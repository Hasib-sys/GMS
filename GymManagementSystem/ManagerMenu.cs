using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class ManagerMenu : Form
    {
        public ManagerMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewMember AddNewMember = new AddNewMember();
            AddNewMember.Show();
            AddNewMember.Tag = this;
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchMember SearchMember = new SearchMember();
            SearchMember.Show();
            SearchMember.Tag = this;
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteMember DeleteMember = new DeleteMember();
            DeleteMember.Show();
            DeleteMember.Tag = this;
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateMember UpdateMember = new UpdateMember();
            UpdateMember.Show();
            UpdateMember.Tag = this;
            Hide();
        }

        

        private void button9_Click(object sender, EventArgs e)
        {
            MemberAttendence MemberAttendence = new MemberAttendence();
            MemberAttendence.Show();
            MemberAttendence.Tag = this;
            Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TrainerAttendence TrainerAttendence = new TrainerAttendence();
            TrainerAttendence.Show();
            TrainerAttendence.Tag = this;
            Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
            Login Login = new Login();
            Login.Show();
        }
    }
}
