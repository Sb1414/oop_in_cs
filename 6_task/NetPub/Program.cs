// See https://aka.ms/new-console-template for more information
using NetPub;
using System;

bool fl = true;
var manager = new PublicationBase();
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
        default:
            fl = false;
            break;
    }
}

void AddNews()
{

    Console.WriteLine("\nСколько новостей внести?");
    int n = Console.ReadKey().KeyChar - '0';
    for (int i = 1; i <= n; i++)
    {
        Console.Write($"\nВведите заголовок новости {i}: ");
        var title = Console.ReadLine();
        Console.Write($"\nВведите источник новости {i}: ");
        var source = Console.ReadLine();
        var publication = new News(title, source);
        manager.AddPublication(publication);
    }
}


void AddArticle()
{
    Console.WriteLine("\nСколько статей внести?");
    int n = Console.ReadKey().KeyChar - '0';
    for (int i = 1; i <= n; i++)
    {
        Console.Write($"\nВведите заголовок статьи {i}: ");
        var title = Console.ReadLine();
        Console.Write($"\nВведите автора статьи {i}: ");
        var author = Console.ReadLine();
        var publication = new Article(title, author);
        manager.AddPublication(publication);
    }
}


void RemoveArticle()
{
    Console.Write("\nВведите заголовок статьи, которую хотите удалить: ");
    var title = Console.ReadLine();
    manager.RemoveArticle(title);
}

void RemoveNews()
{
    Console.Write("\nВведите заголовок новости, которую хотите удалить: ");
    var title = Console.ReadLine();
    manager.RemoveNews(title);
}

void menu()
{
    Console.Write("1. Внести данные о статье\n");
    Console.Write("2. Внести данные о новости\n");
    Console.Write("3. Вывести все статьи\n");
    Console.Write("4. Вывести все новости\n");
    Console.Write("5. Вывести все данные\n");
    Console.Write("6. Удалить статью\n");
    Console.Write("7. Удалить новость\n");
}


void draw()
{
    Console.WriteLine("\n========================================================");
}