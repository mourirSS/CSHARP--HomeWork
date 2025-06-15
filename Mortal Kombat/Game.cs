namespace MortalKombat
{
    // Класс управления игрой
    class Game
    {
        private readonly Fighter _player; //написал с нижним подчеркиванием, чтобы не писать this. по 100 раз
        private readonly Fighter _bot; //написал с нижним подчеркиванием, чтобы не писать this. по 100 раз
        private readonly Random _rng = new(); // Генератор рандома

        public Game(Fighter player, Fighter bot)
        {
            _player = player;
            _bot = bot;
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine(">>> MORTAL KOMBAT!!! <<<");
            ShowFighters(); // Показываю бойцов
            Console.WriteLine("\nPRESS ANY KEY TO FIGHT!");
            Console.ReadKey(); // Жду нажатия клавиши

            while (_player.IsAlive && _bot.IsAlive) // Пока оба бойца живы они будут делать ходы
            {
                PlayerTurn(); // Ход игрока
                if (!_bot.IsAlive) // Если компьютер умер то бой завершается
                    break;
                BotTurn(); // А если нет то следующий ход копмьютера
            }

            EndGame(); // когда мы выходим из цикла. то есть если кто то умер. то игра заканчивается
        }

        private void ShowFighters() // Метод для отображения бойцов
        {
            Console.WriteLine("You: " + _player.Name);
            _player.DrawFace();
            Console.WriteLine("\nVS\n");
            Console.WriteLine("Bot: " + _bot.Name);
            _bot.DrawFace();
        }

        private void Interface() // Метод для отрисовки интерфейса
        {
            Console.Clear();
            Console.WriteLine("=== FIGHT ===\n");
            Console.WriteLine($"{_player.Name} HP {_player.DrawHp()}  XRAY {_player.DrawXRay()}\n");
            Console.WriteLine($"{_bot.Name}   HP {_bot.DrawHp()}  XRAY {_bot.DrawXRay()}\n");
        }

        private void PlayerTurn()
        {
            Interface();
            Console.WriteLine("Your move: A - to attack  X - to X‑Ray  Q - to quit");
            char choice = char.ToUpper(Console.ReadKey(true).KeyChar); // Читаем клавишу (интересная вещь кстати. true стоит чтобы не отображать нажатую клавишу
                                                                        // а KeyChar чтобы вернуть символ нажатой клавиши)
            switch (choice)
            {
                case 'X' when _player.CanXRay:
                    DoAttack(_player, _bot, _player.PerformXRay()); // XRAY атака
                    break;
                case 'A':
                default:
                    DoAttack(_player, _bot, _player.Attack); // Обычная атака (если нажата клавиша A или любая другая то все равно сработает обычная атака.
                                                             // поставил чтобы не приходилось работать с исключениями)
                    break;
                case 'Q':
                    Environment.Exit(0); // Выход из игры
                    break;
            }
            _player.ChargeXRay(50); // Заряжаем XRAY. Выбрал 50. Довольно быстро на самом деле. что немного рушит баланс. но 25 будет очень долго
                                     // пришлось бы тогда уменьшить урон от обычных атак. но опять же это очень затянет бой
        }

        private void BotTurn()
        {
            Thread.Sleep(700); // Пауза перед ходом компьютера
            int dmg = _bot.Attack;
            DoAttack(_bot, _player, dmg);
            _bot.ChargeXRay(50);
            Thread.Sleep(700);
        }

        private static void DoAttack(Fighter attacker, Fighter defender, int dmg)
        {
            Console.WriteLine($"{attacker.Name} hits {defender.Name} for {dmg}!");
            defender.ReceiveDamage(dmg);
            Thread.Sleep(600);
        }

        private void EndGame()
        {
            Interface();
            Fighter winner;
            Fighter loser;

            if (_player.IsAlive)
            {
                winner = _player;
                loser = _bot;
            }
            else
            {
                winner = _bot;
                loser = _player;
            }

            Console.WriteLine($"\n{winner.Name} wins!");
            winner.PerformFatality(loser); // Завершающий добивающий удар
            Console.WriteLine("\nGAME OVER!!! Press any key to exit");
            Console.ReadKey();
        }
    }
}