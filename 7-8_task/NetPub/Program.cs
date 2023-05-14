// See https://aka.ms/new-console-template for more information
using NetPub;
using System;

bool fl = true;
// var manager = new PublicationBase();
Console.WriteLine("\nВведите максимальный размер списка публикаций:");
int num1;
num1 = Console.ReadKey().KeyChar - '0';
int tmpSize = 0;
PublicationList manager = new PublicationList(num1);
while (fl)
{
    menu();
    int num;
    num = Console.ReadKey().KeyChar - '0';
    switch (num)
    {
        case 1:
            draw();
            AddArticle();
            break;
        case 2:
            draw();
            AddNews();
            break;
        case 3:
            draw();
            Console.WriteLine("\nВывод статей:");
            manager.PrintPublicationsByType<Article>();
            draw();
            break;
        case 4:
            draw();
            Console.WriteLine("\nВывод новостей:");
            manager.PrintPublicationsByType<News>();
            draw();
            break;
        case 5:
            draw();
            Console.WriteLine("\nВывод всех публикаций:");
            manager.PrintAllPublications();
            draw();
            break;
        case 6:
            draw();
            RemoveArticle();
            draw();
            break;
        case 7:
            draw();
            RemoveNews();
            draw();
            break;
        case 8:
            draw();
            Console.WriteLine("\nВведите на сколько хотите увеличить размер списка публикаций:");
            int num2;
            num2 = Console.ReadKey().KeyChar - '0';
            manager.ResizePublicationsArray(num2);
            num1 += num2;
            draw();
            break;
        default:
            fl = false;
            break;
    }
}

void AddNews()
{

    Console.WriteLine("\nСколько новостей внести?");
    if (tmpSize < num1)
    {
        int n = Console.ReadKey().KeyChar - '0';
        if (num1-tmpSize < n)
        {
            Console.WriteLine("\nБудет внесено только максимум возможных новостей"); 
        }
        for (int i = 1; i <= n; i++)
        {
            Console.Write($"\nВведите заголовок новости {i}: ");
            var title = Console.ReadLine();
            Console.Write($"\nВведите источник новости {i}: ");
            var source = Console.ReadLine();
            var publication = new News(title, source);
            manager.AddPublication(publication);
            tmpSize++;
        }
    }
    else
    {
        Console.WriteLine("\nМассив переполнен");
    }

}


void AddArticle()
{
    if (tmpSize < num1)
    {
        Console.WriteLine("\nСколько статей внести?");
        int n = Console.ReadKey().KeyChar - '0';
        if (num1-tmpSize < n)
        {
            Console.WriteLine("\nБудет внесено только максимум возможных новостей");
        }
        for (int i = 1; i <= n; i++)
        {
            Console.Write($"\nВведите заголовок статьи {i}: ");
            var title = Console.ReadLine();
            Console.Write($"\nВведите автора статьи {i}: ");
            var author = Console.ReadLine();
            var publication = new Article(title, author);
            manager.AddPublication(publication);
            tmpSize++;
        }
        
    }
    else
    {
        Console.WriteLine("\nМассив переполнен");
    }
}


void RemoveArticle()
{
    if (tmpSize != 0)
    {
        Console.Write("\nВведите заголовок статьи, которую хотите удалить: ");
        var title = Console.ReadLine();
        manager.RemoveArticle(title);
        tmpSize--;
    }
    else
    {
        Console.WriteLine("\nНечего удалять");
    }

}

void RemoveNews()
{
    if (tmpSize != 0)
    {
        Console.Write("\nВведите заголовок новости, которую хотите удалить: ");
        var title = Console.ReadLine();
        manager.RemoveNews(title);
        tmpSize--;
    } 
    else
    {
        Console.WriteLine("\nНечего удалять");
    }
}

void menu()
{
    Console.Write("\n1. Внести данные о статье\n");
    Console.Write("2. Внести данные о новости\n");
    Console.Write("3. Вывести все статьи\n");
    Console.Write("4. Вывести все новости\n");
    Console.Write("5. Вывести все данные\n");
    Console.Write("6. Удалить статью\n");
    Console.Write("7. Удалить новость\n");
    Console.Write("8. Увеличить размер массива публикаций\n");

}


void draw()
{
    Console.WriteLine("\n========================================================");
}