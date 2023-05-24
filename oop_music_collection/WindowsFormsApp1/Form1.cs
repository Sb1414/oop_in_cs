using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string nameGenre = "";
        private int maxSize = 0;
        private string nameTrack = "";
        private int sizeTrack = 0;
        private int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        GenreList genreList = new GenreList();

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Ошибка! Введены не все данные");
            }
            else
            {
                if (count == 0)
                {
                    ProcessGenreAndTrackInput(1, "Наименование музыкального трека", true);
                }
                else if (count == 1)
                {
                    ProcessGenreAndTrackInput(2, "Размер файла-трека", false);
                }
                else if (count == 2)
                {
                    ProcessTrackSizeInput();
                }
                else if (count == 3)
                {
                    ProcessMaxSizeInput();
                }
            }
            AddGenreAndTrack();
            textBox1.Text = "";
        }

        private void ProcessGenreAndTrackInput(int cnt, string text, bool flag)
        {
            if (Regex.IsMatch(textBox1.Text, @"^[a-zA-Zа-яА-я]+$"))
            {
                if (flag)
                {
                    nameGenre = textBox1.Text;
                } else
                {
                    nameTrack = textBox1.Text;
                }
                count = cnt;
                label2.Text = text;
            }
            else
            {
                MessageBox.Show("Некорректный ввод!");
            }
        }

        private void ProcessTrackSizeInput()
        {
            if (Regex.IsMatch(textBox1.Text, @"^[0-9]+$"))
            {
                sizeTrack = Convert.ToInt32(textBox1.Text);
                if (genreList.GenreExists(nameGenre))
                {
                    maxSize = genreList.GetMaxTrackSizeByGenre(nameGenre);
                    count = 0;
                    label2.Text = "Наименование музыкального жанра";
                }
                else
                {
                    count = 3;
                    label2.Text = "Укажите максимальный размер раздела";
                }
            }
            else
            {
                MessageBox.Show("Некорректный ввод!");
            }
        }

        private void ProcessMaxSizeInput()
        {
            if (Regex.IsMatch(textBox1.Text, @"^[0-9]+$"))
            {
                count = 0;
                maxSize = Convert.ToInt32(textBox1.Text);
                label2.Text = "Наименование музыкального жанра";
            }
            else
            {
                MessageBox.Show("Некорректный ввод!");
            }
        }

        private void AddGenreAndTrack()
        {
            if (nameTrack != "" && nameGenre != "" && maxSize != 0 && sizeTrack != 0)
            {
                int check = 1;
                if (radioButton1.Checked)
                {
                    check = 0;
                } else if (radioButton2.Checked)
                {
                    check = 1;
                }
                bool genreExists = false;
                int rowIndex = -1;

                if (genreList.GetTrackCount(nameGenre) > maxSize)
                {
                    MessageBox.Show("Выход за границы максимально возможного количества треков в жанре!");
                    return;
                }

                foreach (DataGridViewRow row in dataGridViewGenre.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == nameGenre)
                    {
                        genreExists = true;
                        rowIndex = row.Index;
                        break;
                    }
                }

                if (genreExists && rowIndex != -1) // Если жанр уже существует, обновляем значения ячеек
                {
                    genreList.AddTrack(nameGenre, new Track(nameTrack, sizeTrack));
                    dataGridViewGenre.Rows[rowIndex].Cells[1].Value = genreList.GetTrackCount(nameGenre);
                    dataGridViewGenre.Rows[rowIndex].Cells[2].Value = maxSize;
                    CountTracksGenres();
                }
                else
                {
                    genreList.AddGenre(new Genre(nameGenre, maxSize));
                    genreList.AddTrack(nameGenre, new Track(nameTrack, sizeTrack));

                    int rowsIndex = dataGridViewGenre.CurrentCell.RowIndex;
                    if (rowsIndex < dataGridViewGenre.RowCount - 1)
                    {
                        dataGridViewGenre.Rows.Insert(rowsIndex + check, nameGenre, genreList.GetTrackCount(nameGenre), maxSize);
                    }
                    else
                    {
                        dataGridViewGenre.Rows.Insert(rowsIndex, nameGenre, genreList.GetTrackCount(nameGenre), maxSize);
                    }
                    CountTracksGenres();
                }
                nameGenre = "";
                maxSize = 0;
                nameTrack = "";
                sizeTrack = 0;
            }
        }

        private void dataGridViewGenre_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewCell selectedGenreName = dataGridViewGenre.Rows[e.RowIndex].Cells[0];

                if (selectedGenreName.Value != null)
                {
                    string selectedGenre = selectedGenreName.Value.ToString();
                    Track[] tracks = genreList.GetAllTracksByGenre(selectedGenre);

                    dataGridViewTrack.Rows.Clear();

                    if (tracks != null)
                    {
                        foreach (Track track in tracks)
                        {
                            dataGridViewTrack.Rows.Add(track.GetTrack(), track.GetFileSize());
                        }
                    }
                    else
                    {
                        dataGridViewTrack.Rows.Clear();
                    }
                }
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    Genre[] genres = genreList.GetGenres();
                    
                    foreach (Genre genre in genres)
                    {
                        string genreName = genre.GetName();
                        int countTrack = genre.GetCurrentTrackCount();
                        int maxCount = genre.GetMaxTrackCount();
                        Track[] tracks = genreList.GetAllTracksByGenre(genreName);

                        if (tracks.Length > 0)
                        {
                            foreach (Track track in tracks)
                            {
                                string trackName = track.GetTrack();
                                int sizeTrack = track.GetFileSize();

                                writer.WriteLine($"{genreName}\t{countTrack}\t{maxCount}\t{trackName}\t{sizeTrack}");
                            }
                        } else
                        {
                            writer.WriteLine($"{genreName}\t{countTrack}\t{maxCount}\t0\t0");
                        }
                    }
                }
                MessageBox.Show("Сохранено");
            }
        }

        private void toolStripButtonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Очищаем перед загрузкой новых данных
                dataGridViewGenre.Rows.Clear();
                dataGridViewTrack.Rows.Clear();

                genreList.RemoveAllGenres();
                genreList.RemoveAllTracks();

                Dictionary<string, bool> search = new Dictionary<string, bool>();

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] words = line.Split('\t');
                        string check = words[0] + words[1] + words[2];

                        if (!search.ContainsKey(check))
                        {
                            genreList.AddGenre(new Genre(words[0], Convert.ToInt32(words[2])));
                            dataGridViewGenre.Rows.Add(words[0], words[1], words[2]);
                            search.Add(check, true);
                        }

                        if (words[3] != "0" && words[4] != "0")
                        {
                            genreList.AddTrack(words[0], new Track(words[3], Convert.ToInt32(words[4])));
                        }
                    }
                }
                CountTracksGenres();
            }
        }

        private void buttonDelTrack_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewTrack.CurrentRow != null)
                {
                    DataGridViewRow currentRowTrack = dataGridViewTrack.CurrentRow;

                    string trackName = currentRowTrack.Cells[0].Value?.ToString();

                    genreList.RemoveTrack(trackName);
                    dataGridViewTrack.Rows.Remove(currentRowTrack);
                    CountTracksGenres();
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

        private void buttonDelGenre_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewGenre.CurrentRow != null)
                {
                    DataGridViewRow currentRowGenre = dataGridViewGenre.CurrentRow;

                    string name = currentRowGenre.Cells[0].Value?.ToString();

                    dataGridViewTrack.Rows.Clear();

                    dataGridViewGenre.Rows.Remove(currentRowGenre);
                    genreList.RemoveGenreByName(name);
                    CountTracksGenres();
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBoxSizeNew.Text != "" && textBoxTrackNew.Text != "") {
                int rowIndex = dataGridViewTrack.CurrentCell.RowIndex;
                int rowIndexGenre = dataGridViewGenre.CurrentCell.RowIndex;
                string nameGenre = dataGridViewGenre.Rows[rowIndexGenre].Cells[0].Value.ToString();

                if (Regex.IsMatch(textBoxTrackNew.Text, @"^[a-zA-Zа-яА-я]+$") && Regex.IsMatch(textBoxSizeNew.Text, @"^[0-9]+$"))
                {
                    DataGridViewRow currentRowTr = dataGridViewTrack.CurrentRow;
                    string name = currentRowTr.Cells[0].Value?.ToString();
                    genreList.RemoveTrack(name);
                    dataGridViewTrack.Rows.Remove(currentRowTr);
                    dataGridViewTrack.Rows.Insert(rowIndex + 0, textBoxTrackNew.Text, textBoxSizeNew.Text);
                    genreList.AddTrack(nameGenre, new Track(textBoxTrackNew.Text, Convert.ToInt32(textBoxSizeNew.Text)));
                }
                else
                {
                    MessageBox.Show("Некорректный ввод!");
                }
                    
            }
            CountTracksGenres();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Checked = false;
        }

        private void CountTracksGenres()
        {
            int countTracks = genreList.GetTrackCount();
            int countGenres = genreList.GetGenreCount();
            labelTracks.Text = "Всего треков: " + countTracks.ToString();
            labelGenres.Text = "Всего жанров: " + countGenres.ToString();
        }
    }
}
