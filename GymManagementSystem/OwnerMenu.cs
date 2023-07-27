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
using System.Drawing.Imaging;
using System.Configuration;
using GymManagementSystem.Properties;
using System.IO;
using System.Text.RegularExpressions;
namespace GymManagementSystem
{
    public partial class OwnerMenu : Form
    {
        public OwnerMenu()
        {
            InitializeComponent();
        }
        private void totalmembersFee()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-JEHSF5C;Initial Catalog=GymManagement;User ID=sa;Password=42528");
            SqlCommand cmd = new SqlCommand("Select * from MEM", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            DataTable dtclients = new DataTable();
            dtclients.Load(sdr);
            con.Close();
            dataGridView1.DataSource = dtclients;

            decimal Total = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Total += Convert.ToDecimal(dataGridView1.Rows[i].Cells["Fee"].Value);
            }


            label3.Text = "$" + Total.ToString();
        }
        private void OwnerMenu_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-JEHSF5C;Initial Catalog=GymManagement;User ID=sa;Password=42528");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT COUNT(*) FROM MEM",con);

            DataTable dt = new DataTable();
            da.Fill(dt);
            label9.Text = dt.Rows[0][0].ToString();

        
            totalmembersFee();

            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM STF", con);
            DataTable sdt = new DataTable();
            sda.Fill(sdt);
            label5.Text = sdt.Rows[0][0].ToString();
            SqlDataAdapter eda = new SqlDataAdapter("SELECT COUNT(*) FROM EQP", con);
            DataTable edt = new DataTable();
            eda.Fill(edt);
            label7.Text = edt.Rows[0][0].ToString();
            con.Close();

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            AddStaff AddStaff = new AddStaff();
            AddStaff.Show();
            AddStaff.Tag = this;
            Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SearchStaff SearchStaff = new SearchStaff();
            SearchStaff.Show();
            SearchStaff.Tag = this;
            Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            UpdateAndDeleteStaff UpdateAndDeleteStaff = new UpdateAndDeleteStaff();
            UpdateAndDeleteStaff.Show();
            UpdateAndDeleteStaff.Tag = this;
            Hide();
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            AddNewTrainer AddNewTrainer = new AddNewTrainer();
            AddNewTrainer.Show();
            AddNewTrainer.Tag = this;
            Hide();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            SearchTrainer SearchTrainer = new SearchTrainer();
            SearchTrainer.Show();
            SearchTrainer.Tag = this;
            Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            UpdateAndDeleteTrainer UpdateAndDeleteTrainer = new UpdateAndDeleteTrainer();
            UpdateAndDeleteTrainer.Show();
            UpdateAndDeleteTrainer.Tag = this;
            Hide();
        }
        private void button7_Click_1(object sender, EventArgs e)
        {
            ViewMember ViewMember = new ViewMember();
            ViewMember.Show();
            ViewMember.Tag = this;
            Hide();
        }

        

        private void button9_Click_1(object sender, EventArgs e)
        {
            AddEquipments AddEquipments = new AddEquipments();
            AddEquipments.Show();
            AddEquipments.Tag = this;
            Hide();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            ViewEquipment ViewEquipment = new ViewEquipment();
            ViewEquipment.Show();
            ViewEquipment.Tag = this;
            Hide();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Login Login = new Login();
            Login.Show();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
