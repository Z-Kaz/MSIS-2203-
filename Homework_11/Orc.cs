using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11
{
    class Orc : Creature
    {
        public int orcAttack;

        public Orc(string name)
        {
            this.Name = name;
            this.CreatureType = "Orc";
            this.CreatureAttack = BaseAttack + num.Next(5, 11);
            this.CreatureHealth = BaseHealth + num.Next(5, 26);
        }

        public override int Attack()
        {
            int RageValue = num.Next(0, 11);
            orcAttack = CreatureAttack + RageValue;
            CreatureHealth -= RageValue;
            if(orcAttack < 0)
            {
                orcAttack = 0;
            }
            return orcAttack;
        }
    }
}
