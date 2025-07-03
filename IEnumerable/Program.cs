﻿using TelephoneDirectory;

PhoneNumber[] db = 
{
    new PhoneNumber(new Person("Bob", "Marley", Gender.Male), "112365"),
    new PhoneNumber(new Person("Ann", "Brown", Gender.Female), "122435"),
    new PhoneNumber(new Person("John", "White", Gender.Male), "434223")
};

Console.WriteLine("sorted by number!");
Console.WriteLine();
PhoneBook bookByNumber = new PhoneBook(db, "number");
foreach (var person in bookByNumber)
{
    person.Output();
}

Console.WriteLine();

Console.WriteLine("sorted by name!");
Console.WriteLine();
PhoneBook bookByName = new PhoneBook(db, "name");
foreach (var person in bookByName)
{
    person.Output();
}