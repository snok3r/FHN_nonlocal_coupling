using FHN_nonlocal_coupling.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace FHN_nonlocal_coupling.Controller
{
    public class PDEController : AbstractController<PDE>
    {
        private bool abort;

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

        public override bool solve(IProgress<int> progress)
        {
            if (!base.solve(progress))
                return false;

            calculateProperties(0);
            progress.Report(4);
            return true;
        }

        /// <summary>
        /// Returns height at trackBarValue point
        /// </summary>
        public double getHeight(int trackBarValue)
        {
            return Math.Round(fhn[0].getHeight(trackBarValue), 3);
        }

        /// <summary>
        /// Returns velocity at trackBarValue point
        /// </summary>
        public double getVelocity(int trackBarValue)
        {
            return Math.Round(fhn[0].getVelocity(trackBarValue), 3);
        }

        /// <summary>
        /// calculates 100% (if start = 0) of velocities in concurrent thread
        /// </summary>
        private void calculateProperties(int start)
        {
            abort = false;
            int max = fhn[0].M;
            
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int j = start; j < max; j++)
            {
                if (abort)
                    break;
                fhn[0].getHeight(j);
                fhn[0].getVelocity(j);
            }
            stopwatch.Stop();
            Debug.WriteLineIf(!abort, "Properties calculated in " + stopwatch.ElapsedMilliseconds / 1000.0 + "sec");
        }

        public void interruptThread()
        {
            abort = true;
        }

        public override void dispose()
        {
            interruptThread();
            base.dispose();
        }
    }
}
