using System;

namespace GME1011A3
{
    internal class Fighter : Hero
    {
        private int strength;
        private int specialPoints = 3;

        public Fighter() : base() => strength = 5;

        public Fighter(int health, string name, int strength) : base(health, name)
        {
            if (strength < 0 || strength > 10) strength = 5;
            this.strength = strength;
        }

        public override int DealDamage()
        {
            return new Random().Next(8, 15);
        }

        public bool CanUseSpecial()
        {
            return specialPoints > 0;
        }

        public int SpecialAttack()
        {
            if (!CanUseSpecial()) return DealDamage();
            specialPoints--;
            Console.WriteLine("*BERSERK!*");
            return strength * new Random().Next(5, 10);
        }

        public override string ToString()
        {
            return $"Fighter[{health}, {GetName()}, str: {strength}]";
        }
    }
}