using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coways_Redisgn
{
    //class used to build the rows of cells used in the game grid
    class Row
    {
        internal List<Cell> cells;

        internal Row()
        {
            cells = new List<Cell>();
        }

        internal void AddCellLeft(int row, int column)
        {
            cells.Insert(0, new Cell(row, column));
        }

        internal void AddCellRight(int row, int column)
        {
            cells.Add(new Cell(row, column));
        }
    }
}
