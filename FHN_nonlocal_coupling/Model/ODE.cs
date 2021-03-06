﻿using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace FHN_nonlocal_coupling.Model
{
    public class ODE : AbstractFHN
    {
        // variables and arrays
        private double[] u, v;
        private double[] u_null, v1, v2; // nullclines

        // Constructor with default parameters
        public ODE()
            : base()
        {
            N = 1000;
            L = 2.5;
            T = 100.0;
            U0 = 1.0;
            V0 = 0.1;
            I = 0.5;
        }

        // properties
        [Description("Initial U(0)")]
        public double U0 { get; set; }

        [Description("Initial V(0)")]
        public double V0 { get; set; }

        // methods
        public override void allocate()
        {   // initialize/declare arrays and steps
            // If we want to change one of the parameters: n or TB,
            // then it needs to call this (plus Intiials) functions again.

            hx = 2 * L / (N - 1); //
            ht = T / (N - 1);  // step for t

            t = new double[N];
            u_null = new double[N];
            Parallel.Invoke(
                () =>
                {
                    if (t != null)
                        for (int j = 0; j < N; j++)
                            t[j] = j * ht;
                },

                () =>
                {
                    if (u_null != null)
                        for (int j = 0; j < N; j++)
                            u_null[j] = -L + j * hx;
                }
            );

            u = new double[N];
            v = new double[N];

            v1 = new double[N];
            v2 = new double[N];
        }

        public override void initials()
        {   // Initialize initials
            u[0] = U0;
            v[0] = V0;
        }

        public override void initialsFurther()
        {
            U0 = u[N - 1];
            V0 = v[N - 1];
            initials();
        }

        public override bool solve()
        {   // If we changed ONLY alpha, beta, Iext, Kernel or f (either a),
            // then just recall this function.

            for (int j = 0; j < N - 1; j++)
            {
                double u_j = f1(u[j], v[j]);
                double v_j = f2(u[j], v[j]);

                double utemp = u[j] + ht * u_j;
                double vtemp = v[j] + ht * v_j;

                if (Double.IsNaN(utemp) || Double.IsNaN(vtemp))
                    return false;

                u[j + 1] = u[j] + ht * 0.5 * (u_j + f1(utemp, vtemp));
                v[j + 1] = v[j] + ht * 0.5 * (v_j + f2(utemp, vtemp));
            }

            nullclines();

            return true;
        }

        public void nullclines()
        {
            if (Gamma != 0.0)
            {
                Parallel.Invoke(
                    () =>
                    {
                        if (v1 != null)
                            for (int j = 0; j < N; j++)
                                v1[j] = f(u_null[j]) + I;
                    },
                    () =>
                    {
                        if (v2 != null)
                            for (int j = 0; j < N; j++)
                                v2[j] = (u_null[j] + Beta) / Gamma;
                    }
                );
            }
            else
            {
                for (int j = 0; j < N; j++)
                {
                    v1[j] = f(u_null[j]) + I;
                    v2[j] = (u_null[j] + Beta) / 0.000001;
                }
            }
        }

        public double getU(int j)
        { return u[j]; }

        public double getV(int j)
        { return v[j]; }

        public double getUN(int j)
        { return u_null[j]; }

        public double getV1(int j)
        { return v1[j]; }

        public double getV2(int j)
        { return v2[j]; }

        // various functions
        private double f1(double u, double v)
        { return f(u) - v + I; }

        private double f2(double u, double v)
        { return Eps * (u + Beta - Gamma * v); }

        public override void dispose()
        {
            base.dispose();
            u = null; v = null;
            u_null = null; v1 = null; v2 = null;
        }
    }
}
