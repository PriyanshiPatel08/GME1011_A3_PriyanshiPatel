using System;

namespace GME1011A3
{
    internal class Goblin : Minion
    {
        private int dexterity;

        public Goblin(int health, int armour, int dexterity)
            : base(health, armour)
        {
            this.dexterity = (dexterity < 0 || dexterity > 10) ? 5 : dexterity;
        }

        public override void TakeDamage(int damage)
        {
            if (new Random().Next(1, 15) < dexterity)
                Console.WriteLine("*Goblin dodges!*");
            else
            {
                int actual = damage - armour;
                if (actual < 0) actual = 0;
                health -= actual;
            }
        }

        public override int DealDamage() =>
            new Random().Next(1, dexterity + 1);

        public int GoblinBite()
        {
            Console.WriteLine("*CHOMP!*");
            return dexterity * new Random().Next(1, 3);
        }

        public override string ToString() =>
            $"Goblin[{health}, {armour}, dexterity: {dexterity}]";
    }
}