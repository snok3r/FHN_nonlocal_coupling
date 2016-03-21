﻿using System;
using System.Linq;
using System.Collections.Generic;
using FHN_nonlocal_coupling.Model;

namespace FHN_nonlocal_coupling.Controller
{
    abstract class AbstractController<T>
    {
        protected bool allocate = true;
        protected bool solveFurther = false;
        protected static HashSet<String> paramsNeedReload;

        protected AbstractFHN[] fhn;
        protected ViewElements viewElements;

        abstract public double chartXMin();
        abstract public double chartXMax();
        abstract public int trackBarMax();
        abstract public void plot();
        abstract public void plot(int j);

        protected AbstractController(ViewElements viewElements)
        { this.viewElements = viewElements; }

        /// <summary>
        /// if 'b' is true, then
        /// arrays need to be reallocated
        /// </summary>
        public void toAllocate(bool b)
        { allocate = b; }

        /// <summary>
        /// if 'b' is true, then
        /// we're solving further
        /// </summary>
        public void toSolveFurther(bool b)
        { solveFurther = b; }

        /// <summary>
        /// Makes all the data point to null
        /// </summary>
        public void dispose()
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

            if (typeof(T) == typeof(PDE))
                fhn = PDE.allocArray(size);
            else if (typeof(T) == typeof(ODE))
                fhn = ODE.allocArray(size);
            else throw new ArgumentException("must be ODE or PDE class");

            viewElements.pg1.SelectedObject = fhn[0];

            if (size == 2) viewElements.pg2.SelectedObject = fhn[1];
            else viewElements.pg2.SelectedObject = null;
        }

        /// <summary>
        /// Checks whether you need to reallocate
        /// arrays or not
        /// </summary>
        public void checkToLoad(String label)
        {
            if (paramsNeedReload.Contains(label))
                allocate = true;
            else
                allocate = false;
        }

        /// <summary>
        /// Call to solve equations
        /// <para>Returns -1, if computation error occurred,
        /// 0 otherwise.</para>
        /// </summary>
        public int solve()
        {
            viewElements.progressBar.Value = 0;
            viewElements.progressBar.Maximum = 3;
            viewElements.trackBar.Maximum = trackBarMax();

                for (int i = 0; i < fhn.Length; i++)
                    if (allocate && !solveFurther)
                        fhn[i].allocate();
                    else
                        fhn[i].reload();
            viewElements.progressBar.Value++;

            for (int i = 0; i < fhn.Length; i++)
                if (solveFurther)
                    fhn[i].initialsFurther();
                else
                    fhn[i].initials();
            viewElements.progressBar.Value++;

            for (int i = 0; i < fhn.Length; i++)
                if (fhn[i].solve() != 0) return -1;
            viewElements.progressBar.Value++;

            return 0;
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
