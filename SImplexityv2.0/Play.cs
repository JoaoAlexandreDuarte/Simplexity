using System;

namespace SImplexityv2._0 {
    /// <summary>
    /// Runs the game with a 'do' 'While' cycle
    /// while also drawing the header
    /// </summary>
    public class Play {
        /* Properties that hold the number of 
         * max squares and circles per player.*/
        private static int P1Squares { get; set; } = 11;
        private static int P2Squares { get; set; } = 11;
        private static int P1Circles { get; set; } = 10;
        private static int P2Circles { get; set; } = 10;

        /// <summary>
        /// Method that creates and draws the world, and the player in it.
        /// </summary>
        public static void StartPlay() {
            World board = new World();
            int currentColumn = 3;
            string result = "";
            PlayerType player = PlayerType.One;
            PieceTypes currentPiece = PieceTypes.WhiteSquare;
            
            do {
                // Clear the board and redraw it with the new 'current' info.
                Console.Clear();
                DrawHeader(board, currentColumn, player, currentPiece);
                board.DrawBoard();
                // Get input from the user.
                // Left and right arrow keys can be used to move over one
                // column at a time.
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow && currentColumn > 0) {
                    currentColumn--;

                } else if (key.Key == ConsoleKey.RightArrow && currentColumn < 6) {
                    currentColumn++;
                  // Up or down to choose the form of the piece, as player one.
                } else if ((key.Key == ConsoleKey.UpArrow ||
                    key.Key == ConsoleKey.DownArrow) &&
                    player == PlayerType.One) {
                   
                    if (currentPiece == PieceTypes.WhiteCircle) {
                        currentPiece = PieceTypes.WhiteSquare;

                    } else if (currentPiece == PieceTypes.WhiteSquare) {
                        currentPiece = PieceTypes.WhiteCircle;
                    }
                 // Up or down to choose the form of the piece, as player two.
                } else if ((key.Key == ConsoleKey.UpArrow ||
                        key.Key == ConsoleKey.DownArrow) &&
                        player == PlayerType.Two) {
                    
                    if (currentPiece == PieceTypes.RedCircle) {
                        currentPiece = PieceTypes.RedSquare;

                    } else if (currentPiece == PieceTypes.RedSquare) {
                        currentPiece = PieceTypes.RedCircle;
                    }

                } else if (key.Key == ConsoleKey.Enter) {
                    // Pressing <Enter> will try to drop the chosen Piece into the current column.
                    if (board.CanAdd(currentColumn) && CheckPiece(currentPiece)) {
                        board.Add(currentColumn, currentPiece);
                        RemovePiece(currentPiece);
                        // Changes the player's turn.
                        if (player == PlayerType.One) {
                            player = PlayerType.Two;
                        } else {
                            player = PlayerType.One;
                        }
                    }
                    // Player one chooses the current piece between square and circle.
                    if (player == PlayerType.One) {
                        if (P1Squares > 0) {
                            currentPiece = PieceTypes.WhiteSquare;
                        } else {
                            currentPiece = PieceTypes.WhiteCircle;
                        }
                      // Player two chooses the current piece between square and circle.
                    } else if (player == PlayerType.Two) {
                        if (P1Squares > 0) {
                            currentPiece = PieceTypes.RedSquare;
                        } else {
                            currentPiece = PieceTypes.RedCircle;
                        }
                    }
                }

                if (P1Circles == 0 && P1Squares == 0 &&
                    P2Circles == 0 && P2Squares == 0) {
                    result = "It's a tie!";
                }

            } while (result == "");

            // Clears the Console
            Console.Clear();
            // Write the information about who won
            Console.WriteLine(result);
            // Ask's for an input return to the Menu
            Console.WriteLine("\nPress Any Key to Return to Menu...");
            Console.ReadKey();

            // Resets Values before returning to the Menu
            CheckWin.win = "";
            P1Circles = 10;
            P1Squares = 11;
            P2Circles = 10;
            P2Squares = 11;

            // Calls method 'DrawMenu()', to return to the Menu
            Menu.DrawMenu();
        }

        /// <summary>
        /// Check the current piece by its form,
        /// color, player and quantity, per turn.
        /// </summary>
        /// <param name="currentPiece">Currently selected piece</param>
        /// <returns></returns>
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
        /// It decrements the value of the 'current' piece.
        /// </summary>
        /// <param name="currentPiece">Currently selected piece</param>
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
        /// It draws the current number of pieces that each player has.
        /// It also draws the piece that the current player 'holds'.
        /// </summary>
        /// <param name="board">Reference of the object</param>
        /// <param name="currentColumn">Currently select column</param>
        /// <param name="player">Represents the player one or two</param>
        /// <param name="currentPiece">Currently selected piece</param>
        private static void DrawHeader(World board, int currentColumn,
            PlayerType player, PieceTypes currentPiece) {
            string piece = "";

            Console.WriteLine($"Player 1: \n\t{Menu.square}: {P1Squares}" +
                $"\n\t{Menu.ball}: {P1Circles}\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Player 2: \n\t{Menu.square}: {P2Squares}" +
                $"\n\t{Menu.ball}: {P2Circles}\n");

            // The player chooses the color of the pieces whether
            // it's a 'Square' or a 'Circle'.
            // Example: if chooses 'RedSquare' it will show a red square 
            // below the column wanted.
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
            // If full, it shows the string "x".
            } else {
                piece = "x";
            }

            // If the current player is 'One' print it current piece 'White' 
            // otherwise print 'Red'.
            Console.ForegroundColor = player == PlayerType.One ?
                ConsoleColor.White : ConsoleColor.Red;
            // Draws the pieces on top of the grid, 
            // according to the column the player chooses.
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
