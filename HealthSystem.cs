using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    public class HealthSystem
    {
        public int CurrentHealth { get; set; }
        public HealthSystem(int initialHealth)
        {
            CurrentHealth = initialHealth;
        }
        public virtual void TakeDamage(int attackValue, int modifier)
        {
            int damage = attackValue + modifier;
            CurrentHealth -= damage;
            //Console.WriteLine($"Entity took {damage} damage. Current health: {CurrentHealth}");
        }
        public virtual void Heal(int amount)
        {
            CurrentHealth += amount;
            //Console.WriteLine($"Entity healed for {amount}. Current health: {CurrentHealth}");
        }
    }
}
