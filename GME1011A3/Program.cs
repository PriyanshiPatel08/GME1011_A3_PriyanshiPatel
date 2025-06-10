using System;
using System.Collections.Generic;

namespace GME1011A3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();

            // 1. Get hero details from user
            Console.Write("Enter your hero's name: ");
            string heroName = Console.ReadLine();

            Console.Write("Enter your hero's health (max 150): ");
            int heroHealth = int.Parse(Console.ReadLine());
            if (heroHealth <= 0 || heroHealth > 150) heroHealth = 100;

            Console.Write("Enter your hero's strength (1–10): ");
            int heroStrength = int.Parse(Console.ReadLine());
            if (heroStrength < 1 || heroStrength > 10) heroStrength = 5;

            Fighter hero = new Fighter(heroHealth, heroName, heroStrength);
            Console.WriteLine("\nHere is our heroic hero: " + hero + "\n\n");

            // 2. Get number of enemies
            Console.Write("Enter number of enemies to fight (1–10): ");
            int numBaddies = int.Parse(Console.ReadLine());
            if (numBaddies <= 0 || numBaddies > 10) numBaddies = 5;

            int numAliveBaddies = numBaddies;
            List<Minion> baddies = new List<Minion>();

            // 3. Create random mix of baddies
            for (int i = 0; i < numBaddies; i++)
            {
                int type = rng.Next(4); // 0=Goblin, 1=Skellie, 2=Sneaky, 3=Archer

                switch (type)
                {
                    case 0:
                        baddies.Add(new Goblin(rng.Next(25, 36), rng.Next(1, 6), rng.Next(3, 11)));
                        break;
                    case 1:
                        baddies.Add(new Skellie(rng.Next(25, 31), 0));
                        break;
                    case 2:
                        baddies.Add(new SneakyMinion(rng.Next(20, 31), rng.Next(0, 3), rng.Next(5, 11)));
                        break;
                    case 3:
                        baddies.Add(new Archer(rng.Next(22, 33), rng.Next(1, 4), rng.Next(1, 4)));
                        break;
                }
            }

            Console.WriteLine("\nHere are the baddies!!!");
            for (int i = 0; i < baddies.Count; i++)
            {
                Console.WriteLine($"#{i + 1}: " + baddies[i]);
            }
            Console.WriteLine("\nLet the EPIC battle begin!");
            Console.WriteLine("----------------------------");

            while (numAliveBaddies > 0 && !hero.isDead())
            {
                int indexOfEnemy = 0;
                while (baddies[indexOfEnemy].isDead())
                    indexOfEnemy++;

                Minion currentEnemy = baddies[indexOfEnemy];
                Console.WriteLine($"\n{hero.GetName()} attacks enemy #{indexOfEnemy + 1} ({currentEnemy.GetType().Name})");

                // Hero attacks
                int heroDamage;
                if (rng.Next(100) < 33 && hero.CanUseSpecial())
                {
                    heroDamage = hero.SpecialAttack();
                }
                else
                {
                    if (!hero.CanUseSpecial())
                        Console.WriteLine("(Not enough power for special. Using regular attack.)");
                    heroDamage = hero.DealDamage();
                }

                Console.WriteLine($"{hero.GetName()} deals {heroDamage} damage!");
                currentEnemy.TakeDamage(heroDamage);

                if (currentEnemy.isDead())
                {
                    numAliveBaddies--;
                    Console.WriteLine($"Enemy #{indexOfEnemy + 1} has been defeated!");
                }
                else
                {
                    // Enemy attacks back
                    int baddieDamage;
                    if (rng.Next(100) < 33)
                    {
                        // Use special attack if available
                        if (currentEnemy is Goblin g)
                            baddieDamage = g.GoblinBite();
                        else if (currentEnemy is Skellie s)
                            baddieDamage = s.SkellieRattle();
                        else if (currentEnemy is SneakyMinion sm)
                            baddieDamage = sm.SneakyStab();
                        else if (currentEnemy is Archer a)
                            baddieDamage = a.ArrowShot();
                        else
                            baddieDamage = currentEnemy.DealDamage();
                    }
                    else
                    {
                        baddieDamage = currentEnemy.DealDamage();
                    }

                    Console.WriteLine($"Enemy #{indexOfEnemy + 1} deals {baddieDamage} damage!");
                    hero.TakeDamage(baddieDamage);
                    Console.WriteLine($"{hero.GetName()} has {hero.GetHealth()} HP remaining.");

                    if (hero.isDead())
                    {
                        Console.WriteLine($"\n{hero.GetName()} has fallen. The world is doomed.");
                    }
                }

                Console.WriteLine("-----------------------------------------");
            }

            if (!hero.isDead())
                Console.WriteLine($"\nAll enemies have been defeated!! {hero.GetName()} is victorious!");
        }
    }
}
