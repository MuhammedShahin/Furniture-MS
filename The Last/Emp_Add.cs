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
    public partial class Emp_Add : UserControl
    {


        //send the user control to the Form .......................................
        private static Emp_Add Emp_instance;
        public static Emp_Add instance_Emp
        {
            get
            {
                if (Emp_instance == null)
                    Emp_instance = new Emp_Add();
                return Emp_instance;
            }
        }
        string conection = "Data Source=DESKTOP-3OTKFSM;Initial Catalog=Furniture Store Management System;Integrated Security=True";
        void get_branch_ids()
        {
            SqlConnection con = new SqlConnection(conection);
            con.Open();
            SqlCommand com = new SqlCommand("select ID from branch", con);
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                int id = (int)read["ID"];
               combo_branch_id.Items.Add(id);
            }
            con.Close();
            read.Close();
        }
        
        public Emp_Add()
        {
            InitializeComponent();
            get_branch_ids();
        }

        private void Emp_Add_Load(object sender, EventArgs e)
        {

        }

        private void Size_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conection);
            con.Open();
            
                SqlCommand cmd1 = new SqlCommand("Select ID from category where name = @m", con);
                cmd1.Parameters.AddWithValue("@m", cate_text.Text);
                int CatID;
                string re = Convert.ToString(cmd1.ExecuteScalar());
                if (re == "")
                {
                    SqlCommand com3 = new SqlCommand("insert into category (name) values (@name)", con);
                    com3.Parameters.AddWithValue("@name", cate_text.Text);
                    com3.ExecuteNonQuery();
                    SqlCommand cmd4 = new SqlCommand("Select ID from category where name = @m", con);
                    cmd4.Parameters.AddWithValue("@m", cate_text.Text);
                    CatID = (int)cmd1.ExecuteScalar();
                }
                else
                {
                    CatID = Convert.ToInt32(re);
                }
                SqlCommand cmd = new SqlCommand("insert into furniture(size,color,model,price,units_in_stock,cat_id)values (@size,@c,@m,@p,@UnitInstock,@id)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@size", textBox1.Text);
                cmd.Parameters.AddWithValue("@c", textBox2.Text);
                cmd.Parameters.AddWithValue("@m", textBox3.Text);
                cmd.Parameters.AddWithValue("@p", textBox4.Text);
                cmd.Parameters.AddWithValue("@UnitInstock", textBox5.Text);
                cmd.Parameters.AddWithValue("@id", CatID);
                cmd.ExecuteNonQuery();
                SqlCommand com8 = new SqlCommand("select ID from furniture where size=@size and color=@color and model=@model", con);
                com8.Parameters.AddWithValue("@size", textBox1.Text);
                com8.Parameters.AddWithValue("@color", textBox2.Text);
                com8.Parameters.AddWithValue("@model", textBox3.Text);
                int id_furnture = (int)com8.ExecuteScalar();
                SqlCommand com9 = new SqlCommand("insert into furniture_branch_relation (furniture_id,branch_id) values (@id_furn,@id_branch)", con);
                com9.Parameters.AddWithValue("@id_furn", id_furnture);
                com9.Parameters.AddWithValue("@id_branch", Convert.ToInt32(combo_branch_id.Text));
                com9.ExecuteNonQuery();
                con.Close();
                combo_branch_id.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                cate_text.Text = "";
            MessageBox.Show("Success Add");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            
        }
    }
}
