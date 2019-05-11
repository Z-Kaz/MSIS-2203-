using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11
{
    class Bunny : Creature
    {
        private string FavFood = "carrot";
        private int numFood = num.Next(3, 9);
        public int BunnyAttack;

        public Bunny(string name)
        {
            this.Name = name;
            this.CreatureType = "Bunny";
            this.CreatureAttack = BaseAttack + num.Next(-5, 1);
            this.CreatureHealth = BaseHealth + num.Next(-30, -9);
        }

        public int Eat()
        {
            if (numFood > 0)
            {
                numFood--;
                CreatureHealth += num.Next(5, 11);
                Console.WriteLine($"{Name} ate a {FavFood}!");
                return CreatureHealth;
            }
            else
            {
                Console.WriteLine($"{Name} tried to eat a {FavFood}, but there were none left.");
            }
            return numFood;
            
        }

        public override int Attack()
        {
            if(num.Next(1, 101) <= 5)
            {
                Eat();
            }
            BunnyAttack = CreatureAttack + num.Next(-7, 4);
            if (BunnyAttack < 0)
            {
                BunnyAttack = 0;
            }
            return BunnyAttack;
        }

    }
}
