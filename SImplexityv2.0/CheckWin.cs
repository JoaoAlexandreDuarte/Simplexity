using System;

namespace SImplexityv2._0 {
    /// <summary>
    /// Checks all wining conditions
    /// </summary>
    public class CheckWin {
        // String that takes in the information about who won
        public static string win = "";

        /// <summary>
        /// Verifies if the value of each piece is divisible by two,
        /// in order to determine its shape.
        /// </summary>
        /// <param name="currentPiece"></param>
        /// <returns></returns>
        private static string CheckShape(PieceTypes currentPiece) {
            string shape = "";
            if ((int)currentPiece % 2 == 0) {
                shape = "Square";
            } else if ((int)currentPiece % 2 != 0) {
                shape = "Circle";
            }
            return shape;
        }

        /// <summary>
        /// Verifies if the value of each piece is the same
        /// as the one on the 'enum', to determine its color.
        /// </summary>
        /// <param name="currentPiece"></param>
        /// <returns></returns>
        private static string CheckColor(PieceTypes currentPiece) {
            string color = "";
            if ((int)currentPiece == 0 || (int)currentPiece == 1) {
                color = "Red";
            } else if ((int)currentPiece == 2 || (int)currentPiece == 3) {
                color = "White";
            }
            return color;
        }
    }
}
