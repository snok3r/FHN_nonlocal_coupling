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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.txtBoxMaxUVTWOD = new System.Windows.Forms.TextBox();
            this.lblFAWOD = new System.Windows.Forms.Label();
            this.rdBtnPlotAllWOD = new System.Windows.Forms.RadioButton();
            this.txtBoxMinUVTWOD = new System.Windows.Forms.TextBox();
            this.btnTuneTWOD = new System.Windows.Forms.Button();
            this.rdBtnTmrWOD = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxMaxUVPhaseWOD = new System.Windows.Forms.TextBox();
            this.rdBtnClassicalNLWOD = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxMinUVPhaseWOD = new System.Windows.Forms.TextBox();
            this.btnTunePhaseWOD = new System.Windows.Forms.Button();
            this.rdBtnNLWOD = new System.Windows.Forms.RadioButton();
            this.lblErrorWOD = new System.Windows.Forms.Label();
            this.txtBoxFAWOD = new System.Windows.Forms.TextBox();
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
            this.panelNonLinTypeWOD = new System.Windows.Forms.Panel();
            this.txtBoxBetaWOD = new System.Windows.Forms.TextBox();
            this.txtBoxAlphaWOD = new System.Windows.Forms.TextBox();
            this.txtBoxTauWOD = new System.Windows.Forms.TextBox();
            this.txtBoxIWOD = new System.Windows.Forms.TextBox();
            this.txtBoxV0WOD = new System.Windows.Forms.TextBox();
            this.txtBoxU0WOD = new System.Windows.Forms.TextBox();
            this.txtBoxTWOD = new System.Windows.Forms.TextBox();
            this.txtBoxLWOD = new System.Windows.Forms.TextBox();
            this.txtBoxNWOD = new System.Windows.Forms.TextBox();
            this.lblBetaWOD = new System.Windows.Forms.Label();
            this.lblAlphaWOD = new System.Windows.Forms.Label();
            this.lblTauWOD = new System.Windows.Forms.Label();
            this.lblIWOD = new System.Windows.Forms.Label();
            this.lblV0WOD = new System.Windows.Forms.Label();
            this.lblU0WOD = new System.Windows.Forms.Label();
            this.lblTWOD = new System.Windows.Forms.Label();
            this.lblLWOD = new System.Windows.Forms.Label();
            this.lblNWOD = new System.Windows.Forms.Label();
            this.timerTWOD = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chartTWOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarTWOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPhaseWOD)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelNonLinTypeWOD.SuspendLayout();
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
            // lblFAWOD
            // 
            this.lblFAWOD.AutoSize = true;
            this.lblFAWOD.Location = new System.Drawing.Point(96, 387);
            this.lblFAWOD.Name = "lblFAWOD";
            this.lblFAWOD.Size = new System.Drawing.Size(13, 13);
            this.lblFAWOD.TabIndex = 78;
            this.lblFAWOD.Text = "a";
            this.lblFAWOD.Visible = false;
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
            // rdBtnClassicalNLWOD
            // 
            this.rdBtnClassicalNLWOD.AutoSize = true;
            this.rdBtnClassicalNLWOD.Checked = true;
            this.rdBtnClassicalNLWOD.Location = new System.Drawing.Point(3, 3);
            this.rdBtnClassicalNLWOD.Name = "rdBtnClassicalNLWOD";
            this.rdBtnClassicalNLWOD.Size = new System.Drawing.Size(65, 17);
            this.rdBtnClassicalNLWOD.TabIndex = 0;
            this.rdBtnClassicalNLWOD.TabStop = true;
            this.rdBtnClassicalNLWOD.Text = "classical";
            this.rdBtnClassicalNLWOD.UseVisualStyleBackColor = true;
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
            // 
            // rdBtnNLWOD
            // 
            this.rdBtnNLWOD.AutoSize = true;
            this.rdBtnNLWOD.Location = new System.Drawing.Point(3, 26);
            this.rdBtnNLWOD.Name = "rdBtnNLWOD";
            this.rdBtnNLWOD.Size = new System.Drawing.Size(81, 17);
            this.rdBtnNLWOD.TabIndex = 1;
            this.rdBtnNLWOD.Text = "non-linearity";
            this.rdBtnNLWOD.UseVisualStyleBackColor = true;
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
            // txtBoxFAWOD
            // 
            this.txtBoxFAWOD.Location = new System.Drawing.Point(112, 384);
            this.txtBoxFAWOD.Name = "txtBoxFAWOD";
            this.txtBoxFAWOD.Size = new System.Drawing.Size(50, 20);
            this.txtBoxFAWOD.TabIndex = 80;
            this.txtBoxFAWOD.Text = "0,1";
            this.txtBoxFAWOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxFAWOD.Visible = false;
            // 
            // chartTWOD
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTWOD.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTWOD.Legends.Add(legend1);
            this.chartTWOD.Location = new System.Drawing.Point(247, 8);
            this.chartTWOD.Name = "chartTWOD";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "U";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Legend = "Legend1";
            series2.Name = "V";
            this.chartTWOD.Series.Add(series1);
            this.chartTWOD.Series.Add(series2);
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
            chartArea2.Name = "ChartArea1";
            this.chartPhaseWOD.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartPhaseWOD.Legends.Add(legend2);
            this.chartPhaseWOD.Location = new System.Drawing.Point(247, 333);
            this.chartPhaseWOD.Name = "chartPhaseWOD";
            series3.BorderWidth = 5;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "V(U)";
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series4.Legend = "Legend1";
            series4.Name = "1 nс V(U)";
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series5.Legend = "Legend1";
            series5.Name = "2 nc V(U)";
            this.chartPhaseWOD.Series.Add(series3);
            this.chartPhaseWOD.Series.Add(series4);
            this.chartPhaseWOD.Series.Add(series5);
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
            // 
            // btnSolveWOD
            // 
            this.btnSolveWOD.Location = new System.Drawing.Point(31, 579);
            this.btnSolveWOD.Name = "btnSolveWOD";
            this.btnSolveWOD.Size = new System.Drawing.Size(75, 23);
            this.btnSolveWOD.TabIndex = 66;
            this.btnSolveWOD.Text = "Solve";
            this.btnSolveWOD.UseVisualStyleBackColor = true;
            // 
            // btnLoadWOD
            // 
            this.btnLoadWOD.Location = new System.Drawing.Point(31, 550);
            this.btnLoadWOD.Name = "btnLoadWOD";
            this.btnLoadWOD.Size = new System.Drawing.Size(75, 23);
            this.btnLoadWOD.TabIndex = 65;
            this.btnLoadWOD.Text = "Load";
            this.btnLoadWOD.UseVisualStyleBackColor = true;
            // 
            // panelNonLinTypeWOD
            // 
            this.panelNonLinTypeWOD.Controls.Add(this.rdBtnNLWOD);
            this.panelNonLinTypeWOD.Controls.Add(this.rdBtnClassicalNLWOD);
            this.panelNonLinTypeWOD.Location = new System.Drawing.Point(18, 384);
            this.panelNonLinTypeWOD.Name = "panelNonLinTypeWOD";
            this.panelNonLinTypeWOD.Size = new System.Drawing.Size(80, 47);
            this.panelNonLinTypeWOD.TabIndex = 64;
            // 
            // txtBoxBetaWOD
            // 
            this.txtBoxBetaWOD.Location = new System.Drawing.Point(112, 358);
            this.txtBoxBetaWOD.Name = "txtBoxBetaWOD";
            this.txtBoxBetaWOD.Size = new System.Drawing.Size(50, 20);
            this.txtBoxBetaWOD.TabIndex = 63;
            this.txtBoxBetaWOD.Text = "0,8";
            this.txtBoxBetaWOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxAlphaWOD
            // 
            this.txtBoxAlphaWOD.Location = new System.Drawing.Point(31, 358);
            this.txtBoxAlphaWOD.Name = "txtBoxAlphaWOD";
            this.txtBoxAlphaWOD.Size = new System.Drawing.Size(50, 20);
            this.txtBoxAlphaWOD.TabIndex = 62;
            this.txtBoxAlphaWOD.Text = "0,7";
            this.txtBoxAlphaWOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxTauWOD
            // 
            this.txtBoxTauWOD.Location = new System.Drawing.Point(112, 332);
            this.txtBoxTauWOD.Name = "txtBoxTauWOD";
            this.txtBoxTauWOD.Size = new System.Drawing.Size(50, 20);
            this.txtBoxTauWOD.TabIndex = 61;
            this.txtBoxTauWOD.Text = "12,5";
            this.txtBoxTauWOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxIWOD
            // 
            this.txtBoxIWOD.Location = new System.Drawing.Point(31, 332);
            this.txtBoxIWOD.Name = "txtBoxIWOD";
            this.txtBoxIWOD.Size = new System.Drawing.Size(50, 20);
            this.txtBoxIWOD.TabIndex = 60;
            this.txtBoxIWOD.Text = "0,5";
            this.txtBoxIWOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxV0WOD
            // 
            this.txtBoxV0WOD.Location = new System.Drawing.Point(112, 306);
            this.txtBoxV0WOD.Name = "txtBoxV0WOD";
            this.txtBoxV0WOD.Size = new System.Drawing.Size(50, 20);
            this.txtBoxV0WOD.TabIndex = 59;
            this.txtBoxV0WOD.Text = "0,1";
            this.txtBoxV0WOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxU0WOD
            // 
            this.txtBoxU0WOD.Location = new System.Drawing.Point(31, 306);
            this.txtBoxU0WOD.Name = "txtBoxU0WOD";
            this.txtBoxU0WOD.Size = new System.Drawing.Size(50, 20);
            this.txtBoxU0WOD.TabIndex = 58;
            this.txtBoxU0WOD.Text = "1,0";
            this.txtBoxU0WOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxTWOD
            // 
            this.txtBoxTWOD.Location = new System.Drawing.Point(112, 280);
            this.txtBoxTWOD.Name = "txtBoxTWOD";
            this.txtBoxTWOD.Size = new System.Drawing.Size(50, 20);
            this.txtBoxTWOD.TabIndex = 57;
            this.txtBoxTWOD.Text = "100,0";
            this.txtBoxTWOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxLWOD
            // 
            this.txtBoxLWOD.Location = new System.Drawing.Point(31, 280);
            this.txtBoxLWOD.Name = "txtBoxLWOD";
            this.txtBoxLWOD.Size = new System.Drawing.Size(50, 20);
            this.txtBoxLWOD.TabIndex = 56;
            this.txtBoxLWOD.Text = "2,5";
            this.txtBoxLWOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxLWOD.Visible = false;
            // 
            // txtBoxNWOD
            // 
            this.txtBoxNWOD.Location = new System.Drawing.Point(31, 254);
            this.txtBoxNWOD.Name = "txtBoxNWOD";
            this.txtBoxNWOD.Size = new System.Drawing.Size(50, 20);
            this.txtBoxNWOD.TabIndex = 55;
            this.txtBoxNWOD.Text = "1000";
            this.txtBoxNWOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBetaWOD
            // 
            this.lblBetaWOD.AutoSize = true;
            this.lblBetaWOD.Location = new System.Drawing.Point(95, 361);
            this.lblBetaWOD.Name = "lblBetaWOD";
            this.lblBetaWOD.Size = new System.Drawing.Size(13, 13);
            this.lblBetaWOD.TabIndex = 54;
            this.lblBetaWOD.Text = "β";
            // 
            // lblAlphaWOD
            // 
            this.lblAlphaWOD.AutoSize = true;
            this.lblAlphaWOD.Location = new System.Drawing.Point(15, 361);
            this.lblAlphaWOD.Name = "lblAlphaWOD";
            this.lblAlphaWOD.Size = new System.Drawing.Size(14, 13);
            this.lblAlphaWOD.TabIndex = 53;
            this.lblAlphaWOD.Text = "α";
            // 
            // lblTauWOD
            // 
            this.lblTauWOD.AutoSize = true;
            this.lblTauWOD.Location = new System.Drawing.Point(95, 335);
            this.lblTauWOD.Name = "lblTauWOD";
            this.lblTauWOD.Size = new System.Drawing.Size(13, 13);
            this.lblTauWOD.TabIndex = 52;
            this.lblTauWOD.Text = "τ";
            // 
            // lblIWOD
            // 
            this.lblIWOD.AutoSize = true;
            this.lblIWOD.Location = new System.Drawing.Point(8, 335);
            this.lblIWOD.Name = "lblIWOD";
            this.lblIWOD.Size = new System.Drawing.Size(24, 13);
            this.lblIWOD.TabIndex = 51;
            this.lblIWOD.Text = "Iext";
            // 
            // lblV0WOD
            // 
            this.lblV0WOD.AutoSize = true;
            this.lblV0WOD.Location = new System.Drawing.Point(90, 309);
            this.lblV0WOD.Name = "lblV0WOD";
            this.lblV0WOD.Size = new System.Drawing.Size(19, 13);
            this.lblV0WOD.TabIndex = 50;
            this.lblV0WOD.Text = "v0";
            // 
            // lblU0WOD
            // 
            this.lblU0WOD.AutoSize = true;
            this.lblU0WOD.Location = new System.Drawing.Point(11, 309);
            this.lblU0WOD.Name = "lblU0WOD";
            this.lblU0WOD.Size = new System.Drawing.Size(19, 13);
            this.lblU0WOD.TabIndex = 49;
            this.lblU0WOD.Text = "u0";
            // 
            // lblTWOD
            // 
            this.lblTWOD.AutoSize = true;
            this.lblTWOD.Location = new System.Drawing.Point(95, 283);
            this.lblTWOD.Name = "lblTWOD";
            this.lblTWOD.Size = new System.Drawing.Size(14, 13);
            this.lblTWOD.TabIndex = 48;
            this.lblTWOD.Text = "T";
            // 
            // lblLWOD
            // 
            this.lblLWOD.AutoSize = true;
            this.lblLWOD.Location = new System.Drawing.Point(16, 283);
            this.lblLWOD.Name = "lblLWOD";
            this.lblLWOD.Size = new System.Drawing.Size(13, 13);
            this.lblLWOD.TabIndex = 46;
            this.lblLWOD.Text = "L";
            this.lblLWOD.Visible = false;
            // 
            // lblNWOD
            // 
            this.lblNWOD.AutoSize = true;
            this.lblNWOD.Location = new System.Drawing.Point(17, 257);
            this.lblNWOD.Name = "lblNWOD";
            this.lblNWOD.Size = new System.Drawing.Size(13, 13);
            this.lblNWOD.TabIndex = 45;
            this.lblNWOD.Text = "n";
            // 
            // WindowODE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 711);
            this.Controls.Add(this.txtBoxMaxUVTWOD);
            this.Controls.Add(this.lblFAWOD);
            this.Controls.Add(this.txtBoxMinUVTWOD);
            this.Controls.Add(this.btnTuneTWOD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxMaxUVPhaseWOD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxMinUVPhaseWOD);
            this.Controls.Add(this.btnTunePhaseWOD);
            this.Controls.Add(this.lblErrorWOD);
            this.Controls.Add(this.txtBoxFAWOD);
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
            this.Controls.Add(this.panelNonLinTypeWOD);
            this.Controls.Add(this.txtBoxBetaWOD);
            this.Controls.Add(this.txtBoxAlphaWOD);
            this.Controls.Add(this.txtBoxTauWOD);
            this.Controls.Add(this.txtBoxIWOD);
            this.Controls.Add(this.txtBoxV0WOD);
            this.Controls.Add(this.txtBoxU0WOD);
            this.Controls.Add(this.txtBoxTWOD);
            this.Controls.Add(this.txtBoxLWOD);
            this.Controls.Add(this.txtBoxNWOD);
            this.Controls.Add(this.lblBetaWOD);
            this.Controls.Add(this.lblAlphaWOD);
            this.Controls.Add(this.lblTauWOD);
            this.Controls.Add(this.lblIWOD);
            this.Controls.Add(this.lblV0WOD);
            this.Controls.Add(this.lblU0WOD);
            this.Controls.Add(this.lblTWOD);
            this.Controls.Add(this.lblLWOD);
            this.Controls.Add(this.lblNWOD);
            this.Name = "WindowODE";
            this.Text = "WindowODE";
            ((System.ComponentModel.ISupportInitialize)(this.chartTWOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarTWOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPhaseWOD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelNonLinTypeWOD.ResumeLayout(false);
            this.panelNonLinTypeWOD.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxMaxUVTWOD;
        private System.Windows.Forms.Label lblFAWOD;
        public System.Windows.Forms.RadioButton rdBtnPlotAllWOD;
        private System.Windows.Forms.TextBox txtBoxMinUVTWOD;
        private System.Windows.Forms.Button btnTuneTWOD;
        public System.Windows.Forms.RadioButton rdBtnTmrWOD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxMaxUVPhaseWOD;
        public System.Windows.Forms.RadioButton rdBtnClassicalNLWOD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxMinUVPhaseWOD;
        private System.Windows.Forms.Button btnTunePhaseWOD;
        public System.Windows.Forms.RadioButton rdBtnNLWOD;
        public System.Windows.Forms.Label lblErrorWOD;
        private System.Windows.Forms.TextBox txtBoxFAWOD;
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
        private System.Windows.Forms.Panel panelNonLinTypeWOD;
        private System.Windows.Forms.TextBox txtBoxBetaWOD;
        private System.Windows.Forms.TextBox txtBoxAlphaWOD;
        private System.Windows.Forms.TextBox txtBoxTauWOD;
        private System.Windows.Forms.TextBox txtBoxIWOD;
        private System.Windows.Forms.TextBox txtBoxV0WOD;
        private System.Windows.Forms.TextBox txtBoxU0WOD;
        private System.Windows.Forms.TextBox txtBoxTWOD;
        private System.Windows.Forms.TextBox txtBoxLWOD;
        private System.Windows.Forms.TextBox txtBoxNWOD;
        private System.Windows.Forms.Label lblBetaWOD;
        private System.Windows.Forms.Label lblAlphaWOD;
        private System.Windows.Forms.Label lblTauWOD;
        private System.Windows.Forms.Label lblIWOD;
        private System.Windows.Forms.Label lblV0WOD;
        private System.Windows.Forms.Label lblU0WOD;
        private System.Windows.Forms.Label lblTWOD;
        private System.Windows.Forms.Label lblLWOD;
        private System.Windows.Forms.Label lblNWOD;
        private System.Windows.Forms.Timer timerTWOD;
    }
}