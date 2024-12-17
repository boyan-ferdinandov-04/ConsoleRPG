using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Classes.Characters
{
    public class Enemy : CharacterClass
    {
        private static readonly Random Random = new();
        public Enemy()
        {
            Strength = GenerateRandomInt();
            Agility = GenerateRandomInt();
            Intelligence = GenerateRandomInt();

            Range = 1;
            Setup();
            CharacterRepresentation = '\u25d9';
        }

        private static int GenerateRandomInt()
        {
            return Random.Next(1, 4);
        }

    }
}
