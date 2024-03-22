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
        public int MaxHealth = Settings.MaxPlayerHealth;
        public int Damage;
        public HealthSystem(int initialHealth)
        {
            CurrentHealth = initialHealth;
        }
        public virtual void TakeDamage(int Damage)
        {
            CurrentHealth -= Damage;
        }
        public virtual void Heal(int amount)
        {
            CurrentHealth += amount;
            if(CurrentHealth >= MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
        }
    }
}
