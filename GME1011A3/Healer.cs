using System;

namespace GME1011A3
{
    internal class Healer : Hero
    {
        private int dexterity;

        public Healer() : base() => dexterity = 5;

        public Healer(int health, string name, int dexterity) : base(health, name ?? "Healer")
        {
            if (this.health > 80) this.health = 80;
            this.dexterity = (dexterity < 0 || dexterity > 10) ? 5 : dexterity;
        }

        public override int DealDamage()
        {
            return new Random().Next(3, 9);
        }

        public override void Heal(int amount)
        {
            this.health += amount;
            if (this.health > 80) this.health = 80;
        }

        public int HealPartyMember()
        {
            if (dexterity <= 0) return 0;
            dexterity--;
            Console.WriteLine("*Party Heal!*");
            return new Random().Next(20, 35);
        }

        public override string ToString()
        {
            return $"Healer[{health}, {GetName()}, dex: {dexterity}]";
        }
    }
}