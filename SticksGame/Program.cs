namespace Udemy109SticksGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Вас приветствует игра \"Палочки\"!");
            Console.WriteLine($"На столе определённое палочек. Игроки по очереди убирают на выбор от 1 до 3 палочек");
            Console.WriteLine("Проигрывает игрок, который забирает последнюю палочку");
            Console.WriteLine($"Вы можете начать игру с 10, 20, 30, 40 или 50 палочками на столе. Сколько вы выберете?");
            
            int NumberOfStarterSticks = int.Parse(Console.ReadLine());
            SticksGame game = new SticksGame(NumberOfStarterSticks);
            int aISticksAmount;

            Console.WriteLine();

            game.WhoStarts();

            Console.WriteLine("Игра началась!");
            
            
            if (game.FirstPlayer == Players.Human)
            {
                Console.WriteLine("По результатам жеребьёвки Вы ходите первым");
            }
            else
            {
                Console.WriteLine("По результатам жеребьёвки первым ходит ИИ");
            }
            Console.WriteLine();
            


            while (game.GameStatus == GameStatus.InProgress)
            {
                PrintSticks();

                if (game.TurnFlag % 2 == 0)
                {
                    
                    int sticksAmount;

                    do
                    {
                        Console.Write("Сколько палочек Вы хотите убрать?: ");
                        sticksAmount = int.Parse(Console.ReadLine());
                        if (sticksAmount < 1 || sticksAmount > 3)
                        {
                            Console.WriteLine($"Вы не можете убрать меньше 1 и больше 3 палочек за один ход");
                        }
                        else
                        {
                            if (sticksAmount > game.NumberOfLeftSticks)
                            {
                                Console.WriteLine($"Количество изымаемых палочек ({sticksAmount}) больше остатка ({game.NumberOfLeftSticks})");
                                Console.WriteLine($"Вы не можете убрать больше {game.NumberOfLeftSticks} палочек");
                            }
                        }


                    } while (sticksAmount < 1 || sticksAmount > 3 || game.NumberOfLeftSticks < sticksAmount);

                    game.HumanTurn(sticksAmount);
                }
                else
                {
                    Console.WriteLine("Ходит ИИ");
                    aISticksAmount = (int)game.AITurn();
                    
                    if (aISticksAmount == 1)
                    {
                        Console.WriteLine($"ИИ убирает со стола {aISticksAmount} палочку");
                    }
                    else
                    {
                        Console.WriteLine($"ИИ убирает со стола {aISticksAmount} палочки");
                    }
                    
                }
                Console.WriteLine();
            }


            if (game.GameStatus == GameStatus.Lost)
            {
                Console.WriteLine("К сожалению, Вы проиграли. Повезёт в другой раз!");
            }
            else
            {
                Console.WriteLine("Ура! Вы выиграли!");
            }

            Console.WriteLine();
            Console.WriteLine("Чтобы закрыть окно, нажмите любую кнопку...");
            Console.ReadLine();

            void PrintSticks()
            {
                Console.WriteLine($"Осталось {game.NumberOfLeftSticks} палочек");
                for (int i = 1; i <= game.NumberOfLeftSticks; i++)
                {
                    Console.Write("|  ");
                }
                Console.WriteLine();
            }
        }
    }
}