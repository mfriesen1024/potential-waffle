using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class EnemyManager
    {
        internal MapData mapData;
        internal Player player;
        internal List<List<Enemy>> allEnemyLists = new List<List<Enemy>>();
        internal List<Enemy> listOfEnemies = new List<Enemy>();

        public EnemyManager(MapData mapData)
        {
            this.mapData = mapData;
        }
        public void MoveEnemies()
        { 
            foreach (var enemy in listOfEnemies)
            {
                if (enemy.dead) continue;
                enemy.MoveEnemy();
            }
        }
        public void DrawEnemies()
        {
            foreach (var enemy in listOfEnemies)
            {
                if (enemy.dead) continue;
                enemy.DrawEnemy();
            }
        }
        public void SetPlayer(Player player)
        {
            this.player = player;
        }
    }
}
