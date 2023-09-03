namespace Udemy119TrueOrFalseGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует игра \"Верю - Не верю\"");
            Console.WriteLine("ИИ задаёт вопрос или предлагает некоторое утверждение, а игрок отвечает \"Да (согласен) / Нет (не согласен)\"");
            Console.WriteLine();

            var game = new TrueOrFalseGame("Questions.csv");
            
            game.EndOfGame += (sender, EventArgs) =>
            {
                Console.WriteLine();
                Console.WriteLine(EventArgs.IsWin ? "Поздравляем! Вы выиграли!" : "Очень жаль, но Вы проиграли.");
                Console.WriteLine($"Количество заданных вопросов: {EventArgs.QuestionsAskedNumber}, количество допущенных ошибок: {EventArgs.MistakesNumber}");
            };

            while (game.GameStatus == GameStatus.GameInProgress)
            {
                Question question = game.GetNextQuestion();
                Console.WriteLine("Вы согласны со следующим утверждением (вопросом)? Введите \"y\" (да) или \"n\" (нет)");
                Console.WriteLine(question.QuestionText);

                string answer = Console.ReadLine();
                bool rigthAnswer = question.CorrectAnswer == answer;

                if (rigthAnswer)
                {
                    Console.WriteLine("Поздраляем! Вы ответили правильно");
                    Console.WriteLine(question.Explanation);
                }
                else
                {
                    Console.WriteLine("К сожалению Вы ошиблись");
                    Console.WriteLine(question.Explanation);
                }

                game.GiveAnswer(rigthAnswer);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}