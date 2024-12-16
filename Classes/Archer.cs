using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Classes
{
    public class Archer:CharacterClass
    {
        public Archer()
        {
            Strength = 2;
            Agility = 1;
            Intelligence = 3;
            Range = 3;
            CharacterRepresentation = '#';

            X = 1;
            Y = 1;
            Setup();
        }

    }
}
