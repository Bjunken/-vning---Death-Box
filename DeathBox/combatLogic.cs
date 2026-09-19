using System;
using System.Collections.Generic;
using System.Text;

namespace DeathBox {
    internal class combatLogic {
        private int playerHealth = 100;
        private int bossHealth = 100;
        private Random random = new Random();
        public void playerHealthBar() {
            int healthBlocks = playerHealth / 5;
            int lostHealthBlocks = 20 - healthBlocks;

            Console.Write("Player Health: [");

            for (int i = 0; i < healthBlocks; i++) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("█");
                Console.ResetColor();
             }

            for (int i = 0; i < lostHealthBlocks; i++) {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("█");
                Console.ResetColor();
             }

             Console.WriteLine("] " + playerHealth + "/100");
            }
        public void bossHealthBar() {
            int bossHealthBlocks = bossHealth / 5;
            int bossLostHealthBlocks = 20 - bossHealthBlocks;

            Console.Write("Boss Health:   [");

            for (int i = 0; i < bossHealthBlocks; i++) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("█");
                Console.ResetColor();
            }

            for (int i = 0; i < bossLostHealthBlocks; i++) {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("█");
                Console.ResetColor();
            }

            Console.WriteLine("] " + bossHealth + "/100");
        }
        public void playerAttack() {
            int playerDamage = random.Next(1, 21);
            Console.WriteLine();
            Console.WriteLine("Player Attacks!");
            Console.WriteLine("Player deals " + playerDamage + " damage!");

            bossHealth -= playerDamage;

            if (bossHealth < 0) {
                bossHealth = 0;
            }
        }
        public void bossAttack() {
            int attack = random.Next(1, 4);
            int bossDamage = 0;
            string attackName = "";

            switch (attack) {
                case 1:
                    attackName = "Claw Attack";
                    bossDamage = random.Next(6, 21);
                    break;

                case 2:
                    attackName = "Tail Swipe";
                    bossDamage = random.Next(9, 29);
                    break;

                case 3:
                    attackName = "Bite";
                    bossDamage = random.Next(11, 31);
                    break;
            }

            Console.WriteLine();
            Console.Write("Boss used ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(attackName);
            Console.ResetColor();
            Console.Write(". You take ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(bossDamage);
            Console.ResetColor();
            Console.Write(" damage!");
            Console.WriteLine();

            playerHealth -= bossDamage;

            if (playerHealth < 0) {
                playerHealth = 0;
            }
        }
        public int getPlayerHealth() {
            return playerHealth;
        }
        public int getBossHealth() {
            return bossHealth;
        }

    }
}
