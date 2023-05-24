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
        public void Form1_Load()
        {
            MainTable.Columns.Add("Музыкальный жанр",typeof(string));
            MainTable.Columns.Add("Размер раздела-жанра,в мб",typeof(int));
            VspTable.Columns.Add("Музыкальный трек", typeof(string));
            VspTable.Columns.Add("Размер трека,в мб", typeof(int));
            dataGridViewGenre.DataSource = MainTable;
            timer1.Enabled= true;
        }
        // MusicCollection Collection=new MusicCollection();
        GenreList genreList = new GenreList();

        DataTable MainTable=new DataTable();
        DataTable VspTable=new DataTable();
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char symbol = e.KeyChar;
            if ((symbol < 'А' || symbol > 'я') && symbol != '\b' && (symbol < 'A' || symbol > 'z'))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char symbol = e.KeyChar;
            if ((symbol < 'А' || symbol > 'я') && symbol != '\b' && (symbol < 'A' || symbol > 'z'))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number=e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled=true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (button3.Text)
            {
                case "Информация о жанре":
                    {
                        if (label8.Text == "Коллекция музыкальных жанров")
                        {
                            label7.Visible = true;
                            textBox4.Visible = true;
                            label5.Visible = false;
                            label6.Visible = false;
                            textBox5.Visible = false;
                            textBox6.Visible = false;
                            panel3.Visible = true;
                        }
                        else 
                        {
                            label7.Visible = false;
                            textBox4.Visible = false;
                            label5.Visible = true;
                            label6.Visible = true;
                            textBox5.Visible = true;
                            textBox6.Visible = true;
                            panel3.Visible = true;
                        }
                       button3.Text = "Назад";
                        break;
                    }
                case "Назад":
                    {
                        panel3.Visible = false;
                        button3.Text = "Информация о жанре";
                        break;
                    }

            }
        }

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
            Console.WriteLine(nameTrack + " " + nameGenre + " " + maxSize + " " + sizeTrack);
            if (nameTrack != "" && nameGenre != "" && maxSize != 0 && sizeTrack != 0)
            {
                bool genreExists = false;
                int rowIndex = -1;

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
                }
                else
                {
                    genreList.AddGenre(new Genre(nameGenre, maxSize));
                    genreList.AddTrack(nameGenre, new Track(nameTrack, sizeTrack));
                    dataGridViewGenre.Rows.Add(nameGenre, genreList.GetTrackCount(nameGenre), maxSize); // Добавляем новую строку
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

                    Console.WriteLine("КОЛ-ВО ТРЕКОВ 1: " + tracks.Length);
                    dataGridViewTrack.Rows.Clear();

                    if (tracks != null)
                    {
                        Console.WriteLine("КОЛ-ВО ТРЕКОВ 2: " + tracks.Length);
                        foreach (Track track in tracks)
                        {
                            // Console.WriteLine("|| name track = " + track.GetTrack() + "|| size = " + track.GetFileSize());
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
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt"; // Фильтр для выбора только текстовых файлов
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
                MessageBox.Show("Информация успешно сохранена");
            }
        }

        private void toolStripButtonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt"; // Фильтр для выбора только текстовых файлов

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Очищаем перед загрузкой новых данных
                dataGridViewGenre.Rows.Clear();
                dataGridViewTrack.Rows.Clear();

                genreList.RemoveAllGenres();
                genreList.RemoveAllTracks();

                Dictionary<string, bool> houseEntries = new Dictionary<string, bool>();

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] columns = line.Split('\t');
                        string houseKey = columns[0] + columns[1] + columns[2];

                        if (!houseEntries.ContainsKey(houseKey))
                        {
                            genreList.AddGenre(new Genre(columns[0], Convert.ToInt32(columns[2])));
                            dataGridViewGenre.Rows.Add(columns[0], columns[1], columns[2]);
                            houseEntries.Add(houseKey, true);
                        }

                        if (columns[3] != "0" && columns[4] != "0")
                        {
                            genreList.AddTrack(columns[0], new Track(columns[3], Convert.ToInt32(columns[4])));
                        }
                    }
                }
                MessageBox.Show("Информация успешно загружена\nДля вывода квартир нажмите на ячейку дома");
            }
        }
    }
}
