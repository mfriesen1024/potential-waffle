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

        internal List<List<EnemyEntity>> allEnemyLists = new List<List<EnemyEntity>>();
        internal List<Enemy1> listOfEnemies = new List<Enemy1>();

        public EnemyManager(MapData mapData)
        {
            this.mapData = mapData;
        }

        public void MoveEnemies()
        {
            /*foreach (List<EnemyEntity> enemyList in allEnemyLists)
            {
                foreach(EnemyEntity enemy in enemyList)
                {
                    enemy.MoveEnemy();
                }
            }*/

            foreach (var enemy in listOfEnemies)
            {
                enemy.MoveEnemy();
            }
        }

        public void DrawEnemies()
        {
            foreach (var enemy in listOfEnemies)
            {
                enemy.DrawEnemy();
            }
        }

        public void SetPlayer(Player player)
        {
            this.player = player;
        }
    }
}
