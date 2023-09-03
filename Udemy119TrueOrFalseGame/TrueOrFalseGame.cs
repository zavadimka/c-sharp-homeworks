using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy119TrueOrFalseGame
{
    public class TrueOrFalseGame
    {
        private readonly List<Question> questions;
        private readonly int allowedMistakes;
        private int counter;
        private int mistakes;

        public event EventHandler<GameResultEventArgs> EndOfGame;

        public GameStatus GameStatus { get; private set; }

        public TrueOrFalseGame(string filePath, int allowedMistakes = 2)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException("filePath");
            }
            
            if (filePath == "")
            {
                throw new ArgumentNullException("Incorrect path to file");
            }

            if (allowedMistakes < 2)
            {
                throw new ArgumentOutOfRangeException("Number of allowed mistakes should be not less than 2");
            }

            List<Question> questions = File.ReadAllLines(filePath)
                                            .Select(line =>
                                            {
                                                string[] lineParts = line.Split(';');
                                                string questionText = lineParts[0];
                                                string CorrectAnswer = lineParts[1].Substring(0, 1).ToLower();
                                                string explanation = lineParts[2];

                                                return new Question(questionText, CorrectAnswer, explanation);
                                            })
                                            .ToList();

            this.questions = questions;
            this.allowedMistakes = allowedMistakes;
            GameStatus = GameStatus.GameInProgress;
        }

        
        public Question GetNextQuestion()
        {
            return questions[counter];
        }


        public void GiveAnswer(bool answer)
        {
            counter++;

            if (!answer)
            {
                mistakes++;
            }

            if (counter == questions.Count || mistakes > allowedMistakes)
            {
                GameStatus = GameStatus.GameIsOver;

                if (EndOfGame != null)
                {
                    EndOfGame(this, new GameResultEventArgs(counter, mistakes, mistakes <= allowedMistakes));
                }
            }
        }
    }
}
