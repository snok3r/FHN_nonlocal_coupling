namespace FHN_nonlocal_coupling.View
{
    partial class WindowODE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblMaxPhase = new System.Windows.Forms.Label();
            this.lblMinPhase = new System.Windows.Forms.Label();
            this.txtBoxMinUVPhase = new System.Windows.Forms.TextBox();
            this.btnTunePhase = new System.Windows.Forms.Button();
            this.chartPhase = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtBoxMaxUVPhase = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPhase)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.Size = new System.Drawing.Size(1030, 325);
            // 
            // btnAbout
            // 
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // lblMinUV
            // 
            this.lblMinUV.Location = new System.Drawing.Point(198, 279);
            // 
            // lblMaxUV
            // 
            this.lblMaxUV.Location = new System.Drawing.Point(198, 28);
            // 
            // btnTune
            // 
            this.btnTune.Location = new System.Drawing.Point(242, 152);
            // 
            // txtBoxMinUV
            // 
            this.txtBoxMinUV.Location = new System.Drawing.Point(242, 276);
            // 
            // txtBoxMaxUV
            // 
            this.txtBoxMaxUV.Location = new System.Drawing.Point(242, 25);
            // 
            // lblMaxPhase
            // 
            this.lblMaxPhase.AutoSize = true;
            this.lblMaxPhase.Location = new System.Drawing.Point(198, 365);
            this.lblMaxPhase.Name = "lblMaxPhase";
            this.lblMaxPhase.Size = new System.Drawing.Size(44, 13);
            this.lblMaxPhase.TabIndex = 114;
            this.lblMaxPhase.Text = "max u,v";
            // 
            // lblMinPhase
            // 
            this.lblMinPhase.AutoSize = true;
            this.lblMinPhase.Location = new System.Drawing.Point(198, 600);
            this.lblMinPhase.Name = "lblMinPhase";
            this.lblMinPhase.Size = new System.Drawing.Size(41, 13);
            this.lblMinPhase.TabIndex = 115;
            this.lblMinPhase.Text = "min u,v";
            // 
            // txtBoxMinUVPhase
            // 
            this.txtBoxMinUVPhase.Location = new System.Drawing.Point(242, 597);
            this.txtBoxMinUVPhase.Name = "txtBoxMinUVPhase";
            this.txtBoxMinUVPhase.Size = new System.Drawing.Size(34, 20);
            this.txtBoxMinUVPhase.TabIndex = 113;
            this.txtBoxMinUVPhase.Text = "-1,0";
            this.txtBoxMinUVPhase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnTunePhase
            // 
            this.btnTunePhase.Location = new System.Drawing.Point(242, 489);
            this.btnTunePhase.Name = "btnTunePhase";
            this.btnTunePhase.Size = new System.Drawing.Size(42, 23);
            this.btnTunePhase.TabIndex = 112;
            this.btnTunePhase.Text = "Zoom";
            this.btnTunePhase.UseVisualStyleBackColor = true;
            this.btnTunePhase.Click += new System.EventHandler(this.btnTunePhase_Click);
            // 
            // chartPhase
            // 
            chartArea1.Name = "ChartArea1";
            this.chartPhase.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPhase.Legends.Add(legend1);
            this.chartPhase.Location = new System.Drawing.Point(242, 333);
            this.chartPhase.Name = "chartPhase";
            series1.BorderWidth = 5;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "V(U)";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Legend = "Legend1";
            series2.Name = "1 nс V(U)";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series3.Legend = "Legend1";
            series3.Name = "2 nc V(U)";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series4.Legend = "Legend1";
            series4.Name = "V2";
            series4.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series5.Legend = "Legend1";
            series5.Name = "1 nc V2";
            series5.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series6.Legend = "Legend1";
            series6.Name = "2 nc V2";
            series6.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
            this.chartPhase.Series.Add(series1);
            this.chartPhase.Series.Add(series2);
            this.chartPhase.Series.Add(series3);
            this.chartPhase.Series.Add(series4);
            this.chartPhase.Series.Add(series5);
            this.chartPhase.Series.Add(series6);
            this.chartPhase.Size = new System.Drawing.Size(1030, 325);
            this.chartPhase.TabIndex = 111;
            this.chartPhase.Text = "chart2";
            // 
            // txtBoxMaxUVPhase
            // 
            this.txtBoxMaxUVPhase.Location = new System.Drawing.Point(242, 362);
            this.txtBoxMaxUVPhase.Name = "txtBoxMaxUVPhase";
            this.txtBoxMaxUVPhase.Size = new System.Drawing.Size(34, 20);
            this.txtBoxMaxUVPhase.TabIndex = 116;
            this.txtBoxMaxUVPhase.Text = "2,0";
            this.txtBoxMaxUVPhase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // WindowODE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 711);
            this.Controls.Add(this.txtBoxMaxUVPhase);
            this.Controls.Add(this.lblMaxPhase);
            this.Controls.Add(this.lblMinPhase);
            this.Controls.Add(this.txtBoxMinUVPhase);
            this.Controls.Add(this.btnTunePhase);
            this.Controls.Add(this.chartPhase);
            this.Name = "WindowODE";
            this.Text = "Window ODE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WindowODE_FormClosing);
            this.Load += new System.EventHandler(this.WindowODE_Load);
            this.Controls.SetChildIndex(this.btnStopTimer, 0);
            this.Controls.SetChildIndex(this.rdBtnTmr, 0);
            this.Controls.SetChildIndex(this.prBarSolve, 0);
            this.Controls.SetChildIndex(this.trBarT, 0);
            this.Controls.SetChildIndex(this.btnPlot, 0);
            this.Controls.SetChildIndex(this.btnSolve, 0);
            this.Controls.SetChildIndex(this.chart, 0);
            this.Controls.SetChildIndex(this.lblError, 0);
            this.Controls.SetChildIndex(this.btnAbout, 0);
            this.Controls.SetChildIndex(this.btnSolveFurther, 0);
            this.Controls.SetChildIndex(this.checkBox2ndEq, 0);
            this.Controls.SetChildIndex(this.txtBoxMaxUV, 0);
            this.Controls.SetChildIndex(this.txtBoxMinUV, 0);
            this.Controls.SetChildIndex(this.btnTune, 0);
            this.Controls.SetChildIndex(this.lblMaxUV, 0);
            this.Controls.SetChildIndex(this.lblMinUV, 0);
            this.Controls.SetChildIndex(this.chartPhase, 0);
            this.Controls.SetChildIndex(this.btnTunePhase, 0);
            this.Controls.SetChildIndex(this.txtBoxMinUVPhase, 0);
            this.Controls.SetChildIndex(this.lblMinPhase, 0);
            this.Controls.SetChildIndex(this.lblMaxPhase, 0);
            this.Controls.SetChildIndex(this.txtBoxMaxUVPhase, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPhase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaxPhase;
        private System.Windows.Forms.Label lblMinPhase;
        private System.Windows.Forms.TextBox txtBoxMinUVPhase;
        private System.Windows.Forms.Button btnTunePhase;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPhase;
        private System.Windows.Forms.TextBox txtBoxMaxUVPhase;
    }
}