using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Classes
{
    public class CharacterClass
    {
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Range { get; set; }

        public int Health { get; set; }
        public int Mana { get; set; }
        public int Damage { get; set; }

        public char CharacterRepresentation { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public void Setup()
        {
            this.Health = this.Strength * 5;
            this.Mana = this.Intelligence * 3;
            this.Damage = this.Agility * 2;
        }
    }
}
