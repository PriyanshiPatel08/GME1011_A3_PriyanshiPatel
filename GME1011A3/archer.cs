using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GME1011A3
{
    internal class Archer : Hero
    {
        private int accuracy;

        // zero-argument constructor
        public Archer() : base()
        {
            this.accuracy = 6;
        }

        // argumented constructor
        public Archer(int health, string name, int accuracy) : base(health, name)
        {
            if (health > 90)
            {
                this.health = 90; // archers are a bit fragile
            }

            if (accuracy < 0 || accuracy > 10)
            {
                accuracy = 6;
            }

            this.accuracy = accuracy;
        }

        // override damage based on accuracy
        public override int DealDamage()
        {
            Random rng = new Random();
            return rng.Next(6, 12) + (accuracy / 2);
        }

        // special move: Snipe
        public int Snipe()
        {
            if (accuracy > 1)
            {
                accuracy -= 2;
                Random rng = new Random();
                return rng.Next(20, 30); // strong single shot
            }
            else
            {
                return 0; // not enough accuracy
            }
        }

        // getter
        public int GetAccuracy()
        {
            return this.accuracy;
        }

        // increase accuracy (max 10)
        public void AddAccuracy()
        {
            if (accuracy <= 9)
                accuracy++;
        }

        // ToString
        public override string ToString()
        {
            return "Archer[" + base.ToString() + ", accuracy: " + this.accuracy + "]";
        }
    }
}
