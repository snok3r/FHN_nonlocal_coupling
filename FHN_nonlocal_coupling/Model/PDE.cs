using MathParser;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace FHN_nonlocal_coupling.Model
{
    public class PDE : AbstractFHN
    {
        // variables and arrays
        private double[] x;
        private double[,] u, v;
        private Velocity[] velocities;
        private Height[] heights;

        private int varM;
        private double varD;
        private double varDiff;

        // Constructor with default values
        public PDE()
            : base()
        {
            N = 1000;
            M = 1000;
            L = 50.0;
            T = 100.0;
            B = 0.0;
            d = 1.0;
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
                if (value >= 20) varL = value;
            }
        }

        [Description("Delay in Delta-Kernel")]
        public double d
        {
            get { return varD; }
            set
            {
                if (value > 0) varD = value;
            }
        }

        [Description("Diffusion Coefficient")]
        public double D
        {
            get { return varDiff; }
            set
            {
                if (value > 0) varDiff = value;
            }
        }

        [Description("constant in front of Kernel")]
        public double B { get; set; }

        [Description("Delta-Kernel or not?")]
        public bool DeltaCoupling { get; set; }

        // methods
        public override void allocate()
        {   // initialize/declare arrays and steps
            // If we want to change one of the parameters: n, m, l, TB,
            // then it needs to call this (plus Intiials) functions again.
            hx = 2 * L / (N - 1); // step for x
            ht = T / (M - 1);  // step for t

            x = new double[N]; // arrange x's
            t = new double[M]; // arrange t's
            velocities = new Velocity[M];
            heights = new Height[M];

            Parallel.Invoke(
                () =>
                {
                    if (x != null)
                        for (int i = 0; i < N; i++)
                            x[i] = -L + i * hx;
                },
                () =>
                {
                    if (t != null && velocities != null && heights != null)
                        for (int j = 0; j < M; j++)
                        {
                            t[j] = j * ht;
                            velocities[j] = new Velocity();
                            heights[j] = new Height();
                        }
                }
            );

            u = new double[M, N];
            v = new double[M, N];
        }

        public override void reload()
        {
            for (int j = 0; j < M; j++)
            {
                velocities[j].calculated = false;
                heights[j].calculated = false;
            }
        }

        public override void initials()
        {   // Initialize initials
            // setting an initial waves at t = 0
            initials("", "");
        }

        public override void initials(String UX0, String VX0)
        {   // Initialize initials
            // setting an initial waves at t = 0
            Parallel.Invoke(
                () =>
                {
                    if (u != null)
                    {
                        if (UX0.Equals(""))
                        {
                            for (int i = 0; i < N; i++)
                                u[0, i] = u_x_0(x[i]);
                        }
                        else
                        {
                            Parser pUX0 = new Parser();
                            for (int i = 0; i < N; i++)
                            {
                                pUX0.Evaluate(UX0.Replace("x", x[i].ToString()));
                                u[0, i] = pUX0.Result;
                            }
                        }
                    }
                },
                () =>
                {
                    if (v != null)
                    {
                        if (VX0.Equals(""))
                        {
                            for (int i = 0; i < N; i++)
                                v[0, i] = v_x_0(x[i]);
                        }
                        else
                        {
                            if (v != null)
                            {
                                Parser pVX0 = new Parser();
                                for (int i = 0; i < N; i++)
                                {
                                    pVX0.Evaluate(VX0.Replace("x", x[i].ToString()));
                                    v[0, i] = pVX0.Result;
                                }
                            }
                        }
                    }
                }
            );
        }

        public override void initialsFurther()
        {
            // setting an initial waves
            // at t = T to solve further
            if (u != null && v != null)
                for (int i = 0; i < N; i++)
                {
                    u[0, i] = u[M - 1, i];
                    v[0, i] = v[M - 1, i];
                }
        }

        public override bool solve()
        {
            // If we changed ONLY eps, beta, gamma, b, d, Kernel, f or Iext,
            // then just recall this function.

            double step = D * ht / (hx * hx);

            double[] P = new double[N];
            double[] Q = new double[N];

            double[] ai = new double[3] { 0, -step, 1 };
            double[] bi = new double[3] { -1, -1 - 2 * step, 1 };
            double[] ci = new double[3] { -1, -step, 0 };
            double[] di = new double[N];
            di[0] = 0; di[N - 1] = 0; // if Neumann condition changes (smth except du/dn = zero), it needs to be commented

            P[0] = ci[0] / bi[0];
            for (int i = 1; i < N - 1; i++) P[i] = ci[1] / (bi[1] - ai[1] * P[i - 1]);
            P[N - 1] = ci[2] / (bi[2] - ai[2] * P[N - 2]);

            for (int j = 0; j < M - 1; j++)
                if (!calculateLayerJ(Q, P, ai, bi, di, j))
                    return false;

            return true;
        }

        private bool calculateLayerJ(double[] Q, double[] P, double[] ai, double[] bi, double[] di, int j)
        {
            int k = Convert.ToInt32(d / hx);
            d = hx * k;

            //di[0] = ht * u_0_t(t[j]); // if Neumann condition is not a zero
            Q[0] = -di[0] / bi[0];
            for (int i = 1; i < N - 1; i++)
            {
                calculateDCoeff(di, i, j, k);

                Q[i] = (ai[1] * Q[i - 1] - di[i]) / (bi[1] - ai[1] * P[i - 1]);

                // catching Q is NaN
                if (Double.IsNaN(Q[i]))
                    return false;
            }
            //di[N - 1] = ht * u_l_t(t[j]); // if Neumann condition is not a zero
            Q[N - 1] = (ai[2] * Q[N - 2] - di[N - 1]) / (bi[2] - ai[2] * P[N - 2]);

            // starting back substitution
            u[j + 1, N - 1] = Q[N - 1];
            for (int i = N - 2; i > -1; i--) u[j + 1, i] = P[i] * u[j + 1, i + 1] + Q[i];

            for (int i = 0; i < N; i++)
            {
                double nextV = (v[j, i] + ht * Eps * (u[j + 1, i] + Beta)) / (1 + Eps * Gamma * ht);

                // catching V is NaN
                if (Double.IsNaN(nextV))
                    return false;
                else
                    v[j + 1, i] = nextV;
            }

            return true;
        }

        private void calculateDCoeff(double[] di, int i, int j, int k)
        {
            if (B == 0)
                di[i] = u[j, i] + ht * (f(u[j, i]) - v[j, i] + I);
            else
            {
                if (DeltaCoupling)
                    di[i] = u[j, i] + ht * (B * uDelta(i, j, k) + f(u[j, i]) - v[j, i] + I);
                else
                    di[i] = u[j, i] + ht * (B * (integral(j, i) - u[j, i]) + f(u[j, i]) - v[j, i] + I);
            }
        }

        private double uDelta(int i, int j, int k)
        {
            double uxminusd = 0, uxplusd = 0;
            if (i - k <= 0) // if x - d <= -L
                uxminusd = u[j, 0];
            else // if x - d > -L
                uxminusd = u[j, i - k];

            if (i + k >= N - 1) // x + d >= L
                uxplusd = u[j, N - 1];
            else // if x + d < L
                uxplusd = u[j, i + k];

            return uxminusd + uxplusd - 2 * u[j, i];
        }

        public double getVelocity(int j0)
        {
            if (!velocities[j0].calculated)
                calculateVelocity(j0);

            return velocities[j0].velocity;
        }

        private void calculateVelocity(int j0)
        {
            if (j0 > M - 1)
                return;

            double velocity = 0;

            if (B > -1.5 && I == 0)
                velocity = calculateVelocityBPositive(j0);
            else
                velocity = calculateVelocityNumerical(j0);

            velocities[j0].velocity = velocity;
            velocities[j0].calculated = true;
        }

        private double calculateVelocityBPositive(int j0)
        {
            int k = Convert.ToInt32(d / hx);

            double nominator = 0;
            double denominator = 0;

            nominator += 0.5 * nominatorFunction(N - 1, j0, k);
            denominator += 0.5 * denominatorFunction(N - 1, j0);
            for (int i = 1; i < N - 1; i++)
            {
                nominator += nominatorFunction(i, j0, k);
                denominator += denominatorFunction(i, j0);
            }

            return -nominator / denominator;
        }

        private double denominatorFunction(int i, int j)
        {
            return Math.Pow(diffUx(i, j), 2) + Math.Pow(diffVx(i, j), 2);
        }

        private double nominatorFunction(int i, int j, int k)
        {
            double uij = u[j, i];
            double vij = v[j, i];

            if (B == 0)
                return diffUx(i, j) * (f(uij) - vij) + diffVx(i, j) * Eps * (uij + Beta - Gamma * vij);
            else
                return diffUx(i, j) * (f(uij) + B * uDelta(i, j, k) - vij) + diffVx(i, j) * Eps * (uij + Beta - Gamma * vij);
        }

        private double diffUx(int i, int j)
        {
            if (i <= 0 || i > N - 1 || j < 0 || j > M - 1)
                return 0;

            return (u[j, i] - u[j, i - 1]) / hx;
        }

        private double diffVx(int i, int j)
        {
            if (i <= 0 || i > N - 1 || j < 0 || j > M - 1)
                return 0;

            return (v[j, i] - v[j, i - 1]) / hx;
        }

        private double calculateVelocityNumerical(int j0)
        {
            int deltaj = (int)(1 / ht);

            int j1 = (j0 + deltaj);
            if (j1 > M - 1) // we're out of frame and no need to find X0 max
                return 0;

            int i0 = 0; // X0 max = u[j0, i0]
            int i1 = 0; // X1 max = u[j1, i0]

            if (u != null)
                for (int i = 1; i < N; i++)
                {
                    if (u[j0, i] > u[j0, i0])
                        i0 = i;

                    if (u[j1, i] > u[j1, i1])
                        i1 = i;
                }

            double x0 = i0 * hx; double x1 = i1 * hx;
            double t0 = j0 * ht; double t1 = j1 * ht;

            return (x1 - x0) / (t1 - t0);
        }

        public double getWidth(int j0)
        {
            double width = 0;

            int idx_left = Int32.MinValue;
            int idx_right = Int32.MaxValue;

            int i = 0;
            double ustat = getUStat();
            double height = getHeight(j0);
            while ((u[j0, i++] < ustat + 0.05 * height) && i < N - 1) ;
            idx_left = i;

            while ((u[j0, i++] > ustat + 0.05 * height) && i < N - 1) ;
            idx_right = i;

            if (idx_right >= N - 1 || idx_left < 0)
                width = 0;
            else
                width = (idx_right - idx_left) * hx;

            return width;
        }

        public double getHeight(int j0)
        {
            if (!heights[j0].calculated)
                calculateHeight(j0);

            return heights[j0].height;
        }

        private void calculateHeight(int j0)
        {
            if (j0 > M - 1)
                return;

            double max = Double.NegativeInfinity;

            if (u != null)
                for (int i = 1; i < N; i++)
                    if (u[j0, i] > max)
                        max = u[j0, i];

            heights[j0].height = Math.Abs(max - getUStat());
            heights[j0].calculated = true;
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

            sum += 0.5 * (kernel(xi - x[0]) * u[j, 0] + kernel(xi - x[N - 1]) * u[j, N - 1]);
            for (int k = 1; k < N - 1; k++)
                sum += kernel(xi - x[k]) * u[j, k];

            return hx * sum;
        }

        private double kernel(double z)
        {
            return Math.Exp(-z * z / 2) / Math.Sqrt(2 * Math.PI);
            //return 1.0 / 2 * Math.Exp(-Math.Abs(z + 2));
        }

        private double u_x_0(double x)
        {	// initial u wave at t = 0
            double u0 = -1.199;
            double lb = this.L - 10;
            double rb = this.L - 20;

            if (x < -lb) return 1.0;
            else if ((x >= -lb) && (x <= -rb))
                return (u0 - 1) * (x + rb) / (lb - rb) + u0;
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

        public override void dispose()
        { base.dispose(); x = null; u = null; v = null; }

        internal class Velocity
        {
            internal double velocity;
            internal bool calculated;

            public override string ToString()
            {
                return String.Format("{0}", velocity);
            }
        }

        internal class Height
        {
            internal double height;
            internal bool calculated;

            public override string ToString()
            {
                return String.Format("{0}", height);
            }
        }
    }
}
