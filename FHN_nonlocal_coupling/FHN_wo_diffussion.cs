using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHN_nonlocal_coupling
{
    class FHN_wo_diffussion
    {
        public WindowODE form; // to access Form's controls
        // variables and arrays
        private double h, ht; // step
        private double[] t; // time
        private double[] u, v, u_null, v1, v2; // v1, v2 are nullclines

        // properties
        public int N
        {   // quantity of u,v t's
            get;
            set;
        }

        public double L
        {   // bound for Kernel
            get;
            set;
        }

        public double T
        {   // t's segment
            get;
            set;
        }

        public double U0
        {   // intiial u
            get;
            set;
        }

        public double V0
        {   // intiial v
            get;
            set;
        }

        public double I
        {   // current
            get;
            set;
        }

        public double Tau
        {   // v's constant
            get;
            set;
        }

        public double Alpha
        {   // v's constant
            get;
            set;
        }

        public double Beta
        {   // v's constant
            get;
            set;
        }

        public double A
        {   // f's constant if non-classical
            get;
            set;
        }

        public bool Eq
        {   // Is the equation with classical non-linearity?
            get;
            set;
        }

        // constructors

        // Constructor with default parameters
        public FHN_wo_diffussion(WindowODE f)
        {
            N = 1000;
            L = 2.5;
            T = 100.0;
            U0 = 1.0;
            V0 = 0.1;
            I = 0.5;
            Tau = 12.5;
            Alpha = 0.7;
            Beta = 0.8;
            A = 0.1;
            Eq = true;

            form = f;
        }

        public FHN_wo_diffussion(int n, double l, double TB, double u0, double v0, double iExt, double tau, double alpha, double beta, double a, bool classical, WindowODE form)
        {
            this.N = n;
            this.L = l;
            this.U0 = u0;
            this.V0 = v0;
            this.T = TB;
            this.I = iExt;
            this.Tau = tau;
            this.Alpha = alpha;
            this.Beta = beta;
            this.A = a;
            this.Eq = classical;

            this.form = form;
        }

        // methods
        public void load(int n, double l, double TB)
        {   // initialize/declare arrays and steps
            // If we want to change one of the parameters: n or TB,
            // then it needs to call this (plus Intiials) functions again.
            this.N = n;
            this.L = l;
            this.T = TB;

            this.h = 2 * l / n; //
            this.ht = TB / n;  // step for t

            this.t = new double[n + 1]; // arrange t's
            for (int j = 0; j < n + 1; j++) this.t[j] = j * this.ht;

            this.u = new double[n + 1];
            this.v = new double[n + 1];

            this.v1 = new double[n + 1];
            this.v2 = new double[n + 1];
            this.u_null = new double[n + 1];
            for (int j = 0; j < n + 1; j++) this.u_null[j] = - this.L + j * this.h;
        }

        public void initials(double u0, double v0)
        {   // Initialize initials
            this.u[0] = u0;
            this.v[0] = v0;
        }

        public void solve()
        {   // If we changed ONLY alpha, beta, Iext, Kernel or f (either a),
            // then just recall this function.

            int prBarMax = 10;
            form.prBarSolveWOD.Maximum = prBarMax;

            double utemp, vtemp;

            for (int j = 0; j < this.N; j++)
            {
                utemp = this.u[j] + this.ht * f1(this.u[j], this.v[j]);
                vtemp = this.v[j] + this.ht * f2(this.u[j], this.v[j]);

                if (Double.IsNaN(utemp))
                {   // catching NaN
                    form.lblErrorWOD.Visible = true;
                    break;
                }
                else if (Double.IsNaN(vtemp))
                {   // catching NaN
                    form.lblErrorWOD.Visible = true;
                    break;
                }

                //// Euler's 1st order
                //this.u[j + 1] = utemp;
                //this.v[j + 1] = vtemp;

                // Euler's 2nd order
                this.u[j + 1] = this.u[j] + this.ht / 2 * (f1(this.u[j], this.v[j]) + f1(utemp, vtemp));
                this.v[j + 1] = this.v[j] + this.ht / 2 * (f2(this.u[j], this.v[j]) + f2(utemp, vtemp));

                if ((j % ((this.N) / prBarMax)) == 0)
                {   // updating progress bar
                    form.prBarSolveWOD.Value++;
                }
            }
            
            nullclines();

            if (form.prBarSolveWOD.Value < prBarMax) form.prBarSolveWOD.Value = prBarMax;
        }

        public void nullclines()
        {
            if (this.Beta != 0.0)
            {
                for (int j = 0; j < this.N + 1; j++)
                {
                    this.v1[j] = f(this.u_null[j]) + this.I;
                    this.v2[j] = (this.u_null[j] + Alpha) / Beta;
                }
            }
        }

        public double getT(int j)
        { 
            return this.t[j]; 
        }

        public double getU(int j)
        { 
            return this.u[j]; 
        }

        public double getV(int j)
        { 
            return this.v[j]; 
        }

        public double getUN(int j)
        { 
            return this.u_null[j]; 
        }

        public double getV1(int j)
        { 
            return this.v1[j]; 
        }

        public double getV2(int j)
        { 
            return this.v2[j]; 
        }

        // various functions
        private double f1(double u, double v)
        {
            return f(u) - v + I;
        }

        private double f2(double u, double v)
        {
            return (u + Alpha - Beta * v) / Tau;
        }

        private double f(double u) 
        {
            if (Eq)
                return u - u * u * u / 3;
            else
                return - u * (u - 1) * (u - A);
        }
    }
}
