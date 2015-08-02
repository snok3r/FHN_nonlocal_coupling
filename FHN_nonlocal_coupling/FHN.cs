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
        private int n, m;
        private float h, hx, ht; // steps h for integrating
        private float l, TB; // bounds; l is for x and TB/TBound is for t
        private float[] x, t;

        private double[,] u, v;
        private float eps, gamma; // v's equation constants

        // properties
        public int N
        {
            get { return this.n; }
            set { this.n = value; }
        }

        public int M
        {
            get { return this.m; }
            set { this.m = value; }
        }

        public float L
        {
            get { return this.l; }
            set { this.l = value; }
        }

        public float T
        {
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

        // constructors
        public FHN(float eps = 0.08F, float gamma = 0.8F, float l = 3.0F, float TB = 3.0F, int m = 49, int n = 99)
        {
            this.eps = eps;
            this.gamma = gamma;
            this.l = l;
            this.TB = TB;
            this.n = n;
            this.m = m;

            Load(m, n);
        }

        // methods
        public void Load(int m = 49, int n = 99)
        {   // initialize/declare arrays and steps
            this.n = n;
            this.m = m;

            this.h = 2 * this.l / n;
            this.hx = 2 * this.l / n;
            this.ht = this.TB / m;

            this.x = new float[n + 1];
            for (int i = 0; i < n + 1; i++) this.x[i] = -this.l + i * this.hx;

            this.t = new float[m + 1];
            for (int j = 0; j < m + 1; j++) this.t[j] = j * this.ht;

            this.u = new double[m + 1, n + 1];
            this.v = new double[m + 1, n + 1];
            for (int i = 0; i < n + 1; i++)
            {	// setting an initial waves at t = 0
                this.u[0, i] = u0(x[i]);
                this.v[0, i] = v0(x[i]);
            }
        }

        public void Solve()
	    {
            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n + 1; i++)
                {
                    this.u[j + 1, i] = - this.u[j, i] + Intergral(j, i) + f(this.u[j, i]) - this.v[j, i];
                    this.v[j + 1, i] = this.eps * (this.u[j, i] - this.gamma * this.v[j, i]);
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
        private double Intergral(int j, int i)
        {	// integrating at point (t[j], x[i]) from -l to l
            double sum = 0;
            int k; // k is iteration variable for integrating (n+1 in number)
            for (k = 0; k < n + 1; k++) sum += Kernel(this.x[i] - this.x[k]) * this.u[j, k];

            return this.h * sum / 2;
        }

        private double Kernel(float z)
        {
            return z*z+z+1;
        }

        private double f(double u)
        {	// f(0) = f(1) = 0; f'(0) < 0 and f'(1) < 0 ???
            return Math.Cos(u);
        }

        private double u0(float x)
        {	// initial u wave at t = 0
            return x;
        }

        private double v0(float x)
        {	// initial v wave at t = 0
            return x*x+1;
        }
    }
}
