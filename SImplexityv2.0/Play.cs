using System;

namespace SImplexityv2._0 {
    /// <summary>
    /// Runs the game with a 'do' 'While' cycle
    /// while also drawing the header.
    /// </summary>
    public class Play {
        /* Properties that hold the number of 
         * max squares and circles per player.*/
        private static int P1Squares { get; set; } = 11;
        private static int P2Squares { get; set; } = 11;
        private static int P1Circles { get; set; } = 10;
        private static int P2Circles { get; set; } = 10;

        /// <summary>
        /// Method that creates the object board, and runs the game on a while cycle.
        /// </summary>
        public static void StartPlay() {
            //  Create a board.
            World board = new World();
            // Default value of the selected column to start at the middle.
            int currentColumn = 3;
            // 'result' will recive the winning condition.
            string result = "";
            // Stores the information on what player's turn it is.
            PlayerType player = PlayerType.One;
            // Stores the information on what piece is currently selected.
            PieceTypes currentPiece = PieceTypes.WhiteSquare;
            
            // Start a Do-While cycle.
            do {
                // Clear the board and redraw it with the new 'current' info.
                Console.Clear();
                // Call the 'DrawHeader' Method to draw the header.
                DrawHeader(board, currentColumn, player, currentPiece);
                // Call the 'DrawBoard' Method to draw the board.
                board.DrawBoard();

                // Get input from the user.
                ConsoleKeyInfo key = Console.ReadKey();
                /* Left and right arrow keys can be used to move over one
                 * column at a time.*/
                if (key.Key == ConsoleKey.LeftArrow && currentColumn > 0) {
                    currentColumn--;

                } else if (key.Key == ConsoleKey.RightArrow && currentColumn < 6) {
                    currentColumn++;
                  /* Up and Down arrows can be used to select between the diferent
                   * pieces depending on witch player's turn it is.*/
                } else if ((key.Key == ConsoleKey.UpArrow ||
                    key.Key == ConsoleKey.DownArrow) &&
                    player == PlayerType.One) {
                    // Up or down to choose the pieces form, as player one.
                    if (currentPiece == PieceTypes.WhiteCircle) {
                        currentPiece = PieceTypes.WhiteSquare;
                    } else if (currentPiece == PieceTypes.WhiteSquare) {
                        currentPiece = PieceTypes.WhiteCircle;
                    }

                /* Up and Down arrows can be used to select between the diferent
                 * pieces depending on witch player's turn it is*/
                } else if ((key.Key == ConsoleKey.UpArrow ||
                        key.Key == ConsoleKey.DownArrow) &&
                        player == PlayerType.Two) {
                    // Up or down to choose the pieces form, as player two.
                    if (currentPiece == PieceTypes.RedCircle) {
                        currentPiece = PieceTypes.RedSquare;
                    } else if (currentPiece == PieceTypes.RedSquare) {
                        currentPiece = PieceTypes.RedCircle;
                    }
                /* When the 'Enter' key is pressed we will verify everything
                 * to make sure, that the chosen piece can be played.*/
                } else if (key.Key == ConsoleKey.Enter) {
                    /* Ask if the selected column is not full and if the player still has
                     * the selected piece available to play.*/
                    if (board.CanAdd(currentColumn) && CheckPiece(currentPiece)) {
                        // Adds the selected pice to the right 'cell' on the array.
                        board.Add(currentColumn, currentPiece);
                        // Decreases the piece counter.
                        RemovePiece(currentPiece);
                        // Checks for a winning condition
                        result = board.Win(result);
                        // Changes the player's turn.
                        if (player == PlayerType.One) {
                            player = PlayerType.Two;
                        } else {
                            player = PlayerType.One;
                        }
                    }

                    /* Automatically switches the default player 1 piece in case he doesn't have
                     * a square or circle available to play anymore. */
                    if (player == PlayerType.One) {
                        if (P1Squares > 0) {
                            currentPiece = PieceTypes.WhiteSquare;
                        } else {
                            currentPiece = PieceTypes.WhiteCircle;
                        }
                        /* Automatically switches the default player 2 piece in case he doesn't have
                         * a square or circle available to play anymore. */
                    } else if (player == PlayerType.Two) {
                        if (P1Squares > 0) {
                            currentPiece = PieceTypes.RedSquare;
                        } else {
                            currentPiece = PieceTypes.RedCircle;
                        }
                    }
                }

                /* If both players run out of pieces then the winning condition
                 * becomes a Tie.*/
                if (P1Circles == 0 && P1Squares == 0 &&
                    P2Circles == 0 && P2Squares == 0 &&
                    result == "") {
                    result = "It's a tie!";
                }
            // Runs the Do-While cycle while there is no winning condition.
            } while (result == "");

            // Clears the Console.
            Console.Clear();
            // Write the information about who won.
            Console.WriteLine(result);
            // Asks for an input return to the Menu.
            Console.WriteLine("\nPress Any Key to Return to Menu...");
            Console.ReadKey();

            // Resets all necessary values before returning to the Menu.
            P1Circles = 10;
            P1Squares = 11;
            P2Circles = 10;
            P2Squares = 11;

            // Calls method 'DrawMenu()', to return to the Menu.
            Menu.DrawMenu();
        }

        /// <summary>
        /// Check if the player's selected piece is still available to be played.
        /// </summary>
        /// <param name="currentPiece">Currently selected piece.</param>
        /// <returns>True of False depending on whether or not the player still
        ///  has pieces left to play.</returns>
        private static bool CheckPiece(PieceTypes currentPiece)
        {
            if (currentPiece == PieceTypes.RedSquare && (P2Squares > 0))
            {
                return true;
            } else if (currentPiece == PieceTypes.RedCircle && (P2Circles > 0))
            {
                return true;
            } else if (currentPiece == PieceTypes.WhiteSquare && (P1Squares > 0))
            {
                return true;
            } else if (currentPiece == PieceTypes.WhiteCircle && (P1Circles > 0))
            {
                return true;
            } else
            {
                return false;
            }
        }

        /// <summary>
        /// Decrements the value of the 'current' piece.
        /// </summary>
        /// <param name="currentPiece">Currently selected piece.</param>
        private static void RemovePiece(PieceTypes currentPiece) {
            if (currentPiece == PieceTypes.RedSquare)
            {
                P2Squares--;
            }
            else if (currentPiece == PieceTypes.RedCircle)
            {
                P2Circles--;
            }
            else if (currentPiece == PieceTypes.WhiteSquare)
            {
                P1Squares--;
            }
            else if (currentPiece == PieceTypes.WhiteCircle)
            {
                P1Circles--;
            }
        }

        /// <summary>
        /// Draws the current number of pieces that each player has.
        /// Also draws the piece that the current player 'holds'.
        /// </summary>
        /// <param name="board">Reference of the object.</param>
        /// <param name="currentColumn">Currently select column.</param>
        /// <param name="player">Represents the player one/two.</param>
        /// <param name="currentPiece">Currently selected piece.</param>
        private static void DrawHeader(World board, int currentColumn,
            PlayerType player, PieceTypes currentPiece) {
            string piece = "";

            Console.WriteLine($"Player 1: \n\t{Menu.square}: {P1Squares}" +
                $"\n\t{Menu.ball}: {P1Circles}\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Player 2: \n\t{Menu.square}: {P2Squares}" +
                $"\n\t{Menu.ball}: {P2Circles}\n");

            /* The player chooses the shape of the pieces whether
             * it's a 'Square' or a 'Circle'.
             * Example: If he chooses 'RedSquare' it will show a red square 
             * on top of the column selected.*/
            if (board.CanAdd(currentColumn) && CheckPiece(currentPiece))
            {
                if (currentPiece == PieceTypes.RedSquare ||
                    currentPiece == PieceTypes.WhiteSquare)
                {
                    piece = Menu.square;
                }
                else if (currentPiece == PieceTypes.RedCircle ||
                   currentPiece == PieceTypes.WhiteCircle)
                {
                    piece = Menu.ball;
                }
            // If the selected column is full, prints the string "x".
            } else {
                piece = "x";
            }

            /* If the current player is 'One' 
             * print the current piece as 'White'.
             * Otherwise print the current piece as 'Red'.*/
            Console.ForegroundColor = player == PlayerType.One ?
                ConsoleColor.White : ConsoleColor.Red;
            /* Draws the pieces on top of the grid, 
             * according to the column selected by the player.*/
            Console.WriteLine("   {0}  {1}  {2}  {3}  {4}  {5}  {6}",
                currentColumn == 0 ? piece : " ",
                currentColumn == 1 ? piece : " ",
                currentColumn == 2 ? piece : " ",
                currentColumn == 3 ? piece : " ",
                currentColumn == 4 ? piece : " ",
                currentColumn == 5 ? piece : " ",
                currentColumn == 6 ? piece : " ");
        }
    }
}
