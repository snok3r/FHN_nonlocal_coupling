using System;
using System.Collections.Generic;

namespace FHN_nonlocal_coupling.Controller
{
    public interface IControllable
    {
        void toSolveFurther(bool b);
        void dispose();
        void reallocate(bool chckd);
        void checkToLoad(IEnumerable<String> paramsNeedReload);
        bool solve(IProgress<int> progress);
        void clearPlot();

        int trackBarMax();
        double chartXMin();
        double chartXMax();
        void plot();
        void plot(int j);

        List<double> getStat();
    }
}
