using ConsoleApp1;
using System.Net.NetworkInformation;
using System.Timers;

class Program
{
    static void menu()
    {
        Console.WriteLine("1. Добавить кредитоплательщика");
        Console.WriteLine("2. Удалить кредитоплательщика");
        Console.WriteLine("3. Вывод всей информации о кредитоплательщиках");
        Console.WriteLine("4. Вывод информации по конкретному кредитоплательщику");
        Console.WriteLine("5. Корректировка информации");
        Console.WriteLine("6. Сумма всех выплат и всех кредитов");
    }
    static void draw()
    {
        Console.WriteLine("===========================================");
    }

    static void addPerson(PersonsCredits sd)
    {
        Console.Write("Введите фамилию: ");
        string surname = Console.ReadLine();

        Console.Write("Введите сумму кредита: ");
        int paySum = Convert.ToInt32(Console.ReadLine());

        Console.Write("Сколько выплат ввести?: ");
        int paymentsLeft = 1;
        while (paymentsLeft == 1)
        {
            paymentsLeft = Convert.ToInt32(Console.ReadLine());
            if (paymentsLeft < 1 || paymentsLeft > 10)
            {
                paymentsLeft = 1;
                Console.Write("Введено некорректное число\nВведите число от 1 до 10: ");
            }
        }

        Console.Write("\nВведите " + paymentsLeft.ToString() + " выплат: ");
        double[] pays = new double[paymentsLeft];
        double sum = 0;
        for (int i = 0; i < paymentsLeft; i++)
        {
            pays[i] = Convert.ToDouble(Console.ReadLine());
            sum += pays[i];
        }

        sd.AddPerson(surname, paySum, pays, sum);
    }

    static void remove(PersonsCredits sd)
    {
        Console.Write("Введите номер кредитоплательщика, которого нужно удалить: ");
        int id = Convert.ToInt32(Console.ReadLine());
        if (id > sd.GetCountPerson() || id < 0)
        {
            Console.WriteLine("Некорректное число");
        } else
        {
            --id;
            string name = sd.GetPersonSurname(id);
            sd.RemovePerson(id);
            string t = "Кредитоплательщик " + name + " успешно удален";
            Console.WriteLine(t);
        }
    }

    static void rename(PersonsCredits sd)
    {
        Console.Write("Введите номер кредитоплательщика, которого нужно отредактировать: ");
        int id = Convert.ToInt32(Console.ReadLine());
        if (id > sd.GetCountPerson() || id < 0)
        {
            Console.WriteLine("Некорректное число");
        }
        else
        {
            --id;
            string nameOld = sd.GetPersonSurname(id);
            Console.WriteLine("это кредитоплательщик " + nameOld + ". Всё верно? \n1. Да\n2. Нет");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num == 1)
            {
                sd.RemovePerson(id);
                Console.WriteLine("Введите новые данные: ");
                Console.Write("Введите фамилию: ");
                string surname = Console.ReadLine();

                Console.Write("Введите сумму кредита: ");
                int paySum = Convert.ToInt32(Console.ReadLine());

                Console.Write("Сколько выплат ввести?: ");
                int paymentsLeft = 1;
                while (paymentsLeft == 1)
                {
                    paymentsLeft = Convert.ToInt32(Console.ReadLine());
                    if (paymentsLeft < 1 || paymentsLeft > 10)
                    {
                        paymentsLeft = 1;
                        Console.Write("Введено некорректное число\nВведите число от 1 до 10: ");
                    }
                }

                Console.Write("\nВведите " + paymentsLeft.ToString() + " выплат: ");
                double[] pays = new double[paymentsLeft];
                double sum = 0;
                for (int i = 0; i < paymentsLeft; i++)
                {
                    pays[i] = Convert.ToDouble(Console.ReadLine());
                    sum += pays[i];
                }

                sd.AddAtPerson(id, surname, paySum, pays, sum);

                string nameNew = sd.GetPersonSurname(id);
                string t = "\nRредитоплательщик " + nameOld + " успешно изменен на " + nameNew;
                Console.WriteLine(t);
            }
        }
    }

    static void showOne(PersonsCredits sd)
    {
        Console.Write("Введите номер кредитоплательщика, о котором нужно вывести информацию: ");
        int id = Convert.ToInt32(Console.ReadLine());
        if (id > sd.GetCountPerson() || id < 0)
        {
            Console.WriteLine("Некорректное число");
        }
        else
        {
            --id;
            sd.ShowOnePerson(id);
        }

    }

    static void Main(string[] args)
    {
        int countStudents;
        var personCredit = new PersonsCredits();

        bool fl = true, fl2 = true;
        while (fl)
        {
            Console.Write("Информацию о скольки кредитоплательщиках ввести? ");
            countStudents = Convert.ToInt32(Console.ReadLine());
            if (countStudents > 0)
            {
                fl = false;
                for (int i = 0; i < countStudents; i++)
                {
                    addPerson(personCredit);
                }
                while (fl2)
                {
                    menu();
                    int num = Convert.ToInt32(Console.ReadLine());
                    switch (num)
                    {
                        case 1:
                            draw();
                            addPerson(personCredit);
                            draw();
                            break;
                        case 2:
                            draw();
                            remove(personCredit);
                            draw();
                            break;
                        case 3:
                            draw();
                            personCredit.ShowAllPerson();
                            draw();
                            break;
                        case 4:
                            draw();
                            showOne(personCredit);
                            draw();
                            break;
                        case 5:
                            draw();
                            rename(personCredit);
                            draw();
                            break;
                        case 6:
                            draw();
                            personCredit.ShowFullInfo();
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