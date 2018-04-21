using System;

namespace SImplexityv2._0 {
    /// <summary>
    /// Checks all wining conditions
    /// </summary>
    public class CheckWin {
        // String that takes in the information about who won
        public static string win = "";

        // Check shape in horizontal.
        public static string CheckHorizontal(PieceTypes[,] grid)
        {
            int piecesInRow = 0;
            string shape = "";
            string color = "";

            // Check shape in horizontal.
            for (int i = 6; i >= 0; i--)
            {
                for (int j = 6; j > 0; j--)
                {
                    piecesInRow++;
                    shape = CheckShape(grid[i, j]);
                    if (grid[j, i] == PieceTypes.Bar || grid[i, j - 1] == PieceTypes.Bar)
                    {
                        piecesInRow = 0;
                    }
                    else if (shape != CheckShape(grid[i, j - 1]))
                    {
                        piecesInRow = 0;

                    }
                    if (piecesInRow == 3)
                    {
                        win = shape == "Square" ? "Player 2 Wins!" : "Player 1 Wins!";
                        return win;
                    }
                }

            }

            // Check color in horizontal.
            for (int i = 6; i >= 0; i--)
            {
                for (int j = 6; j > 0; j--)
                {
                    piecesInRow++;
                    color = CheckColor(grid[i, j]);
                    if (grid[j, i] == PieceTypes.Bar || grid[i, j - 1] == PieceTypes.Bar)
                    {
                        piecesInRow = 0;
                    }
                    else if (color != CheckColor(grid[i, j - 1]))
                    {
                        piecesInRow = 0;

                    }
                    if (piecesInRow == 3)
                    {
                        win = color == "Red" ? "Player 2 Wins!" : "Player 1 Wins!";
                        return win;
                    }
                }

            }
            return win;
        }

        /// <summary>
        /// Verifies if the value of each piece is divisible by two,
        /// in order to determine its shape.
        /// </summary>
        /// <param name="currentPiece"></param>
        /// <returns></returns>
        private static string CheckShape(PieceTypes currentPiece)
        {
            string shape = "";
            if ((int)currentPiece % 2 == 0)
            {
                shape = "Square";
            }
            else if ((int)currentPiece % 2 != 0)
            {
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
