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
            this.checkBoxInitials = new System.Windows.Forms.CheckBox();
            this.txtBoxUX0 = new System.Windows.Forms.TextBox();
            this.txtBoxVX0 = new System.Windows.Forms.TextBox();
            this.lblUX0 = new System.Windows.Forms.Label();
            this.lblVX0 = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.btnGetHeight = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarT)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxContiniousVelocity
            // 
            this.checkBoxContiniousVelocity.AutoSize = true;
            this.checkBoxContiniousVelocity.Checked = true;
            this.checkBoxContiniousVelocity.CheckState = System.Windows.Forms.CheckState.Checked;
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
            this.lblVelocity.Size = new System.Drawing.Size(20, 16);
            this.lblVelocity.TabIndex = 112;
            this.lblVelocity.Text = "---";
            // 
            // btnGetVelocity
            // 
            this.btnGetVelocity.Enabled = false;
            this.btnGetVelocity.Location = new System.Drawing.Point(27, 524);
            this.btnGetVelocity.Name = "btnGetVelocity";
            this.btnGetVelocity.Size = new System.Drawing.Size(75, 21);
            this.btnGetVelocity.TabIndex = 111;
            this.btnGetVelocity.Text = "Get Velocity";
            this.btnGetVelocity.UseVisualStyleBackColor = true;
            this.btnGetVelocity.Click += new System.EventHandler(this.btnGetVelocity_Click);
            // 
            // checkBoxInitials
            // 
            this.checkBoxInitials.AutoSize = true;
            this.checkBoxInitials.Location = new System.Drawing.Point(77, 384);
            this.checkBoxInitials.Name = "checkBoxInitials";
            this.checkBoxInitials.Size = new System.Drawing.Size(92, 17);
            this.checkBoxInitials.TabIndex = 114;
            this.checkBoxInitials.Text = "choose initials";
            this.checkBoxInitials.UseVisualStyleBackColor = true;
            this.checkBoxInitials.CheckedChanged += new System.EventHandler(this.checkBoxInitials_CheckedChanged);
            // 
            // txtBoxUX0
            // 
            this.txtBoxUX0.Enabled = false;
            this.txtBoxUX0.Location = new System.Drawing.Point(52, 407);
            this.txtBoxUX0.Name = "txtBoxUX0";
            this.txtBoxUX0.Size = new System.Drawing.Size(125, 20);
            this.txtBoxUX0.TabIndex = 115;
            this.txtBoxUX0.Validated += new System.EventHandler(this.txtBoxInit_Validated);
            // 
            // txtBoxVX0
            // 
            this.txtBoxVX0.Enabled = false;
            this.txtBoxVX0.Location = new System.Drawing.Point(52, 433);
            this.txtBoxVX0.Name = "txtBoxVX0";
            this.txtBoxVX0.Size = new System.Drawing.Size(125, 20);
            this.txtBoxVX0.TabIndex = 116;
            this.txtBoxVX0.Validated += new System.EventHandler(this.txtBoxInit_Validated);
            // 
            // lblUX0
            // 
            this.lblUX0.AutoSize = true;
            this.lblUX0.Enabled = false;
            this.lblUX0.Location = new System.Drawing.Point(13, 410);
            this.lblUX0.Name = "lblUX0";
            this.lblUX0.Size = new System.Drawing.Size(33, 13);
            this.lblUX0.TabIndex = 117;
            this.lblUX0.Text = "u(x,0)";
            // 
            // lblVX0
            // 
            this.lblVX0.AutoSize = true;
            this.lblVX0.Enabled = false;
            this.lblVX0.Location = new System.Drawing.Point(13, 436);
            this.lblVX0.Name = "lblVX0";
            this.lblVX0.Size = new System.Drawing.Size(33, 13);
            this.lblVX0.TabIndex = 118;
            this.lblVX0.Text = "v(x,0)";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblHeight.Location = new System.Drawing.Point(108, 503);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(20, 16);
            this.lblHeight.TabIndex = 120;
            this.lblHeight.Text = "---";
            // 
            // btnGetHeight
            // 
            this.btnGetHeight.Enabled = false;
            this.btnGetHeight.Location = new System.Drawing.Point(27, 501);
            this.btnGetHeight.Name = "btnGetHeight";
            this.btnGetHeight.Size = new System.Drawing.Size(75, 21);
            this.btnGetHeight.TabIndex = 119;
            this.btnGetHeight.Text = "Get Height";
            this.btnGetHeight.UseVisualStyleBackColor = true;
            this.btnGetHeight.Click += new System.EventHandler(this.btnGetHeight_Click);
            // 
            // WindowPDE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 711);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.btnGetHeight);
            this.Controls.Add(this.lblVX0);
            this.Controls.Add(this.lblUX0);
            this.Controls.Add(this.txtBoxVX0);
            this.Controls.Add(this.txtBoxUX0);
            this.Controls.Add(this.checkBoxInitials);
            this.Controls.Add(this.checkBoxContiniousVelocity);
            this.Controls.Add(this.lblVelocity);
            this.Controls.Add(this.btnGetVelocity);
            this.Name = "WindowPDE";
            this.Text = "Window PDE";
            this.Controls.SetChildIndex(this.btnGetVelocity, 0);
            this.Controls.SetChildIndex(this.lblVelocity, 0);
            this.Controls.SetChildIndex(this.checkBoxContiniousVelocity, 0);
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
            this.Controls.SetChildIndex(this.checkBoxInitials, 0);
            this.Controls.SetChildIndex(this.txtBoxUX0, 0);
            this.Controls.SetChildIndex(this.txtBoxVX0, 0);
            this.Controls.SetChildIndex(this.lblUX0, 0);
            this.Controls.SetChildIndex(this.lblVX0, 0);
            this.Controls.SetChildIndex(this.btnGetHeight, 0);
            this.Controls.SetChildIndex(this.lblHeight, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxContiniousVelocity;
        private System.Windows.Forms.Label lblVelocity;
        private System.Windows.Forms.Button btnGetVelocity;
        private System.Windows.Forms.CheckBox checkBoxInitials;
        private System.Windows.Forms.TextBox txtBoxUX0;
        private System.Windows.Forms.TextBox txtBoxVX0;
        private System.Windows.Forms.Label lblUX0;
        private System.Windows.Forms.Label lblVX0;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Button btnGetHeight;
    }
}