namespace FHN_nonlocal_coupling
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartWDiff = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnSolve = new System.Windows.Forms.Button();
            this.btnPlot = new System.Windows.Forms.Button();
            this.trBarT = new System.Windows.Forms.TrackBar();
            this.prBarSolve = new System.Windows.Forms.ProgressBar();
            this.timerT = new System.Windows.Forms.Timer(this.components);
            this.rdBtnTmr = new System.Windows.Forms.RadioButton();
            this.btnStopTimer = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtBoxN = new System.Windows.Forms.TextBox();
            this.txtBoxM = new System.Windows.Forms.TextBox();
            this.txtBoxL = new System.Windows.Forms.TextBox();
            this.txtBoxT = new System.Windows.Forms.TextBox();
            this.txtBoxA = new System.Windows.Forms.TextBox();
            this.txtBoxMinUV = new System.Windows.Forms.TextBox();
            this.txtBoxMaxUV = new System.Windows.Forms.TextBox();
            this.rdBtnDeltaCoupl = new System.Windows.Forms.RadioButton();
            this.rdBtnCoupl = new System.Windows.Forms.RadioButton();
            this.lblN = new System.Windows.Forms.Label();
            this.lblM = new System.Windows.Forms.Label();
            this.lblL = new System.Windows.Forms.Label();
            this.lblT = new System.Windows.Forms.Label();
            this.lblMaxUV = new System.Windows.Forms.Label();
            this.lblMinUV = new System.Windows.Forms.Label();
            this.panelEqType = new System.Windows.Forms.Panel();
            this.lblAlpha = new System.Windows.Forms.Label();
            this.lblGamma = new System.Windows.Forms.Label();
            this.txtBoxAlpha = new System.Windows.Forms.TextBox();
            this.txtBoxGamma = new System.Windows.Forms.TextBox();
            this.btnTune = new System.Windows.Forms.Button();
            this.lblFA = new System.Windows.Forms.Label();
            this.tabEq = new System.Windows.Forms.TabControl();
            this.tabPageWDiff = new System.Windows.Forms.TabPage();
            this.txtBoxBeta = new System.Windows.Forms.TextBox();
            this.lblBeta = new System.Windows.Forms.Label();
            this.txtBoxI = new System.Windows.Forms.TextBox();
            this.lblI = new System.Windows.Forms.Label();
            this.lblD = new System.Windows.Forms.Label();
            this.txtBoxD = new System.Windows.Forms.TextBox();
            this.lblB = new System.Windows.Forms.Label();
            this.txtBoxB = new System.Windows.Forms.TextBox();
            this.tabPageWODiff = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxMaxUVTWOD = new System.Windows.Forms.TextBox();
            this.txtBoxMinUVPhaseWOD = new System.Windows.Forms.TextBox();
            this.txtBoxMinUVTWOD = new System.Windows.Forms.TextBox();
            this.txtBoxFAWOD = new System.Windows.Forms.TextBox();
            this.btnTuneTWOD = new System.Windows.Forms.Button();
            this.txtBoxMaxUVPhaseWOD = new System.Windows.Forms.TextBox();
            this.chartTWOD = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblFAWOD = new System.Windows.Forms.Label();
            this.btnTunePhaseWOD = new System.Windows.Forms.Button();
            this.trBarTWOD = new System.Windows.Forms.TrackBar();
            this.chartPhaseWOD = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.prBarSolveWOD = new System.Windows.Forms.ProgressBar();
            this.lblMinUVWOD = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdBtnPlotAllWOD = new System.Windows.Forms.RadioButton();
            this.rdBtnTmrWOD = new System.Windows.Forms.RadioButton();
            this.btnStopTimerWOD = new System.Windows.Forms.Button();
            this.lblMaxUVWOD = new System.Windows.Forms.Label();
            this.btnPlotWOD = new System.Windows.Forms.Button();
            this.btnSolveWOD = new System.Windows.Forms.Button();
            this.btnLoadWOD = new System.Windows.Forms.Button();
            this.panelNonLinTypeWOD = new System.Windows.Forms.Panel();
            this.rdBtnNLWOD = new System.Windows.Forms.RadioButton();
            this.rdBtnClassicalNLWOD = new System.Windows.Forms.RadioButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.chartWDiff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarT)).BeginInit();
            this.panelEqType.SuspendLayout();
            this.tabEq.SuspendLayout();
            this.tabPageWDiff.SuspendLayout();
            this.tabPageWODiff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTWOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarTWOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPhaseWOD)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelNonLinTypeWOD.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartWDiff
            // 
            chartArea4.Name = "ChartArea1";
            this.chartWDiff.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartWDiff.Legends.Add(legend4);
            this.chartWDiff.Location = new System.Drawing.Point(240, 0);
            this.chartWDiff.Name = "chartWDiff";
            series8.BorderWidth = 3;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Legend = "Legend1";
            series8.MarkerSize = 7;
            series8.Name = "U";
            series8.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series8.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series9.BorderWidth = 3;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series9.Legend = "Legend1";
            series9.MarkerSize = 7;
            series9.Name = "V";
            series9.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series9.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chartWDiff.Series.Add(series8);
            this.chartWDiff.Series.Add(series9);
            this.chartWDiff.Size = new System.Drawing.Size(1031, 650);
            this.chartWDiff.TabIndex = 0;
            this.chartWDiff.Text = "chart1";
            // 
            // btnSolve
            // 
            this.btnSolve.Enabled = false;
            this.btnSolve.Location = new System.Drawing.Point(25, 571);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(75, 23);
            this.btnSolve.TabIndex = 1;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // btnPlot
            // 
            this.btnPlot.Enabled = false;
            this.btnPlot.Location = new System.Drawing.Point(25, 600);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(75, 23);
            this.btnPlot.TabIndex = 2;
            this.btnPlot.Text = "Plot";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
            // 
            // trBarT
            // 
            this.trBarT.Location = new System.Drawing.Point(310, 650);
            this.trBarT.Maximum = 49;
            this.trBarT.Name = "trBarT";
            this.trBarT.Size = new System.Drawing.Size(827, 45);
            this.trBarT.TabIndex = 3;
            this.trBarT.Scroll += new System.EventHandler(this.trBarT_Scroll);
            // 
            // prBarSolve
            // 
            this.prBarSolve.Location = new System.Drawing.Point(25, 653);
            this.prBarSolve.Maximum = 4;
            this.prBarSolve.Name = "prBarSolve";
            this.prBarSolve.Size = new System.Drawing.Size(156, 23);
            this.prBarSolve.Step = 1;
            this.prBarSolve.TabIndex = 4;
            // 
            // timerT
            // 
            this.timerT.Interval = 500;
            this.timerT.Tick += new System.EventHandler(this.timerT_Tick);
            // 
            // rdBtnTmr
            // 
            this.rdBtnTmr.AutoSize = true;
            this.rdBtnTmr.Location = new System.Drawing.Point(109, 601);
            this.rdBtnTmr.Name = "rdBtnTmr";
            this.rdBtnTmr.Size = new System.Drawing.Size(76, 17);
            this.rdBtnTmr.TabIndex = 5;
            this.rdBtnTmr.Text = "With Timer";
            this.rdBtnTmr.UseVisualStyleBackColor = true;
            // 
            // btnStopTimer
            // 
            this.btnStopTimer.Location = new System.Drawing.Point(106, 624);
            this.btnStopTimer.Name = "btnStopTimer";
            this.btnStopTimer.Size = new System.Drawing.Size(75, 23);
            this.btnStopTimer.TabIndex = 6;
            this.btnStopTimer.Text = "Stop Timer";
            this.btnStopTimer.UseVisualStyleBackColor = true;
            this.btnStopTimer.Click += new System.EventHandler(this.btnStopTimer_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(25, 542);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtBoxN
            // 
            this.txtBoxN.Location = new System.Drawing.Point(25, 246);
            this.txtBoxN.Name = "txtBoxN";
            this.txtBoxN.Size = new System.Drawing.Size(50, 20);
            this.txtBoxN.TabIndex = 8;
            this.txtBoxN.Text = "2000";
            this.txtBoxN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxN.TextChanged += new System.EventHandler(this.txtBoxN_TextChanged);
            // 
            // txtBoxM
            // 
            this.txtBoxM.Location = new System.Drawing.Point(106, 246);
            this.txtBoxM.Name = "txtBoxM";
            this.txtBoxM.Size = new System.Drawing.Size(50, 20);
            this.txtBoxM.TabIndex = 9;
            this.txtBoxM.Text = "2000";
            this.txtBoxM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxM.TextChanged += new System.EventHandler(this.txtBoxM_TextChanged);
            // 
            // txtBoxL
            // 
            this.txtBoxL.Location = new System.Drawing.Point(25, 272);
            this.txtBoxL.Name = "txtBoxL";
            this.txtBoxL.Size = new System.Drawing.Size(50, 20);
            this.txtBoxL.TabIndex = 10;
            this.txtBoxL.Text = "50,0";
            this.txtBoxL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxL.TextChanged += new System.EventHandler(this.txtBoxL_TextChanged);
            // 
            // txtBoxT
            // 
            this.txtBoxT.Location = new System.Drawing.Point(106, 272);
            this.txtBoxT.Name = "txtBoxT";
            this.txtBoxT.Size = new System.Drawing.Size(50, 20);
            this.txtBoxT.TabIndex = 11;
            this.txtBoxT.Text = "40,0";
            this.txtBoxT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxT.TextChanged += new System.EventHandler(this.txtBoxT_TextChanged);
            // 
            // txtBoxA
            // 
            this.txtBoxA.Location = new System.Drawing.Point(25, 324);
            this.txtBoxA.Name = "txtBoxA";
            this.txtBoxA.Size = new System.Drawing.Size(50, 20);
            this.txtBoxA.TabIndex = 14;
            this.txtBoxA.Text = "0,1";
            this.txtBoxA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxA.TextChanged += new System.EventHandler(this.txtBoxA_TextChanged);
            // 
            // txtBoxMinUV
            // 
            this.txtBoxMinUV.Location = new System.Drawing.Point(241, 596);
            this.txtBoxMinUV.Name = "txtBoxMinUV";
            this.txtBoxMinUV.Size = new System.Drawing.Size(34, 20);
            this.txtBoxMinUV.TabIndex = 15;
            this.txtBoxMinUV.Text = "-2,1";
            this.txtBoxMinUV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxMaxUV
            // 
            this.txtBoxMaxUV.Location = new System.Drawing.Point(241, 29);
            this.txtBoxMaxUV.Name = "txtBoxMaxUV";
            this.txtBoxMaxUV.Size = new System.Drawing.Size(34, 20);
            this.txtBoxMaxUV.TabIndex = 16;
            this.txtBoxMaxUV.Text = "2,0";
            this.txtBoxMaxUV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.rdBtnDeltaCoupl.CheckedChanged += new System.EventHandler(this.rdBtnDeltaCoupl_CheckedChanged);
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
            this.rdBtnCoupl.CheckedChanged += new System.EventHandler(this.rdBtnCoupl_CheckedChanged);
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Location = new System.Drawing.Point(11, 249);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(13, 13);
            this.lblN.TabIndex = 19;
            this.lblN.Text = "n";
            // 
            // lblM
            // 
            this.lblM.AutoSize = true;
            this.lblM.Location = new System.Drawing.Point(88, 249);
            this.lblM.Name = "lblM";
            this.lblM.Size = new System.Drawing.Size(15, 13);
            this.lblM.TabIndex = 20;
            this.lblM.Text = "m";
            // 
            // lblL
            // 
            this.lblL.AutoSize = true;
            this.lblL.Location = new System.Drawing.Point(13, 275);
            this.lblL.Name = "lblL";
            this.lblL.Size = new System.Drawing.Size(9, 13);
            this.lblL.TabIndex = 21;
            this.lblL.Text = "l";
            // 
            // lblT
            // 
            this.lblT.AutoSize = true;
            this.lblT.Location = new System.Drawing.Point(89, 275);
            this.lblT.Name = "lblT";
            this.lblT.Size = new System.Drawing.Size(14, 13);
            this.lblT.TabIndex = 22;
            this.lblT.Text = "T";
            // 
            // lblMaxUV
            // 
            this.lblMaxUV.AutoSize = true;
            this.lblMaxUV.Location = new System.Drawing.Point(197, 32);
            this.lblMaxUV.Name = "lblMaxUV";
            this.lblMaxUV.Size = new System.Drawing.Size(44, 13);
            this.lblMaxUV.TabIndex = 26;
            this.lblMaxUV.Text = "max u,v";
            // 
            // lblMinUV
            // 
            this.lblMinUV.AutoSize = true;
            this.lblMinUV.Location = new System.Drawing.Point(200, 599);
            this.lblMinUV.Name = "lblMinUV";
            this.lblMinUV.Size = new System.Drawing.Size(41, 13);
            this.lblMinUV.TabIndex = 27;
            this.lblMinUV.Text = "min u,v";
            // 
            // panelEqType
            // 
            this.panelEqType.Controls.Add(this.rdBtnDeltaCoupl);
            this.panelEqType.Controls.Add(this.rdBtnCoupl);
            this.panelEqType.Location = new System.Drawing.Point(12, 350);
            this.panelEqType.Name = "panelEqType";
            this.panelEqType.Size = new System.Drawing.Size(69, 47);
            this.panelEqType.TabIndex = 28;
            // 
            // lblAlpha
            // 
            this.lblAlpha.AutoSize = true;
            this.lblAlpha.Location = new System.Drawing.Point(9, 301);
            this.lblAlpha.Name = "lblAlpha";
            this.lblAlpha.Size = new System.Drawing.Size(14, 13);
            this.lblAlpha.TabIndex = 29;
            this.lblAlpha.Text = "α";
            // 
            // lblGamma
            // 
            this.lblGamma.AutoSize = true;
            this.lblGamma.Location = new System.Drawing.Point(171, 301);
            this.lblGamma.Name = "lblGamma";
            this.lblGamma.Size = new System.Drawing.Size(13, 13);
            this.lblGamma.TabIndex = 30;
            this.lblGamma.Text = "γ";
            // 
            // txtBoxAlpha
            // 
            this.txtBoxAlpha.Location = new System.Drawing.Point(25, 298);
            this.txtBoxAlpha.Name = "txtBoxAlpha";
            this.txtBoxAlpha.Size = new System.Drawing.Size(50, 20);
            this.txtBoxAlpha.TabIndex = 31;
            this.txtBoxAlpha.Text = "0,08";
            this.txtBoxAlpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxAlpha.TextChanged += new System.EventHandler(this.txtBoxAlpha_TextChanged);
            // 
            // txtBoxGamma
            // 
            this.txtBoxGamma.Location = new System.Drawing.Point(187, 298);
            this.txtBoxGamma.Name = "txtBoxGamma";
            this.txtBoxGamma.Size = new System.Drawing.Size(50, 20);
            this.txtBoxGamma.TabIndex = 32;
            this.txtBoxGamma.Text = "0,056";
            this.txtBoxGamma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxGamma.TextChanged += new System.EventHandler(this.txtBoxGamma_TextChanged);
            // 
            // btnTune
            // 
            this.btnTune.Location = new System.Drawing.Point(240, 325);
            this.btnTune.Name = "btnTune";
            this.btnTune.Size = new System.Drawing.Size(42, 23);
            this.btnTune.TabIndex = 33;
            this.btnTune.Text = "Zoom";
            this.btnTune.UseVisualStyleBackColor = true;
            this.btnTune.Click += new System.EventHandler(this.btnTune_Click);
            // 
            // lblFA
            // 
            this.lblFA.AutoSize = true;
            this.lblFA.Location = new System.Drawing.Point(9, 327);
            this.lblFA.Name = "lblFA";
            this.lblFA.Size = new System.Drawing.Size(13, 13);
            this.lblFA.TabIndex = 25;
            this.lblFA.Text = "a";
            // 
            // tabEq
            // 
            this.tabEq.Controls.Add(this.tabPageWDiff);
            this.tabEq.Controls.Add(this.tabPageWODiff);
            this.tabEq.Location = new System.Drawing.Point(-3, 1);
            this.tabEq.Name = "tabEq";
            this.tabEq.SelectedIndex = 0;
            this.tabEq.Size = new System.Drawing.Size(1286, 750);
            this.tabEq.TabIndex = 34;
            // 
            // tabPageWDiff
            // 
            this.tabPageWDiff.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageWDiff.Controls.Add(this.txtBoxBeta);
            this.tabPageWDiff.Controls.Add(this.lblBeta);
            this.tabPageWDiff.Controls.Add(this.txtBoxI);
            this.tabPageWDiff.Controls.Add(this.lblI);
            this.tabPageWDiff.Controls.Add(this.lblD);
            this.tabPageWDiff.Controls.Add(this.txtBoxD);
            this.tabPageWDiff.Controls.Add(this.lblB);
            this.tabPageWDiff.Controls.Add(this.txtBoxB);
            this.tabPageWDiff.Controls.Add(this.lblMinUV);
            this.tabPageWDiff.Controls.Add(this.lblMaxUV);
            this.tabPageWDiff.Controls.Add(this.btnTune);
            this.tabPageWDiff.Controls.Add(this.txtBoxMinUV);
            this.tabPageWDiff.Controls.Add(this.txtBoxMaxUV);
            this.tabPageWDiff.Controls.Add(this.chartWDiff);
            this.tabPageWDiff.Controls.Add(this.btnSolve);
            this.tabPageWDiff.Controls.Add(this.txtBoxGamma);
            this.tabPageWDiff.Controls.Add(this.btnPlot);
            this.tabPageWDiff.Controls.Add(this.txtBoxAlpha);
            this.tabPageWDiff.Controls.Add(this.trBarT);
            this.tabPageWDiff.Controls.Add(this.lblGamma);
            this.tabPageWDiff.Controls.Add(this.prBarSolve);
            this.tabPageWDiff.Controls.Add(this.lblAlpha);
            this.tabPageWDiff.Controls.Add(this.rdBtnTmr);
            this.tabPageWDiff.Controls.Add(this.panelEqType);
            this.tabPageWDiff.Controls.Add(this.btnStopTimer);
            this.tabPageWDiff.Controls.Add(this.btnLoad);
            this.tabPageWDiff.Controls.Add(this.txtBoxN);
            this.tabPageWDiff.Controls.Add(this.lblFA);
            this.tabPageWDiff.Controls.Add(this.txtBoxM);
            this.tabPageWDiff.Controls.Add(this.lblT);
            this.tabPageWDiff.Controls.Add(this.txtBoxL);
            this.tabPageWDiff.Controls.Add(this.lblL);
            this.tabPageWDiff.Controls.Add(this.txtBoxT);
            this.tabPageWDiff.Controls.Add(this.lblM);
            this.tabPageWDiff.Controls.Add(this.txtBoxA);
            this.tabPageWDiff.Controls.Add(this.lblN);
            this.tabPageWDiff.Location = new System.Drawing.Point(4, 22);
            this.tabPageWDiff.Name = "tabPageWDiff";
            this.tabPageWDiff.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWDiff.Size = new System.Drawing.Size(1278, 724);
            this.tabPageWDiff.TabIndex = 0;
            this.tabPageWDiff.Text = "With diffusion";
            this.tabPageWDiff.Enter += new System.EventHandler(this.tabPageWDiff_Enter);
            // 
            // txtBoxBeta
            // 
            this.txtBoxBeta.Location = new System.Drawing.Point(106, 298);
            this.txtBoxBeta.Name = "txtBoxBeta";
            this.txtBoxBeta.Size = new System.Drawing.Size(50, 20);
            this.txtBoxBeta.TabIndex = 39;
            this.txtBoxBeta.Text = "0,064";
            this.txtBoxBeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxBeta.TextChanged += new System.EventHandler(this.txtBoxBeta_TextChanged);
            // 
            // lblBeta
            // 
            this.lblBeta.AutoSize = true;
            this.lblBeta.Location = new System.Drawing.Point(91, 301);
            this.lblBeta.Name = "lblBeta";
            this.lblBeta.Size = new System.Drawing.Size(13, 13);
            this.lblBeta.TabIndex = 38;
            this.lblBeta.Text = "β";
            // 
            // txtBoxI
            // 
            this.txtBoxI.Location = new System.Drawing.Point(106, 377);
            this.txtBoxI.Name = "txtBoxI";
            this.txtBoxI.Size = new System.Drawing.Size(50, 20);
            this.txtBoxI.TabIndex = 37;
            this.txtBoxI.Text = "0,0";
            this.txtBoxI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxI.TextChanged += new System.EventHandler(this.txtBoxI_TextChanged);
            // 
            // lblI
            // 
            this.lblI.AutoSize = true;
            this.lblI.Location = new System.Drawing.Point(81, 380);
            this.lblI.Name = "lblI";
            this.lblI.Size = new System.Drawing.Size(24, 13);
            this.lblI.TabIndex = 36;
            this.lblI.Text = "Iext";
            // 
            // lblD
            // 
            this.lblD.AutoSize = true;
            this.lblD.Location = new System.Drawing.Point(90, 353);
            this.lblD.Name = "lblD";
            this.lblD.Size = new System.Drawing.Size(13, 13);
            this.lblD.TabIndex = 35;
            this.lblD.Text = "d";
            // 
            // txtBoxD
            // 
            this.txtBoxD.Location = new System.Drawing.Point(106, 350);
            this.txtBoxD.Name = "txtBoxD";
            this.txtBoxD.Size = new System.Drawing.Size(50, 20);
            this.txtBoxD.TabIndex = 34;
            this.txtBoxD.Text = "0,1";
            this.txtBoxD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxD.TextChanged += new System.EventHandler(this.txtBoxD_TextChanged);
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(90, 327);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(13, 13);
            this.lblB.TabIndex = 19;
            this.lblB.Text = "b";
            // 
            // txtBoxB
            // 
            this.txtBoxB.Location = new System.Drawing.Point(106, 324);
            this.txtBoxB.Name = "txtBoxB";
            this.txtBoxB.Size = new System.Drawing.Size(50, 20);
            this.txtBoxB.TabIndex = 20;
            this.txtBoxB.Text = "0,0";
            this.txtBoxB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxB.TextChanged += new System.EventHandler(this.txtBoxB_TextChanged);
            // 
            // tabPageWODiff
            // 
            this.tabPageWODiff.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageWODiff.Controls.Add(this.label1);
            this.tabPageWODiff.Controls.Add(this.label2);
            this.tabPageWODiff.Controls.Add(this.txtBoxMaxUVTWOD);
            this.tabPageWODiff.Controls.Add(this.txtBoxMinUVPhaseWOD);
            this.tabPageWODiff.Controls.Add(this.txtBoxMinUVTWOD);
            this.tabPageWODiff.Controls.Add(this.txtBoxFAWOD);
            this.tabPageWODiff.Controls.Add(this.btnTuneTWOD);
            this.tabPageWODiff.Controls.Add(this.txtBoxMaxUVPhaseWOD);
            this.tabPageWODiff.Controls.Add(this.chartTWOD);
            this.tabPageWODiff.Controls.Add(this.lblFAWOD);
            this.tabPageWODiff.Controls.Add(this.btnTunePhaseWOD);
            this.tabPageWODiff.Controls.Add(this.trBarTWOD);
            this.tabPageWODiff.Controls.Add(this.chartPhaseWOD);
            this.tabPageWODiff.Controls.Add(this.prBarSolveWOD);
            this.tabPageWODiff.Controls.Add(this.lblMinUVWOD);
            this.tabPageWODiff.Controls.Add(this.panel1);
            this.tabPageWODiff.Controls.Add(this.btnStopTimerWOD);
            this.tabPageWODiff.Controls.Add(this.lblMaxUVWOD);
            this.tabPageWODiff.Controls.Add(this.btnPlotWOD);
            this.tabPageWODiff.Controls.Add(this.btnSolveWOD);
            this.tabPageWODiff.Controls.Add(this.btnLoadWOD);
            this.tabPageWODiff.Controls.Add(this.panelNonLinTypeWOD);
            this.tabPageWODiff.Controls.Add(this.txtBoxBetaWOD);
            this.tabPageWODiff.Controls.Add(this.txtBoxAlphaWOD);
            this.tabPageWODiff.Controls.Add(this.txtBoxTauWOD);
            this.tabPageWODiff.Controls.Add(this.txtBoxIWOD);
            this.tabPageWODiff.Controls.Add(this.txtBoxV0WOD);
            this.tabPageWODiff.Controls.Add(this.txtBoxU0WOD);
            this.tabPageWODiff.Controls.Add(this.txtBoxTWOD);
            this.tabPageWODiff.Controls.Add(this.txtBoxLWOD);
            this.tabPageWODiff.Controls.Add(this.txtBoxNWOD);
            this.tabPageWODiff.Controls.Add(this.lblBetaWOD);
            this.tabPageWODiff.Controls.Add(this.lblAlphaWOD);
            this.tabPageWODiff.Controls.Add(this.lblTauWOD);
            this.tabPageWODiff.Controls.Add(this.lblIWOD);
            this.tabPageWODiff.Controls.Add(this.lblV0WOD);
            this.tabPageWODiff.Controls.Add(this.lblU0WOD);
            this.tabPageWODiff.Controls.Add(this.lblTWOD);
            this.tabPageWODiff.Controls.Add(this.lblLWOD);
            this.tabPageWODiff.Controls.Add(this.lblNWOD);
            this.tabPageWODiff.Location = new System.Drawing.Point(4, 22);
            this.tabPageWODiff.Name = "tabPageWODiff";
            this.tabPageWODiff.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWODiff.Size = new System.Drawing.Size(1278, 795);
            this.tabPageWODiff.TabIndex = 1;
            this.tabPageWODiff.Text = "Without diffusion";
            this.tabPageWODiff.Enter += new System.EventHandler(this.tabPageWODiff_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 594);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "min u,v";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 357);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "max u,v";
            // 
            // txtBoxMaxUVTWOD
            // 
            this.txtBoxMaxUVTWOD.Location = new System.Drawing.Point(241, 17);
            this.txtBoxMaxUVTWOD.Name = "txtBoxMaxUVTWOD";
            this.txtBoxMaxUVTWOD.Size = new System.Drawing.Size(34, 20);
            this.txtBoxMaxUVTWOD.TabIndex = 40;
            this.txtBoxMaxUVTWOD.Text = "2,0";
            this.txtBoxMaxUVTWOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxMinUVPhaseWOD
            // 
            this.txtBoxMinUVPhaseWOD.Location = new System.Drawing.Point(241, 589);
            this.txtBoxMinUVPhaseWOD.Name = "txtBoxMinUVPhaseWOD";
            this.txtBoxMinUVPhaseWOD.Size = new System.Drawing.Size(34, 20);
            this.txtBoxMinUVPhaseWOD.TabIndex = 41;
            this.txtBoxMinUVPhaseWOD.Text = "-1,0";
            this.txtBoxMinUVPhaseWOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxMinUVTWOD
            // 
            this.txtBoxMinUVTWOD.Location = new System.Drawing.Point(241, 268);
            this.txtBoxMinUVTWOD.Name = "txtBoxMinUVTWOD";
            this.txtBoxMinUVTWOD.Size = new System.Drawing.Size(34, 20);
            this.txtBoxMinUVTWOD.TabIndex = 41;
            this.txtBoxMinUVTWOD.Text = "-2,1";
            this.txtBoxMinUVTWOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxFAWOD
            // 
            this.txtBoxFAWOD.Location = new System.Drawing.Point(106, 376);
            this.txtBoxFAWOD.Name = "txtBoxFAWOD";
            this.txtBoxFAWOD.Size = new System.Drawing.Size(50, 20);
            this.txtBoxFAWOD.TabIndex = 41;
            this.txtBoxFAWOD.Text = "0,1";
            this.txtBoxFAWOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxFAWOD.Visible = false;
            this.txtBoxFAWOD.TextChanged += new System.EventHandler(this.txtBoxFAWOD_TextChanged);
            // 
            // btnTuneTWOD
            // 
            this.btnTuneTWOD.Location = new System.Drawing.Point(241, 144);
            this.btnTuneTWOD.Name = "btnTuneTWOD";
            this.btnTuneTWOD.Size = new System.Drawing.Size(42, 23);
            this.btnTuneTWOD.TabIndex = 37;
            this.btnTuneTWOD.Text = "Zoom";
            this.btnTuneTWOD.UseVisualStyleBackColor = true;
            this.btnTuneTWOD.Click += new System.EventHandler(this.btnTuneTWOD_Click);
            // 
            // txtBoxMaxUVPhaseWOD
            // 
            this.txtBoxMaxUVPhaseWOD.Location = new System.Drawing.Point(241, 354);
            this.txtBoxMaxUVPhaseWOD.Name = "txtBoxMaxUVPhaseWOD";
            this.txtBoxMaxUVPhaseWOD.Size = new System.Drawing.Size(34, 20);
            this.txtBoxMaxUVPhaseWOD.TabIndex = 40;
            this.txtBoxMaxUVPhaseWOD.Text = "2,0";
            this.txtBoxMaxUVPhaseWOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chartTWOD
            // 
            chartArea5.Name = "ChartArea1";
            this.chartTWOD.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartTWOD.Legends.Add(legend5);
            this.chartTWOD.Location = new System.Drawing.Point(241, 0);
            this.chartTWOD.Name = "chartTWOD";
            series10.BorderWidth = 3;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Legend = "Legend1";
            series10.Name = "U";
            series11.BorderWidth = 3;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series11.Legend = "Legend1";
            series11.Name = "V";
            this.chartTWOD.Series.Add(series10);
            this.chartTWOD.Series.Add(series11);
            this.chartTWOD.Size = new System.Drawing.Size(1030, 325);
            this.chartTWOD.TabIndex = 37;
            this.chartTWOD.Text = "chart1";
            // 
            // lblFAWOD
            // 
            this.lblFAWOD.AutoSize = true;
            this.lblFAWOD.Location = new System.Drawing.Point(90, 379);
            this.lblFAWOD.Name = "lblFAWOD";
            this.lblFAWOD.Size = new System.Drawing.Size(13, 13);
            this.lblFAWOD.TabIndex = 40;
            this.lblFAWOD.Text = "a";
            this.lblFAWOD.Visible = false;
            // 
            // btnTunePhaseWOD
            // 
            this.btnTunePhaseWOD.Location = new System.Drawing.Point(241, 481);
            this.btnTunePhaseWOD.Name = "btnTunePhaseWOD";
            this.btnTunePhaseWOD.Size = new System.Drawing.Size(42, 23);
            this.btnTunePhaseWOD.TabIndex = 39;
            this.btnTunePhaseWOD.Text = "Zoom";
            this.btnTunePhaseWOD.UseVisualStyleBackColor = true;
            this.btnTunePhaseWOD.Click += new System.EventHandler(this.btnTunePhaseWOD_Click);
            // 
            // trBarTWOD
            // 
            this.trBarTWOD.Location = new System.Drawing.Point(322, 650);
            this.trBarTWOD.Name = "trBarTWOD";
            this.trBarTWOD.Size = new System.Drawing.Size(788, 45);
            this.trBarTWOD.TabIndex = 36;
            this.trBarTWOD.Scroll += new System.EventHandler(this.trBarTWOD_Scroll);
            // 
            // chartPhaseWOD
            // 
            chartArea6.Name = "ChartArea1";
            this.chartPhaseWOD.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartPhaseWOD.Legends.Add(legend6);
            this.chartPhaseWOD.Location = new System.Drawing.Point(241, 325);
            this.chartPhaseWOD.Name = "chartPhaseWOD";
            series12.BorderWidth = 5;
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.Legend = "Legend1";
            series12.Name = "V(U)";
            series13.BorderWidth = 3;
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series13.Legend = "Legend1";
            series13.Name = "1 nс V(U)";
            series14.BorderWidth = 3;
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series14.Legend = "Legend1";
            series14.Name = "2 nc V(U)";
            this.chartPhaseWOD.Series.Add(series12);
            this.chartPhaseWOD.Series.Add(series13);
            this.chartPhaseWOD.Series.Add(series14);
            this.chartPhaseWOD.Size = new System.Drawing.Size(1030, 325);
            this.chartPhaseWOD.TabIndex = 38;
            this.chartPhaseWOD.Text = "chart2";
            // 
            // prBarSolveWOD
            // 
            this.prBarSolveWOD.Location = new System.Drawing.Point(25, 653);
            this.prBarSolveWOD.Maximum = 4;
            this.prBarSolveWOD.Name = "prBarSolveWOD";
            this.prBarSolveWOD.Size = new System.Drawing.Size(156, 23);
            this.prBarSolveWOD.TabIndex = 2;
            // 
            // lblMinUVWOD
            // 
            this.lblMinUVWOD.AutoSize = true;
            this.lblMinUVWOD.Location = new System.Drawing.Point(200, 271);
            this.lblMinUVWOD.Name = "lblMinUVWOD";
            this.lblMinUVWOD.Size = new System.Drawing.Size(41, 13);
            this.lblMinUVWOD.TabIndex = 39;
            this.lblMinUVWOD.Text = "min u,v";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdBtnPlotAllWOD);
            this.panel1.Controls.Add(this.rdBtnTmrWOD);
            this.panel1.Location = new System.Drawing.Point(109, 571);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(80, 47);
            this.panel1.TabIndex = 23;
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
            // btnStopTimerWOD
            // 
            this.btnStopTimerWOD.Location = new System.Drawing.Point(106, 624);
            this.btnStopTimerWOD.Name = "btnStopTimerWOD";
            this.btnStopTimerWOD.Size = new System.Drawing.Size(75, 23);
            this.btnStopTimerWOD.TabIndex = 22;
            this.btnStopTimerWOD.Text = "Stop Timer";
            this.btnStopTimerWOD.UseVisualStyleBackColor = true;
            this.btnStopTimerWOD.Click += new System.EventHandler(this.btnStopTimerWOD_Click);
            // 
            // lblMaxUVWOD
            // 
            this.lblMaxUVWOD.AutoSize = true;
            this.lblMaxUVWOD.Location = new System.Drawing.Point(197, 20);
            this.lblMaxUVWOD.Name = "lblMaxUVWOD";
            this.lblMaxUVWOD.Size = new System.Drawing.Size(44, 13);
            this.lblMaxUVWOD.TabIndex = 38;
            this.lblMaxUVWOD.Text = "max u,v";
            // 
            // btnPlotWOD
            // 
            this.btnPlotWOD.Enabled = false;
            this.btnPlotWOD.Location = new System.Drawing.Point(25, 600);
            this.btnPlotWOD.Name = "btnPlotWOD";
            this.btnPlotWOD.Size = new System.Drawing.Size(75, 23);
            this.btnPlotWOD.TabIndex = 21;
            this.btnPlotWOD.Text = "Plot";
            this.btnPlotWOD.UseVisualStyleBackColor = true;
            this.btnPlotWOD.Click += new System.EventHandler(this.btnPlotWOD_Click);
            // 
            // btnSolveWOD
            // 
            this.btnSolveWOD.Location = new System.Drawing.Point(25, 571);
            this.btnSolveWOD.Name = "btnSolveWOD";
            this.btnSolveWOD.Size = new System.Drawing.Size(75, 23);
            this.btnSolveWOD.TabIndex = 20;
            this.btnSolveWOD.Text = "Solve";
            this.btnSolveWOD.UseVisualStyleBackColor = true;
            this.btnSolveWOD.Click += new System.EventHandler(this.btnSolveWOD_Click);
            // 
            // btnLoadWOD
            // 
            this.btnLoadWOD.Location = new System.Drawing.Point(25, 542);
            this.btnLoadWOD.Name = "btnLoadWOD";
            this.btnLoadWOD.Size = new System.Drawing.Size(75, 23);
            this.btnLoadWOD.TabIndex = 19;
            this.btnLoadWOD.Text = "Load";
            this.btnLoadWOD.UseVisualStyleBackColor = true;
            this.btnLoadWOD.Click += new System.EventHandler(this.btnLoadWOD_Click);
            // 
            // panelNonLinTypeWOD
            // 
            this.panelNonLinTypeWOD.Controls.Add(this.rdBtnNLWOD);
            this.panelNonLinTypeWOD.Controls.Add(this.rdBtnClassicalNLWOD);
            this.panelNonLinTypeWOD.Location = new System.Drawing.Point(12, 376);
            this.panelNonLinTypeWOD.Name = "panelNonLinTypeWOD";
            this.panelNonLinTypeWOD.Size = new System.Drawing.Size(80, 47);
            this.panelNonLinTypeWOD.TabIndex = 18;
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
            this.rdBtnNLWOD.CheckedChanged += new System.EventHandler(this.rdBtnNLWOD_CheckedChanged);
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
            this.rdBtnClassicalNLWOD.CheckedChanged += new System.EventHandler(this.rdBtnClassicalNLWOD_CheckedChanged);
            // 
            // txtBoxBetaWOD
            // 
            this.txtBoxBetaWOD.Location = new System.Drawing.Point(106, 350);
            this.txtBoxBetaWOD.Name = "txtBoxBetaWOD";
            this.txtBoxBetaWOD.Size = new System.Drawing.Size(50, 20);
            this.txtBoxBetaWOD.TabIndex = 17;
            this.txtBoxBetaWOD.Text = "0,8";
            this.txtBoxBetaWOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxBetaWOD.TextChanged += new System.EventHandler(this.txtBoxBetaWOD_TextChanged);
            // 
            // txtBoxAlphaWOD
            // 
            this.txtBoxAlphaWOD.Location = new System.Drawing.Point(25, 350);
            this.txtBoxAlphaWOD.Name = "txtBoxAlphaWOD";
            this.txtBoxAlphaWOD.Size = new System.Drawing.Size(50, 20);
            this.txtBoxAlphaWOD.TabIndex = 16;
            this.txtBoxAlphaWOD.Text = "0,7";
            this.txtBoxAlphaWOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxAlphaWOD.TextChanged += new System.EventHandler(this.txtBoxAlphaWOD_TextChanged);
            // 
            // txtBoxTauWOD
            // 
            this.txtBoxTauWOD.Location = new System.Drawing.Point(106, 324);
            this.txtBoxTauWOD.Name = "txtBoxTauWOD";
            this.txtBoxTauWOD.Size = new System.Drawing.Size(50, 20);
            this.txtBoxTauWOD.TabIndex = 15;
            this.txtBoxTauWOD.Text = "12,5";
            this.txtBoxTauWOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxTauWOD.TextChanged += new System.EventHandler(this.txtBoxTauWOD_TextChanged);
            // 
            // txtBoxIWOD
            // 
            this.txtBoxIWOD.Location = new System.Drawing.Point(25, 324);
            this.txtBoxIWOD.Name = "txtBoxIWOD";
            this.txtBoxIWOD.Size = new System.Drawing.Size(50, 20);
            this.txtBoxIWOD.TabIndex = 14;
            this.txtBoxIWOD.Text = "0,5";
            this.txtBoxIWOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxIWOD.TextChanged += new System.EventHandler(this.txtBoxIWOD_TextChanged);
            // 
            // txtBoxV0WOD
            // 
            this.txtBoxV0WOD.Location = new System.Drawing.Point(106, 298);
            this.txtBoxV0WOD.Name = "txtBoxV0WOD";
            this.txtBoxV0WOD.Size = new System.Drawing.Size(50, 20);
            this.txtBoxV0WOD.TabIndex = 13;
            this.txtBoxV0WOD.Text = "0,1";
            this.txtBoxV0WOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxV0WOD.TextChanged += new System.EventHandler(this.txtBoxV0WOD_TextChanged);
            // 
            // txtBoxU0WOD
            // 
            this.txtBoxU0WOD.Location = new System.Drawing.Point(25, 298);
            this.txtBoxU0WOD.Name = "txtBoxU0WOD";
            this.txtBoxU0WOD.Size = new System.Drawing.Size(50, 20);
            this.txtBoxU0WOD.TabIndex = 12;
            this.txtBoxU0WOD.Text = "1,0";
            this.txtBoxU0WOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxU0WOD.TextChanged += new System.EventHandler(this.txtBoxU0WOD_TextChanged);
            // 
            // txtBoxTWOD
            // 
            this.txtBoxTWOD.Location = new System.Drawing.Point(106, 272);
            this.txtBoxTWOD.Name = "txtBoxTWOD";
            this.txtBoxTWOD.Size = new System.Drawing.Size(50, 20);
            this.txtBoxTWOD.TabIndex = 11;
            this.txtBoxTWOD.Text = "100,0";
            this.txtBoxTWOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxTWOD.TextChanged += new System.EventHandler(this.txtBoxTWOD_TextChanged);
            // 
            // txtBoxLWOD
            // 
            this.txtBoxLWOD.Location = new System.Drawing.Point(25, 272);
            this.txtBoxLWOD.Name = "txtBoxLWOD";
            this.txtBoxLWOD.Size = new System.Drawing.Size(50, 20);
            this.txtBoxLWOD.TabIndex = 10;
            this.txtBoxLWOD.Text = "2,5";
            this.txtBoxLWOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxLWOD.Visible = false;
            this.txtBoxLWOD.TextChanged += new System.EventHandler(this.txtBoxLWOD_TextChanged);
            // 
            // txtBoxNWOD
            // 
            this.txtBoxNWOD.Location = new System.Drawing.Point(25, 246);
            this.txtBoxNWOD.Name = "txtBoxNWOD";
            this.txtBoxNWOD.Size = new System.Drawing.Size(50, 20);
            this.txtBoxNWOD.TabIndex = 9;
            this.txtBoxNWOD.Text = "1000";
            this.txtBoxNWOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxNWOD.TextChanged += new System.EventHandler(this.txtBoxNWOD_TextChanged);
            // 
            // lblBetaWOD
            // 
            this.lblBetaWOD.AutoSize = true;
            this.lblBetaWOD.Location = new System.Drawing.Point(89, 353);
            this.lblBetaWOD.Name = "lblBetaWOD";
            this.lblBetaWOD.Size = new System.Drawing.Size(13, 13);
            this.lblBetaWOD.TabIndex = 8;
            this.lblBetaWOD.Text = "β";
            // 
            // lblAlphaWOD
            // 
            this.lblAlphaWOD.AutoSize = true;
            this.lblAlphaWOD.Location = new System.Drawing.Point(9, 353);
            this.lblAlphaWOD.Name = "lblAlphaWOD";
            this.lblAlphaWOD.Size = new System.Drawing.Size(14, 13);
            this.lblAlphaWOD.TabIndex = 7;
            this.lblAlphaWOD.Text = "α";
            // 
            // lblTauWOD
            // 
            this.lblTauWOD.AutoSize = true;
            this.lblTauWOD.Location = new System.Drawing.Point(89, 327);
            this.lblTauWOD.Name = "lblTauWOD";
            this.lblTauWOD.Size = new System.Drawing.Size(13, 13);
            this.lblTauWOD.TabIndex = 6;
            this.lblTauWOD.Text = "τ";
            // 
            // lblIWOD
            // 
            this.lblIWOD.AutoSize = true;
            this.lblIWOD.Location = new System.Drawing.Point(2, 327);
            this.lblIWOD.Name = "lblIWOD";
            this.lblIWOD.Size = new System.Drawing.Size(24, 13);
            this.lblIWOD.TabIndex = 5;
            this.lblIWOD.Text = "Iext";
            // 
            // lblV0WOD
            // 
            this.lblV0WOD.AutoSize = true;
            this.lblV0WOD.Location = new System.Drawing.Point(84, 301);
            this.lblV0WOD.Name = "lblV0WOD";
            this.lblV0WOD.Size = new System.Drawing.Size(19, 13);
            this.lblV0WOD.TabIndex = 4;
            this.lblV0WOD.Text = "v0";
            // 
            // lblU0WOD
            // 
            this.lblU0WOD.AutoSize = true;
            this.lblU0WOD.Location = new System.Drawing.Point(5, 301);
            this.lblU0WOD.Name = "lblU0WOD";
            this.lblU0WOD.Size = new System.Drawing.Size(19, 13);
            this.lblU0WOD.TabIndex = 3;
            this.lblU0WOD.Text = "u0";
            // 
            // lblTWOD
            // 
            this.lblTWOD.AutoSize = true;
            this.lblTWOD.Location = new System.Drawing.Point(89, 275);
            this.lblTWOD.Name = "lblTWOD";
            this.lblTWOD.Size = new System.Drawing.Size(14, 13);
            this.lblTWOD.TabIndex = 2;
            this.lblTWOD.Text = "T";
            // 
            // lblLWOD
            // 
            this.lblLWOD.AutoSize = true;
            this.lblLWOD.Location = new System.Drawing.Point(13, 275);
            this.lblLWOD.Name = "lblLWOD";
            this.lblLWOD.Size = new System.Drawing.Size(9, 13);
            this.lblLWOD.TabIndex = 1;
            this.lblLWOD.Text = "l";
            this.lblLWOD.Visible = false;
            // 
            // lblNWOD
            // 
            this.lblNWOD.AutoSize = true;
            this.lblNWOD.Location = new System.Drawing.Point(11, 249);
            this.lblNWOD.Name = "lblNWOD";
            this.lblNWOD.Size = new System.Drawing.Size(13, 13);
            this.lblNWOD.TabIndex = 0;
            this.lblNWOD.Text = "n";
            // 
            // timerTWOD
            // 
            this.timerTWOD.Tick += new System.EventHandler(this.timerTWOD_Tick);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1284, 711);
            this.Controls.Add(this.tabEq);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "FitzHugh-Nagumo model  with nonlocal coupling";
            ((System.ComponentModel.ISupportInitialize)(this.chartWDiff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarT)).EndInit();
            this.panelEqType.ResumeLayout(false);
            this.panelEqType.PerformLayout();
            this.tabEq.ResumeLayout(false);
            this.tabPageWDiff.ResumeLayout(false);
            this.tabPageWDiff.PerformLayout();
            this.tabPageWODiff.ResumeLayout(false);
            this.tabPageWODiff.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTWOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarTWOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPhaseWOD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelNonLinTypeWOD.ResumeLayout(false);
            this.panelNonLinTypeWOD.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartWDiff;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.Timer timerT;
        private System.Windows.Forms.Button btnStopTimer;
        private System.Windows.Forms.RadioButton rdBtnTmr;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtBoxN;
        private System.Windows.Forms.TextBox txtBoxM;
        private System.Windows.Forms.TextBox txtBoxL;
        private System.Windows.Forms.TextBox txtBoxT;
        private System.Windows.Forms.TextBox txtBoxMinUV;
        private System.Windows.Forms.TextBox txtBoxMaxUV;
        private System.Windows.Forms.RadioButton rdBtnDeltaCoupl;
        private System.Windows.Forms.RadioButton rdBtnCoupl;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.Label lblM;
        private System.Windows.Forms.Label lblL;
        private System.Windows.Forms.Label lblT;
        private System.Windows.Forms.Label lblMaxUV;
        private System.Windows.Forms.Label lblMinUV;
        private System.Windows.Forms.Panel panelEqType;
        private System.Windows.Forms.Label lblAlpha;
        private System.Windows.Forms.Label lblGamma;
        private System.Windows.Forms.TextBox txtBoxAlpha;
        private System.Windows.Forms.TextBox txtBoxGamma;
        private System.Windows.Forms.Button btnTune;
        private System.Windows.Forms.TrackBar trBarT;
        public System.Windows.Forms.ProgressBar prBarSolve;
        private System.Windows.Forms.Label lblFA;
        private System.Windows.Forms.TextBox txtBoxA;
        private System.Windows.Forms.TabControl tabEq;
        private System.Windows.Forms.TabPage tabPageWDiff;
        private System.Windows.Forms.TabPage tabPageWODiff;
        private System.Windows.Forms.Label lblBetaWOD;
        private System.Windows.Forms.Label lblAlphaWOD;
        private System.Windows.Forms.Label lblTauWOD;
        private System.Windows.Forms.Label lblIWOD;
        private System.Windows.Forms.Label lblV0WOD;
        private System.Windows.Forms.Label lblU0WOD;
        private System.Windows.Forms.Label lblTWOD;
        private System.Windows.Forms.Label lblLWOD;
        private System.Windows.Forms.Label lblNWOD;
        private System.Windows.Forms.Panel panelNonLinTypeWOD;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStopTimerWOD;
        private System.Windows.Forms.Button btnPlotWOD;
        private System.Windows.Forms.Button btnSolveWOD;
        private System.Windows.Forms.Button btnLoadWOD;
        public System.Windows.Forms.RadioButton rdBtnNLWOD;
        public System.Windows.Forms.RadioButton rdBtnClassicalNLWOD;
        public System.Windows.Forms.RadioButton rdBtnPlotAllWOD;
        public System.Windows.Forms.RadioButton rdBtnTmrWOD;
        private System.Windows.Forms.TrackBar trBarTWOD;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTWOD;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPhaseWOD;
        private System.Windows.Forms.Timer timerTWOD;
        public System.Windows.Forms.ProgressBar prBarSolveWOD;
        private System.Windows.Forms.TextBox txtBoxMaxUVTWOD;
        private System.Windows.Forms.TextBox txtBoxMinUVTWOD;
        private System.Windows.Forms.Button btnTuneTWOD;
        private System.Windows.Forms.Label lblMinUVWOD;
        private System.Windows.Forms.Label lblMaxUVWOD;
        private System.Windows.Forms.TextBox txtBoxMinUVPhaseWOD;
        private System.Windows.Forms.TextBox txtBoxMaxUVPhaseWOD;
        private System.Windows.Forms.Button btnTunePhaseWOD;
        private System.Windows.Forms.Label lblD;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.TextBox txtBoxB;
        public System.Windows.Forms.TextBox txtBoxD;
        private System.Windows.Forms.Label lblFAWOD;
        private System.Windows.Forms.TextBox txtBoxTWOD;
        private System.Windows.Forms.TextBox txtBoxLWOD;
        private System.Windows.Forms.TextBox txtBoxNWOD;
        private System.Windows.Forms.TextBox txtBoxU0WOD;
        private System.Windows.Forms.TextBox txtBoxV0WOD;
        private System.Windows.Forms.TextBox txtBoxIWOD;
        private System.Windows.Forms.TextBox txtBoxBetaWOD;
        private System.Windows.Forms.TextBox txtBoxAlphaWOD;
        private System.Windows.Forms.TextBox txtBoxTauWOD;
        private System.Windows.Forms.TextBox txtBoxFAWOD;
        private System.Windows.Forms.Label lblI;
        public System.Windows.Forms.TextBox txtBoxI;
        public System.Windows.Forms.TextBox txtBoxBeta;
        private System.Windows.Forms.Label lblBeta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

