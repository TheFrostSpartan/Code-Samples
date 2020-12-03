//Written By Matt Mader and Ethan Duncan for CS3500 in October 2019

using SpreadsheetUtilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;


namespace SS
{
    /// <summary>
    /// Shows a Visual Representation of a Spreadsheet object
    /// </summary>
    public partial class window : Form
    {
        //The Row and Column of the Previously Accessed Cell
        private int previousPanelCol;
        private int previousPanelRow;
        //The Spreadsheet Backing
        private Spreadsheet mainSpread;
        //The Path to the Saved File
        private String savePath = "";

        /// <summary>
        /// Creates a new Spreadsheet Window
        /// </summary>
        public window()
        {
            //Initialize and Set Starting Cell
            InitializeComponent();
            spreadsheetPanel1.SetSelection(0, 0);
        }

        /// <summary>
        /// Finds the sum of all cells between two given cells, then outputs that to a given cell
        /// </summary>
        /// <param name="col">Output Cell Column</param>
        /// <param name="row">Output Cell Row</param>
        /// <param name="colStart">Start Cell Column</param>
        /// <param name="colEnd">End Cell Column</param>
        /// <param name="row1">Start Cell Row</param>
        /// <param name="row2">End Cell Row</param>
        private void Summation(int col, int row, char colStart, char colEnd, int row1, int row2)
        {
            //Normalizes colStart and colEnd
            String toLowerThis = "" + colStart;
            colStart = toLowerThis.ToLower().ToCharArray()[0];
            toLowerThis = "" + colEnd;
            colEnd = toLowerThis.ToLower().ToCharArray()[0];

            //If the cells aren't in the same row or col, it isn't valid
            if (colStart != colEnd && row1 != row2)
            {
                spreadsheetPanel1.SetValue(col, row, "Invalid Sum");
                return;
            }

            //If they're in the same col
            if (row1 != row2)
            {
                //Create a string representation of a formula of all the cells 
                String input = "=";
                for (int i = row1 + 1; i <= row2 + 1; i++)
                {
                    input += "" + colStart + i;
                    if (i != row2 + 1)
                    {
                        input += " + ";
                    }
                }
                //Sets the cell to the formula
                cellInputBox.Text = input;
                previousPanelCol = col;
                previousPanelRow = row;
                SpreadsheetPanel1_SelectionChanged(spreadsheetPanel1);
                return;
            }

            //If they're in the same row
            if (colStart != colEnd)
            {
                //Create a string representation of a formula of all the cells 
                String input = "=";
                for (int i = colStart - 97; i <= colEnd - 97; i++)
                {
                    input += "" + ((char)(i + 97)) + (row1 + 1);
                    if (i != colEnd - 97)
                    {
                        input += " + ";
                    }
                }
                //Sets the cell to the formula
                cellInputBox.Text = input;
                previousPanelCol = col;
                previousPanelRow = row;
                SpreadsheetPanel1_SelectionChanged(spreadsheetPanel1);
                return;
            }

            //If the summation is run over 1 single cell
            if (colStart == colEnd && row1 == row2)
            {
                //Sets the input to a single cell reference
                String input = "=";
                input += "" + colStart + (row1 + 1);

                //Sets the cell to the formula
                cellInputBox.Text = input;
                previousPanelCol = col;
                previousPanelRow = row;
                SpreadsheetPanel1_SelectionChanged(spreadsheetPanel1);
                return;
            }
        }

        /// <summary>
        /// Updates cells in the GUI
        /// </summary>
        /// <param name="sender"></param>
        private void SpreadsheetPanel1_SelectionChanged(SpreadsheetPanel sender)
        {
            //Changes the cell from numerical to variable format
            char coll = (char)(previousPanelCol + 97);
            String input = "" + coll + (previousPanelRow + 1);

            //Checks to see if the input is a formula
            if (cellInputBox.Text.IndexOf("=") == 0)
            {
                try
                {
                    //Checks to see if the formula inputted is valid
                    Formula tempForm = new Formula(cellInputBox.Text.Substring(1));
                }
                catch (FormulaFormatException e)
                {
                    //Catches and notifies users of Invalid Formulas
                    String message = e.Message;
                    string caption = "Formula Format Error";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                    cellInputBox.Text = "";
                    return;
                }
            }

            try
            {
                //Updates all cells that rely on this cell
                foreach (string cell in mainSpread.SetContentsOfCell(input, cellInputBox.Text))
                {
                    Thread temp = new Thread(() => SetCellValue(cell));
                    temp.Start();
                }
            }
            catch (FormulaFormatException e)
            {
                //Catches and notifies users of Invalid Variables
                String message = e.Message;
                string caption = "Error: Invalid Variable";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                cellInputBox.Text = "";
                return;
            }
            catch (CircularException e)
            {
                //Catches and notifies users of Circular Dependencies
                String message = "The Formula Entered Creates a Circular Dependency";
                string caption = "Circular Formula Error";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                cellInputBox.Text = "";
                return;
            }

            //Checks for the SUM key in order to perform operation if necessary
            if (cellInputBox.Text.StartsWith("SUM(") && cellInputBox.Text.EndsWith(")"))
            {
                String sum = cellInputBox.Text;
                sum = sum.Trim();
                List<string> temp = new List<string>(Regex.Split(sum, "[(,)]"));

                //Removes all empty strings from temp
                foreach (string empty in Regex.Split(sum, "[(,)]"))
                {
                    if (empty.Trim() == "")
                    {
                        temp.Remove(empty);
                    }
                }

                //If there are less than two items, there wasn't anything inside the parentheses
                if (temp.Count < 2)
                {
                    //Inform the user of the bad sum and remove it
                    var result = MessageBox.Show("Invalid SUM: Nothing Inside Parentheses", "Invalid SUM", MessageBoxButtons.OK);
                    cellInputBox.Text = "";
                    mainSpread.SetContentsOfCell(input, "");
                    SetCellValue(input);
                }
                else
                {
                    //Trim any white space
                    String SumStart = temp[1].Trim();
                    String SumEnd = temp[2].Trim();

                    //Make sure the given cells are actual cells
                    if (cellValidation(SumStart) && cellValidation(SumEnd))
                    {
                        //Get the character representations of the columns
                        char col1 = SumStart.ToCharArray()[0];
                        char col2 = SumEnd.ToCharArray()[0];

                        //Pull the numeral versions of the rows from the input strings
                        int row1 = 0;
                        int row2 = 0;
                        if (SumStart.Length == 3)
                        {
                            row1 += (SumStart.ToCharArray()[1] - 48) * 10;
                            row1 += SumStart.ToCharArray()[2] - 49;
                        }
                        else
                        {
                            row1 += SumStart.ToCharArray()[1] - 49;
                        }

                        if (SumEnd.Length == 3)
                        {
                            row2 += (SumEnd.ToCharArray()[1] - 48) * 10;
                            row2 += SumEnd.ToCharArray()[2] - 49;
                        }
                        else
                        {
                            row2 += SumEnd.ToCharArray()[1] - 49;
                        }

                        //Do the sum
                        Summation(previousPanelCol, previousPanelRow, col1, col2, row1, row2);
                    }
                    //In the case of invalid cell names
                    else
                    {
                        //Inform the user of the bad sum and remove it
                        var result = MessageBox.Show("Invalid SUM: Invalid Cell Within SUM", "Invalid SUM", MessageBoxButtons.OK);
                        cellInputBox.Text = "";
                        mainSpread.SetContentsOfCell(input, "");
                        SetCellValue(input);
                    }
                }
            }

            sender.Refresh();

            //Selects the box and sets up the input text form
            sender.GetSelection(out int col, out int row);
            cellInputBox.Focus();
            cellInputBox.Text = GetContentsOfCell(col, row);

            //Shows the cell name and value at the top of the spreadsheet
            coll = (char)(col + 97);
            input = "" + coll + (row + 1);
            spreadsheetPanel1.GetValue(col, row, out string tempVal);
            CellNameLabel.Text = input.ToUpper() + " = " + tempVal;

            //Resets the previous value
            previousPanelCol = col;
            previousPanelRow = row;
        }

        /// <summary>
        /// Sets the Value of the cell in the GUI
        /// </summary>
        /// <param name="cell"></param>
        private void SetCellValue(String cell)
        {
            //Convert the cell name to numerical form (HELPER METHOD?)
            int output = 0;
            Char[] tempChar = cell.ToCharArray();
            if (cell.Length == 3)
            {
                output += (tempChar[1] - 48) * 10;
                output += tempChar[2] - 49;
            }
            else
            {
                output += tempChar[1] - 49;
            }

            //If the cell is a Formula Error, Set it to text Showing that
            if (mainSpread.GetCellValue(cell) is FormulaError)
            {
                spreadsheetPanel1.SetValue(tempChar[0] - 97, output, "Formula Error");
                return;
            }
            //Get the value of the cell and display it.
            spreadsheetPanel1.SetValue(tempChar[0] - 97, output, "" + mainSpread.GetCellValue(cell));
        }

        /// <summary>
        /// Initializes the Spreadsheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpreadsheetPanel1_Load(object sender, EventArgs e)
        {
            previousPanelCol = 0;
            previousPanelRow = 0;
            mainSpread = new Spreadsheet(s => cellValidation(s), s => s.ToLower(), "ps6");
        }

        /// <summary>
        /// Checks if a cell name is valid
        /// </summary>
        /// <param name="name">Cell name to validate</param>
        /// <returns></returns>
        private bool cellValidation(string name)
        {
            //Normalize the name
            name = name.ToLower();

            //If the first character is a letter and the name contains 1-2 other characters
            if (Regex.IsMatch(name, "^[a-z]") && name.Length <= 3 && name.Length > 1)
            {
                //Remove all the letters
                String[] tempArr = Regex.Split(name, "[a-z]");
                //If there are more than two items in the array, there was more than one letter
                if (tempArr.Length > 2)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns the contents of the cell at the given col and row
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private string GetContentsOfCell(int col, int row)
        {
            //Turns the current col into it's letter representation
            char coll = (char)(col + 97);
            //Creates the proper string format
            String contents = "" + coll + (row + 1);

            //Turn the contents into a string
            string output = "" + mainSpread.GetCellContents(contents);
            if (mainSpread.GetCellContents(contents) is Formula)
            {
                return "=" + output;
            }
            return output;
        }

        /// <summary>
        /// Closes the Spreadsheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Opens a new Window of Spreadsheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowApplicationContext.getAppContext().RunForm(new window());
        }

        /// <summary>
        /// Saves a spreadsheet to an existing file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If there is no valid path, run save as. Otherwise, save to the existing file path
            if (savePath == "")
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                mainSpread.Save(savePath);
            }
        }

        /// <summary>
        /// Saves a spreadsheet to a new file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create a File Dialog that takes in .SPRD and any other files
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Spreadsheet|*.sprd|All Files|*.*";
            saveFileDialog1.Title = "Save a Spreadsheet";
            saveFileDialog1.ShowDialog();

            //Set the document filepath to the path the user chooses
            savePath = saveFileDialog1.FileName;

            // If the file name is not an empty string open it for saving.
            if (savePath != "")
            {
                mainSpread.Save(saveFileDialog1.FileName);
            }
        }

        /// <summary>
        /// Loads a spreadsheet from a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If there has been any edits to the Spreadsheet, verify if the user would like to save
            if (mainSpread.Changed)
            {
                String message = "You have not saved changes. Would you like to save?";
                string caption = "File Not Saved";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel);

                //If they choose to save, run the save method
                if (result == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                }
                //If the user selects to cancel, do not close the application
                if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            //Opens a fileDialog that limits selections to .SPRD or all types of files
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Spreadsheet|*.sprd|All Files|*.*";
            openFile.Title = "Load a Spreadsheet";
            openFile.ShowDialog();

            //Saves the file path to the global path
            savePath = openFile.FileName;

            // If the file name is not an empty string open it for loading
            if (savePath != "")
            {
                previousPanelCol = 0;
                previousPanelRow = 0;
                //Reset the Spreadsheet with new data
                mainSpread = new Spreadsheet(savePath, s => cellValidation(s), s => s.ToLower(), "ps6");



                //Makes sure the inital cell keeps it's data
                String cellA1 = "";
                if (mainSpread.GetCellContents("a1") is Formula)
                {
                    cellA1 += "=";
                }
                cellA1 += mainSpread.GetCellContents("a1").ToString();
                cellInputBox.Text = cellA1;

                //Empties the GUI
                spreadsheetPanel1.Clear();
                spreadsheetPanel1.Refresh();

                //Updates all populated cells in the GUI
                foreach (string cell in mainSpread.GetNamesOfAllNonemptyCells())
                {
                    SetCellValue(cell);
                }
            }
        }

        /// <summary>
        /// Toggles Darkmode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            //Toggle the spreadsheet panel dark mode
            spreadsheetPanel1.DarkMode();

            //If the back is white, then enter darkmode
            if (cellInputBox.BackColor == Color.White)
            {
                DarkModeButton.Text = "Dark Mode Off";
                this.BackColor = Color.Gray;
                cellInputBox.BackColor = Color.Gray;
                cellInputBox.ForeColor = Color.White;
                CellNameLabel.ForeColor = Color.White;
                FileToolStrip.BackColor = Color.Gray;
                FileToolStrip.ForeColor = Color.White;
                FileDropDownButton.DropDown.BackColor = Color.Gray;
                FileDropDownButton.DropDown.ForeColor = Color.White;
            }
            //Otherwise, enter light mode
            else if (cellInputBox.BackColor == Color.Gray)
            {
                DarkModeButton.Text = "Dark Mode On";
                this.BackColor = Color.White;
                cellInputBox.BackColor = Color.White;
                cellInputBox.ForeColor = Color.Black;
                CellNameLabel.ForeColor = Color.Black;
                FileToolStrip.BackColor = Color.White;
                FileToolStrip.ForeColor = Color.Black;
                FileDropDownButton.DropDown.BackColor = Color.White;
                FileDropDownButton.DropDown.ForeColor = Color.Black;

            }
        }

        /// <summary>
        /// Prompts the user to save when attempting to close a non-saved document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            //If Windows is trying to force close this application, close it
            if (e.CloseReason == CloseReason.WindowsShutDown || e.CloseReason == CloseReason.ApplicationExitCall || e.CloseReason == CloseReason.TaskManagerClosing)
            {
                return;
            }

            //If there has been any edits to the Spreadsheet, verify if the user would like to save
            if (mainSpread.Changed)
            {
                String message = "You have not saved changes. Would you like to save?";
                string caption = "File Not Saved";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel);

                //If they choose to save, run the save method
                if (result == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                    return;
                }
                //If the user selects to cancel, do not close the application
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        /// <summary>
        /// Opens/Closes the Help Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpButton_Click(object sender, EventArgs e)
        {
            if(HelpTextBox.Visible == true)
            {
                HelpTextBox.Visible = false;
                //The Close Help Menu Button Must Match the Visibility of the Menu
                CloseHelpButton.Visible = false;
            }
            else
            {
                CloseHelpButton.Visible = true;
                //The Close Help Menu Button Must Match the Visibility of the Menu
                HelpTextBox.Visible = true;
            }
        }

        /// <summary>
        /// Detects Key Shortcuts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            //If F1 is Pressed Open Help
            if (e.KeyData == Keys.F1)
            {
                HelpButton_Click(sender, e);
                return;
            }

            //If enter is pressed, move down a cell
            if (e.KeyData == Keys.Enter)
            {
                //Gets the current selection and lets the panel know the selection has been changed
                spreadsheetPanel1.GetSelection(out int col, out int row);
                SpreadsheetPanel1_SelectionChanged(spreadsheetPanel1);

                //Gets the contents on the next cell and shows it as it selects the next cell
                if(row < 98)
                {
                    cellInputBox.Text = GetContentsOfCell(col, row + 1);
                    spreadsheetPanel1.SetSelection(col, row + 1);
                    char coll = (char)(col + 97);
                    string input = "" + coll + (row + 2);
                    spreadsheetPanel1.GetValue(col, row + 1, out string tempVal);
                    CellNameLabel.Text = input.ToUpper() + " = " + tempVal;

                    previousPanelCol = col;
                    previousPanelRow = row + 1;
                }
            }
        }

        /// <summary>
        /// Closes the help menu with a visual button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseHelpButton_Click(object sender, EventArgs e)
        {
            HelpButton_Click(sender, e);
        }
    }
}