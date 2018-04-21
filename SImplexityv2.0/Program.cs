using System;

namespace SImplexityv2._0 {
    /// <summary>
    /// Used to start the program and to call the
    /// method 'DrawMenu()' in the 'Menu' Class
    /// </summary>
    public class Program {
        private static void Main(string[] args) {
            // Changes the Console encoding to be 'UTF8'
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Calls the 'DrawMenu()' Method from the 'Menu' Class
            Menu.DrawMenu();
        }
    }
}
