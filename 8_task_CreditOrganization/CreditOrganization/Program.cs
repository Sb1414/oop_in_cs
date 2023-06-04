using System;
using System.ComponentModel;
using System.Xml.Linq;

namespace CreditOrganization
{
    internal class Program
    {
        static CreditContainer container;
        static int num1;
        static void AddMortgageCredit()
        {
            Console.WriteLine("\nСколько кредитов внести?");
            string input = Console.ReadLine();
            int n;
            if (int.TryParse(input, out n))
            {
                if (container.printCount() == container.GetCapacity())
                {
                    Console.WriteLine("\nМассив переполнен");
                    return;
                }
                for (int i = 1; i <= n; i++)
                {
                    Console.Write($"\nВведите ФИО {i}: ");
                    string name = Console.ReadLine();
                    Console.Write($"\nВведите сумму кредита {i}: ");
                    var sum = Console.ReadLine();
                    Console.Write($"\nВведите адрес {i}: ");
                    string address = Console.ReadLine();
                    MortgageCredit mCredit = new MortgageCredit(name, Convert.ToInt32(sum), address);
                    container.AddCredit(mCredit);
                }                
            }
            else
            {
                Console.WriteLine("Некорректный ввод!");
            }

        }

        static void AddAutoCredit()
        {
            Console.WriteLine("\nСколько кредитов внести?");
            string input = Console.ReadLine();
            int n;
            if (int.TryParse(input, out n))
            {
                if (container.printCount() == container.GetCapacity())
                {
                    Console.WriteLine("\nМассив переполнен");
                    return;
                }
                for (int i = 1; i <= n; i++)
                {
                    Console.Write($"\nВведите ФИО {i}: ");
                    string name = Console.ReadLine();
                    Console.Write($"\nВведите сумму кредита {i}: ");
                    var sum = Console.ReadLine();
                    Console.Write($"\nВведите марку машины {i}: ");
                    string brand = Console.ReadLine();
                    AutoCredit aCredit = new AutoCredit(name, Convert.ToInt32(sum), brand);
                    container.AddCredit(aCredit);
                }                
            }
            else
            {
                Console.WriteLine("Некорректный ввод!");
            }
        }

        static void RemoveMortgageCredit()
        {
            if (container.printCount() != 0)
            {
                Console.Write("\nВведите данные кредита, который нужно удалить: ");
                Console.Write($"\nВведите адрес: ");
                string address = Console.ReadLine();
                container.RemoveMortgageCredit(address);
            }
            else
            {
                Console.WriteLine("\nНечего удалять");
            }
        }

        static void RemoveAutoCredit()
        {
            if (container.printCount() != 0)
            {
                Console.Write("\nВведите данные кредита, который нужно удалить: ");
                Console.Write($"\nВведите марку машины: ");
                string brand = Console.ReadLine();
                container.RemoveAutoCredit(brand);
            }
            else
            {
                Console.WriteLine("\nНечего удалять");
            }
        }
        static void Resize()
        {
            Console.WriteLine("\nВведите на сколько хотите увеличить размер списка контейнеров:");
            int num2;
            string stNum = Console.ReadLine();
            if (int.TryParse(stNum, out num2))
            {
                container.IncreaseCapacity(num2);
                num1 += num2;
            } else
            {
                Console.WriteLine("Некорректный ввод!");
            }
        }

        static void menu()
        {
            Console.Write("\n------------------------------------\n");
            Console.Write("\n 1. Внести данные об ипотечном кредите\n");
            Console.Write(" 2. Внести данные об автокредите\n");
            Console.Write(" 3. Вывести все кредиты\n");
            Console.Write(" 4. Удалить ипотечный кредит\n");
            Console.Write(" 5. Удалить автокредит\n");
            Console.Write(" 6. Увеличить размер массива\n");
            Console.Write("\n Контейнер заполнен на " + container.printCount() + " из " + container.GetCapacity());
            Console.Write("\n------------------------------------\n");

        }
        static void Main(string[] args)
        {
            Console.WriteLine("\nВведите максимальный размер контейнера:");
            string stNum = Console.ReadLine();
            if (int.TryParse(stNum, out num1))
            {
                container = new CreditContainer(num1);
                bool fl = true;
                while (fl)
                {
                    menu();
                    string input = Console.ReadLine();
                    int num;
                    if (int.TryParse(input, out num))
                    {
                        switch (num)
                        {
                            case 1:
                                AddMortgageCredit();
                                break;
                            case 2:
                                AddAutoCredit();
                                break;
                            case 3:
                                Console.WriteLine("\nВывод кредитов:");
                                container.DisplayAllCredits();
                                break;
                            case 4:
                                RemoveMortgageCredit();
                                break;
                            case 5:
                                RemoveAutoCredit();
                                break;
                            case 6:
                                Resize();
                                break;
                            default:
                                fl = false;
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод!");
                    }

                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод!");
            }
        }
    }
}