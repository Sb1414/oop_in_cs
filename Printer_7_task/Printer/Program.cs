using Printer;

bool fl = true;
Console.WriteLine("\nВведите максимальный размер контейнера:");
int num1;
num1 = Console.ReadKey().KeyChar - '0';
int tmpSize = 0;
PrinterContainer container = new PrinterContainer(num1);
while (fl)
{
    Console.WriteLine("Сейчас размер: " + tmpSize + " | " + num1);
    menu();
    int num;
    num = Console.ReadKey().KeyChar - '0';
    switch (num)
    {
        case 1:
            draw();
            AddLPrinter();
            break;
        case 2:
            draw();
            AddJPrinter();
            break;
        case 3:
            draw();
            Console.WriteLine("\nВывод принтеров:");
            container.PrintAll();
            container.PrintDetailsAll();
            draw();
            break;
        case 4:
            draw();
            RemoveLaser();
            draw();
            break;
        case 5:
            draw();
            RemoveJ();
            draw();
            break;
        case 6:
            draw();
            Resize();
            draw();
            break;
        default:
            fl = false;
            break;
    }
}

void AddLPrinter()
{

    Console.WriteLine("\nСколько принтеров внести?");
    if (tmpSize < num1)
    {
        int n = Console.ReadKey().KeyChar - '0';
        if (num1 - tmpSize < n)
        {
            Console.WriteLine("\nБудет внесено только максимум возможных принтеров");
        }
        for (int i = 1; i <= n; i++)
        {
            Console.Write($"\nВведите скорость принтера {i}: ");
            var printSpeed = Console.ReadLine();
            Console.Write($"\nВведите размер картирижда {i}: ");
            var cartridgeSize = Console.ReadLine();
            LaserPrinter laserPrinter = new LaserPrinter(Convert.ToInt32(printSpeed), Convert.ToInt32(cartridgeSize));
            container.AddPrinter(laserPrinter);
            if (tmpSize < num1)
                tmpSize++;
        }
    }
    else
    {
        Console.WriteLine("\nМассив переполнен");
    }

}


void AddJPrinter()
{
    Console.WriteLine("\nСколько принтеров внести?");
    if (tmpSize < num1)
    {
        int n = Console.ReadKey().KeyChar - '0';
        if (num1 - tmpSize < n)
        {
            Console.WriteLine("\nБудет внесено только максимум возможных принтеров");
        }
        for (int i = 1; i <= n; i++)
        {
            Console.Write($"\nВведите скорость принтера {i}: ");
            var printSpeed = Console.ReadLine();
            Console.Write($"\nВведите количество цветов {i}: ");
            var colorCount = Console.ReadLine();
            InkjetPrinter inkjetPrinter = new InkjetPrinter(Convert.ToInt32(printSpeed), Convert.ToInt32(colorCount));
            container.AddPrinter(inkjetPrinter);
            if (tmpSize < num1)
                tmpSize++;
        }
    }
    else
    {
        Console.WriteLine("\nМассив переполнен");
    }
}


void RemoveLaser()
{
    if (tmpSize != 0)
    {
        Console.Write("\nВведите данные принтера, который нужно удалить: ");
        Console.Write($"\nВведите скорость принтера: ");
        var printSpeed = Console.ReadLine();
        Console.Write($"\nВведите размер картриджа: ");
        var cartridgeSize = Console.ReadLine();

        LaserPrinter laserPrinter = new LaserPrinter(Convert.ToInt32(printSpeed), Convert.ToInt32(cartridgeSize));

        container.RemovePrinter(laserPrinter);
        tmpSize--;
    }
    else
    {
        Console.WriteLine("\nНечего удалять");
    }
}

void RemoveJ()
{
    if (tmpSize != 0)
    {
        Console.Write("\nВведите данные принтера, который нужно удалить: ");
        Console.Write($"\nВведите скорость принтера: ");
        var printSpeed = Console.ReadLine();
        Console.Write($"\nВведите количество цветов: ");
        var colorCount = Console.ReadLine();

        InkjetPrinter inkjetPrinter = new InkjetPrinter(Convert.ToInt32(printSpeed), Convert.ToInt32(colorCount));

        container.RemovePrinter(inkjetPrinter);
        tmpSize--;
    }
    else
    {
        Console.WriteLine("\nНечего удалять");
    }
}


void Resize()
{
    Console.WriteLine("\nВведите на сколько хотите увеличить размер списка публикаций:");
    int num2;
    num2 = Console.ReadKey().KeyChar - '0';
    container.IncreaseCapacity(num2);
    num1 += num2;
}

void menu()
{
    Console.Write("\n1. Внести данные о лазерном принтере\n");
    Console.Write("2. Внести данные о струйном принтере\n");
    Console.Write("3. Вывести все принтеры\n");
    Console.Write("4. Удалить лазерный принтер\n");
    Console.Write("5. Удалить струйный принтер\n");
    Console.Write("6. Увеличить размер массива принтеров\n");

}


void draw()
{
    Console.WriteLine("\n========================================================");
}