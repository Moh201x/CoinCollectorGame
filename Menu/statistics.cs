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
    public partial class statistics : Form
    {
        public static DataTable table = new DataTable("table");
        public statistics()
        {

            InitializeComponent();
            dataGridView1.DataSource = table;
        }
        public static void make_table()
        {
            table.Columns.Clear();
            table.Clear();
            table.Columns.Add("Item");
            table.Columns.Add("Value");
            table.Rows.Add("#Of Games", 0);
            table.Rows.Add("#Of Profiles", 0);
            table.Rows.Add("Heighest Score", 0);
            table.Rows.Add("Lowest Score", 0);
            table.Rows.Add("Minimum Duration", 0);
            table.Rows.Add("Maximum Duration ", 0);
            table.Rows.Add("Total Duration", 0);
            statistics.table.Rows[0][1] = CreateGame.numOfGame;
            statistics.table.Rows[1][1] = RegisterForm.numOfProfile;
            statistics.table.Rows[2][1] = MainMenu.HieghstS;
            statistics.table.Rows[3][1] = MainMenu.MinimumS; 
            statistics.table.Rows[4][1] = MainMenu.min;
            statistics.table.Rows[5][1] = MainMenu.max;  
            statistics.table.Rows[6][1] = MainMenu.total_Duration;
        }
    }
}