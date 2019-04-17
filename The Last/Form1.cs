using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Last
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Form a = new Admin_Form();
            a.Show();
          //  this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Emp_Form a = new Emp_Form();
            a.Show();
            //this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cust_Form a = new Cust_Form();
            a.Show();
            //this.Hide();
        }
    }
}
