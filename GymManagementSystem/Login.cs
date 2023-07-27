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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-JEHSF5C;Initial Catalog=GymManagement;User ID=sa;Password=42528");
            con.Open();
            
            SqlDataAdapter da = new SqlDataAdapter("SELECT Count(*) FROM Login where userid='" + textBox1.Text + "' and password='" + textBox2.Text + "' and usertype='" +comboBox1.Text+"'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string cmbItemValue = comboBox1.SelectedItem.ToString();

            if (dt.Rows[0][0].ToString() == "1")
            {
                
                    SqlDataAdapter da1 = new SqlDataAdapter("SELECT usertype FROM Login where userid='" + textBox1.Text + "' and password='" + textBox2.Text + "'", con);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                if (dt1.Rows[0][0].ToString() == "Owner")
                {
                    this.Hide();
                    OwnerMenu om = new OwnerMenu();
                    
                    om.Show();
                }
                if (dt1.Rows[0][0].ToString() == "Manager")
                {
                    this.Hide();
                    ManagerMenu mm = new ManagerMenu();
                    
                    mm.Show();
                }
                
            }
            else
            {
                MessageBox.Show("Login Error! Incorrect UserID Or Password");
            }
            


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;

            }else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

       
    }
}
