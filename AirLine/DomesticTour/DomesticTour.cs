using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirLine.DomesticTour
{
    public partial class DomesticTour : Form
    {
        string FoodService;
        public DomesticTour()
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
        private void DomesticTour_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'airLaneDataSet.Tour' table. You can move, or remove it, as needed.
            this.tourTableAdapter.FillDomestic(this.airLaneDataSet.Tour);
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                    FoodService = "دارد";
                else
                    FoodService = "ندارد";
                tourTableAdapter.InsertQuery(textBox1.Text, textBox2.Text, comboBox1.SelectedItem.ToString(), "داخلی", textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, FoodService, textBox10.Text, textBox11.Text);
                this.tourTableAdapter.FillDomestic(this.airLaneDataSet.Tour);
                MessageBox.Show("عملیات موفقیت آمیز انجام شد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAllText(this);
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
                if (checkBox1.Checked == true)
                    FoodService = "دارد";
                else
                    FoodService = "ندارد";
                tourTableAdapter.UpdateQuery(textBox1.Text, textBox2.Text, comboBox1.SelectedItem.ToString(), "داخلی", textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, FoodService, textBox10.Text, textBox11.Text, DomesticTourDataGridView.SelectedRows[0].Cells[0].Value.ToString());
                MessageBox.Show("عملیات موفقیت آمیز انجام شد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAllText(this);
                checkBox1.Checked = false;
                this.tourTableAdapter.FillDomestic(this.airLaneDataSet.Tour);
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
                tourTableAdapter.DeleteQuery(DomesticTourDataGridView.SelectedRows[0].Cells[0].Value.ToString());
                this.tourTableAdapter.FillDomestic(this.airLaneDataSet.Tour);
                MessageBox.Show("عملیات موفقیت آمیز انجام شد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAllText(this);
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در انجام عملیات", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = DomesticTourDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = DomesticTourDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            comboBox1.SelectedItem = DomesticTourDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = DomesticTourDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            textBox4.Text = DomesticTourDataGridView.SelectedRows[0].Cells[5].Value.ToString();
            textBox5.Text = DomesticTourDataGridView.SelectedRows[0].Cells[6].Value.ToString();
            textBox6.Text = DomesticTourDataGridView.SelectedRows[0].Cells[7].Value.ToString();
            textBox7.Text = DomesticTourDataGridView.SelectedRows[0].Cells[8].Value.ToString();
            textBox8.Text = DomesticTourDataGridView.SelectedRows[0].Cells[9].Value.ToString();
            string Food = DomesticTourDataGridView.SelectedRows[0].Cells[11].Value.ToString();
            if (Food == "دارد")
            {
                checkBox1.Checked = true;
            }
            else if (Food == "ندارد")
            {
                checkBox1.Checked = false;
            }
            textBox9.Text = DomesticTourDataGridView.SelectedRows[0].Cells[10].Value.ToString();
            textBox10.Text = DomesticTourDataGridView.SelectedRows[0].Cells[12].Value.ToString();
            textBox11.Text = DomesticTourDataGridView.SelectedRows[0].Cells[13].Value.ToString();
        }
    }
}
