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
    public partial class Emp_Delete : UserControl
    {
        //send the user control to the Form .......................................
        private static Emp_Delete Emp_instance2;
        public static Emp_Delete instance_Emp2
        {
            get
            {
                if (Emp_instance2 == null)
                    Emp_instance2 = new Emp_Delete();
                return Emp_instance2;
            }
        }



        string conection = "Data Source=DESKTOP-3OTKFSM;Initial Catalog=Furniture Store Management System;Integrated Security=True";
        void fill_combobox()
        {
            SqlConnection con = new SqlConnection(conection);
            con.Open();
            SqlCommand com6 = new SqlCommand("select ID from furniture", con);
            SqlDataReader read = com6.ExecuteReader();
            while (read.Read())
            {
                int id = Convert.ToInt32(read["ID"]);
               
                comboBox_delete.Items.Add(id);
            }
            read.Close();
            con.Close();
        }
        public Emp_Delete()
        {
            InitializeComponent();
            fill_combobox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conection);
            con.Open();
            SqlCommand cm = new SqlCommand("delete from order_furniture_relation where order_id =@id", con);
            cm.Parameters.AddWithValue("@id", comboBox_delete.SelectedItem);
            cm.ExecuteNonQuery();
            SqlCommand cmd = new SqlCommand("delete from furniture where ID=@id", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", comboBox_delete.SelectedItem);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Deleted");
            comboBox_delete.Items.Clear();
            comboBox_delete.Text = "";
            fill_combobox();
            con.Close();
        }
    }
}
