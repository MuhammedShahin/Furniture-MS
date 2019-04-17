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
    public partial class Signup : UserControl
    {
        //send the user control to the Form .......................................
        private static Signup Cust_instance4;
        public static Signup instance_Cust4
        {
            get
            {
                if (Cust_instance4 == null)
                    Cust_instance4 = new Signup();
                return Cust_instance4;
            }
        }
        string Cs = "Data Source=DESKTOP-3OTKFSM;Initial Catalog = Furniture Store Management System; Integrated Security = True";
        public Signup()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Cs);
            con.Open();
          
            //one Admin for the system.
            string ToAddCustomer = "INSERT INTO customer(name , phone_number , E_mail , address , password,adm_ID ) VALUES ( @name , @num , @Email , @address , @pass , 1) ";
            SqlCommand cmd = new SqlCommand(ToAddCustomer, con);
            cmd.CommandType = CommandType.Text;

            SqlParameter name = new SqlParameter("@name", textBox3.Text);
            SqlParameter num = new SqlParameter("@num", textBox4.Text);
            SqlParameter Email = new SqlParameter("@Email", textBox5.Text);
            SqlParameter address = new SqlParameter("@address", textBox6.Text);
            SqlParameter pass = new SqlParameter("@pass", textBox7.Text);
            
            cmd.Parameters.Add(name);
            cmd.Parameters.Add(num);
            cmd.Parameters.Add(Email);
            cmd.Parameters.Add(address);
            cmd.Parameters.Add(pass);

            cmd.ExecuteNonQuery();
            con.Close();
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            MessageBox.Show("You Created an Account .. ");
        }
    }
}
