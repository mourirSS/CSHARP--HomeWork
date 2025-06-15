using MortalKombat.Fighters;

namespace MortalKombat
{
    class Program
    {
        static void Main()
        {
            Fighter player = ChooseFighter(); // Выбор игрока
            Fighter bot = RandomBot(player); // Случайный бот
            new Game(player, bot).Start(); // Запуск игры
        }

        // Выбор бойца игроком
        private static Fighter ChooseFighter()
        {
            Console.WriteLine("Choose your fighter:");
            Console.WriteLine("1. Scorpion\n2. Sub-Zero\n3. Raiden");
            while (true)
            {
                char input = Console.ReadKey(true).KeyChar;

                if (input == '1')
                {
                    return new Scorpion();
                }
                else if (input == '2')
                {
                    return new SubZero();
                }
                else if (input == '3')
                {
                    return new Raiden();
                }
            }
        }

        // Случайный выбор бота
        private static Fighter RandomBot(Fighter playerChoice)
        {
            var options = new List<Fighter>();

            if (playerChoice is not Scorpion)
            {
                options.Add(new Scorpion());
            }
            if (playerChoice is not SubZero)
            {
                options.Add(new SubZero());
            }
            if (playerChoice is not Raiden)
            {
                options.Add(new Raiden());
            }

            Random rng = new();
            return options[rng.Next(options.Count)];
        }
    }
}