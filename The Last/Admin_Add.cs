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
    public partial class Admin_Add : UserControl
    {
        private static Admin_Add _instance;
        public static Admin_Add instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Admin_Add();
                return _instance;
            }
        }
        string Connection = "Data Source=DESKTOP-3OTKFSM;Initial Catalog=Furniture Store Management System;Integrated Security=True";
        int get_Admin_ID()
        {
            int Admin_id = Convert.ToInt32(Admin_ID.Text);
            return Admin_id;
        }

        
        void get_Branchs_id()
        {
            SqlConnection con = new SqlConnection(Connection);
            con.Open();
            SqlCommand com = new SqlCommand("select ID from branch", con);
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                int id = (int)read["ID"];
                Branch_id.Items.Add(id);
            }
            con.Close();
            read.Close();
        }

        void get_manager_id()
        {
            SqlConnection con = new SqlConnection(Connection);
            con.Open();
            SqlCommand com = new SqlCommand("select * from employee where title='manager' and bra_ID_work is null ", con);
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                int id = (int)read["ID"];
                mang_id.Items.Add(id);
            }
            con.Close();
            read.Close();
        }
      


        public Admin_Add()
        {
            InitializeComponent();
            get_Branchs_id();
            get_manager_id();
          
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Connection);
            con.Open();
            //ADD customer......................................................................................
            if (check_customer.Checked == true)
            {
                SqlCommand com = new SqlCommand("insert into customer (name,phone_number,E_mail,address,password,adm_ID) values (@Name, @Phone, @Mail, @Add, @pass,@adminID)", con);
                SqlParameter Name = new SqlParameter("@Name", 100);
                Name.Value = cust_name.Text;
                com.Parameters.Add(Name);
                SqlParameter Phone = new SqlParameter("@Phone", SqlDbType.Int);
                Phone.Value = cust_phone.Text;
                com.Parameters.Add(Phone);
                SqlParameter Mail = new SqlParameter("@Mail", 100);
                Mail.Value = cust_email.Text;
                com.Parameters.Add(Mail);
                SqlParameter Address = new SqlParameter("@Add", 100);
                Address.Value = cust_address.Text;
                com.Parameters.Add(Address);
                SqlParameter pass = new SqlParameter("@pass", 100);
                pass.Value = cust_password.Text;
                com.Parameters.Add(pass);
                SqlParameter ID = new SqlParameter("@adminID", 100);
                ID.Value = get_Admin_ID();
                com.Parameters.Add(ID);
                SqlDataReader r = com.ExecuteReader();
                r.Close();
                cust_address.Text = "";
                cust_email.Text = "";
                cust_name.Text = "";
                cust_password.Text = "";
                cust_phone.Text = "";
                check_customer.Checked = false;
                cust_address.Enabled = false;
                cust_email.Enabled = false;
                cust_name.Enabled = false;
                cust_password.Enabled = false;
                cust_phone.Enabled = false;

            }
            //ADD Employee..............................................................
            if (check_employee.Checked == true)
            {
                SqlCommand com = new SqlCommand("insert into employee (name, E_mail, salary, phone_number, password,title,adm_ID) values (@Name, @Mail, @salary, @Phone, @pass, @title,@adminID)", con);
                SqlParameter Name = new SqlParameter("@Name", 100);
                Name.Value = emp_name.Text;
                com.Parameters.Add(Name);
                SqlParameter Phone = new SqlParameter("@Phone", SqlDbType.Int);
                Phone.Value = emp_phone.Text;
                com.Parameters.Add(Phone);
                SqlParameter Mail = new SqlParameter("@Mail", 100);
                Mail.Value = emp_email.Text;
                com.Parameters.Add(Mail);
                SqlParameter salary = new SqlParameter("@salary", SqlDbType.Money);
                salary.Value = emp_salary.Text;
                com.Parameters.Add(salary);
                SqlParameter pass = new SqlParameter("@pass", 100);
                pass.Value = emp_password.Text;
                com.Parameters.Add(pass);
                SqlParameter title = new SqlParameter("@title", 100);
                title.Value = emp_title.Text;
                com.Parameters.Add(title);

                SqlParameter ID = new SqlParameter("@adminID", 100);
                ID.Value = get_Admin_ID();
                com.Parameters.Add(ID);

                SqlDataReader r = com.ExecuteReader();
                

                r.Close();
                //insert the branch ID...................................................
                if (emp_title.Text!="manager")
                { 
                    SqlCommand cmd = new SqlCommand("update employee set bra_ID_work=@bra_id where E_mail=@Mail",con);
                    SqlParameter mail = new SqlParameter("@Mail", 100);
                    mail.Value = emp_email.Text;
                    SqlParameter bra_id = new SqlParameter("@bra_id", 100);
                    bra_id.Value = Branch_id.Text;
                    cmd.Parameters.Add(bra_id);
                    cmd.Parameters.Add(mail);
                    SqlDataReader rd ;
                    rd = cmd.ExecuteReader();
                    rd.Close();
                    
                }
               


                emp_title.Text = "";
                emp_salary.Text = "";
                emp_phone.Text = "";
                emp_password.Text = "";
                emp_name.Text = "";
                emp_email.Text = "";
                Branch_id.Text = "";
                Branch_id.Enabled = false;
                check_employee.Checked = false;
                emp_email.Enabled = false;
                emp_name.Enabled = false;
                emp_password.Enabled = false;
                emp_phone.Enabled = false;
                emp_salary.Enabled = false;
                emp_title.Enabled = false;
                mang_id.Items.Clear();
                get_manager_id();
            }
            // ADD Branch.........................................................................
            if (check_branch.Checked == true)
            {
                SqlCommand com = new SqlCommand("insert into branch (Address, phone_number,emp_id_manage,adm_ID) values (@Add, @Phone,@Emp_mang,@adminID)", con);
                SqlParameter address = new SqlParameter("@Add", 100);
                address.Value = branch_address.Text;
                com.Parameters.Add(address);
                SqlParameter Phone = new SqlParameter("@Phone", SqlDbType.Int);
                Phone.Value = branch_phone.Text;
                com.Parameters.Add(Phone);
                SqlParameter Emp_mang = new SqlParameter("@Emp_mang", SqlDbType.Int);
                Emp_mang.Value = Convert.ToInt32(mang_id.Text);
                com.Parameters.Add(Emp_mang);
                SqlParameter ID = new SqlParameter("@adminID", SqlDbType.Int);
                ID.Value = get_Admin_ID();
                com.Parameters.Add(ID);
                SqlDataReader r = com.ExecuteReader();
                r.Close();
                //get the branch ID ..................relations................................
                com = new SqlCommand("select ID from branch where emp_id_manage=@Emp_mang",con);
                SqlParameter Emp_Manag = new SqlParameter("@Emp_mang",SqlDbType.Int);
                Emp_Manag.Value = mang_id.Text;
                com.Parameters.Add(Emp_Manag);
                int bran_id =Convert.ToInt32(com.ExecuteScalar());

                //put the branch ID ..................relations................................
                SqlCommand cmd = new SqlCommand("update employee set bra_ID_work=@bra_id where ID=@Emp_mang ",con);
                SqlParameter bran_ID = new SqlParameter("@bra_id", SqlDbType.Int);
                bran_ID.Value = bran_id;
                cmd.Parameters.Add(bran_ID);
                SqlParameter ID_man = new SqlParameter("@Emp_mang", SqlDbType.Int);
                ID_man.Value = Convert.ToInt32(mang_id.Text);
                cmd.Parameters.Add(ID_man);

                SqlDataReader r_ = cmd.ExecuteReader();
                r_.Close();
                


                branch_address.Text = "";
                branch_phone.Text = "";
                mang_id.Text = "";
                mang_id.Enabled = false;
                check_branch.Checked = false;
                branch_phone.Enabled = false;
                branch_address.Enabled = false;
                mang_id.Items.Clear();
                get_manager_id();
                Branch_id.Items.Clear();
                get_Branchs_id();
            }
            con.Close();
            MessageBox.Show("Added successfully *_* ");
        }

        private void check_employee_CheckedChanged(object sender, EventArgs e)
        {
            emp_email.Enabled = true;
            emp_name.Enabled = true;
            emp_password.Enabled = true;
            emp_phone.Enabled = true;
            emp_salary.Enabled = true;
            emp_title.Enabled = true;
            Branch_id.Enabled = true;
        }

        private void check_customer_CheckedChanged(object sender, EventArgs e)
        {
            cust_address.Enabled = true;
            cust_email.Enabled = true;
            cust_name.Enabled = true;
            cust_password.Enabled = true;
            cust_phone.Enabled = true;
        }

        private void check_branch_CheckedChanged(object sender, EventArgs e)
        {
            branch_address.Enabled = true;
            branch_phone.Enabled = true;
            mang_id.Enabled = true;
            mang_id.Items.Clear();
            get_manager_id();

        }

        private void check_customer_CheckStateChanged(object sender, EventArgs e)
        {
            if (check_customer.Checked == false)
            {
                cust_address.Enabled = false;
                cust_email.Enabled = false;
                cust_name.Enabled = false;
                cust_password.Enabled = false;
                cust_phone.Enabled = false;
            }
        }

        private void check_employee_CheckStateChanged(object sender, EventArgs e)
        {
            if (check_employee.Checked == false)
            {
                emp_email.Enabled = false;
                emp_name.Enabled = false;
                emp_password.Enabled = false;
                emp_phone.Enabled = false;
                emp_salary.Enabled = false;
                emp_title.Enabled = false;
                Branch_id.Enabled = false;
            }
        }

        private void check_branch_CheckStateChanged(object sender, EventArgs e)
        {
            if (check_branch.Checked==false)
            {
                branch_address.Enabled = false;
                branch_phone.Enabled = false;
                mang_id.Enabled = false;
            }
        }

        private void emp_title_TextChanged(object sender, EventArgs e)
        {
            if (emp_title.Text=="manager")
            {
                Branch_id.Enabled = false;
            }
            else
                Branch_id.Enabled = true;
        }

        private void Admin_ID_TextChanged(object sender, EventArgs e)
        {
            if (Admin_ID.Text==null)
            {
                button_Add.Enabled = false;
            }
            else
                button_Add.Enabled = true;
        }
    }
}
