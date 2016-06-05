namespace FHN_nonlocal_coupling.View.Other
{
    partial class Main
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
            this.btnLoadODE = new System.Windows.Forms.Button();
            this.btnLoadPDE = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoadODE
            // 
            this.btnLoadODE.Location = new System.Drawing.Point(12, 12);
            this.btnLoadODE.Name = "btnLoadODE";
            this.btnLoadODE.Size = new System.Drawing.Size(200, 60);
            this.btnLoadODE.TabIndex = 0;
            this.btnLoadODE.Text = "Load ODE";
            this.btnLoadODE.UseVisualStyleBackColor = true;
            this.btnLoadODE.Click += new System.EventHandler(this.btnLoadODE_Click);
            // 
            // btnLoadPDE
            // 
            this.btnLoadPDE.Location = new System.Drawing.Point(222, 12);
            this.btnLoadPDE.Name = "btnLoadPDE";
            this.btnLoadPDE.Size = new System.Drawing.Size(200, 60);
            this.btnLoadPDE.TabIndex = 1;
            this.btnLoadPDE.Text = "Load PDE";
            this.btnLoadPDE.UseVisualStyleBackColor = true;
            this.btnLoadPDE.Click += new System.EventHandler(this.btnLoadPDE_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(434, 81);
            this.Controls.Add(this.btnLoadPDE);
            this.Controls.Add(this.btnLoadODE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FitzHugh-Nagumo model  with nonlocal coupling";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadODE;
        private System.Windows.Forms.Button btnLoadPDE;
    }
}