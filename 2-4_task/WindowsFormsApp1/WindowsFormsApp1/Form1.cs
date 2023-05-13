using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Point lastPoint;
        private void panelUp_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panelUp_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    if (textBoxName.Text != "" && textBoxCredit.Text != "")
                    {
                        int ind = dataGridView1.CurrentRow.Index;
                        if (dataGridView1.Rows[ind].Cells[0].Value == "") 
                            dataGridView1.Rows.Insert(dataGridView1.CurrentRow.Index);
                        dataGridView1.Rows[ind].Cells[0].Value = textBoxName.Text;
                        dataGridView1.Rows[ind].Cells[1].Value = textBoxCredit.Text;
                        string mark = "";
                        double marks = 0;
                        int i = 0;
                        if (textBoxPay1.Text != "")
                        {
                            marks += Convert.ToDouble(textBoxPay1.Text);
                            i++;
                            mark += textBoxPay1.Text + " ";
                            if (textBoxPay2.Text != "")
                            {
                                marks += Convert.ToDouble(textBoxPay2.Text);
                                i++;
                                mark += textBoxPay2.Text + " ";
                                if (textBoxPay3.Text != "")
                                {
                                    marks += Convert.ToDouble(textBoxPay3.Text);
                                    i++;
                                    mark += textBoxPay3.Text + " ";
                                }
                            }
                        }
                        
                        dataGridView1.Rows[ind].Cells[2].Value = mark;
                        dataGridView1.Rows[ind].Cells[3].Value = marks;
                        dataGridView1.Rows[ind].Cells[4].Value = i;

                        if (marks >= Convert.ToDouble(textBoxCredit.Text))
                        {
                            double razn = marks - Convert.ToDouble(textBoxCredit.Text);
                            string res = "Переплата = " + razn.ToString();
                            dataGridView1.Rows[ind].Cells[5].Value = res;
                            dataGridView1.Rows[ind].Cells[5].Style.BackColor = Color.Green;
                        } else
                        {
                            double razn = Convert.ToDouble(textBoxCredit.Text) - marks;
                            string res = "Осталось = " + razn.ToString();
                            dataGridView1.Rows[ind].Cells[5].Value = res;
                        }
                    } else
                    {
                        throw new Exception("Не все обязательные поля заполены! (фамилия, сумма кредита)");
                    }
                    
                }
                else
                {
                    throw new Exception("Не указано куда нужно добавить строку!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    int ind = dataGridView1.CurrentRow.Index;
                    dataGridView1.Rows.Insert(dataGridView1.CurrentRow.Index);
                }
                else
                {
                    throw new Exception("Не указано куда нужно добавить строку!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                }
                else
                {
                    throw new Exception("Не указано какую строку нужно удалить!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void buttonAddPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    int ind = dataGridView1.CurrentRow.Index;
                    if (dataGridView1.Rows[ind].Cells[0].Value != "" && dataGridView1.Rows[ind].Cells[1].Value != "")
                    {
                        double countPay = Convert.ToDouble(dataGridView1.Rows[ind].Cells[4].Value);
                        double sumPay = Convert.ToDouble(dataGridView1.Rows[ind].Cells[3].Value);
                        string pays = dataGridView1.Rows[ind].Cells[2].Value.ToString();
                        if (textBoxPayment.Text != "")
                        {
                            countPay += 1;
                            sumPay += Convert.ToDouble(textBoxPayment.Text);
                            pays += textBoxPayment.Text.ToString() + " ";
                            dataGridView1.Rows[ind].Cells[4].Value = countPay;
                            dataGridView1.Rows[ind].Cells[3].Value = sumPay;
                            dataGridView1.Rows[ind].Cells[2].Value = pays;

                            double credit = Convert.ToDouble(dataGridView1.Rows[ind].Cells[1].Value);

                            if (sumPay >= credit)
                            {
                                double razn = sumPay - credit;
                                string res = "Переплата = " + razn.ToString();
                                dataGridView1.Rows[ind].Cells[5].Value = res;
                                dataGridView1.Rows[ind].Cells[5].Style.BackColor = Color.Green;
                            }
                            else
                            {
                                double razn = credit - sumPay;
                                string res = "Осталось = " + razn.ToString();
                                dataGridView1.Rows[ind].Cells[5].Value = res;
                            }

                        }
                        else
                        {
                            throw new Exception("Не заполено сколько нужно добавить к сумме выплат!");
                        }
                    }
                    else
                    {
                        throw new Exception("Не заполнены поля данных о заемщике, вначале нужно заполнить обязательные поля!");
                    }

                }
                else
                {
                    throw new Exception("Не указано куда нужно добавить строку!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
