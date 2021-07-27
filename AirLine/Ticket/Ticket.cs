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

namespace AirLine.Ticket
{
    public partial class Ticket : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=.;Initial Catalog=AkbarPoorAirLineAgency;Integrated Security=True");
        public Ticket()
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

        private void Ticket_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'airLaneDataSet.FlightSchedule' table. You can move, or remove it, as needed.
            this.flightScheduleTableAdapter.Fill(this.airLaneDataSet.FlightSchedule);
            // TODO: This line of code loads data into the 'airLaneDataSet.Tikcet' table. You can move, or remove it, as needed.
            this.tikcetTableAdapter.Fill(this.airLaneDataSet.Tikcet);
            button1.Enabled = false;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter FindInfo = new SqlDataAdapter("Select Destination,BoardingTime,Date FROM FlightSchedule WHERE RegisterNo ='" + int.Parse(comboBox2.SelectedValue.ToString()) + "'", Con);
            DataTable FindInfoDT = new DataTable();
            FindInfo.Fill(FindInfoDT);
            textBox6.Text = FindInfoDT.Rows[0][0].ToString();
            textBox7.Text = FindInfoDT.Rows[0][2].ToString();
            textBox8.Text = FindInfoDT.Rows[0][1].ToString();
            FindInfoDT.Clear();
            Con.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                tikcetTableAdapter.InsertQuery(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.SelectedItem.ToString(), textBox4.Text, textBox5.Text, Convert.ToInt32(comboBox2.SelectedValue.ToString()));
                this.tikcetTableAdapter.Fill(this.airLaneDataSet.Tikcet);
                MessageBox.Show("عملیات موفقیت آمیز انجام شد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAllText(this);
                comboBox1.SelectedIndex = -1;
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
                tikcetTableAdapter.DeleteQuery(Convert.ToInt32(tikcetDataGridView.SelectedRows[0].Cells[0].Value.ToString()));
                this.flightScheduleTableAdapter.Fill(this.airLaneDataSet.FlightSchedule);
                MessageBox.Show("عملیات موفقیت آمیز انجام شد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAllText(this);
                comboBox1.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در انجام عملیات", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tikcetDataGridView.SelectedRows.Count !=0 )
            {
                tikcetTableAdapter.FillByRpt(airLaneDataSet.Tikcet, Convert.ToInt16(tikcetDataGridView.SelectedRows[0].Cells[0].Value.ToString()));
                AirLine.TicketReport.CrystalReportTicket rpt = new AirLine.TicketReport.CrystalReportTicket();
                rpt.SetDataSource(airLaneDataSet);
                TicketReport.TicketReport frpt = new TicketReport.TicketReport();
                frpt.Owner = this;
                frpt.crystalReportViewer1.ReportSource = rpt;
                frpt.Show();
            }
            else
            {
                MessageBox.Show("بلیطی از جدول زیر انتخاب نشده است", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
