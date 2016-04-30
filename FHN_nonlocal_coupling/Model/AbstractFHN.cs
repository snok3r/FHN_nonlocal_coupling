using System;
using System.ComponentModel;

namespace FHN_nonlocal_coupling.Model
{
    public abstract class AbstractFHN
    {
        protected const int POINTS_THRESHOLD = 10;

        protected double hx, ht; // steps
        protected double[] t; // time

        // variables for properties
        protected double varL;
        private int varN;
        private double varA;
        private double varT;

        public abstract void allocate();
        public abstract void reload();
        public abstract void initials();
        public abstract void initialsFurther();
        public abstract bool solve();

        public AbstractFHN()
        {
            Eps = 0.08;
            Gamma = 0.8;
            Beta = 0.7;
            A = 0.1;
            Classical = true;
        }

        // properties
        public int N
        {   // quantity of u,v t's (x's)
            get { return varN; }
            set
            {
                if (value > POINTS_THRESHOLD) varN = value;
            }
        }

        public virtual double L
        {
            get { return varL; }
            set
            {
                if (value > 0) varL = value;
            }
        }

        [Description("Interval for t [0, T]")]
        public double T
        {   // bound t's segment
            get { return varT; }
            set
            {
                if (value > 0) varT = value;
            }
        }

        [Description("v's equation constant")]
        public double Eps { get; set; }

        [Description("v's equation constant")]
        public double Beta { get; set; }

        [Description("v's equation constant")]
        public double Gamma { get; set; }

        [Description("Current I excitatory")]
        public double I { get; set; }

        [Description("F's constant in non-classical non-linearity (classical == false)")]
        public double A
        {   // f's constant if non-classical
            get { return varA; }
            set
            {
                if (value > 0 && value < 1) varA = value;
            }
        }

        [Description("Whether this is a classical f(u) or not")]
        public bool Classical { get; set; }

        public double getT(int j)
        { return t[j]; }

        protected double f(double u)
        {
            if (Classical)
                return u - u * u * u / 3;
            else
                return -u * (u - 1) * (u - A);
        }

        public virtual void initials(String UX0, String VX0) { }

        public virtual void dispose()
        { t = null; }
    }
}
