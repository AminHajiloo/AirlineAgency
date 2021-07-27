using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirLine.FlightSchedule
{
    public partial class FlightSchedule : Form
    {
        public FlightSchedule()
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
            this.Close();
        }

        private void FlightSchedule_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'airLaneDataSet.FlightSchedule' table. You can move, or remove it, as needed.
            this.flightScheduleTableAdapter.Fill(this.airLaneDataSet.FlightSchedule);
            button3.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                flightScheduleTableAdapter.InsertQuery(Convert.ToInt32(textBox1.Text), textBox2.Text, comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text);
                this.flightScheduleTableAdapter.Fill(this.airLaneDataSet.FlightSchedule);
                MessageBox.Show("عملیات موفقیت آمیز انجام شد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAllText(this);
                comboBox1.SelectedIndex = -1; comboBox2.SelectedIndex = -1;
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
                flightScheduleTableAdapter.UpdateQuery(textBox2.Text, comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, int.Parse(flightScheduleDataGridView.SelectedRows[0].Cells[0].Value.ToString()));
                this.flightScheduleTableAdapter.Fill(this.airLaneDataSet.FlightSchedule);
                MessageBox.Show("عملیات موفقیت آمیز انجام شد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAllText(this);
                comboBox1.SelectedIndex = -1; comboBox2.SelectedIndex = -1;
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
                flightScheduleTableAdapter.DeleteQuery(int.Parse(flightScheduleDataGridView.SelectedRows[0].Cells[0].Value.ToString()));
                this.flightScheduleTableAdapter.Fill(this.airLaneDataSet.FlightSchedule);
                MessageBox.Show("عملیات موفقیت آمیز انجام شد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAllText(this);
                comboBox1.SelectedIndex = -1; comboBox2.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در انجام عملیات", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void flightScheduleDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button3.Enabled = true;
            textBox1.Text = flightScheduleDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = flightScheduleDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            comboBox1.SelectedItem = flightScheduleDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            comboBox2.SelectedItem = flightScheduleDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = flightScheduleDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            textBox4.Text = flightScheduleDataGridView.SelectedRows[0].Cells[5].Value.ToString();
            textBox5.Text = flightScheduleDataGridView.SelectedRows[0].Cells[6].Value.ToString();
            textBox6.Text = flightScheduleDataGridView.SelectedRows[0].Cells[7].Value.ToString();
            textBox7.Text = flightScheduleDataGridView.SelectedRows[0].Cells[8].Value.ToString();
            textBox8.Text = flightScheduleDataGridView.SelectedRows[0].Cells[9].Value.ToString();
            textBox9.Text = flightScheduleDataGridView.SelectedRows[0].Cells[10].Value.ToString();

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            flightScheduleTableAdapter.FillBySearch(airLaneDataSet.FlightSchedule, textBox10.Text);
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox10.Text == "بر اساس مقصد")
            {
                textBox10.Text = null;
                textBox10.ForeColor = Color.Black;
            }
        }
    }
}
