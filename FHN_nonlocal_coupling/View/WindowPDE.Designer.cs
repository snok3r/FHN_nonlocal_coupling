namespace FHN_nonlocal_coupling.View
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
            this.checkBoxContiniousVelocity = new System.Windows.Forms.CheckBox();
            this.lblVelocity = new System.Windows.Forms.Label();
            this.btnGetVelocity = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarT)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAbout
            // 
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // checkBoxContiniousVelocity
            // 
            this.checkBoxContiniousVelocity.AutoSize = true;
            this.checkBoxContiniousVelocity.Location = new System.Drawing.Point(28, 547);
            this.checkBoxContiniousVelocity.Name = "checkBoxContiniousVelocity";
            this.checkBoxContiniousVelocity.Size = new System.Drawing.Size(126, 17);
            this.checkBoxContiniousVelocity.TabIndex = 113;
            this.checkBoxContiniousVelocity.Text = "Measure Continiously";
            this.checkBoxContiniousVelocity.UseVisualStyleBackColor = true;
            // 
            // lblVelocity
            // 
            this.lblVelocity.AutoSize = true;
            this.lblVelocity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVelocity.Location = new System.Drawing.Point(108, 524);
            this.lblVelocity.Name = "lblVelocity";
            this.lblVelocity.Size = new System.Drawing.Size(36, 16);
            this.lblVelocity.TabIndex = 112;
            this.lblVelocity.Text = "--- x/t";
            // 
            // btnGetVelocity
            // 
            this.btnGetVelocity.Enabled = false;
            this.btnGetVelocity.Location = new System.Drawing.Point(27, 519);
            this.btnGetVelocity.Name = "btnGetVelocity";
            this.btnGetVelocity.Size = new System.Drawing.Size(75, 26);
            this.btnGetVelocity.TabIndex = 111;
            this.btnGetVelocity.Text = "Get Velocity";
            this.btnGetVelocity.UseVisualStyleBackColor = true;
            this.btnGetVelocity.Click += new System.EventHandler(this.btnGetVelocity_Click);
            // 
            // WindowPDE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 711);
            this.Controls.Add(this.checkBoxContiniousVelocity);
            this.Controls.Add(this.lblVelocity);
            this.Controls.Add(this.btnGetVelocity);
            this.Name = "WindowPDE";
            this.Text = "Window PDE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WindowPDE_FormClosing);
            this.Load += new System.EventHandler(this.WindowPDE_Load);
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
            this.Controls.SetChildIndex(this.btnGetVelocity, 0);
            this.Controls.SetChildIndex(this.lblVelocity, 0);
            this.Controls.SetChildIndex(this.checkBoxContiniousVelocity, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxContiniousVelocity;
        private System.Windows.Forms.Label lblVelocity;
        private System.Windows.Forms.Button btnGetVelocity;
    }
}