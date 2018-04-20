using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImplexityv2._0 {
    class Play {
        static int p1Squares = 11, p2Squares = 11;
        static int p1Circles = 10, p2Circles = 10;

        public static void startPlay() {
            World board = new World();
            int currentColumn = 3;
            PlayerType player = PlayerType.One;
            PieceTypes currentPiece = PieceTypes.WhiteSquare;

            bool trip = true;
            do {
                Console.Clear();
                // DrawHeader(board, currentColumn, player, currentPiece);
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
                    if (board.CanAdd(currentColumn)) {
                        board.Add(currentColumn, currentPiece);
                        if (player == PlayerType.One) {
                            player = PlayerType.Two;
                        } else {
                            player = PlayerType.One;
                        }
                    }
                }
            } while (trip);
        }
    }
}
