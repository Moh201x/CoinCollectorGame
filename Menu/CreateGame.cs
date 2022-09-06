using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FCTEST2;
namespace Menu
{
    public partial class CreateGame : Form
    {
        CoinCollector NewGame;

        public static int numOfGame = 0;
        public static string n;
        DateTime DateT = DateTime.Now;
        public static string Date;
        public static int D;
        public static string Lvls;
        public CreateGame()
        {
            InitializeComponent();

            for (int i = 0; i < MainMenu.P.Count; i++)
            {
                comboBox1.Items.Add(MainMenu.P[i].Name);
            }
            comboBox1.SelectedIndex = MainMenu.P.Count - 1;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewGame = new CoinCollector();
            string N = comboBox1.Text;
            if (String.IsNullOrEmpty(N) == false)
            {
                foreach (var i in MainMenu.P)
                    if (N.Contains(i.Name))
                    {
                     
                            NewGame.Show();
                        NewGame.ProfileN.Text = N;
                        n = NewGame.ProfileN.Text;
                        if (N.Contains(i.Name))
                        {
                            MainMenu.lProfile.Add(N);  
                            Date = DateT.ToString("MM/dd/yyyy");
                            //Date
                            MainMenu.lDate.Add(Date);
                            History.make_table();
                        }
                        //number Of Games
                        numOfGame = (from x in MainMenu.lProfile select x).Count();
                        statistics.make_table();

                        this.Hide();

                    }
            }
            else
            {
                MessageBox.Show("Please set your profile name");
            }     
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            foreach (var i in MainMenu.P)
                if (comboBox1.Text.Contains(i.Name) && String.IsNullOrEmpty(comboBox1.Text) == false)
                {
                    MainMenu.min = 1000;
                    if (NewGame != null)
                    {

                        if (NewGame.Visible == true && NewGame.playbb.Visible == false)
                        {
                          
                            MainMenu.total_Duration++;
                            timer1.Start();
                            MainMenu.Duration1++;
                            MainMenu.Duration2++;
                    
                        }

                        else
                        {
                            timer1.Stop();
                            //Levels
                            if (MainMenu.Duration1 <= 60)
                            {
                                Lvls = "1";
                                MainMenu.lLevel.Add(Lvls);
                                History.make_table();
                            }
                            else if(MainMenu.Duration1 > 60&& MainMenu.Duration1 <= 120) {
                                Lvls = "2";
                                MainMenu.lLevel.Add(Lvls);
                                History.make_table();
                            }
                            else
                            {
                                Lvls = "3";
                                MainMenu.lLevel.Add(Lvls);
                                History.make_table();
                            }
                            statistics.make_table();
                          //Minimum Duration,Maximum Duration
                            MainMenu.lMin.Add(MainMenu.Duration1);
                            MainMenu.min = (from x in MainMenu.lMin select x).Min();
                            MainMenu.lMax.Add(MainMenu.Duration2);
                            MainMenu.max = (from x in MainMenu.lMax select x).Max();
                                statistics.make_table();
                            timer1.Stop();
                            MainMenu.Duration1 = 0;
                            MainMenu.Duration2 = 0;
                            MainMenu.steps_count.Add(CoinCollector.steps.Count);

                        }

                    }
                }
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
           
           
                foreach (var i in MainMenu.P)
                    if (comboBox1.Text.Contains(i.Name) && String.IsNullOrEmpty(comboBox1.Text) == false)

                    {
                        MainMenu.HieghstS = -1000;
                        MainMenu.MinimumS = 1000;
                        if (NewGame != null)
                        {
                            if (NewGame.Visible == true&& NewGame.playbb.Visible == false)
                            { 
                                timer2.Start();
                                MainMenu.Duration3++;
                                if (MainMenu.Duration3 <= 60)
                                    MainMenu.Score = NewGame.ScoreCounter;
                                else if (MainMenu.Duration3 > 60 && MainMenu.Duration3 <= 120)
                                    MainMenu.Score2 = NewGame.ScoreCounter;
                                else
                                    MainMenu.Score3 = NewGame.ScoreCounter;
                            }
                            else
                            {
                            timer2.Stop();
                                MainMenu.lScore.Add(MainMenu.Score + MainMenu.Score2 + MainMenu.Score3);
                                History.make_table();
                            //Heighest Score, Minimum Score
                            MainMenu.HieghstS = MainMenu.lScore.Max();
                                MainMenu.MinimumS = MainMenu.lScore.Min();
                                statistics.make_table();
                                MainMenu.lDuration.Add(MainMenu.Duration3);
                                History.make_table();
                                timer2.Stop();
                                MainMenu.Duration3 = 0;
                                MainMenu.Score = 0;

                            }
                        }
                    }
            
            
        }
    }
}
