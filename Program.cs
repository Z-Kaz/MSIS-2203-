using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Creature humanCreature = new Creature("Finn", "Human");
            Bunny bunnyCreature = new Bunny("Jake");
            Orc orcCreature = new Orc("Gunther");

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{humanCreature.Name} stats:\n\tType: {humanCreature.CreatureType}\n\tBase Attack: {humanCreature.CreatureAttack}\n\tHealth: {humanCreature.CreatureHealth}");
                Console.WriteLine($"{bunnyCreature.Name} stats:\n\tType: {bunnyCreature.CreatureType}\n\tBase Attack: {bunnyCreature.CreatureAttack}\n\tHealth: {bunnyCreature.CreatureHealth}");
                Console.WriteLine($"{orcCreature.Name} stats:\n\tType: {orcCreature.CreatureType}\n\tBase Attack: {orcCreature.CreatureAttack}\n\tHealth: {orcCreature.CreatureHealth}\n");
                
                Console.WriteLine($"Sample fight round data for {humanCreature.Name} the {humanCreature.CreatureType}: \tHealth: {humanCreature.CreatureHealth}\tAttack: {humanCreature.humanAttack}");
                Console.WriteLine($"Sample fight round data for {bunnyCreature.Name} the {bunnyCreature.CreatureType}: \tHealth: {bunnyCreature.CreatureHealth}\tAttack: {bunnyCreature.BunnyAttack}");
                Console.WriteLine($"Sample fight round data for {orcCreature.Name} the {orcCreature.CreatureType}: \tHealth: {orcCreature.CreatureHealth}\tAttack: {orcCreature.orcAttack}");

                humanCreature.Attack();
                bunnyCreature.Attack();
                orcCreature.Attack();
                
                Console.ReadKey();
            }
        }
    }
}
