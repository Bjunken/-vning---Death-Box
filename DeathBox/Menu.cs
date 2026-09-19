using DeathBox;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;

namespace DeathBox
{
    internal class Menu
    {
        public bool errorMsg = false;
        public bool menu = false;
        public void mainMenu() {
            // Frontend box
            do {
                Console.WriteLine("╔════════════════════╗");
                Console.Write("║ ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Övning - Death Box");
                Console.ResetColor();
                Console.Write(" ║");
                Console.WriteLine("");
                Console.Write("║ ");
                Console.WriteLine(" >[1]   Login   <  ║");
                Console.Write("║ ");
                Console.WriteLine(" >[2]  Register <  ║");
                Console.Write("║ ");
                Console.WriteLine(" >[3]    Exit   <  ║");
                Console.WriteLine("╚════════════════════╝");
                Console.Write("Input: ");
                string userInput = Console.ReadLine();
                if (!int.TryParse(userInput, out int result) || (result > 3 || result < 1)) {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: ");
                    Console.ResetColor();
                    Console.WriteLine("Invalid input.");
                }
                // Menu logic
                switch (result) {
                    case 1:
                        Console.Clear();
                        loginMenu();
                        break;

                    case 2:
                        Console.Clear();
                        registerMenu();
                        break;

                    case 3:
                        menu = true;
                        break;
                }
            } while (!menu);
        }
        public void loginMenu() {
            // Frontend box
            Console.WriteLine("╔════════════════════╗");
            Console.Write("║ ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Övning - Death Box");
            Console.ResetColor();
            Console.Write(" ║");
            Console.WriteLine("");
            Console.Write("║ ");
            Console.WriteLine(" Username:         ║");
            Console.Write("║ ");
            Console.WriteLine(" Password:         ║");
            Console.Write("║ ");
            Console.WriteLine(" >[1]back          ║");
            Console.WriteLine("╚════════════════════╝");

            // Deserialize json filen
            string json = File.ReadAllText(Program.filePath);
            List<User> users = JsonSerializer.Deserialize<List<User>>(json);

            if (!errorMsg) {
                Console.SetCursorPosition(12, 2);
            }
            else {
                Console.SetCursorPosition(12, 3);
            }

            string username = Console.ReadLine();

            if (username == "1") {
                Console.Clear();
                return;
            }

            if (!errorMsg) {
                Console.SetCursorPosition(12, 3);
            }
            else {
                Console.SetCursorPosition(12, 4);
            }

            string password = Console.ReadLine();

            bool userFound = false;
            // login check
            User loggedInUser = null;
            foreach (User user in users) {
                if (user.Username == username && user.Password == password) {
                    userFound = true;
                    loggedInUser = user;
                    break;
                }
            }
            if (userFound) {
                Console.Clear();
                loggedIn(loggedInUser, users);
            } else {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: ");
                Console.ResetColor();
                Console.WriteLine("Invalid account details.");
                errorMsg = true;
                loginMenu();
                return;
            }
        }
        public void registerMenu() {
            // Frontend box
            Console.WriteLine("╔════════════════════╗");
            Console.Write("║ ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Övning - Death Box");
            Console.ResetColor();
            Console.Write(" ║");
            Console.WriteLine("");
            Console.Write("║ ");
            Console.WriteLine(" Username:         ║");
            Console.Write("║ ");
            Console.WriteLine(" Password:         ║");
            Console.Write("║ ");
            Console.WriteLine(" >[1]back          ║");
            Console.WriteLine("╚════════════════════╝");

            // Menu logic
            // Sets the correct writting position depending on if there is an error msg or not
            if (!errorMsg) {
                Console.SetCursorPosition(12, 2);
            } else {
                Console.SetCursorPosition(12, 3);
            }
            string username = Console.ReadLine();
            
            if (username == "1") {
                Console.Clear();
                return;
            }

            if (!errorMsg) {
                Console.SetCursorPosition(12, 3);
            }
            else {
                Console.SetCursorPosition(12, 4);
            }

            string password = Console.ReadLine();

            // Deserialize json filen
            string json = File.ReadAllText(Program.filePath);
            List<User> users = JsonSerializer.Deserialize<List<User>>(json);

            // Checking if user exists
            foreach (User user in users) {
                if (user.Username == username) {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: ");
                    Console.ResetColor();
                    Console.WriteLine("Username already exists.");
                    errorMsg = true;
                    registerMenu();
                    return;
                }
            }
            // Adds user
            User newUser = new User {
                Username = username,
                Password = password
            };

            users.Add(newUser);
            json = JsonSerializer.Serialize(users);
            File.WriteAllText(Program.filePath, json);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Account created!\n");
            Console.ResetColor();
        }
        public void loggedIn(User user, List<User> users) {
            bool menu = false;
            do {
                // if-statement for character check & frontend
                if (string.IsNullOrWhiteSpace(user.Class)) {
                    Console.WriteLine("╔════════════════════╗");
                    Console.Write("║ ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Övning - Death Box");
                    Console.ResetColor();
                    Console.Write(" ║");
                    Console.WriteLine("");
                    Console.Write("║ ");
                    Console.WriteLine(" >[1]Choose Class <║");
                    Console.Write("║ ");
                    Console.WriteLine(" >[2]   Exit      <║");
                    Console.Write("║ ");
                    Console.WriteLine("                   ║");
                    Console.WriteLine("╚════════════════════╝");
                } else {
                    Console.WriteLine("╔════════════════════╗ " + " ╔════════════════════╗");
                    Console.Write("║ ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Övning - Death Box");
                    Console.ResetColor();
                    Console.Write(" ║ " + " ║  > Player Stats <  ║");
                    Console.WriteLine("");
                    Console.Write("║ ");
                    Console.WriteLine(" >[1]Start Battle <║ " + " ║  >STR: " + user.Strength + "           ║");
                    Console.Write("║ ");
                    Console.WriteLine(" >[2]   Exit      <║ " + " ║  >AGI: " + user.Agility + "           ║");
                    Console.Write("║ ");
                    Console.WriteLine("                   ║ " + " ║  >INT: " + user.Intellect + "           ║");
                    Console.WriteLine("╚════════════════════╝ " + " ╚════════════════════╝");
                }

                Console.Write("Input: ");
                string userInput = Console.ReadLine();
                if (!int.TryParse(userInput, out int result) || (result > 2 || result < 1)) {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: ");
                    Console.ResetColor();
                    Console.WriteLine("Invalid input.");
                }
                // Menu logic
                switch (result) {
                    case 1:
                        if (string.IsNullOrWhiteSpace(user.Class)) {
                            Console.Clear();
                            chooseClass(user, users);
                            break;
                        }
                        Console.Clear();
                        startBattle(user);
                        break;

                    case 2:
                        Environment.Exit(0);
                        break;
                }
            } while (!menu);
        }
        public void chooseClass(User user, List<User> users) {
            // Frontend box
            do {
                Console.WriteLine("╔════════════════════╗");
                Console.Write("║ ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Övning - Death Box");
                Console.ResetColor();
                Console.Write(" ║");
                Console.WriteLine("");
                Console.Write("║ ");
                Console.WriteLine(" >[1]  Warrior  <  ║");
                Console.Write("║ ");
                Console.WriteLine(" >[2]  Ranger   <  ║");
                Console.Write("║ ");
                Console.WriteLine(" >[3]  Mage     <  ║");
                Console.Write("║ ");
                Console.WriteLine(" >[4]  Exit     <  ║");
                Console.WriteLine("╚════════════════════╝");
                Console.Write("Input: ");
                string userInput = Console.ReadLine();
                if (!int.TryParse(userInput, out int result) || (result > 4 || result < 1)) {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error: ");
                    Console.ResetColor();
                    Console.WriteLine("Invalid input.");
                }
                // Menu logic
                switch (result) {
                    case 1:
                        // Adds class / stats
                        user.Class = "Warrior";
                        user.Strength = 6;
                        user.Agility = 2;
                        user.Intellect = 1;

                        string json = JsonSerializer.Serialize(users);
                        File.WriteAllText(Program.filePath, json);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Class Picked!");
                        Console.ResetColor();
                        loggedIn(user, users);
                        break;

                    case 2:
                        Console.Clear();
                        // Adds class / stats
                        user.Class = "Ranger";
                        user.Strength = 2;
                        user.Agility = 6;
                        user.Intellect = 2;

                        json = JsonSerializer.Serialize(users);
                        File.WriteAllText(Program.filePath, json);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Class Picked!");
                        Console.ResetColor();
                        loggedIn(user, users);
                        break;

                    case 3:
                        Console.Clear();
                        // Adds class / stats
                        user.Class = "Mage";
                        user.Strength = 1;
                        user.Agility = 2;
                        user.Intellect = 8;

                        json = JsonSerializer.Serialize(users);
                        File.WriteAllText(Program.filePath, json);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Class Picked!");
                        Console.ResetColor();
                        loggedIn(user, users);
                        break;

                    case 4:
                        Environment.Exit(0);
                        break;
                }
            } while (!menu);
        }
        public void startBattle(User user) {
            combatLogic combat = new combatLogic();

            do {
                Console.Clear();

                Console.WriteLine("══════════════════════════════════════");
                Console.WriteLine("               Battle");
                Console.WriteLine("══════════════════════════════════════");

                // Show healthbars
                combat.playerHealthBar();
                combat.bossHealthBar();

                // 2,5 sec pause
                Thread.Sleep(2500);

                // player attack
                combat.playerAttack();
                combat.bossHealthBar();

                // 3 sec pause
                Thread.Sleep(3000);

                // Check if boss is dead
                if (combat.getBossHealth() <= 0) {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Boss has been defeated!");
                    Console.ResetColor();
                    Thread.Sleep(2500);
                    break;
                }

                // Boss attack
                Console.Clear();

                Console.WriteLine("══════════════════════════════════════");
                Console.WriteLine("               Battle");
                Console.WriteLine("══════════════════════════════════════");

                // Show healthbars
                combat.playerHealthBar();
                combat.bossHealthBar();

                // 2,5 sec pause
                Thread.Sleep(2500);

                combat.bossAttack();
                combat.playerHealthBar();

                // 3 sec pause
                Thread.Sleep(3000);

                if (combat.getPlayerHealth() <= 0) {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Player has been defeated!");
                    Console.ResetColor();
                    Thread.Sleep(3000);
                    Console.Clear();
                    break;
                }
            } while (combat.getPlayerHealth() > 0 && combat.getBossHealth() > 0);
        }
    }
}