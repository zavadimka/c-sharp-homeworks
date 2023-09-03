namespace Udemy119TrueOrFalseGame
{
    public class GameResultEventArgs : EventArgs
    {
        public GameResultEventArgs(int questionsAskedNumber, int mistakesNumber, bool isWin)
        {
            QuestionsAskedNumber = questionsAskedNumber;
            MistakesNumber = mistakesNumber;
            IsWin = isWin;
        }

        public int QuestionsAskedNumber { get; }
        public int MistakesNumber { get; }
        public bool IsWin { get; }
    }
}
