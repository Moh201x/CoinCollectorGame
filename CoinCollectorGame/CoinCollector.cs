using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FCTEST2
{
    public partial class CoinCollector : Form
    {
        bool right, left, Up, Down; // For Player Movments
        int player_speed = 16; //Player Speed
        int Duration = 60; //60 second
        Random rand = new Random();
        int goldTime = 70;
        int fruitStart = 1;
        Random PointX = new Random();
        Dictionary<int, PictureBox> Fruity = new Dictionary<int, PictureBox>();
        Dictionary<int, PictureBox> Fruity1st = new Dictionary<int, PictureBox>();
        public int ScoreCounter = 0;
        int bombing = 0;
        List<Point> points = new List<Point>();
        List<Image> player_img = new List<Image>();
        bool check = false;
        List<PictureBox> fpics = new List<PictureBox>();
        List<Point> si = new List<Point>();
        PictureBox fruit;
        int Level_Duration = 2;
        int pbDue;
        bool repeat = true;
        int clocking=0;
        public static List<Keys> steps=new List<Keys>();

        void game_result()
        {

            if (LevelValue.Text != "1")
                foreach (KeyValuePair<int, PictureBox> fruit in Fruity)
                {
                    if (player_p1.Bounds.IntersectsWith(fruit.Value.Bounds))
                    {
                        fruit.Value.Visible = false;
                        int x = 0, y = 0;
                        RandAxis(ref x, ref y);
                        fruit.Value.Location = new Point(x, y);
                        si.Add(fruit.Value.Location);
                        if (fruit.Value.Tag != "bom")
                        {
                            ScoreCounter += fruit.Key;
                        }

                        if (fruit.Value.Tag == "cloc")
                        {
                            Duration += 20; clocking++;
                        }
                        else if (fruit.Value.Tag == "ba")
                        {
                            player_p1.Location = new Point(449, 217);
                        }
                        else if (fruit.Value.Tag == "bom")
                        {
                            bombing += 1;
                            if (bombing == 1)
                                x1.Visible = true;
                            else if (bombing == 2)
                                x2.Visible = true;
                            else if (bombing == 3)
                                x3.Visible = true;
                            if (bombing >= 3)
                            {
                                pbDue = Duration;
                                Game_Over();
                            }
                        }



                        ScoreValue.Text = ScoreCounter.ToString();

                    }
                }

            else

                foreach (KeyValuePair<int, PictureBox> fruit in Fruity1st)
                {
                    if (player_p1.Bounds.IntersectsWith(fruit.Value.Bounds))
                    {
                        fruit.Value.Visible = false;
                        int x = 0, y = 0;
                        RandAxis(ref x, ref y);
                        fruit.Value.Location = new Point(x, y);
                        ScoreCounter += fruit.Key;

                        ScoreValue.Text = ScoreCounter.ToString();

                    }
                }


        }
        public void Game_Over()
        {
            gol.Visible = false;
            silve.Visible = false;
            bronz.Visible = false;
            tra.Visible = false;
            barrie.Visible = false;
            skul.Visible = false;
            bom.Visible = false;
            sta.Visible = false;
            cloc.Visible = false;
            gameoverpic.Visible = true;
            restartb.Visible = true;
            if (repeat)
                playbb.Visible = true;
            player_p1.Location = new Point(449, 366);
            player_p1.Image = FCTEST2.Properties.Resources.Front;
            timer1.Stop();
            timer2.Stop();
            Timers.Stop();
        }
        public void winnerr()
        {
            gol.Visible = false;
            silve.Visible = false;
            bronz.Visible = false;
            tra.Visible = false;
            barrie.Visible = false;
            skul.Visible = false;
            bom.Visible = false;
            sta.Visible = false;
            cloc.Visible = false;
            winp.Visible = true;
            fire1.Visible = true;
            fire2.Visible = true;
            fire3.Visible = true;
            fire4.Visible = true;
            restartb.Visible = true;
            playbb.Visible = true;
            player_p1.Location = new Point(449, 366);
            timer1.Stop();
            timer2.Stop();
            Timers.Enabled = false;
        }
        public CoinCollector()
        {
            InitializeComponent();
            //level1---------------
            Fruity1st.Add(5, bronz);
            Fruity1st.Add(20, gol);
            Fruity1st.Add(10, silve);

            //level2,3--------------
            Fruity.Add(20, gol);
            Fruity.Add(10, silve);
            Fruity.Add(5, bronz);
            Fruity.Add(-10, tra);
            Fruity.Add(-5, barrie);
            Fruity.Add(-15, skul);
            Fruity.Add(-20, bom);
            Fruity.Add(15, sta);
            Fruity.Add(0, cloc);


            //setting fruits
            settingFruits();



        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                right = true;

            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }
            if (e.KeyCode == Keys.Up)
                Up = true;
            if (e.KeyCode == Keys.Down)
                Down = true;

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                player_p1.Image = FCTEST2.Properties.Resources.RightG;
                right = false;
                steps.Add(e.KeyCode);
            }

            if (e.KeyCode == Keys.Left)
            {
                left = false;
                player_p1.Image = FCTEST2.Properties.Resources.LeftG;
                steps.Add(e.KeyCode);

            }

            if (e.KeyCode == Keys.Up)
            {
                Up = false;
                steps.Add(e.KeyCode);
            }

            if (e.KeyCode == Keys.Down)
            {
                Down = false;
                player_p1.Image = FCTEST2.Properties.Resources.FrontG;
                steps.Add(e.KeyCode);
            }
        }


        private void Move_Player()
        {
            if (left && player_p1.Left > 10)
            {
                player_p1.Left -= player_speed;
                player_p1.Image = FCTEST2.Properties.Resources.Left;
            }
            if (right && player_p1.Left < ProfileName.Width - player_p1.Width)
            {
                player_p1.Left += player_speed;
                player_p1.Image = FCTEST2.Properties.Resources.Right;
            }
            if (Up && player_p1.Top > 0)
            {
                player_p1.Top -= player_speed;
                player_p1.Image = FCTEST2.Properties.Resources.Back;
            }
            if (Down && player_p1.Top < ProfileName.Height - player_p1.Height)
            {
                player_p1.Top += player_speed;
                player_p1.Image = FCTEST2.Properties.Resources.Front;
            }
        }
        private Color RandColor()
        {
            List<Color> Rc = new List<Color>();
            Rc.Add(Color.LightGray);
            Rc.Add(Color.SkyBlue);
            Rc.Add(Color.LightGreen);
            Rc.Add(Color.LightPink);
            Rc.Add(Color.Coral);
            Rc.Add(Color.YellowGreen);
            return Rc[rand.Next(0, 6)];
        }

        private void settingFruits()
        {
            //setting fruits randomly at the start
            gol.Visible = false;
            silve.Visible = false;
            bronz.Visible = false;
            tra.Visible = false;
            barrie.Visible = false;
            skul.Visible = false;
            bom.Visible = false;
            sta.Visible = false;
            cloc.Visible = false;

            int x = 0, y = 0;
            RandAxis(ref x, ref y);
            gol.Location = new Point(x, y);
            int xS = 0, yS = 0;
            RandAxis(ref xS, ref yS);
            silve.Location = new Point(xS, yS);
            int xB = 0, yB = 0;
            RandAxis(ref xB, ref yB);
            bronz.Location = new Point(xB, yB);
            int xT = 0, yT = 0;
            RandAxis(ref xT, ref yT);
            tra.Location = new Point(xT, yT);
            int xBA = 0, yBA = 0;
            RandAxis(ref xBA, ref yBA);
            barrie.Location = new Point(xBA, yBA);
            int xSK = 0, ySK = 0;
            RandAxis(ref xSK, ref ySK);
            skul.Location = new Point(xSK, ySK);
            int xBO = 0, yBO = 0;
            RandAxis(ref xBO, ref yBO);
            bom.Location = new Point(xBO, yBO);
            int xST = 0, yST = 0;
            RandAxis(ref xST, ref yST);
            sta.Location = new Point(xST, yST);
            int xC = 0, yC = 0;
            RandAxis(ref xC, ref yC);
            cloc.Location = new Point(xC, yC);
        }
        private PictureBox RandFruit(bool bol)
        {
            // true for levels higher than 1, false for level 1


            if (bol)
            {
                return Fruity.ElementAt(rand.Next(0, 9)).Value;
            }
            else
            {
                return Fruity1st.ElementAt(rand.Next(0, 3)).Value;
            }

        }


        private void RandAxis(ref int x, ref int y)
        {
            x = PointX.Next(20, 870);
            y = PointX.Next(20, 330);
        }

        private void ticks()
        {
            goldTime--;
            if (LevelValue.Text.Equals("1"))
                fruit = RandFruit(false);
            else
                fruit = RandFruit(true);

            if (goldTime % 10 == 0)
            {
                fruit.Visible = false;
                int x = 0, y = 0;
                RandAxis(ref x, ref y);
                fruit.Location = new Point(x, y);
            }
            else
                fruit.Visible = true;
            fpics.Add(fruit);
            /* si.Add(fruit.Location);*/

            if (Duration == 0)
            {
                Timers.Stop();

            }
        }





        //<Level3>


        private void Timers_Tick(object sender, EventArgs e)
        {
            ticks();
            ticks();
            ticks();
            si.Add(fruit.Location);

        }

        private void StartAgain()
        {
            Duration = 60;
            ScoreValue.Text = "0";
            fruitStart = 1;
            ScoreCounter = 0;
            bombing = 0;
            x1.Visible = false;
            x2.Visible = false;
            x3.Visible = false;
            clocking = 0;
            points = new List<Point>();
            player_img = new List<Image>();
            fpics = new List<PictureBox>();
            si = new List<Point>();
            settingFruits();
            timer1.Start();
            timer2.Start();
        }


        private void restartb_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        //</Level3>


        private void timer2_Tick(object sender, EventArgs e)
        {
            TimeValue.ForeColor = RandColor();
            Duration = Duration - 1;
            TimeValue.Text = (Duration).ToString() + "s";
            if (Duration == 0)
            {
                timer1.Stop();
                timer2.Stop();

                //<update Level>
                if (LevelValue.Text == "1")
                {
                    if (ScoreCounter >= 300)
                    {
                        LevelValue.Text = "2";
                        timer5.Enabled = true;
                        levelup.Visible = true;
                        StartAgain();
                    }
                    else
                        Game_Over();

                }
                else if (LevelValue.Text == "2")
                {
                    if (ScoreCounter >= 150)
                    {
                        LevelValue.Text = "3";
                        timer5.Enabled = true;
                        levelup.Visible = true;
                        StartAgain();
                    }
                    else
                    {
                        Game_Over();
                    }

                }
                else
                {
                    if (ScoreCounter >= 100)
                    {
                        winnerr();
                    }
                    else
                    {
                        Game_Over();
                    }
                }

                //this.Close();

            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Move_Player();
            points.Add(player_p1.Location);
            player_img.Add(player_p1.Image);
            game_result();
        }


        int scoore = 0;
        private void playbb_Click(object sender, EventArgs e)
        {

            winp.Visible = false;
            fire1.Visible = false;
            fire2.Visible = false;
            fire3.Visible = false;
            fire4.Visible = false;
            restartb.Visible = false;
            playbb.Visible = false;
            gameoverpic.Visible = false;
            Timers.Stop();
            timer3.Enabled = true;
            check = true;
            player_p1.Location = new Point(449, 366);
            timer4.Enabled = true;
            //pictureBox2.Enabled = false;
            scoore = ScoreCounter;
            ScoreCounter = 0;
            ScoreValue.Text = "0";
            Duration = 60 +(clocking*20);
            timer2.Stop();
            goldTime = 70;
            timer4.Start();

        }



        int j = 0;
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (check)
            {
                if (j != points.Count - 1)
                {
                    player_p1.Image = player_img[j];
                    player_p1.Location = new Point(points[j].X, points[j].Y);

                }

                else
                {
                    check = false;
                    timer3.Enabled = false;
                    timer1.Enabled = false;
                    timer2.Enabled = false;
                }
                j++;
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            Level_Duration--;
            levelup.Visible = false;
            Level_Duration = 2;
            timer5.Enabled = false;
        }


        int gg = 0;
        private void timer4_Tick(object sender, EventArgs e)
        {
            Duration--;
            try
            {
                goldTime--;
                TimeValue.Text = (Duration).ToString() + "s";
                fruit = fpics[gg];
                fruit.Location = si[gg];
                if (goldTime % 10 == 0)
                {
                    fruit.Visible = false;

                }
                else
                    fruit.Visible = true;


                gg++;

            }
            catch (Exception ex)
            {
               
                    repeat = false;
                    Game_Over();
                    timer4.Stop();
                ScoreValue.Text = scoore.ToString();

            }

            if (Duration == pbDue || Duration == 0)
            {
                repeat = false;
                Game_Over();
                timer4.Stop();
                ScoreValue.Text = scoore.ToString();
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_COMPOSITED = 0x02000000;
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_COMPOSITED;
                return cp;
            }
        }
    }


}
