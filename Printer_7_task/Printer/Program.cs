using Printer;

bool fl = true;
int tmpSize = 0;
PrinterContainer container = new PrinterContainer();
while (fl)
{
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
        default:
            fl = false;
            break;
    }
}

void AddLPrinter()
{

    Console.WriteLine("\nСколько принтеров внести?");
        int n = Console.ReadKey().KeyChar - '0';
       
    for (int i = 1; i <= n; i++)
    {
        Console.Write($"\nВведите скорость принтера {i}: ");
        var printSpeed = Console.ReadLine();
        Console.Write($"\nВведите размер картирижда {i}: ");
        var cartridgeSize = Console.ReadLine();
        LaserPrinter laserPrinter = new LaserPrinter(Convert.ToInt32(printSpeed), Convert.ToInt32(cartridgeSize));
        container.AddPrinter(laserPrinter);
    }

}


void AddJPrinter()
{
    Console.WriteLine("\nСколько принтеров внести?");

    int n = Console.ReadKey().KeyChar - '0';
        
    for (int i = 1; i <= n; i++)
    {
        Console.Write($"\nВведите скорость принтера {i}: ");
        var printSpeed = Console.ReadLine();
        Console.Write($"\nВведите количество цветов {i}: ");
        var colorCount = Console.ReadLine();
        InkjetPrinter inkjetPrinter = new InkjetPrinter(Convert.ToInt32(printSpeed), Convert.ToInt32(colorCount));
        container.AddPrinter(inkjetPrinter);
    }

}


void RemoveLaser()
{
    if (container.prCn() != 0)
    {
        Console.Write("\nВведите данные принтера, который нужно удалить: ");
        Console.Write($"\nВведите размер картриджа: ");
        var cartridgeSize = Console.ReadLine();
        container.RemovePrinterL(Convert.ToInt32(cartridgeSize));
        tmpSize--;
    }
    else
    {
        Console.WriteLine("\nНечего удалять");
    }
}

void RemoveJ()
{
    if (container.prCn() != 0)
    {
        Console.Write("\nВведите данные принтера, который нужно удалить: ");
        Console.Write($"\nВведите количество цветов: ");
        var colorCount = Console.ReadLine();
        container.RemovePrinterI(Convert.ToInt32(colorCount));
        tmpSize--;
    }
    else
    {
        Console.WriteLine("\nНечего удалять");
    }
}

void menu()
{
    Console.Write("\n1. Внести данные о лазерном принтере\n");
    Console.Write("2. Внести данные о струйном принтере\n");
    Console.Write("3. Вывести все принтеры\n");
    Console.Write("4. Удалить лазерный принтер\n");
    Console.Write("5. Удалить струйный принтер\n");

}


void draw()
{
    Console.WriteLine("\n========================================================");
}