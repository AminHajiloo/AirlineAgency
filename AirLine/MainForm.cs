using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace AirLine
{
    public partial class MainForm : Form
    {
        string pdate;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MaxBtn.Enabled = false;
            label5.Text = GlobalInfo.NameLogin + " " + GlobalInfo.LastnameLogin;
            label6.Text = GlobalInfo.PositionLogin;
            PersianCalendar pc = new PersianCalendar();
            pdate = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
            label3.Text = pdate;

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.DarkGreen;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(51, 51, 76);
        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Coral;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(51, 51, 76);
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.BlueViolet;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(51, 51, 76);
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.DarkBlue;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(51, 51, 76);
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.Brown;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(51, 51, 76);
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            button6.BackColor = Color.DeepPink;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(51, 51, 76);
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            button7.BackColor = Color.DarkKhaki;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.BackColor = Color.FromArgb(51, 51, 76);
        }
        private void button8_MouseEnter(object sender, EventArgs e)
        {
            button8.BackColor = Color.DarkRed;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.BackColor = Color.FromArgb(51, 51, 76);
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            button9.ForeColor = Color.LightBlue;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.ForeColor = Color.White;
        }
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void MinBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form FlightSchedule = new FlightSchedule.FlightSchedule();
            FlightSchedule.MdiParent = this;
            FlightSchedule.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Ticket = new Ticket.Ticket();
            Ticket.MdiParent = this;
            Ticket.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form DomesticTour = new DomesticTour.DomesticTour();
            DomesticTour.MdiParent = this;
            DomesticTour.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form ForeignTour = new ForeignTour.ForeignTour();
            ForeignTour.MdiParent = this;
            ForeignTour.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form TourTicket = new TourTicket.TourTicket();
            TourTicket.MdiParent = this;
            TourTicket.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form User = new User.User();
            User.MdiParent = this;
            User.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form ContactUs = new ContactUs.ContactUs();
            ContactUs.MdiParent = this;
            ContactUs.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form ChangePassword = new ChangePassword.ChabgePassword();
            ChangePassword.MdiParent = this;
            ChangePassword.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form Login = new Login.Login();
            Login.Show();
            this.Hide();
        }

    }
}
