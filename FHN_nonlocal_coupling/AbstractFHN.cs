﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FHN_nonlocal_coupling
{
    abstract class AbstractFHN
    {
        protected const int POINTS_THRESHOLD = 5;

        protected double hx, ht; // steps
        protected double[] t; // time

        private int varN;
        protected double varL;
        private double varA;
        private double varT;

        public abstract void load();
        public abstract void initials();
        public abstract int solve();

        public AbstractFHN()
        {
            Eps = 0.08;
            Beta = 0.064;
            Alpha = 0.056;
            A = 0.1;
            Classical = true;
        }

        // properties
        public int N
        {   // quantity of u,v t's (x's)
            get { return varN; }
            set
            {
                if (value > POINTS_THRESHOLD)
                    varN = value;
            }
        }
        
        public virtual double L
        {
            get { return varL; }
            set 
            {
                if (value > 0)
                    varL = value;
            }
        }

        [Description("Interval for t [0, T]")]
        public double T
        {   // bound t's segment
            get { return varT; }
            set
            {
                if (value > 0)
                    varT = value;
            }
        }

        [Description("v's equation constant")]
        public double Eps
        {   // v's equation constants
            get;
            set;
        }

        [Description("v's equation constant")]
        public double Alpha
        {   // v's equation constants
            get;
            set;
        }

        [Description("v's equation constant")]
        public double Beta
        {   // v's equation constants
            get;
            set;
        }

        [Description("Current I excitatory")]
        public double I
        {   // current
            get;
            set;
        }

        [Description("F's constant in non-classical non-linearity (classical == false)")]
        public double A
        {   // f's constant if non-classical
            get { return varA; }
            set
            {
                if (value > 0 && value < 1)
                    varA = value;
            }
        }

        [Description("Whether this is a classical f(u) or not")]
        public bool Classical
        {   // Is the equation with classical non-linearity?
            get;
            set;
        }

        public double getT(int j)
        {
            return t[j];
        }

        protected double f(double u)
        {
            if (Classical)
                return u - u * u * u / 3;
            else
                return -u * (u - 1) * (u - A);
        }
    }
}
