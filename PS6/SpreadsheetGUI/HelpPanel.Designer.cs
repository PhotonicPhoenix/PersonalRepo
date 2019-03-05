namespace SpreadsheetGUI
{
    partial class HelpPanel
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
            this.HelpInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HelpInfo
            // 
            this.HelpInfo.Location = new System.Drawing.Point(12, 9);
            this.HelpInfo.Name = "HelpInfo";
            this.HelpInfo.Size = new System.Drawing.Size(421, 307);
            this.HelpInfo.TabIndex = 0;
            this.HelpInfo.Click += new System.EventHandler(this.HelpInfo_Click);
            // 
            // HelpPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 325);
            this.Controls.Add(this.HelpInfo);
            this.Name = "HelpPanel";
            this.Text = "Help";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label HelpInfo;
    }
}