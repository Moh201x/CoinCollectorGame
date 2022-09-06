using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu
{
    public partial class Current : Form
    {
        public static Exception e;
        public Current()
        {
            InitializeComponent();
            view();
        }

       public void view()


            /* if (Default.Checked == true)
            {
                panel1.BackColor = Color.FromArgb(18, 92, 19);
                panel2.BackColor = Color.FromArgb(62, 124, 23);
            }
            else if(radioButton5.Checked == true)
            {
                panel1.BackColor = Color.FromArgb(111, 111, 111);
                panel2.BackColor = Color.FromArgb(171, 171, 171);
                label2.BackColor= Color.FromArgb(111, 111, 111);

            }
            else
            {
                panel1.BackColor = Color.FromArgb(216, 212, 0);
                label7.ForeColor = Color.Black;
                panel2.BackColor = Color.FromArgb(249, 248, 142);
                label2.BackColor = Color.Black;

            }
*/
        {
            try
            {
                if (RegisterForm.d.Checked == true)
                {
                    panel7.BackColor = Color.FromArgb(62, 124, 23);
                    this.BackColor = Color.FromArgb(18, 92, 19);
                }
                else if (RegisterForm.gray.Checked == true)
                {
                    panel7.BackColor = Color.FromArgb(111, 111, 111);
                    this.BackColor = Color.FromArgb(171, 171, 171);
                    NameValue.ForeColor = Color.Black;
                    GenderValue.ForeColor = Color.Black;
                    AgeValue.ForeColor = Color.Black;
                    label11.BackColor = Color.FromArgb(111, 111, 111);
                    label11.ForeColor = Color.Black;
                    label10.BackColor = Color.FromArgb(111, 111, 111);
                    label10.ForeColor = Color.Black;
                    label8.BackColor = Color.FromArgb(111, 111, 111);
                    label8.ForeColor = Color.Black;
                    label9.BackColor = Color.FromArgb(111, 111, 111);
                    label9.ForeColor = Color.Black;
                    label7.ForeColor = Color.Black;

                }
                else
                {
                    panel7.BackColor = Color.FromArgb(216, 212, 0);
                    this.BackColor = Color.FromArgb(249, 248, 142);
                    NameValue.ForeColor = Color.Black;
                    GenderValue.ForeColor = Color.Black;
                    AgeValue.ForeColor = Color.Black;
                    label11.BackColor = Color.FromArgb(216, 212, 0);
                    label11.ForeColor = Color.Black;
                    label10.BackColor = Color.FromArgb(216, 212, 0);
                    label10.ForeColor = Color.Black;
                    label8.BackColor = Color.FromArgb(216, 212, 0);
                    label8.ForeColor = Color.Black;
                    label9.BackColor = Color.FromArgb(216, 212, 0);
                    label9.ForeColor = Color.Black;
                    label7.ForeColor = Color.Black;
                }

                NameValue.Text = MainMenu.P[MainMenu.P.Count - 1].Name;
                GenderValue.Text = MainMenu.P[MainMenu.P.Count - 1].Gender;
                AgeValue.Text = MainMenu.P[MainMenu.P.Count - 1].Age;

            }
            catch (Exception ex)
            {
                MessageBox.Show("You have not created any profile!");
            }
        }

        private void Done_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
