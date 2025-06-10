using System;
using System.Collections.Generic;

namespace GME1011A3
{
    internal class Program
    {
        static void Main()
        {
            var rng = new Random();

            Console.Write("Hero name: ");
            string heroName = Console.ReadLine() ?? "Hero";

            Console.Write("Health (1–150): ");
            int.TryParse(Console.ReadLine(), out int hp);
            hp = (hp < 1 || hp > 150) ? 100 : hp;

            Console.Write("Type (Fighter, Healer, Archer): ");
            string type = Console.ReadLine()?.Trim().ToLower() ?? "fighter";

            Console.Write("Stat (1–10): ");
            int.TryParse(Console.ReadLine(), out int stat);
            if (stat < 1 || stat > 10) stat = 5;

            Hero hero = type switch
            {
                "healer" => new Healer(hp, heroName, stat),
                "archer" => new Archer(hp, heroName, stat),
                _ => new Fighter(hp, heroName, stat),
            };

            Console.WriteLine($"\nYour hero: {hero}\n");

            Console.Write("Number of enemies (1–10): ");
            int.TryParse(Console.ReadLine(), out int num);
            if (num < 1 || num > 10) num = 5;

            var baddies = new List<Minion>();
            for (int i = 0; i < num; i++)
            {
                int roll = rng.Next(4);
                baddies.Add(roll switch
                {
                    0 => new Goblin(rng.Next(25, 36), rng.Next(1, 6), rng.Next(1, 11)),
                    1 => new Skellie(rng.Next(25, 31)),
                    2 => new SneakyMinion(rng.Next(20, 31), rng.Next(0, 4), rng.Next(1, 11)),
                    _ => new Archer(rng.Next(22, 33), "EnemyArcher", rng.Next(1, 11)),
                });
            }

            Console.WriteLine("\nEnemies:");
            for (int i = 0; i < baddies.Count; i++)
                Console.WriteLine($"#{i + 1}: {baddies[i]}");

            Console.WriteLine("\nBattle begins!");
            while (!hero.isDead() && baddies.Exists(m => !m.isDead()))
            {
                int idx = baddies.FindIndex(m => !m.isDead());
                var enemy = baddies[idx];

                Console.WriteLine($"\n{hero.GetName()} attacks #{idx + 1} ({enemy.GetType().Name})");

                int heroDamage;
                bool heroSpecialOk = hero is Fighter f1 && f1.CanUseSpecial() || hero is Archer a1 && a1.CanUseSpecial();
                if (rng.Next(100) < 33 && heroSpecialOk)
                    heroDamage = hero is Fighter f2 ? f2.SpecialAttack() : (hero is Archer a2 ? a2.SpecialAttack() : hero.DealDamage());
                else
                    heroDamage = hero.DealDamage();

                Console.WriteLine($"Hero deals {heroDamage} damage.");
                enemy.TakeDamage(heroDamage);

                if (enemy.isDead())
                {
                    Console.WriteLine($"Enemy #{idx + 1} defeated!");
                }
                else
                {
                    int enemyDamage = rng.Next(100) < 33 ? enemy switch
                    {
                        Goblin g => g.GoblinBite(),
                        Skellie s => s.SkellieRattle(),
                        SneakyMinion sm => sm.SneakyStab(),
                        Archer a3 => a3.ArrowShot(),
                        _ => enemy.DealDamage()
                    } : enemy.DealDamage();

                    Console.WriteLine($"Enemy deals {enemyDamage} damage.");
                    hero.TakeDamage(enemyDamage);
                    Console.WriteLine($"{hero.GetName()} has {hero.GetHealth()} HP left.");

                    if (hero.isDead())
                        Console.WriteLine("\nHero has fallen. Game over!");
                }
            }

            if (!hero.isDead())
                Console.WriteLine("\nAll enemies defeated! Victory!");
        }
    }
}