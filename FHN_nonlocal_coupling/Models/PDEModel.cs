﻿using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FHN_nonlocal_coupling
{
    class PDEModel
    {
        private PDE[] pdes;

        public void dispose()
        {
            for (int i = 0; i < pdes.Length; i++)
            {
                pdes[i].dispose(); 
                pdes[i] = null;
            }
            pdes = null;
        }

        /// <summary>
        /// Call when you need to reload equations
        /// or to reassign them to property grid
        /// </summary>
        public void loadEquations(bool chckd, PropertyGrid pg1, PropertyGrid pg2)
        {
            int count;
            if (chckd) count = 2;
            else count = 1;

            pdes = new PDE[count];

            for (int i = 0; i < count; i++)
                pdes[i] = new PDE();

            pg1.SelectedObject = pdes[0];

            if (count == 2)
                pg2.SelectedObject = pdes[1];
            else
                pg2.SelectedObject = null;
        }

        /// <summary>
        /// Call to solve equations
        /// <para>Returns -1, if computation error occurred,
        /// 0 otherwise.</para>
        /// </summary>
        public int btnSolveClick(ProgressBar progressBar)
        {
            for (int i = 0; i < pdes.Length; i++)
                pdes[i].load();
            progressBar.Value++;

            for (int i = 0; i < pdes.Length; i++)
                pdes[i].initials();
            progressBar.Value++;

            for (int i = 0; i < pdes.Length; i++)
                if (pdes[i].solve() != 0) return -1;
            progressBar.Value++;

            return 0;
        }

        /// <summary>
        /// Plots full j segment
        /// </summary>
        private void plot(int j, PDE obj, int numEq, Chart chart)
        {
            for (int i = 0; i < obj.N; i++)
            {
                double x = obj.getX(i);

                chart.Series[2 * numEq].Points.AddXY(x, obj.getU(j, i));
                chart.Series[2 * numEq + 1].Points.AddXY(x, obj.getV(j, i));
            }
        }

        /// <summary>
        /// Plots layer 'j'
        /// </summary>
        public void plotLayer(int j, Chart chart)
        {
            for (int i = 0; i < pdes.Length; i++)
                plot(j, pdes[i], i, chart);
        }

        public void plotTimerTick(TrackBar trackBar, Chart chart)
        {
            if (trackBar.Value == trackBarMax())
            {   // if it is the last t segment, plot it and reset trBar.Value
                plotLayer(trackBar.Value, chart);
                trackBar.Value = 0;
            }
            else
            {
                trackBar.Value++;
                plotLayer(trackBar.Value, chart);
            }
        }


        /// <summary>
        /// Returns formatted String with velocity
        /// at trackBarValue point
        /// </summary>
        public String getVelocity(int trackBarValue)
        {
            return Math.Round(pdes[0].getVelocity(trackBarValue), 3).ToString() + " x/t";
        }

        public double chartXMin()
        {
            return -(pdes[0].L - 0.1);
        }

        public double chartXMax()
        {
            return pdes[0].L + 0.1;
        }

        public int trackBarMax()
        {
            return pdes[0].M - 1;
        }
    }
}
