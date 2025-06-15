namespace MortalKombat.Fighters
{
    // Боец — Scorpion
    class Scorpion : Fighter
    {
        private static readonly string[] art = // Рисунки лица gpt сделал. Адекватные модели бойцов не нашел
        {
            "  ██╗   ",
            " █╬╬█╗  ",
            "█╬██╬█╗ ",
            "█╬██╬█║ ",
            " ╚███╔╝ ",
            "   ╚╝   "
        };

        public Scorpion() : base("Scorpion", 100, 25, 5) { } // Устанавливаем параметры бойца

        public override void DrawFace() 
        {
            foreach (var line in art) Console.WriteLine(line); // Печать портрета
        }

        public override void PerformFatality(Fighter loser) 
        {
            Console.WriteLine($"{Name} burns {loser.Name}! FATALITY!"); // Собственная фраза
        }
    }
}