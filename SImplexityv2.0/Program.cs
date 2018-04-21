using System;

namespace SImplexityv2._0 {
    class Program {
        static void Main(string[] args) {
            // Changes the Console encoding to be 'UTF8'
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Calls the 'DrawMenu()' Method from the 'Menu' Class
            Menu.DrawMenu();
        }
    }
}
