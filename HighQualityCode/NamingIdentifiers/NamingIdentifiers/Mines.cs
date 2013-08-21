namespace NamingIdentifiers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Mines
    {
        public static void Main(string[] arguments)
        {
            string command = string.Empty;
            char[,] field = CreateGameField();
            char[,] bombs = SetBombs();
            int counter = 0;
            bool hitBomb = false;
            List<Scores> topPoints = new List<Scores>(6);
            int row = 0;
            int col = 0;
            bool newGame = true;
            const int MaxPoints = 35;
            bool isWon = false;
            do
            {
                if (newGame)
                {
                    Console.WriteLine("Start Mines. You have to find all fields without bombs." +
                                      " commands: 'top' show top rating, 'restart' restart the game, 'exit' exit from the game");
                    DrawField(field);
                    newGame = false;
                }

                Console.Write("Enter Row and col (Example: 1 1): ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out col) &&
                        row <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Rating(topPoints);
                        break;
                    case "restart":
                        field = CreateGameField();
                        bombs = SetBombs();
                        DrawField(field);
                        hitBomb = false;
                        newGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("You have been exit from the game");
                        break;
                    case "turn":
                        if (bombs[row, col] != '*')
                        {
                            if (bombs[row, col] == '-')
                            {
                                SetBombField(field, bombs, row, col);
                                counter++;
                            }
                            if (MaxPoints == counter)
                            {
                                isWon = true;
                            }
                            else
                            {
                                DrawField(field);
                            }
                        }
                        else
                        {
                            hitBomb = true;
                        }
                        break;
                    default:
                        Console.WriteLine("Erowor! unknown command");
                        break;
                }

                if (hitBomb)
                {
                    DrawField(bombs);
                    Console.Write("You die! Try again. You have {0} points. " +
                                  "Enter your name: ", counter);
                    string name = Console.ReadLine();
                    Scores playerPoints = new Scores(name, counter);
                    if (topPoints.Count < 5)
                    {
                        topPoints.Add(playerPoints);
                    }
                    else
                    {
                        for (int index = 0; index < topPoints.Count; index++)
                        {
                            if (topPoints[index].Points < playerPoints.Points)
                            {
                                topPoints.Insert(index, playerPoints);
                                topPoints.RemoveAt(topPoints.Count - 1);
                                break;
                            }
                        }
                    }
                    topPoints.Sort((Scores firstPlayer, Scores secondPlayer) => secondPlayer.Name.CompareTo(firstPlayer.Name));
                    topPoints.Sort((Scores firstPlayer, Scores secondPlayer) => secondPlayer.Points.CompareTo(firstPlayer.Points));
                    Rating(topPoints);
                    field = CreateGameField();
                    bombs = SetBombs();
                    counter = 0;
                    hitBomb = false;
                    newGame = true;
                }
                if (isWon)
                {
                    Console.WriteLine("You have find all fields.");
                    DrawField(bombs);
                    Console.WriteLine("Your name: ");
                    string name = Console.ReadLine();
                    Scores playerPoints = new Scores(name, counter);
                    topPoints.Add(playerPoints);
                    Rating(topPoints);
                    field = CreateGameField();
                    bombs = SetBombs();
                    counter = 0;
                    isWon = false;
                    newGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria");
            Console.Read();
        }

        private static void Rating(List<Scores> playerPoints)
        {
            Console.WriteLine("Points:");
            if (playerPoints.Count > 0)
            {
                for (int index = 0; index < playerPoints.Count; index++)
                {
                    Console.WriteLine("{0}. {1} --> {2} fields",
                        index + 1, playerPoints[index].Name, playerPoints[index].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No people in top rating");
            }
        }

        private static void SetBombField(char[,] field, char[,] bombs, int row, int col)
        {
            char bombsNumber = GetBombField(bombs, row, col);
            bombs[row, col] = bombsNumber;
            field[row, col] = bombsNumber;
        }

        private static void DrawField(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(string.Format("{0} ", board[row, col]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int row = 0; row < boardRows; row++)
            {
                for (int col = 0; col < boardColumns; col++)
                {
                    board[row, col] = '?';
                }
            }

            return board;
        }

        private static char[,] SetBombs()
        {
            int rows = 5;
            int cols = 10;
            char[,] gameField = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    gameField[i, j] = '-';
                }
            }

            List<int> bombFill = new List<int>();
            while (bombFill.Count < 15)
            {
                Random randomInt = new Random();
                int randomLocation = randomInt.Next(50);
                if (!bombFill.Contains(randomLocation))
                {
                    bombFill.Add(randomLocation);
                }
            }

            foreach (int bombLocation in bombFill)
            {
                int col = (bombLocation / cols);
                int row = (bombLocation % cols);
                if (row == 0 && bombLocation != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }
                gameField[col, row - 1] = '*';
            }

            return gameField;
        }

        private static char GetBombField(char[,] field, int row, int col)
        {
            int bombCounter = 0;
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field[row - 1, rows] == '*')
                {
                    bombCounter++;
                }
            }
            if (row + 1 < rows)
            {
                if (field[row + 1, rows] == '*')
                {
                    bombCounter++;
                }
            }
            if (rows - 1 >= 0)
            {
                if (field[row, rows - 1] == '*')
                {
                    bombCounter++;
                }
            }
            if (rows + 1 < cols)
            {
                if (field[row, rows + 1] == '*')
                {
                    bombCounter++;
                }
            }
            if ((row - 1 >= 0) && (rows - 1 >= 0))
            {
                if (field[row - 1, rows - 1] == '*')
                {
                    bombCounter++;
                }
            }
            if ((row - 1 >= 0) && (rows + 1 < cols))
            {
                if (field[row - 1, rows + 1] == '*')
                {
                    bombCounter++;
                }
            }
            if ((row + 1 < rows) && (rows - 1 >= 0))
            {
                if (field[row + 1, rows - 1] == '*')
                {
                    bombCounter++;
                }
            }
            if ((row + 1 < rows) && (rows + 1 < cols))
            {
                if (field[row + 1, rows + 1] == '*')
                {
                    bombCounter++;
                }
            }
            return char.Parse(bombCounter.ToString());
        }
    }
}
