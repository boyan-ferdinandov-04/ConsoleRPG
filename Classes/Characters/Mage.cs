using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Classes.Characters
{
    public class Mage : CharacterClass
    {
        public Mage()
        {
            Strength = 2;
            Agility = 1;
            Intelligence = 3;
            Range = 3;

            X = 1;
            Y = 1;

            CharacterRepresentation = '*';
            Setup();
        }
    }
}
