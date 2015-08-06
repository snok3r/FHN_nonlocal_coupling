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
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnSolve = new System.Windows.Forms.Button();
            this.btnPlot = new System.Windows.Forms.Button();
            this.trBarT = new System.Windows.Forms.TrackBar();
            this.prBarSolve = new System.Windows.Forms.ProgressBar();
            this.timerT = new System.Windows.Forms.Timer(this.components);
            this.rdBtnTmr = new System.Windows.Forms.RadioButton();
            this.btnStopTimer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarT)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(231, 12);
            this.chart1.Name = "chart1";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series7.Legend = "Legend1";
            series7.MarkerSize = 7;
            series7.Name = "U";
            series7.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series7.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series8.Legend = "Legend1";
            series8.MarkerSize = 7;
            series8.Name = "V";
            series8.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series8.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
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
            this.trBarT.Location = new System.Drawing.Point(295, 417);
            this.trBarT.Maximum = 49;
            this.trBarT.Name = "trBarT";
            this.trBarT.Size = new System.Drawing.Size(675, 45);
            this.trBarT.TabIndex = 3;
            this.trBarT.Scroll += new System.EventHandler(this.trBarT_Scroll);
            // 
            // prBarSolve
            // 
            this.prBarSolve.Location = new System.Drawing.Point(25, 423);
            this.prBarSolve.Maximum = 1;
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
            this.rdBtnTmr.Location = new System.Drawing.Point(106, 385);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1006, 467);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.TrackBar trBarT;
        private System.Windows.Forms.ProgressBar prBarSolve;
        private System.Windows.Forms.Timer timerT;
        private System.Windows.Forms.RadioButton rdBtnTmr;
        private System.Windows.Forms.Button btnStopTimer;
    }
}

