// By Josh Lange and Kimi Heimsoth
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpreadsheetGUI
{
    /// <summary>
    /// The form that pops up when the Help button is pressed.
    /// </summary>
    public partial class HelpPanel : Form
    {
        /// <summary>
        /// Creates the form.
        /// </summary>
        public HelpPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads automatically the info the TAs will need to know.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            HelpInfo.Text = "How To Use This Spreadsheet Tool: \n- To use our spreadsheet tool, " +
                "you will click on a cell on the spreadsheet form and move up to the text box in " +
                "the upper margin. \n\n- In the text box you will add either a number, a string or " +
                "a formula (by appending with an equals sign) and hit enter to fill the cell with " +
                "the value of the contents of the text box. When highlighting a cell the upper " +
                "margin will also communicate the name and value of the currently selected cell, " +
                "with two label boxes. \n\n- To maneuver about the spreadsheet form, you can move " +
                "to any cell by clicking on it, or you can move to any adjacent cell by using the " +
                "directional arrow keys. Also you can use the Tab or Enter keys to move to the " +
                "next cell value. (i.e. A1 to B1, B1 to C1... Z1 to A2, etc.) \n\n- To utilize " +
                "the Bar graph you will press the Bar Graph menu item and it will open up a " +
                "new GUI box that will prompt you to enter the title of the bar graph, the range " +
                "of Cells to be graphed on the x axis, and the range of Cells to be graphed on " +
                "the y-axis. To get the Bar graph to graph properly you must give the exact " +
                "same number of Cells in the x-axis range as the the y-axis. That way each " +
                "x-value has a pairing y-value. In addition data must run parallel to one " +
                "another, so if you grabbed data for the x-axis from A1-A4 then, the " +
                "y-axis must pull all of its values from one column as well. (i.e. B1 - B4 would " +
                "work, but  B1 - E1 would not.) The same rules apply if you were to " +
                "grab your data organized in a horizontal format as well.";
        }
        
        private void HelpInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
