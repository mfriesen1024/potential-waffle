using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{   // Everything added to this class needs to have a reference within all of its children, don't clutter this
    public abstract class Entity 
    {
        private HealthSystem healthSystem;
        public string Name { get; set; }
        public string CreatureType { get; set; } // For now creature types do jack all

        // Other common properties or methods...

        // Abstract method that must be implemented by derived classes
        public Entity(string name, int initialHealth, string creatureType) 
        {
            Name = name;
            CreatureType = creatureType;
            healthSystem = new HealthSystem(initialHealth);
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Health: {healthSystem.CurrentHealth}, Creature Type: {CreatureType}");
        }
        public void TakeDamage(int damage) => healthSystem.TakeDamage(damage);
        public void Heal(int amount) => healthSystem.Heal(amount);
        public abstract void Attack(Entity target);
    }
}
