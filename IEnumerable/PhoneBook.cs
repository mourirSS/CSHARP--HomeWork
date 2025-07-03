using System.Collections;
namespace TelephoneDirectory;

public class PhoneBook : IEnumerable<PhoneNumber>
{
    public PhoneNumber[] numbers;
    private string sortByChoice;

    public PhoneBook(PhoneNumber[] numbers, string sortByChoice)
    {
        this.numbers = numbers;
        this.sortByChoice = sortByChoice;
    }

    public IEnumerator<PhoneNumber> GetEnumerator()
    {
        List<PhoneNumber> sorted = new List<PhoneNumber>(numbers);

        if (sortByChoice == "number")
        {
            sorted.Sort(CompareByNumber);
        }
        else if (sortByChoice == "name")
        {
            sorted.Sort(CompareByName);
        }

        return sorted.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private int CompareByNumber(PhoneNumber x, PhoneNumber y)
    {
        return x.number.CompareTo(y.number);
    }

    private int CompareByName(PhoneNumber x, PhoneNumber y)
    {
        return x.person.name.CompareTo(y.person.name);
    }
}