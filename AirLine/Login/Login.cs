using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;


namespace AirLine.Login
{
    public partial class Login : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=.;Initial Catalog=AkbarPoorAirLineAgency;Integrated Security=True");
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        public Login()
        {
            InitializeComponent();
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
        }
        private void Login_Load(object sender, EventArgs e)
        {
            if (textBox1.Text == "نام کاربری")
            {
                textBox1.ForeColor = Color.LightGray;
            }
            if (textBox2.Text == "رمز عبور")
            {
                textBox2.ForeColor = Color.LightGray;
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text == "نام کاربری")
            {
                textBox1.Text = null;
                textBox1.ForeColor = Color.WhiteSmoke;
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( textBox2.Text == "رمز عبور")
            {
                textBox2.Text = null;
                textBox2.ForeColor = Color.WhiteSmoke;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter Login = new SqlDataAdapter("Select * From dbo.[User] Where Username ='" + textBox1.Text + "' and Password ='" + textBox2.Text + "'", Con);
                DataTable LoginDT = new DataTable();
                Login.Fill(LoginDT);
                if (LoginDT.Rows.Count == 1 )
                {
                    GlobalInfo.UsernameLogin = LoginDT.Rows[0][11].ToString();
                    GlobalInfo.NameLogin = LoginDT.Rows[0][0].ToString();
                    GlobalInfo.LastnameLogin = LoginDT.Rows[0][1].ToString();
                    GlobalInfo.PositionLogin = LoginDT.Rows[0][8].ToString();
                    Form MainForm = new MainForm();
                    MainForm.Show();
                    this.Hide();
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
    }
}
public static class GlobalInfo
{
    public static string UsernameLogin;
    public static string NameLogin;
    public static string LastnameLogin;
    public static string PositionLogin;
}
