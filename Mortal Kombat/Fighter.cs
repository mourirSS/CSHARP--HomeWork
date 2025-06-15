namespace MortalKombat
{
    // Абстрактный базовый класс для всех бойцов
    abstract class Fighter
    {
        private const int MaxMeter = 100; // Максимальное значение для XRAY и Fatality
        private int xrayCounter; // Текущий уровень XRAY

        // Публичные свойства бойца
        public string Name { get; } // Имя бойца. Эти свойства не меняются после создания. Поэтому set не нужен
        public int MaxHp { get; } // Максимальное здоровье
        public int Hp { get; private set; } // Текущее здоровье. Только ему приписал private set потому что оно постоянно меняется в процессе боя
                                          // а private чтобы не позволяеть менять значение вне класса
        public int Attack { get; } // Сила атаки
        public int Defence { get; } // Уровень защиты

        // Конструктор бойца
        protected Fighter(string name, int hp, int attack, int defence)
        {
            Name = name;
            MaxHp = hp;
            Hp = hp;
            Attack = attack;
            Defence = defence;
        }

        // Проверка жив ли боец
        public bool IsAlive
        {
            get { return Hp > 0; } 
        }

        // Можно ли использовать XRAY
        public bool CanXRay
        {
            get { return xrayCounter >= MaxMeter; }
        }

        // Можно ли использовать Fatality (когда мёртв и шкала заполнена)
         public bool CanFatality
        {
            get { return !IsAlive; }
        }

        // Получение урона
        public void ReceiveDamage(int dmg)
        {
            int trueDmg = dmg - Defence;  // Вычитываю защиту из полученного урона 

            // Если после защиты урон стал меньше нуля то обнуляю его
            if (trueDmg < 0) trueDmg = 0;

            // Отнимаю урон от текущего здоровья
            Hp -= trueDmg;

            // Если здоровье стало меньше нуля то обнуляю его
            if (Hp < 0) Hp = 0;
        }

        // Зарядка XRAY
        public void ChargeXRay(int xray)
        {
            xrayCounter += xray;
            if (xrayCounter > MaxMeter)
            {
                xrayCounter = MaxMeter; // Ставим ограничение чтобы не было больше 100
            }
        }

        // Обнуление счётчиков чтобы после использования было обнуление собственно
        public void ResetXRay() // Обнуляем XRAY
        {
            xrayCounter = 0;
        } 

        // Графику сделал gpt. Тут уже вообще без понятия как сделать.
        public string DrawHp() => DrawBar(Hp, MaxHp, 20, '█'); // Отображение HP
        public string DrawXRay() => DrawBar(xrayCounter, MaxMeter, 10, '#'); // Отображение XRAY

        // Тут отрисовка полосок HP и XRAY 
        private static string DrawBar(int value, int max, int width, char fill)
        {
            int filled = (int)Math.Round((double)value / max * width); // Сколько символов заполнить
            return "[" + new string(fill, filled) + new string(' ', width - filled) + "]"; // Генерация строки
        }

        public abstract void DrawFace(); // Пишу абстрактным для будущего полиморфизма 

        // XRAY по умолчанию
        public virtual int PerformXRay()
        {
            Console.WriteLine($"{Name} performs XRAY!!!");
            ResetXRay();
            return Attack * 2; // Удвоенный урон
        }

        // Fatality по умолчанию
        public virtual void PerformFatality(Fighter loser) // Создаю loser чтобы в будущем вставить туда имя проигравшего бойца
        {
            if (CanFatality) // Если можно сделать Fatality
            {
                Console.WriteLine($"{Name} performs FATALITY on {loser.Name}!!! 💀");
            }
        }
    }
}