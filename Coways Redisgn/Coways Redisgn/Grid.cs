using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coways_Redisgn
{
    class Grid
    {
        //grid class used to great a grid comprised of rows populated by cells for the game

        internal List<Row> rows;

        internal Grid()
        {
            rows = new List<Row>();
        }

        internal void AddRowBottom()
        {
            rows.Add(new Row());
        }

        internal void AddRowTop()
        {
            rows.Insert(0, new Row());
        }
    }
}
