using System;
using System.Threading;

namespace TicTacToe
{
    class Game
    {
        private Random RandomGen;
        private bool?[,] Board;
        private bool Running;
        private bool CurrentPlayer;
        
        public Game()
        {
            RandomGen = new Random();
            InitBoard();
            Running = false;
            CurrentPlayer = false; // false = cpu ; true = player
        }
       
        void InitBoard()
        {
            // create 3x3 grid and set all values to null
            Board = new bool?[3,3];
            for(int row = 0; row <= 2; row++)
            {
                for(int col = 0; col <= 2; col++)
                {
                    Board[row, col] = null;
                }
            }
        }

        public void Play()
        {
            Running = true;
            DisplayBoard();

            if(RandomGen.Next(2) > 0)
            {
                Console.WriteLine("\nPlayer Goes First\n");
                CurrentPlayer = true;
            }
            else
            {
                Console.WriteLine("\nComputer Goes First\n");
                CurrentPlayer = false;
            }

            while(Running)
            {
                if(CurrentPlayer)
                {
                    Console.WriteLine("\nPlayers Turn\n");
                    PlayerMove();
                }
                else
                {
                    Console.Write("\nComputers Turn\n\n\nThinking....");
                    Thread.Sleep(3000);
                    CpuMove();
                }

                DisplayBoard();
                CheckForWin();
                CurrentPlayer = !CurrentPlayer;
            }
        }

        void DisplayBoard()
        {
            int choice = 1;
            Console.Clear();
            Console.WriteLine();
            for(int row = 0; row <= 2; row++)
            {
                for(int col = 0; col <= 2; col++)
                {
                    switch (Board[row, col]) 
                    {
                        case true:
                            Console.Write("[X]");
                            break;
                        case false:
                            Console.Write("[O]");
                            break;
                        default:
                            Console.Write("[{0}]", choice);
                            break;
                    }
                    choice++;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        void PlayerMove()
        {
            int playerInput;
            do
            {
                Console.WriteLine();
                Console.Write("Select an open space (1-9): ");
                playerInput = ValidateInput(Console.ReadLine());
            }
            while(!MakeValidMove(playerInput));
        }

        void CpuMove()
        {
            int cpuMove;
            do
            {
                cpuMove = RandomGen.Next(1, 10);
            }
            while(!MakeValidMove(cpuMove));
        }

        int ValidateInput(string input)
        {
            int cleanInput;
            try
            {
                cleanInput = Convert.ToInt32(input);
            }
            catch
            {
                cleanInput = 0; // Zero is never a valid move in our game. Will trigger default case in MakeValidMove
            }
            return cleanInput;
        }

        bool MakeValidMove(int move)
        {
            bool isValid = false;
            switch(move)
            {
                case 1:
                    if(Board[0,0] == null)
                    {
                        isValid = true;
                        Board[0,0] = CurrentPlayer;
                    }
                    break;
                case 2:
                    if(Board[0,1] == null)
                    {
                        isValid = true;
                        Board[0,1] = CurrentPlayer;
                    }
                    break;
                case 3:
                    if(Board[0,2] == null)
                    {
                        isValid = true;
                        Board[0,2] = CurrentPlayer;
                    }
                    break;
                case 4:
                    if(Board[1,0] == null)
                    {
                        isValid = true;
                        Board[1,0] = CurrentPlayer;
                    }
                    break;
                case 5:
                    if(Board[1,1] == null)
                    {
                        isValid = true;
                        Board[1,1] = CurrentPlayer;
                    }
                    break;
                case 6:
                    if(Board[1,2] == null)
                    {
                        isValid = true;
                        Board[1,2] = CurrentPlayer;
                    }
                    break;
                case 7:
                    if(Board[2,0] == null)
                    {
                        isValid = true;
                        Board[2,0] = CurrentPlayer;
                    }
                    break;
                case 8:
                    if(Board[2,1] == null)
                    {
                        isValid = true;
                        Board[2,1] = CurrentPlayer;
                    }
                    break;
                case 9:
                    if(Board[2,2] == null)
                    {
                        isValid = true;
                        Board[2,2] = CurrentPlayer;
                    }
                    break;
                default:
                    isValid = false;
                    break;
            }
            return isValid;
        }

        void CheckForWin()
        {
            /*
             *   Brute force method. there are 8 possable winning combos
             *
             *   Winning Rows
             *   0,0  0,1  0,2
             *   1,0  1,1  1,2
             *   2,0  2,1  2,2
             *
             *   Winning Columns
             *   0,0  1,0  2,0
             *   0,1  1,1  2,1
             *   0,2  1,2  2,2
             *
             *   Winning Diagonals  
             *   0,0  1,1  2,2
             *   0,2  1,1  2,0
             */


            if(Board[0,0] == CurrentPlayer && Board[0,1] == CurrentPlayer && Board[0,2] == CurrentPlayer ||
               Board[1,0] == CurrentPlayer && Board[1,1] == CurrentPlayer && Board[1,2] == CurrentPlayer ||
               Board[2,0] == CurrentPlayer && Board[2,1] == CurrentPlayer && Board[2,2] == CurrentPlayer ||
               Board[0,0] == CurrentPlayer && Board[1,0] == CurrentPlayer && Board[2,0] == CurrentPlayer ||
               Board[0,1] == CurrentPlayer && Board[1,1] == CurrentPlayer && Board[2,1] == CurrentPlayer ||
               Board[0,2] == CurrentPlayer && Board[1,2] == CurrentPlayer && Board[2,2] == CurrentPlayer ||
               Board[0,0] == CurrentPlayer && Board[1,1] == CurrentPlayer && Board[2,2] == CurrentPlayer ||
               Board[0,2] == CurrentPlayer && Board[1,1] == CurrentPlayer && Board[2,0] == CurrentPlayer)
            {
                // Winner!
                Running = false;
                if(CurrentPlayer)
                {
                    // player
                    Console.WriteLine("\nYOU WIN!!!\n");
                }
                else
                {
                    // cpu
                    Console.WriteLine("\nYou Loose =[\n");
                }

            }
        }
        
    }
}
