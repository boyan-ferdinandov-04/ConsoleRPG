using ConsoleRPG.Classes;
using ConsoleRPG.Data;
using ConsoleRPG.Data.Models;
using ConsoleRPG.Enums;

namespace ConsoleRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Game game = new Game();
            game.Run();
        }

    }
}
