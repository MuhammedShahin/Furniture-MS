using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace The_Last
{
    //send the user control to the Form .......................................
    public partial class Admin_Update : UserControl
    {
        private static Admin_Update _instance2;
        public static Admin_Update instance2
        {
            get
            {
                if (_instance2 == null)
                    _instance2 = new Admin_Update();
                return _instance2;
            }
        }
        string Connection = "Data Source=DESKTOP-3OTKFSM;Initial Catalog=Furniture Store Management System;Integrated Security=True";
        public Admin_Update()
        {
            InitializeComponent();
            get_cust_IDs();
            get_Branch_IDs();
            get_Emp_IDs();
        }
        void get_cust_IDs()
        {
            SqlConnection con = new SqlConnection(Connection);
            con.Open();
            SqlCommand com = new SqlCommand("select ID from customer", con);
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                int id = (int)read["ID"];
                comboBox_id_cust.Items.Add(id);
            }
            con.Close();
            read.Close();
        }
        void get_Emp_IDs()
        {
            SqlConnection con = new SqlConnection(Connection);
            con.Open();
            SqlCommand com = new SqlCommand("select ID from employee", con);
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                int id = (int)read["ID"];
                comboBox_emp_id.Items.Add(id);

            }

            con.Close();
            read.Close();
        }
        void get_Branch_IDs()
        {
            SqlConnection con = new SqlConnection(Connection);
            con.Open();
            SqlCommand com = new SqlCommand("select ID from branch", con);
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                int id = (int)read["ID"];
                comboBox_branch_id.Items.Add(id);
            }
            con.Close();
            read.Close();
        }
        void get_update_cust_rows()
        {
            SqlConnection con = new SqlConnection(Connection);
            con.Open();
            SqlCommand com = new SqlCommand("select * from customer", con);
            SqlDataReader read = com.ExecuteReader();
            int id_comp = (int)comboBox_id_cust.SelectedItem;
            while (read.Read())
            {
                int id = (int)read["ID"];
                if (id == id_comp)
                {
                    comboBox_cust_select.Items.Add(read.GetString(1));
                    comboBox_cust_select.Items.Add(read.GetInt32(2));
                    comboBox_cust_select.Items.Add(read.GetString(3));
                    comboBox_cust_select.Items.Add(read.GetString(4));
                    comboBox_cust_select.Items.Add(read.GetString(5));
                    break;
                }
            }
            con.Close();
            read.Close();
        }
        void get_update_emp_rows()
        {
            SqlConnection con = new SqlConnection(Connection);
            con.Open();
            SqlCommand com = new SqlCommand("select * from employee", con);
            SqlDataReader read = com.ExecuteReader();
            int id_comp = (int)comboBox_emp_id.SelectedItem;
            while (read.Read())
            {
                int id = (int)read["ID"];
                if (id == id_comp)
                {
                    comboBox_select_emp.Items.Add(read.GetString(1));
                    comboBox_select_emp.Items.Add(read.GetString(2));
                    comboBox_select_emp.Items.Add(read.GetSqlMoney(3));
                    comboBox_select_emp.Items.Add(read.GetInt32(4));
                    comboBox_select_emp.Items.Add(read.GetString(5));
                    comboBox_select_emp.Items.Add(read.GetString(6));
                    break;
                }
            }
            read.Close();
            con.Close();
        }
        void get_update_branch_rows()
        {
            SqlConnection con = new SqlConnection(Connection);
            con.Open();
            SqlCommand com = new SqlCommand("select * from branch", con);
            SqlDataReader read = com.ExecuteReader();
            int id_comp = (int)comboBox_branch_id.SelectedItem;
            while (read.Read())
            {
                int id = (int)read["ID"];
                if (id == id_comp)
                {
                    comboBox_select_branch.Items.Add(read.GetString(1));
                    comboBox_select_branch.Items.Add(read.GetInt32(2));
                    break;
                }
            }
            read.Close();
            con.Close();
        }
        private void button_update_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Connection);
            con.Open();
            if (radioButton_cust.Checked)
            {
                int id_comp = (int)comboBox_id_cust.SelectedItem;
                int index = (int)comboBox_cust_select.SelectedIndex;
                if (index == 0)
                {
                    SqlCommand cmd = new SqlCommand("update customer set name=@name where ID=@ID", con);
                    SqlParameter name_cust = new SqlParameter("@name", textBox_edit_cust.Text);
                    SqlParameter id_cust = new SqlParameter("@ID", SqlDbType.Int);
                    id_cust.Value = id_comp;
                    cmd.Parameters.Add(id_cust);
                    cmd.Parameters.Add(name_cust);
                    cmd.ExecuteNonQuery();
                    textBox_edit_cust.Clear();

                }
                else if (index == 1)
                {
                    SqlCommand cmd = new SqlCommand("update customer set phone_number=@Phonenum where ID=@ID", con);
                    SqlParameter phone_cust = new SqlParameter("@Phonenum", SqlDbType.Int);
                    SqlParameter id_cust = new SqlParameter("@ID", SqlDbType.Int);
                    id_cust.Value = id_comp;
                    phone_cust.Value = int.Parse(textBox_edit_cust.Text);
                    cmd.Parameters.Add(id_cust);
                    cmd.Parameters.Add(phone_cust);
                    cmd.ExecuteNonQuery();
                    textBox_edit_cust.Clear();
                }
                else if (index == 2)
                {
                    SqlCommand cmd = new SqlCommand("update customer set E_mail=@email where ID=@ID", con);
                    SqlParameter email = new SqlParameter("@email", textBox_edit_cust.Text);
                    SqlParameter id_cust = new SqlParameter("@ID", SqlDbType.Int);
                    id_cust.Value = id_comp;
                    cmd.Parameters.Add(id_cust);
                    cmd.Parameters.Add(email);
                    cmd.ExecuteNonQuery();
                    textBox_edit_cust.Clear();
                }
                else if (index == 3)
                {
                    SqlCommand cmd = new SqlCommand("update customer set address=@add where ID=@ID", con);
                    SqlParameter add = new SqlParameter("@add", textBox_edit_cust.Text);
                    SqlParameter id_cust = new SqlParameter("@ID", SqlDbType.Int);
                    id_cust.Value = id_comp;
                    cmd.Parameters.Add(id_cust);
                    cmd.Parameters.Add(add);
                    cmd.ExecuteNonQuery();
                    textBox_edit_cust.Clear();
                }
                else if (index == 4)
                {
                    SqlCommand cmd = new SqlCommand("update customer set password=@pass where ID=@ID", con);
                    SqlParameter pass = new SqlParameter("@pass", textBox_edit_cust.Text);
                    SqlParameter id_cust = new SqlParameter("@ID", SqlDbType.Int);
                    id_cust.Value = id_comp;
                    cmd.Parameters.Add(id_cust);
                    cmd.Parameters.Add(pass);
                    cmd.ExecuteNonQuery();
                    textBox_edit_cust.Clear();
                }
                comboBox_cust_select.Items.Clear();
                get_update_cust_rows();
            }
            if (radioButton_emp.Checked)
            {
                int id_comp = (int)comboBox_emp_id.SelectedItem;
                int index = (int)comboBox_select_emp.SelectedIndex;
                if (index == 0)
                {
                    SqlCommand cmd = new SqlCommand("update employee set name=@name where ID=@ID", con);
                    SqlParameter name_emp = new SqlParameter("@name", textBox_edit_emp.Text);
                    SqlParameter id_emp = new SqlParameter("@ID", SqlDbType.Int);
                    id_emp.Value = id_comp;
                    cmd.Parameters.Add(id_emp);
                    cmd.Parameters.Add(name_emp);
                    cmd.ExecuteNonQuery();
                    textBox_edit_emp.Clear();
                }
                else if (index == 1)
                {
                    SqlCommand cmd = new SqlCommand("update employee set E_mail=@email where ID=@ID", con);
                    SqlParameter email_emp = new SqlParameter("@email", textBox_edit_emp.Text);
                    SqlParameter id_emp = new SqlParameter("@ID", SqlDbType.Int);
                    id_emp.Value = id_comp;
                    cmd.Parameters.Add(id_emp);
                    cmd.Parameters.Add(email_emp);
                    cmd.ExecuteNonQuery();
                    textBox_edit_emp.Clear();
                }
                else if (index == 2)
                {
                    SqlCommand cmd = new SqlCommand("update employee set salary=@salary where ID=@ID", con);
                    SqlParameter salary_emp = new SqlParameter("@salary", textBox_edit_emp.Text);
                    SqlParameter id_emp = new SqlParameter("@ID", SqlDbType.Int);
                    id_emp.Value = id_comp;
                    cmd.Parameters.Add(id_emp);
                    cmd.Parameters.Add(salary_emp);
                    cmd.ExecuteNonQuery();
                    textBox_edit_emp.Clear();
                }
                else if (index == 3)
                {
                    SqlCommand cmd = new SqlCommand("update employee set phone_number=@phone_number where ID=@ID", con);
                    SqlParameter phone_number_emp = new SqlParameter("@phone_number", SqlDbType.Int);
                    SqlParameter id_emp = new SqlParameter("@ID", SqlDbType.Int);
                    id_emp.Value = id_comp;
                    phone_number_emp.Value = int.Parse(textBox_edit_emp.Text);
                    cmd.Parameters.Add(id_emp);
                    cmd.Parameters.Add(phone_number_emp);
                    cmd.ExecuteNonQuery();
                    textBox_edit_emp.Clear();
                }
                else if (index == 4)
                {
                    SqlCommand cmd = new SqlCommand("update employee set password=@password where ID=@ID", con);
                    SqlParameter password_emp = new SqlParameter("@password", textBox_edit_emp.Text);
                    SqlParameter id_emp = new SqlParameter("@ID", SqlDbType.Int);
                    id_emp.Value = id_comp;
                    cmd.Parameters.Add(id_emp);
                    cmd.Parameters.Add(password_emp);
                    cmd.ExecuteNonQuery();
                    textBox_edit_emp.Clear();
                }
                else if (index == 5)
                {
                    SqlCommand cmd = new SqlCommand("update employee set title=@title where ID=@ID", con);
                    SqlParameter title_emp = new SqlParameter("@title", textBox_edit_emp.Text);
                    SqlParameter id_emp = new SqlParameter("@ID", SqlDbType.Int);
                    id_emp.Value = id_comp;
                    cmd.Parameters.Add(id_emp);
                    cmd.Parameters.Add(title_emp);
                    cmd.ExecuteNonQuery();
                    textBox_edit_emp.Clear();
                }
                comboBox_select_emp.Items.Clear();
                get_update_emp_rows();
            }
            if (radioButton_branch.Checked)
            {
                int id_comp = (int)comboBox_branch_id.SelectedItem;
                int index = (int)comboBox_select_branch.SelectedIndex;
                if (index == 0)
                {
                    SqlCommand cmd = new SqlCommand("update branch set Address=@Address where ID=@ID", con);
                    SqlParameter Address_branch = new SqlParameter("@Address", textBox_edit_branch.Text);
                    SqlParameter id_branch = new SqlParameter("@ID", SqlDbType.Int);
                    id_branch.Value = id_comp;
                    cmd.Parameters.Add(id_branch);
                    cmd.Parameters.Add(Address_branch);
                    cmd.ExecuteNonQuery();
                    textBox_edit_branch.Clear();
                }
                else if (index == 1)
                {
                    SqlCommand cmd = new SqlCommand("update branch set phone_number=@phone_number where ID=@ID", con);
                    SqlParameter phone_number_branch = new SqlParameter("@phone_number", SqlDbType.Int);
                    SqlParameter id_branch = new SqlParameter("@ID", SqlDbType.Int);
                    id_branch.Value = id_comp;
                    phone_number_branch.Value = int.Parse(textBox_edit_branch.Text);
                    cmd.Parameters.Add(id_branch);
                    cmd.Parameters.Add(phone_number_branch);
                    cmd.ExecuteNonQuery();
                    textBox_edit_branch.Clear();
                }
                comboBox_select_branch.Items.Clear();
                get_update_branch_rows();
            }
            comboBox_id_cust.Text = "";
            comboBox_cust_select.Text = "";
            comboBox_emp_id.Text = "";
            comboBox_select_emp.Text = "";
            comboBox_branch_id.Text = "";
            comboBox_select_branch.Text = "";
            MessageBox.Show("Success !!");
        }

        private void radioButton_cust_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_id_cust.Enabled = true;
            comboBox_cust_select.Enabled = true;
            textBox_edit_cust.Enabled = true;
            comboBox_emp_id.Enabled = false;
            comboBox_select_emp.Enabled = false;
            textBox_edit_emp.Enabled = false;
            comboBox_branch_id.Enabled = false;
            comboBox_select_branch.Enabled = false;
            textBox_edit_branch.Enabled = false;
        }

        private void radioButton_emp_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_id_cust.Enabled = false;
            comboBox_cust_select.Enabled = false;
            textBox_edit_cust.Enabled = false;
            comboBox_emp_id.Enabled = true;
            comboBox_select_emp.Enabled = true;
            textBox_edit_emp.Enabled = true;
            comboBox_branch_id.Enabled = false;
            comboBox_select_branch.Enabled = false;
            textBox_edit_branch.Enabled = false;
        }

        private void radioButton_branch_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_id_cust.Enabled = false;
            comboBox_cust_select.Enabled = false;
            textBox_edit_cust.Enabled = false;
            comboBox_emp_id.Enabled = false;
            comboBox_select_emp.Enabled = false;
            textBox_edit_emp.Enabled = false;
            comboBox_branch_id.Enabled = true;
            comboBox_select_branch.Enabled = true;
            textBox_edit_branch.Enabled = true;
        }

        private void comboBox_id_cust_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_cust_select.Items.Clear();
            get_update_cust_rows();
        }

        private void comboBox_emp_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_select_emp.Items.Clear();
            get_update_emp_rows();
        }

        private void comboBox_branch_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_select_branch.Items.Clear();
            get_update_branch_rows();
        }
    }
}
