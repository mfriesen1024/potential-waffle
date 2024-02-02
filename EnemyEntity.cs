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

        protected Buffer buffer;
        
        public int EnemyCol;
        public int EnemyRow;

        protected EnemyManager enemyManager;

        protected char EnemyCharacter;

        public EnemyEntity(MapData mapData, int attackValue, EnemyManager enemyManager, Buffer buffer) // What is passed into EnemyEntity
         : base("DefaultEnemyName", 100, "Enemy") // base = what it is given/needs by default from its parent/base class
        {
            this.enemyManager = enemyManager;
            this.mapData = mapData;
            enemyManager.allEnemyLists.Add(new List<EnemyEntity>());
            enemyManager.allEnemyLists[enemyManager.allEnemyLists.Count - 1].Add(this);
            attackValue = AttackValue;
            this.buffer = buffer;
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
            foreach (var enemyList in enemyManager.allEnemyLists)
            {
                foreach (var enemy in enemyList)
                {
                    Console.WriteLine();
                }
            }
        }

        public virtual void MoveEnemy(){}
        public void DrawEnemy()
        {
            buffer.secondBuffer[EnemyCol, EnemyRow] = EnemyCharacter;
        }
    }
}
