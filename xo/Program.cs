using System;

namespace xo
{
    class Program
    {
        public static char playerSignature = ' ';

        static int turns = 0;

        static char[] OnBoard =
        {
            '1', '2', '3','4', '5', '6','7', '8', '9'
        };



        public static void BoardReset()
        {
            char[] OnBoardInitialize =
            {
                '1', '2', '3','4', '5', '6','7', '8', '9'
            };

            OnBoard = OnBoardInitialize;
            DrawBoard();
            turns = 0;
        }

        public static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine("  -------------------------");
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", OnBoard[0], OnBoard[1], OnBoard[2]);
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  -------------------------");
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", OnBoard[3], OnBoard[4], OnBoard[5]);
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  -------------------------");
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", OnBoard[6], OnBoard[7], OnBoard[8]);
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  -------------------------");
        } //Draws the player board to terminal.  

        public static void Introduction()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("xxx      xxx        ooo            ");
            Console.WriteLine("  xxx  xxx      ooo     ooo        ");
            Console.WriteLine("    xxx        ooo       ooo       ");
            Console.WriteLine("  xxx  xxx      ooo     ooo        ");
            Console.WriteLine("xxx      xxx        ooo        GAME    ");

            Console.WriteLine("\nWelcome to XO GAME");

            Console.ResetColor();
            Console.Write("\nPlease press any to begin...");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("RULES");
            Console.ResetColor();
            Console.WriteLine("XO Game is a two player");
            Console.WriteLine(" ___________________________"
                            + "\n|                           |"
                            + "\n|It is you vs your opponent.|"
                            + "\n|___________________________|"
                            );
            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("RULES");
            Console.ResetColor();
            Console.WriteLine("Players are represented with a unique signature");
            Console.WriteLine(" _____________________________"
                                + "\n|                             |"
                                + "\n| Player 1 = O.  Player 2 = X |"
                                + "\n|_____________________________|"
                                );
            Console.WriteLine("\nThe first player to score three signatures in a row is the winner");
            Console.Write("\nNow press any key to begin...");
            Console.ReadKey();
        }


        static void Main(string[] args)
        {
            int player = 2;
            int input = 0;
            bool inputCorrect = true;

            Introduction();


            do
            {
                if (player == 2)
                {
                    player = 1;
                    XorO(player, input);
                }
                else if (player == 1)
                {
                    player = 2;
                    XorO(player, input);
                }

                DrawBoard();
                turns++;

                //Check Game Status.
                HorizontalWin();
                VerticalWin();
                DiagonalWin();

                if (turns == 10)
                {
                    Draw();
                }

                do
                {
                    Console.WriteLine("\nReady Player {0}: It's your move!", player);
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a number!");
                    }

                    if ((input == 1) && (OnBoard[0] == '1'))
                        inputCorrect = true;
                    else if ((input == 2) && (OnBoard[1] == '2'))
                        inputCorrect = true;
                    else if ((input == 3) && (OnBoard[2] == '3'))
                        inputCorrect = true;
                    else if ((input == 4) && (OnBoard[3] == '4'))
                        inputCorrect = true;
                    else if ((input == 5) && (OnBoard[4] == '5'))
                        inputCorrect = true;
                    else if ((input == 6) && (OnBoard[5] == '6'))
                        inputCorrect = true;
                    else if ((input == 7) && (OnBoard[6] == '7'))
                        inputCorrect = true;
                    else if ((input == 8) && (OnBoard[7] == '8'))
                        inputCorrect = true;
                    else if ((input == 9) && (OnBoard[8] == '9'))
                        inputCorrect = true;
                    else
                    {
                        Console.WriteLine("Whoops, I didn't get that.  \nPlease try again...");
                        inputCorrect = false;
                    }


                } while (!inputCorrect);
            } while (true);

        }



        public static void XorO(int player, int input)
        {

            if (player == 1) playerSignature = 'X';
            else if (player == 2) playerSignature = 'O';

            switch (input)
            {
                case 1: OnBoard[0] = playerSignature; break;
                case 2: OnBoard[1] = playerSignature; break;
                case 3: OnBoard[2] = playerSignature; break;
                case 4: OnBoard[3] = playerSignature; break;
                case 5: OnBoard[4] = playerSignature; break;
                case 6: OnBoard[5] = playerSignature; break;
                case 7: OnBoard[6] = playerSignature; break;
                case 8: OnBoard[7] = playerSignature; break;
                case 9: OnBoard[8] = playerSignature; break;
            }

        }


        public static void HorizontalWin()
        {
            char[] playerSignatures = { 'X', 'O' };

            foreach (char playerSignatue in playerSignatures)
            {
                if (((OnBoard[0] == playerSignatue) && (OnBoard[1] == playerSignatue) && (OnBoard[2] == playerSignatue))
                    || ((OnBoard[3] == playerSignatue) && (OnBoard[4] == playerSignatue) && (OnBoard[5] == playerSignatue))
                    || ((OnBoard[6] == playerSignatue) && (OnBoard[7] == playerSignatue) && (OnBoard[8] == playerSignatue)))
                {
                    Console.Clear();
                    if (playerSignatue == 'X')
                    {
                        Console.WriteLine("Congratulations Player 1.\nYou have a achieved a horizontal win! " +
                                          "\nYou're the XO Master!" +
                                          "\nTurns taken{0}" + "bot'sHorizontalWin", turns);
                    }
                    else if (playerSignatue == 'O')
                    {
                        Console.WriteLine("Congratulations Player 2.\nYou have a achieved a horizontal win! " +
                                          "\nYou're the XO Master!" +
                                          "\nTurns taken{0}" + "You'reHorizontalWin", turns);
                    }


                    WinArt();
                    Console.WriteLine("\nPlease press any key to reset the game...");
                    Console.ReadKey();
                    BoardReset();

                    break;
                }
            }
        } //ชนะแนวนอน 


        public static void VerticalWin()
        {
            char[] playerSignatures = { 'X', 'O' };

            foreach (char playerSignatue in playerSignatures)
            {
                if (((OnBoard[0] == playerSignatue) && (OnBoard[3] == playerSignatue) && (OnBoard[6] == playerSignatue))
                    || ((OnBoard[1] == playerSignatue) && (OnBoard[4] == playerSignatue) && (OnBoard[7] == playerSignatue))
                    || ((OnBoard[2] == playerSignatue) && (OnBoard[5] == playerSignatue) && (OnBoard[8] == playerSignatue)))
                {
                    Console.Clear();
                    if (playerSignatue == 'X')
                    {
                        Console.WriteLine("Player 1, that was Fantastic.\nA vertical win!\nYou're the XO Master!" + "bot'sVerticalWin");
                    }
                    else
                    {
                        Console.WriteLine("Player 2, that was Fantastic.\nA vertical win!\nYou're the XO Master!" + "you'reVerticalWin");
                    }

                    WinArt();
                    Console.WriteLine("\nPlease press any key to reset the game...");
                    Console.ReadKey();
                    BoardReset();

                    break;
                }
            }
        } //ชนะแนวตั้ง  

        public static void DiagonalWin()
        {
            char[] playerSignatures = { 'X', 'O' };

            foreach (char playerSignatue in playerSignatures)
            {
                if (((OnBoard[0] == playerSignatue) && (OnBoard[4] == playerSignatue) && (OnBoard[8] == playerSignatue))
                    || ((OnBoard[6] == playerSignatue) && (OnBoard[4] == playerSignatue) && (OnBoard[2] == playerSignatue)))
                {
                    Console.Clear();
                    if (playerSignatue == 'X')
                    {
                        Console.WriteLine("WOW!, player 1 that's a diagonal win! " +
                                          "\nExcellently played, it's one for the ages! " +
                                          "\nYou're the XO Legend!" + "botDiagonalWin");
                    }
                    else
                    {
                        Console.WriteLine("WOW!, player 2 that's a diagonal win! " +
                                          "\nExcellently played, it's one for the ages! " +
                                          "\nYou're the XO Legend!" + "ํYouDiagonalWin");
                    }

                    WinArt();
                    Console.WriteLine("\nPlease press any key to reset the game...");
                    Console.ReadKey();
                    BoardReset();

                    break;
                }
            }
        }  //ชนะในแนวทแยง
        public static void Draw()
        {

            {
                Console.WriteLine("Aw gosh... it's a draw." +
                                  "\nPlease press any key to reset the game and try again!...");
                Console.ReadKey();
                BoardReset();

            }
        } //Method is called to check if the game is a draw.

        public static void WinArt()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" _____________________________"
                                + "\n|                             |"
                                + "\n|            VICTORY          |"
                                + "\n|_____________________________|"
                                );

            Console.ResetColor();
        } //ASCII Art setup in it's own method to help keep the code tidy.  
    }
}
