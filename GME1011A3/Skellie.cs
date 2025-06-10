using System;

namespace GME1011A3
{
    internal class Skellie : Minion
    {
        // Constructor - Skellies always have 0 armour
        public Skellie(int health) : base(health, 0)
        {
            this.armour = 0;
        }

        // Skellies take half damage
        public override void TakeDamage(int damage)
        {
            int halfDamage = damage / 2;
            if (halfDamage < 0) halfDamage = 0;
            health -= halfDamage;
        }

        // Skellies do 2–8 damage
        public override int DealDamage()
        {
            Random rng = new Random();
            return rng.Next(2, 9); // upper bound is exclusive
        }

        // Special move: spooky rattling
        public int SkellieRattle()
        {
            Console.WriteLine("**Spooky rattling echoes across the battlefield...**");
            Random rng = new Random();
            return rng.Next(7, 15); // 7 to 14 inclusive
        }

        public override string ToString()
        {
