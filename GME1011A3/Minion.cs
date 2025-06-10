using System;

namespace GME1011A3
{
    internal abstract class Minion
    {
        protected int health;
        protected int armour;

        public Minion(int health, int armour)
        {
            if (health <= 0 || health > 35)
                health = 35;
            this.health = health;

            if (armour < 0 || armour > 5)
                armour = 3;
            this.armour = armour;
        }

        public int GetHealth() { return health; }
        public int GetArmour() { return armour; }

        public virtual void TakeDamage(int damage)
        {
            int actualDamage = damage - armour;
            if (actualDamage < 0) actualDamage = 0;
            health -= actualDamage;
        }

        public abstract int DealDamage();

        public bool isDead() { return health <= 0; }

        public override string ToString()
        {
            return "Minion[" + health + ", " + armour + "]";
        }
    }
}
s