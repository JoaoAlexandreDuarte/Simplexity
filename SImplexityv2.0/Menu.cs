using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImplexityv2._0 {
    class Menu {
        /// <summary>
        /// Unicode of the ball and square used in this game
        /// </summary>
        public static string ball = "\u25CF";
        public static string square = "\u25A0";

        static void Choise(byte menuSel) {
            if (menuSel == 1) {
                //Play.startPlay();
            } else if (menuSel == 2) {
                DrawRules();
                DrawMenu();
            } else {
                DrawMenu();
            }
        }

        public static void DrawMenu() {
            byte menuSel;

            // Simple menu
            Console.Clear();
            Console.WriteLine("╔═══════════════════════╗");
            Console.WriteLine("║\tSimplexity\t║");
            Console.WriteLine("╠═══════════════════════╣");
            Console.WriteLine("║\t1 - Play\t║");
            Console.WriteLine("║\t2 - How to win\t║");
            Console.WriteLine("╚═══════════════════════╝");
            menuSel = Convert.ToByte(Console.ReadLine());

            Choise(menuSel);
        }

        static void DrawRules() {
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Red");
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
            Console.ReadKey();
        }
    }
}