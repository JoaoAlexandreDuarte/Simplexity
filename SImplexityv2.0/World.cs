using System;

namespace SImplexityv2._0 {
    /// <summary>
    /// Manages and draws the world grid, keeping
    /// everything in place and checking if any columns
    /// are full
    /// </summary>
    public class World {

        /// <summary>
        /// The number of rows and Columns in the grid.
        /// </summary>
        private static readonly int Rows = 7;
        private static readonly int Columns = 7;

        /// <summary>
        /// Stores the contents of the grid.
        /// </summary>
        private PieceTypes[,] grid;

        /// <summary>
        /// Creates a empty board.
        /// </summary>
        public World() {
            grid = new PieceTypes[Rows, Columns];

            PopulateEmptyGrid();

        }

        /// <summary>
        /// Fill the grid with "|".
        /// </summary>
        private void PopulateEmptyGrid() {
            // Runs the array filling each 'cell' with a 'PiceType.Bar'
            for (int row = 0; row < Rows; row++) {
                for (int column = 0; column < Columns; column++) {
                    grid[row, column] = PieceTypes.Bar;
                }
            }
        }

        /// <summary>
        /// Adds the chosen Piece to the chosen Column.
        /// </summary>
        /// <param name="column">Number of the selected column</param>
        /// <param name="currentPiece">Currently selected piece</param>
        public void Add(int column, PieceTypes currentPiece) {
            // Check if the chosen column is full.
            if (!CanAdd(column)) { return; }

            /* Starting at the top, move down to check for the correct position
             * to assign the chosen Piece. */
            int currentRow = 0;
            while (currentRow < Rows - 1 &&
                grid[currentRow + 1, column] == PieceTypes.Bar) {
                currentRow++;
            }

            // Place the chosen piece when it gets to the right Row.
            grid[currentRow, column] = currentPiece;
        }

        /// <summary>
        /// Checks if the chosen piece can be added to the chosen Row.
        /// </summary>
        /// <param name="column">Number of the selected column</param>
        /// <returns>True or False, depending on the state of the column</returns>
        public bool CanAdd(int column) {
            if (grid[0, column] == PieceTypes.Bar) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// Checks all winning conditions to determine if anyone won
        /// and if so who won.
        /// </summary>
        /// <param name="result">Stores the information about who won</param>
        /// <returns>Winning condition</returns>
        public string Win(string result) {
            result = CheckWin.CheckHorizontal(grid, result);
            result = CheckWin.CheckVertical(grid, result);
            result = CheckWin.CheckDiagonalLeft(grid, result);
            result = CheckWin.CheckDiagonalRight(grid, result);
            return result;
        }

        /// <summary>
        /// Draws the complete Board to the console.
        /// </summary>
        public void DrawBoard() {
            // Runs the array
            for (int row = 0; row < Rows; row++) {
                Console.Write("  ");
                for (int column = 0; column < Columns; column++) {
                    PieceTypes type = grid[row, column];

                    /* Check what type of pice is contained on that "cell" to draw
                     * the corresponding piece on to the console*/
                    switch (type) {
                        case PieceTypes.Bar:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(" | ");
                            break;
                        case PieceTypes.RedSquare:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($" {Menu.square} ");
                            break;
                        case PieceTypes.RedCircle:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($" {Menu.ball} ");
                            break;
                        case PieceTypes.WhiteCircle:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write($" {Menu.ball} ");
                            break;
                        case PieceTypes.WhiteSquare:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write($" {Menu.square} ");
                            break;
                    }
                }
                // Switch Line after completing each Row
                Console.WriteLine("");
            }
            // Draw the base line.
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  ---------------------");
        }
    }
}