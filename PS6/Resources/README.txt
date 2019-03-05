Authors Josh Lange and Kimi Heimsoth (done all together!)

General Use:
10/15- To use our spreadsheet tool, you will click on a cell on the spreadsheet form and move up to 
	the text box in the upper margin
10/15- In the text box you will add either a number, a string, or a formula (by appending with an equals sign)
	and hit enter to fill the cell with the value of he contents of the text box.
10/15- When highlighting a cell the upper margin will also communicate the name and value of the currently
	selected cell, with two label boxes.
10/17- To maneuver about the spreadsheet form, you can move to any cell by clicking on it, or you can move to
	any adjacent cell by using the directional arrow keys. Also you can use the Tab or Enter keys to move to
	the next cell value. (i.e. A1 to B1, B1 to C1... Z1 to A2, etc.)
10/21- To utilize the Bar graph you will press the Bar Graph menu item and it will open up a new UI box
	that will prompt you to enter the title of the bar graph, the range of Cells to be graphed on the x axis,
	and the range of Cells to be graphed on the y-axis. To get the Bar graph to graph properly you must give 
	the exact same number of Cells in the x-axis range as the the y-axis. That way each x-value has a pairing
	y-value.In addition data must run parallel to one another, so if you grabbed data for the x-axis from
	A1-A4 then, the y-axis must pull all of its values from one column as well. (i.e. B1-B4 would work, but
	B1-E1 would not.) The same rules apply if you were to grab your data organized in a horizontal format as
	well.

Design Decisions:
10/17-Pressing Enter or Tab will change the selection to the adjacent right. If at Column Z, 
	it will loop back to A on the next row.
10/19-Added a dialogue box that gives the reason for why a FormulaError occurs.
10/19-If you save over an already existing sprd file, a backup of the old file will be stored in the
	same loaction with " - backup" appended.
10/21- Created a bar chart tool that will take in a title, a range of x-values and a range of y-values
	and will output a bar chart graph with the inputted data and title.
	

External Code Resources
10/22 - No external code resources were used other than Microsoft's Documentation and the PS6 Demo provided to 
	us.

Build Guidelines:
-

Implementation Notes:
-

Problems
10/22 - We did not encounter any problems that we couldn't solve by thinking it over and experimenting.
