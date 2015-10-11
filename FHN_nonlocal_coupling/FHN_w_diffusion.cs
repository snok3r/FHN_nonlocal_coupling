using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser;

namespace FHN_nonlocal_coupling
{
    class FHN_w_diffusion
    {
        public Form1 form; // to access Form's controls
        // variables and arrays
        private bool deltaCoupl; // bool for deciding which equation solves
        private int n, m;
        private double hx, ht; // steps
        private double l, TB; // bounds; l is for x and TB/TBound is for t
        private double[] x, t;

        private double[,] u, v;
        private double alpha, beta, gamma; // v's equation constants
        private double a; // f constant
        private double b, d; // b is before coupling, d is a delay in delta Kernel
        private double Iext;

        // strings and parsers with initials expression formulas
        //public String SUx0;
        //public Parser PUx0;
        
        // properties
        public int N
        {   // quantity of u,v x's
            get { return this.n; }
            set { this.n = value; }
        }

        public int M
        {   // quantity of u,v t's
            get { return this.m; }
            set { this.m = value; }
        }

        public double L 
        {   // x's segment
            get { return this.l; }
            set { this.l = value; }
        }

        public double T
        {   // t's segment
            get { return this.TB; }
            set { this.TB = value; }
        }

        public double Alpha
        {
            get { return this.alpha; }
            set { this.alpha = value; }
        }
        
        public double Beta
        {
            get { return this.beta; }
            set { this.beta = value; }
        }

        public double Gamma
        {
            get { return this.gamma; }
            set { this.gamma = value; }
        }

        public double A
        {   // f's constant
            get { return this.a; }
            set { this.a = value; }
        }

        public double B
        {
            get { return this.b; }
            set { this.b = value; }
        }

        public double D
        {
            get { return this.d; }
            set { this.d = value; }
        }

        public double I
        {   // current
            get { return this.Iext; }
            set { this.Iext = value; }
        }
        
        public bool Eq
        { 
            get { return this.deltaCoupl; }
            set { this.deltaCoupl = value; }
        }

        // constructors

        public FHN_w_diffusion() { } // kind of destructor

        public FHN_w_diffusion(double alpha, double beta, double gamma, double a,double b, double d, double l, double TB, double Iext, int m, int n, bool deltaCoupl, Form1 form)
        {
            this.alpha = alpha;
            this.beta = beta;
            this.gamma = gamma;
            this.a = a;
            this.b = b;
            this.d = d;
            this.l = l;
            this.TB = TB;
            this.Iext = Iext;
            this.n = n;
            this.m = m;
            this.deltaCoupl = deltaCoupl;
            this.form = form;

            //this.PF = new Parser(); this.PF.Mode = Mode.RAD;
        }

        // methods
        public void Load(int m, int n, double l, double TB)
        {   // initialize/declare arrays and steps
            // If we want to change one of the parameters: n, m, l, TB,
            // then it needs to call this (plus Intiials) functions again.
            this.n = n;
            this.m = m;

            this.hx = 2 * l / n; // step for x
            this.ht = TB / m;  // step for t

            this.x = new double[n + 1]; // arrange x's
            for (int i = 0; i < n + 1; i++) this.x[i] = - this.l + i * this.hx;

            this.t = new double[m + 1]; // arrange t's
            for (int j = 0; j < m + 1; j++) this.t[j] = j * this.ht;

            this.u = new double[m + 1, n + 1];
            this.v = new double[m + 1, n + 1];
        }

        public void Initials(int n)
        {   // Initialize initials

            for (int i = 0; i < n + 1; i++)
            {	// setting an initial waves at t = 0
                this.u[0, i] = u_x_0(x[i]);
                this.v[0, i] = v_x_0(x[i]);
            }
        }

        public void NeumannCondition(int j)
        {
            // Neumann condition at x = -l and x = l
            this.u[j, 0] = this.hx * u_0_t(t[j]) + this.u[j, 1]; // at x = -l
            this.u[j, this.n] = this.hx * u_l_t(t[j]) + this.u[j, this.n - 1]; // at x = l
        }
        /*
        public void Solve() 
	    {   // If we changed ONLY eps, gamma, b, d, Kernel (delta or usual), f,
            // then just recall this function.

            //this.SF = form.txtBoxF.Text; // parses f expression to string once Solve() is called

            if (this.deltaCoupl)
            {
                double step = this.ht / (this.hx * this.hx);
                for (int j = 0; j < this.m; j++)
                {
                    if ((j % ((this.m) / 4)) == 0)
                    {   // updating progress bar
                        form.prBarSolve.Value++;
                    }

                    this.v[j + 1, 0] = this.v[j, 0] + this.ht * this.eps * (this.u[j, 0] - this.gamma * this.v[j, 0]);
                    for (int i = 1; i < this.n; i++)
                    {
                        this.u[j + 1, i] = this.u[j, i] + step * (this.u[j, i - 1] - 2 * this.u[j, i] + this.u[j, i + 1]) + this.ht * f(this.u[j, i]) - this.ht * this.v[j, i];
                        this.v[j + 1, i] = this.v[j, i] + this.ht * this.eps * (this.u[j, i] - this.gamma * this.v[j, i]);
                    }
                    this.v[j + 1, this.n] = this.v[j, this.n] + this.ht * this.eps * (this.u[j, this.n] - this.gamma * this.v[j, this.n]);

                    NeumannCondition(j+1);
                }

                if (form.prBarSolve.Value < 4) form.prBarSolve.Value = 4;
            }
            else
            {   // with nonlocal coupling
                for (int j = 0; j < this.m; j++)
                {
                    if ((j % ((this.m) / 4)) == 0)
                    {   // updating progress bar
                        form.prBarSolve.Value++;
                    }
                    for (int i = 0; i < this.n + 1; i++)
                    {
                        this.u[j + 1, i] = this.u[j, i] * (1 - this.ht) + this.ht * (Integral(j, i) + f(this.u[j, i]) - this.v[j, i]);
                        this.v[j + 1, i] = this.v[j, i] + this.ht * this.eps * (this.u[j, i] - this.gamma * this.v[j, i]);
                    }
                }

                if (form.prBarSolve.Value < 4) form.prBarSolve.Value = 4;
            }

	    }*/

        
        public void SolveBeta1()
        {
            // If we changed ONLY alpha, beta, gamma, b, d, Kernel, f or Iext,
            // then just recall this function.

            int prBarMax = 10;
            form.prBarSolve.Maximum = prBarMax;

            int i, j, k;

            k = Convert.ToInt32(this.d / this.hx);
            this.d = this.hx * k;
            form.txtBoxD.Text = Convert.ToString(this.d);

            double step = this.ht / (this.hx * this.hx);

            double[] P = new double[this.n + 1];
            double[] Q = new double[this.n + 1];

            double[] ai = new double[3] { 0, -step, 1 };
            double[] bi = new double[3] { -1, -1 - 2 * step, 1 };
            double[] ci = new double[3] { -1, -step, 0 };
            double[] di = new double[this.n + 1];
            di[0] = 0; di[this.n] = 0; // if Neumann condition changes (smth except du/dn = zero), it needs to be commented

            P[0] = ci[0] / bi[0];
            for (i = 1; i < this.n; i++) P[i] = ci[1] / (bi[1] - ai[1] * P[i - 1]);
            P[this.n] = ci[2] / (bi[2] - ai[2] * P[this.n - 1]);

            for (j = 0; j < this.m; j++)
            {
                if ((j % ((this.m) / prBarMax)) == 0)
                {   // updating progress bar
                    form.prBarSolve.Value++;
                }

                //di[0] = this.ht * u_0_t(this.t[j]); // if Neumann condition is not a zero
                Q[0] = -di[0] / bi[0];
                for (i = 1; i < this.n; i++)
                {
                    if (this.deltaCoupl)
                    {
                        if (this.b != 0)
                        {
                            if (i - k <= 1) // if x - d <= -l
                            {
                                if (i + k <= n - 1) // if x - d <= -l and x + d <= l
                                    di[i] = this.u[j, i] + this.ht * (this.b * (this.u[j, 1] + this.u[j, i + k] - 2 * this.u[j, i]) + f(this.u[j, i]) - this.v[j, i] + this.Iext);
                                else if (i + k > n - 1) // if x - d <= -l and x + d > l
                                    di[i] = this.u[j, i] + this.ht * (this.b * (this.u[j, 1] + this.u[j, n - 1] - 2 * this.u[j, i]) + f(this.u[j, i]) - this.v[j, i] + this.Iext);
                            }
                            else if (i - k > 1) // if x - d > -l
                            {
                                if (i + k <= n - 1) // if x - d > -l and x + d <= l
                                    di[i] = this.u[j, i] + this.ht * (this.b * (this.u[j, i - k] + this.u[j, i + k] - 2 * this.u[j, i]) + f(this.u[j, i]) - this.v[j, i] + this.Iext);
                                else if (i + k > n - 1)  // if x - d > -l and x + d > l
                                    di[i] = this.u[j, i] + this.ht * (this.b * (this.u[j, i - k] + this.u[j, n - 1] - 2 * this.u[j, i]) + f(this.u[j, i]) - this.v[j, i] + this.Iext);
                            }
                        }
                        else if (this.b == 0)
                            di[i] = this.u[j, i] + this.ht * (f(this.u[j, i]) - this.v[j, i] + this.Iext);
                    }
                    else if (this.b != 0)
                        di[i] = this.u[j, i] + this.ht * (this.b * (Integral(j, i) - this.u[j, i]) + f(this.u[j, i]) - this.v[j, i] + this.Iext);
                    else if (this.b == 0)
                        di[i] = this.u[j, i] + this.ht * (f(this.u[j, i]) - this.v[j, i] + this.Iext);

                    Q[i] = (ai[1] * Q[i - 1] - di[i]) / (bi[1] - ai[1] * P[i - 1]);
                }
                //di[this.n] = this.ht * u_l_t(this.t[j]); // if Neumann condition is not a zero
                Q[this.n] = (ai[2] * Q[this.n - 1] - di[this.n]) / (bi[2] - ai[2] * P[this.n - 1]);

                this.u[j + 1, this.n] = Q[this.n];
                for (i = this.n - 1; i > -1; i--) u[j + 1, i] = P[i] * this.u[j + 1, i + 1] + Q[i];

                for (i = 0; i < this.n + 1; i++) v[j + 1, i] = (this.v[j, i] + this.ht * (this.alpha * this.u[j + 1, i] + this.gamma)) / (1 + this.beta * this.ht);
            }

            if (form.prBarSolve.Value < prBarMax) form.prBarSolve.Value = prBarMax;
        }
        

        /*        
        public void SolveBeta2()
        {
            // If we changed ONLY eps, gamma or f,
            // then just recall this function.

            // reaction-diffusion equation
            double step = this.ht / (this.hx * this.hx);

            double[] P = new double[this.n + 1];
            double[] Q = new double[this.n + 1];

            double[] ai = new double[3] { 0, -step, 1 };
            double[] bi = new double[3] { -1, -1 - 2 * step, 1 };
            double[] ci = new double[3] { -1, -step, 0 };
            double[] di = new double[this.n + 1];
            di[0] = 0; di[this.n] = 0; // if Neumann condition changes (smth except du/dn = zero), it needs to be commented

            P[0] = ci[0] / bi[0];
            for (int i = 1; i < this.n; i++) P[i] = ci[1] / (bi[1] - ai[1] * P[i - 1]);
            P[this.n] = ci[2] / (bi[2] - ai[2] * P[this.n - 1]);

            for (int j = 0; j < this.m; j++)
            {
                if ((j % ((this.m) / 3)) == 0)
                {   // updating progress bar
                    form.prBarSolve.Value++;
                }

                for (int i = 0; i < this.n + 1; i++) v[j + 1, i] = (this.v[j, i] + this.ht * this.eps * this.u[j, i]) / (1 + this.eps * this.gamma * this.ht);

                Q[0] = - di[0] / bi[0];
                //di[0] = this.ht * u_0_t(this.t[j]); // if Neumann condition is not a zero
                for (int i = 1; i < this.n; i++)
                {
                    di[i] = this.u[j, i] + ht * (f(this.u[j, i]) - this.v[j + 1, i]);
                    Q[i] = (ai[1] * Q[i - 1] - di[i]) / (bi[1] - ai[1] * P[i - 1]);
                }
                //di[this.n] = this.ht * u_l_t(this.t[j]); // if Neumann condition is not a zero
                Q[this.n] = (ai[2] * Q[this.n - 1] - di[this.n]) / (bi[2] - ai[2] * P[this.n - 1]);

                this.u[j + 1, n] = Q[this.n];
                this.u[j + 1, n - 1] = Q[this.n];
                for (int i = this.n - 2; i > -1; i--) u[j + 1, i] = P[i] * this.u[j + 1, i + 1] + Q[i];


            }
            if (form.prBarSolve.Value < 4) form.prBarSolve.Value = 4;
        }*/
        

        public double GetX(int i) { return this.x[i]; }

        public double GetT(int j) { return this.t[j]; }
        
        public double GetU(int j, int i) { return this.u[j, i]; }
        
        public double GetV(int j, int i) { return this.v[j, i]; }

        // various functions
        private double Integral(int j, int i)
        {   // Trapezoidal rule, uniform grid
            // integrating at point (t[j], x[i]) from -l to l
            double sum = 0;
            int k; // k is iteration variable for integrating (n+1 in number)
            sum += Kernel(this.x[i] - this.x[0]) * this.u[j, 0];
            for (k = 1; k < this.n; k++) sum += 2 * Kernel(this.x[i] - this.x[k]) * this.u[j, k];
            sum += Kernel(this.x[i] - this.x[this.n]) * this.u[j, this.n];

            return this.hx * sum / 2;
        }

        private double Kernel(double z)
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
            
            //PUx0.Evaluate(SUx0.Replace("x", x.ToString()));
            //return PUx0.Result;
            
            //return Math.Exp(-x * x / 2) / (2 * Math.PI);
            
            //return 1.0 / 2 * Math.Exp(-Math.Abs(x + 2));
        }

        private double v_x_0(double x) { return -0.624; } // initial v wave at t = 0

        private double u_0_t(double t) { return 0.0; } // Neumann boundary condition at x = -l

        private double u_l_t(double t) { return 0.0; } // Neumann boundary condition at x = l
    }
}
