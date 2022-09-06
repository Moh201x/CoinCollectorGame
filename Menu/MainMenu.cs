using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu;
using FCTEST2;

namespace Menu
{
    public partial class MainMenu : Form
    {
        private static List<Profile> p = new List<Profile>();
        internal static List<Profile> P { get => p; set => p = value; }
        public static int total_Duration = 0;
        public static int Duration1 = 0;
        public static int Duration2 = 0;
        public static int Duration3 = 0;
        public static List<int> lMax = new List<int>();
        public static List<int> lMin = new List<int>();
        public static string D;
        public static int min;
        public static int max = 0;
        public static int time = 0;
        public static int HieghstS = 0;
        public static int MinimumS =0;
        public static int Score = 0;
        public static int Score2 = 0;
        public static int Score3 = 0;
        public static List<int> steps_count = new List<int>();


        public static List<String> lProfile = new List<String>();
        public static List<int> lDuration = new List<int>();
        public static List<string> lDate = new List<string>();
        public static List<int> lScore = new List<int>();
        public static List<string> lLevel = new List<string>();
        public MainMenu()
        {
            statistics.make_table();
            History.make_table();
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RegisterForm Register = new RegisterForm();
            Register.Show();
        }

        private void endToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            CreateGame Start_New_Game = new CreateGame();
            Start_New_Game.Show();

        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    
        private void statisticsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            statistics st = new statistics();
            st.Show();

        }

        private void historyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            History His = new History();
            His.Show();

        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void currentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Current c=new Current(); 
            if(MainMenu.P.Count - 1>=0)
            c.Show();
            
        }
    }
}
