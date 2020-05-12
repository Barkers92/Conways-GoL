using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coways_Redisgn
{
    class NewRulesGame
    {
        private const int rows = 100;
        private const int column = 100;
        private const int cellSize = 7;
        private Grid oldGrid;

        int A = 255;
        int R = 255;
        int G = 255;
        int B = 255;

        public int overpop = 3;
        public int underpop = 2;
        public int rebirthpop = 3;


        //grid for heatmap
        private Grid heatMap;

        public NewRulesGame()
        {
            oldGrid = CreateGameGrid(rows, column);
            heatMap = CreateHeatGrid(rows, column);
        }


        //method for greating the game grid to play on
        private Grid CreateGameGrid(int rows, int columns)
        {
            int rowCount = 0;
            Grid Gamegrid = new Grid();

            for (int i = 0; i < rows; i++)
            {
                Gamegrid.AddRowBottom();
            }

            foreach (Row row in Gamegrid.rows)
            {
                for (int i = 0; i < columns; i++)
                {
                    row.AddCellRight(rowCount, i);
                }
                rowCount++;
            }

            return Gamegrid;
        }

        //method to create the games heatmap grid for analysis
        private Grid CreateHeatGrid(int rows, int columns)
        {
            int rowCount = 0;
            Grid heatgrid = new Grid();

            for (int i = 0; i < rows; i++)
            {
                heatgrid.AddRowBottom();
            }

            foreach (Row row in heatgrid.rows)
            {
                for (int i = 0; i < columns; i++)
                {
                    row.AddCellRight(rowCount, i);
                }
                rowCount++;
            }

            return heatgrid;
        }


        public void Draw(Graphics graphics)
        {
            Point gameGridStartPoint = new Point(5, 5);
            Point gameGridCurrentPoint = gameGridStartPoint;

            Point heatMapStartPoint = new Point(1050, 5);
            Point heatMapCurrentPoint = heatMapStartPoint;




            foreach (Row row in oldGrid.rows)
            {
                foreach (Cell cell in row.cells)
                {
                    Rectangle cellRect = new Rectangle(gameGridCurrentPoint.X, gameGridCurrentPoint.Y, cellSize, cellSize);
                    cell.rectangle = cellRect;


                    SolidBrush Dead = new SolidBrush(Color.FromArgb(255, 255, cell.B, cell.G));






                    if (cell.alive == true)
                    {
                        graphics.FillRectangle(Brushes.Black, cellRect);
                        Cell.Alive = "true";

                    }
                    else
                    {
                        Cell.Alive = "false";

                        graphics.FillRectangle(Dead, cellRect);
                        cell.alive = false;

                    }


                    gameGridCurrentPoint = new Point((gameGridCurrentPoint.X + cellSize + 1), gameGridCurrentPoint.Y);
                }
                gameGridCurrentPoint = new Point(gameGridStartPoint.X, (gameGridCurrentPoint.Y + cellSize + 1));
            }


        }

        public void NextGeneration()
        {
            
            foreach (Row row in oldGrid.rows)
            {
                foreach (Cell cell in row.cells)
                {
                    Cell origionalCell = cell;
                    
                    bool topleft = false;
                    bool topmiddle = false;
                    bool topright = false;
                    bool middleleft = false;
                    bool middleright = false;
                    bool lowerleft = false;
                    bool lowermiddle = false;
                    bool lowerright = false;

                    try
                    {

                        Row currentRow = oldGrid.rows[cell.rowNumber];


                        if (cell.rowNumber != 0)
                        {

                            Row topRow = oldGrid.rows[cell.rowNumber - 1];
                            Cell topMiddle = topRow.cells[cell.columnNumber];

                            if (topMiddle.alive)
                            {

                                topmiddle = true;
                            }

                            if (cell.columnNumber != 0)
                            {
                                Cell TopLeft = topRow.cells[cell.columnNumber - 1];

                                if (TopLeft.alive)
                                {

                                    topleft = true;
                                }

                                if (cell.columnNumber != topRow.cells.Count - 1)
                                {
                                    Cell topRight = topRow.cells[cell.columnNumber + 1];

                                    if (topRight.alive)
                                    {

                                        topright = true;
                                    }
                                }
                            }
                        }



                        if (cell.columnNumber != 0)
                        {
                            Cell middleLeft = currentRow.cells[cell.columnNumber - 1];

                            if (middleLeft.alive)
                            {

                                middleleft = true;
                            }
                        }

                        if (cell.columnNumber != (currentRow.cells.Count - 1))
                        {
                            Cell middleRight = currentRow.cells[cell.columnNumber + 1];

                            if (middleRight.alive)
                            {

                                middleright = true;
                            }
                        }

                        if (cell.rowNumber != (oldGrid.rows.Count - 1))
                        {
                            Row bottomRow = oldGrid.rows[cell.rowNumber + 1];
                            Cell bottomMiddle = bottomRow.cells[cell.columnNumber];

                            if (bottomMiddle.alive)
                            {

                                lowermiddle = true;
                            }

                            if (cell.columnNumber != 0)
                            {
                                Cell bottomLeft = bottomRow.cells[cell.columnNumber - 1];
                                if (bottomLeft.alive)
                                {

                                    lowerleft = true;
                                }
                            }

                            if (cell.columnNumber != (bottomRow.cells.Count - 1))
                            {
                                Cell bottomRight = bottomRow.cells[cell.columnNumber + 1];
                                if (bottomRight.alive)
                                {

                                    lowerright = true;
                                }
                            }
                        }
                    }
                    catch { }






                    int aliveCount = NearAliveCount(cell);

                    if (aliveCount < underpop && cell.alive)
                    {
                        cell.nextAlive = true;
                    }
                    else if (aliveCount > overpop && cell.alive)
                    {
                        cell.nextAlive = true;
                    }
                    else if (aliveCount == rebirthpop && cell.alive == false)
                    {
                        cell.nextAlive = false;
                    }
                    else
                    {
                        cell.nextAlive = cell.alive;
                    }


                    //attempting to call the new boundry rules in a differnt order and call the setCellAlive using a different method.
                    int rownumber = cell.rowNumber;
                    int columnnumber = cell.columnNumber;
                    
                    if (cell.nextAlive == true)
                    {


                        if (topleft == false && topmiddle == false && topright == false && middleleft == false && middleright == false && lowerleft == false && lowermiddle == false && lowerright == false)
                        {
                            cell.nextAlive = true;
                        }

                        if (topleft == true && topmiddle == true && topright == true && middleleft == true && middleright == true && lowerleft == true && lowermiddle == true && lowerright == true)
                        {

                            cell.nextAlive = false;
                        }

                        if (topmiddle)
                        {
                           rownumber = rownumber + 1;
                           Console.WriteLine("loop top middle");
                           cell.nextAlive = false;
                            setCellAlive(rownumber, columnnumber);
                        }

                        if(middleleft)
                        {
                        columnnumber = columnnumber + 1;
                        Console.WriteLine("loop middle left");
                        cell.nextAlive = false;
                            setCellAlive(rownumber, columnnumber);
                        }

                        if(middleright == true)
                        {
                         columnnumber = columnnumber - 1;
                         Console.WriteLine("loop middle right");
                         cell.nextAlive = false;
                            setCellAlive(rownumber, columnnumber);
                        }

                        if(lowermiddle)
                        {
                        rownumber = rownumber - 1;
                        Console.WriteLine("loop middle left");
                        cell.nextAlive = false;
                            setCellAlive(rownumber, columnnumber);
                        }
                     
                    // Console.WriteLine("row = " + rownumber + "col = " + columnnumber);
                        
                        
                        
                    }

                    //else
                   // {
                   //     cell.nextAlive = false;
                  //  }
                    

                    // an attempt at creating distance based rules using boolean values to setect which side of a cell has alive cells this caused issues with cells shooting across the screen

                    /*
                     
                        if (topleft == true && topmiddle == true && topright == true && middleleft == true && middleright == true && lowerleft == true && lowermiddle == true && lowerright == true)
                        {
                            
                            cell.nextAlive = false;
                        }

                        if (topleft == true && topmiddle == false && topright == false && middleleft == false && middleright == false && lowerleft == false && lowermiddle == false && lowerright == false)
                        {
                            setCellAlive((cell.rowNumber + 1), (cell.columnNumber-1));
                            cell.nextAlive = false;
                            Console.WriteLine("top left" + (cell.rowNumber + 1) + "adwaD" + (cell.columnNumber - 1));
                        }
                        
                        
                        if (topleft == false && topmiddle == true && topright == false && middleleft == false && middleright == false && lowerleft == false && lowermiddle == false && lowerright == false)
                        {
                            setCellAlive(cell.rowNumber++, cell.columnNumber);
                            cell.nextAlive = false;
                        }
                        
                      if (topleft == false && topmiddle == false && topright == true && middleleft == false && middleright == false && lowerleft == false && lowermiddle == false && lowerright == false)
                      {

                          setCellAlive(cell.rowNumber + 1, cell.columnNumber);
                          cell.nextAlive = false;
                      }
                        
                        if (topleft == false && topmiddle == false && topright == false && middleleft == true && middleright == false && lowerleft == false && lowermiddle == false && lowerright == false)
                        {
                            setCellAlive(cell.rowNumber - 5 , cell.columnNumber);
                            cell.nextAlive = false;
                        }

                    if (topleft == false && topmiddle == false && topright == false && middleleft == false && middleright == true && lowerleft == false && lowermiddle == false && lowerright == false)
                    {
                        setCellAlive(cell.rowNumber - 1, cell.columnNumber);
                        cell.nextAlive = false;
                    }
                    if (topleft == false && topmiddle == false && topright == false && middleleft == false && middleright == false && lowerleft == false && lowermiddle == false && lowerright == false)
                    {
                        cell.nextAlive = false;
                    }
                        
                        if (topleft == false && topmiddle == false && topright == false && middleleft == false && middleright == false && lowerleft == true && lowermiddle == false && lowerright == false)
                        {
                            setCellAlive(cell.rowNumber - 1, cell.columnNumber + 1);
                            cell.nextAlive = false;
                        }

                        else if (topleft == false && topmiddle == false && topright == false && middleleft == false && middleright == false && lowerleft == false && lowermiddle == true && lowerright == false)
                        {
                            setCellAlive(cell.rowNumber - 1, cell.columnNumber);
                            cell.nextAlive = false;
                        }

                          if (topleft == false && topmiddle == false && topright == false && middleleft == false && middleright == false && lowerleft == false && lowermiddle == false && lowerright == true)
                          {
                              setCellAlive(cell.rowNumber - 1, cell.columnNumber - 1);
                              cell.nextAlive = false;
                          }

                           if (topleft == true && topmiddle == true && topright == false && middleleft == false && middleright == false && lowerleft == false && lowermiddle == false && lowerright == false)
                           {
                               setCellAlive(cell.rowNumber + 1, cell.columnNumber + 1);
                               cell.nextAlive = false;
                           }

                           else if (topleft == true && topmiddle == false && topright == true && middleleft == false && middleright == false && lowerleft == false && lowermiddle == false && lowerright == false)
                           {
                               setCellAlive(cell.rowNumber + 1, cell.columnNumber);
                               cell.nextAlive = false;
                           }

                         else if (topleft == true && topmiddle == false && topright == false && middleleft == true && middleright == false && lowerleft == false && lowermiddle == false && lowerright == false)
                         {
                             setCellAlive(cell.rowNumber + 1, cell.columnNumber + 1);
                             cell.nextAlive = true;
                         }
                         else if (topleft == true && topmiddle == false && topright == false && middleleft == false && middleright == true && lowerleft == false && lowermiddle == false && lowerright == false)
                         {
                             setCellAlive(cell.rowNumber + 1, cell.columnNumber - 1);
                             cell.nextAlive = true;
                         }
                         else if (topleft == true && topmiddle == false && topright == false && middleleft == false && middleright == false && lowerleft == true && lowermiddle == false && lowerright == false)
                         {
                             setCellAlive(cell.rowNumber, cell.columnNumber + 1);
                             cell.nextAlive = true;
                         }
                         else if (topleft == true && topmiddle == false && topright == false && middleleft == false && middleright == false && lowerleft == false && lowermiddle == true && lowerright == false)
                         {
                             setCellAlive(cell.rowNumber - 1, cell.columnNumber + 1);
                             cell.nextAlive = true;
                         }
                         else if (topleft == true && topmiddle == false && topright == false && middleleft == false && middleright == false && lowerleft == false && lowermiddle == false && lowerright == true)
                         {
                             setCellAlive(cell.rowNumber + 1, cell.columnNumber - 1);
                             cell.nextAlive = true;
                         }
                         else if (topleft == true && topmiddle == true && topright == true && middleleft == false && middleright == false && lowerleft == false && lowermiddle == false && lowerright == false)
                         {
                             setCellAlive(cell.rowNumber + 1, cell.columnNumber);
                             cell.nextAlive = true;
                         }
                         else if (topleft == true && topmiddle == true && topright == false && middleleft == true && middleright == false && lowerleft == false && lowermiddle == false && lowerright == false)
                         {
                             setCellAlive(cell.rowNumber + 1, cell.columnNumber + 1);
                             cell.nextAlive = true;
                         }
                         else if (topleft == true && topmiddle == true && topright == false && middleleft == false && middleright == true && lowerleft == false && lowermiddle == false && lowerright == false)
                         {
                             setCellAlive(cell.rowNumber + 1, cell.columnNumber - 1);
                             cell.nextAlive = true;
                         }
                         else if (topleft == true && topmiddle == true && topright == false && middleleft == false && middleright == false && lowerleft == true && lowermiddle == false && lowerright == false)
                         {
                             setCellAlive(cell.rowNumber + 1, cell.columnNumber + 1);
                             cell.nextAlive = true;
                         }
                         else if (topleft == true && topmiddle == true && topright == false && middleleft == false && middleright == false && lowerleft == false && lowermiddle == true && lowerright == false)
                         {
                             //cannot escape
                             cell.nextAlive = false;
                         }
                         else if (topleft == true && topmiddle == true && topright == false && middleleft == false && middleright == false && lowerleft == false && lowermiddle == false && lowerright == true)
                         {
                             setCellAlive(cell.rowNumber + 1, cell.columnNumber - 1);
                             cell.nextAlive = true;
                         }
                         else if (topleft == true && topmiddle == true && topright == true && middleleft == true && middleright == false && lowerleft == false && lowermiddle == false && lowerright == false)
                         {
                             setCellAlive(cell.rowNumber + 1, cell.columnNumber + 1);
                             cell.nextAlive = true;
                         }
                         else if (topleft == true && topmiddle == true && topright == true && middleleft == false && middleright == true && lowerleft == false && lowermiddle == false && lowerright == false)
                         {
                             setCellAlive(cell.rowNumber + 1, cell.columnNumber - 1);
                             cell.nextAlive = true;
                         }
                         else if (topleft == true && topmiddle == true && topright == true && middleleft == false && middleright == false && lowerleft == true && lowermiddle == false && lowerright == false)
                         {
                             setCellAlive(cell.rowNumber + 1, cell.columnNumber + 1);
                             cell.nextAlive = true;
                         }
                         else if (topleft == true && topmiddle == true && topright == true && middleleft == false && middleright == false && lowerleft == false && lowermiddle == true && lowerright == false)
                         {
                             //cannot escape
                             cell.nextAlive = false;
                         }
                         else if (topleft == true && topmiddle == true && topright == true && middleleft == false && middleright == false && lowerleft == false && lowermiddle == false && lowerright == true)
                         {
                             setCellAlive(cell.rowNumber + 1, cell.columnNumber - 1);
                             cell.nextAlive = true;
                         }
                         else if (topleft == true && topmiddle == true && topright == true && middleleft == true && middleright == true && lowerleft == false && lowermiddle == false && lowerright == false)
                         {
                             //cannot escape
                             cell.nextAlive = false;
                         }
                         else if (topleft == true && topmiddle == true && topright == true && middleleft == true && middleright == false && lowerleft == true && lowermiddle == false && lowerright == false)
                         {
                             setCellAlive(cell.rowNumber + 1, cell.columnNumber + 1);
                             cell.nextAlive = true;
                         }
                         else if (topleft == false && topmiddle == false && topright == false && middleleft == false && middleright == false && lowerleft == false && lowermiddle == false && lowerright == false)
                         {




                             int dice = Form1.rnd.Next(1, 7);
                             Console.WriteLine("random number = " + dice);

                             if(dice == 1)
                                 setCellAlive(cell.rowNumber - 1, cell.columnNumber + 0);
                             else if (dice == 2)
                                 setCellAlive(cell.rowNumber + 0, cell.columnNumber - 1);
                             else if (dice == 3)
                                 setCellAlive(cell.rowNumber - 1, cell.columnNumber - 1);
                             else if (dice == 4)
                                 setCellAlive(cell.rowNumber + 1, cell.columnNumber + 0);
                             else if (dice == 5)
                                 setCellAlive(cell.rowNumber + 1, cell.columnNumber + 1);
                             else if (dice == 6)
                                 setCellAlive(cell.rowNumber + 1, cell.columnNumber - 1);
                             //cell.nextAlive = false;



                         }
                         else
                         {
                             //cannot escape
                             cell.nextAlive = false;
                         }
                         */



                    /*
                        if (topleft == true)
                        {
                            setCellAlive(cell.rowNumber + 1, cell.columnNumber + 1);
                            cell.nextAlive = false;
                        }

                        if (topmiddle == true)
                        {
                            setCellAlive(cell.rowNumber + 1, cell.columnNumber);
                            cell.nextAlive = false;
                        }


                        if (topright == true)
                        {
                            setCellAlive(cell.rowNumber + 1, cell.columnNumber - 1);
                            cell.nextAlive = false;
                        }

                        if (middleleft == true)
                        {
                            setCellAlive(cell.rowNumber, cell.columnNumber + 1);
                            cell.nextAlive = false;
                        }
                        if (middleright == true)
                        {
                            setCellAlive(cell.rowNumber, cell.columnNumber - 1);
                            cell.nextAlive = false;
                        }

                        if (lowerleft == true)
                        {
                            setCellAlive(cell.rowNumber - 1, cell.columnNumber + 1);
                            cell.nextAlive = false;
                        }
                        if (lowermiddle == true)
                        {
                            setCellAlive(cell.rowNumber - 1, cell.columnNumber);
                            cell.nextAlive = false;
                        }
                        if (lowerright == true)
                        {
                            setCellAlive(cell.rowNumber - 1, cell.columnNumber - 1);
                            cell.nextAlive = false;
                        }

                */

                    /*
                    if (cell.alive == true)
                    {
                        if (topleft == true)
                        {
                            cell.columnNumber = cell.columnNumber + 1;
                            cell.rowNumber = cell.rowNumber + 1;
                        }
                         if (topmiddle == true)
                        {
                            cell.rowNumber = cell.rowNumber + 1;
                        }
                         if (topright == true)
                        {
                            cell.columnNumber = cell.columnNumber - 1;
                            cell.rowNumber = cell.rowNumber + 1;
                        }

                         if (middleleft == true)
                        {
                            cell.columnNumber = cell.columnNumber + 1;
                        }
                         if (middleright == true)
                        {
                            cell.columnNumber = cell.columnNumber - 1;
                        }

                         if (lowerleft == true)
                        {
                            cell.columnNumber = cell.columnNumber + 1;
                            cell.rowNumber = cell.rowNumber - 1;
                        }
                         if (lowermiddle == true)
                        {
                            cell.rowNumber = cell.rowNumber - 1;
                        }
                         if (lowerright == true)
                        {
                            cell.columnNumber = cell.columnNumber - 1;
                            cell.rowNumber = cell.rowNumber - 1;
                        }
                        try
                        {

                        Console.WriteLine("Row = " + cell.rowNumber + " Column = " + cell.columnNumber + " Alive = " + cell.alive);
                         // setCellAlive(cell.rowNumber, cell.columnNumber);
                        }
                        catch {  }
                    }
                    */


                }
            }
            //changes the cells to match the next itteration 
            foreach (Row row in oldGrid.rows)
            {
                foreach (Cell cell in row.cells)
                {
                    cell.alive = cell.nextAlive;
                }
            }
        }

        public void ClearHeat()
        {
            foreach (Row row in oldGrid.rows)
            {
                foreach (Cell cell in row.cells)
                {
                    cell.G = 255;
                    cell.B = 255;
                }
            }
        }

        //get the alive count of the surrounding cells
        public int NearAliveCount(Cell cell)
        {
            int aliveCount = 0;

            try
            {
                Row currentRow = oldGrid.rows[cell.rowNumber];
            
                if (cell.rowNumber != 0)
                {

                    Row topRow = oldGrid.rows[cell.rowNumber - 1];
                    Cell topMiddle = topRow.cells[cell.columnNumber];

                    if (topMiddle.alive)
                    {
                        aliveCount++;
                    }

                    if (cell.columnNumber != 0)
                    {
                        Cell TopLeft = topRow.cells[cell.columnNumber - 1];

                        if (TopLeft.alive)
                        {
                            aliveCount++;
                        }

                        if (cell.columnNumber != topRow.cells.Count - 1)
                        {
                            Cell topRight = topRow.cells[cell.columnNumber + 1];

                            if (topRight.alive)
                            {
                                aliveCount++;
                            }
                        }
                    }
                }

                if (cell.columnNumber != 0)
                {
                    Cell middleLeft = currentRow.cells[cell.columnNumber - 1];

                    if (middleLeft.alive)
                    {
                        aliveCount++;
                    }
                }

                if (cell.columnNumber != (currentRow.cells.Count - 1))
                {
                    Cell middleRight = currentRow.cells[cell.columnNumber + 1];

                    if (middleRight.alive)
                    {
                        aliveCount++;
                    }
                }

                if (cell.rowNumber != (oldGrid.rows.Count - 1))
                {
                    Row bottomRow = oldGrid.rows[cell.rowNumber + 1];
                    Cell bottomMiddle = bottomRow.cells[cell.columnNumber];

                    if (bottomMiddle.alive)
                    {
                        aliveCount++;
                    }

                    if (cell.columnNumber != 0)
                    {
                        Cell bottomLeft = bottomRow.cells[cell.columnNumber - 1];
                        if (bottomLeft.alive)
                        {
                            aliveCount++;
                        }
                    }

                    if (cell.columnNumber != (bottomRow.cells.Count - 1))
                    {
                        Cell bottomRight = bottomRow.cells[cell.columnNumber + 1];
                        if (bottomRight.alive)
                        {
                            aliveCount++;
                        }
                    }
                }
            }
            catch { cell.alive = false; }
            return aliveCount;
        }
        //populates the grid with randomly alive or dead cells
        public void Random()
        {
            foreach (Row row in oldGrid.rows)
            {
                foreach (Cell cell in row.cells)
                {
                    int dice = Form1.rnd.Next(1, 3);

                    if (dice == 1)
                        cell.alive = false;
                    if (dice == 2)
                        cell.alive = true;
                    Console.WriteLine("randnum = " + dice);


                }
            }
        }
        //used by buttons to construct patterns
        internal void setCellAlive(int row, int column)
        {
            try
            {
                Row findRow = oldGrid.rows[row];
                Cell findCell = findRow.cells[column];
                if (findCell.alive)
                    findCell.alive = false;
                else
                    findCell.alive = true;
            }
            catch { }
           
            
        }
        //allows the user to select and deselect cells with mouse click
        public void ClickCell(int mouseX, int mouseY)
        {
            foreach (Row row in oldGrid.rows)
            {
                foreach (Cell cell in row.cells)
                {
                    if (cell.rectangle.Contains(mouseX, mouseY))
                    {
                        if (cell.alive == false)
                        {
                            cell.alive = true;
                            cell.nextAlive = true;
                        }
                        else
                        {
                            cell.alive = false;
                            cell.nextAlive = false;
                        }

                    }
                }
            }
        }

        public void Clear()
        {
            foreach (Row row in oldGrid.rows)
            {
                foreach (Cell cell in row.cells)
                {
                    cell.alive = false;
                }
            }
        }
    }
}