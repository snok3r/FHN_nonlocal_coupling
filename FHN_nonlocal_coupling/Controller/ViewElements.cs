using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FHN_nonlocal_coupling.Controller
{
    public class ViewElements
    {
        public Chart chart;
        public Chart chartPhase;
        public PropertyGrid pg1, pg2;
        public ProgressBar progressBar;
        public TrackBar trackBar;
        public TextBox ux0, vx0;
        public CheckBox customInitials;

        public ViewElements(Chart chart, Chart chartPhase, PropertyGrid pg1, PropertyGrid pg2, ProgressBar progressBar, TrackBar trackBar, TextBox ux0, TextBox vx0, CheckBox customInitials)
        {
            this.chart = chart;
            this.chartPhase = chartPhase;
            this.pg1 = pg1;
            this.pg2 = pg2;
            this.progressBar = progressBar;
            this.trackBar = trackBar;
            this.ux0 = ux0;
            this.vx0 = vx0;
            this.customInitials = customInitials;
        }

        public ViewElements(Chart chart, Chart chartPhase, PropertyGrid pg1, PropertyGrid pg2, ProgressBar progressBar, TrackBar trackBar)
            : this(chart, chartPhase, pg1, pg2, progressBar, trackBar, null, null, null) { }

        public ViewElements(Chart chart, PropertyGrid pg1, PropertyGrid pg2, ProgressBar progressBar, TrackBar trackBar, TextBox ux0, TextBox vx0, CheckBox customInitials)
            : this(chart, null, pg1, pg2, progressBar, trackBar, ux0, vx0, customInitials) { }
    }
}
