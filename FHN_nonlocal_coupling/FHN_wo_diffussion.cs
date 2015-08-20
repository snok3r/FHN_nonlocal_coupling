using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHN_nonlocal_coupling
{
    class FHN_wo_diffussion
    {
        public Form1 form; // to access Form's controls
        // variables and arrays
        private bool w_coupl; // with coupling?
        private int n;
        private double h, ht; // steps (h is for integrating)
        private double l, TB; // bounds; l is for Kernel, TB/TBound is for t
        private double[] t; // time

        private double[] v, w, v_null, w1, w2; // w1, w2 are nullclines
        private double v0, w0; // initials
        private double Iext, tau, a, b; // equation's constants

        // properties
        public int N
        {   // quantity of u,v x's
            get { return this.n; }
            set { this.n = value; }
        }

        public double L
        {
            get { return this.l; }
            set { this.l = value; }
        }

        public double T
        {   // t's segment
            get { return this.TB; }
            set { this.TB = value; }
        }

        public double V0
        {
            get { return this.v0; }
            set { this.v0 = value; }
        }

        public double W0
        {
            get { return this.w0; }
            set { this.w0 = value; }
        }

        public double I
        {
            get { return this.Iext; }
            set { this.Iext = value; }
        }

        public double Tau
        {
            get { return this.tau; }
            set { this.tau = value; }
        }

        public double A
        {
            get { return this.a; }
            set { this.a = value; }
        }

        public double B
        {
            get { return this.b; }
            set { this.b = value; }
        }

        public bool Eq
        {   // Is the equation with coupling?
            get { return this.w_coupl; }
            set { this.w_coupl = value; }
        }

        // constructors
        public FHN_wo_diffussion() { } // kind of destructor

        public FHN_wo_diffussion(int n, double l, double TB, double v0, double w0, double Iext, double tau, double a, double b, bool w_coupl, Form1 form)
        {
            this.n = n;
            this.l = l;
            this.v0 = v0;
            this.w0 = w0;
            this.TB = TB;
            this.Iext = Iext;
            this.tau = tau;
            this.a = a;
            this.b = b;
            this.w_coupl = w_coupl;

            this.form = form;
        }

        // methods
        public void Load(int n, double l, double TB, double v0, double w0, bool w_coupl)
        {   // initialize/declare arrays and steps
            // If we want to change one of the parameters: n, TB or w_coupl,
            // then it needs to call this (plus Intiials) functions again.
            this.n = n;
            this.l = l;
            this.TB = TB;
            this.v0 = v0;
            this.w0 = w0;
            this.w_coupl = w_coupl;

            this.h = 2 * l / n; // for integrating from -l to l
            this.ht = TB / n;  // step for t

            this.t = new double[n + 1]; // arrange t's
            for (int j = 0; j < n + 1; j++) this.t[j] = j * this.ht;

            this.v = new double[n + 1];
            this.w = new double[n + 1];

            this.w1 = new double[n + 1];
            this.w2 = new double[n + 1];
            this.v_null = new double[n + 1];
            for (int j = 0; j < n + 1; j++) this.v_null[j] = - this.l + j * this.h;
        }

        public void Initials(double v0, double w0)
        {   // Initialize initials
            this.v[0] = v0;
            this.w[0] = w0;
        }

        public void Solve()
        {   // If we changed ONLY a, b, Iext, Kernel or f,
            // then just recall this function.

            if (!(this.w_coupl))
            {
                for (int j = 0; j < this.n; j++)
                {
                    this.v[j + 1] = this.v[j] + this.ht * (f(this.v[j]) - this.w[j] + this.Iext);
                    this.w[j + 1] = this.w[j] + this.ht / this.tau * (this.v[j] + this.a - this.b * this.w[j]);
                }
            }
            else
            {   // with nonlocal coupling
                for (int j = 0; j < this.n; j++)
                {
                    this.v[j + 1] = 0;
                    this.w[j + 1] = 0;
                }
            }

        }

        public void Nullclines()
        {
            if (this.b != 0.0)
            {
                for (int j = 0; j < this.n + 1; j++)
                {
                    this.w1[j] = this.v_null[j] - Math.Pow(this.v_null[j], 3.0) / 3 + this.Iext;
                    this.w2[j] = (this.v_null[j] + this.a) / this.b; ;
                }
            }
        }

        public double GetT(int j) { return (this.t[j]); }

        public double GetV(int j) { return this.v[j]; }

        public double GetW(int j) { return this.w[j]; }

        public double GetVN(int j) { return this.v_null[j]; } // for nullclines

        // various functions
        private double f(double v) { return v - v * v * v / 3; }

        /*private double Integral(int j, int i)
        {   // Trapezoidal rule, uniform grid
            // integrating at point (t[j], x[i]) from -l to l
            double sum = 0;
            int k; // k is iteration variable for integrating (n+1 in number)
            sum += Kernel(this.t[i] - this.t[0]) * this.t[j, 0];
            for (k = 1; k < this.n; k++) sum += 2 * Kernel(this.t[i] - this.x[k]) * this.u[j, k];
            sum += Kernel(this.x[i] - this.x[this.n]) * this.u[j, this.n];

            return this.h * sum / 2;
        } 

        private double Kernel(double z)
        {
            return z;
        }
        */
    }
}
