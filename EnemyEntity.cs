using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class EnemyEntity
    {
        private MapData mapData;
        private Player player;
        private int MapWidth;
        private int MapHeight;

        public EnemyEntity(MapData mapData, Player player)
        {
            this.mapData = mapData;
            this.player = player; 
        }
        void MethodOrSomething()
        {
            int MapWidth = mapData.map.GetLength(1);
            int MapHeight = mapData.map.GetLength(0);
        }

       



    }
}
