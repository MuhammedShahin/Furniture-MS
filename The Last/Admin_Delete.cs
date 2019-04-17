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
    public partial class Admin_Delete : UserControl
    {
        private static Admin_Delete _instance1;
        public static Admin_Delete instance1
        {
            get
            {
                if (_instance1 == null)
                    _instance1 = new Admin_Delete();
                return _instance1;
            }
        }
        string Connection= "Data Source=DESKTOP-3OTKFSM;Initial Catalog=Furniture Store Management System;Integrated Security=True";
        void get_cust_IDs()
        {
            SqlConnection con = new SqlConnection(Connection);
            con.Open();
            SqlCommand com = new SqlCommand("select ID from customer", con);
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                int id = (int)read["ID"];
                cust_IDs.Items.Add(id);
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
                Emp_IDs.Items.Add(id);
                
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
                Branch_IDs.Items.Add(id);
            }
            con.Close();
            read.Close();
        }
        public Admin_Delete()
        {
            InitializeComponent();
            get_Branch_IDs();
            get_cust_IDs();
            get_Emp_IDs();
        }

        private void Admin_Delete_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Connection);
            con.Open();
            if (radio_cust.Checked == true)
            {
                //get Order ID .
                SqlCommand cmd = new SqlCommand("select ID from order1 where cust_id=@ID_",con);
                SqlParameter id2 = new SqlParameter("@ID_", SqlDbType.Int);
                id2.Value = cust_IDs.Text;
                cmd.Parameters.Add(id2);
                cmd.CommandType = CommandType.Text;
                int id_order = Convert.ToInt32(cmd.ExecuteScalar());

                //delete the order form relation 
                SqlCommand comand = new SqlCommand("delete from order_furniture_relation where order_id=@order_id", con);
                comand.Parameters.AddWithValue("@order_id", id_order);
                comand.ExecuteNonQuery();


                //Delete the orders of the customer.
                SqlCommand com1 = new SqlCommand("delete from order1 where cust_id=@ID_", con);
                SqlParameter id1 = new SqlParameter("@ID_", SqlDbType.Int);
                id1.Value = cust_IDs.Text;
                com1.Parameters.Add(id1);
                com1.CommandType = CommandType.Text;
                SqlDataReader r1 = com1.ExecuteReader();
                r1.Close();

                //Delete the customer.
                SqlCommand com = new SqlCommand("delete from customer where ID=@ID_", con);
                SqlParameter id = new SqlParameter("@ID_", SqlDbType.Int);
                id.Value = cust_IDs.Text;
                com.Parameters.Add(id);
                com.CommandType = CommandType.Text;
                SqlDataReader r = com.ExecuteReader();
                r.Close();

                //clearing.
                cust_IDs.Items.Clear();
                get_cust_IDs();
                cust_IDs.Text = "";
                radio_cust.Checked = false;
                cust_IDs.Enabled = false;
            }
            if (radio_Emp.Checked == true)
            {
                SqlConnection c = new SqlConnection(Connection);
                c.Open();
                //Get Employee thitle..................relations................................
                SqlCommand cmd = new SqlCommand("select * from employee", c);
                SqlParameter E_ID = new SqlParameter("@E_ID",SqlDbType.Int);
                E_ID.Value = Convert.ToInt32(Emp_IDs.Text);
                cmd.Parameters.Add(E_ID);
                SqlDataReader rd = cmd.ExecuteReader();
                string title=null;
                while (rd.Read())
                { 
                    int x = Convert.ToInt32(Emp_IDs.Text);
                    int y = Convert.ToInt32(rd["ID"]);
                    if (x==y)
                    {
                        title = Convert.ToString(rd["title"]);
                    }
                }
                rd.Close();
                c.Close();
                if (title=="manager")
                {
                    //close the relation bitween manager and branch...........................................
                    SqlConnection u = new SqlConnection(Connection);
                    u.Open();
                    SqlCommand u1 = new SqlCommand("update branch set emp_id_manage=NULL where emp_id_manage=@Emp_man",u);
                    SqlParameter Emp_id = new SqlParameter("@Emp_man", SqlDbType.Int);
                    Emp_id.Value = Emp_IDs.Text;
                    u1.Parameters.Add(Emp_id);
                    u1.ExecuteNonQuery();
                    u.Close();
                }
                //Delete The Employee..........................................................
                SqlCommand com = new SqlCommand("delete from employee where ID=@ID_", con);
                SqlParameter id = new SqlParameter("@ID_", SqlDbType.Int);
                id.Value = Convert.ToInt32( Emp_IDs.Text);
                com.Parameters.Add(id);
                com.CommandType = CommandType.Text;
                SqlDataReader r = com.ExecuteReader();
                r.Close();
                Emp_IDs.Items.Clear();
                get_Emp_IDs();
                Emp_IDs.Text = "";
                radio_Emp.Checked = false;
                Emp_IDs.Enabled = false;
            }
            if (radio_Branch.Checked == true)
            {
                //remove the relation with furniture.
                SqlCommand com4 = new SqlCommand("delete from furniture_branch_relation where branch_id=@bran_ID", con);
                SqlParameter bran_id3 = new SqlParameter("@bran_ID", SqlDbType.Int);
                bran_id3.Value = Branch_IDs.Text;
                com4.Parameters.Add(bran_id3);
                com4.CommandType = CommandType.Text;
                SqlDataReader read4 = com4.ExecuteReader();
                read4.Close();


                //remove the manager from this branch.
                SqlCommand com3 = new SqlCommand("update employee set bra_ID_work=null where bra_ID_work=@bran_ID and title='manager'", con);
                SqlParameter bran_id2 = new SqlParameter("@bran_ID", SqlDbType.Int);
                bran_id2.Value = Branch_IDs.Text;
                com3.Parameters.Add(bran_id2);
                com3.CommandType = CommandType.Text;
                SqlDataReader read1 = com3.ExecuteReader();
                read1.Close();

                //Delete All the Employees form this branch.
                SqlCommand com2 = new SqlCommand("delete from employee where bra_ID_work=@bran_ID",con);
                SqlParameter bran_id = new SqlParameter("@bran_ID", SqlDbType.Int);
                bran_id.Value = Branch_IDs.Text;
                com2.Parameters.Add(bran_id);
                com2.CommandType = CommandType.Text;
                SqlDataReader read = com2.ExecuteReader();
                read.Close();

                //Delete All the Branch.
                SqlCommand com1 = new SqlCommand("delete from branch where ID=@ID_", con);
                SqlParameter id = new SqlParameter("@ID_", SqlDbType.Int);
                id.Value = Branch_IDs.Text;
                com1.Parameters.Add(id);
                com1.CommandType = CommandType.Text;
                SqlDataReader r = com1.ExecuteReader();
                r.Close();
                Branch_IDs.Items.Clear();
                get_Branch_IDs();
                Branch_IDs.Text = "";
                radio_Branch.Checked = false;
                Branch_IDs.Enabled = false;
            }

            con.Close();
        }

        private void radio_cust_CheckedChanged(object sender, EventArgs e)
        {
            cust_IDs.Enabled = true;
            Emp_IDs.Enabled = false;
            Branch_IDs.Enabled = false;
            cust_IDs.Items.Clear();
            get_cust_IDs();
        }

        private void radio_Emp_CheckedChanged(object sender, EventArgs e)
        {
            Emp_IDs.Enabled = true;
            cust_IDs.Enabled = false;
            Branch_IDs.Enabled = false;
            Emp_IDs.Items.Clear();
            get_Emp_IDs();
        }

        private void radio_Branch_CheckedChanged(object sender, EventArgs e)
        {
            Branch_IDs.Enabled = true;
            Emp_IDs.Enabled = false;
            cust_IDs.Enabled = false;
            Branch_IDs.Items.Clear();
            get_Branch_IDs();
        }
    }
}
