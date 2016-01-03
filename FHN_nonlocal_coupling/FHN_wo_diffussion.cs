using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

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

        [Description("F's constant in non-classical non-linearity (classical == false)")]
        public double A
        {   // f's constant if non-classical
            get;
            set;
        }

        [Description("Whether this is a classical non-linearity or not")]
        public bool Classical
        {   // Is the equation with classical non-linearity?
            get;
            set;
        }

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
            Classical = true;

            form = f;
        }

        // methods
        public void load()
        {   // initialize/declare arrays and steps
            // If we want to change one of the parameters: n or TB,
            // then it needs to call this (plus Intiials) functions again.

            h = 2 * L / N; //
            ht = T / N;  // step for t

            t = new double[N + 1]; // arrange t's
            for (int j = 0; j < N + 1; j++) 
                t[j] = j * ht;

            u = new double[N + 1];
            v = new double[N + 1];

            v1 = new double[N + 1];
            v2 = new double[N + 1];
            
            u_null = new double[N + 1];
            for (int j = 0; j < N + 1; j++) 
                u_null[j] = - L + j * h;
        }

        public void initials()
        {   // Initialize initials
            u[0] = U0;
            v[0] = V0;
        }

        public int solve()
        {   // If we changed ONLY alpha, beta, Iext, Kernel or f (either a),
            // then just recall this function.

            double utemp, vtemp;

            for (int j = 0; j < N; j++)
            {
                utemp = u[j] + ht * f1(u[j], v[j]);
                vtemp = v[j] + ht * f2(u[j], v[j]);

                if (Double.IsNaN(utemp) || Double.IsNaN(vtemp))
                    return -1;

                //// Euler's 1st order
                //u[j + 1] = utemp;
                //v[j + 1] = vtemp;

                // Euler's 2nd order
                u[j + 1] = u[j] + ht / 2 * (f1(u[j], v[j]) + f1(utemp, vtemp));
                v[j + 1] = v[j] + ht / 2 * (f2(u[j], v[j]) + f2(utemp, vtemp));
            }
            
            nullclines();

            return 0;
        }

        public void nullclines()
        {
            if (Beta != 0.0)
            {
                for (int j = 0; j < N + 1; j++)
                {
                    v1[j] = f(u_null[j]) + I;
                    v2[j] = (u_null[j] + Alpha) / Beta;
                }
            }
        }

        public double getT(int j)
        { 
            return t[j]; 
        }

        public double getU(int j)
        { 
            return u[j]; 
        }

        public double getV(int j)
        { 
            return v[j]; 
        }

        public double getUN(int j)
        { 
            return u_null[j]; 
        }

        public double getV1(int j)
        { 
            return v1[j]; 
        }

        public double getV2(int j)
        { 
            return v2[j]; 
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
            if (Classical)
                return u - u * u * u / 3;
            else
                return - u * (u - 1) * (u - A);
        }
    }
}
