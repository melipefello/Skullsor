using System;

namespace Enemies
{
    public class EnemyModel
    {
        public int Health { get; private set; }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            Health = Math.Max(Health, 0);
        }

        public void ResetHealth(int amount)
        {
            Health = amount;
        }
    }
}