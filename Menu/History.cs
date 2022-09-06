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
    public partial class History : Form
    {
        public static DataTable table = new DataTable("table");
        public static int cell = 0;

        public History()
        {
            InitializeComponent();
            dataGridView1.DataSource = table;

        }
        public static void make_table()
        {
            table.Columns.Clear();
            table.Clear();
            table.Columns.Add("Profile");
            table.Columns.Add("Date");
            table.Columns.Add("Duration");
            table.Columns.Add("Score");
            table.Columns.Add("Levels");
            table.Columns.Add("Check Steps");


            for (int i = 0; i < MainMenu.lProfile.Count; i++)
            {
                table.Rows.Add(0, 0, 0, 0, 0, "DoubleClick");
                table.Rows[i][0] = MainMenu.lProfile[i];
            }
            for (int i = 0; i < MainMenu.lDate.Count; i++)
            {
                table.Rows[i][1] = MainMenu.lDate[i];
            }
            for (int i = 0; i < MainMenu.lDuration.Count; i++)
            {
                table.Rows[i][2] = MainMenu.lDuration[i] + " S";
            }
            for (int i = 0; i < MainMenu.lScore.Count; i++)
            {
                table.Rows[i][3] = MainMenu.lScore[i];
            }
            for (int i = 0; i < MainMenu.lLevel.Count; i++)
            {
                table.Rows[i][4] = MainMenu.lLevel[i];
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
         
            cell = e.RowIndex;
            steps s = new steps();
            s.Show();
        }
    }
}
