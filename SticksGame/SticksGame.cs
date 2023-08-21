using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy109SticksGame
{
    public class SticksGame
    {
        public readonly int NumberOfStarterSticks;
        private int LastHumanTurnSticksAmount;

        public int NumberOfLeftSticks { get; private set; }
        public GameStatus GameStatus { get; private set; } = GameStatus.NotStarted;
        public Players FirstPlayer { get; private set; }
        private SticksAmount SticksAmount { get; set; }
        public int TurnFlag { get; private set; }


        public SticksGame(int NumberOfStarterSticks = 10)
        {
            if (NumberOfStarterSticks < 10 || NumberOfStarterSticks > 50) 
            {
                throw new ArgumentException("Стартовое количество палочек должно быть между 10 и 50 включительно");
            }
            this.NumberOfStarterSticks = NumberOfStarterSticks;
            NumberOfLeftSticks = NumberOfStarterSticks;
        }


        public void WhoStarts()
        {
            if (GameStatus != GameStatus.NotStarted)
            {
                throw new InvalidOperationException($"Несоответствующий этап игры: {GameStatus}");
            }

            Random firstTurn = new Random();
            if (firstTurn.Next(2) == 0)
            {
                FirstPlayer = Players.Human;
                TurnFlag = 0;
            }
            else
            {
                FirstPlayer = Players.AI;
                TurnFlag = 1;
            }

            GameStatus = GameStatus.InProgress;
        }

        
        private bool isLost()
        {
            if (NumberOfLeftSticks == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public SticksAmount AITurn()
        {
            if (GameStatus != GameStatus.InProgress)
            {
                throw new InvalidOperationException($"Несоответствующий этап игры: {GameStatus}");
            }
            if (NumberOfLeftSticks == 0)
            {
                throw new InvalidOperationException("Нет больше палочек. Игра должна быть закончена");
            }

            if (FirstPlayer == Players.AI)
            {
                if ((NumberOfLeftSticks - 1) % ((int)SticksAmount.Three + 1) != 0)
                {
                    SticksAmount = (SticksAmount)((NumberOfLeftSticks - 1) % ((int)SticksAmount.Three + 1));
                }
                else
                {
                    SticksAmount = SticksAmount.Three;
                }
            }
            else
            {
                // если последняя взятка 3, то берем по 1, пока не возьмет меньше 3, чтобы можно было сравняться
                // если не 3, тогда по первому обычному варианту
                if (LastHumanTurnSticksAmount == 1 || LastHumanTurnSticksAmount == 2)
                {
                    if ((NumberOfLeftSticks - 1) % ((int)SticksAmount.Three + 1) != 0)
                    {
                        SticksAmount = (SticksAmount)((NumberOfLeftSticks - 1) % ((int)SticksAmount.Three + 1));
                    }
                    else
                    {
                        SticksAmount = SticksAmount.Three;
                    }
                }
                else
                {
                    SticksAmount = SticksAmount.One;
                }
            }

            if (NumberOfLeftSticks < (int)SticksAmount)
            {
                throw new ArgumentException($"Количество изымаемых палочек ({(int)SticksAmount}) больше остатка ({NumberOfLeftSticks})");
            }
            NumberOfLeftSticks -= (int)SticksAmount;
            
            if (isLost())
            {
                if (TurnFlag % 2 != 0)
                {
                    GameStatus = GameStatus.Won;
                }
                else
                {
                    GameStatus = GameStatus.Lost;
                }
            }
            else
            {
                TurnFlag++;
            }
            
            return SticksAmount;
        }

        public void HumanTurn(int sticksAmount)
        {
            if (GameStatus != GameStatus.InProgress)
            {
                throw new InvalidOperationException($"Несоответствующий этап игры: {GameStatus}");
            }
            if (NumberOfLeftSticks == 0)
            {
                throw new InvalidOperationException("Нет больше палочек. Игра должна быть закончена");
            }

            SticksAmount = (SticksAmount)sticksAmount;

            if (NumberOfLeftSticks < (int)sticksAmount)
            {
                throw new ArgumentException($"Количество изымаемых палочек ({(int)sticksAmount}) больше остатка ({NumberOfLeftSticks})");
            }

            NumberOfLeftSticks -= (int)sticksAmount;

            if (isLost())
            {
                if (TurnFlag % 2 == 0)
                {
                    GameStatus = GameStatus.Lost;
                }
                else
                {
                    GameStatus = GameStatus.Won;
                }
            }
            else
            {
                TurnFlag++;
            }
        }
    }
}
