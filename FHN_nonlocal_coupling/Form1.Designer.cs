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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
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
            this.rdBtnDiffsn = new System.Windows.Forms.RadioButton();
            this.rdBtnCplng = new System.Windows.Forms.RadioButton();
            this.lblN = new System.Windows.Forms.Label();
            this.lblM = new System.Windows.Forms.Label();
            this.lblL = new System.Windows.Forms.Label();
            this.lblT = new System.Windows.Forms.Label();
            this.lblMaxUV = new System.Windows.Forms.Label();
            this.lblMinUV = new System.Windows.Forms.Label();
            this.panelEqType = new System.Windows.Forms.Panel();
            this.lblEps = new System.Windows.Forms.Label();
            this.lblGamma = new System.Windows.Forms.Label();
            this.txtBoxEps = new System.Windows.Forms.TextBox();
            this.txtBoxGamma = new System.Windows.Forms.TextBox();
            this.btnTune = new System.Windows.Forms.Button();
            this.lblFA = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarT)).BeginInit();
            this.panelEqType.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(277, 12);
            this.chart1.Name = "chart1";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series5.Legend = "Legend1";
            series5.MarkerSize = 7;
            series5.Name = "U";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series5.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series6.Legend = "Legend1";
            series6.MarkerSize = 7;
            series6.Name = "V";
            series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series6.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Size = new System.Drawing.Size(765, 400);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(25, 355);
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
            this.btnPlot.Location = new System.Drawing.Point(25, 384);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(75, 23);
            this.btnPlot.TabIndex = 2;
            this.btnPlot.Text = "Plot";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
            // 
            // trBarT
            // 
            this.trBarT.Location = new System.Drawing.Point(341, 417);
            this.trBarT.Maximum = 49;
            this.trBarT.Name = "trBarT";
            this.trBarT.Size = new System.Drawing.Size(675, 45);
            this.trBarT.TabIndex = 3;
            this.trBarT.Scroll += new System.EventHandler(this.trBarT_Scroll);
            // 
            // prBarSolve
            // 
            this.prBarSolve.Location = new System.Drawing.Point(25, 423);
            this.prBarSolve.Maximum = 4;
            this.prBarSolve.Name = "prBarSolve";
            this.prBarSolve.Size = new System.Drawing.Size(75, 23);
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
            this.rdBtnTmr.Location = new System.Drawing.Point(109, 385);
            this.rdBtnTmr.Name = "rdBtnTmr";
            this.rdBtnTmr.Size = new System.Drawing.Size(76, 17);
            this.rdBtnTmr.TabIndex = 5;
            this.rdBtnTmr.TabStop = true;
            this.rdBtnTmr.Text = "With Timer";
            this.rdBtnTmr.UseVisualStyleBackColor = true;
            // 
            // btnStopTimer
            // 
            this.btnStopTimer.Location = new System.Drawing.Point(106, 408);
            this.btnStopTimer.Name = "btnStopTimer";
            this.btnStopTimer.Size = new System.Drawing.Size(75, 23);
            this.btnStopTimer.TabIndex = 6;
            this.btnStopTimer.Text = "Stop Timer";
            this.btnStopTimer.UseVisualStyleBackColor = true;
            this.btnStopTimer.Click += new System.EventHandler(this.btnStopTimer_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(25, 326);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtBoxN
            // 
            this.txtBoxN.Location = new System.Drawing.Point(25, 21);
            this.txtBoxN.Name = "txtBoxN";
            this.txtBoxN.Size = new System.Drawing.Size(50, 20);
            this.txtBoxN.TabIndex = 8;
            this.txtBoxN.Text = "100";
            this.txtBoxN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxN.TextChanged += new System.EventHandler(this.txtBoxN_TextChanged);
            // 
            // txtBoxM
            // 
            this.txtBoxM.Enabled = false;
            this.txtBoxM.Location = new System.Drawing.Point(106, 21);
            this.txtBoxM.Name = "txtBoxM";
            this.txtBoxM.Size = new System.Drawing.Size(50, 20);
            this.txtBoxM.TabIndex = 9;
            this.txtBoxM.Text = "20001";
            this.txtBoxM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxM.TextChanged += new System.EventHandler(this.txtBoxM_TextChanged);
            // 
            // txtBoxL
            // 
            this.txtBoxL.Location = new System.Drawing.Point(25, 47);
            this.txtBoxL.Name = "txtBoxL";
            this.txtBoxL.Size = new System.Drawing.Size(50, 20);
            this.txtBoxL.TabIndex = 10;
            this.txtBoxL.Text = "3,0";
            this.txtBoxL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxL.TextChanged += new System.EventHandler(this.txtBoxL_TextChanged);
            // 
            // txtBoxT
            // 
            this.txtBoxT.Location = new System.Drawing.Point(106, 47);
            this.txtBoxT.Name = "txtBoxT";
            this.txtBoxT.Size = new System.Drawing.Size(50, 20);
            this.txtBoxT.TabIndex = 11;
            this.txtBoxT.Text = "20,0";
            this.txtBoxT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxT.TextChanged += new System.EventHandler(this.txtBoxT_TextChanged);
            // 
            // txtBoxA
            // 
            this.txtBoxA.Location = new System.Drawing.Point(25, 99);
            this.txtBoxA.Name = "txtBoxA";
            this.txtBoxA.Size = new System.Drawing.Size(50, 20);
            this.txtBoxA.TabIndex = 14;
            this.txtBoxA.Text = "0,5";
            this.txtBoxA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxA.TextChanged += new System.EventHandler(this.txtBoxA_TextChanged);
            // 
            // txtBoxMinUV
            // 
            this.txtBoxMinUV.Location = new System.Drawing.Point(277, 340);
            this.txtBoxMinUV.Name = "txtBoxMinUV";
            this.txtBoxMinUV.Size = new System.Drawing.Size(34, 20);
            this.txtBoxMinUV.TabIndex = 15;
            this.txtBoxMinUV.Text = "-12,0";
            this.txtBoxMinUV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxMaxUV
            // 
            this.txtBoxMaxUV.Location = new System.Drawing.Point(277, 32);
            this.txtBoxMaxUV.Name = "txtBoxMaxUV";
            this.txtBoxMaxUV.Size = new System.Drawing.Size(34, 20);
            this.txtBoxMaxUV.TabIndex = 16;
            this.txtBoxMaxUV.Text = "12,0";
            this.txtBoxMaxUV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rdBtnDiffsn
            // 
            this.rdBtnDiffsn.AutoSize = true;
            this.rdBtnDiffsn.Checked = true;
            this.rdBtnDiffsn.Location = new System.Drawing.Point(3, 3);
            this.rdBtnDiffsn.Name = "rdBtnDiffsn";
            this.rdBtnDiffsn.Size = new System.Drawing.Size(66, 17);
            this.rdBtnDiffsn.TabIndex = 17;
            this.rdBtnDiffsn.TabStop = true;
            this.rdBtnDiffsn.Text = "Diffusion";
            this.rdBtnDiffsn.UseVisualStyleBackColor = true;
            this.rdBtnDiffsn.CheckedChanged += new System.EventHandler(this.rdBtnDiffsn_CheckedChanged);
            // 
            // rdBtnCplng
            // 
            this.rdBtnCplng.AutoSize = true;
            this.rdBtnCplng.Location = new System.Drawing.Point(3, 26);
            this.rdBtnCplng.Name = "rdBtnCplng";
            this.rdBtnCplng.Size = new System.Drawing.Size(66, 17);
            this.rdBtnCplng.TabIndex = 18;
            this.rdBtnCplng.Text = "Coupling";
            this.rdBtnCplng.UseVisualStyleBackColor = true;
            this.rdBtnCplng.CheckedChanged += new System.EventHandler(this.rdBtnCplng_CheckedChanged);
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Location = new System.Drawing.Point(11, 24);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(13, 13);
            this.lblN.TabIndex = 19;
            this.lblN.Text = "n";
            // 
            // lblM
            // 
            this.lblM.AutoSize = true;
            this.lblM.Location = new System.Drawing.Point(88, 24);
            this.lblM.Name = "lblM";
            this.lblM.Size = new System.Drawing.Size(15, 13);
            this.lblM.TabIndex = 20;
            this.lblM.Text = "m";
            // 
            // lblL
            // 
            this.lblL.AutoSize = true;
            this.lblL.Location = new System.Drawing.Point(13, 50);
            this.lblL.Name = "lblL";
            this.lblL.Size = new System.Drawing.Size(9, 13);
            this.lblL.TabIndex = 21;
            this.lblL.Text = "l";
            // 
            // lblT
            // 
            this.lblT.AutoSize = true;
            this.lblT.Location = new System.Drawing.Point(89, 50);
            this.lblT.Name = "lblT";
            this.lblT.Size = new System.Drawing.Size(14, 13);
            this.lblT.TabIndex = 22;
            this.lblT.Text = "T";
            // 
            // lblMaxUV
            // 
            this.lblMaxUV.AutoSize = true;
            this.lblMaxUV.Location = new System.Drawing.Point(233, 35);
            this.lblMaxUV.Name = "lblMaxUV";
            this.lblMaxUV.Size = new System.Drawing.Size(44, 13);
            this.lblMaxUV.TabIndex = 26;
            this.lblMaxUV.Text = "max u,v";
            // 
            // lblMinUV
            // 
            this.lblMinUV.AutoSize = true;
            this.lblMinUV.Location = new System.Drawing.Point(236, 343);
            this.lblMinUV.Name = "lblMinUV";
            this.lblMinUV.Size = new System.Drawing.Size(41, 13);
            this.lblMinUV.TabIndex = 27;
            this.lblMinUV.Text = "min u,v";
            // 
            // panelEqType
            // 
            this.panelEqType.Controls.Add(this.rdBtnDiffsn);
            this.panelEqType.Controls.Add(this.rdBtnCplng);
            this.panelEqType.Location = new System.Drawing.Point(106, 326);
            this.panelEqType.Name = "panelEqType";
            this.panelEqType.Size = new System.Drawing.Size(78, 47);
            this.panelEqType.TabIndex = 28;
            // 
            // lblEps
            // 
            this.lblEps.AutoSize = true;
            this.lblEps.Location = new System.Drawing.Point(9, 76);
            this.lblEps.Name = "lblEps";
            this.lblEps.Size = new System.Drawing.Size(13, 13);
            this.lblEps.TabIndex = 29;
            this.lblEps.Text = "ε";
            // 
            // lblGamma
            // 
            this.lblGamma.AutoSize = true;
            this.lblGamma.Location = new System.Drawing.Point(90, 76);
            this.lblGamma.Name = "lblGamma";
            this.lblGamma.Size = new System.Drawing.Size(13, 13);
            this.lblGamma.TabIndex = 30;
            this.lblGamma.Text = "γ";
            // 
            // txtBoxEps
            // 
            this.txtBoxEps.Location = new System.Drawing.Point(25, 73);
            this.txtBoxEps.Name = "txtBoxEps";
            this.txtBoxEps.Size = new System.Drawing.Size(50, 20);
            this.txtBoxEps.TabIndex = 31;
            this.txtBoxEps.Text = "0,08";
            this.txtBoxEps.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxEps.TextChanged += new System.EventHandler(this.txtBoxEps_TextChanged);
            // 
            // txtBoxGamma
            // 
            this.txtBoxGamma.Location = new System.Drawing.Point(106, 73);
            this.txtBoxGamma.Name = "txtBoxGamma";
            this.txtBoxGamma.Size = new System.Drawing.Size(50, 20);
            this.txtBoxGamma.TabIndex = 32;
            this.txtBoxGamma.Text = "0,8";
            this.txtBoxGamma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxGamma.TextChanged += new System.EventHandler(this.txtBoxGamma_TextChanged);
            // 
            // btnTune
            // 
            this.btnTune.Location = new System.Drawing.Point(277, 186);
            this.btnTune.Name = "btnTune";
            this.btnTune.Size = new System.Drawing.Size(42, 23);
            this.btnTune.TabIndex = 33;
            this.btnTune.Text = "Tune";
            this.btnTune.UseVisualStyleBackColor = true;
            this.btnTune.Click += new System.EventHandler(this.btnTune_Click);
            // 
            // lblFA
            // 
            this.lblFA.AutoSize = true;
            this.lblFA.Location = new System.Drawing.Point(9, 102);
            this.lblFA.Name = "lblFA";
            this.lblFA.Size = new System.Drawing.Size(13, 13);
            this.lblFA.TabIndex = 25;
            this.lblFA.Text = "a";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1054, 467);
            this.Controls.Add(this.btnTune);
            this.Controls.Add(this.txtBoxGamma);
            this.Controls.Add(this.txtBoxEps);
            this.Controls.Add(this.lblGamma);
            this.Controls.Add(this.lblEps);
            this.Controls.Add(this.panelEqType);
            this.Controls.Add(this.lblMinUV);
            this.Controls.Add(this.lblMaxUV);
            this.Controls.Add(this.lblFA);
            this.Controls.Add(this.lblT);
            this.Controls.Add(this.lblL);
            this.Controls.Add(this.lblM);
            this.Controls.Add(this.lblN);
            this.Controls.Add(this.txtBoxMaxUV);
            this.Controls.Add(this.txtBoxMinUV);
            this.Controls.Add(this.txtBoxA);
            this.Controls.Add(this.txtBoxT);
            this.Controls.Add(this.txtBoxL);
            this.Controls.Add(this.txtBoxM);
            this.Controls.Add(this.txtBoxN);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnStopTimer);
            this.Controls.Add(this.rdBtnTmr);
            this.Controls.Add(this.prBarSolve);
            this.Controls.Add(this.trBarT);
            this.Controls.Add(this.btnPlot);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.chart1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "FitzHugh-Nagumo model  with nonlocal coupling";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarT)).EndInit();
            this.panelEqType.ResumeLayout(false);
            this.panelEqType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
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
        private System.Windows.Forms.RadioButton rdBtnDiffsn;
        private System.Windows.Forms.RadioButton rdBtnCplng;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.Label lblM;
        private System.Windows.Forms.Label lblL;
        private System.Windows.Forms.Label lblT;
        private System.Windows.Forms.Label lblMaxUV;
        private System.Windows.Forms.Label lblMinUV;
        private System.Windows.Forms.Panel panelEqType;
        private System.Windows.Forms.Label lblEps;
        private System.Windows.Forms.Label lblGamma;
        private System.Windows.Forms.TextBox txtBoxEps;
        private System.Windows.Forms.TextBox txtBoxGamma;
        private System.Windows.Forms.Button btnTune;
        private System.Windows.Forms.TrackBar trBarT;
        public System.Windows.Forms.ProgressBar prBarSolve;
        private System.Windows.Forms.Label lblFA;
        private System.Windows.Forms.TextBox txtBoxA;
    }
}

