namespace Udemy103TickTackToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] gameBoard = new char[3, 3]
            {
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            };

            char[,] gameBoardNum = new char[3, 3]
            {
                { '0', '1', '2' },
                { '3', '4', '5' },
                { '6', '7', '8' }
            };

            Console.WriteLine("Вас приветствует игра \"Крестики-Нолики\"!");
            Console.WriteLine("Первыми ходят крестики. Удачи!");
            
            PrintGameBoard();

            char cross = 'X';
            string krestikami = "крестиками";
            
            char nought = 'O';
            string nolikami = "ноликами";

            string fullBoard = "012345678";
            string matchResult = null;

            bool isWin = false;
            while (!isWin || matchResult != "draw")
            {
                MakeTurn(cross, krestikami);
                PrintGameBoard();
                isWin = CheckWinner(gameBoard, out string result1);
                matchResult = result1;
                if (isWin)
                {
                    Console.WriteLine("Поздравляем! Победили крестики!");
                    break;
                }
                else if (matchResult == "draw")
                {
                    Console.WriteLine("Ничья! Победила дружба!");
                    break;
                }

                MakeTurn(nought, nolikami);
                PrintGameBoard();
                isWin =  CheckWinner(gameBoard, out string result2);
                matchResult = result2;
                if (isWin)
                {
                    Console.WriteLine("Поздравляем! Победили нолики!");
                    break;
                }
                else if (matchResult == "draw")
                {
                    Console.WriteLine("Ничья! Победила дружба!");
                    break;
                }

                Console.WriteLine();
                Console.WriteLine("Чтобы закрыть окно, нажмите любую кнопку...");
                Console.ReadLine();
            }
            

            void PrintGameBoard()
            {
                Console.WriteLine();
                Console.Write($" {gameBoard[0, 0]} | {gameBoard[0, 1]} | {gameBoard[0, 2]} ");
                Console.Write("     ");
                Console.WriteLine($" {gameBoardNum[0, 0]} | {gameBoardNum[0, 1]} | {gameBoardNum[0, 2]} ");

                Console.Write($"---|---|---");
                Console.Write("     ");
                Console.WriteLine($"---|---|---");

                Console.Write($" {gameBoard[1, 0]} | {gameBoard[1, 1]} | {gameBoard[1, 2]} ");
                Console.Write("     ");
                Console.WriteLine($" {gameBoardNum[1, 0]} | {gameBoardNum[1, 1]} | {gameBoardNum[1, 2]} ");

                Console.Write($"---|---|---");
                Console.Write("     ");
                Console.WriteLine($"---|---|---");

                Console.Write($" {gameBoard[2, 0]} | {gameBoard[2, 1]} | {gameBoard[2, 2]} ");
                Console.Write("     ");
                Console.WriteLine($" {gameBoardNum[2, 0]} | {gameBoardNum[2, 1]} | {gameBoardNum[2, 2]} ");
                Console.WriteLine();
            }


            void MakeTurn(char thisTurnSymbol, string thisTurnValue)
            {
                string position = " ";

                while (!fullBoard.Contains(position))
                {
                    Console.Write($"Ход {thisTurnValue}. Введите номер поля: ");
                    position = Console.ReadLine();
                }

                switch (position)
                {
                    case "0":
                        gameBoard[0, 0] = thisTurnSymbol;
                        gameBoardNum[0, 0] = ' ';
                        break;
                    case "1":
                        gameBoard[0, 1] = thisTurnSymbol;
                        gameBoardNum[0, 1] = ' ';
                        break;
                    case "2":
                        gameBoard[0, 2] = thisTurnSymbol;
                        gameBoardNum[0, 2] = ' ';
                        break;
                    case "3":
                        gameBoard[1, 0] = thisTurnSymbol;
                        gameBoardNum[1, 0] = ' ';
                        break;
                    case "4":
                        gameBoard[1, 1] = thisTurnSymbol;
                        gameBoardNum[1, 1] = ' ';
                        break;
                    case "5":
                        gameBoard[1, 2] = thisTurnSymbol;
                        gameBoardNum[1, 2] = ' ';
                        break;
                    case "6":
                        gameBoard[2, 0] = thisTurnSymbol;
                        gameBoardNum[2, 0] = ' ';
                        break;
                    case "7":
                        gameBoard[2, 1] = thisTurnSymbol;
                        gameBoardNum[2, 1] = ' ';
                        break;
                    case "8":
                        gameBoard[2, 2] = thisTurnSymbol;
                        gameBoardNum[2, 2] = ' ';
                        break;
                }

                fullBoard = fullBoard.Remove(fullBoard.IndexOf(position), 1);
            }


            bool CheckWinner(char[,] gameBoard, out string matchResult)
            {
                matchResult = null;
                bool isWin = false;


                for (int i = 0; i < 3; i++)
                {
                    if (gameBoard[i, 0] != ' ' && gameBoard[i, 0] == gameBoard[i, 1] && gameBoard[i, 0] == gameBoard[i, 2])
                    {
                        isWin = true;
                        break;
                    }
                }
                
                for (int j = 0; j < 3; j++)
                {
                    if (gameBoard[0, j] != ' ' && gameBoard[0, j] == gameBoard[1, j] && gameBoard[0, j] == gameBoard[2, j])
                    {
                        isWin = true;
                        break;
                    }
                }

                if (gameBoard[0, 0] != ' ' && gameBoard[0, 0] == gameBoard[1, 1] && gameBoard[0, 0] == gameBoard[2, 2] ||
                    (gameBoard[0, 2] != ' ' && gameBoard[0, 2] == gameBoard[1, 1] && gameBoard[0, 2] == gameBoard[2, 0]))
                {
                    isWin = true;
                }

                if (!isWin && fullBoard == "")
                {
                    matchResult = "draw";
                }

                return isWin;
            }
        }
    }
}