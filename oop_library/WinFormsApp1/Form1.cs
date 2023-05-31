using System.Text.RegularExpressions;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Library currentLibrary; // Переменная для хранения текущей выбранной библиотеки
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentLibrary != null)
                {
                    DialogResult result = MessageBox.Show("Действительно открыть новую библиотеку? Предыдущая будет удалена", "", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                if (currentLibrary != null) 
                    currentLibrary.Clear();
                dataGridView1.Rows.Clear();
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
                openFileDialog.Title = "Открыть библиотеку";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] bookData = line.Split('\t');
                            if (bookData.Length == 5)
                            {
                                string libraryName = bookData[0];
                                string bookTitle = bookData[1];
                                int bookYear = int.Parse(bookData[2]);
                                string bookPublisher = bookData[3];
                                string bookAuthor = bookData[4];

                                if (currentLibrary == null)
                                {
                                    currentLibrary = new Library(libraryName);
                                }

                                Book book = new Book(bookTitle, bookAuthor, bookPublisher, bookYear);
                                currentLibrary.Enqueue(book);
                                dataGridView1.Rows.Add(bookTitle, bookYear, bookPublisher, bookAuthor);
                            }
                        }
                    }

                    labelNameLib.Text = "Название библиотеки: " + currentLibrary.Name;
                    labelCountBooks.Text = "Количество книг: " + currentLibrary.Count();
                    MessageBox.Show("Библиотека успешно загружена из файла", "Загрузка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void saveToolStrip_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentLibrary == null)
                {
                    throw new Exception("Библиотека не создана");
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
                saveFileDialog.Title = "Сохранить библиотеку";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        for (int i = 0; i < currentLibrary.Count(); i++)
                        {
                            Book book = currentLibrary.GetBook(i);
                            writer.WriteLine($"{currentLibrary.Name}\t{book.Title}\t{book.Year}\t{book.Publisher}\t{book.Author}");
                        }
                    }

                    MessageBox.Show("Библиотека успешно сохранена", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }


        private void buttonAddLib_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxLibName.Text == "")
                {
                    throw new Exception("Нечего не введено");
                }

                string libraryName = textBoxLibName.Text.Trim();
                // Проверка наличия только букв в введенном имени библиотеки
                if (!Regex.IsMatch(libraryName, @"^[a-zA-Zа-яА-Я\s]+$"))
                {
                    throw new Exception("В названии библиотеки должны быть только буквы");
                }
                if (labelNameLib.Text != "Название библиотеки: ")
                {
                    DialogResult result = MessageBox.Show("Действительно создать новую библиотеку? Предыдущая будет удалена", "", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                dataGridView1.Rows.Clear();

                currentLibrary = new Library(libraryName); // объект библиотеки

                labelNameLib.Text = "Название библиотеки: " + textBoxLibName.Text;
                labelCountBooks.Text = "Количество книг: " + currentLibrary.Count();
                textBoxLibName.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxBookName.Text == "" || textBoxBookYear.Text == "" || textBoxBookPublishing.Text == "" || textBoxAutor.Text == "")
                {
                    throw new Exception("Заполните все поля");
                }

                if (currentLibrary == null)
                {
                    throw new Exception("Вначале введите название библиотеки");
                }

                string bookName = textBoxBookName.Text.Trim();
                string authorName = textBoxAutor.Text.Trim();
                string publishing = textBoxBookPublishing.Text.Trim();
                string year = textBoxBookYear.Text.Trim();
                // Проверка наличия только букв в названии книги, имени автора и издании
                if (!Regex.IsMatch(bookName, @"^[a-zA-Zа-яА-Я\s]+$"))
                {
                    throw new Exception("Название книги должно состоять из букв");
                }

                if (!Regex.IsMatch(authorName, @"^[a-zA-Zа-яА-Я\s]+$"))
                {
                    throw new Exception("Имя автора должно состоять из букв");
                }

                if (!Regex.IsMatch(publishing, @"^[a-zA-Zа-яА-Я\s]+$"))
                {
                    throw new Exception("Издание должно состоять только из букв");
                }

                // Проверка, что поле года содержит ровно 4 цифры
                if (!Regex.IsMatch(year, @"^\d{4}$"))
                {
                    throw new Exception("Поле 'Год издания' должно содержать ровно 4 цифры");
                }

                // Создание объекта книги
                Book book = new Book(bookName, authorName, publishing, Convert.ToInt32(year));

                if (!currentLibrary.IsBookExists(bookName))
                {
                    // Добавление книги в библиотеку
                    currentLibrary.Enqueue(book);
                    dataGridView1.Rows.Add(book.Title, book.Year, book.Publisher, book.Author);
                } else
                {
                    throw new Exception("Такая книга уже существует");
                }

                labelCountBooks.Text = "Количество книг: " + currentLibrary.Count();
                textBoxBookName.Text = "";
                textBoxBookYear.Text = "";
                textBoxBookPublishing.Text = "";
                textBoxAutor.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void deleteToolStrip_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentLibrary == null)
                {
                    throw new Exception("Библиотека не создана");
                }

                if (currentLibrary.IsEmpty())
                {
                    throw new Exception("Библиотека пуста. Нет книг для удаления.");
                }

                Book removedBook = currentLibrary.Dequeue();

                // Обновление таблицы и метки с количеством книг
                dataGridView1.Rows.Clear();
                for (int i = 0; i < currentLibrary.Count(); i++)
                {
                    Book book = currentLibrary.GetBook(i);
                    dataGridView1.Rows.Add(book.Title, book.Year, book.Publisher, book.Author);
                }
                labelCountBooks.Text = "Количество книг: " + currentLibrary.Count();

                MessageBox.Show("Книга успешно удалена: " + removedBook.Title, "Удаление книги", MessageBoxButtons.OK, MessageBoxIcon.Information);      
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}