namespace SS
{
    partial class Graph
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.SpreadsheetChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BarGraphNameText = new System.Windows.Forms.TextBox();
            this.BarGraphNameLabel = new System.Windows.Forms.Label();
            this.XAxisLabel = new System.Windows.Forms.Label();
            this.RangeToY = new System.Windows.Forms.Label();
            this.EndingRangeYText = new System.Windows.Forms.TextBox();
            this.BeginningRangeYText = new System.Windows.Forms.TextBox();
            this.YAxisLabel = new System.Windows.Forms.Label();
            this.RangeToX = new System.Windows.Forms.Label();
            this.EndingRangeXText = new System.Windows.Forms.TextBox();
            this.BeginningRangeXText = new System.Windows.Forms.TextBox();
            this.MakeBarGraphButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SpreadsheetChart)).BeginInit();
            this.SuspendLayout();
            // 
            // SpreadsheetChart
            // 
            this.SpreadsheetChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.SpreadsheetChart.ChartAreas.Add(chartArea1);
            this.SpreadsheetChart.Location = new System.Drawing.Point(12, 118);
            this.SpreadsheetChart.Name = "SpreadsheetChart";
            this.SpreadsheetChart.Size = new System.Drawing.Size(645, 272);
            this.SpreadsheetChart.TabIndex = 0;
            this.SpreadsheetChart.Text = "Spreadsheet Graph";
            this.SpreadsheetChart.Click += new System.EventHandler(this.SpreadsheetChart_Click);
            // 
            // BarGraphNameText
            // 
            this.BarGraphNameText.Location = new System.Drawing.Point(167, 12);
            this.BarGraphNameText.Name = "BarGraphNameText";
            this.BarGraphNameText.Size = new System.Drawing.Size(109, 20);
            this.BarGraphNameText.TabIndex = 10;
            // 
            // BarGraphNameLabel
            // 
            this.BarGraphNameLabel.AutoSize = true;
            this.BarGraphNameLabel.Location = new System.Drawing.Point(47, 15);
            this.BarGraphNameLabel.Name = "BarGraphNameLabel";
            this.BarGraphNameLabel.Size = new System.Drawing.Size(86, 13);
            this.BarGraphNameLabel.TabIndex = 11;
            this.BarGraphNameLabel.Text = "Bar Graph Name";
            // 
            // XAxisLabel
            // 
            this.XAxisLabel.AutoSize = true;
            this.XAxisLabel.Location = new System.Drawing.Point(49, 43);
            this.XAxisLabel.Name = "XAxisLabel";
            this.XAxisLabel.Size = new System.Drawing.Size(103, 13);
            this.XAxisLabel.TabIndex = 12;
            this.XAxisLabel.Text = "Cell Range of X-Axis";
            // 
            // RangeToY
            // 
            this.RangeToY.AutoSize = true;
            this.RangeToY.Location = new System.Drawing.Point(218, 83);
            this.RangeToY.Name = "RangeToY";
            this.RangeToY.Size = new System.Drawing.Size(10, 13);
            this.RangeToY.TabIndex = 19;
            this.RangeToY.Text = "-";
            // 
            // EndingRangeYText
            // 
            this.EndingRangeYText.Location = new System.Drawing.Point(234, 80);
            this.EndingRangeYText.Name = "EndingRangeYText";
            this.EndingRangeYText.Size = new System.Drawing.Size(42, 20);
            this.EndingRangeYText.TabIndex = 18;
            // 
            // BeginningRangeYText
            // 
            this.BeginningRangeYText.Location = new System.Drawing.Point(167, 80);
            this.BeginningRangeYText.Name = "BeginningRangeYText";
            this.BeginningRangeYText.Size = new System.Drawing.Size(42, 20);
            this.BeginningRangeYText.TabIndex = 17;
            // 
            // YAxisLabel
            // 
            this.YAxisLabel.AutoSize = true;
            this.YAxisLabel.Location = new System.Drawing.Point(49, 80);
            this.YAxisLabel.Name = "YAxisLabel";
            this.YAxisLabel.Size = new System.Drawing.Size(103, 13);
            this.YAxisLabel.TabIndex = 16;
            this.YAxisLabel.Text = "Cell Range of Y-Axis";
            // 
            // RangeToX
            // 
            this.RangeToX.AutoSize = true;
            this.RangeToX.Location = new System.Drawing.Point(218, 43);
            this.RangeToX.Name = "RangeToX";
            this.RangeToX.Size = new System.Drawing.Size(10, 13);
            this.RangeToX.TabIndex = 15;
            this.RangeToX.Text = "-";
            // 
            // EndingRangeXText
            // 
            this.EndingRangeXText.Location = new System.Drawing.Point(234, 40);
            this.EndingRangeXText.Name = "EndingRangeXText";
            this.EndingRangeXText.Size = new System.Drawing.Size(42, 20);
            this.EndingRangeXText.TabIndex = 14;
            // 
            // BeginningRangeXText
            // 
            this.BeginningRangeXText.Location = new System.Drawing.Point(167, 40);
            this.BeginningRangeXText.Name = "BeginningRangeXText";
            this.BeginningRangeXText.Size = new System.Drawing.Size(42, 20);
            this.BeginningRangeXText.TabIndex = 13;
            // 
            // MakeBarGraphButton
            // 
            this.MakeBarGraphButton.Location = new System.Drawing.Point(364, 65);
            this.MakeBarGraphButton.Name = "MakeBarGraphButton";
            this.MakeBarGraphButton.Size = new System.Drawing.Size(127, 23);
            this.MakeBarGraphButton.TabIndex = 20;
            this.MakeBarGraphButton.Text = "Make Bar Graph";
            this.MakeBarGraphButton.UseVisualStyleBackColor = true;
            this.MakeBarGraphButton.Click += new System.EventHandler(this.MakeBarGraphButton_Click);
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 402);
            this.Controls.Add(this.MakeBarGraphButton);
            this.Controls.Add(this.RangeToY);
            this.Controls.Add(this.EndingRangeYText);
            this.Controls.Add(this.BeginningRangeYText);
            this.Controls.Add(this.YAxisLabel);
            this.Controls.Add(this.RangeToX);
            this.Controls.Add(this.EndingRangeXText);
            this.Controls.Add(this.BeginningRangeXText);
            this.Controls.Add(this.XAxisLabel);
            this.Controls.Add(this.BarGraphNameLabel);
            this.Controls.Add(this.BarGraphNameText);
            this.Controls.Add(this.SpreadsheetChart);
            this.Name = "Graph";
            this.Text = "Graph";
            this.Load += new System.EventHandler(this.Graph_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SpreadsheetChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart SpreadsheetChart;
        private System.Windows.Forms.TextBox BarGraphNameText;
        private System.Windows.Forms.Label BarGraphNameLabel;
        private System.Windows.Forms.Label XAxisLabel;
        private System.Windows.Forms.Label RangeToY;
        private System.Windows.Forms.TextBox EndingRangeYText;
        private System.Windows.Forms.TextBox BeginningRangeYText;
        private System.Windows.Forms.Label YAxisLabel;
        private System.Windows.Forms.Label RangeToX;
        private System.Windows.Forms.TextBox EndingRangeXText;
        private System.Windows.Forms.TextBox BeginningRangeXText;
        private System.Windows.Forms.Button MakeBarGraphButton;
    }
}