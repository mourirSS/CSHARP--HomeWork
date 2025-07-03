namespace TelephoneDirectory;

public class PhoneNumber
{
    public Person person;
    public string number;

    public PhoneNumber(Person person, string number)
    {
        this.person = person;
        this.number = number;
    }

    public void Output()
    {
        Console.WriteLine($"{person.MrOrMs()} {person.name} {person.surname} {number}");
    }
}