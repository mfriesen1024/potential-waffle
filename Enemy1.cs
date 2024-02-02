using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class Enemy1 : EnemyEntity
    {
        // Constructor for Enemy1, it needs to pass mapData and player to the base class constructor
        public Enemy1(MapData mapData, Player player) : base(mapData, player)
        {
            // Enemy 1 specific initializations go here so that methods within Enemy1 can see them.  
        }



    }
}
