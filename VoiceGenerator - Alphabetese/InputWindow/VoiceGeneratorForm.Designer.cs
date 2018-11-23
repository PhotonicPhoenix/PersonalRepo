namespace InputWindow
{
    partial class VoiceGeneratorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoiceGeneratorForm));
            this.TextBoxImage = new System.Windows.Forms.PictureBox();
            this.PhraseInput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBoxImage
            // 
            this.TextBoxImage.Image = ((System.Drawing.Image)(resources.GetObject("TextBoxImage.Image")));
            this.TextBoxImage.Location = new System.Drawing.Point(3, 1);
            this.TextBoxImage.Name = "TextBoxImage";
            this.TextBoxImage.Size = new System.Drawing.Size(1334, 705);
            this.TextBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TextBoxImage.TabIndex = 0;
            this.TextBoxImage.TabStop = false;
            // 
            // PhraseInput
            // 
            this.PhraseInput.Font = new System.Drawing.Font("Californian FB", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhraseInput.Location = new System.Drawing.Point(142, 35);
            this.PhraseInput.Multiline = true;
            this.PhraseInput.Name = "PhraseInput";
            this.PhraseInput.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.PhraseInput.Size = new System.Drawing.Size(1144, 483);
            this.PhraseInput.TabIndex = 1;
            this.PhraseInput.Text = "Enter a phrase here...";
            this.PhraseInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PhraseInput.Click += new System.EventHandler(this.PhraseInput_Click);
            // 
            // VoiceGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1503, 1106);
            this.Controls.Add(this.PhraseInput);
            this.Controls.Add(this.TextBoxImage);
            this.Name = "VoiceGeneratorForm";
            this.Text = "Alphabetese - Voice Generator";
            this.Load += new System.EventHandler(this.VoiceGeneratorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox TextBoxImage;
        private System.Windows.Forms.TextBox PhraseInput;
    }
}

