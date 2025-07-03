namespace TelephoneDirectory;

public enum Gender
{
    Male,
    Female
}

public class Person
{
    public string name;
    public string surname;
    public Gender gender;

    public Person(string name, string surname, Gender gender)
    {
        this.name = name;
        this.surname = surname;
        this.gender = gender;
    }

    public string MrOrMs()
    {
        if (gender == Gender.Male)
        {
            return "Mr.";
        }
        else
        {
            return "Ms.";
        }
    }
}