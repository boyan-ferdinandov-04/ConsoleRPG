using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Classes.Characters
{
    public class Archer : CharacterClass
    {
        public Archer()
        {
            Strength = 2;
            Agility = 4;
            Intelligence = 0;
            Range = 2;
            CharacterRepresentation = '#';

            X = 1;
            Y = 1;
            Setup();
        }

    }
}
