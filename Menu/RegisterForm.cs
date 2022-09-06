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
    public partial class RegisterForm : Form
    {
        string N, G, A;
        public static   RadioButton d = new RadioButton();
        public static RadioButton gray = new RadioButton();
        public static RadioButton y = new RadioButton();


        public static int numOfProfile = 0;
        public RegisterForm()
        {
            InitializeComponent();
           

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Default.Checked == true)
            {
                panel1.BackColor = Color.FromArgb(18, 92, 19);
                panel2.BackColor = Color.FromArgb(62, 124, 23);
                d = Default;
            }
            else if(radioButton5.Checked == true)
            {
                panel1.BackColor = Color.FromArgb(111, 111, 111);
                panel2.BackColor = Color.FromArgb(171, 171, 171);
                label2.BackColor= Color.FromArgb(111, 111, 111);
                gray = radioButton5;
            }
            else
            {
                panel1.BackColor = Color.FromArgb(216, 212, 0);
                label7.ForeColor = Color.Black;
                panel2.BackColor = Color.FromArgb(249, 248, 142);
                label2.BackColor = Color.Black;
                y = radioButton4;
            }



        }

        private void label7_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            N = textBox1.Text;
            G = radioButton1.Text;
            A = comboBox1.Text;


            if (String.IsNullOrWhiteSpace(Name) ||
                String.IsNullOrWhiteSpace(G) ||
                String.IsNullOrWhiteSpace(A))
            {
                MessageBox.Show("All feiled must be filled");
            }

            else
            {
                MainMenu.P.Add(new Profile(N, G, A));
                //Number Of Profile
                numOfProfile = (from x in MainMenu.P select x).Count();
                statistics.make_table();
                MessageBox.Show("Profile Saved Successfully");
                this.Hide();

            }
        }
    }
}
