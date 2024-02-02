using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{   // Everything added to this class needs to have a reference within all of its children, don't clutter this
    public abstract class Entity 
    {
        protected HealthSystem healthSystem;
        public string Name { get; set; }
        public string CreatureType { get; set; } // For now creature types do jack all
        public int AttackValue { get; set; }
        public int Level { get; set; }
        public int CurrentHealth { get => healthSystem.CurrentHealth; set => healthSystem.CurrentHealth = value; }

        public bool dead;

        public Entity(string name, int initialHealth, string creatureType) 
        {
            Name = name;
            CreatureType = creatureType;
            healthSystem = new HealthSystem(initialHealth);
            AttackValue = 1;
            Level = 1;
        }
        public void Die()
        {
            Console.WriteLine($"{Name} has been defeated!");
            dead = true;
        }
        //public virtual void DisplayInfo()
        //{
        //    Console.WriteLine($"Name: {Name}, Health: {healthSystem.CurrentHealth}, Creature Type: {CreatureType}");
        //}
        public void TakeDamage(int attackValue, int modifier) => healthSystem.TakeDamage(AttackValue, modifier);
        public void Heal(int amount) => healthSystem.Heal(amount);
        public abstract void Attack(Entity target);
    }
}
