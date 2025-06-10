using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GME1011A3
{
    internal class SneakyMinion : Minion
    {
        private int sneakLevel;

        // Zero-argument constructor
        public SneakyMinion() : base()
        {
            this.sneakLevel = 3;
        }

        // Argumented constructor
        public SneakyMinion(int health, string name, int sneakLevel) : base(health, name)
        {
            if (sneakLevel < 0 || sneakLevel > 10)
                sneakLevel = 3;

            this.sneakLevel = sneakLevel;
        }

        // Override DealDamage — sneakier = more damage
        public override int DealDamage()
        {
            Random rng = new Random();
            return rng.Next(4, 8) + (sneakLevel / 2);
        }

        // Special move: SneakAttack
        public int SneakAttack()
        {
            if (sneakLevel > 0)
            {
                sneakLevel--;
                Random rng = new Random();
                return rng.Next(10, 20);
            }
            else
            {
                return 0;
            }
        }

        // Increase sneakLevel (max 10)
        public void AddSneak()
        {
            if (sneakLevel <= 9)
                sneakLevel++;
        }

        // Get sneak level
        public int GetSneakLevel()
        {
            return this.sneakLevel;
        }

        // Override ToString
        public override string ToString()
        {
            return "SneakyMinion[" + base.ToString() + ", sneakLevel: " + this.sneakLevel + "]";
        }
    }
}
