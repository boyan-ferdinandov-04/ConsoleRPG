using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRPG.Classes;

namespace ConsoleRPG
{
    public class Field
    {
        public static void DrawField(CharacterClass player, List<Enemy> enemies)
        {
            char[,] field = new char[10, 10];
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Health: {player.Health}    Mana: {player.Mana}");

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    field[i, j] = '▒';
                }
            }

            if (player.X >= 0 && player.X < 10 && player.Y >= 0 && player.Y < 10)
            {
                field[player.X, player.Y] = player.CharacterRepresentation;
            }

            foreach (var enemy in enemies)
            {
                if (enemy.X >= 0 && enemy.X < 10 && enemy.Y >= 0 && enemy.Y < 10)
                {
                    field[enemy.X, enemy.Y] = enemy.CharacterRepresentation;
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Enemies in range:");
            foreach (var enemy in enemies)
            {
                if (Math.Abs(enemy.X - player.X) <= player.Range && Math.Abs(enemy.Y - player.Y) <= player.Range)
                {
                    Console.WriteLine($"Enemy at ({enemy.X}, {enemy.Y}) with Health: {enemy.Health}");
                }
            }

            if (!enemies.Exists(e => Math.Abs(e.X - player.X) <= player.Range && Math.Abs(e.Y - player.Y) <= player.Range))
            {
                Console.WriteLine("No enemies in range.");
            }
        }
    }
}
