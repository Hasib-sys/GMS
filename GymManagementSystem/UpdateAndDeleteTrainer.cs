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
    public partial class UpdateAndDeleteTrainer : Form
    {
        public UpdateAndDeleteTrainer()
        {
            InitializeComponent();
        }

        void BindData()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-JEHSF5C;Initial Catalog=GymManagement;User ID=sa;Password=42528");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TRN", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void UpdateAndDeleteTrainer_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-JEHSF5C;Initial Catalog=GymManagement;User ID=sa;Password=42528");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TRN", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
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
            SqlCommand cmd = new SqlCommand("UPDATE  Trainer SET  Name=@Name, Age=@Age, Email=@Email, Contact_No=@Contact_No, DOB=@DOB,Address=@Address,Gender=@Gender,Join_Date=@Join_Date, Salary=@Salary, Shift=@Shift,Photo=@Photo WHERE T_ID=@T_ID", con);
            cmd.Parameters.AddWithValue("@T_ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Age", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@Email", textBox4.Text);
            cmd.Parameters.AddWithValue("@Contact_No", int.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Address", textBox7.Text);
            cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Join_Date", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@Salary", int.Parse(textBox10.Text));
            cmd.Parameters.AddWithValue("@Shift", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Photo", savephoto());
            cmd.ExecuteNonQuery();
            con.Close();
      
            BindData();
            MessageBox.Show("Successfully Updated");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-JEHSF5C;Initial Catalog=GymManagement;User ID=sa;Password=42528");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM TRN WHERE T_ID=@T_ID", con);
            cmd.Parameters.AddWithValue("@T_ID", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            BindData();

            MessageBox.Show("Successfully Deleted");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            OwnerMenu OwnerMenu = new OwnerMenu();
            OwnerMenu.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["T_ID"].Value.ToString();
                textBox2.Text = row.Cells["Name"].Value.ToString();
                textBox3.Text = row.Cells["Age"].Value.ToString();
                textBox4.Text = row.Cells["Email"].Value.ToString();
                textBox5.Text = row.Cells["Contact_No"].Value.ToString();
                dateTimePicker1.Text = row.Cells["DOB"].Value.ToString();
                textBox7.Text = row.Cells["Address"].Value.ToString();
                comboBox1.Text = row.Cells["Gender"].Value.ToString();
                dateTimePicker2.Text = row.Cells["Join_Date"].Value.ToString();
                textBox10.Text = row.Cells["Salary"].Value.ToString();
                var data = (Byte[])(row.Cells["Photo"].Value);
                var stream = new MemoryStream(data);
                pictureBox1.Image = Image.FromStream(stream);
            }
        }
    }
}
