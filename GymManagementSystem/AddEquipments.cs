using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class AddEquipments : Form
    {
        public AddEquipments()
        {
            InitializeComponent();
        }
        void BindData()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-JEHSF5C;Initial Catalog=GymManagement;User ID=sa;Password=42528");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM EQP", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


        }
        private void AddEquipments_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-JEHSF5C;Initial Catalog=GymManagement;User ID=sa;Password=42528");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM EQP", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-JEHSF5C;Initial Catalog=GymManagement;User ID=sa;Password=42528");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO EQP(E_ID, EQUIP_NAME, Muscle_Used,Delivery_Date, COST) VALUES(@E_ID, @EQUIP_NAME, @Muscle_Used, @Delivery_Date, @COST)", con);
            cmd.Parameters.AddWithValue("@E_ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@EQUIP_NAME", textBox2.Text);
            cmd.Parameters.AddWithValue("@Muscle_Used", textBox3.Text);
            cmd.Parameters.AddWithValue("@Delivery_Date", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@COST", int.Parse(textBox5.Text));
       
            cmd.ExecuteNonQuery();
            con.Close();
         
            BindData();
            MessageBox.Show("Successfully Inserted");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dateTimePicker1.Value = DateTime.Now;
            textBox5.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            OwnerMenu OwnerMenu = new OwnerMenu();
            OwnerMenu.Show();
        }
    }
}
