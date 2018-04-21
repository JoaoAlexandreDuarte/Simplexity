using System;

namespace SImplexityv2._0 {
    public class Play {
        private static int p1Squares = 11, p2Squares = 11;
        private static int p1Circles = 10, p2Circles = 10;

        public static void StartPlay() {
            World board = new World();
            int currentColumn = 3;
            PlayerType player = PlayerType.One;
            PieceTypes currentPiece = PieceTypes.WhiteSquare;

            bool trip = true;
            do {
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

                } else if ((key.Key == ConsoleKey.UpArrow ||
                    key.Key == ConsoleKey.DownArrow) &&
                    player == PlayerType.One) {

                    if (currentPiece == PieceTypes.WhiteCircle) {
                        currentPiece = PieceTypes.WhiteSquare;

                    } else if (currentPiece == PieceTypes.WhiteSquare) {
                        currentPiece = PieceTypes.WhiteCircle;
                    }

                } else if ((key.Key == ConsoleKey.UpArrow ||
                        key.Key == ConsoleKey.DownArrow) &&
                        player == PlayerType.Two) {

                    if (currentPiece == PieceTypes.RedCircle) {
                        currentPiece = PieceTypes.RedSquare;

                    } else if (currentPiece == PieceTypes.RedSquare) {
                        currentPiece = PieceTypes.RedCircle;
                    }

                } else if (key.Key == ConsoleKey.Enter) {
                    // Pressing <Enter> will try to drop the chosen Piece into the correct column.
                    if (board.CanAdd(currentColumn) && CheckPiece(currentPiece)) {
                        board.Add(currentColumn, currentPiece);
                        RemovePiece(currentPiece);
                        if (player == PlayerType.One) {
                            player = PlayerType.Two;
                        } else {
                            player = PlayerType.One;
                        }
                    }

                    if (player == PlayerType.One) {
                        if (p1Squares > 0) {
                            currentPiece = PieceTypes.WhiteSquare;
                        } else {
                            currentPiece = PieceTypes.WhiteCircle;
                        }
                    } else if (player == PlayerType.Two) {
                        if (p1Squares > 0) {
                            currentPiece = PieceTypes.RedSquare;
                        } else {
                            currentPiece = PieceTypes.RedCircle;
                        }
                    }
                }
            } while (trip);

            Console.Clear();
            DrawHeader(board, currentColumn, player, currentPiece);
            board.DrawBoard();
        }

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

        private static void DrawHeader(World board, int currentColumn,
            PlayerType player, PieceTypes currentPiece) {
            string piece = "";

            Console.WriteLine($"Player 1: \n\t{Menu.square}: {p1Squares}" +
                $"\n\t{Menu.ball}: {p1Circles}\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Player 2: \n\t{Menu.square}: {p2Squares}" +
                $"\n\t{Menu.ball}: {p2Circles}\n");

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

            }else {
                piece = "x";
            }

            Console.ForegroundColor = player == PlayerType.One ?
                ConsoleColor.White : ConsoleColor.Red;

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
