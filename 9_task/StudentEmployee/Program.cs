using StudentEmployee;


bool fl = true;
// var manager = new PublicationBase();
Console.WriteLine("\nВыберите действие:");
IPersonContainer container = new PersonArrayContainer();
while (fl)
{
    menu();
    int num;
    num = Console.ReadKey().KeyChar - '0';
    switch (num)
    {
        case 1:
            draw();
            menuAdd();
            int num_add;
            num_add = Console.ReadKey().KeyChar - '0';
            switch (num_add)
            {
                case 1:
                    var tmp = AddInfo("\nВведите стоимость обучения:", false);
                    container.Add(new Student(tmp.Item1) { Tuition = tmp.Item2 });
                    break;
                case 2:
                    var tmp2 = AddInfo("\nВведите зарплату:", false);
                    container.Add(new Employee(tmp2.Item1) { Salary = tmp2.Item2 });
                    break;
                case 3:
                    var tmp3 = AddInfo("\nВведите зарплату:", true);
                    container.Add(new Student_Employee(tmp3.Item1) { Tuition = tmp3.Item2, Salary = tmp3.Item3 });
                    break;
            }
            break;
        case 2:
            draw();
            Console.WriteLine("\n Введите имя, кого нужно удалить");
            string nameToRemove = Console.ReadLine();
            Person personToRemove = container.GetAll().FirstOrDefault(p => p.LastName == nameToRemove);
            if (personToRemove != null)
            {
                container.Remove(personToRemove);
                Console.WriteLine("Объект успешно удален.");
            }
            else
            {
                Console.WriteLine("Объект с указанным именем не найден.");
            }
            break;
        case 3:
            draw();
            OutputAll();
            draw();
            break;
        default:
            fl = false;
            break;
    }
}

static (string, double, double) AddInfo(string second, bool check)
{
    string name_ = "";
    double tuit_ = 0;

    Console.WriteLine("\nВведите имя:");
    name_ = Console.ReadLine();

    if (check)
    {
        double sal_ = 0;
        Console.WriteLine("\nВведите стоимость обучения:");
        double.TryParse(Console.ReadLine(), out tuit_);

        Console.WriteLine("\nВведите зарплату:");
        double.TryParse(Console.ReadLine(), out sal_);

        return (name_, tuit_, sal_);
    } else
    {
        Console.WriteLine(second);
        double.TryParse(Console.ReadLine(), out tuit_);
    }

    return (name_, tuit_, 0);
}

void menu()
{
    Console.Write("\n1. Внести данные\n");
    Console.Write("2. Удалить данные\n");
    Console.Write("3. Вывести данные\n");
}

void menuAdd()
{
    Console.Write("\n. Какие данные внести?\n");
    Console.Write("1. о студенте\n");
    Console.Write("2. о сотруднике\n");
    Console.Write("3. о студенте-сотруднике\n");
}

void draw()
{
    Console.WriteLine("\n========================================================");
}

void OutputAll()
{
    foreach (var person in container.GetAll())
    {
       // Console.Write(person.LastName + " ");
        if (person is Student)
        {
            Console.WriteLine("Students:");
            Console.Write(person.LastName + " ");
            Console.Write("  | Tuition: " + ((Student)person).Tuition + "; ");
        }
        if (person is Employee)
        {
            Console.WriteLine("Employee:");
            Console.Write(person.LastName + " ");
            Console.Write("  | Salary: " + ((Employee)person).Salary + "; ");
        }
        if (person is Student_Employee)
        {
            Console.WriteLine("Student_Employee:");
            Console.Write(person.LastName + " ");
            Console.Write("  | Tuition: " + ((Student_Employee)person).Tuition + "| Salary: " + ((Student_Employee)person).Salary + "; ");
        }
        Console.WriteLine();
    }
}