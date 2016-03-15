using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FHN_nonlocal_coupling
{
    abstract class AbstractController<T>
    {
        protected AbstractFHN[] fhn;

        abstract public double chartXMax();
        abstract public int trackBarMax();

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
        public void load(bool chckd, PropertyGrid pg1, PropertyGrid pg2)
        {
            int count;
            if (chckd) count = 2;
            else count = 1;

            if (typeof(T) == typeof(PDE))
                fhn = PDE.allocArray(count);
            else if (typeof(T) == typeof(ODE))
                fhn = ODE.allocArray(count);
            else throw new ArgumentException("must be ODE or PDE class");
            
            pg1.SelectedObject = fhn[0];

            if (count == 2)
                pg2.SelectedObject = fhn[1];
            else
                pg2.SelectedObject = null;
        }

        /// <summary>
        /// Call to solve equations
        /// <para>Returns -1, if computation error occurred,
        /// 0 otherwise.</para>
        /// </summary>
        public int solve(ProgressBar progressBar)
        {
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
