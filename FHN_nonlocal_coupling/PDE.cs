﻿using System;
using System.ComponentModel;

namespace FHN_nonlocal_coupling
{
    class PDE : AbstractFHN
    {
        // variables and arrays
        private double[] x;
        private double[,] u, v;

        private int varM;
        private double varD;

        // Constructor with default values
        public PDE() : base()
        {
            N = 2000;
            M = 2000;
            L = 50.0;
            T = 40.0;
            B = 0.0;
            D = 1.0;
            I = 0.0;
            DeltaCoupling = true;
        }

        // properties
        public int M
        {   // quantity of u,v t's
            get { return varM; }
            set 
            {
                if (value > POINTS_THRESHOLD) varM = value;
            }
        }

        [Description("Interval for x [-L, L]")]
        public override double L
        {   // bound x's segment
            get { return varL; }
            set
            {
                if (value > 0) varL = value;
            }
        }

        [Description("Delay in Delta-Kernel")]
        public double D
        {   // a delay in delta Kernel
            get { return varD; }
            set
            {
                if (value > 0) varD = value;
            }
        }

        [Description("constant in front of Kernel")]
        public double B { get; set; }

        [Description("Delta-Kernel or not?")]
        public bool DeltaCoupling { get; set; }

        // methods
        public override void load()
        {   // initialize/declare arrays and steps
            // If we want to change one of the parameters: n, m, l, TB,
            // then it needs to call this (plus Intiials) functions again.
            hx = 2 * L / N; // step for x
            ht = T / M;  // step for t

            x = new double[N + 1]; // arrange x's
            for (int i = 0; i < N + 1; i++) 
                x[i] = - L + i * hx;

            t = new double[M + 1]; // arrange t's
            for (int j = 0; j < M + 1; j++) 
                t[j] = j * ht;

            u = new double[M + 1, N + 1];
            v = new double[M + 1, N + 1];
        }

        public override void initials()
        {   // Initialize initials
            for (int i = 0; i < N + 1; i++)
            {	// setting an initial waves at t = 0
                u[0, i] = u_x_0(x[i]);
                v[0, i] = v_x_0(x[i]);
            }
        }

        public override int solve()
        {
            // If we changed ONLY eps, beta, gamma, b, d, Kernel, f or Iext,
            // then just recall this function.
            
            double step = ht / (hx * hx);

            double[] P = new double[N + 1];
            double[] Q = new double[N + 1];

            double[] ai = new double[3] { 0, -step, 1 };
            double[] bi = new double[3] { -1, -1 - 2 * step, 1 };
            double[] ci = new double[3] { -1, -step, 0 };
            double[] di = new double[N + 1];
            di[0] = 0; di[N] = 0; // if Neumann condition changes (smth except du/dn = zero), it needs to be commented

            P[0] = ci[0] / bi[0];
            for (int i = 1; i < N; i++) P[i] = ci[1] / (bi[1] - ai[1] * P[i - 1]);
            P[N] = ci[2] / (bi[2] - ai[2] * P[N - 1]);

            for (int j = 0; j < M; j++)
            {
                int extCode = progonkaJLayer(Q, P, ai, bi, di, j);
                if (extCode != 0)
                    return -1;
            }

            return 0;
        }

        private int progonkaJLayer(double[] Q, double[] P, double[] ai, double[] bi, double[] di, int j)
        {
            int k = Convert.ToInt32(D / hx);
            D = hx * k;

            //di[0] = ht * u_0_t(t[j]); // if Neumann condition is not a zero
            Q[0] = -di[0] / bi[0];
            for (int i = 1; i < N; i++)
            {
                calculateDCoeff(di, i, j, k);

                Q[i] = (ai[1] * Q[i - 1] - di[i]) / (bi[1] - ai[1] * P[i - 1]);

                // catching Q is NaN
                if (Double.IsNaN(Q[i]))
                    return -1;
            }
            //di[n] = ht * u_l_t(t[j]); // if Neumann condition is not a zero
            Q[N] = (ai[2] * Q[N - 1] - di[N]) / (bi[2] - ai[2] * P[N - 1]);

            u[j + 1, N] = Q[N];
            for (int i = N - 1; i > -1; i--) u[j + 1, i] = P[i] * u[j + 1, i + 1] + Q[i];

            for (int i = 0; i < N + 1; i++)
            {
                double nextV = (v[j, i] + ht * (Eps * u[j + 1, i] + Alpha)) / (1 + Beta * ht);

                // catching V is NaN
                if (Double.IsNaN(nextV))
                    return -1;
                else
                    v[j + 1, i] = nextV;
            }

            return 0;
        }

        private void calculateDCoeff(double[] di, int i, int j, int k)
        {
            if (DeltaCoupling)
            {
                if (B != 0)
                {
                    if (i - k <= 1) // if x - d <= -l
                    {
                        if (i + k <= N - 1) // if x - d <= -l and x + d <= l
                            di[i] = u[j, i] + ht * (B * (u[j, 1] + u[j, i + k] - 2 * u[j, i]) + f(u[j, i]) - v[j, i] + I);
                        else if (i + k > N - 1) // if x - d <= -l and x + d > l
                            di[i] = u[j, i] + ht * (B * (u[j, 1] + u[j, N - 1] - 2 * u[j, i]) + f(u[j, i]) - v[j, i] + I);
                    }
                    else if (i - k > 1) // if x - d > -l
                    {
                        if (i + k <= N - 1) // if x - d > -l and x + d <= l
                            di[i] = u[j, i] + ht * (B * (u[j, i - k] + u[j, i + k] - 2 * u[j, i]) + f(u[j, i]) - v[j, i] + I);
                        else if (i + k > N - 1)  // if x - d > -l and x + d > l
                            di[i] = u[j, i] + ht * (B * (u[j, i - k] + u[j, N - 1] - 2 * u[j, i]) + f(u[j, i]) - v[j, i] + I);
                    }
                }
                else
                    di[i] = u[j, i] + ht * (f(u[j, i]) - v[j, i] + I);
            }
            else if (B != 0)
                di[i] = u[j, i] + ht * (B * (integral(j, i) - u[j, i]) + f(u[j, i]) - v[j, i] + I);
            else
                di[i] = u[j, i] + ht * (f(u[j, i]) - v[j, i] + I);
        }

        public double getVelocity(int j0)
        {
            if (u != null)
            {
                int deltaj = (int)(1 / ht);

                int i0 = 0; // X0 max = u[j0, i0]
                for (int i = 1; i < N + 1; i++)
                    if (u[j0, i] > u[j0, i0])
                        i0 = i;

                int j1 = (j0 + deltaj);
                if (j1 > M + 1) return 0; // we're out of frame

                int i1 = 0; // X1 max = u[j1, i0]

                for (int i = 1; i < N + 1; i++)
                    if (u[j1, i] > u[j1, i1])
                        i1 = i;

                double x0 = i0 * hx; double x1 = i1 * hx;
                double t0 = j0 * ht; double t1 = j1 * ht;

                return (x1 - x0) / (t1 - t0);
            }

            return 0;
        }

        public double getX(int i)
        { return x[i]; }
        
        public double getU(int j, int i)
        { return u[j, i]; }
        
        public double getV(int j, int i)
        { return v[j, i]; }

        // various functions
        private double integral(int j, int i)
        {   // Trapezoidal rule, uniform grid
            // integrating at point (t[j], x[i]) from -l to l
            double sum = 0;
            double xi = x[i];

            sum += kernel(xi - x[0]) * u[j, 0];
            for (int k = 1; k < N; k++) sum += 2 * kernel(xi - x[k]) * u[j, k];
            sum += kernel(xi - x[N]) * u[j, N];

            return hx * sum / 2;
        }

        private double kernel(double z)
        {
            //return Math.Exp(-z * z / 2) / Math.Sqrt(2 * Math.PI);
            return 1.0 / 2 * Math.Exp(-Math.Abs(z + 2));
        }            

        private double u_x_0(double x)
        {	// initial u wave at t = 0
            double u0 = -1.199;
            if (x < -40) return 1.0;
            else if ((x >= -40) && (x <= -30))
                return (u0 - 1) * (x + 30) / 10 + u0;
            else
                return u0;
            
            //return Math.Exp(-x * x / 2) / (2 * Math.PI);
            
            //return 1.0 / 2 * Math.Exp(-Math.Abs(x + 2));
        }

        private double v_x_0(double x)
        {   // initial v wave at t = 0
            return -0.624; 
        } 

        private double u_0_t(double t) { return 0.0; } // Neumann boundary condition at x = -l

        private double u_l_t(double t) { return 0.0; } // Neumann boundary condition at x = l
    }
}
