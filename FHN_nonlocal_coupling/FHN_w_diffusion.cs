using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHN_nonlocal_coupling
{
    class FHN_w_diffussion
    {
        public WindowPDE form; // to access Form's controls

        // variables and arrays
        private double hx, ht; // steps
        private double[] x, t;
        private double[,] u, v;
        
        // properties
        public int N
        {   // quantity of u,v x's
            get;
            set;
        }

        public int M
        {   // quantity of u,v t's
            get;
            set;
        }

        public double L
        {   // bound x's segment
            get;
            set;
        }

        public double T
        {   // bound t's segment
            get;
            set;
        }

        public double Alpha
        {   // v's equation constants
            get;
            set;
        }

        public double Beta
        {   // v's equation constants
            get;
            set;
        }

        public double Gamma
        {   // v's equation constants
            get;
            set;
        }

        public double A
        {   // f's constant
            get;
            set;
        }

        public double B
        {   // constant before coupling
            get;
            set;
        }

        public double D
        {   // a delay in delta Kernel
            get;
            set;
        }

        public double I
        {   // current
            get;
            set;
        }

        public bool Eq
        {   // bool for deciding which equation solves
            get;
            set;
        }

        //////////////////
        // Constructors //
        //////////////////

        // Constructor with default values
        public FHN_w_diffussion(WindowPDE f)
        {
            N = 2000;
            M = 2000;
            L = 50.0;
            T = 40.0;
            Alpha = 0.08;
            Beta = 0.064;
            Gamma = 0.056;
            A = 0.1;
            B = 0.0;
            D = 1.0;
            I = 0.0;
            Eq = true;

            this.form = f;
        }

        public FHN_w_diffussion(double alpha, double beta, double gamma, double a,double b, double d, double l, double TB, double iExt, int m, int n, bool deltaCoupl, WindowPDE form)
        {
            this.Alpha = alpha;
            this.Beta = beta;
            this.Gamma = gamma;
            this.A = a;
            this.B = b;
            this.D = d;
            this.L = l;
            this.T = TB;
            this.I = iExt;
            this.N = n;
            this.M = m;
            this.Eq = deltaCoupl;
            this.form = form;
        }

        // methods
        public void load(int m, int n, double l, double TB)
        {   // initialize/declare arrays and steps
            // If we want to change one of the parameters: n, m, l, TB,
            // then it needs to call this (plus Intiials) functions again.
            this.N = n;
            this.M = m;

            this.hx = 2 * l / n; // step for x
            this.ht = TB / m;  // step for t

            this.x = new double[n + 1]; // arrange x's
            for (int i = 0; i < n + 1; i++) this.x[i] = - this.L + i * this.hx;

            this.t = new double[m + 1]; // arrange t's
            for (int j = 0; j < m + 1; j++) this.t[j] = j * this.ht;

            this.u = new double[m + 1, n + 1];
            this.v = new double[m + 1, n + 1];
        }

        public void initials(int n)
        {   // Initialize initials

            for (int i = 0; i < n + 1; i++)
            {	// setting an initial waves at t = 0
                this.u[0, i] = u_x_0(x[i]);
                this.v[0, i] = v_x_0(x[i]);
            }
        }

        public void solve()
        {
            // If we changed ONLY alpha, beta, gamma, b, d, Kernel, f or Iext,
            // then just recall this function.

            int prBarMax = 10;
            form.prBarSolve.Maximum = prBarMax;

            
            int k = Convert.ToInt32(this.D / this.hx);
            this.D = this.hx * k;
            form.txtBoxD.Text = Convert.ToString(this.D);

            double step = this.ht / (this.hx * this.hx);

            double[] P = new double[this.N + 1];
            double[] Q = new double[this.N + 1];

            double[] ai = new double[3] { 0, -step, 1 };
            double[] bi = new double[3] { -1, -1 - 2 * step, 1 };
            double[] ci = new double[3] { -1, -step, 0 };
            double[] di = new double[this.N + 1];
            di[0] = 0; di[this.N] = 0; // if Neumann condition changes (smth except du/dn = zero), it needs to be commented

            P[0] = ci[0] / bi[0];
            for (int i = 1; i < this.N; i++) P[i] = ci[1] / (bi[1] - ai[1] * P[i - 1]);
            P[this.N] = ci[2] / (bi[2] - ai[2] * P[this.N - 1]);

            for (int j = 0; j < this.M; j++)
            {
                if ((j % ((this.M) / prBarMax)) == 0)
                {   // updating progress bar
                    form.prBarSolve.Value++;
                }

                //di[0] = this.ht * u_0_t(this.t[j]); // if Neumann condition is not a zero
                Q[0] = -di[0] / bi[0];
                for (int i = 1; i < this.N; i++)
                {
                    if (this.Eq)
                    {
                        if (this.B != 0)
                        {
                            if (i - k <= 1) // if x - d <= -l
                            {
                                if (i + k <= N - 1) // if x - d <= -l and x + d <= l
                                    di[i] = this.u[j, i] + this.ht * (this.B * (this.u[j, 1] + this.u[j, i + k] - 2 * this.u[j, i]) + f(this.u[j, i]) - this.v[j, i] + this.I);
                                else if (i + k > N - 1) // if x - d <= -l and x + d > l
                                    di[i] = this.u[j, i] + this.ht * (this.B * (this.u[j, 1] + this.u[j, N - 1] - 2 * this.u[j, i]) + f(this.u[j, i]) - this.v[j, i] + this.I);
                            }
                            else if (i - k > 1) // if x - d > -l
                            {
                                if (i + k <= N - 1) // if x - d > -l and x + d <= l
                                    di[i] = this.u[j, i] + this.ht * (this.B * (this.u[j, i - k] + this.u[j, i + k] - 2 * this.u[j, i]) + f(this.u[j, i]) - this.v[j, i] + this.I);
                                else if (i + k > N - 1)  // if x - d > -l and x + d > l
                                    di[i] = this.u[j, i] + this.ht * (this.B * (this.u[j, i - k] + this.u[j, N - 1] - 2 * this.u[j, i]) + f(this.u[j, i]) - this.v[j, i] + this.I);
                            }
                        }
                        else if (this.B == 0)
                            di[i] = this.u[j, i] + this.ht * (f(this.u[j, i]) - this.v[j, i] + this.I);
                    }
                    else if (this.B != 0)
                        di[i] = this.u[j, i] + this.ht * (this.B * (integral(j, i) - this.u[j, i]) + f(this.u[j, i]) - this.v[j, i] + this.I);
                    else if (this.B == 0)
                        di[i] = this.u[j, i] + this.ht * (f(this.u[j, i]) - this.v[j, i] + this.I);

                    Q[i] = (ai[1] * Q[i - 1] - di[i]) / (bi[1] - ai[1] * P[i - 1]);

                    if (Double.IsNaN(Q[i]))
                    {   // catching Q is NaN and show Error label
                        form.lblError.Visible = true;
                        break;
                    }

                }
                //di[this.n] = this.ht * u_l_t(this.t[j]); // if Neumann condition is not a zero
                Q[this.N] = (ai[2] * Q[this.N - 1] - di[this.N]) / (bi[2] - ai[2] * P[this.N - 1]);

                this.u[j + 1, this.N] = Q[this.N];
                for (int i = this.N - 1; i > -1; i--) u[j + 1, i] = P[i] * this.u[j + 1, i + 1] + Q[i];

                double nextV;
                for (int i = 0; i < this.N + 1; i++)
                {
                    nextV = (this.v[j, i] + this.ht * (this.Alpha * this.u[j + 1, i] + this.Gamma)) / (1 + this.Beta * this.ht);
                    if (Double.IsNaN(nextV))
                    {   // catching V is NaN and show Error label
                        form.lblError.Visible = true;
                        break;
                    }
                    else
                        v[j + 1, i] = nextV;
                }
            }

            if (form.prBarSolve.Value < prBarMax) form.prBarSolve.Value = prBarMax;
        }

        public double getX(int i)
        { 
            return this.x[i]; 
        }

        public double getT(int j) 
        { 
            return this.t[j]; 
        }
        
        public double getU(int j, int i)
        { 
            return this.u[j, i]; 
        }
        
        public double getV(int j, int i)
        { 
            return this.v[j, i]; 
        }

        // various functions
        private double integral(int j, int i)
        {   // Trapezoidal rule, uniform grid
            // integrating at point (t[j], x[i]) from -l to l
            double sum = 0;
            int k; // k is iteration variable for integrating (n+1 in number)
            sum += kernel(this.x[i] - this.x[0]) * this.u[j, 0];
            for (k = 1; k < this.N; k++) sum += 2 * kernel(this.x[i] - this.x[k]) * this.u[j, k];
            sum += kernel(this.x[i] - this.x[this.N]) * this.u[j, this.N];

            return this.hx * sum / 2;
        }

        private double kernel(double z)
        {
            //return Math.Exp(-z * z / 2) / Math.Sqrt(2 * Math.PI);
            return 1.0 / 2 * Math.Exp(-Math.Abs(z + 2));
        }

        private double f(double u){
            //return - u * (u - 1) * (u - this.a); 
            return u - u * u * u / 3;
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
