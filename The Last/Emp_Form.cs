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
    public partial class Emp_Form : Form
    {
        string Connection = "Data Source=DESKTOP-3OTKFSM;Initial Catalog=Furniture Store Management System;Integrated Security=True";
        public Emp_Form()
        {
            InitializeComponent();
            Emp_pass.PasswordChar = '*'; //to make the password not visible El_Shikh(*_*) .
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mail = Emp_mail.Text;
            string pass = Emp_pass.Text;
            SqlConnection con = new SqlConnection(Connection);
            con.Open();
            SqlCommand com = new SqlCommand("select E_mail , password from employee where E_mail=@mail and password=@pass", con);
            com.CommandType = CommandType.Text;
            com.Parameters.AddWithValue("@mail", mail);
            com.Parameters.AddWithValue("@pass", pass);
            SqlDataReader r = com.ExecuteReader();


            SqlConnection con2 = new SqlConnection(Connection);
            con2.Open();
            SqlCommand com2 = new SqlCommand("select ID from employee where E_mail=@mail and password=@pass", con2);
            com2.CommandType = CommandType.Text;
            com2.Parameters.AddWithValue("@mail", mail);
            com2.Parameters.AddWithValue("@pass", pass);
            int ID = Convert.ToInt32(com2.ExecuteScalar());


            if (r.HasRows)
            {
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                MessageBox.Show("Your ID is : " + ID.ToString());
            }
            else
            {
                MessageBox.Show("invalid");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Add usercontrole to the panel..................................................
            if (!Emp_panel.Controls.Contains(Emp_Add.instance_Emp))
            {
                Emp_panel.Controls.Add(Emp_Add.instance_Emp);
                Emp_Add.instance_Emp.Dock = DockStyle.Fill;
                Emp_Add.instance_Emp.BringToFront();
            }
            else
                Emp_Add.instance_Emp.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Add usercontrole to the panel..................................................
            if (!Emp_panel.Controls.Contains(Emp_update.instance_Emp1))
            {
                Emp_panel.Controls.Add(Emp_update.instance_Emp1);
                Emp_update.instance_Emp1.Dock = DockStyle.Fill;
                Emp_update.instance_Emp1.BringToFront();
            }
            else
                Emp_update.instance_Emp1.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Add usercontrole to the panel..................................................
            if (!Emp_panel.Controls.Contains(Emp_Delete.instance_Emp2))
            {
                Emp_panel.Controls.Add(Emp_Delete.instance_Emp2);
                Emp_Delete.instance_Emp2.Dock = DockStyle.Fill;
                Emp_Delete.instance_Emp2.BringToFront();
            }
            else
                Emp_Delete.instance_Emp2.BringToFront();
        }

        private void comboBox_salary_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //View Salary for the employee............................................................
            SqlConnection con = new SqlConnection(Connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select salary from employee where ID=@EmployeeId", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@EmployeeId", Convert.ToInt32(comboBox_salary.Text));
            //money data tybe
            double GetSalary = Double.Parse(Convert.ToDecimal(cmd.ExecuteScalar()).ToString());
            con.Close();
            MessageBox.Show("The Salary Is: " + GetSalary);
        }
    }
}
