using System;

namespace SImplexityv2._0 {
    /// <summary>
    /// Class of the pieces and its quantitys
    /// </summary>
    class Play {
        static int p1Squares = 11, p2Squares = 11;
        static int p1Circles = 10, p2Circles = 10;

        /// <summary>
        /// The game will start with the player one in the column 3
        /// </summary>
        public static void startPlay() {
            World board = new World();
            int currentColumn = 3;
            PlayerType player = PlayerType.One;
            PieceTypes currentPiece = PieceTypes.WhiteSquare;
            
            bool trip = true;
            do {
                // Clear the board and redraw it with the new 'current' info
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
                  // Up or down to choose the form of the piece 
                } else if ((key.Key == ConsoleKey.UpArrow ||
                    key.Key == ConsoleKey.DownArrow) &&
                    player == PlayerType.One) {
                    // as player one
                    if (currentPiece == PieceTypes.WhiteCircle) {
                        currentPiece = PieceTypes.WhiteSquare;

                    } else if (currentPiece == PieceTypes.WhiteSquare) {
                        currentPiece = PieceTypes.WhiteCircle;
                    }
                 // Up or down to choose the form of the piece
                }else if ((key.Key == ConsoleKey.UpArrow ||
                        key.Key == ConsoleKey.DownArrow) &&
                        player == PlayerType.Two) {
                    // as player two
                    if (currentPiece == PieceTypes.RedCircle) {
                        currentPiece = PieceTypes.RedSquare;

                    } else if (currentPiece == PieceTypes.RedSquare) {
                        currentPiece = PieceTypes.RedCircle;
                    }

                } else if (key.Key == ConsoleKey.Enter) {
                    // Pressing <Enter> will try to drop the chosen Piece into the correct column
                    if (board.CanAdd(currentColumn) && CheckPiece(currentPiece)) {
                        board.Add(currentColumn, currentPiece);
                        RemovePiece(currentPiece);
                        // Changes the player's turn
                        if (player == PlayerType.One) {
                            player = PlayerType.Two;
                        } else {
                            player = PlayerType.One;
                        }
                    }
                    // Player one choose the current piece between square and circle
                    if (player == PlayerType.One) {
                        if (p1Squares > 0) {
                            currentPiece = PieceTypes.WhiteSquare;
                        } else {
                            currentPiece = PieceTypes.WhiteCircle;
                        }
                      // Player two choose the current piece between square and circle
                    } else if (player == PlayerType.Two) {
                        if (p1Squares > 0) {
                            currentPiece = PieceTypes.RedSquare;
                        } else {
                            currentPiece = PieceTypes.RedCircle;
                        }
                    }
                }
            } while (trip);
            // Clear the board and redraw it with the new 'current' info
            Console.Clear();
            DrawHeader(board, currentColumn, player, currentPiece);
            board.DrawBoard();
        }

        /// <summary>
        /// Check the current piece by its form, color, player and quantity,
        /// per turn; if the piece exists, return true; 
        /// if it doesn't, return false
        /// </summary>
        /// <param name="currentPiece">To verify the game piece?????</param>
        /// <returns></returns>
        private static bool CheckPiece(PieceTypes currentPiece)
        {
            if (currentPiece == PieceTypes.RedSquare && (p2Squares > 0))
            {
                return true;
            } else if (currentPiece == PieceTypes.RedCircle && (p2Circles > 0))
            {
                return true;
            } else if (currentPiece == PieceTypes.WhiteSquare && (p1Squares > 0))
            {
                return true;
            } else if (currentPiece == PieceTypes.WhiteCircle && (p1Circles > 0))
            {
                return true;
            } else
            {
                return false;
            }
        }

        /// <summary>
        /// It decrements the value of the 'current' piece
        /// </summary>
        /// <param name="currentPiece"> variable that possesses the info about the piece that tha player is 'holding' </param>
        private static void RemovePiece(PieceTypes currentPiece) {
            if (currentPiece == PieceTypes.RedSquare)
            {
                p2Squares--;
            }
            else if (currentPiece == PieceTypes.RedCircle)
            {
                p2Circles--;
            }
            else if (currentPiece == PieceTypes.WhiteSquare)
            {
                p1Squares--;
            }
            else if (currentPiece == PieceTypes.WhiteCircle)
            {
                p1Circles--;
            }
        }

        /// <summary>
        /// It draws the current number of pieces that each player has
        /// It also draws the piece that the current player 'holds'
        /// </summary>
        /// <param name="board">Reference of the object</param>
        /// <param name="currentColumn">Currently select column</param>
        /// <param name="player">Represents the player one or two</param>
        /// <param name="currentPiece">Currently select piece</param>
        private static void DrawHeader(World board, int currentColumn,
            PlayerType player, PieceTypes currentPiece) {
            string piece = "";

            Console.WriteLine($"Player 1: \n\t{Menu.square}: {p1Squares}" +
                $"\n\t{Menu.ball}: {p1Circles}\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Player 2: \n\t{Menu.square}: {p2Squares}" +
                $"\n\t{Menu.ball}: {p2Circles}\n");

            // The player chooses the color of the pieces whether 
            // it's a 'Square' or a 'Circle'
            // example: if chooses 'RedSquare' it will show a red square 
            // below the column wanted
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
            // If full, it shows the string "x"
            }else {
                piece = "x";
            }

            // If the current player is 'One' print it current piece 'White' 
            // otherwise print 'Red'
            Console.ForegroundColor = player == PlayerType.One ?
                ConsoleColor.White : ConsoleColor.Red;
            // Draws the pieces on top of the grid, 
            // according to the column the player chooses
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
