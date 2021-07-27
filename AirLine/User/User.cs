using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AirLine.User
{
    public partial class User : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=.;Initial Catalog=AkbarPoorAirLineAgency;Integrated Security=True");
        public User()
        {
            InitializeComponent();
        }
        public static void ClearAllText(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else
                    ClearAllText(c);
            }
        }
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void User_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'airLaneDataSet.User' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.airLaneDataSet.User);
            groupBox1.Visible = false; UserDataGridView.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter Login = new SqlDataAdapter("Select Count(*) From dbo.[User] Where Username ='" + textBox14.Text + "' and Password ='" + textBox15.Text + "'and Roll= N'مدیر'", Con);
                DataTable LoginDT = new DataTable();
                Login.Fill(LoginDT);
                if (LoginDT.Rows[0][0].ToString() == "1")
                {
                    groupBox1.Visible = true; UserDataGridView.Visible = true;
                    textBox14.Enabled = false; textBox15.Enabled = false; button4.Enabled = false;
                    textBox14.Text = null; textBox15.Text = null;
                }
                else
                {
                    MessageBox.Show("نام کاربری یا رمز عبور اشتباه می باشد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در انجام عملیات", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                userTableAdapter.InsertQuery(textBox1.Text, textBox2.Text, comboBox1.SelectedItem.ToString(), textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text,
                    textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, textBox12.Text, textBox13.Text, "کاربر");
                this.userTableAdapter.Fill(this.airLaneDataSet.User);
                MessageBox.Show("عملیات موفقیت آمیز انجام شد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAllText(this); comboBox1.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در انجام عملیات", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                userTableAdapter.UpdateQuery(textBox1.Text, textBox2.Text, comboBox1.SelectedItem.ToString(), textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text,
                    textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, textBox12.Text, textBox13.Text, "کاربر", UserDataGridView.SelectedRows[0].Cells[11].Value.ToString());
                this.userTableAdapter.Fill(this.airLaneDataSet.User);
                MessageBox.Show("عملیات موفقیت آمیز انجام شد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAllText(this); comboBox1.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در انجام عملیات", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                userTableAdapter.DeleteQuery(UserDataGridView.SelectedRows[0].Cells[11].Value.ToString());
                this.userTableAdapter.Fill(this.airLaneDataSet.User);
                MessageBox.Show("عملیات موفقیت آمیز انجام شد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAllText(this); comboBox1.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در انجام عملیات", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (UserDataGridView.SelectedRows[0].Cells[14].Value.ToString() == "مدیر")
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
            textBox1.Text = UserDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = UserDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            comboBox1.SelectedItem = UserDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = UserDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = UserDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = UserDataGridView.SelectedRows[0].Cells[5].Value.ToString();
            textBox6.Text = UserDataGridView.SelectedRows[0].Cells[6].Value.ToString();
            textBox7.Text = UserDataGridView.SelectedRows[0].Cells[7].Value.ToString();
            textBox8.Text = UserDataGridView.SelectedRows[0].Cells[8].Value.ToString();
            textBox9.Text = UserDataGridView.SelectedRows[0].Cells[9].Value.ToString();
            textBox10.Text = UserDataGridView.SelectedRows[0].Cells[10].Value.ToString();
            textBox11.Text = UserDataGridView.SelectedRows[0].Cells[11].Value.ToString();
            textBox12.Text = UserDataGridView.SelectedRows[0].Cells[12].Value.ToString();
            textBox13.Text = UserDataGridView.SelectedRows[0].Cells[13].Value.ToString();
        }
    }
}
