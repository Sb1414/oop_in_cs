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
                    if (textBoxName.Text != "" && textBoxSurname.Text != "" && textBoxGroup.Text != "")
                    {
                        int ind = dataGridView1.CurrentRow.Index;
                        if (dataGridView1.Rows[ind].Cells[0].Value == "") 
                            dataGridView1.Rows.Insert(dataGridView1.CurrentRow.Index);
                        dataGridView1.Rows[ind].Cells[0].Value = textBoxName.Text;
                        dataGridView1.Rows[ind].Cells[1].Value = textBoxSurname.Text;
                        dataGridView1.Rows[ind].Cells[2].Value = textBoxGroup.Text;
                        string mark = "";
                        double marks = 0;
                        int i = 0;
                        if (textBoxMark1.Text != "")
                        {
                            marks += Convert.ToDouble(textBoxMark1.Text);
                            i++;
                            mark += textBoxMark1.Text + " ";
                            if (textBoxMark2.Text != "")
                            {
                                marks += Convert.ToDouble(textBoxMark2.Text);
                                i++;
                                mark += textBoxMark2.Text + " ";
                                if (textBoxMark3.Text != "")
                                {
                                    marks += Convert.ToDouble(textBoxMark3.Text);
                                    i++;
                                    mark += textBoxMark3.Text + " ";
                                    if (textBoxMark4.Text != "")
                                    {
                                        marks += Convert.ToDouble(textBoxMark4.Text);
                                        i++;
                                        mark += textBoxMark4.Text + " ";
                                        if (textBoxMark5.Text != "")
                                        {
                                            marks += Convert.ToDouble(textBoxMark5.Text);
                                            i++;
                                            mark += textBoxMark5.Text + " ";
                                            if (textBoxMark6.Text != "")
                                            {
                                                marks += Convert.ToDouble(textBoxMark6.Text);
                                                i++;
                                                mark += textBoxMark5.Text + " ";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        dataGridView1.Rows[ind].Cells[3].Value = mark;
                        double mean = marks / i;
                        dataGridView1.Rows[ind].Cells[4].Value = mean;
                    } else
                    {
                        throw new Exception("Не все обязательные поля заполены! (имя, фамилия, группа)");
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
    }
}
