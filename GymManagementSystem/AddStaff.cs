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
    public partial class AddStaff : Form
    {
        public AddStaff()
        {
            InitializeComponent();
        }
        void BindData()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-JEHSF5C;Initial Catalog=GymManagement;User ID=sa;Password=42528");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM STF", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


        }
        private void AddStaff_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-JEHSF5C;Initial Catalog=GymManagement;User ID=sa;Password=42528");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM STF", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
        }
        private byte[] savephoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-JEHSF5C;Initial Catalog=GymManagement;User ID=sa;Password=42528");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO STF(S_ID, Staff_Type, Name, Age,Email, Contact_No, DOB, Address, Gender, Join_Date,Salary,Photo) VALUES(@S_ID,@Staff_Type, @Name, @Age, @Email, @Contact_No, @DOB, @Address, @Gender, @Join_Date, @Salary,@Photo)", con);
            cmd.Parameters.AddWithValue("@S_ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Staff_Type", textBox2.Text);
            cmd.Parameters.AddWithValue("@Name", textBox3.Text);
            cmd.Parameters.AddWithValue("@Age", int.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@Email", textBox5.Text);
            cmd.Parameters.AddWithValue("@Contact_No", int.Parse(textBox6.Text));
            cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Address", textBox8.Text);
            cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Join_Date", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@Salary", int.Parse(textBox11.Text));
            cmd.Parameters.AddWithValue("@Photo", savephoto());

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
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            
            textBox8.Clear();
            comboBox1.SelectedIndex=-1;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            textBox11.Clear();

        }
       

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
            OwnerMenu OwnerMenu = new OwnerMenu();
            OwnerMenu.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Profile Picture";
            ofd.Filter = "Image file(*.png; *.jpg; *.gif)|*.png; *.jpg; *.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

       
    }
}
