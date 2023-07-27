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
    public partial class MemberAttendence : Form
    {
        public MemberAttendence()
        {
            InitializeComponent();
        }
        void BindData()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-JEHSF5C;Initial Catalog=GymManagement;User ID=sa;Password=42528");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM MEM", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }
        private void MemberAttendence_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-JEHSF5C;Initial Catalog=GymManagement;User ID=sa;Password=42528");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM MEM", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-JEHSF5C;Initial Catalog=GymManagement;User ID=sa;Password=42528");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE MEM SET Attendence=@Attendence, Attendence_Time=@Attendence_Time WHERE M_ID = @M_ID", con);
            cmd.Parameters.AddWithValue("@M_ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Attendence", textBox3.Text);
            cmd.Parameters.AddWithValue("@Attendence_Time", dateTimePicker1.Value);
            

            cmd.ExecuteNonQuery();
            con.Close();

   
       
            BindData();
            MessageBox.Show("Successfully Submitted");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagerMenu ManagerMenu = new ManagerMenu();
            ManagerMenu.Show();
        }
    }
}
