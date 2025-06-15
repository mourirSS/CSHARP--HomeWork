namespace MortalKombat.Fighters
{
    // Raiden — аналогично
    class Raiden : Fighter
    {
        private static readonly string[] art =
        {
            "   _____ ",
            "  /_____",
            "  | ° ° |",
            "  |  ∼  |",
            "   ___/ "
        };

        public Raiden() : base("Raiden", 95, 28, 4) { }

        public override void DrawFace()
        {
            foreach (var line in art) Console.WriteLine(line);
        }

        public override void PerformFatality(Fighter loser)
        {
            Console.WriteLine($"{Name} electrocutes {loser.Name}! FATALITY!");
        }
    }
}