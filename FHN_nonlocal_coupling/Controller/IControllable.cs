using System;

namespace FHN_nonlocal_coupling.Controller
{
    public interface IControllable
    {
        void toAllocate(bool b);
        void toSolveFurther(bool b);
        void dispose();
        void reallocate(bool chckd);
        void checkToLoad(String label);
        bool solve(IProgress<int> progress);
        void clearPlot();

        int trackBarMax();
        double chartXMin();
        double chartXMax();
        void plot();
        void plot(int j);

        double[] getStat();
    }
}
