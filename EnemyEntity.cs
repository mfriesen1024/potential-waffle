using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class EnemyEntity : Entity
    {
        internal MapData mapData;
        internal Player player;
        internal int MapWidth;
        internal int MapHeight;
        internal int playerRow;
        internal int playerCol;
        public int EnemyCol;
        public int EnemyRow;
        internal List<List<EnemyEntity>> allEnemyLists = new List<List<EnemyEntity>>();
        internal List<Enemy1> listOfEnemies = new List<Enemy1>();

        public EnemyEntity(MapData mapData, Player player, int attackValue) // What is passed into EnemyEntity
         : base("DefaultEnemyName", 100, "Enemy") // base = what it is given/needs by default from its parent/base class
        {
            this.mapData = mapData;
            this.player = player;
            allEnemyLists.Add(new List<EnemyEntity>());
            allEnemyLists[allEnemyLists.Count - 1].Add(this);
            attackValue = AttackValue;
        }
        public int CurrentHealth => healthSystem.CurrentHealth;

        internal void MeasureMapSize()
        {
            int MapWidth = mapData.map.GetLength(1);
            int MapHeight = mapData.map.GetLength(0);
        }
        public override void Attack(Entity target) // target is of type Entity, fill this arguement with who is being attacked.
        {

            Console.WriteLine("Display Info to be used until attacks are added");
        }

        public void DisplayAllEnemyListsInfo() // Spits out all each list of enemies that contains any number of enemies.
        {
            foreach (var enemyList in allEnemyLists)
            {
                foreach (var enemy in enemyList)
                {
                    enemy.DisplayInfo();
                    Console.WriteLine();
                }
            }
        }
        internal void PlayerDetection()
        {
            playerRow = player.playerRow;
            playerCol = player.playerCol;
        }
    }
}
