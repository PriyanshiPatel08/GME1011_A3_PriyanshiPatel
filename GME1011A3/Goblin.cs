using System;

namespace GME1011A3
{
    internal class Goblin : Minion
    {
        private int dexterity;

        public Goblin(int health, int armour, int dexterity) : base(health, armour)
        {
            if (dexterity < 0 || dexterity > 10)
                dexterity = 5;
            this.dexterity = dexterity;
        }

        public override void TakeDamage(int damage)
        {
            Random rng = new Random();
            if (rng.Next(1, 15) < dexterity)
            {
                Console.WriteLine("**Goblin dodges the attack! Sneaky!**");
            }
            else
            {
                int actualDamage = damage - armour;
                if (actualDamage < 0) actualDamage = 0;
                health -= actualDamage;
            }
        }

        public override int DealDamage()
        {
            Random rng = new Random();
            return rng.Next(1, dexterity + 1);  // 1 to dexterity inclusive
        }

        public int GoblinBite()
        {
            Console.WriteLine("**CHOMP! Goblin bites viciously.**");
            Random rng = new Random();
            return dexterity * rng.Next(1, 3);  // 1 or 2
        }

        public override string ToString()
        {
            return "Goblin[" + base.ToString() + ", dexterity: " + dexterity + "]";
        }
    }
}
