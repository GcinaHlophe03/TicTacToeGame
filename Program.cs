using System;

namespace TicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic-Tac-Toe!");

            // Create the board, initially filled with numbers 1-9
            char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            int player = 1; // Player 1 starts, alternate between 1 and 2
            int choice; // Store the player's choice (1-9)
            int validMove; // Will hold a check to see if the move is valid
            char mark; // Store the player's mark ('X' or 'O')

            // Print initial board
            PrintBoard(board);

            // Game loop
            do
            {
                // Determine current player's mark
                mark = (player % 2 == 0) ? 'O' : 'X';

                // Get player input
                Console.WriteLine($"Player {player}'s turn. Choose a spot (1-9): ");
                validMove = 0;

                while (validMove != 1)
                {
                    string userInput = Console.ReadLine();

                    // Validate input to ensure it's a number between 1 and 9
                    if (int.TryParse(userInput, out choice) && choice >= 1 && choice <= 9)
                    {
                        // Check if the spot is already taken
                        if (board[choice - 1] != 'X' && board[choice - 1] != 'O')
                        {
                            // Place the mark on the board
                            board[choice - 1] = mark;
                            validMove = 1; // Move is valid
                        }
                        else
                        {
                            Console.WriteLine("That spot is already taken, choose another spot.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please enter a number between 1 and 9.");
                    }
                }

                // Display the updated board
                PrintBoard(board);

                // Check for a winner
                if (CheckWin(board))
                {
                    Console.WriteLine($"Player {player} wins!");
                    break;
                }

                // Check for a draw
                if (Array.TrueForAll(board, spot => spot == 'X' || spot == 'O'))
                {
                    Console.WriteLine("It's a draw!");
                    break;
                }

                // Switch to the other player
                player++;
            } while (true);

            Console.ReadLine();
        }

        // Function to print the board
        static void PrintBoard(char[] board)
        {
            Console.Clear();
            Console.WriteLine(" {0} | {1} | {2} ", board[0], board[1], board[2]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", board[3], board[4], board[5]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", board[6], board[7], board[8]);
        }

        // Function to check for a winner
        static bool CheckWin(char[] board)
        {
            // Check rows, columns, and diagonals
            return (board[0] == board[1] && board[1] == board[2]) ||  // First row
                   (board[3] == board[4] && board[4] == board[5]) ||  // Second row
                   (board[6] == board[7] && board[7] == board[8]) ||  // Third row
                   (board[0] == board[3] && board[3] == board[6]) ||  // First column
                   (board[1] == board[4] && board[4] == board[7]) ||  // Second column
                   (board[2] == board[5] && board[5] == board[8]) ||  // Third column
                   (board[0] == board[4] && board[4] == board[8]) ||  // Diagonal 1
                   (board[2] == board[4] && board[4] == board[6]);    // Diagonal 2
        }
    }
}
