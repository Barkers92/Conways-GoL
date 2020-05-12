using System;
using System.Windows.Forms;

namespace Coways_Redisgn
{
    public partial class Form1 : Form
    {

        //initialise game modes
        ClassicGame CGame;
        NewRulesGame NRGame;
        //set default gamemode to classic conways
        bool gameModeClassic = true;
        bool gameModeNewRules = false;
        public static Random rnd = new Random();

        //ariable to keep track of current generation to be relayed to the user
        int generation;

       

        public Form1()
        {

            InitializeComponent();
            generation = 0;
            NRGame = new NewRulesGame();
            

            CGame = new ClassicGame();
            
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameModeClassic == true)
            {
                CGame.Draw(e.Graphics);
            }
            if (gameModeNewRules == true)
            {
                NRGame.Draw(e.Graphics);
            }
        }

        public void DrawTimer_Tick(object sender, EventArgs e)
        {
            if(gameModeClassic == true)
            {
                CGame.NextGeneration();
                generation++;
                GenerationLB.Text = "Generation:  " + generation;
                Invalidate();
            }
            if(gameModeNewRules == true)
            {
                NRGame.NextGeneration();
                generation++;
                GenerationLB.Text = "Generation:  " + generation;
                Invalidate();
            }
        }

        private void PlayBTN_Click(object sender, EventArgs e)
        {
            if(DrawTimer.Enabled)
            {
                DrawTimer.Stop();
                PlayBTN.Text = "Play";
            }
            else
            {
                DrawTimer.Interval = 500;
                DrawTimer.Start();
                PlayBTN.Text = "Pause";
            }
        }




        private void SetOverpopBtn_Click(object sender, EventArgs e)
        {
           
            int userSetOverpopLimit = Convert.ToInt32(OverPopTB.Text);
            Console.WriteLine("here it is = " + userSetOverpopLimit);

            if(gameModeClassic == true)
            {
                CGame.overpop = userSetOverpopLimit;
            }
            if(gameModeNewRules == true)
            {
                NRGame.overpop = userSetOverpopLimit;
            }


        }

        private void SetUnderpopBTN_Click(object sender, EventArgs e)
        {
            int userSetUnderpopLimit = Convert.ToInt32(UnderpopTB.Text);
            Console.WriteLine("here it is = " + userSetUnderpopLimit);

            if (gameModeClassic == true)
            {
                CGame.underpop = userSetUnderpopLimit;
            }
            if (gameModeNewRules == true)
            {
                NRGame.underpop = userSetUnderpopLimit;
            }
        }

        private void SetRebirthBTN_Click(object sender, EventArgs e)
        {
            int userSetRebirthLimit = Convert.ToInt32(RebirthPopTB.Text);
            Console.WriteLine("here it is = " + userSetRebirthLimit);

            if (gameModeClassic == true)
            {
                CGame.rebirthpop = userSetRebirthLimit;
            }
            if (gameModeNewRules == true)
            {
                NRGame.rebirthpop = userSetRebirthLimit;
            }
        }



        private void ClearBTN_Click(object sender, EventArgs e)
        {
            if (gameModeClassic == true)
            {
                CGame.Clear();
                Invalidate();
                DrawTimer.Stop();
                PlayBTN.Text = "Play";
                generation = 0;
                GenerationLB.Text = "Generation: " + generation;
            }
            if (gameModeNewRules == true)
            {
                NRGame.Clear();
                Invalidate();
                DrawTimer.Stop();
                PlayBTN.Text = "Play";
                generation = 0;
                GenerationLB.Text = "Generation: " + generation;
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (gameModeClassic == true)
            {
                CGame.ClickCell(e.X, e.Y);
                Invalidate();
            }
            if (gameModeNewRules == true)
            {
                NRGame.ClickCell(e.X, e.Y);
                Invalidate();
            }
        }




        private void PulsarBTN_Click(object sender, EventArgs e)
        {
            if (gameModeClassic == true)
            {
                CGame.Clear();
                Invalidate();
                DrawTimer.Stop();
                PlayBTN.Text = "Play";
                generation = 0;
                GenerationLB.Text = "Generation: " + generation;

                CGame.setCellAlive(19, 21);
                CGame.setCellAlive(19, 22);
                CGame.setCellAlive(19, 23);
                CGame.setCellAlive(19, 27);
                CGame.setCellAlive(19, 28);
                CGame.setCellAlive(19, 29);
                CGame.setCellAlive(24, 21);
                CGame.setCellAlive(24, 22);
                CGame.setCellAlive(24, 23);
                CGame.setCellAlive(24, 27);
                CGame.setCellAlive(24, 28);
                CGame.setCellAlive(24, 29);
                CGame.setCellAlive(26, 21);
                CGame.setCellAlive(26, 22);
                CGame.setCellAlive(26, 23);
                CGame.setCellAlive(26, 27);
                CGame.setCellAlive(26, 28);
                CGame.setCellAlive(26, 29);
                CGame.setCellAlive(31, 21);
                CGame.setCellAlive(31, 22);
                CGame.setCellAlive(31, 23);
                CGame.setCellAlive(31, 27);
                CGame.setCellAlive(31, 28);
                CGame.setCellAlive(31, 29);

                CGame.setCellAlive(21, 19);
                CGame.setCellAlive(22, 19);
                CGame.setCellAlive(23, 19);
                CGame.setCellAlive(27, 19);
                CGame.setCellAlive(28, 19);
                CGame.setCellAlive(29, 19);
                CGame.setCellAlive(21, 24);
                CGame.setCellAlive(22, 24);
                CGame.setCellAlive(23, 24);
                CGame.setCellAlive(27, 24);
                CGame.setCellAlive(28, 24);
                CGame.setCellAlive(29, 24);
                CGame.setCellAlive(21, 26);
                CGame.setCellAlive(22, 26);
                CGame.setCellAlive(23, 26);
                CGame.setCellAlive(27, 26);
                CGame.setCellAlive(28, 26);
                CGame.setCellAlive(29, 26);
                CGame.setCellAlive(21, 31);
                CGame.setCellAlive(22, 31);
                CGame.setCellAlive(23, 31);
                CGame.setCellAlive(27, 31);
                CGame.setCellAlive(28, 31);
                CGame.setCellAlive(29, 31);
            }
            if(gameModeNewRules == true)
            {
                    NRGame.Clear();
                    Invalidate();
                    DrawTimer.Stop();
                    PlayBTN.Text = "Play";
                    generation = 0;
                    GenerationLB.Text = "Generation: " + generation;

                    NRGame.setCellAlive(19, 21);
                    NRGame.setCellAlive(19, 22);
                    NRGame.setCellAlive(19, 23);
                    NRGame.setCellAlive(19, 27);
                    NRGame.setCellAlive(19, 28);
                    NRGame.setCellAlive(19, 29);
                    NRGame.setCellAlive(24, 21);
                    NRGame.setCellAlive(24, 22);
                    NRGame.setCellAlive(24, 23);
                    NRGame.setCellAlive(24, 27);
                    NRGame.setCellAlive(24, 28);
                    NRGame.setCellAlive(24, 29);
                    NRGame.setCellAlive(26, 21);
                    NRGame.setCellAlive(26, 22);
                    NRGame.setCellAlive(26, 23);
                    NRGame.setCellAlive(26, 27);
                    NRGame.setCellAlive(26, 28);
                    NRGame.setCellAlive(26, 29);
                    NRGame.setCellAlive(31, 21);
                    NRGame.setCellAlive(31, 22);
                    NRGame.setCellAlive(31, 23);
                    NRGame.setCellAlive(31, 27);
                    NRGame.setCellAlive(31, 28);
                    NRGame.setCellAlive(31, 29);

                    NRGame.setCellAlive(21, 19);
                    NRGame.setCellAlive(22, 19);
                    NRGame.setCellAlive(23, 19);
                    NRGame.setCellAlive(27, 19);
                    NRGame.setCellAlive(28, 19);
                    NRGame.setCellAlive(29, 19);
                    NRGame.setCellAlive(21, 24);
                    NRGame.setCellAlive(22, 24);
                    NRGame.setCellAlive(23, 24);
                    NRGame.setCellAlive(27, 24);
                    NRGame.setCellAlive(28, 24);
                    NRGame.setCellAlive(29, 24);
                    NRGame.setCellAlive(21, 26);
                    NRGame.setCellAlive(22, 26);
                    NRGame.setCellAlive(23, 26);
                    NRGame.setCellAlive(27, 26);
                    NRGame.setCellAlive(28, 26);
                    NRGame.setCellAlive(29, 26);
                    NRGame.setCellAlive(21, 31);
                    NRGame.setCellAlive(22, 31);
                    NRGame.setCellAlive(23, 31);
                    NRGame.setCellAlive(27, 31);
                    NRGame.setCellAlive(28, 31);
                    NRGame.setCellAlive(29, 31);
                
            }
        }


            private void ClassicGameModeBTN_Click(object sender, EventArgs e)
        {
            if(gameModeClassic == false)
            {
                gameModeNewRules = false;
                gameModeClassic = true;
                Console.WriteLine("gamemode classic Rules");
                Invalidate();
            }
        }

        private void NewRulesBTN_Click(object sender, EventArgs e)
        {
            if(gameModeNewRules == false)
            {
                gameModeClassic = false;
                gameModeNewRules = true;
                Console.WriteLine("gamemode New Rules");
                Invalidate();

            }
        }

        private void LionHeartBTN_Click(object sender, EventArgs e)
        {
            if (gameModeClassic == true)
            {
                CGame.Clear();
                Invalidate();
                DrawTimer.Stop();
                PlayBTN.Text = "Play";
                generation = 0;
                GenerationLB.Text = "Generation: " + generation;
                //code to preset the specified cells to alive so the user doesnt need to enter them manually
                CGame.setCellAlive(21, 23);
                CGame.setCellAlive(21, 24);
                CGame.setCellAlive(21, 26);
                CGame.setCellAlive(21, 27);
                CGame.setCellAlive(22, 22);
                CGame.setCellAlive(22, 25);
                CGame.setCellAlive(22, 28);
                CGame.setCellAlive(23, 22);
                CGame.setCellAlive(23, 28);
                CGame.setCellAlive(24, 22);
                CGame.setCellAlive(24, 28);
                CGame.setCellAlive(25, 23);
                CGame.setCellAlive(25, 27);
                CGame.setCellAlive(26, 24);
                CGame.setCellAlive(26, 26);
                CGame.setCellAlive(27, 25);
            }
            if (gameModeNewRules == true)
            {
                NRGame.Clear();
                Invalidate();
                DrawTimer.Stop();
                PlayBTN.Text = "Play";
                generation = 0;
                GenerationLB.Text = "Generation: " + generation;
                //code to preset the specified cells to alive so the user doesnt need to enter them manually
                NRGame.setCellAlive(21, 23);
                NRGame.setCellAlive(21, 24);
                NRGame.setCellAlive(21, 26);
                NRGame.setCellAlive(21, 27);
                NRGame.setCellAlive(22, 22);
                NRGame.setCellAlive(22, 25);
                NRGame.setCellAlive(22, 28);
                NRGame.setCellAlive(23, 22);
                NRGame.setCellAlive(23, 28);
                NRGame.setCellAlive(24, 22);
                NRGame.setCellAlive(24, 28);
                NRGame.setCellAlive(25, 23);
                NRGame.setCellAlive(25, 27);
                NRGame.setCellAlive(26, 24);
                NRGame.setCellAlive(26, 26);
                NRGame.setCellAlive(27, 25);
            }
        }

        private void ShurikenBTN_Click(object sender, EventArgs e)
        {
            if (gameModeClassic == true)
            {
                CGame.Clear();
                Invalidate();
                DrawTimer.Stop();
                PlayBTN.Text = "Play";
                generation = 0;
                GenerationLB.Text = "Generation: " + generation;

                CGame.setCellAlive(20, 26);
                CGame.setCellAlive(20, 27);
                CGame.setCellAlive(21, 23);
                CGame.setCellAlive(22, 22);
                CGame.setCellAlive(22, 24);
                CGame.setCellAlive(22, 27);
                CGame.setCellAlive(22, 28);
                CGame.setCellAlive(23, 20);
                CGame.setCellAlive(23, 22);
                CGame.setCellAlive(23, 24);
                CGame.setCellAlive(23, 25);
                CGame.setCellAlive(23, 26);
                CGame.setCellAlive(23, 29);
                CGame.setCellAlive(24, 20);
                CGame.setCellAlive(24, 23);
                CGame.setCellAlive(24, 24);
                CGame.setCellAlive(24, 25);
                CGame.setCellAlive(24, 26);
                CGame.setCellAlive(24, 27);
                CGame.setCellAlive(24, 28);
                CGame.setCellAlive(25, 23);
                CGame.setCellAlive(25, 24);
                CGame.setCellAlive(25, 26);
                CGame.setCellAlive(25, 27);
                CGame.setCellAlive(26, 22);
                CGame.setCellAlive(26, 23);
                CGame.setCellAlive(26, 24);
                CGame.setCellAlive(26, 25);
                CGame.setCellAlive(26, 26);
                CGame.setCellAlive(26, 27);
                CGame.setCellAlive(26, 30);
                CGame.setCellAlive(27, 21);
                CGame.setCellAlive(27, 24);
                CGame.setCellAlive(27, 25);
                CGame.setCellAlive(27, 26);
                CGame.setCellAlive(27, 28);
                CGame.setCellAlive(27, 30);
                CGame.setCellAlive(28, 22);
                CGame.setCellAlive(28, 23);
                CGame.setCellAlive(28, 26);
                CGame.setCellAlive(28, 28);
                CGame.setCellAlive(29, 27);
                CGame.setCellAlive(30, 23);
                CGame.setCellAlive(30, 24);
            }
            if (gameModeNewRules)
            {
                NRGame.Clear();
                Invalidate();
                DrawTimer.Stop();
                PlayBTN.Text = "Play";
                generation = 0;
                GenerationLB.Text = "Generation: " + generation;

                NRGame.setCellAlive(20, 26);
                NRGame.setCellAlive(20, 27);
                NRGame.setCellAlive(21, 23);
                NRGame.setCellAlive(22, 22);
                NRGame.setCellAlive(22, 24);
                NRGame.setCellAlive(22, 27);
                NRGame.setCellAlive(22, 28);
                NRGame.setCellAlive(23, 20);
                NRGame.setCellAlive(23, 22);
                NRGame.setCellAlive(23, 24);
                NRGame.setCellAlive(23, 25);
                NRGame.setCellAlive(23, 26);
                NRGame.setCellAlive(23, 29);
                NRGame.setCellAlive(24, 20);
                NRGame.setCellAlive(24, 23);
                NRGame.setCellAlive(24, 24);
                NRGame.setCellAlive(24, 25);
                NRGame.setCellAlive(24, 26);
                NRGame.setCellAlive(24, 27);
                NRGame.setCellAlive(24, 28);
                NRGame.setCellAlive(25, 23);
                NRGame.setCellAlive(25, 24);
                NRGame.setCellAlive(25, 26);
                NRGame.setCellAlive(25, 27);
                NRGame.setCellAlive(26, 22);
                NRGame.setCellAlive(26, 23);
                NRGame.setCellAlive(26, 24);
                NRGame.setCellAlive(26, 25);
                NRGame.setCellAlive(26, 26);
                NRGame.setCellAlive(26, 27);
                NRGame.setCellAlive(26, 30);
                NRGame.setCellAlive(27, 21);
                NRGame.setCellAlive(27, 24);
                NRGame.setCellAlive(27, 25);
                NRGame.setCellAlive(27, 26);
                NRGame.setCellAlive(27, 28);
                NRGame.setCellAlive(27, 30);
                NRGame.setCellAlive(28, 22);
                NRGame.setCellAlive(28, 23);
                NRGame.setCellAlive(28, 26);
                NRGame.setCellAlive(28, 28);
                NRGame.setCellAlive(29, 27);
                NRGame.setCellAlive(30, 23);
                NRGame.setCellAlive(30, 24);
            }
        }

        private void nextGenBTN_Click(object sender, EventArgs e)
        {
            int tickTimer = 0;
            
            if (gameModeClassic == true && tickTimer == 0)
            {
                CGame.NextGeneration();
                generation++;
                GenerationLB.Text = "Generation:  " + generation;
                tickTimer++;
                Invalidate();
            }
            if (gameModeNewRules == true && tickTimer == 0)
            {
                NRGame.NextGeneration();
                generation++;
                GenerationLB.Text = "Generation:  " + generation;
                tickTimer++;
                Invalidate();
            }
        }

        private void GliderBTN_Click(object sender, EventArgs e)
        {
           
                if (gameModeClassic == true)
                {
                    CGame.Clear();
                    Invalidate();
                    DrawTimer.Stop();
                    PlayBTN.Text = "Play";
                    generation = 0;
                    GenerationLB.Text = "Generation: " + generation;

                    CGame.setCellAlive(1, 2);
                    CGame.setCellAlive(2, 3);
                    CGame.setCellAlive(3, 1);
                    CGame.setCellAlive(3, 2);
                    CGame.setCellAlive(3, 3);
                }
                if (gameModeNewRules == true)
                {
                    NRGame.Clear();
                    Invalidate();
                    DrawTimer.Stop();
                    PlayBTN.Text = "Play";
                    generation = 0;
                    GenerationLB.Text = "Generation: " + generation;

                    NRGame.setCellAlive(1, 2);
                    NRGame.setCellAlive(2, 3);
                    NRGame.setCellAlive(3, 1);
                    NRGame.setCellAlive(3, 2);
                    NRGame.setCellAlive(3, 3);
                }
            
        }

        private void RandomBTN_Click(object sender, EventArgs e)
        {
            if (gameModeClassic == true)
            {
                CGame.Clear();
                Invalidate();
                DrawTimer.Stop();
                PlayBTN.Text = "Play";
                generation = 0;
                GenerationLB.Text = "Generation: " + generation;

                CGame.Random();
            }
            if (gameModeNewRules == true)
            {
                NRGame.Clear();
                Invalidate();
                DrawTimer.Stop();
                PlayBTN.Text = "Play";
                generation = 0;
                GenerationLB.Text = "Generation: " + generation;

                NRGame.Random();
            }
        }

        private void clearHeatBTN_Click(object sender, EventArgs e)
        {
            if (gameModeClassic == true)
            {
                CGame.ClearHeat();
              
            }
            if (gameModeNewRules == true)
            {
                NRGame.ClearHeat();
                
            }
        }
    }
}
