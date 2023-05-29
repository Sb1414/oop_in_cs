using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace InternetNewsPortal
{
    public partial class Form1 : Form
    {
        NewsSectionList newsSectionList = new NewsSectionList();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAddSection_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMaxNews.Text) || string.IsNullOrWhiteSpace(textBoxSection.Text))
            {
                MessageBox.Show("Заполните поля названия раздела и максимально возможного количества новостей");
                return;
            }

            string sectionName = textBoxSection.Text;

            // Проверка, что в поле sectionName вводятся только буквы
            if (!IsLettersOnly(sectionName))
            {
                MessageBox.Show("Название раздела должно содержать только буквы");
                return;
            }

            string maxNewsText = textBoxMaxNews.Text;

            // Проверка, что в поле maxNewsText вводятся только числа
            if (!IsDigitsOnly(maxNewsText))
            {
                MessageBox.Show("Максимальное количество новостей должно быть числом");
                return;
            }

            if (newsSectionList.SectionExists(sectionName))
            {
                MessageBox.Show($"Раздел '{sectionName}' уже существует");
                textBoxSection.Text = string.Empty;
                textBoxMaxNews.Text = string.Empty;
                return;
            }

            int capacity = Convert.ToInt32(maxNewsText);
            NewsSection newsSection = new NewsSection(sectionName, capacity);

            int rowIndex = dataGridViewSection.CurrentCell?.RowIndex ?? dataGridViewSection.Rows.Count - 1;
            if (rowIndex >= 0)
            {
                dataGridViewSection.Rows.Insert(rowIndex, sectionName, capacity, newsSectionList.GetNewsCountBySectionName(sectionName));
                newsSectionList.InsertNewsSection(rowIndex, newsSection);
            }
            else
            {
                dataGridViewSection.Rows.Add(sectionName, capacity, newsSectionList.GetNewsCountBySectionName(sectionName));
                newsSectionList.AddNewsSection(newsSection);
            }

            textBoxSection.Text = string.Empty;
            textBoxMaxNews.Text = string.Empty;
        }


        private bool IsLettersOnly(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsDigitsOnly(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        private void buttonAddNews_Click(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dataGridViewSection.CurrentRow;

            if (currentRow.Cells[0].Value != null)
            {
                if (!IsLettersOnly(textBoxNewsName.Text))
                {
                    MessageBox.Show("Название новости должно содержать только буквы");
                    return;
                }

                string name = currentRow.Cells[0].Value?.ToString();

                if (newsSectionList.SectionExists(name))
                {
                    string newsName = textBoxNewsName.Text;
                    string date = dateTimePicker1.Text;

                    // Проверка на то, что новость существует
                    bool newsExists = dataGridViewNews.Rows
                        .Cast<DataGridViewRow>()
                        .Any(row =>
                            row.Cells[0].Value?.ToString().Equals(newsName, StringComparison.OrdinalIgnoreCase) == true &&
                            row.Cells[1].Value?.ToString().Equals(date, StringComparison.OrdinalIgnoreCase) == true);

                    if (newsExists)
                    {
                        MessageBox.Show("Данная новость уже существует.");
                        return;
                    }

                    int currentNewsCount = newsSectionList.GetNewsCountBySectionName(name);
                    int maxNewsCount = Convert.ToInt32(currentRow.Cells[1].Value);

                    if (currentNewsCount >= maxNewsCount)
                    {
                        dataGridViewNews.Rows.RemoveAt(0);
                        dataGridViewNews.Rows.Add(newsName, date);
                    }
                    else
                    {
                        dataGridViewNews.Rows.Add(newsName, date);
                    }

                    newsSectionList.AddNewsToSection(name, newsName, date);
                    int newNewsCount = newsSectionList.GetNewsCountBySectionName(name);

                    currentRow.Cells[2].Value = newNewsCount;
                }
            }
            else
            {
                MessageBox.Show("Не выбран раздел, к которому нужно добавить новость");
            }
            textBoxNewsName.Text = string.Empty;
        }


        private void dataGridViewSection_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewSection.Rows[e.RowIndex];
                string name = selectedRow.Cells[0].Value?.ToString();

                if (string.IsNullOrEmpty(name))
                {
                    dataGridViewNews.Rows.Clear(); ;
                    return;
                }
                News[] news = newsSectionList.GetNewsBySectionName(name);

                if (news != null)
                {
                    UpdateNewsRows(name, news);
                }
                else
                {
                    dataGridViewNews.Rows.Clear(); ;
                }
            }
        }


        private void UpdateNewsRows(string customerName, News[] news)
        {
            if (news.Count() == 0)
            {
                dataGridViewNews.Rows.Clear(); ;
            }
            else
            {
                if (dataGridViewNews.Rows[0].Cells[0].Value != null)
                {
                    dataGridViewNews.Rows.Clear(); ;
                }

                foreach (News newss in news)
                {
                    string newsName = newss.GetTitle();
                    string date = newss.GetDate();

                    dataGridViewNews.Rows.Add(newsName, date);
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (NewsSection section in newsSectionList.GetNewsSections())
                    {
                        int newNewsCount = newsSectionList.GetNewsSectionCapacity(section.SectionName);
                        int nowNewsCount = newsSectionList.GetNewsCountBySectionName(section.SectionName);
                        string sectionLine = section.SectionName.ToString() + "\t" + newNewsCount + "\t";
                       
                        News newsItem = section.GetNextNews();
                        if (nowNewsCount == 0)
                        {
                            writer.WriteLine(sectionLine + "\t0" + "\t0");
                        }
                        while (newsItem != null)
                        {
                            string newsLine = newsItem.GetTitle().ToString()  + "\t" + newsItem.GetDate().ToString();

                            writer.Write(sectionLine, "\t");
                            writer.WriteLine(newsLine);

                            newsItem = section.GetNextNews();
                        }
                    }
                }

                MessageBox.Show("Сохранено");
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Clear existing data
                    newsSectionList.Clear();
                    dataGridViewSection.Rows.Clear();
                    dataGridViewNews.Rows.Clear();

                    string line;
                    string currentSectionName = null;
                    int currentSectionMaxCount = 0;

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('\t');

                        if (parts.Length > 0)
                        {
                            string sectionName = parts[0];

                            if (!sectionName.Equals(currentSectionName))
                            {
                                // Create a new section
                                currentSectionName = sectionName;
                                currentSectionMaxCount = Convert.ToInt32(parts[1]);
                                newsSectionList.AddNewsSection(new NewsSection(currentSectionName, currentSectionMaxCount));
                            }

                            // Add news item to the current section
                            string newsTitle = parts[2];
                            string publicationDate = parts[3];
                            if (newsTitle != "0" && publicationDate != "0")
                            {
                                newsSectionList.AddNewsToSection(currentSectionName, newsTitle, publicationDate);
                            }
                        }
                    }
                }

                // Refresh the UI or perform any necessary updates
                foreach (NewsSection newsSection in newsSectionList.GetNewsSections())
                {
                    int newsCount = newsSectionList.GetNewsCountBySectionName(newsSection.SectionName);
                    dataGridViewSection.Rows.Add(newsSection.SectionName, newsSection.GetCapacity(), newsCount);
                }

                MessageBox.Show("Загружено");
            }
        }

        private void DeleteSection_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewSection.CurrentRow != null)
                {
                    DataGridViewRow currentRow = dataGridViewSection.CurrentRow;

                    string name = currentRow.Cells[0].Value?.ToString();

                    dataGridViewNews.Rows.Clear();
                    dataGridViewSection.Rows.Remove(currentRow);
                    newsSectionList.RemoveAllNewsInSection(name);
                    newsSectionList.RemoveSection(name);
                }
                else
                {
                    throw new Exception("Наведите курсор в ячейку, которую нужно удалить!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void DeleteNews_Click(object sender, EventArgs e)
        {
            if (dataGridViewSection.CurrentRow == null)
            {
                MessageBox.Show("Выберите раздел, из которого нужно удалить новость");
                return;
            }

            if (dataGridViewSection.CurrentRow.Cells[0].Value == null)
            {
                MessageBox.Show("Новость не выбрана");
                return;
            }

            int rowIndex = dataGridViewSection.CurrentRow.Index;
            string sectionName = dataGridViewSection.Rows[rowIndex].Cells[0].Value.ToString();

            if (!newsSectionList.SectionExists(sectionName))
            {
                MessageBox.Show($"Раздел '{sectionName}' не найден");
                return;
            }

            NewsSection newsSection = newsSectionList.GetNewsSections()
                .FirstOrDefault(section => section.SectionName == sectionName);

            if (newsSection.GetNewsCount() == 0)
            {
                MessageBox.Show($"Раздел '{sectionName}' не содержит новостей");
                return;
            }

            newsSection.Remove();
            dataGridViewNews.Rows.RemoveAt(0);
            dataGridViewSection.Rows[rowIndex].Cells[2].Value = newsSection.GetNewsCount();
            
        }

        private void clearAll_Click(object sender, EventArgs e)
        {
            dataGridViewNews.Rows.Clear();
            dataGridViewSection.Rows.Clear();
            newsSectionList.Clear();
        }
    }
}
