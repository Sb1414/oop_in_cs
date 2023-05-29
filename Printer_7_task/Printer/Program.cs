using Printer;

PrinterContainer container = new PrinterContainer(5);

LaserPrinter laserPrinter = new LaserPrinter(100, 500);
InkjetPrinter inkjetPrinter = new InkjetPrinter(50, 4);

container.AddPrinter(laserPrinter);
container.AddPrinter(inkjetPrinter);

container.PrintAll();
Console.WriteLine("-----------------------");
container.PrintDetailsAll();

Console.ReadLine();
