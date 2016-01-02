namespace FHN_nonlocal_coupling
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.txtBoxMaxUVTWOD = new System.Windows.Forms.TextBox();
            this.rdBtnPlotAllWOD = new System.Windows.Forms.RadioButton();
            this.txtBoxMinUVTWOD = new System.Windows.Forms.TextBox();
            this.btnTuneTWOD = new System.Windows.Forms.Button();
            this.rdBtnTmrWOD = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxMaxUVPhaseWOD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxMinUVPhaseWOD = new System.Windows.Forms.TextBox();
            this.btnTunePhaseWOD = new System.Windows.Forms.Button();
            this.lblErrorWOD = new System.Windows.Forms.Label();
            this.chartTWOD = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.trBarTWOD = new System.Windows.Forms.TrackBar();
            this.chartPhaseWOD = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.prBarSolveWOD = new System.Windows.Forms.ProgressBar();
            this.lblMinUVWOD = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStopTimerWOD = new System.Windows.Forms.Button();
            this.lblMaxUVWOD = new System.Windows.Forms.Label();
            this.btnPlotWOD = new System.Windows.Forms.Button();
            this.btnSolveWOD = new System.Windows.Forms.Button();
            this.btnLoadWOD = new System.Windows.Forms.Button();
            this.timerTWOD = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.propertyGrid2 = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.chartTWOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarTWOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPhaseWOD)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxMaxUVTWOD
            // 
            this.txtBoxMaxUVTWOD.Location = new System.Drawing.Point(247, 25);
            this.txtBoxMaxUVTWOD.Name = "txtBoxMaxUVTWOD";
            this.txtBoxMaxUVTWOD.Size = new System.Drawing.Size(34, 20);
            this.txtBoxMaxUVTWOD.TabIndex = 79;
            this.txtBoxMaxUVTWOD.Text = "2,0";
            this.txtBoxMaxUVTWOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rdBtnPlotAllWOD
            // 
            this.rdBtnPlotAllWOD.AutoSize = true;
            this.rdBtnPlotAllWOD.Checked = true;
            this.rdBtnPlotAllWOD.Location = new System.Drawing.Point(3, 26);
            this.rdBtnPlotAllWOD.Name = "rdBtnPlotAllWOD";
            this.rdBtnPlotAllWOD.Size = new System.Drawing.Size(57, 17);
            this.rdBtnPlotAllWOD.TabIndex = 1;
            this.rdBtnPlotAllWOD.TabStop = true;
            this.rdBtnPlotAllWOD.Text = "Plot All";
            this.rdBtnPlotAllWOD.UseVisualStyleBackColor = true;
            // 
            // txtBoxMinUVTWOD
            // 
            this.txtBoxMinUVTWOD.Location = new System.Drawing.Point(247, 276);
            this.txtBoxMinUVTWOD.Name = "txtBoxMinUVTWOD";
            this.txtBoxMinUVTWOD.Size = new System.Drawing.Size(34, 20);
            this.txtBoxMinUVTWOD.TabIndex = 82;
            this.txtBoxMinUVTWOD.Text = "-2,1";
            this.txtBoxMinUVTWOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnTuneTWOD
            // 
            this.btnTuneTWOD.Location = new System.Drawing.Point(247, 152);
            this.btnTuneTWOD.Name = "btnTuneTWOD";
            this.btnTuneTWOD.Size = new System.Drawing.Size(42, 23);
            this.btnTuneTWOD.TabIndex = 71;
            this.btnTuneTWOD.Text = "Zoom";
            this.btnTuneTWOD.UseVisualStyleBackColor = true;
            this.btnTuneTWOD.Click += new System.EventHandler(this.btnTuneTWOD_Click);
            // 
            // rdBtnTmrWOD
            // 
            this.rdBtnTmrWOD.AutoSize = true;
            this.rdBtnTmrWOD.Location = new System.Drawing.Point(3, 3);
            this.rdBtnTmrWOD.Name = "rdBtnTmrWOD";
            this.rdBtnTmrWOD.Size = new System.Drawing.Size(76, 17);
            this.rdBtnTmrWOD.TabIndex = 0;
            this.rdBtnTmrWOD.Text = "With Timer";
            this.rdBtnTmrWOD.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 365);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 83;
            this.label2.Text = "max u,v";
            // 
            // txtBoxMaxUVPhaseWOD
            // 
            this.txtBoxMaxUVPhaseWOD.Location = new System.Drawing.Point(247, 362);
            this.txtBoxMaxUVPhaseWOD.Name = "txtBoxMaxUVPhaseWOD";
            this.txtBoxMaxUVPhaseWOD.Size = new System.Drawing.Size(34, 20);
            this.txtBoxMaxUVPhaseWOD.TabIndex = 77;
            this.txtBoxMaxUVPhaseWOD.Text = "2,0";
            this.txtBoxMaxUVPhaseWOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 602);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 84;
            this.label1.Text = "min u,v";
            // 
            // txtBoxMinUVPhaseWOD
            // 
            this.txtBoxMinUVPhaseWOD.Location = new System.Drawing.Point(247, 597);
            this.txtBoxMinUVPhaseWOD.Name = "txtBoxMinUVPhaseWOD";
            this.txtBoxMinUVPhaseWOD.Size = new System.Drawing.Size(34, 20);
            this.txtBoxMinUVPhaseWOD.TabIndex = 81;
            this.txtBoxMinUVPhaseWOD.Text = "-1,0";
            this.txtBoxMinUVPhaseWOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnTunePhaseWOD
            // 
            this.btnTunePhaseWOD.Location = new System.Drawing.Point(247, 489);
            this.btnTunePhaseWOD.Name = "btnTunePhaseWOD";
            this.btnTunePhaseWOD.Size = new System.Drawing.Size(42, 23);
            this.btnTunePhaseWOD.TabIndex = 75;
            this.btnTunePhaseWOD.Text = "Zoom";
            this.btnTunePhaseWOD.UseVisualStyleBackColor = true;
            this.btnTunePhaseWOD.Click += new System.EventHandler(this.btnTunePhaseWOD_Click);
            // 
            // lblErrorWOD
            // 
            this.lblErrorWOD.AutoSize = true;
            this.lblErrorWOD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblErrorWOD.ForeColor = System.Drawing.Color.DarkRed;
            this.lblErrorWOD.Location = new System.Drawing.Point(193, 665);
            this.lblErrorWOD.Name = "lblErrorWOD";
            this.lblErrorWOD.Size = new System.Drawing.Size(102, 16);
            this.lblErrorWOD.TabIndex = 85;
            this.lblErrorWOD.Text = "Error occured";
            this.lblErrorWOD.Visible = false;
            // 
            // chartTWOD
            // 
            chartArea3.Name = "ChartArea1";
            this.chartTWOD.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartTWOD.Legends.Add(legend3);
            this.chartTWOD.Location = new System.Drawing.Point(247, 8);
            this.chartTWOD.Name = "chartTWOD";
            series6.BorderWidth = 3;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "U";
            series7.BorderWidth = 3;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series7.Legend = "Legend1";
            series7.Name = "V";
            this.chartTWOD.Series.Add(series6);
            this.chartTWOD.Series.Add(series7);
            this.chartTWOD.Size = new System.Drawing.Size(1030, 325);
            this.chartTWOD.TabIndex = 72;
            this.chartTWOD.Text = "chart1";
            // 
            // trBarTWOD
            // 
            this.trBarTWOD.Location = new System.Drawing.Point(328, 658);
            this.trBarTWOD.Name = "trBarTWOD";
            this.trBarTWOD.Size = new System.Drawing.Size(788, 45);
            this.trBarTWOD.TabIndex = 70;
            // 
            // chartPhaseWOD
            // 
            chartArea4.Name = "ChartArea1";
            this.chartPhaseWOD.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartPhaseWOD.Legends.Add(legend4);
            this.chartPhaseWOD.Location = new System.Drawing.Point(247, 333);
            this.chartPhaseWOD.Name = "chartPhaseWOD";
            series8.BorderWidth = 5;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Legend = "Legend1";
            series8.Name = "V(U)";
            series9.BorderWidth = 3;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series9.Legend = "Legend1";
            series9.Name = "1 nс V(U)";
            series10.BorderWidth = 3;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series10.Legend = "Legend1";
            series10.Name = "2 nc V(U)";
            this.chartPhaseWOD.Series.Add(series8);
            this.chartPhaseWOD.Series.Add(series9);
            this.chartPhaseWOD.Series.Add(series10);
            this.chartPhaseWOD.Size = new System.Drawing.Size(1030, 325);
            this.chartPhaseWOD.TabIndex = 74;
            this.chartPhaseWOD.Text = "chart2";
            // 
            // prBarSolveWOD
            // 
            this.prBarSolveWOD.Location = new System.Drawing.Point(31, 661);
            this.prBarSolveWOD.Maximum = 4;
            this.prBarSolveWOD.Name = "prBarSolveWOD";
            this.prBarSolveWOD.Size = new System.Drawing.Size(156, 23);
            this.prBarSolveWOD.TabIndex = 47;
            // 
            // lblMinUVWOD
            // 
            this.lblMinUVWOD.AutoSize = true;
            this.lblMinUVWOD.Location = new System.Drawing.Point(206, 279);
            this.lblMinUVWOD.Name = "lblMinUVWOD";
            this.lblMinUVWOD.Size = new System.Drawing.Size(41, 13);
            this.lblMinUVWOD.TabIndex = 76;
            this.lblMinUVWOD.Text = "min u,v";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdBtnPlotAllWOD);
            this.panel1.Controls.Add(this.rdBtnTmrWOD);
            this.panel1.Location = new System.Drawing.Point(115, 579);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(80, 47);
            this.panel1.TabIndex = 69;
            // 
            // btnStopTimerWOD
            // 
            this.btnStopTimerWOD.Location = new System.Drawing.Point(112, 632);
            this.btnStopTimerWOD.Name = "btnStopTimerWOD";
            this.btnStopTimerWOD.Size = new System.Drawing.Size(75, 23);
            this.btnStopTimerWOD.TabIndex = 68;
            this.btnStopTimerWOD.Text = "Stop Timer";
            this.btnStopTimerWOD.UseVisualStyleBackColor = true;
            // 
            // lblMaxUVWOD
            // 
            this.lblMaxUVWOD.AutoSize = true;
            this.lblMaxUVWOD.Location = new System.Drawing.Point(203, 28);
            this.lblMaxUVWOD.Name = "lblMaxUVWOD";
            this.lblMaxUVWOD.Size = new System.Drawing.Size(44, 13);
            this.lblMaxUVWOD.TabIndex = 73;
            this.lblMaxUVWOD.Text = "max u,v";
            // 
            // btnPlotWOD
            // 
            this.btnPlotWOD.Enabled = false;
            this.btnPlotWOD.Location = new System.Drawing.Point(31, 608);
            this.btnPlotWOD.Name = "btnPlotWOD";
            this.btnPlotWOD.Size = new System.Drawing.Size(75, 23);
            this.btnPlotWOD.TabIndex = 67;
            this.btnPlotWOD.Text = "Plot";
            this.btnPlotWOD.UseVisualStyleBackColor = true;
            this.btnPlotWOD.Click += new System.EventHandler(this.btnPlotWOD_Click);
            // 
            // btnSolveWOD
            // 
            this.btnSolveWOD.Location = new System.Drawing.Point(31, 579);
            this.btnSolveWOD.Name = "btnSolveWOD";
            this.btnSolveWOD.Size = new System.Drawing.Size(75, 23);
            this.btnSolveWOD.TabIndex = 66;
            this.btnSolveWOD.Text = "Solve";
            this.btnSolveWOD.UseVisualStyleBackColor = true;
            this.btnSolveWOD.Click += new System.EventHandler(this.btnSolveWOD_Click);
            // 
            // btnLoadWOD
            // 
            this.btnLoadWOD.Location = new System.Drawing.Point(31, 550);
            this.btnLoadWOD.Name = "btnLoadWOD";
            this.btnLoadWOD.Size = new System.Drawing.Size(75, 23);
            this.btnLoadWOD.TabIndex = 65;
            this.btnLoadWOD.Text = "Load";
            this.btnLoadWOD.UseVisualStyleBackColor = true;
            this.btnLoadWOD.Click += new System.EventHandler(this.btnLoadWOD_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(11, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(176, 369);
            this.tabControl1.TabIndex = 86;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.propertyGrid1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(168, 343);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "First eq";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.propertyGrid1.Size = new System.Drawing.Size(168, 343);
            this.propertyGrid1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.propertyGrid2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(168, 343);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Second eq";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // propertyGrid2
            // 
            this.propertyGrid2.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid2.Name = "propertyGrid2";
            this.propertyGrid2.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.propertyGrid2.Size = new System.Drawing.Size(168, 343);
            this.propertyGrid2.TabIndex = 1;
            // 
            // WindowODE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 711);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtBoxMaxUVTWOD);
            this.Controls.Add(this.txtBoxMinUVTWOD);
            this.Controls.Add(this.btnTuneTWOD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxMaxUVPhaseWOD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxMinUVPhaseWOD);
            this.Controls.Add(this.btnTunePhaseWOD);
            this.Controls.Add(this.lblErrorWOD);
            this.Controls.Add(this.chartTWOD);
            this.Controls.Add(this.trBarTWOD);
            this.Controls.Add(this.chartPhaseWOD);
            this.Controls.Add(this.prBarSolveWOD);
            this.Controls.Add(this.lblMinUVWOD);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnStopTimerWOD);
            this.Controls.Add(this.lblMaxUVWOD);
            this.Controls.Add(this.btnPlotWOD);
            this.Controls.Add(this.btnSolveWOD);
            this.Controls.Add(this.btnLoadWOD);
            this.Name = "WindowODE";
            this.Text = "WindowODE";
            this.Load += new System.EventHandler(this.WindowODE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartTWOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarTWOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPhaseWOD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxMaxUVTWOD;
        public System.Windows.Forms.RadioButton rdBtnPlotAllWOD;
        private System.Windows.Forms.TextBox txtBoxMinUVTWOD;
        private System.Windows.Forms.Button btnTuneTWOD;
        public System.Windows.Forms.RadioButton rdBtnTmrWOD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxMaxUVPhaseWOD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxMinUVPhaseWOD;
        private System.Windows.Forms.Button btnTunePhaseWOD;
        public System.Windows.Forms.Label lblErrorWOD;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTWOD;
        private System.Windows.Forms.TrackBar trBarTWOD;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPhaseWOD;
        public System.Windows.Forms.ProgressBar prBarSolveWOD;
        private System.Windows.Forms.Label lblMinUVWOD;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStopTimerWOD;
        private System.Windows.Forms.Label lblMaxUVWOD;
        private System.Windows.Forms.Button btnPlotWOD;
        private System.Windows.Forms.Button btnSolveWOD;
        private System.Windows.Forms.Button btnLoadWOD;
        private System.Windows.Forms.Timer timerTWOD;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PropertyGrid propertyGrid2;
    }
}