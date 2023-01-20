using ConsoleApp1;
using System.Net.NetworkInformation;
using System.Timers;

class Program
{
    static void menu()
    {
        Console.WriteLine("1. Добавить студента");
        Console.WriteLine("2. Удалить студента");
        Console.WriteLine("3. Вывод всей информации");
        Console.WriteLine("4. Корректировка информации");
    }
    static void draw()
    {
        Console.WriteLine("===========================================");
    }

    static void addSt(StudentGroup sd)
    {
        Console.Write("Введите имя: ");
        string name = Console.ReadLine();

        Console.Write("Введите фамилию: ");
        string surname = Console.ReadLine();

        Console.Write("Введите номер группы: ");
        string group = Console.ReadLine();

        Console.Write("Введите 5 оценок группы: ");
        int[] marks = new int[5];
        double meadl = 0;
        for (int i = 0; i < 5; i++)
        {
            marks[i] = Convert.ToInt32(Console.ReadLine());
            meadl += marks[i];
        }
        meadl = meadl / 5;
        

        sd.AddStudent(name, surname, group, marks, meadl);
    }

    static void remove(StudentGroup sd)
    {
        Console.Write("Введите номер студента, которого нужно удалить: ");
        int id = Convert.ToInt32(Console.ReadLine());
        if (id > sd.GetCountStudents() || id < 0)
        {
            Console.WriteLine("Некорректное число");
        } else
        {
            --id;
            string name = sd.GetStudentNameAndSurname(id);
            sd.RemoveStudent(id);
            string t = "Студент " + name + " успешно удален";
            Console.WriteLine(t);
        }
    }

    static void rename(StudentGroup sd)
    {
        Console.Write("Введите номер студента, которого нужно отредактировать: ");
        int id = Convert.ToInt32(Console.ReadLine());
        if (id > sd.GetCountStudents() || id < 0)
        {
            Console.WriteLine("Некорректное число");
        }
        else
        {
            --id;
            string nameOld = sd.GetStudentNameAndSurname(id);
            Console.WriteLine("это студент " + nameOld + ". Всё верно? \n1. Да\n2. Нет");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num == 1)
            {
                sd.RemoveStudent(id);
                Console.WriteLine("Введите новые данные: ");
                Console.Write("Введите имя: ");
                string name1 = Console.ReadLine();

                Console.Write("Введите фамилию: ");
                string surname1 = Console.ReadLine();

                Console.Write("Введите номер группы: ");
                string group1 = Console.ReadLine();

                Console.Write("Введите 5 оценок группы: ");
                int[] marks = new int[5];
                int meadl1 = 0;
                for (int i = 0; i < 5; i++)
                {
                    marks[i] = Convert.ToInt32(Console.ReadLine());
                    meadl1 += marks[i];
                }
                meadl1 = meadl1 / 5;

                sd.AddAtStudent(id, name1, surname1, group1, marks, meadl1);
                string nameNew = sd.GetStudentNameAndSurname(id);
                string t = "Студент " + nameOld + " успешно изменен на " + nameNew;
                Console.WriteLine(t);
            }
        }
    }

    static void Main(string[] args)
    {
        int countStudents;
        var studentGroup = new StudentGroup();

        bool fl = true, fl2 = true;
        while (fl)
        {
            Console.Write("Информацию о скольки студентах ввести? ");
            countStudents = Convert.ToInt32(Console.ReadLine());
            if (countStudents > 0)
            {
                fl = false;
                for (int i = 0; i < countStudents; i++)
                {
                    addSt(studentGroup);
                }
                while (fl2)
                {
                    menu();
                    int num = Convert.ToInt32(Console.ReadLine());
                    switch (num)
                    {
                        case 1:
                            draw();
                            addSt(studentGroup);
                            draw();
                            break;
                        case 2:
                            draw();
                            remove(studentGroup);
                            draw();
                            break;
                        case 3:
                            draw();
                            studentGroup.ShowAllStudent();
                            draw();
                            break;
                        case 4:
                            draw();
                            rename(studentGroup);
                            draw();
                            break;
                        default:
                            break;
                    }

                }
            }
        }

            
            
        
    }
}