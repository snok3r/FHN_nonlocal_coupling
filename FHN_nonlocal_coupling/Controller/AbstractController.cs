﻿using FHN_nonlocal_coupling.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FHN_nonlocal_coupling.Controller
{
    public abstract class AbstractController<T> : IControllable where T : AbstractFHN, new()
    {
        protected bool allocate = true;
        protected bool solveFurther = false;
        protected static HashSet<String> paramsNeedReload;

        protected T[] fhn;
        protected ViewElements viewElements;

        abstract public double chartXMin();
        abstract public double chartXMax();
        abstract public void plot();
        abstract public void plot(int j);
        abstract public int trackBarMax();

        protected AbstractController(ViewElements viewElements)
        { this.viewElements = viewElements; }

        /// <summary>
        /// if 'b' is true, then
        /// we're solving further
        /// </summary>
        public void toSolveFurther(bool b)
        { solveFurther = b; }

        /// <summary>
        /// Makes all the data point to null
        /// </summary>
        public virtual void dispose()
        {
            for (int i = 0; i < fhn.Length; i++)
            {
                fhn[i].dispose();
                fhn[i] = null;
            }
            fhn = null;
        }

        /// <summary>
        /// Call when you need to reload equations
        /// or to reassign them to property grid
        /// </summary>
        public void reallocate(bool chckd)
        {
            int size;
            if (chckd) size = 2;
            else size = 1;

            fhn = new T[size];
            for (int i = 0; i < size; i++)
                fhn[i] = new T();

            viewElements.pg1.SelectedObject = fhn[0];

            if (size == 2) viewElements.pg2.SelectedObject = fhn[1];
            else viewElements.pg2.SelectedObject = null;
        }

        /// <summary>
        /// Checks whether you need to reallocate
        /// arrays or not
        /// </summary>
        public void checkToLoad(IEnumerable<String> parameters)
        {
            // need to reallocate, if paramsNeedReload contains given label
            allocate = paramsNeedReload.Overlaps(parameters);
        }

        /// <summary>
        /// Call to solve equations
        /// <para>Returns false, if computation error occurred,
        /// true otherwise.</para>
        /// </summary>
        public virtual bool solve(IProgress<int> progress)
        {
            Stopwatch stopwatch = Stopwatch.StartNew(); //creates and start the instance of Stopwatch
            for (int i = 0; i < fhn.Length; i++)
                if (allocate && !solveFurther)
                    fhn[i].allocate();
                else
                    fhn[i].reload();
            progress.Report(33);

            for (int i = 0; i < fhn.Length; i++)
            {
                if (solveFurther)
                    fhn[i].initialsFurther();
                else
                {
                    if (viewElements.ux0 != null && viewElements.vx0 != null && viewElements.customInitials != null)
                    {
                        if (viewElements.customInitials.Checked)
                            fhn[i].initials(viewElements.ux0.Text, viewElements.vx0.Text);
                        else
                            fhn[i].initials();
                    }
                    else
                        fhn[i].initials();
                }
            }
            progress.Report(66);

            for (int i = 0; i < fhn.Length; i++)
                if (!fhn[i].solve())
                    return false;

            stopwatch.Stop();
            Debug.WriteLine("Solved in " + stopwatch.ElapsedMilliseconds / 1000.0 + "sec");
            return true;
        }

        /// <summary>
        /// Caclulates and then returns two stationary
        /// point in List: {u_stationary1, v_stationary1, u_stationary2, ...}
        /// </summary>
        public List<double> getStat()
        {
            List<double> result = new List<double>();

            for (int i = 0; i < fhn.Length; i++)
            {
                fhn[i].calculateStationary();
                result.Add(fhn[i].getUStat());
                result.Add(fhn[i].getVStat());
            }

            return result;
        }

        /// <summary>
        /// Clears all the plot data
        /// </summary>
        public virtual void clearPlot()
        {
            for (int i = 0; i < viewElements.chart.Series.Count(); i++)
                viewElements.chart.Series[i].Points.Clear();
        }
    }
}
