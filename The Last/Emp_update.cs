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
    public partial class Emp_update : UserControl
    {
        //send the user control to the Form .......................................
        private static Emp_update Emp_instance1;
        public static Emp_update instance_Emp1
        {
            get
            {
                if (Emp_instance1 == null)
                    Emp_instance1 = new Emp_update();
                return Emp_instance1;
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
                comboBox_ID.Items.Add(id);
            }
            read.Close();
            con.Close();
        }
        public Emp_update()
        {
            InitializeComponent();
            fill_combobox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conection);
            con.Open();
            if (combobox_update.SelectedIndex == 0)
            {
                SqlCommand com2 = new SqlCommand("update furniture set size=@size where ID=@id", con);
                com2.Parameters.AddWithValue("@size", Convert.ToInt32(textBox_update.Text));
                com2.Parameters.AddWithValue("@ID", Convert.ToInt32(comboBox_ID.Text));
                com2.ExecuteNonQuery();
            }
            else if (combobox_update.SelectedIndex == 1)
            {
                SqlCommand com2 = new SqlCommand("update furniture set color=@color where ID=@id", con);
                com2.Parameters.AddWithValue("@color", Convert.ToString(textBox_update.Text));
                com2.Parameters.AddWithValue("@ID", Convert.ToInt32(comboBox_ID.Text));
                com2.ExecuteNonQuery();
            }
            else if (combobox_update.SelectedIndex == 2)
            {
                SqlCommand com2 = new SqlCommand("update furniture set model=@model where ID=@id", con);
                com2.Parameters.AddWithValue("@model", Convert.ToString(textBox_update.Text));
                com2.Parameters.AddWithValue("@ID", Convert.ToInt32(comboBox_ID.Text));
                com2.ExecuteNonQuery();
            }
            else if (combobox_update.SelectedIndex == 3)
            {
                SqlCommand com2 = new SqlCommand("update furniture set price=@price where ID=@id", con);
                com2.Parameters.AddWithValue("@price", Convert.ToInt32(textBox_update.Text));
                com2.Parameters.AddWithValue("@ID", Convert.ToInt32(comboBox_ID.Text));
                com2.ExecuteNonQuery();
            }
            else if (combobox_update.SelectedIndex == 4)
            {
                SqlCommand com2 = new SqlCommand("update furniture set units_in_stock=@units_in_stock where ID=@id", con);
                com2.Parameters.AddWithValue("@units_in_stock", Convert.ToInt32(textBox_update.Text));
                com2.Parameters.AddWithValue("@ID", Convert.ToInt32(comboBox_ID.Text));
                com2.ExecuteNonQuery();
            }
            fill_combobox();
            con.Close();
            textBox_update.Text = "";
            comboBox_ID.Text = "";
            combobox_update.Text = "";
            MessageBox.Show("Updated !");
        }
    }
}
