using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirLine.ChangePassword
{
    public partial class ChabgePassword : Form
    {
        public ChabgePassword()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == textBox2.Text)
            {
                userTableAdapter.UpdatePasswordQuery(textBox1.Text, GlobalInfo.UsernameLogin);
                textBox1.Text = null; textBox2.Text = null;
                MessageBox.Show("عملیات موفقیت آمیز انجام شد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("رمز ها همخوانی ندارد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ChabgePassword_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'airLaneDataSet.User' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.airLaneDataSet.User);

        }
    }
}
