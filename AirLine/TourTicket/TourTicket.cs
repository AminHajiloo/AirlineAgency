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

namespace AirLine.TourTicket
{
    public partial class TourTicket : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=.;Initial Catalog=AkbarPoorAirLineAgency;Integrated Security=True");
        public TourTicket()
        {
            InitializeComponent();
        }

        private void TourTicket_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'airLaneDataSet.TourTicket' table. You can move, or remove it, as needed.
            this.tourTicketTableAdapter.Fill(this.airLaneDataSet.TourTicket);
            // TODO: This line of code loads data into the 'airLaneDataSet.Tour' table. You can move, or remove it, as needed.
            this.tourTableAdapter.FillByComboBox(this.airLaneDataSet.Tour);
            button1.Enabled = false;
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter FindInfo = new SqlDataAdapter("SELECT Destination, BoardingDate,ReturnDate FROM Tour WHERE RegisterNo ='" + comboBox2.SelectedValue.ToString() + "'", Con);
            DataTable FindInfoDT = new DataTable();
            FindInfo.Fill(FindInfoDT);
            textBox6.Text = FindInfoDT.Rows[0][0].ToString();
            textBox7.Text = FindInfoDT.Rows[0][1].ToString();
            textBox8.Text = FindInfoDT.Rows[0][2].ToString();
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
                tourTicketTableAdapter.InsertQuery(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.SelectedItem.ToString(), textBox4.Text, textBox5.Text,comboBox2.SelectedValue.ToString());
                this.tourTicketTableAdapter.Fill(this.airLaneDataSet.TourTicket);
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
                tourTicketTableAdapter.DeleteQuery(Convert.ToInt32(tourtikcetDataGridView.SelectedRows[0].Cells[0].Value.ToString()));
                this.tourTicketTableAdapter.Fill(this.airLaneDataSet.TourTicket);
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
            if (tourtikcetDataGridView.SelectedRows.Count != 0)
            {
                tourTicketTableAdapter.FillByRptTourTicket(airLaneDataSet.TourTicket,Convert.ToInt16(tourtikcetDataGridView.SelectedRows[0].Cells[0].Value.ToString()));
                AirLine.TicketReport.CrystalReportTourTicket rpttour = new AirLine.TicketReport.CrystalReportTourTicket();
                rpttour.SetDataSource(airLaneDataSet);
                TicketReport.TourTicketReport frpttour = new TicketReport.TourTicketReport();
                frpttour.Owner = this;
                frpttour.crystalReportViewer1.ReportSource = rpttour;
                frpttour.Show();
            }
            else
            {
                MessageBox.Show("بلیطی از جدول زیر انتخاب نشده است", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
