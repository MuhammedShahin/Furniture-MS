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
    public partial class Cust_Del : UserControl
    {
     
        private static Cust_Del Cust_instance2;
        public static Cust_Del instance_Cust2
        {
            get
            {
                if (Cust_instance2 == null)
                     Cust_instance2 = new Cust_Del();
                return Cust_instance2;
            }
        }

            string Cs = "Data Source=DESKTOP-3OTKFSM;Initial Catalog = Furniture Store Management System; Integrated Security = True";


        public Cust_Del()
        {
            InitializeComponent();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
           // string Cs = "Data Source=LBOTAL-PC;Initial Catalog=Furniture Store Management System;Integrated Security=True";
            SqlConnection con = new SqlConnection(Cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from order_furniture_relation where order_id = @1 delete from order1 where ID = @1", con);
            cmd.Parameters.Add(new SqlParameter("@1", textBox5.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            textBox5.Text = "";
            MessageBox.Show("Order has been deleted successfuly");
        }
    }
}
