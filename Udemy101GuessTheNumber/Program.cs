namespace Udemy101GuessTheNumber
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует игра \"Угадай число\"!");
            Console.WriteLine("Один игрок загадывает число, а другой должен его отгадать.");
            Console.Write("Хотите, чтобы компьютер загадал число? \"Да\" или \"Нет\": ");

            string isVSComputer = Console.ReadLine();

            switch (isVSComputer)
            {
                case "Да":
                    StartGamePlayeerAnswer();
                    break;
                case "Нет":
                    StartGameAIAnswer();
                    break;
                default:
                    throw new ArgumentException("Введён некорректный ответ");
            }
        }


        private static int GetNumber()
        {
            Random random = new Random();
                
            return random.Next(0, 100);
        }

        private static void StartGamePlayeerAnswer()
        {
            int number = GetNumber();
            int answer;
            bool isRigthAnswer = false;

            Console.WriteLine("Компьютер загадал число от 0 до 100. У Вас есть 5 попыток, чтобы его отгадать");

            for (int i = 1; i < 6; i++)
            {
                Console.Write("Ваш ответ: ");
                answer = int.Parse(Console.ReadLine());

                if (answer == number)
                {
                    Console.WriteLine("Верно, Вы выиграли!");
                    isRigthAnswer = true;
                    break;
                }
                else if (answer < number)
                {
                    Console.WriteLine($"Ответ неверный, осталось попыток: {5 - i}");
                    Console.WriteLine($"{answer} меньше загаданного числа");
                }
                else
                {
                    Console.WriteLine($"Ответ неверный, осталось попыток: {5 - i}");
                    Console.WriteLine($"{answer} больше загаданного числа");
                }
            }

            if (!isRigthAnswer)
            {
                Console.WriteLine($"Вы проиграли. Правльный ответ: {number}");
            }
        }
        

        static void StartGameAIAnswer()
        {
            int number = -1;
            int firstNumber = 0;
            int lastNumber = 100;
            int answer;
            bool isRigthAnswer = false;

            
            while (number < 0 || number > 100)
            {
                Console.Write("Загадайте число от 0 до 100: ");
                number = int.Parse(Console.ReadLine());
            }
            
            
            Console.WriteLine("У ИИ есть 5 попыток, чтобы его отгадать");
            answer = (lastNumber - firstNumber) / 2;
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine($"Ответ ИИ: {answer}");

                if (answer == number)
                {
                    Console.WriteLine("Верно, ИИ выиграл!");
                    isRigthAnswer = true;
                    break;
                }
                else if (answer < number)
                {
                    Console.WriteLine($"Ответ неверный, осталось попыток: {5 - i}");
                    Console.WriteLine($"{answer} меньше загаданного числа");

                    firstNumber = answer;
                    answer =  answer + (lastNumber - firstNumber) / 2;
                }
                else
                {
                    Console.WriteLine($"Ответ неверный, осталось попыток: {5 - i}");
                    Console.WriteLine($"{answer} больше загаданного числа");

                    lastNumber = answer;
                    answer = answer - (lastNumber - firstNumber) / 2;
                }
            }

            Console.WriteLine();
            if (!isRigthAnswer)
            {
                Console.WriteLine($"ИИ проиграл. Правльный ответ: {number}");
            }
        }
    }
}