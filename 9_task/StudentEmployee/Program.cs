using StudentEmployee;

IPersonContainer container = new PersonArrayContainer();

container.Add(new Student("Первый") { Tuition = 50000 });
container.Add(new Employee("Второй") { Salary = 20000 });
container.Add(new Student_Employee("Третий") { Tuition = 50000, Salary = 25000 });

foreach (var person in container.GetAll())
{
    Console.Write(person.LastName + " ");
    if (person is Student)
        Console.Write("Tuition: " + ((Student)person).Tuition + " ");
    if (person is Employee)
        Console.Write("Salary: " + ((Employee)person).Salary + " ");
    if (person is Student_Employee)
        Console.Write("Total Payment: " + ((Student_Employee)person).TotalPayment + " ");
    Console.WriteLine();
}

/*
    var student1 = new Student("Ivanov");
    student1.Tuition = 1000;

    var student2 = new Student("Petrov");
    student2.Tuition = 1500;

    var employee1 = new Employee("Sidorov");
    employee1.Salary = 2000;

    var employee2 = new Employee("Kozlov");
    employee2.Salary = 2500;

    var studentEmployee1 = new Student_Employee("Vasiliev");
    studentEmployee1.Tuition = 800;
    studentEmployee1.Salary = 1800;

    var studentEmployee2 = new Student_Employee("Goncharov");
    studentEmployee2.Tuition = 1200;
    studentEmployee2.Salary = 2200;

    // Создаем контейнер и добавляем объекты
    var container = new PersonArrayContainer();
    container.Add(student1);
    container.Add(student2);
    container.Add(employee1);
    container.Add(employee2);
    container.Add(studentEmployee1);
    container.Add(studentEmployee2);

    // Выводим информацию о всех объектах в контейнере
    var allPersons = container.GetAll();
    foreach (var person in allPersons)
    {
        Console.WriteLine($"Last Name: {person.LastName}");
        if (person is Student student)
        {
            Console.WriteLine($"Tuition: {student.Tuition}");
        }
        else if (person is Employee employee)
        {
            Console.WriteLine($"Salary: {employee.Salary}");
        }
        else if (person is Student_Employee studentEmployee)
        {
            Console.WriteLine($"Tuition: {studentEmployee.Tuition}, Salary: {studentEmployee.Salary}, Total Payment: {studentEmployee.TotalPayment}");
        }
        Console.WriteLine();
    }

*/