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
    public partial class steps : Form
    {
        public static DataTable step_table = new DataTable("table");
        public static List<DataTable> t = new List<DataTable>();
        int j = 0;
        public steps()
        {
            InitializeComponent();
            dataGridView1.DataSource = step_table;
            make_table();
        }

        public void make_table()
        {
            step_table.Columns.Clear();
            step_table.Clear();
            step_table.Columns.Add("Step");
            step_table.Columns.Add("Click");
            if (History.cell == 0)
                j = 0;
            else
                j = MainMenu.steps_count[History.cell - 1];

            for (; j < MainMenu.steps_count[History.cell]; j++)
            {
                steps.step_table.Rows.Add(j + 1, CoinCollector.steps[j].ToString());
            }
        }
    }
}
