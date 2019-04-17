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
    public partial class Cust_Add : UserControl
    {
        private static Cust_Add Cust_instance;
        public static Cust_Add instance_Cust
        {
            get
            {
                if (Cust_instance == null)
                    Cust_instance = new Cust_Add();
                return Cust_instance;
            }
        }
        string Cs = "Data Source=DESKTOP-3OTKFSM;Initial Catalog = Furniture Store Management System; Integrated Security = True";


        public Cust_Add()
        {
            InitializeComponent();
            get_Category();
            get_model();
        }



        void get_Category()
        {
            SqlConnection con = new SqlConnection(Cs);
            con.Open();
            SqlCommand com = new SqlCommand("select name from category", con);
            SqlDataReader rd = com.ExecuteReader();
            while (rd.Read())
            {
                string name = (string)rd["name"];
                comboBox10.Items.Add(name);
            }
        }
        void get_model()
        {
            Dictionary<string, int> model = new Dictionary<string, int>();
            SqlConnection con = new SqlConnection(Cs);
            con.Open();
            SqlCommand com = new SqlCommand("select model from furniture", con);
            SqlDataReader re = com.ExecuteReader();
            while (re.Read())
            {
                model[re["model"].ToString()] = 0;
            }
            foreach (KeyValuePair<string, int> k in model)
            {
                comboBox3.Items.Add(k.Key);
            }
        }
        int countOfFur = 0;
        int total = 0;
        //int chaircounter = 0;
        //int tablecounter = 0;
        //int bedcounter = 0;
        int[] CountAdder = new int[100];
        void ReturnValues(int x, int y, int z)
        {
            CountAdder[y - 1] = z;
            total += x;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string Cs = "Data Source=DESKTOP-L0VPAVI\\SQLEXPRESS;Initial Catalog=Furniture Store Management System;Integrated Security=True";
          
            SqlConnection con = new SqlConnection(Cs);
            con.Open();
            SqlCommand com = new SqlCommand("select ID from category where name=@name", con);
            com.Parameters.Add(new SqlParameter("@name", comboBox10.Text));
            int id = (int)com.ExecuteScalar();
            string C = "select price from furniture where size=@s and color = @c and model=@m and cat_id=@m1";
            SqlCommand cmd = new SqlCommand(C, con);
            cmd.Parameters.Add(new SqlParameter("@s", comboBox1.Text));
            cmd.Parameters.Add(new SqlParameter("@c", comboBox2.Text));
            cmd.Parameters.Add(new SqlParameter("@m", comboBox3.Text));
            cmd.Parameters.Add(new SqlParameter("@m1", id));
            int price = (int)cmd.ExecuteScalar();
            countOfFur++;
            /*if (comboBox3.Text=="chair")
            {
                chaircounter++;
            }
            else if (comboBox3.Text == "table")
            {
                tablecounter++;
            }
            else if (comboBox3.Text == "bed")
            {
                bedcounter++;
            }*/
            SqlCommand cmd4 = new SqlCommand("select ID from furniture where model=@m and size =@mmm and color = @mm and cat_id=@mmmm", con);
            cmd4.Parameters.Add(new SqlParameter("@m", comboBox3.Text));
            cmd4.Parameters.Add(new SqlParameter("@mm", comboBox2.Text));
            cmd4.Parameters.Add(new SqlParameter("@mmm", comboBox1.Text));
            cmd4.Parameters.Add(new SqlParameter("@mmmm", id));
            int IDD = (int)cmd4.ExecuteScalar();
            ReturnValues(price, countOfFur, IDD);
            con.Close();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            string s = taskDATE3.Text + "-" + taskDATE1.Text + "-" + taskDATE2.Text;
            string o = textBox1.Text + "-" + textBox6.Text + "-" + textBox2.Text;
            //string Cs = "Data Source=DESKTOP-L0VPAVI\\SQLEXPRESS;Initial Catalog=Furniture Store Management System;Integrated Security=True";
        //    string Cs = "Data Source=LBOTAL-PC;Initial Catalog=Furniture Store Management System;Integrated Security=True";
            SqlConnection con = new SqlConnection(Cs);
            con.Open();
            //SqlCommand cmd = new SqlCommand("InsertToOrder", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            SqlCommand cmd = new SqlCommand("insert into order1(Delivery_Date, Order_Data, Address, Num_Of_Items, Total_Cost) values(@ddate, @odate, @address, @noitems, @total)", con);
            cmd.Parameters.Add(new SqlParameter("@ddate", s));
            cmd.Parameters.Add(new SqlParameter("@odate", o));
            cmd.Parameters.Add(new SqlParameter("@address", textBox3.Text));
            cmd.Parameters.Add(new SqlParameter("@noitems", countOfFur));
            cmd.Parameters.Add(new SqlParameter("@total", total));
            cmd.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand("select * from order1", con);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            int ID = 0;
            while (reader1.Read())
            {
                string x = Convert.ToString(reader1["Delivery_Date"]);
                string y = Convert.ToString(reader1["Order_Data"]);
                string z = Convert.ToString(reader1["Address"]);
                if (s == x && o == y && z == textBox3.Text)
                {
                    ID = Convert.ToInt32(reader1["ID"]);
                }
            }
            reader1.Close();
            //d hit3dl x login lsa
            SqlCommand cmd2 = new SqlCommand("select ID from customer where password=@to ", con);
            cmd2.Parameters.Add(new SqlParameter("@to", cust_pass.Text));
            int id = (int)cmd2.ExecuteScalar();
            SqlCommand cmd3 = new SqlCommand("update order1 set cust_id = @ddd where ID=@dd ", con);
            cmd3.Parameters.Add(new SqlParameter("@dd", ID));
            cmd3.Parameters.Add(new SqlParameter("@ddd", id));
            cmd3.ExecuteNonQuery();
            //bool v = true;
            for (int i = 0; i < countOfFur; i++)
            {
                SqlCommand cmd4 = new SqlCommand("insert into order_furniture_relation(order_id,furniture_id) values (@1,@2)", con);
                cmd4.Parameters.Add(new SqlParameter("@1", ID));
                cmd4.Parameters.Add(new SqlParameter("@2", CountAdder[i]));
                cmd4.ExecuteNonQuery();
                /*if (v==true)
                {
                    cmd4.ExecuteNonQuery();
                }*/
                /*for (int j = 0; j < i + 1; j++)
                {
                    if (CountAdder[i+1]==CountAdder[j])
                    {
                        v = false;
                    }          
                }*/
            }
            /*SqlCommand cmd5 = new SqlCommand("select ID from category where name=@mm", con);
            cmd5.Parameters.Add(new SqlParameter("@mm", "chair"));
            int IDD = (int)cmd5.ExecuteScalar();
            SqlCommand cmd6 = new SqlCommand("update order_furniture_relation set Num_Used = @3 where order_id=@4", con);
            cmd6.Parameters.Add(new SqlParameter("@3", chaircounter));
            cmd6.Parameters.Add(new SqlParameter("@4", ID));
            cmd6.ExecuteNonQuery();
            /*SqlCommand cmd7 = new SqlCommand("select ID from category where name=@mmm", con);
            cmd7.Parameters.Add(new SqlParameter("@mmm", "table"));
            int IDDD = (int)cmd7.ExecuteScalar();*
            SqlCommand cmd8 = new SqlCommand("update order_furniture_relation set Num_Used = @33 where order_id=@44", con);
            cmd8.Parameters.Add(new SqlParameter("@33", tablecounter));
            cmd8.Parameters.Add(new SqlParameter("@44", ID));
            cmd8.ExecuteNonQuery();
            /*SqlCommand cmd9 = new SqlCommand("select ID from category where name=@mmmm", con);
            cmd9.Parameters.Add(new SqlParameter("@mmmm", "bed"));
            int IDDDD = (int)cmd9.ExecuteScalar();
            SqlCommand cmd10 = new SqlCommand("update order_furniture_relation set Num_Used = @333 where order_id=@444", con);
            cmd10.Parameters.Add(new SqlParameter("@333", bedcounter));
            cmd10.Parameters.Add(new SqlParameter("@444", ID));
            cmd10.ExecuteNonQuery();*/
            for (int i = 0; i < countOfFur; i++)
            {
                CountAdder[i] = 0;
            }
            countOfFur = 0;
            total = 0;
            MessageBox.Show("Order has been added successfuly");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(countOfFur.ToString());
            listBox1.Items.Add(total.ToString());
            //listBox1.Items.Add(chaircounter.ToString());
            //listBox1.Items.Add(tablecounter.ToString());
            //listBox1.Items.Add(bedcounter.ToString());
        }

        private void cust_pass_TextChanged(object sender, EventArgs e)
        {
            if (cust_pass.Text == null)
                Add.Enabled = false;
            else
            {
                Add.Enabled = true;
            }
        }
    }
}
