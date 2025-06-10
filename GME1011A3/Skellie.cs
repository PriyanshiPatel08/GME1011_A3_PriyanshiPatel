using System;

namespace GME1011A3
{
    internal class Skellie : Minion
    {
        public Skellie(int health) : base(health, 0) { }

        public override void TakeDamage(int damage)
        {
            int half = damage / 2;
            if (half < 0) half = 0;
            health -= half;
        }

        public override int DealDamage()
        {
            return new Random().Next(2, 9);
        }

        public int SkellieRattle()
        {
            Console.WriteLine("*Spooky rattling...*");
            return new Random().Next(7, 15);
        }

        public override string ToString()
        {
            return $"Skellie[{health}, {armour}]";
        }
    }
}