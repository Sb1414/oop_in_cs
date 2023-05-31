using System.Text.RegularExpressions;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Library currentLibrary; // ���������� ��� �������� ������� ��������� ����������
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
                    DialogResult result = MessageBox.Show("������������� ������� ����� ����������? ���������� ����� �������", "", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                if (currentLibrary != null) 
                    currentLibrary.Clear();
                dataGridView1.Rows.Clear();
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "��������� ����� (*.txt)|*.txt";
                openFileDialog.Title = "������� ����������";
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

                    labelNameLib.Text = "�������� ����������: " + currentLibrary.Name;
                    labelCountBooks.Text = "���������� ����: " + currentLibrary.Count();
                    MessageBox.Show("���������� ������� ��������� �� �����", "��������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "������!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void saveToolStrip_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentLibrary == null)
                {
                    throw new Exception("���������� �� �������");
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "��������� ����� (*.txt)|*.txt";
                saveFileDialog.Title = "��������� ����������";
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

                    MessageBox.Show("���������� ������� ���������", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "������!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }


        private void buttonAddLib_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxLibName.Text == "")
                {
                    throw new Exception("������ �� �������");
                }

                string libraryName = textBoxLibName.Text.Trim();
                // �������� ������� ������ ���� � ��������� ����� ����������
                if (!Regex.IsMatch(libraryName, @"^[a-zA-Z�-��-�\s]+$"))
                {
                    throw new Exception("� �������� ���������� ������ ���� ������ �����");
                }
                if (labelNameLib.Text != "�������� ����������: ")
                {
                    DialogResult result = MessageBox.Show("������������� ������� ����� ����������? ���������� ����� �������", "", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                dataGridView1.Rows.Clear();

                currentLibrary = new Library(libraryName); // ������ ����������

                labelNameLib.Text = "�������� ����������: " + textBoxLibName.Text;
                labelCountBooks.Text = "���������� ����: " + currentLibrary.Count();
                textBoxLibName.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "������!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxBookName.Text == "" || textBoxBookYear.Text == "" || textBoxBookPublishing.Text == "" || textBoxAutor.Text == "")
                {
                    throw new Exception("��������� ��� ����");
                }

                if (currentLibrary == null)
                {
                    throw new Exception("������� ������� �������� ����������");
                }

                string bookName = textBoxBookName.Text.Trim();
                string authorName = textBoxAutor.Text.Trim();
                string publishing = textBoxBookPublishing.Text.Trim();
                string year = textBoxBookYear.Text.Trim();
                // �������� ������� ������ ���� � �������� �����, ����� ������ � �������
                if (!Regex.IsMatch(bookName, @"^[a-zA-Z�-��-�\s]+$"))
                {
                    throw new Exception("�������� ����� ������ �������� �� ����");
                }

                if (!Regex.IsMatch(authorName, @"^[a-zA-Z�-��-�\s]+$"))
                {
                    throw new Exception("��� ������ ������ �������� �� ����");
                }

                if (!Regex.IsMatch(publishing, @"^[a-zA-Z�-��-�\s]+$"))
                {
                    throw new Exception("������� ������ �������� ������ �� ����");
                }

                // ��������, ��� ���� ���� �������� ����� 4 �����
                if (!Regex.IsMatch(year, @"^\d{4}$"))
                {
                    throw new Exception("���� '��� �������' ������ ��������� ����� 4 �����");
                }

                // �������� ������� �����
                Book book = new Book(bookName, authorName, publishing, Convert.ToInt32(year));

                if (!currentLibrary.IsBookExists(bookName))
                {
                    // ���������� ����� � ����������
                    currentLibrary.Enqueue(book);
                    dataGridView1.Rows.Add(book.Title, book.Year, book.Publisher, book.Author);
                } else
                {
                    throw new Exception("����� ����� ��� ����������");
                }

                labelCountBooks.Text = "���������� ����: " + currentLibrary.Count();
                textBoxBookName.Text = "";
                textBoxBookYear.Text = "";
                textBoxBookPublishing.Text = "";
                textBoxAutor.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "������!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void deleteToolStrip_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentLibrary == null)
                {
                    throw new Exception("���������� �� �������");
                }

                if (currentLibrary.IsEmpty())
                {
                    throw new Exception("���������� �����. ��� ���� ��� ��������.");
                }

                Book removedBook = currentLibrary.Dequeue();

                // ���������� ������� � ����� � ����������� ����
                dataGridView1.Rows.Clear();
                for (int i = 0; i < currentLibrary.Count(); i++)
                {
                    Book book = currentLibrary.GetBook(i);
                    dataGridView1.Rows.Add(book.Title, book.Year, book.Publisher, book.Author);
                }
                labelCountBooks.Text = "���������� ����: " + currentLibrary.Count();

                MessageBox.Show("����� ������� �������: " + removedBook.Title, "�������� �����", MessageBoxButtons.OK, MessageBoxIcon.Information);      
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "������!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}