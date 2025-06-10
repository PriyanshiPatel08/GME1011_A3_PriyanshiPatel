using System;

namespace GME1011A3
{
    internal abstract class Minion
    {
        protected int health;
        protected int armour;

        public Minion(int health, int armour)
        {
            if (health <= 0 || health > 35) health = 35;
            this.health = health;
            if (armour < 0 || armour > 5) armour = 3;
            this.armour = armour;
        }

        public int GetHealth() => health;
        public int GetArmour() => armour;

        public virtual void TakeDamage(int damage)
        {
            int actual = damage - armour;
            if (actual < 0) actual = 0;
            health -= actual;
        }

        public abstract int DealDamage();

        public bool isDead() => health <= 0;

        public override string ToString() =>
            $"Minion[{health}, {armour}]";
    }
}