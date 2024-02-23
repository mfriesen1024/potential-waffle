using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal abstract class Enemy : Entity // base class for all enemy types to inherit from
    {
        internal MapData mapData;
        internal Player player;
        protected Buffer buffer;
        protected EnemyManager enemyManager;
        public int TurnCount;

        protected char EnemyCharacter;
        public int EnemyCol;
        public int EnemyRow;
        public int CurrentHealth => healthSystem.CurrentHealth;
        public int MaxHealth;
        public static string[] SmallCreatureTypes = { "Duck" };
        public static string[] MediumCreatureTypes = { "Not Duck" };
        public static string[] LargeCreatureTypes = { "Also Not Duck" };

        public Enemy(MapData mapData, int attackValue, EnemyManager enemyManager, Buffer buffer) // What is passed into Enemy
            : base("DefaultEnemyName", 10, new string[] { "Enemy" }) // base = what it is given/needs by default from its parent/base class
        {
            this.enemyManager = enemyManager;
            this.mapData = mapData;
            enemyManager.allEnemyLists.Add(new List<Enemy>());
            enemyManager.allEnemyLists[enemyManager.allEnemyLists.Count - 1].Add(this);
            attackValue = AttackValue;
            this.buffer = buffer;
            dead = false;
        }
        public override void Attack(Entity target) { } // target is of type Entity, fill this arguement with who is being attacked.
        public abstract int DetermineMaxHealth();

        public virtual void MoveEnemy(){}
        public void DrawEnemy()
        {
            if (!dead)
            {
            buffer.secondBuffer[EnemyCol, EnemyRow] = EnemyCharacter; // USE AS FUTURE REFERENCE FOR DRAWING INTO BUFFER
            }
        }
        
        protected internal void SpawnEnemy(string name, int health, string[] creatureTypes, int creatureTypeIndex, int attackValue)
        {
            int randomX, randomY;
            do
            {
                randomX = Settings.random.Next(8, 77);
                randomY = Settings.random.Next(8, 27);
            } while (MapData.map[randomY, randomX] != ' ');
            DrawEnemy();
            EnemyCol = randomY;
            EnemyRow = randomX;
            Name = name;
            enemyManager.listOfEnemies.Add(this);
            string creatureType = creatureTypes[creatureTypeIndex];
        }
    }
}
