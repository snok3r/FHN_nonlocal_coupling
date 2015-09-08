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
        private bool classical; // classical non-linearity?
        private int n;
        private double h, ht; // step
        private double l, TB; // bounds; l is for Kernel, TB/TBound is for t
        private double[] t; // time

        private double[] u, v, u_null, v1, v2; // v1, v2 are nullclines
        private double u0, v0; // initials
        private double Iext, tau, alpha, beta, a; // equation's constants

        // properties
        public int N
        {   // quantity of u,v t's
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

        public double U0
        {   // intiial u
            get { return this.u0; }
            set { this.u0 = value; }
        }

        public double V0
        {   // intiial v
            get { return this.v0; }
            set { this.v0 = value; }
        }

        public double I
        {   // current
            get { return this.Iext; }
            set { this.Iext = value; }
        }

        public double Tau
        {
            get { return this.tau; }
            set { this.tau = value; }
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

        public double A
        {   // f's constant if non-classical
            get { return this.a; }
            set { this.a = value; }
        }

        public bool Eq
        {   // Is the equation with classical non-linearity?
            get { return this.classical; }
            set { this.classical = value; }
        }

        // constructors
        public FHN_wo_diffussion() { } // kind of destructor

        public FHN_wo_diffussion(int n, double l, double TB, double u0, double v0, double Iext, double tau, double alpha, double beta, double a, bool classical, Form1 form)
        {
            this.n = n;
            this.l = l;
            this.u0 = u0;
            this.v0 = v0;
            this.TB = TB;
            this.Iext = Iext;
            this.tau = tau;
            this.alpha = alpha;
            this.beta = beta;
            this.a = a;
            this.classical = classical;

            this.form = form;
        }

        // methods
        public void Load(int n, double l, double TB)
        {   // initialize/declare arrays and steps
            // If we want to change one of the parameters: n or TB,
            // then it needs to call this (plus Intiials) functions again.
            int j;

            this.n = n;
            this.l = l;
            this.TB = TB;

            this.h = 2 * l / n; //
            this.ht = TB / n;  // step for t

            this.t = new double[n + 1]; // arrange t's
            for (j = 0; j < n + 1; j++) this.t[j] = j * this.ht;

            this.u = new double[n + 1];
            this.v = new double[n + 1];

            this.v1 = new double[n + 1];
            this.v2 = new double[n + 1];
            this.u_null = new double[n + 1];
            for (j = 0; j < n + 1; j++) this.u_null[j] = - this.l + j * this.h;
        }

        public void Initials(double u0, double v0)
        {   // Initialize initials
            this.u[0] = u0;
            this.v[0] = v0;
        }

        public void Solve()
        {   // If we changed ONLY alpha, beta, Iext, Kernel or f (either a),
            // then just recall this function.

            int prBarMax = 10;
            form.prBarSolveWOD.Maximum = prBarMax;

            double utemp, vtemp;

            for (int j = 0; j < this.n; j++)
            {
                utemp = this.u[j] + this.ht * f1(this.u[j], this.v[j]);
                vtemp = this.v[j] + this.ht * f2(this.u[j], this.v[j]);

                //// Euler's 1st order
                //this.u[j + 1] = utemp;
                //this.v[j + 1] = vtemp;

                // Euler's 2nd order
                this.u[j + 1] = this.u[j] + this.ht / 2 * (f1(this.u[j], this.v[j]) + f1(utemp, vtemp));
                this.v[j + 1] = this.v[j] + this.ht / 2 * (f2(this.u[j], this.v[j]) + f2(utemp, vtemp));

                if ((j % ((this.n) / prBarMax)) == 0)
                {   // updating progress bar
                    form.prBarSolveWOD.Value++;
                }
            }
            
            Nullclines();

            if (form.prBarSolveWOD.Value < prBarMax) form.prBarSolveWOD.Value = prBarMax;
        }

        public void Nullclines()
        {
            if (this.beta != 0.0)
            {
                for (int j = 0; j < this.n + 1; j++)
                {
                    this.v1[j] = f(this.u_null[j]) + this.Iext;
                    this.v2[j] = (this.u_null[j] + this.alpha) / this.beta;
                }
            }
        }

        public double GetT(int j) { return this.t[j]; }

        public double GetU(int j) { return this.u[j]; }

        public double GetV(int j) { return this.v[j]; }

        public double GetUN(int j) { return this.u_null[j]; } // for nullclines

        public double GetV1(int j) { return this.v1[j]; } // for nullclines

        public double GetV2(int j) { return this.v2[j]; } // for nullclines

        // various functions
        private double f1(double u, double v)
        {
            return f(u) - v + this.Iext;
        }

        private double f2(double u, double v)
        {
            return (u + this.alpha - this.beta * v) / this.tau;
        }

        private double f(double u) 
        {
            if (this.classical)
                return u - u * u * u / 3;
            else
                return - u * (u - 1) * (u - this.a);
        }
    }
}
