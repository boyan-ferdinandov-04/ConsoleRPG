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
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            //ScreenEnum currentState = ScreenEnum.MainMenu;
            //CharacterClass playerCharacter = null;
            //List<Enemy> enemies = new();
            //Random random = new Random();

            //while (currentState != ScreenEnum.Exit)
            //{
            //    switch (currentState)
            //    {
            //        case ScreenEnum.MainMenu:
            //            currentState = ShowMainMenu();
            //            break;
            //        case ScreenEnum.CharacterSelect:
            //            playerCharacter = SelectCharacter();
            //            AllocateStats(playerCharacter);
            //            //SaveCharacterInfo(playerCharacter);
            //            currentState = ScreenEnum.InGame;
            //            break;

            //        case ScreenEnum.InGame:
            //            Console.Clear();
            //            SpawnEnemy(random, enemies, playerCharacter);
            //            Field.DrawField(playerCharacter, enemies);
            //            Console.WriteLine("Choose action:\n1) Attack\n2) Move");
            //            string action = Console.ReadLine();

            //            if (action == "1")
            //            {
            //                HandleAttack(playerCharacter, enemies);
            //            }
            //            else if (action == "2")
            //            {
            //                HandleMovement(playerCharacter);
            //            }
            //            else
            //            {
            //                Console.WriteLine("Invalid input. Skipping turn.");
            //            }

            //            UpdateEnemies(playerCharacter, enemies);
            //            break;

            //        case ScreenEnum.Exit:
            //            Environment.Exit(0);
            //            break;
            //    }
            //}

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Game game = new Game();
            game.Run();
        }

        //static ScreenEnum ShowMainMenu()
        //{
        //    Console.Clear();
        //    Console.WriteLine("Welcome! \nPress any key to play.");
        //    Console.ReadKey(true);
        //    return ScreenEnum.CharacterSelect;
        //}

        //static CharacterClass SelectCharacter()
        //{
        //    CharacterClass character = null;
        //    bool isConfirmed = false;
        //    while (!isConfirmed)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Choose character type:\n1) Warrior\n2) Archer\n3) Mage\n4) Display Logs\nYour pick: ");

        //        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

        //        switch (keyInfo.Key)
        //        {
        //            case ConsoleKey.D1:
        //            case ConsoleKey.NumPad1:
        //                character = new Warrior();
        //                Console.WriteLine("\nYou chose Warrior!");
        //                break;

        //            case ConsoleKey.D2:
        //            case ConsoleKey.NumPad2:
        //                character = new Archer();
        //                Console.WriteLine("\nYou chose Archer!");
        //                break;

        //            case ConsoleKey.D3:
        //            case ConsoleKey.NumPad3:
        //                character = new Mage();
        //                Console.WriteLine("\nYou chose Mage!");
        //                break;

        //            case ConsoleKey.D4:
        //            case ConsoleKey.NumPad4:
        //                DisplayLogs();
        //                Console.WriteLine("Press anything to continue");
        //                Console.ReadKey(true);
        //                continue;
        //            default:
        //                Console.WriteLine("Invalid choice. Returning to the selection");
        //                continue;
        //        }
        //        Console.WriteLine($"\nYou selected: {character.GetType().Name}.\nIs this correct? (Y/N)");
        //        ConsoleKeyInfo confirmation = Console.ReadKey(true);

        //        if (confirmation.Key == ConsoleKey.Y)
        //        {
        //            isConfirmed = true;
        //        }
        //        else
        //        {
        //            Console.WriteLine("\nRe-selecting character...\nPress any key to continue.");
        //            Console.ReadKey(true);
        //        }
        //    }

        //    return character;
        //}

        //static void AllocateStats(CharacterClass playerCharacter)
        //{
        //    Console.Clear();
        //    Console.WriteLine($"You have chosen {playerCharacter.GetType().Name}");
        //    Console.WriteLine("Would you like to buff up your stats before starting? (Limit: 3 points total)");
        //    Console.WriteLine("Response (Y/N): ");

        //    ConsoleKeyInfo response = Console.ReadKey(true);

        //    if (response.Key == ConsoleKey.Y)
        //    {
        //        int remainingPoints = 3;

        //        while (remainingPoints > 0)
        //        {
        //            Console.Clear();
        //            Console.WriteLine($"Remaining Points: {remainingPoints}");
        //            Console.WriteLine($"Current Stats:\nStrength: {playerCharacter.Strength}\nAgility: {playerCharacter.Agility}\nIntelligence: {playerCharacter.Intelligence}");
        //            Console.Write("Add to Strength: ");
        //            int addStrength = ReadStatInput(remainingPoints);

        //            remainingPoints -= addStrength;

        //            Console.Write("Add to Agility: ");
        //            int addAgility = ReadStatInput(remainingPoints);

        //            remainingPoints -= addAgility;

        //            Console.Write("Add to Intelligence: ");
        //            int addIntelligence = ReadStatInput(remainingPoints);

        //            remainingPoints -= addIntelligence;

        //            playerCharacter.Strength += addStrength;
        //            playerCharacter.Agility += addAgility;
        //            playerCharacter.Intelligence += addIntelligence;
        //        }

        //        Console.WriteLine("\nStat allocation complete! Press any key to continue...");
        //        playerCharacter.Setup();
        //        Console.ReadKey(true);
        //    }
        //}



        //static void DisplayLogs()
        //{
        //    using (var context = new ConsoleRPGContext())
        //    {
        //        var logs = context.GameLogs.ToList();
        //        Console.WriteLine("Saved Character Logs:");
        //        foreach (var log in logs)
        //        {
        //            Console.WriteLine($"ID: {log.Id}, Type: {log.CharacterClass}, Strength: {log.Strength}, Agility: {log.Agility}, Intelligence: {log.Intelligence}, Created On: {log.CreationTime}");
        //        }
        //    }
        //}

        //static int ReadStatInput(int maxPoints)
        //{
        //    int value;
        //    while (true)
        //    {
        //        string input = Console.ReadLine();
        //        if (int.TryParse(input, out value) && value >= 0 && value <= maxPoints)
        //        {
        //            return value;
        //        }
        //        Console.WriteLine($"Invalid input. Please enter a value between 0 and {maxPoints}: ");
        //    }
        //}

        //static void HandleMovement(CharacterClass playerCharacter)
        //{
        //    Console.WriteLine("Use WASD to move or diagonals with QEZX:");
        //    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

        //    switch (keyInfo.Key)
        //    {
        //        case ConsoleKey.W:
        //            playerCharacter.X = Math.Max(0, playerCharacter.X - 1);
        //            break;
        //        case ConsoleKey.S:
        //            playerCharacter.X = Math.Min(9, playerCharacter.X + 1);
        //            break;
        //        case ConsoleKey.A: 
        //            playerCharacter.Y = Math.Max(0, playerCharacter.Y - 1);
        //            break;
        //        case ConsoleKey.D:
        //            playerCharacter.Y = Math.Min(9, playerCharacter.Y + 1);
        //            break;
        //        case ConsoleKey.Q: 
        //            playerCharacter.X = Math.Max(0, playerCharacter.X - 1);
        //            playerCharacter.Y = Math.Max(0, playerCharacter.Y - 1);
        //            break;
        //        case ConsoleKey.E: 
        //            playerCharacter.X = Math.Max(0, playerCharacter.X - 1);
        //            playerCharacter.Y = Math.Min(9, playerCharacter.Y + 1);
        //            break;
        //        case ConsoleKey.Z: 
        //            playerCharacter.X = Math.Min(9, playerCharacter.X + 1);
        //            playerCharacter.Y = Math.Max(0, playerCharacter.Y - 1);
        //            break;
        //        case ConsoleKey.X: 
        //            playerCharacter.X = Math.Min(9, playerCharacter.X + 1);
        //            playerCharacter.Y = Math.Min(9, playerCharacter.Y + 1);
        //            break;
        //        default:
        //            Console.WriteLine("Invalid input. Skipping movement.");
        //            break;
        //    }
        //}

        //static void HandleAttack(CharacterClass player, List<Enemy> enemies)
        //{
        //    var targetsInRange = enemies.Where(e => Math.Abs(e.X - player.X) <= player.Range && Math.Abs(e.Y - player.Y) <= player.Range).ToList();

        //    if (!targetsInRange.Any())
        //    {
        //        Console.WriteLine("No available targets in your range.");
        //        return;
        //    }

        //    Console.WriteLine("Available targets:");
        //    for (int i = 0; i < targetsInRange.Count; i++)
        //    {
        //        Console.WriteLine($"{i}) Target({targetsInRange[i].X}, {targetsInRange[i].Y}) with remaining Health: {targetsInRange[i].Health}");
        //    }

        //    Console.Write("Which one to attack: ");
        //    int choice = ReadStatInput(targetsInRange.Count - 1);

        //    var target = targetsInRange[choice];
        //    target.Health -= player.Damage;
        //    Console.WriteLine($"You dealt {player.Damage} damage. Target's remaining Health: {target.Health}");

        //    if (target.Health <= 0)
        //    {
        //        Console.WriteLine("Target eliminated!");
        //        enemies.Remove(target);
        //    }
        //}

        //static void UpdateEnemies(CharacterClass player, List<Enemy> enemies)
        //{
        //    foreach (var enemy in enemies)
        //    {
        //        if (Math.Abs(enemy.X - player.X) <= 1 && Math.Abs(enemy.Y - player.Y) <= 1)
        //        {
        //            Console.WriteLine($"Enemy attacks you for {enemy.Damage} damage!");
        //            player.Health -= enemy.Damage;

        //            if (player.Health <= 0)
        //            {
        //                Console.WriteLine("You have been defeated. Game over.");
        //                Environment.Exit(0);
        //            }
        //        }
        //        else
        //        {
        //            if (enemy.X < player.X) 
        //                enemy.X++;
        //            else if (enemy.X > player.X) 
        //                enemy.X--;

        //            if (enemy.Y < player.Y) 
        //                enemy.Y++;
        //            else if (enemy.Y > player.Y) enemy.Y--;
        //        }
        //    }
        //}

        //static void SpawnEnemy(Random random, List<Enemy> enemies, CharacterClass player)
        //{
        //    int x, y;
        //    bool isPositionValid;
        //    do
        //    {
        //        x = random.Next(0, 10);
        //        y = random.Next(0, 10);
        //        isPositionValid = (x != player.X || y != player.Y) && !enemies.Any(e => e.X == x && e.Y == y);

        //    } while (!isPositionValid);

        //    enemies.Add(new Enemy { X = x, Y = y });
        //}
    }
}
