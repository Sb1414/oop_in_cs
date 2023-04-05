// See https://aka.ms/new-console-template for more information
using ConsoleApp7;
using Xunit;

// запуск тестов (методов классов тестирования)
try
{
    Console.WriteLine("начался прогон тестов");
    var testManagementCompanyTests = new ManagementCompanyTests();
    testManagementCompanyTests.AddHouseTest();
    testManagementCompanyTests.DeleteHouseTest();
    testManagementCompanyTests.SearchHouseTest();
    var testHouseTests = new HouseTests();
    testHouseTests.CreateHouseTest();
    testHouseTests.AddAndDeleteApartmentTest();
    var tastApartmentTests = new ApartmentTests();
    tastApartmentTests.AddNewApartmentTest();
    tastApartmentTests.AddNewApartmentTest();
    tastApartmentTests.DeleteApartmentTest();
    Console.WriteLine("Тесты пройдены!\n");
}
catch (Exception ex)
{
    Console.WriteLine($"Ошибка при выполнении тестов: {ex.Message}");
}

ManagementCompany company = new ManagementCompany();

// Добавляем дома
Console.WriteLine("   Использован метод добавления домов, добавлены 3 дома:   ");
company.AddHouse("Улица Пушкина", 10, 10);
company.AddHouse("Улица Спартаковская", 5, 20);
company.AddHouse("Улица Габдулы Тукая", 7, 15);

company.Printinformation();
Console.WriteLine("===================\n");
// Добавляем квартиры в дома
Console.WriteLine("   Добавление информации о 3 выплатах и номерах квартир в доме по адресу Улица Пушкина 10\n");
House house1 = company.SearchHouse("Улица Пушкина", 10);
house1.SizeApart = 10;
house1.AddApart(1, 5000);
house1.AddApart(2, 6000);
house1.AddApart(3, 4000);
Console.WriteLine("\n===== Инфо о 1 доме ====\n");
house1.PrintHouseInfo();
Console.WriteLine("======================\n");

Console.WriteLine("   Добавление информации о 4 выплатах и номерах квартир в доме по адресу Улица Спартаковская 5\n");
House house2 = company.SearchHouse("Улица Спартаковская", 5);
house2.AddApart(1, 10000);
house2.AddApart(2, 8000);
house2.AddApart(3, 9000);
house2.AddApart(4, 7500);
Console.WriteLine("===== Инфо о 2 доме ====\n");
house1.PrintHouseInfo();
Console.WriteLine("======================\n");

Console.WriteLine("   Добавление информации о 3 выплатах и номерах квартир в доме по адресу Улица Габдулы Тукая 7\n");
House house3 = company.SearchHouse("Улица Габдулы Тукая", 7);
house3.AddApart(1, 7000);
house3.AddApart(2, 6500);
house3.AddApart(3, 8000);
Console.WriteLine("===== Инфо о 3 доме ====");
house1.PrintHouseInfo();
Console.WriteLine("=======================\n");

// Вывод информации о всех домах

Console.WriteLine("========= Вывод информации обо всех домах ========");
company.Printinformation();
Console.WriteLine("=================");

// Удаляем дом
Console.WriteLine("========= Удаление дома ========");
company.DelHouse();

// Вывод информации о всех домах после удаления
Console.WriteLine("========= Вывод информации обо всех домах после удаления ========");
company.Printinformation();
