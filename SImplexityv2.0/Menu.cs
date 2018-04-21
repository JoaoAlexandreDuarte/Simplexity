using System;

namespace SImplexityv2._0 {
    public class Menu {
        /// <summary>
        /// Unicode of the ball and square used in this game
        /// </summary>
        public static string ball = "\u25CF";
        public static string square = "\u25A0";

        /// <summary>
        /// Check what option the user chose
        /// </summary>
        /// <param name="menuSel">Contains the user input value</param>
        private static void Choice(string menuSel) {
            // Asks if the user selected the first option
            if (menuSel == "1") {
                /* If the player selected option 1 calls the 'startPlay()' 
                 * Method from the 'Play' Class */
                Play.StartPlay();

            // Asks if the user selected the second option
            } else if (menuSel == "2") {
                // If the player selected option 2 calls the 'DrawRules()' Method
                DrawRules();
                /* When the Method 'DrawRules()' finishes, calls 'DrawMenu()'
                 * to display the Menu again */
                DrawMenu();

            // If nothing was selected, prints the menu again on to the Console
            } else {
                DrawMenu();
            }
        }


        /// <summary>
        /// Displays a small choice menu on the console
        /// </summary>
        public static void DrawMenu() {
            // Saves the user input value.
            string menuSel;

            // Clears the console to write a simple menu.
            Console.Clear();
            Console.WriteLine("╔═══════════════════════╗");
            Console.WriteLine("║\tSimplexity\t║");
            Console.WriteLine("╠═══════════════════════╣");
            Console.WriteLine("║\t1 - Play\t║");
            Console.WriteLine("║\t2 - How to win\t║");
            Console.WriteLine("╚═══════════════════════╝");

            // Saves the user input to the 'menuSel' byte.
            menuSel = Console.ReadLine();

            // Calls the 'Choise()' Method.
            Choice(menuSel);
        }


        /// <summary>
        /// Displays a table containing information about the game.
        /// </summary>
        private static void DrawRules() {
            // Clears the console
            Console.Clear();

            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║         Win Conditions        ║");
            Console.WriteLine("╚═══════════════════════════════╝\n");
            Console.WriteLine("╔════════╦═══════════╦═══════════╗");
            Console.WriteLine("║ Player ║ Win Color ║ Win Piece ║");
            Console.WriteLine("╠════════╬═══════════╬═══════════╣");
            Console.WriteLine("║ 1      ║ White     ║ Cilinder  ║");
            Console.WriteLine("╠════════╬═══════════╬═══════════╣");
            Console.WriteLine("║ 2      ║ Red       ║ Square    ║");
            Console.WriteLine("╚════════╩═══════════╩═══════════╝\n\n");
            Console.WriteLine("╔══════════════════════════════╗");
            Console.WriteLine("║             Help             ║");
            Console.WriteLine("╚══════════════════════════════╝\n");
            Console.WriteLine("╔════════╦══════════╦══════════╗");
            Console.WriteLine("║        ║  Circle  ║  Square  ║");
            Console.WriteLine("╠════════╬══════════╬══════════╣");
            Console.WriteLine($"║ White  ║  {ball}       ║  {square}       ║");
            Console.WriteLine("╠════════╬══════════╬══════════╣");
            Console.Write("║ ");
            // Changes the Foreground Color on the Console to red.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Red");
            // Resets the Console colors.
            Console.ResetColor();
            Console.Write("    ║  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(ball);
            Console.ResetColor();
            Console.Write("       ║  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(square);
            Console.ResetColor();
            Console.WriteLine("       ║");
            Console.WriteLine("╚════════╩══════════╩══════════╝");
            // Waits for a user input to return to the menu.
            Console.ReadKey();
        }
    }
}