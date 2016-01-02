namespace FHN_nonlocal_coupling
{
    partial class WindowPDE
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblError = new System.Windows.Forms.Label();
            this.txtBoxBeta = new System.Windows.Forms.TextBox();
            this.lblBeta = new System.Windows.Forms.Label();
            this.lblI = new System.Windows.Forms.Label();
            this.rdBtnDeltaCoupl = new System.Windows.Forms.RadioButton();
            this.rdBtnCoupl = new System.Windows.Forms.RadioButton();
            this.lblB2 = new System.Windows.Forms.Label();
            this.chBoxPlotWB2 = new System.Windows.Forms.CheckBox();
            this.txtBoxB2 = new System.Windows.Forms.TextBox();
            this.txtBoxI = new System.Windows.Forms.TextBox();
            this.lblD = new System.Windows.Forms.Label();
            this.txtBoxD = new System.Windows.Forms.TextBox();
            this.lblB = new System.Windows.Forms.Label();
            this.txtBoxB = new System.Windows.Forms.TextBox();
            this.lblMinUV = new System.Windows.Forms.Label();
            this.lblMaxUV = new System.Windows.Forms.Label();
            this.btnTune = new System.Windows.Forms.Button();
            this.txtBoxMinUV = new System.Windows.Forms.TextBox();
            this.txtBoxMaxUV = new System.Windows.Forms.TextBox();
            this.chartWDiff = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnSolve = new System.Windows.Forms.Button();
            this.txtBoxGamma = new System.Windows.Forms.TextBox();
            this.btnPlot = new System.Windows.Forms.Button();
            this.txtBoxAlpha = new System.Windows.Forms.TextBox();
            this.trBarT = new System.Windows.Forms.TrackBar();
            this.lblGamma = new System.Windows.Forms.Label();
            this.prBarSolve = new System.Windows.Forms.ProgressBar();
            this.lblAlpha = new System.Windows.Forms.Label();
            this.rdBtnTmr = new System.Windows.Forms.RadioButton();
            this.panelEqType = new System.Windows.Forms.Panel();
            this.btnStopTimer = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtBoxN = new System.Windows.Forms.TextBox();
            this.lblFA = new System.Windows.Forms.Label();
            this.txtBoxM = new System.Windows.Forms.TextBox();
            this.lblT = new System.Windows.Forms.Label();
            this.txtBoxL = new System.Windows.Forms.TextBox();
            this.lblL = new System.Windows.Forms.Label();
            this.txtBoxT = new System.Windows.Forms.TextBox();
            this.lblM = new System.Windows.Forms.Label();
            this.txtBoxA = new System.Windows.Forms.TextBox();
            this.lblN = new System.Windows.Forms.Label();
            this.timerT = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chartWDiff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarT)).BeginInit();
            this.panelEqType.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblError.ForeColor = System.Drawing.Color.DarkRed;
            this.lblError.Location = new System.Drawing.Point(189, 665);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(102, 16);
            this.lblError.TabIndex = 80;
            this.lblError.Text = "Error occured";
            this.lblError.Visible = false;
            // 
            // txtBoxBeta
            // 
            this.txtBoxBeta.Location = new System.Drawing.Point(108, 306);
            this.txtBoxBeta.Name = "txtBoxBeta";
            this.txtBoxBeta.Size = new System.Drawing.Size(50, 20);
            this.txtBoxBeta.TabIndex = 79;
            this.txtBoxBeta.Text = "0,064";
            this.txtBoxBeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBeta
            // 
            this.lblBeta.AutoSize = true;
            this.lblBeta.Location = new System.Drawing.Point(93, 309);
            this.lblBeta.Name = "lblBeta";
            this.lblBeta.Size = new System.Drawing.Size(13, 13);
            this.lblBeta.TabIndex = 78;
            this.lblBeta.Text = "β";
            // 
            // lblI
            // 
            this.lblI.AutoSize = true;
            this.lblI.Location = new System.Drawing.Point(83, 388);
            this.lblI.Name = "lblI";
            this.lblI.Size = new System.Drawing.Size(24, 13);
            this.lblI.TabIndex = 76;
            this.lblI.Text = "Iext";
            // 
            // rdBtnDeltaCoupl
            // 
            this.rdBtnDeltaCoupl.AutoSize = true;
            this.rdBtnDeltaCoupl.Checked = true;
            this.rdBtnDeltaCoupl.Location = new System.Drawing.Point(3, 3);
            this.rdBtnDeltaCoupl.Name = "rdBtnDeltaCoupl";
            this.rdBtnDeltaCoupl.Size = new System.Drawing.Size(63, 17);
            this.rdBtnDeltaCoupl.TabIndex = 17;
            this.rdBtnDeltaCoupl.TabStop = true;
            this.rdBtnDeltaCoupl.Text = "δ-kernel";
            this.rdBtnDeltaCoupl.UseVisualStyleBackColor = true;
            // 
            // rdBtnCoupl
            // 
            this.rdBtnCoupl.AutoSize = true;
            this.rdBtnCoupl.Location = new System.Drawing.Point(3, 26);
            this.rdBtnCoupl.Name = "rdBtnCoupl";
            this.rdBtnCoupl.Size = new System.Drawing.Size(54, 17);
            this.rdBtnCoupl.TabIndex = 18;
            this.rdBtnCoupl.Text = "kernel";
            this.rdBtnCoupl.UseVisualStyleBackColor = true;
            // 
            // lblB2
            // 
            this.lblB2.AutoSize = true;
            this.lblB2.Location = new System.Drawing.Point(91, 442);
            this.lblB2.Name = "lblB2";
            this.lblB2.Size = new System.Drawing.Size(15, 13);
            this.lblB2.TabIndex = 83;
            this.lblB2.Text = "b\'";
            this.lblB2.Visible = false;
            // 
            // chBoxPlotWB2
            // 
            this.chBoxPlotWB2.AutoSize = true;
            this.chBoxPlotWB2.Location = new System.Drawing.Point(16, 442);
            this.chBoxPlotWB2.Name = "chBoxPlotWB2";
            this.chBoxPlotWB2.Size = new System.Drawing.Size(66, 17);
            this.chBoxPlotWB2.TabIndex = 82;
            this.chBoxPlotWB2.Text = "Plot w b\'";
            this.chBoxPlotWB2.UseVisualStyleBackColor = true;
            // 
            // txtBoxB2
            // 
            this.txtBoxB2.Location = new System.Drawing.Point(108, 439);
            this.txtBoxB2.Name = "txtBoxB2";
            this.txtBoxB2.Size = new System.Drawing.Size(50, 20);
            this.txtBoxB2.TabIndex = 81;
            this.txtBoxB2.Text = "0,0";
            this.txtBoxB2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxB2.Visible = false;
            // 
            // txtBoxI
            // 
            this.txtBoxI.Location = new System.Drawing.Point(108, 385);
            this.txtBoxI.Name = "txtBoxI";
            this.txtBoxI.Size = new System.Drawing.Size(50, 20);
            this.txtBoxI.TabIndex = 77;
            this.txtBoxI.Text = "0,0";
            this.txtBoxI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblD
            // 
            this.lblD.AutoSize = true;
            this.lblD.Location = new System.Drawing.Point(92, 361);
            this.lblD.Name = "lblD";
            this.lblD.Size = new System.Drawing.Size(13, 13);
            this.lblD.TabIndex = 75;
            this.lblD.Text = "d";
            // 
            // txtBoxD
            // 
            this.txtBoxD.Location = new System.Drawing.Point(108, 358);
            this.txtBoxD.Name = "txtBoxD";
            this.txtBoxD.Size = new System.Drawing.Size(50, 20);
            this.txtBoxD.TabIndex = 74;
            this.txtBoxD.Text = "1,0";
            this.txtBoxD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(92, 335);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(13, 13);
            this.lblB.TabIndex = 59;
            this.lblB.Text = "b";
            // 
            // txtBoxB
            // 
            this.txtBoxB.Location = new System.Drawing.Point(108, 332);
            this.txtBoxB.Name = "txtBoxB";
            this.txtBoxB.Size = new System.Drawing.Size(50, 20);
            this.txtBoxB.TabIndex = 62;
            this.txtBoxB.Text = "0,0";
            this.txtBoxB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMinUV
            // 
            this.lblMinUV.AutoSize = true;
            this.lblMinUV.Location = new System.Drawing.Point(202, 607);
            this.lblMinUV.Name = "lblMinUV";
            this.lblMinUV.Size = new System.Drawing.Size(41, 13);
            this.lblMinUV.TabIndex = 67;
            this.lblMinUV.Text = "min u,v";
            // 
            // lblMaxUV
            // 
            this.lblMaxUV.AutoSize = true;
            this.lblMaxUV.Location = new System.Drawing.Point(199, 40);
            this.lblMaxUV.Name = "lblMaxUV";
            this.lblMaxUV.Size = new System.Drawing.Size(44, 13);
            this.lblMaxUV.TabIndex = 66;
            this.lblMaxUV.Text = "max u,v";
            // 
            // btnTune
            // 
            this.btnTune.Location = new System.Drawing.Point(242, 333);
            this.btnTune.Name = "btnTune";
            this.btnTune.Size = new System.Drawing.Size(42, 23);
            this.btnTune.TabIndex = 73;
            this.btnTune.Text = "Zoom";
            this.btnTune.UseVisualStyleBackColor = true;
            this.btnTune.Click += new System.EventHandler(this.btnTune_Click);
            // 
            // txtBoxMinUV
            // 
            this.txtBoxMinUV.Location = new System.Drawing.Point(243, 604);
            this.txtBoxMinUV.Name = "txtBoxMinUV";
            this.txtBoxMinUV.Size = new System.Drawing.Size(34, 20);
            this.txtBoxMinUV.TabIndex = 57;
            this.txtBoxMinUV.Text = "-2,1";
            this.txtBoxMinUV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxMaxUV
            // 
            this.txtBoxMaxUV.Location = new System.Drawing.Point(243, 37);
            this.txtBoxMaxUV.Name = "txtBoxMaxUV";
            this.txtBoxMaxUV.Size = new System.Drawing.Size(34, 20);
            this.txtBoxMaxUV.TabIndex = 58;
            this.txtBoxMaxUV.Text = "2,0";
            this.txtBoxMaxUV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chartWDiff
            // 
            chartArea2.Name = "ChartArea1";
            this.chartWDiff.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartWDiff.Legends.Add(legend2);
            this.chartWDiff.Location = new System.Drawing.Point(242, 8);
            this.chartWDiff.Name = "chartWDiff";
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.MarkerSize = 7;
            series5.Name = "U";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series5.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series6.BorderWidth = 3;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series6.Legend = "Legend1";
            series6.MarkerSize = 7;
            series6.Name = "V";
            series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series6.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series7.BorderWidth = 2;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Legend = "Legend1";
            series7.Name = "U(b\')";
            series8.BorderWidth = 2;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Legend = "Legend1";
            series8.Name = "V(b\')";
            this.chartWDiff.Series.Add(series5);
            this.chartWDiff.Series.Add(series6);
            this.chartWDiff.Series.Add(series7);
            this.chartWDiff.Series.Add(series8);
            this.chartWDiff.Size = new System.Drawing.Size(1031, 650);
            this.chartWDiff.TabIndex = 44;
            this.chartWDiff.Text = "chart1";
            // 
            // btnSolve
            // 
            this.btnSolve.Enabled = false;
            this.btnSolve.Location = new System.Drawing.Point(27, 579);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(75, 23);
            this.btnSolve.TabIndex = 45;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // txtBoxGamma
            // 
            this.txtBoxGamma.Location = new System.Drawing.Point(189, 306);
            this.txtBoxGamma.Name = "txtBoxGamma";
            this.txtBoxGamma.Size = new System.Drawing.Size(50, 20);
            this.txtBoxGamma.TabIndex = 72;
            this.txtBoxGamma.Text = "0,056";
            this.txtBoxGamma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPlot
            // 
            this.btnPlot.Enabled = false;
            this.btnPlot.Location = new System.Drawing.Point(27, 608);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(75, 23);
            this.btnPlot.TabIndex = 46;
            this.btnPlot.Text = "Plot";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
            // 
            // txtBoxAlpha
            // 
            this.txtBoxAlpha.Location = new System.Drawing.Point(27, 306);
            this.txtBoxAlpha.Name = "txtBoxAlpha";
            this.txtBoxAlpha.Size = new System.Drawing.Size(50, 20);
            this.txtBoxAlpha.TabIndex = 71;
            this.txtBoxAlpha.Text = "0,08";
            this.txtBoxAlpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // trBarT
            // 
            this.trBarT.Location = new System.Drawing.Point(312, 658);
            this.trBarT.Maximum = 49;
            this.trBarT.Name = "trBarT";
            this.trBarT.Size = new System.Drawing.Size(827, 45);
            this.trBarT.TabIndex = 47;
            // 
            // lblGamma
            // 
            this.lblGamma.AutoSize = true;
            this.lblGamma.Location = new System.Drawing.Point(173, 309);
            this.lblGamma.Name = "lblGamma";
            this.lblGamma.Size = new System.Drawing.Size(13, 13);
            this.lblGamma.TabIndex = 70;
            this.lblGamma.Text = "γ";
            // 
            // prBarSolve
            // 
            this.prBarSolve.Location = new System.Drawing.Point(27, 661);
            this.prBarSolve.Maximum = 4;
            this.prBarSolve.Name = "prBarSolve";
            this.prBarSolve.Size = new System.Drawing.Size(156, 23);
            this.prBarSolve.Step = 1;
            this.prBarSolve.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prBarSolve.TabIndex = 48;
            // 
            // lblAlpha
            // 
            this.lblAlpha.AutoSize = true;
            this.lblAlpha.Location = new System.Drawing.Point(11, 309);
            this.lblAlpha.Name = "lblAlpha";
            this.lblAlpha.Size = new System.Drawing.Size(14, 13);
            this.lblAlpha.TabIndex = 69;
            this.lblAlpha.Text = "α";
            // 
            // rdBtnTmr
            // 
            this.rdBtnTmr.AutoSize = true;
            this.rdBtnTmr.Location = new System.Drawing.Point(111, 609);
            this.rdBtnTmr.Name = "rdBtnTmr";
            this.rdBtnTmr.Size = new System.Drawing.Size(76, 17);
            this.rdBtnTmr.TabIndex = 49;
            this.rdBtnTmr.Text = "With Timer";
            this.rdBtnTmr.UseVisualStyleBackColor = true;
            // 
            // panelEqType
            // 
            this.panelEqType.Controls.Add(this.rdBtnDeltaCoupl);
            this.panelEqType.Controls.Add(this.rdBtnCoupl);
            this.panelEqType.Location = new System.Drawing.Point(14, 358);
            this.panelEqType.Name = "panelEqType";
            this.panelEqType.Size = new System.Drawing.Size(69, 47);
            this.panelEqType.TabIndex = 68;
            // 
            // btnStopTimer
            // 
            this.btnStopTimer.Location = new System.Drawing.Point(108, 632);
            this.btnStopTimer.Name = "btnStopTimer";
            this.btnStopTimer.Size = new System.Drawing.Size(75, 23);
            this.btnStopTimer.TabIndex = 50;
            this.btnStopTimer.Text = "Stop Timer";
            this.btnStopTimer.UseVisualStyleBackColor = true;
            this.btnStopTimer.Click += new System.EventHandler(this.btnStopTimer_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(27, 550);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 51;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtBoxN
            // 
            this.txtBoxN.Location = new System.Drawing.Point(27, 254);
            this.txtBoxN.Name = "txtBoxN";
            this.txtBoxN.Size = new System.Drawing.Size(50, 20);
            this.txtBoxN.TabIndex = 52;
            this.txtBoxN.Text = "2000";
            this.txtBoxN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblFA
            // 
            this.lblFA.AutoSize = true;
            this.lblFA.Location = new System.Drawing.Point(11, 335);
            this.lblFA.Name = "lblFA";
            this.lblFA.Size = new System.Drawing.Size(13, 13);
            this.lblFA.TabIndex = 65;
            this.lblFA.Text = "a";
            // 
            // txtBoxM
            // 
            this.txtBoxM.Location = new System.Drawing.Point(108, 254);
            this.txtBoxM.Name = "txtBoxM";
            this.txtBoxM.Size = new System.Drawing.Size(50, 20);
            this.txtBoxM.TabIndex = 53;
            this.txtBoxM.Text = "2000";
            this.txtBoxM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblT
            // 
            this.lblT.AutoSize = true;
            this.lblT.Location = new System.Drawing.Point(91, 283);
            this.lblT.Name = "lblT";
            this.lblT.Size = new System.Drawing.Size(14, 13);
            this.lblT.TabIndex = 64;
            this.lblT.Text = "T";
            // 
            // txtBoxL
            // 
            this.txtBoxL.Location = new System.Drawing.Point(27, 280);
            this.txtBoxL.Name = "txtBoxL";
            this.txtBoxL.Size = new System.Drawing.Size(50, 20);
            this.txtBoxL.TabIndex = 54;
            this.txtBoxL.Text = "50,0";
            this.txtBoxL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblL
            // 
            this.lblL.AutoSize = true;
            this.lblL.Location = new System.Drawing.Point(12, 283);
            this.lblL.Name = "lblL";
            this.lblL.Size = new System.Drawing.Size(13, 13);
            this.lblL.TabIndex = 63;
            this.lblL.Text = "L";
            // 
            // txtBoxT
            // 
            this.txtBoxT.Location = new System.Drawing.Point(108, 280);
            this.txtBoxT.Name = "txtBoxT";
            this.txtBoxT.Size = new System.Drawing.Size(50, 20);
            this.txtBoxT.TabIndex = 55;
            this.txtBoxT.Text = "40,0";
            this.txtBoxT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblM
            // 
            this.lblM.AutoSize = true;
            this.lblM.Location = new System.Drawing.Point(90, 257);
            this.lblM.Name = "lblM";
            this.lblM.Size = new System.Drawing.Size(15, 13);
            this.lblM.TabIndex = 61;
            this.lblM.Text = "m";
            // 
            // txtBoxA
            // 
            this.txtBoxA.Location = new System.Drawing.Point(27, 332);
            this.txtBoxA.Name = "txtBoxA";
            this.txtBoxA.Size = new System.Drawing.Size(50, 20);
            this.txtBoxA.TabIndex = 56;
            this.txtBoxA.Text = "0,1";
            this.txtBoxA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Location = new System.Drawing.Point(13, 257);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(13, 13);
            this.lblN.TabIndex = 60;
            this.lblN.Text = "n";
            // 
            // WindowPDE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 711);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.txtBoxBeta);
            this.Controls.Add(this.lblBeta);
            this.Controls.Add(this.lblI);
            this.Controls.Add(this.lblB2);
            this.Controls.Add(this.chBoxPlotWB2);
            this.Controls.Add(this.txtBoxB2);
            this.Controls.Add(this.txtBoxI);
            this.Controls.Add(this.lblD);
            this.Controls.Add(this.txtBoxD);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.txtBoxB);
            this.Controls.Add(this.lblMinUV);
            this.Controls.Add(this.lblMaxUV);
            this.Controls.Add(this.btnTune);
            this.Controls.Add(this.txtBoxMinUV);
            this.Controls.Add(this.txtBoxMaxUV);
            this.Controls.Add(this.chartWDiff);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.txtBoxGamma);
            this.Controls.Add(this.btnPlot);
            this.Controls.Add(this.txtBoxAlpha);
            this.Controls.Add(this.trBarT);
            this.Controls.Add(this.lblGamma);
            this.Controls.Add(this.prBarSolve);
            this.Controls.Add(this.lblAlpha);
            this.Controls.Add(this.rdBtnTmr);
            this.Controls.Add(this.panelEqType);
            this.Controls.Add(this.btnStopTimer);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtBoxN);
            this.Controls.Add(this.lblFA);
            this.Controls.Add(this.txtBoxM);
            this.Controls.Add(this.lblT);
            this.Controls.Add(this.txtBoxL);
            this.Controls.Add(this.lblL);
            this.Controls.Add(this.txtBoxT);
            this.Controls.Add(this.lblM);
            this.Controls.Add(this.txtBoxA);
            this.Controls.Add(this.lblN);
            this.Name = "WindowPDE";
            this.Text = "WindowPDE";
            ((System.ComponentModel.ISupportInitialize)(this.chartWDiff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarT)).EndInit();
            this.panelEqType.ResumeLayout(false);
            this.panelEqType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblError;
        public System.Windows.Forms.TextBox txtBoxBeta;
        private System.Windows.Forms.Label lblBeta;
        private System.Windows.Forms.Label lblI;
        private System.Windows.Forms.RadioButton rdBtnDeltaCoupl;
        private System.Windows.Forms.RadioButton rdBtnCoupl;
        private System.Windows.Forms.Label lblB2;
        private System.Windows.Forms.CheckBox chBoxPlotWB2;
        private System.Windows.Forms.TextBox txtBoxB2;
        public System.Windows.Forms.TextBox txtBoxI;
        private System.Windows.Forms.Label lblD;
        public System.Windows.Forms.TextBox txtBoxD;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.TextBox txtBoxB;
        private System.Windows.Forms.Label lblMinUV;
        private System.Windows.Forms.Label lblMaxUV;
        private System.Windows.Forms.Button btnTune;
        private System.Windows.Forms.TextBox txtBoxMinUV;
        private System.Windows.Forms.TextBox txtBoxMaxUV;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartWDiff;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.TextBox txtBoxGamma;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.TextBox txtBoxAlpha;
        private System.Windows.Forms.TrackBar trBarT;
        private System.Windows.Forms.Label lblGamma;
        public System.Windows.Forms.ProgressBar prBarSolve;
        private System.Windows.Forms.Label lblAlpha;
        private System.Windows.Forms.RadioButton rdBtnTmr;
        private System.Windows.Forms.Panel panelEqType;
        private System.Windows.Forms.Button btnStopTimer;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtBoxN;
        private System.Windows.Forms.Label lblFA;
        private System.Windows.Forms.TextBox txtBoxM;
        private System.Windows.Forms.Label lblT;
        private System.Windows.Forms.TextBox txtBoxL;
        private System.Windows.Forms.Label lblL;
        private System.Windows.Forms.TextBox txtBoxT;
        private System.Windows.Forms.Label lblM;
        private System.Windows.Forms.TextBox txtBoxA;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.Timer timerT;
    }
}