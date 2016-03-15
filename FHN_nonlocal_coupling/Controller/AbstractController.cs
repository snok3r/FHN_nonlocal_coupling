using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FHN_nonlocal_coupling.Model;

namespace FHN_nonlocal_coupling.Controller
{
    abstract class AbstractController<T>
    {
        protected AbstractFHN[] fhn;
        protected Chart chart;
        protected PropertyGrid pg1, pg2;
        protected ProgressBar progressBar;
        protected TrackBar trackBar;

        abstract public double chartXMax();
        abstract public int trackBarMax();
        abstract public void plot();
        abstract public void plot(int j);
        abstract public void clearPlot();

        protected AbstractController(Chart chart, PropertyGrid pg1, PropertyGrid pg2, ProgressBar progressBar, TrackBar trackBar)
        {
            this.chart = chart;
            this.pg1 = pg1;
            this.pg2 = pg2;
            this.progressBar = progressBar;
            this.trackBar = trackBar;
        }

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
        public void load(bool chckd)
        {
            int size;
            if (chckd) size = 2;
            else size = 1;

            if (typeof(T) == typeof(PDE))
                fhn = PDE.allocArray(size);
            else if (typeof(T) == typeof(ODE))
                fhn = ODE.allocArray(size);
            else throw new ArgumentException("must be ODE or PDE class");
            
            pg1.SelectedObject = fhn[0];

            if (size == 2) pg2.SelectedObject = fhn[1];
            else pg2.SelectedObject = null;
        }

        /// <summary>
        /// Call to solve equations
        /// <para>Returns -1, if computation error occurred,
        /// 0 otherwise.</para>
        /// </summary>
        public int solve()
        {
            progressBar.Value = 0;
            progressBar.Maximum = 3;
            trackBar.Maximum = trackBarMax();

            for (int i = 0; i < fhn.Length; i++)
                fhn[i].load();
            progressBar.Value++;

            for (int i = 0; i < fhn.Length; i++)
                fhn[i].initials();
            progressBar.Value++;

            for (int i = 0; i < fhn.Length; i++)
                if (fhn[i].solve() != 0) return -1;
            progressBar.Value++;

            return 0;
        }
    }
}
