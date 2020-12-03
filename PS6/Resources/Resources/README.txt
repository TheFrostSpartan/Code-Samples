Written By Matt Mader and Ethan Duncan for CS3500 in October 2019
U1178487 (Matt Mader)
U1167015 (Ethan Duncan)

GUI Additional Features
	Dark Mode
		Adds two seperate themes for the spreadsheet, a dark theme and a light theme
			Light Theme (Default Theme)
				All Backgrounds are white and text is black, all lines and foreground elements are black
			Dark Theme (Kinder to the eyes theme)
				All backgrounds are dark gray, with all text and foreground elements being white

		Dark Mode is toggled through a button on the top of the screen
			The button is a full toggle, so clicking it again will turn off dark mode


	SUM(cell1, cell2)
		Adds an extra function to the spreadsheet for bulk summation
			Converts to a formula to keep constant updates

		SUM(cell1, cell2)
			SUM
				Calls the Summation function, without this (case-sensitive) calling card, the spreadsheet just reads it as a string
			cell1
				The cell the the summation starts at, the sum will include this cell
			cell2
				The cell the summation concludes with, the sum will include this cell

		SUM will only calculate the sum of a straight line
			A1, A10 is valid
				The Cells Share a Column
			A1, J1 is valid
				The Cells Share a Row
			A1, B2 is invalid
				The Cells Share Nothing In Common

	Enter Key
		When enter is pressed, sets the contents of the selected cell and moves the selection down one row

	F1 Key
		When F1 is pressed, open the help menu
			If the Help menu is already open, F1 Closes the help menu



Implementation Problems:
	Loading large files is incredibly slow (10/3/19)
		Sometimes causes a crash?
			Seemingly at random
				Fixed, loads rapidly now, no matter how many cells are occupied (10/4/19)

	Spreadsheet is Incredibly Slow (10/1/19)
		Added Threading, still slow, marginally better (10/2/19)
			Reworked how PS5 handles getting values, incredibly fast now (10/3/19)

	Cannot change color on the Spreadsheet panel, struggling to add Dark Mode (9/30/19)
		Added methods to SpreadsheetPanel.dll that allow for changes of color, enabling dark mode (10/2/19)

	Miswritten Formulas crash the entire program (9/30/19)
		Fixed by catching, displaying a error message and removing the offending formula (10/3/19)



External Code Resources:
	Formula, Dependency Graph, Spreadsheet
		Written by Matt Mader
		Spreadsheet Updated by Matt Mader and Ethan Duncan
	
	SpreadsheetPanel
		Written by Joe Zachary
		Modified by Matt Mader
	
	PS6SkeletonDemo
		Code Used from this to implement multiple windows
		Written by: No Author Given