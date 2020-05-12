using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coways_Redisgn
{
    //class used to define the Cells used by the program to populate the game grid
    class Cell
    {
        //used to determine the shade of red that the heatmap displays for this cell
        static public int aliveCount = 255;
        public bool alive { get; set; }
        public static string Alive = "null";
        internal bool nextAlive { get; set; }
        internal int rowNumber { get; set; }
        internal int columnNumber { get; set; }
        internal Rectangle rectangle { get; set; }
        internal SolidBrush shade { get; set; }



        //variables used by the Cell to store an indevidual Color for use with a heatmap
        internal int A = 0;
        internal int R = 0;
        internal int G = 255;
        internal int B = 255;
        

        public Cell (int row, int column)
        {
            shade = new SolidBrush(Color.FromArgb(A, R, G, B));
           
            //loop used by cell to determine if the color changes to a darker red
            if (Alive == "true")
            {
                if(aliveCount < 0)
                {
                    aliveCount = aliveCount - 1;
                    Console.WriteLine("New aliveCount = " + aliveCount);
                }
                Console.WriteLine("no change to alive count");
            }
            if (Alive == "false")
            {
                Console.WriteLine("inloop aliveCount = " + aliveCount);
            }

            rowNumber = row;
            columnNumber = column;
        }

    }
}
