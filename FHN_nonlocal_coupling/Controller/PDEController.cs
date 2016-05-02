using FHN_nonlocal_coupling.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace FHN_nonlocal_coupling.Controller
{
    public class PDEController : AbstractController<PDE>
    {
        private bool threadStarted = false;

        public PDEController(ViewElements viewElements)
            : base(viewElements)
        {
            if (paramsNeedReload == null)
                paramsNeedReload = new HashSet<String>(new String[] { "N", "M", "T", "L" });
        }

        /// <summary>
        /// Returns chart's minimum X bound
        /// </summary>
        public override double chartXMin()
        { return -fhn[0].L; }

        /// <summary>
        /// Returns chart's maximum X bound
        /// </summary>
        public override double chartXMax()
        { return fhn[0].L; }

        /// <summary>
        /// Returns maximum value for trackBar
        /// </summary>
        public override int trackBarMax()
        { return fhn[0].M - 1; }

        /// <summary>
        /// Plots layer 'tj'
        /// </summary>
        public override void plot(int tj)
        {
            clearPlot();

            for (int i = 0; i < fhn.Length; i++)
                plot(tj, fhn[i], i);
        }

        /// <summary>
        /// Plots layer tj with variable trackbar value
        /// </summary>
        public override void plot()
        {
            if (viewElements.trackBar.Value < trackBarMax())
                plot(viewElements.trackBar.Value++);
            else
                viewElements.trackBar.Value = 0;
        }

        /// <summary>
        /// Plots full j segment
        /// </summary>
        private void plot(int j, PDE obj, int numEq)
        {
            for (int i = 0; i < obj.N; i++)
            {
                double x = obj.getX(i);

                viewElements.chart.Series[2 * numEq].Points.AddXY(x, obj.getU(j, i));
                viewElements.chart.Series[2 * numEq + 1].Points.AddXY(x, obj.getV(j, i));
            }
        }

        /// <summary>
        /// Returns height at trackBarValue point
        /// </summary>
        public double getHeight(int trackBarValue)
        {
            if (!threadStarted)
                calculatePropertiesInThread(trackBarValue);

            return Math.Round(fhn[0].getHeight(trackBarValue), 3);
        }

        /// <summary>
        /// Returns velocity at trackBarValue point
        /// </summary>
        public double getVelocity(int trackBarValue)
        {
            if (!threadStarted)
                calculatePropertiesInThread(trackBarValue);

            return Math.Round(fhn[0].getVelocity(trackBarValue), 3);
        }

        private void calculatePropertiesInThread(int startingJ)
        {
            int M = fhn[0].M;

            threadStarted = true;
            // (max - start) calculates around 90% (if startingJ = 0) of left velocities in concurrent thread
            int start = startingJ + (M - 1) / 10;
            int max = M - 1;

            if (max - start > 50) // if there's a sense to calculate it concurrently
            {
                ThreadPool.QueueUserWorkItem(arg =>
                {
                    try
                    {
                        while (Thread.CurrentThread.IsAlive)
                        {
                            Stopwatch stopwatch = Stopwatch.StartNew(); //creates and start the instance of Stopwatch
                            for (int j = start; j < max; j++)
                            {
                                if (!threadStarted)
                                {
                                    Debug.WriteLine("Interrupted properties calculation on j = " + j);
                                    break;
                                }
                                fhn[0].getHeight(j);
                                fhn[0].getVelocity(j);
                            }
                            stopwatch.Stop();
                            if (threadStarted)
                                Debug.WriteLine("Properties calculated in " + stopwatch.ElapsedMilliseconds / 1000.0 + "sec");
                            throw new ThreadInterruptedException();
                        }
                    }
                    catch (ThreadInterruptedException)
                    {
                        Thread.CurrentThread.Interrupt();
                    }
                });
            }
        }

        public void interruptThread()
        {
            threadStarted = false;
        }

        public override void dispose()
        {
            interruptThread();
            base.dispose();
        }
    }
}
