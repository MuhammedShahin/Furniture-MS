using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace The_Last
{
    public partial class Cust_Form : Form
    {
        string Connection = "Data Source=DESKTOP-3OTKFSM;Initial Catalog=Furniture Store Management System;Integrated Security=True";
        public Cust_Form()
        {
            InitializeComponent();
            Cust_pass.PasswordChar = '*'; //to make the password not visible El_Shikh(*_*) .
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mail = Cust_mail.Text;
            string pass = Cust_pass.Text;
            SqlConnection con = new SqlConnection(Connection);
            con.Open();
            SqlCommand com = new SqlCommand("select E_mail , password from customer where E_mail=@mail and password=@pass", con);
            com.CommandType = CommandType.Text;
            com.Parameters.AddWithValue("@mail", mail);
            com.Parameters.AddWithValue("@pass", pass);
            SqlDataReader r = com.ExecuteReader();
            if (r.HasRows)
            {
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
            }
            else
            {
                MessageBox.Show("invalid username or password !");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Add usercontrole to the panel..................................................
            if (!Cust_panel.Controls.Contains(Cust_Add.instance_Cust))
            {
                Cust_panel.Controls.Add(Cust_Add.instance_Cust);
                Cust_Add.instance_Cust.Dock = DockStyle.Fill;
                Cust_Add.instance_Cust.BringToFront();
            }
            else
                Cust_Add.instance_Cust.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Add usercontrole to the panel..................................................
            if (!Cust_panel.Controls.Contains(Cust_update.instance_Cust1))
            {
                Cust_panel.Controls.Add(Cust_update.instance_Cust1);
                Cust_update.instance_Cust1.Dock = DockStyle.Fill;
                Cust_update.instance_Cust1.BringToFront();
            }
            else
                Cust_update.instance_Cust1.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Add usercontrole to the panel..................................................
            if (!Cust_panel.Controls.Contains(Cust_Del.instance_Cust2))
            {
                Cust_panel.Controls.Add(Cust_Del.instance_Cust2);
                Cust_Del.instance_Cust2.Dock = DockStyle.Fill;
                Cust_Del.instance_Cust2.BringToFront();
            }
            else
                Cust_Del.instance_Cust2.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Add usercontrole to the panel..................................................
            if (!Cust_panel.Controls.Contains(Cust_search.instance_Cust3))
            {
                Cust_panel.Controls.Add(Cust_search.instance_Cust3);
                Cust_search.instance_Cust3.Dock = DockStyle.Fill;
                Cust_search.instance_Cust3.BringToFront();
            }
            else
                Cust_search.instance_Cust3.BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Add usercontrole to the panel..................................................
            if (!Cust_panel.Controls.Contains(Signup.instance_Cust4))
            {
                Cust_panel.Controls.Add(Signup.instance_Cust4);
                Signup.instance_Cust4.Dock = DockStyle.Fill;
                Signup.instance_Cust4.BringToFront();
            }
            else
                Signup.instance_Cust4.BringToFront();
        }
    }
}
