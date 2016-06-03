using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FHN_nonlocal_coupling.Controller
{
    public class ViewElements
    {
        public Chart chart;
        public Chart chartPhase;
        public PropertyGrid pg1, pg2;
        public TrackBar trackBar;
        public TextBox ux0, vx0;
        public CheckBox customInitials;

        private ViewElements(Chart chart, Chart chartPhase, PropertyGrid pg1, PropertyGrid pg2, TrackBar trackBar, TextBox ux0, TextBox vx0, CheckBox customInitials)
        {
            this.chart = chart;
            this.chartPhase = chartPhase;
            this.pg1 = pg1;
            this.pg2 = pg2;
            this.trackBar = trackBar;
            this.ux0 = ux0;
            this.vx0 = vx0;
            this.customInitials = customInitials;
        }

        public static ViewElements ODEViewElements(Chart chart, Chart chartPhase, PropertyGrid pg1, PropertyGrid pg2, TrackBar trackBar)
        {
            return new ViewElements(chart, chartPhase, pg1, pg2, trackBar, null, null, null);
        }

        public static ViewElements PDEViewElements(Chart chart, PropertyGrid pg1, PropertyGrid pg2, TrackBar trackBar, TextBox ux0, TextBox vx0, CheckBox customInitials)
        {
            return new ViewElements(chart, null, pg1, pg2, trackBar, ux0, vx0, customInitials);
        }
    }
}
