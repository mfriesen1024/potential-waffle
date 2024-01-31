using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    // Use this example to determine if there is more than one instance of a class when there should not be.
    internal class Map
    {
        private static int count;

        public Map() 
        { 
        Debug.Assert(count == 0);
        
        }
    }



    // Proper OOP class relationship using a constructor I made to teach myself
    // Add Example after existing class names to avoid unintended references or double names.
        class PlayerExample // class declaration 
    {

         // Private field for encapsulation
        private HealthInfo healthInfo; // Constructor for initializing instances

        public PlayerExample() // Name of containing class followed by () creates a "Constructor". 
        // Creates a new instance of HealthInfo for this player
        // Constructors can be used to initialize instances of other classes, creating a sort of "composition" or "aggregation" of objects. 
        // This allows methods within the class to interact with the instances created in the constructor.
        {
            // Updates the PlayerHealth property of the healthInfo instance
            healthInfo = new HealthInfo(); // Creates an instance/copy of the named class elsewhere in the project. From this instance you may access methods and variables from that class for object references.
        }

        public void SetPlayerHealth(int newHealth) // This passes an int argument into the method requiring an int to be provided when the method is called, this int will become the new value for this instance of PlayerHealth contained by Player;
        // healthInfo.PlayerHealth = newHealth;: This line updates the PlayerHealth property of the new healthInfo object within the instance contained within the constructor.
        // This new health value is passed as an argument to this method allowing it to be freely changed without effecting the original HealthInfo class. 
        {
            healthInfo.PlayerHealth = newHealth; 
        }
    }

    public class HealthInfo // Original class that is referenced in the Player constructor. 
    {
        // Public property needed for access from outside the class
        public int PlayerHealth = 100; // Anything that is intended to be accessed by other classes through constructors or other means needs to be public. Only the original class can access private data.
    } 



}
