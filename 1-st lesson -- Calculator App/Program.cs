// Приветствие.
Console.WriteLine("Welcome to calculator app!");

while (true)
{
    // Предлагаем выбор пользователю.
    Console.Write("Make choice: 1-addition, 2-subtraction, 3-multiplication, 4-division, 5-exit: ");
    string choiceInputStr = Console.ReadLine();
    int choiceInputInt = Convert.ToInt32(choiceInputStr);

    // Проверяем находится ли ввод пользователя в диапазоне. Если нет, пользователь должен ввести цифру снова.
    if (choiceInputInt < 1 || choiceInputInt > 5)
    {
        Console.Write("Wrong! The index is out of range. Please try again: ");
        choiceInputStr = Console.ReadLine();
        choiceInputInt = Convert.ToInt32(choiceInputStr);
    }

    if (choiceInputInt == 5)
    {
        Console.WriteLine("Goodbye!");
        break;
    }

    Console.Write("Enter the first number: ");
    string num1Str = Console.ReadLine();
    int num1Int = Convert.ToInt32(num1Str);

    Console.Write("Enter the second number: ");
    string num2Str = Console.ReadLine();
    int num2Int = Convert.ToInt32(num2Str);

    if (choiceInputInt == 1)
    {
        Console.WriteLine($"The result is {Addition(num1Int, num2Int)}");
    }
    else if (choiceInputInt == 2)
    {
        Console.WriteLine($"The result is {Subtraction(num1Int, num2Int)}");
    }
    else if (choiceInputInt == 3)
    {
        Console.WriteLine($"The result is {Multiplication(num1Int, num2Int)}");
    }
    else if (choiceInputInt == 4)
    {
        Console.WriteLine($"The result is {Division(num1Int, num2Int)}");
    }
}


int Addition(int a, int b)
{
    return a + b;
}

int Subtraction(int a, int b)
{
    return a - b;
}

int Multiplication(int a, int b)
{
    return a * b;
}

int Division(int a, int b)
{
    // Проверяем деление на ноль.
    if (b == 0)
    {
        System.Console.WriteLine("Error: Division by zero is not allowed.");
        return 0;
    }
        
    return a / b;
}