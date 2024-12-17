using ConsoleRPG.Classes;
using ConsoleRPG.Classes.Characters;
using ConsoleRPG.Data;
using ConsoleRPG.Data.Models;
using ConsoleRPG.Enums;
using System.Numerics;

namespace ConsoleRPG
{
    public class Game
    {
        //An enum that checks for the screen state
        private ScreenEnum currentState;
        //A variable that keeps track of the player
        private CharacterClass playerCharacter;
        private List<Enemy> enemies;
        private Random random;
        //During every game session we keep track of the kill counts
        private int monsterKillCount;
        
        public Game()
        {
            currentState = ScreenEnum.MainMenu;
            enemies = new List<Enemy>();
            random = new Random();
            monsterKillCount = 0;
        }

        //The launcher method
        public void Run()
        {
            while (currentState != ScreenEnum.Exit)
            {
                switch (currentState)
                {
                    case ScreenEnum.MainMenu:
                        currentState = ShowMainMenu();
                        break;
                    case ScreenEnum.CharacterSelect:
                        playerCharacter = SelectCharacter();
                        AllocateStats(playerCharacter);
                        SaveCharacterInfo(playerCharacter);
                        currentState = ScreenEnum.InGame;
                        break;
                    case ScreenEnum.InGame:
                        HandleGameLoop();
                        break;
                    
                }
            }
            //When we exit the game we save the session
            SaveSession();
            Environment.Exit(0);
        }

        private ScreenEnum ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome! \nPress any key to play.");
            Console.ReadKey(true);
            return ScreenEnum.CharacterSelect;
        }

        private CharacterClass SelectCharacter()
        {
            CharacterClass character = null;
            bool isConfirmed = false;

            while (!isConfirmed)
            {
                Console.Clear();
                Console.WriteLine("Choose character type or view logs of previous games:\nOptions:\n1) Warrior\n2) Archer\n3) Mage\n4) Display Logs\nYour pick: ");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        character = new Warrior();
                        Console.WriteLine("\nYou chose Warrior!");
                        break;
                    case ConsoleKey.D2:
                        character = new Archer();
                        Console.WriteLine("\nYou chose Archer!");
                        break;
                    case ConsoleKey.D3:
                        character = new Mage();
                        Console.WriteLine("\nYou chose Mage!");
                        break;
                    case ConsoleKey.D4:
                        DisplayLogs();
                        Console.WriteLine("Press anything to continue");
                        Console.ReadKey(true);
                        continue;
                    default:
                        Console.WriteLine("Invalid choice. Returning to the selection");
                        continue;
                }
                //We make sure that the player has selected the characters they want to play as
                //and haven't accidentally selected something else
                Console.WriteLine($"\nYou selected: {character.GetType().Name}.\nIs this correct? (Y/N)");
                ConsoleKeyInfo confirmation = Console.ReadKey(true);

                if (confirmation.Key == ConsoleKey.Y)
                {
                    isConfirmed = true;
                }
                else
                {
                    Console.WriteLine("\nRe-selecting character...\nPress any key to continue.");
                    Console.ReadKey(true);
                }
            }

            return character;
        }

        private void AllocateStats(CharacterClass playerCharacter)
        {
            Console.Clear();
            Console.WriteLine($"You have chosen {playerCharacter.GetType().Name}");
            Console.WriteLine("Would you like to buff up your stats before starting? (Limit: 3 points total)");
            Console.WriteLine("Response (Y/N): ");

            ConsoleKeyInfo response = Console.ReadKey(true);

            if (response.Key == ConsoleKey.Y)
            {
                int remainingPoints = 3;

                while (remainingPoints > 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Remaining Points: {remainingPoints}");
                    Console.WriteLine($"Current Stats:\nStrength: {playerCharacter.Strength}\nAgility: {playerCharacter.Agility}\nIntelligence: {playerCharacter.Intelligence}");
                    Console.Write("Add to Strength: ");
                    int addStrength = ReadStatInput(remainingPoints);

                    remainingPoints -= addStrength;
                    Console.WriteLine($"Remaining Points: {remainingPoints}");
                    Console.Write("Add to Agility: ");
                    int addAgility = ReadStatInput(remainingPoints);

                    remainingPoints -= addAgility;
                    Console.WriteLine($"Remaining Points: {remainingPoints}");
                    Console.Write("Add to Intelligence: ");
                    int addIntelligence = ReadStatInput(remainingPoints);

                    remainingPoints -= addIntelligence;
                    Console.WriteLine($"Remaining Points: {remainingPoints}");
                    playerCharacter.Strength += addStrength;
                    playerCharacter.Agility += addAgility;
                    playerCharacter.Intelligence += addIntelligence;
                }

                Console.WriteLine("\nStat allocation complete! Press any key to continue...");
                playerCharacter.Setup();
                Console.ReadKey(true);
            }
        }
        //THe method that handles the main game loop:
        //Movement, enemies, etc.
        private void HandleGameLoop()
        {
            Console.Clear();
            SpawnEnemy(random, enemies, playerCharacter);
            Field.DrawField(playerCharacter, enemies);
            Console.WriteLine("Choose action:\n1) Attack\n2) Move");
            string action = Console.ReadLine();

            if (action == "1")
            {
                HandleAttack(playerCharacter, enemies);
            }
            else if (action == "2")
            {
                HandleMovement(playerCharacter);
            }
            else
            {
                Console.WriteLine("Invalid input. Skipping turn.");
            }

            UpdateEnemies(playerCharacter, enemies);
            //If the player dies we go to the exit screen
            if (playerCharacter.Health <= 0)
            {
                Console.WriteLine("You have been defeated.");
                currentState = ScreenEnum.Exit;
                
            }
        }
        // A method that handles movement in a matrix
        //The math class is used to make sure that the player doesn't go out of bounds
        private void HandleMovement(CharacterClass playerCharacter)
        {
            Console.WriteLine("Use WASD to move or diagonals with QEZX:");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.W: 
                    playerCharacter.X = Math.Max(0, playerCharacter.X - 1);
                    break;
                case ConsoleKey.S: 
                    playerCharacter.X = Math.Min(9, playerCharacter.X + 1); 
                    break;
                case 
                    ConsoleKey.A: playerCharacter.Y = Math.Max(0, playerCharacter.Y - 1); 
                    break;
                case 
                    ConsoleKey.D: playerCharacter.Y = Math.Min(9, playerCharacter.Y + 1); 
                    break;
                case ConsoleKey.Q:
                    playerCharacter.X = Math.Max(0, playerCharacter.X - 1);
                    playerCharacter.Y = Math.Max(0, playerCharacter.Y - 1);
                    break;
                case ConsoleKey.E:
                    playerCharacter.X = Math.Max(0, playerCharacter.X - 1);
                    playerCharacter.Y = Math.Min(9, playerCharacter.Y + 1);
                    break;
                case ConsoleKey.Z:
                    playerCharacter.X = Math.Min(9, playerCharacter.X + 1);
                    playerCharacter.Y = Math.Max(0, playerCharacter.Y - 1);
                    break;
                case ConsoleKey.X:
                    playerCharacter.X = Math.Min(9, playerCharacter.X + 1);
                    playerCharacter.Y = Math.Min(9, playerCharacter.Y + 1);
                    break;
                default:
                    Console.WriteLine("Invalid input. Skipping movement.");
                    break;
            }
        }
        //A method that eases the input of numbers that have to be in a specific range
        private int ReadStatInput(int maxPoints)
        {
            int value;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out value) && value >= 0 && value <= maxPoints)
                {
                    return value;
                }
                Console.WriteLine($"Invalid input. Please enter a value between 0 and {maxPoints}: ");
            }
        }

        //We spawn enemies as long as the position is valid
        private void SpawnEnemy(Random random, List<Enemy> enemies, CharacterClass player)
        {
            int x, y;
            bool isPositionValid;
            do
            {
                x = random.Next(0, 10);
                y = random.Next(0, 10);
                isPositionValid = (x != player.X || y != player.Y) && !enemies.Any(e => e.X == x && e.Y == y);

            } while (!isPositionValid);

            enemies.Add(new Enemy
            {
                X = x, 
                Y = y
            });
        }

        //This method handles attacks and checks whether we can attack an enemy given the range 
        private void HandleAttack(CharacterClass player, List<Enemy> enemies)
        {
            var targetsInRange = enemies.Where(e => Math.Abs(e.X - player.X) <= player.Range && Math.Abs(e.Y - player.Y) <= player.Range).ToList();

            if (!targetsInRange.Any())
            {
                Console.WriteLine("No available targets in your range.");
                return;
            }

            Console.WriteLine("Available targets:");
            for (int i = 0; i < targetsInRange.Count; i++)
            {
                Console.WriteLine($"{i}) Target({targetsInRange[i].X}, {targetsInRange[i].Y}) with remaining Health: {targetsInRange[i].Health}");
            }

            Console.Write("Which one to attack: ");
            int choice = ReadStatInput(targetsInRange.Count - 1);

            var target = targetsInRange[choice];
            target.Health -= player.Damage;
            Console.WriteLine($"You dealt {player.Damage} damage. Target's remaining Health: {target.Health}");

            if (target.Health <= 0)
            {
                Console.WriteLine("Target eliminated!");
                enemies.Remove(target);
                monsterKillCount++;
            }
        }
        //We move the player closer to the player
        private void UpdateEnemies(CharacterClass player, List<Enemy> enemies)
        {
            foreach (var enemy in enemies)
            {
                if (Math.Abs(enemy.X - player.X) <= 1 && Math.Abs(enemy.Y - player.Y) <= 1)
                {
                    Console.WriteLine($"Enemy attacks you for {enemy.Damage} damage!");
                    player.Health -= enemy.Damage;

                }
                else
                {
                    if (enemy.X < player.X)
                    {
                        enemy.X++;
                    }
                        
                    else if (enemy.X > player.X)
                    {
                        enemy.X--;
                    }

                    if (enemy.Y < player.Y)
                    {
                        enemy.Y++;
                    }
                    else if (enemy.Y > player.Y)
                    {
                        enemy.Y--;
                    }
                }
            }
        }
        //A method that saves the player character in the DB 
        private static void SaveCharacterInfo(CharacterClass playerCharacter)
        {
            using var context = new ConsoleRPGContext();
            var gameLog = new GameLog()
            {
                CharacterClass = playerCharacter.GetType().Name,
                Strength = playerCharacter.Strength,
                Agility = playerCharacter.Agility,
                Intelligence = playerCharacter.Intelligence,
                CreationTime = DateTime.Now
            };
            context.GameLogs.Add(gameLog);
            context.SaveChanges();
            
        }
        //An option to display all previous players from the DB before we start the game
        private void DisplayLogs()
        {
            using var context = new ConsoleRPGContext();
            var logs = context.GameLogs.ToList();
            Console.WriteLine("Saved Character Logs:");
            foreach (var log in logs)
            {
                Console.WriteLine($"ID: {log.Id}, Type: {log.CharacterClass}, Strength: {log.Strength}, Agility: {log.Agility}, Intelligence: {log.Intelligence}, Created On: {log.CreationTime}");
            }
        }
        //This saves the current session and references the character created in the DB
        private void SaveSession()
        {
            using var context = new ConsoleRPGContext();
            
            var session = new Session()
            {
                GameLogId = context.GameLogs.OrderByDescending(gl => gl.Id).First().Id, 
                MonsterKillCount = monsterKillCount
            };
            context.Sessions.Add(session);
            context.SaveChanges();
            Console.WriteLine($"Session saved. Total kills: {monsterKillCount}");
        }
    }
}
