namespace Udemy119TrueOrFalseGame
{
    public class Question
    {
        public string QuestionText { get; }
        public string CorrectAnswer { get; }
        public string Explanation { get; }

        public Question(string question, string сorrectAnswer, string explanation)
        {
            QuestionText = question;
            CorrectAnswer = сorrectAnswer;
            Explanation = explanation;
        }
    }
}