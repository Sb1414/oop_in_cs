using queue;
using System;

bool fl2 = true;
Console.WriteLine("\nНа сколько элементов создать очередь?");
int cnt = Console.ReadKey().KeyChar - '0';
MyQueue<int> intQueue = new MyQueue<int>(cnt);
MyQueue<string> stringQueue = new MyQueue<string>(cnt);
Console.WriteLine("\nВыберите тип очереди:");
MenuType();
int type;
type = Console.ReadKey().KeyChar - '0';
Console.WriteLine("type is " + type);
while (fl2)
{
    menu();
    int num;
    num = Console.ReadKey().KeyChar - '0';
    Console.WriteLine();
    switch (num)
    {
        case 1:
            draw();
            if (type == 1)
            {
                string tmp1 = Console.ReadLine();
                Console.WriteLine();
                stringQueue.Enqueue(tmp1);
            } else if (type == 2)
            {
                int tmp2 = Console.ReadKey().KeyChar - '0';
                Console.WriteLine();
                intQueue.Enqueue(tmp2);
            }
            draw();
            break;
        case 2:
            draw();
            if (type == 1)
            {
                Console.WriteLine(stringQueue.Dequeue());
            } else if (type == 2)
            {
                Console.WriteLine(intQueue.Dequeue());
            }
            draw();
            break;
        case 3:
            draw();
            if (type == 1)
            {
                stringQueue.Print();
            } else if (type == 2)
            {
                intQueue.Print();
            }
            draw();
            break;
        default:
            fl2 = false;
            break;
    }
}

void menu()
{
    Console.Write("\n Выберите действие! \n");
    Console.Write("\n1. Внести данные\n");
    Console.Write("2. Удалить данные\n");
    Console.Write("3. Вывести данные\n");
}

void MenuType()
{
    Console.Write("\n1. Строковый\n");
    Console.Write("2. Числовой\n");
}

void draw()
{
    Console.WriteLine("\n========================================================");
}