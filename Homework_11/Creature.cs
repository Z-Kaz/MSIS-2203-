using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11
{
    class Creature
    {
        protected static Random num = new Random();
        public string Name { get; set; }
        public string CreatureType { get; set; }
        public int BaseAttack = 10;
        public int BaseHealth = 50;

        public int CreatureAttack { get; set; }
        public int CreatureHealth { get; set; }
        public int humanAttack;

        public Creature(string Name, string CreatureType)
        {
            this.Name = Name;
            this.CreatureType = CreatureType;
            this.CreatureHealth = BaseHealth;
            this.CreatureAttack = BaseAttack;
        }
        public Creature() { }

        public virtual int Attack()
        {
            humanAttack = BaseAttack + num.Next(-5, 6);
            if (humanAttack < 0)
            {
                humanAttack = 0;
            }
            return humanAttack;
        }
    }
}
