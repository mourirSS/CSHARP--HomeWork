namespace MortalKombat.Fighters
{
    // SubZero — аналогично
    class SubZero : Fighter
    {
        private static readonly string[] art =
        {
            "  ╔═══╗ ",
            " ║█║║█║",
            " ║█║║█║",
            " ║█║║█║",
            " ╚═══╝ "
        };

        public SubZero() : base("Sub-Zero", 110, 22, 7) { }

        public override void DrawFace()
        {
            foreach (var line in art) Console.WriteLine(line);
        }

        public override void PerformFatality(Fighter loser)
        {
            Console.WriteLine($"{Name} freezes {loser.Name}! FATALITY!");
        }
    }
}