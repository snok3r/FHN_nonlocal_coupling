using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathParser;

namespace FHN_nonlocal_coupling
{
    class FHN
    {
        public Form1 form; // to access Form's controls
        // variables and arrays
        private bool eq_diff; // bool for deciding which equation solves
        private int n, m;
        private double h, hx, ht; // steps (h is for integrating)
        private double l, TB; // bounds; l is for x and TB/TBound is for t
        private double[] x, t;

        private double[,] u, v;
        private double eps, gamma; // v's equation constants
        private double a; // f constant

        // strings and parsers with initials expression formulas
        //public String SF;
        //public Parser PF;
        
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

        public double Eps
        {
            get { return this.eps; }
            set { this.eps = value; }
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
        
        public bool Eq
        {   // Is the equation a diffusuion equation?
            get { return this.eq_diff; }
            set { this.eq_diff = value; }
        }

        // constructor
        public FHN(double eps, double gamma, double a, double l, double TB, int m, int n, bool eq_diff, Form1 form)
        {
            this.eps = eps;
            this.gamma = gamma;
            this.a = a;
            this.l = l;
            this.TB = TB;
            this.n = n;
            this.m = m;
            this.eq_diff = eq_diff;
            this.form = form;

            //this.PF = new Parser(); this.PF.Mode = Mode.RAD;
        }

        // methods
        public void Load(int m, int n, bool eq_diff, double l, double TB)
        {   // initialize/declare arrays and steps
            // If we want to change one of the parameters: n, m, eq_diff, l, TB,
            // then it needs to call this (plus Intiials) functions again.
            this.n = n;
            this.m = m;
            this.eq_diff = eq_diff;

            this.h = 2 * l / n; // for integrating from -l to l
            this.hx = 2 * l / n; // step for x
            this.ht = TB / m;  // step for t

            this.x = new double[n + 1]; // arrange x's
            for (int i = 0; i < n + 1; i++) this.x[i] = - this.l + i * this.hx;

            this.t = new double[m + 1]; // arrange t's
            for (int j = 0; j < m + 1; j++) this.t[j] = j * this.ht;

            this.u = new double[m + 1, n + 1];
            this.v = new double[m + 1, n + 1];
        }

        public void Initials(int m, int n)
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

        public void Solve() 
	    {   // If we changed ONLY eps, gamma, Kernel or f,
            // then just recall this function.

            //this.SF = form.txtBoxF.Text; // parses f expression to string once Solve() is called

            if (this.eq_diff)
            {   // reaction-diffusion equation
                double step = this.ht / (this.hx * this.hx);
                for (int j = 0; j < this.m; j++)
                {
                    if ((j % ((this.m) / 3)) == 0)
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
                    if ((j % ((this.m) / 3)) == 0)
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

	    }

        /*
        public void SolveBeta1()
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

                Q[0] = - di[0] / bi[0];
                //di[0] = this.ht * u_0_t(this.t[j]); // if Neumann condition is not a zero
                for (int i = 1; i < this.n; i++)
                {
                    di[i] = this.u[j, i] + ht * (f(this.u[j, i]) - this.v[j, i]);
                    Q[i] = (ai[1] * Q[i - 1] - di[i]) / (bi[1] - ai[1] * P[i - 1]);
                }
                //di[n] = this.ht * u_l_t(this.t[j]); // if Neumann condition is not a zero
                Q[this.n] = (ai[2] * Q[this.n - 1] - di[this.n]) / (bi[2] - ai[2] * P[this.n - 1]);

                this.u[j + 1, n] = Q[this.n];
                this.u[j + 1, n - 1] = Q[this.n];
                for (int i = this.n - 2; i > -1; i--) u[j + 1, i] = P[i] * this.u[j + 1, i + 1] + Q[i];

                for (int i = 0; i < this.n + 1; i++) v[j + 1, i] = (this.v[j, i] + this.ht * this.eps * this.u[j + 1, i]) / (1 + this.eps * this.gamma * this.ht);
            }
            if (form.prBarSolve.Value < 4) form.prBarSolve.Value = 4;
        }
        */

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
                //di[n] = this.ht * u_l_t(this.t[j]); // if Neumann condition is not a zero
                Q[this.n] = (ai[2] * Q[this.n - 1] - di[this.n]) / (bi[2] - ai[2] * P[this.n - 1]);

                this.u[j + 1, n] = Q[this.n];
                this.u[j + 1, n - 1] = Q[this.n];
                for (int i = this.n - 2; i > -1; i--) u[j + 1, i] = P[i] * this.u[j + 1, i + 1] + Q[i];


            }
            if (form.prBarSolve.Value < 4) form.prBarSolve.Value = 4;
        }
        */

        public double GetX(int i)
        {
            return this.x[i];
        }

        public double GetT(int j)
        {
            return this.t[j];
        }

        public double GetU(int j, int i)
        {
            return this.u[j, i];
        }

        public double GetV(int j, int i)
        {
            return this.v[j, i];
        }

        // various functions
        private double Integral(int j, int i)
        {   // Trapezoidal rule, uniform grid
            // integrating at point (t[j], x[i]) from -l to l
            double sum = 0;
            int k; // k is iteration variable for integrating (n+1 in number)
            sum += Kernel(this.x[i] - this.x[0]) * this.u[j, 0];
            for (k = 1; k < this.n; k++) sum += 2 * Kernel(this.x[i] - this.x[k]) * this.u[j, k];
            sum += Kernel(this.x[i] - this.x[this.n]) * this.u[j, this.n];

            return this.h * sum / 2;
        }

        private double Kernel(double z)
        {
            return z;
        }

        private double f(double u)
        {	// f(0) = f(1) = 0; f'(0) < 0 and f'(1) < 0 ???
            return - u * (u - 1) * (u - this.a);
        }

        private double u_x_0(double x)
        {	// initial u wave at t = 0
            //if (x < 0.0F) return -1.0;
            //else return 0.0;
            //PUx0.Evaluate(SUx0.Replace("x", x.ToString()));
            //return PUx0.Result;
            return Math.Exp(-x * x) / 0.1;
        }

        private double v_x_0(double x)
        {	// initial v wave at t = 0
            return 0.0;
        }

        private double u_0_t(double t)
        {   // Neumann boundary condition at x = -l
            return 0;
        }

        private double u_l_t(double t)
        {   // Neumann boundary condition at x = l
            return 0;
        }
    }
}
