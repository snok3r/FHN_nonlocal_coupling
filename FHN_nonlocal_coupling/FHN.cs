using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHN_nonlocal_coupling
{
    class FHN
    {
        // variables and arrays
        private bool eq_diff; // bool for deciding which equation solves
        private int n, m;
        private float h, hx, ht; // steps (h is for integrating)
        private float l, TB; // bounds; l is for x and TB/TBound is for t
        private float[] x, t;

        private double[,] u, v;
        private float eps, gamma; // v's equation constants

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

        public float L 
        {   // x's segment
            get { return this.l; }
            set { this.l = value; }
        }

        public float T
        {   // t's segment
            get { return this.TB; }
            set { this.TB = value; }
        }

        public float Eps
        {
            get { return this.eps; }
            set { this.eps = value; }
        }
        public float Gamma
        {
            get { return this.gamma; }
            set { this.gamma = value; }
        }
        
        public bool Eq
        {   // Is the equation a diffusuion equation?
            get { return this.eq_diff; }
            set { this.eq_diff = value; }
        }

        // constructors
        public FHN(float eps = 0.08F, float gamma = 0.8F, float l = 3.0F, float TB = 3.0F, int m = 49, int n = 99, bool eq_diff = false)
        {
            this.eps = eps;
            this.gamma = gamma;
            this.l = l;
            this.TB = TB;
            this.n = n;
            this.m = m;
            this.eq_diff = eq_diff;

            Load(m, n, eq_diff);
        }

        // methods
        public void Load(int m = 49, int n = 99, bool eq_diff = false)
        {   // initialize/declare arrays and steps
            // If we want to change one of the parameters: n, m, eq_diff, l, TB or initials, 
            // then it needs to call this function again.
            this.n = n;
            this.m = m;
            this.eq_diff = eq_diff;

            this.h = 2 * this.l / n; // for integrating from -l to l
            this.hx = 2 * this.l / n; // step for x
            this.ht = this.TB / m;  // step for t

            this.x = new float[n + 1]; // arrange x's
            for (int i = 0; i < n + 1; i++) this.x[i] = - this.l + i * this.hx;

            this.t = new float[m + 1]; // arrange t's
            for (int j = 0; j < m + 1; j++) this.t[j] = j * this.ht;

            this.u = new double[m + 1, n + 1];
            this.v = new double[m + 1, n + 1];
            for (int i = 0; i < n + 1; i++)
            {	// setting an initial waves at t = 0
                this.u[0, i] = u_x_0(x[i]);
                this.v[0, i] = v_x_0(x[i]);
            }

            if (eq_diff) 
            {   // if it is a diffusion equation, then sets initials
                for (int j = 0; j < m + 1; j++)
                {   // setting an initial waves at x = -l and x = l
                    this.u[j, 0] = u_0_t(t[j]); // at x = -l
                    this.v[j, 0] = v_0_t(t[j]); // at x = -l

                    this.u[j, n] = u_l_t(t[j]); // at x = l
                    this.v[j, n] = v_l_t(t[j]); // at x = l
                }
            }
        }

        public void Solve() 
	    {   // If we changed ONLY eps, gamma or Kernel,
            // then just recall this function.
            if (this.eq_diff)
            {   // reaction-diffusion equation
                float step = this.ht / (this.hx * this.hx);
                for (int j = 0; j < this.m; j++)
                {
                    for (int i = 1; i < this.n; i++)
                    {
                        this.u[j + 1, i] = (1 - 2 * step) * this.u[j, i] + step * (this.u[j, i - 1] + this.u[j, i + 1]) + this.ht * f(this.u[j, i]) - this.ht * this.v[j, i];
                        this.v[j + 1, i] = this.v[j, i] + this.ht * this.eps * (this.u[j, i] - this.gamma * this.v[j, i]);
                    }
                }
            }
            else
            {   // with nonlocal coupling
                for (int j = 0; j < this.m; j++)
                {
                    for (int i = 0; i < this.n + 1; i++)
                    {
                        this.u[j + 1, i] = this.u[j, i] * (1 - this.ht) + this.ht * (Integral(j, i) + f(this.u[j, i]) - this.v[j, i]);
                        this.v[j + 1, i] = this.v[j, i] + this.ht * this.eps * (this.u[j, i] - this.gamma * this.v[j, i]);
                    }
                }
            }

	    }

        public float GetX(int i)
        {
            return this.x[i];
        }

        public float GetT(int j)
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
        {	// integrating at point (t[j], x[i]) from -l to l
            double sum = 0;
            int k; // k is iteration variable for integrating (n+1 in number)
            sum += Kernel(this.x[i] - this.x[0]) * this.u[j, 0];
            for (k = 1; k < this.n; k++) sum += 2 * Kernel(this.x[i] - this.x[k]) * this.u[j, k];
            sum += Kernel(this.x[i] - this.x[this.n]) * this.u[j, this.n];

            return this.h * sum / 2;
        }

        private double Kernel(float z)
        {
            return z;
        }

        private double f(double u)
        {	// f(0) = f(1) = 0; f'(0) < 0 and f'(1) < 0 ???
            return u * 0;
        }

        private double u_x_0(float x)
        {	// initial u wave at t = 0
            return 1.0/2.0 * (1 + Math.Tanh(x/(2*Math.Sqrt(2))));
        }

        private double v_x_0(float x)
        {	// initial v wave at t = 0
            return (1 + Math.Tanh(x / (2 * Math.Sqrt(2)))); ;
        }

        private double u_0_t(float t)
        {   // initial u wave at x = -l
            return 1.0 / 2.0 * (1 + Math.Tanh(t / (2 * Math.Sqrt(2)))); 
        }

        private double v_0_t(float t)
        {   // initial v wave at x = -l
            return (1 + Math.Tanh(t / (2 * Math.Sqrt(2))));
        }

        private double u_l_t(float t)
        {   // initial u wave at x = l
            return 1.0 / 2.0 * (1 + Math.Tanh(t / (2 * Math.Sqrt(2))));
        }

        private double v_l_t(float t)
        {   // initial v wave at x = l
            return (1 + Math.Tanh(t / (2 * Math.Sqrt(2))));
        }

    }
}
