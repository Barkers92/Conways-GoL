using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coways_Redisgn
{
    class ClassicGame
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

        public ClassicGame()
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
                    int aliveCount = NearAliveCount(cell);
                    if (aliveCount < underpop && cell.alive)
                    {
                        cell.nextAlive = false;
                      //  if (Cell.G > 0)
                      //  {
                      //      Cell.G = Cell.G - 1;
                      //      Cell.B = Cell.B - 1;
                      //  }
                    }
                    else if (aliveCount > overpop && cell.alive)
                    {
                        cell.nextAlive = false;
                       // if (Cell.G > 0)
                       // {
                       //     Cell.G = Cell.G - 1;
                       //     Cell.B = Cell.B - 1;
                       // }
                    }
                    else if (aliveCount == rebirthpop && cell.alive == false)
                    {
                        cell.nextAlive = true;


                    }
                    else
                    {
                        cell.nextAlive = cell.alive;
                    }
                }
            }
            //changes the cells to match the next itteration 
            foreach (Row row in oldGrid.rows)
            {
                foreach (Cell cell in row.cells)
                {
                    if (cell.alive && cell.nextAlive == false)
                    {
                        if (cell.G > 0)
                        {
                            cell.G = cell.G - 5;
                            cell.B = cell.B - 5;
                        }
                    }
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
            Row currentRow = oldGrid.rows[cell.rowNumber];

            if (cell.rowNumber != 0)
            {

                Row topRow = oldGrid.rows[cell.rowNumber - 1];
                Cell topMiddle = topRow.cells[cell.columnNumber];

                if (topMiddle.alive)
                    aliveCount++;

                if (cell.columnNumber != 0)
                {
                    Cell TopLeft = topRow.cells[cell.columnNumber - 1];

                    if (TopLeft.alive)
                        aliveCount++;

                    if (cell.columnNumber != topRow.cells.Count - 1)
                    {
                        Cell topRight = topRow.cells[cell.columnNumber + 1];

                        if (topRight.alive)
                            aliveCount++;
                    }
                }
            }

            if (cell.columnNumber != 0)
            {
                Cell middleLeft = currentRow.cells[cell.columnNumber - 1];

                if (middleLeft.alive)
                    aliveCount++;
            }

            if (cell.columnNumber != (currentRow.cells.Count - 1))
            {
                Cell middleRight = currentRow.cells[cell.columnNumber + 1];

                if (middleRight.alive)
                    aliveCount++;
            }

            if (cell.rowNumber != (oldGrid.rows.Count - 1))
            {
                Row bottomRow = oldGrid.rows[cell.rowNumber + 1];
                Cell bottomMiddle = bottomRow.cells[cell.columnNumber];

                if (bottomMiddle.alive)
                    aliveCount++;

                if (cell.columnNumber != 0)
                {
                    Cell bottomLeft = bottomRow.cells[cell.columnNumber - 1];
                    if (bottomLeft.alive)
                        aliveCount++;
                }

                if (cell.columnNumber != (bottomRow.cells.Count - 1))
                {
                    Cell bottomRight = bottomRow.cells[cell.columnNumber + 1];
                    if (bottomRight.alive)
                        aliveCount++;
                }
            }

            return aliveCount;
        }

        internal void setCellAlive(int row, int column)
        {
            Row findRow = oldGrid.rows[row];
            Cell findCell = findRow.cells[column];
            if (findCell.alive)
                findCell.alive = false;
            else
            {
                findCell.alive = true;

            }
        }

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

        public void Random()
        {
            foreach (Row row in oldGrid.rows)
            {
                foreach (Cell cell in row.cells)
                {
                    int dice = Form1.rnd.Next(1, 3);

                    if(dice == 1)
                        cell.alive = false;
                    if(dice == 2)
                        cell.alive = true;
                    Console.WriteLine("randnum = " + dice);

                
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