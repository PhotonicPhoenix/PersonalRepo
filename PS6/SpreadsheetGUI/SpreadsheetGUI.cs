// By Josh Lange and Kimi Heimsoth
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SpreadsheetUtilities;
using System.IO;
using SpreadsheetGUI;

namespace SS
{
    /// <summary>
    /// A form that shows the spreadsheet.
    /// </summary>
    public partial class SpreadsheetGUI : Form
    {
        /// <summary>
        /// The current column that is selected.
        /// </summary>
        private int col = 0;

        /// <summary>
        /// The current row that is selected.
        /// </summary>
        private int row = 0;

        /// <summary>
        /// The spreadsheet the data will be held in.
        /// </summary>
        private Spreadsheet spreadsheetModel;

        /// <summary>
        /// The constructor for the form.
        /// </summary>
        public SpreadsheetGUI()
        {
            InitializeComponent();
            // updates whether something is selected by mouse
            Spreadsheet.SelectionChanged += displaySelection;
            // sets the initial selection
            Spreadsheet.SetSelection(col, row);
            // updates that any keys currently assigned that we will be using should not be assigned
            Spreadsheet.PreviewKeyDown += disableScroll;
            // updates whether a key is down
            Spreadsheet.KeyDown += displayArrowSelect;
            // creates the spreadsheet with the validator and normalizer
            spreadsheetModel = new Spreadsheet(s => Regex.IsMatch(s, @"^[A-Z][\d]$"), s => s.ToUpper(), 
                "ps6");

            // used to disable the keys we need that are already assigned a function
            foreach (Control control in this.Controls)
            {
                control.PreviewKeyDown += new PreviewKeyDownEventHandler(control_PreviewKeyDown);
            }
        }

        /// <summary>
        /// Called before a key is fully pressed
        /// </summary>
        /// <param name="sender">What object the method call came from</param>
        /// <param name="e">The arguments for the PreviewKeyDown</param>
        private void control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // if the key is a key that we will be using to do something else...
            if (e.KeyData == Keys.Tab || e.KeyData == Keys.Up || e.KeyData == Keys.Down || 
                e.KeyData == Keys.Left || e.KeyData == Keys.Right)
            {
                // cancel the old control
                e.IsInputKey = true;
            }
        }

        private void disableScroll(object sender, PreviewKeyDownEventArgs e)
        {


        }

        /// <summary>
        /// Used to determine what to do when a key is pressed.
        /// </summary>
        /// <param name="sender">What object the method call came from</param>
        /// <param name="e">The arguments for the KeyEvent</param>
        private void displayArrowSelect(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                if (row < 98)
                {
                    Spreadsheet.SetSelection(col, ++row);
                }

            }
            else if (e.KeyData == Keys.Up)
            {
                if (row > 0)
                {
                    Spreadsheet.SetSelection(col, --row);
                }
            }
            else if (e.KeyData == Keys.Left)
            {
                if (col > 0)
                {
                    Spreadsheet.SetSelection(--col, row);
                }
            }
            else if (e.KeyData == Keys.Right)
            {
                if (col < 25)
                {
                    Spreadsheet.SetSelection(++col, row);
                }
            }
            else if (e.KeyData == Keys.Tab || e.KeyData == Keys.Enter)
            {
                if (col == 25)
                {
                    col = 0;
                    Spreadsheet.SetSelection(col, ++row);
                }
                else if (row == 98)
                {
                    return;
                }
                else
                {
                    Spreadsheet.SetSelection(++col, row);
                }
            }

            // gets the new cell letter
            char colLetter = (char)('A' + col);
            // sets the current cell text to the new selected cell
            CellName.Text = colLetter + "" + (1 + row);
            
            // gets the cell contents from the spreadsheet model
            object cellContents = spreadsheetModel.GetCellContents(CellName.Text);
            if (cellContents is Formula)
            {
                // makes sure to append = if the contents are a formula
                CellContents.Text = "=" + cellContents.ToString();
            }
            else
            {
                CellContents.Text = cellContents.ToString();
            }

            // gets the value at the current cell and sets it to the cell value text
            Spreadsheet.GetValue(col, row, out string value);
            CellValue.Text = value;
        }

        // 
        /// <summary>
        /// Every time the selection changes by mouse, this method is called with the
        /// Spreadsheet as its parameter.
        /// </summary>
        /// <param name="ss">The current spreadsheet panel</param>
        private void displaySelection(SpreadsheetPanel ss)
        {
            // initializes out values
            int row, col;
            String value;

            // calls the get selection to get the row and col of the currently selected cell
            ss.GetSelection(out col, out row);

            // gets the value at that cell
            ss.GetValue(col, row, out value);

            // updates the cell name label
            char colLetter = (char)('A' + col);
            CellName.Text = colLetter + "" + (1 + row);

            // updates the cell contents label
            object cellContents = spreadsheetModel.GetCellContents(CellName.Text);
            if (cellContents is Formula)
            {
                CellContents.Text = "=" + cellContents.ToString();
            }
            else
            {
                CellContents.Text = cellContents.ToString();
            }

            // updates the cell value label
            CellValue.Text = value;

            // updates the current row and column
            this.row = row;
            this.col = col;
        }

        private void SpreadsheetGUI_Load(object sender, EventArgs e)
        {

        }

        private void Spreadsheet_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Called when the new button is clicked in the File menu.
        /// </summary>
        /// <param name="sender">What object the method call came from</param>
        /// <param name="e">The arguments for the Event</param>
        private void New_Click(object sender, EventArgs e)
        {
            // runs a new instance of the rorm
            DemoApplicationContext.getAppContext().RunForm(new SpreadsheetGUI());
        }

        /// <summary>
        /// Called when the close button is clicked in the File menu.
        /// </summary>
        /// <param name="sender">What object the method call came from</param>
        /// <param name="e">The arguments for the Event</param>
        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Called when the Help button is clicked.
        /// </summary>
        /// <param name="sender">What object the method call came from</param>
        /// <param name="e">The arguments for the Event</param>
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // makes a new help panel and shows it
            HelpPanel helper = new HelpPanel();
            helper.Show();
        }

        private void File_Click(object sender, EventArgs e)
        {

        }

        private void CellContents_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Called when the CellContent text box is selected and a key is pressed.
        /// </summary>
        /// <param name="sender">What object the method call came from</param>
        /// <param name="e">The arguments for the KeyEvent</param>
        private void CellContents_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                // try setting the contents into the spreadsheet.
                IEnumerator<string> cellsToChange = null;
                try
                {
                    cellsToChange = spreadsheetModel.SetContentsOfCell(CellName.Text,
                        CellContents.Text).GetEnumerator();
                }
                catch (CircularException)
                {
                    // show circular exception error message
                    MessageBox.Show("Circular Dependency Error: There cannot be a cell " +
                        "referencing itself.");

                    // changes the cell contents text box back to what it was
                    object cellContentsBefore = spreadsheetModel.GetCellContents(CellName.Text);
                    if (cellContentsBefore is Formula)
                    {
                        CellContents.Text = "=" + cellContentsBefore.ToString();
                    }
                    else
                    {
                        CellContents.Text = cellContentsBefore.ToString();
                    }

                    return;
                }
                catch (FormulaFormatException)
                {
                    // show a formula format exception messages
                    MessageBox.Show("Invalid Formula Error: Make sure your formula is correctly " +
                        "formatted and the variables exist.");

                    // changes the cell contents text box back to what it was
                    object cellContentsBefore = spreadsheetModel.GetCellContents(CellName.Text);
                    if (cellContentsBefore is Formula)
                    {
                        CellContents.Text = "=" + cellContentsBefore.ToString();
                    }
                    else
                    {
                        CellContents.Text = cellContentsBefore.ToString();
                    }

                    return;
                }
                
                bool formulaErrorFound = false;

                // if setting contents succeeds, we have a IEnumerable of cells to change values of
                while (cellsToChange.MoveNext())
                {
                    string cellName = cellsToChange.Current;
                    object cellValue = spreadsheetModel.GetCellValue(cellName);
                    
                    if (cellValue is FormulaError)
                    {
                        // makes it so that only one message is shown saying there is a Formula error
                        if (!formulaErrorFound)
                        {
                            MessageBox.Show(((FormulaError)cellValue).Reason);
                            formulaErrorFound = true;
                        }
                        // set all dependents to FORMULA ERROR
                        Spreadsheet.SetValue(cellName[0] - 'A', Int32.Parse(cellName.Substring(1)) - 1, 
                            "FORMULA ERROR");
                    }
                    else
                    {
                        // sets the value in the cell based on the row and col
                        Spreadsheet.SetValue(cellName[0] - 'A', Int32.Parse(cellName.Substring(1)) - 1, 
                            cellValue.ToString());
                    }

                }

                // updates the cell contents into the label
                object cellContents = spreadsheetModel.GetCellContents(CellName.Text);
                if (cellContents is Formula)
                {
                    CellContents.Text = "=" + cellContents.ToString();
                }
                else
                {
                    CellContents.Text = cellContents.ToString();
                }

                // updates the current selected cell's value for the label
                Spreadsheet.GetValue(col, row, out string value);
                CellValue.Text = value;

                // updates the title of the window
                if (!this.Text.EndsWith("*"))
                {
                    this.Text = this.Text + "*";
                }
                
                // change the focus to the spreadsheet again
                Spreadsheet.Focus();
            }
        }

        /// <summary>
        /// Called when the Save button in the File menu is clicked.
        /// </summary>
        /// <param name="sender">What object the method call came from</param>
        /// <param name="e">The arguments for the Event</param>
        private void Save_Click(object sender, EventArgs e)
        {
            // Initializes the Save Dialog with certain arguments
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.AddExtension = true;
            saveFile.OverwritePrompt = false;
            saveFile.Title = "Save Spreadsheet";
            saveFile.DefaultExt = "sprd";
            saveFile.Filter = "sprd files (*.sprd)|*.sprd|All files (*.*)|*.*";

            // Makes it so that the name of the opened file is displayed as the default saving location
            if (Text.LastIndexOf('*') < 0)
            {
                saveFile.FileName = this.Text;
            }
            else
            {
                saveFile.FileName = this.Text.Substring(0, Text.LastIndexOf('*'));
            }
            
            saveFile.ShowDialog();
            
            // if we are saving the file as a sprd...
            if (saveFile.FilterIndex == 1)
            {
                // store the original file name
                string formattedFile = saveFile.FileName;

                // add .sprd if it doesn't end in .sprd
                if (!formattedFile.EndsWith(".sprd"))
                {
                    formattedFile = saveFile.FileName + ".sprd";
                }

                // add the .xml extension to the filename so it can be saved
                string filePath = formattedFile + ".xml";

                string fileOpenSavingName = "";
                // checks if the file is being saved to another file of a different name 
                if (this.Text.EndsWith("*"))
                {
                    fileOpenSavingName = this.Text.Substring(0, Text.LastIndexOf("*"));
                }
                else
                {
                    fileOpenSavingName = this.Text;
                }

                // test if the names of the files are equal
                if (!(fileOpenSavingName + ".sprd").Equals(formattedFile.Substring(
                    formattedFile.LastIndexOf('\\') + 1)))
                {
                    // display a warning for overwriting an existing file
                    // if yes, it will save
                    if (MessageBox.Show("Are you sure you want to overwrite this file?", "Overwriting",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                    }
                    else
                    {
                        // if no, it will cancel
                        return;
                    }
                }

                spreadsheetModel.Save(filePath);

                // get the file information for the appended .xml version
                FileInfo fileXML = new FileInfo(filePath);
                // get the file info for the non-appended .xml version
                FileInfo fileSprd = new FileInfo(formattedFile);
                if (fileXML.Exists)
                {
                    // if the non-appended .xml version already exists, the file already exists so we will
                    // create a back up version of the old one
                    if (fileSprd.Exists)
                    {
                        fileXML.Replace(formattedFile, formattedFile + " - backup");

                    }
                    else
                    {
                        // replace the name to .sprd
                        fileXML.MoveTo(formattedFile);
                    }
                }
            }
            // if the option is all files
            else
            {
                // add the .xml extension to the filename so it can be saved
                string filePath = saveFile.FileName + ".xml";
                spreadsheetModel.Save(filePath);

                // get the file information for the appended .xml version
                FileInfo fileXML = new FileInfo(filePath);
                // get the file info for the non-appended .xml version
                FileInfo fileSprd = new FileInfo(saveFile.FileName);
                if (fileXML.Exists)
                {
                    if (fileSprd.Exists)
                    {
                        // if the non-appended .xml version already exists, the file already exists so we will
                        // create a back up version of the old one
                        fileXML.Replace(saveFile.FileName, saveFile.FileName + " - backup");

                    }
                    else
                    {
                        // replace the name to .sprd
                        fileXML.MoveTo(saveFile.FileName);
                    }
                }
            }
            
            // updates the title of the form
            if (this.Text.EndsWith("*"))
            {
                this.Text = this.Text.Substring(0, Text.LastIndexOf('*'));
            }
            else
            {
                this.Text = this.Text;
            }

        }

        /// <summary>
        /// Called when the form is closing.
        /// </summary>
        /// <param name="sender">What object the method call came from</param>
        /// <param name="e">The arguments for the FormClosingEvent</param>
        private void SpreadsheetGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (spreadsheetModel.Changed)
            {
                // display a warning for closing with an unsaved spreadsheet.
                // if yes, it will close.
                if (MessageBox.Show("You are about to close the file you are working on and there are " +
                    "some unsaved changes, would you like to close it anyway?", "Close without saving?", 
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                }
                else
                {
                    // if no, it will cancel closing.
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// Called when the open button is clicked in the File Menu.
        /// </summary>
        /// <param name="sender">What object the method call came from</param>
        /// <param name="e">The arguments for the Event</param>
        private void Open_Click(object sender, EventArgs e)
        {
            // creates an open file dialog with certain arguments
            OpenFileDialog fileToOpen = new OpenFileDialog();
            fileToOpen.AddExtension = true;
            fileToOpen.Title = "Open Spreadsheet";
            fileToOpen.DefaultExt = "sprd";
            fileToOpen.Filter = "sprd files (*.sprd)|*.sprd|All files (*.*)|*.*";

            fileToOpen.ShowDialog();
            
            // try to get the info for the file to open
            FileInfo fileToOpenInfo = null;
            try
            {
                fileToOpenInfo = new FileInfo(fileToOpen.FileName);
            }
            catch (Exception)
            {
                // if form is exited, just return.
                return;
            }

            // if the spreadsheet model has been changed, show a warning dialog about unsaved spreadsheet
            if (spreadsheetModel.Changed)
            {
                if (MessageBox.Show("You are about to open a file before saving the one you are " +
                    "working on. Would you like to open this file anyway?", "Close without saving?", 
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                }
                else
                {
                    return;
                }
            }

            // if the file formation exists
            if (fileToOpenInfo.Exists)
            {
                // rename the file with the xml extension
                fileToOpenInfo.MoveTo(fileToOpen.FileName + ".xml");
            }
            

            // try creating a new spreadsheet with the file with the xml extension
            try
            {
                spreadsheetModel = new Spreadsheet(fileToOpen.FileName + ".xml", 
                    s => Regex.IsMatch(s, @"^[A-Z][\d]$"), s => s.ToUpper(), "ps6");
            }
            catch (SpreadsheetReadWriteException)
            {
                // if anything bad happens while creating, show an error message
                MessageBox.Show("Error: Make sure your file is a .sprd file and that all the values " +
                    "inside make sense.");
                // name the original file back to sprd form
                fileToOpenInfo.MoveTo(fileToOpen.FileName);
                return;
            }
            // rename the file back to sprd form
            fileToOpenInfo.MoveTo(fileToOpen.FileName);
            
            Spreadsheet.Clear();

            // updates the spreadsheet gui
            IEnumerator<string> cellsToUpdate = spreadsheetModel.GetNamesOfAllNonemptyCells().GetEnumerator();

            // for all cells with values...
            while (cellsToUpdate.MoveNext())
            {
                string cell = cellsToUpdate.Current;
                string cellName = cellsToUpdate.Current;
                object cellValue = spreadsheetModel.GetCellValue(cellName);
                if (cellValue is FormulaError)
                {
                    // set the value if there is a Formula error
                    Spreadsheet.SetValue(cellName[0] - 'A', Int32.Parse(cellName.Substring(1)) - 1, 
                        "FORMULA ERROR");
                }
                else
                {
                    // set the value if there is not a Formula error
                    Spreadsheet.SetValue(cellName[0] - 'A', Int32.Parse(cellName.Substring(1)) - 1, 
                        cellValue.ToString());
                }
            }

            // reset the current selection to A1
            row = 0;
            col = 0;
            Spreadsheet.SetSelection(col, row);

            // update the cell name label
            CellName.Text = "A1";

            // update the cell value label
            Spreadsheet.GetValue(col, row, out string value);
            CellValue.Text = value;

            // update the cell contents label
            object cellContents = spreadsheetModel.GetCellContents(CellName.Text);
            if (cellContents is Formula)
            {
                CellContents.Text = "=" + cellContents.ToString();
            }
            else
            {
                CellContents.Text = cellContents.ToString();
            }

            // update the name of the window to the name of the file (without the sprd extension)
            int index = fileToOpen.FileName.LastIndexOf('.');
            string fileName = fileToOpen.FileName.Substring(fileToOpen.FileName.LastIndexOf('\\') + 1, 
                index - fileToOpen.FileName.LastIndexOf('\\') - 1);
            this.Text = fileName;
        }

        /// <summary>
        /// Called when the Bar Grapg button is clicked.
        /// </summary>
        /// <param name="sender">What object the method call came from</param>
        /// <param name="e">The arguments for the Event</param>
        private void graphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // makes a new Graph form and shows it.
            Graph GraphingPanel = new Graph(spreadsheetModel);
            GraphingPanel.Show();
        }
    }
}