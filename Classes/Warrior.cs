using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Classes
{
    public class Warrior:CharacterClass
    {
        public Warrior()
        {
            Strength = 3;
            Agility = 3;
            Intelligence = 0;
            Range = 1;

            X = 1;
            Y = 1;

            CharacterRepresentation = '@';
            Setup();
        }

    }
}
