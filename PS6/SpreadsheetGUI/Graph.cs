// By Josh Lange and Kimi Heimsoth
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SS
{
    /// <summary>
    /// A form that displays the Graph interface.
    /// </summary>
    public partial class Graph : Form
    {
        /// <summary>
        /// The spreadsheet that contains the values to graph.
        /// </summary>
        private Spreadsheet spreadsheetModel;

        /// <summary>
        /// Creates a Graph form that draws from a given spreadsheet.
        /// </summary>
        /// <param name="spreadsheet">The spreadsheet to draw data from.</param>
        public Graph(Spreadsheet spreadsheet)
        {
            InitializeComponent();
            spreadsheetModel = spreadsheet;
        }
        
        private void Graph_Load(object sender, EventArgs e)
        {
           
        }

        private void SpreadsheetChart_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// What happens when the Make Bar Graph button is clicked.
        /// </summary>
        /// <param name="sender">The object this method came from.</param>
        /// <param name="e">The event arguments.</param>
        private void MakeBarGraphButton_Click(object sender, EventArgs e)
        {
            // Clears the spreadsheet if the button was already pressed
            SpreadsheetChart.Titles.Clear();
            SpreadsheetChart.Series.Clear();

            // Creates a series to add to named Data
            SpreadsheetChart.Series.Add("data");

            // Changes the title of the graph
            SpreadsheetChart.Titles.Add(BarGraphNameText.Text);

            // Records all the cells inputed into the text fields asking for ranges
            string xCellStart = BeginningRangeXText.Text;
            string xCellEnd = EndingRangeXText.Text;
            string yCellStart = BeginningRangeYText.Text;
            string yCellEnd = EndingRangeYText.Text;

            // Initializes the max values and whether the ranges are listed 
            // vertically or horizontally
            int maxValueX = -1;
            int maxValueY = 0;
            bool isVertical = false;

            // Checks to make sure all the inputted cells are valid cells
            Func<string, bool> g = s => Regex.IsMatch(s, @"^[A-Za-z][\d]$");
            if (!g(xCellStart) || !g(xCellEnd) || !g(yCellStart) || !g(yCellEnd))
            {
                MessageBox.Show("Cell Error: Make sure that all cells are valid.");
                return;
            }



            // if the ranges are being listed vertically (same first letter)...
            if (xCellStart.ToUpper()[0] == xCellEnd.ToUpper()[0] && yCellStart.ToUpper()[0] == yCellEnd.ToUpper()[0])
            {
                // Get the number of cells in the range for x and y
                maxValueX = Int32.Parse(xCellEnd.Substring(1)) - Int32.Parse(xCellStart.Substring(1));
                maxValueY = Int32.Parse(yCellEnd.Substring(1)) - Int32.Parse(yCellStart.Substring(1));
                isVertical = true;
            }
            // if the ranges are being listed horizontally (same number)...
            else if (xCellStart.Substring(1).Equals(xCellEnd.Substring(1)) && yCellStart.Substring(1).Equals(yCellEnd.Substring(1)))
            {
                // Get the number of cells in the range for x and y
                maxValueX = xCellEnd.ToUpper()[0] - xCellStart.ToUpper()[0];
                maxValueY = yCellEnd.ToUpper()[0] - yCellStart.ToUpper()[0];
                isVertical = false;
            }

            // if the number of cells in each range (x and y) are not the same...
            if (maxValueX != maxValueY)
            {
                MessageBox.Show("Cell Error: Make sure that both cell ranges are equal to eachother and " +
                "both are parallel.");
                return;
            }
            
            // since they are the same, we can use either for the conditional...
            for (int i = 0; i <= maxValueX; i++)
            {
                if (isVertical)
                {
                    // converts the number part of the starting cell x and starting cell y to int
                    int intX = Int32.Parse(xCellStart.Substring(1));
                    int intY = Int32.Parse(yCellStart.Substring(1));

                    // creates the next x and y cell name
                    string nextXCellName = "" + xCellStart[0] + (intX + i);
                    string nextYCellName = "" + yCellStart[0] + (intY + i);

                    // gets the cell values
                    object x = spreadsheetModel.GetCellValue(nextXCellName);
                    object y = spreadsheetModel.GetCellValue(nextYCellName);

                    // Adds the values as a pair into the bar graph
                    SpreadsheetChart.Series["data"].Points.AddXY(x, y);
                }
                else
                {
                    // creates the next x and y cell name
                    string nextXCellName = "" + (char) (xCellStart[0] + i) + xCellStart.Substring(1);
                    string nextYCellName = "" + (char) (yCellStart[0] + i) + yCellStart.Substring(1);

                    // gets the cell values
                    object x = spreadsheetModel.GetCellValue(nextXCellName);
                    object y = spreadsheetModel.GetCellValue(nextYCellName);

                    // Adds the values as a pair into the bar graph
                    SpreadsheetChart.Series["data"].Points.AddXY(x, y);
                }
            }

        }
    }
}
