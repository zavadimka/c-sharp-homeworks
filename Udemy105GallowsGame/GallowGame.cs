using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Udemy105GallowsGame
{
    public class GallowGame
    {
        private string alphabet = " А Б В Г Д Е Ж З И Й К Л М Н О П Р С Т У Ф Х Ц Ч Ш Щ Ъ Ы Ь Э Ю Я ";
        private readonly int attempts;
        private readonly string randomWord;

        public string Alphabet { get { return alphabet; } private set { alphabet = value; } }
        private string[] Dictionary { get; set; }
        public string Word { get; }
        private string SacredWord { get; set; }
        private string CheckedWord { get; set; }
        private string UsedLetters { get; set; }


        public GallowGame(int attempts = 6)
        {
            this.attempts = attempts;
            randomWord = GenerateWord();
            Word = randomWord[0].ToString().ToUpper();

            SacredWord = "*";
            for (int i = 1; i < randomWord.Length; i++)
            {
                Word += " " + randomWord[i].ToString().ToUpper();
                SacredWord += " *";
            }
            CheckedWord = Word;
            UsedLetters = string.Empty;
        }


        public void StartGame()
        {
            int attemptCounter = attempts;

            Console.WriteLine("Ну что, брат-пират, допрыгался? Тебя хотят вздёрнуть на виселице и петля уже болтается на шее.");
            Console.WriteLine("У тебя есть 6 попыток, чтобы вспомнить старое заклинание (загаданное слово), которое позволит избежать тебе смерти");
            Console.WriteLine();

            bool containsLetter = false;
            while (SacredWord != Word && attemptCounter > 0)
            {
                containsLetter = GetTurn();
                if (!containsLetter)
                {
                    attemptCounter--;
                }
                Console.WriteLine($"Осталось попыток: {attemptCounter}");
                Console.WriteLine();
            }

            Console.WriteLine();

            if (SacredWord == Word)
            {
                Console.WriteLine($"Фуууух! Ты прошептал заклинание {Word} и откуда-то нарисовался Робин Гуд, перебил верёвку и тебе удалось сбежать. Чёрная Жемчужина, ром и шлюхи ждут!");
            }
            else
            {
                Console.WriteLine("Ну всё, тоби пизда - тебя вздёрнули на виселице, не пить тебе больше рома и не храпеть на пышных грудях куртизанок...");
                Console.WriteLine($"А заклинание было таким простым - {Word}");
            }
        }


        private string[] GetDictionary()
        {
            try
            {
                Dictionary = File.ReadAllLines("WordsStockRus.txt");

                return Dictionary;
            }
            catch (Exception ex)
            {
                throw new IOException("Ошибка при загрузке словаря: " + ex.Message);
            }
        }


        public string GenerateWord()
        {
            GetDictionary();
            Random randomIndex = new Random(DateTime.Now.Millisecond);
            int randomWordIndex = randomIndex.Next(Dictionary.Length - 1);
            string word = Dictionary[randomWordIndex];

            return word;
        }


        private bool GetTurn()
        {
            Console.Write("Отгадайте слово: ");
            Console.WriteLine(SacredWord);
            Console.Write("Оставшиеся буквы алфавита: ");
            Console.WriteLine(Alphabet);
            Console.Write("Буква: ");
            char letter;

            do
            {
                letter = char.ToUpper(Console.ReadLine().First());
                if (UsedLetters.Contains(letter))
                {
                    Console.Write("Такая буква уже была, выберите другую: ");
                }
            }
            while (UsedLetters.Contains(letter));

            UsedLetters += letter;

            if (CheckedWord.Contains(letter))
            {
                Console.WriteLine("Правильно! Есть такая буква!");

                while (CheckedWord.IndexOf(letter) != -1)
                {
                    int index = CheckedWord.IndexOf(letter);
                    if (index == CheckedWord.Length - 1)
                    {
                        SacredWord = SacredWord.Substring(0, index) + letter;
                        CheckedWord = CheckedWord.Substring(0, index) + '*';
                    }
                    else
                    {
                        SacredWord = SacredWord.Substring(0, index) + letter + SacredWord.Substring(index + 1);
                        CheckedWord = CheckedWord.Substring(0, index) + '*' + CheckedWord.Substring(index + 1);
                    }
                }
                
                Alphabet = Alphabet.Substring(0, Alphabet.IndexOf(letter)).TrimEnd() + Alphabet.Substring(Alphabet.IndexOf(letter) + 1);
                
                return true;
            }
            else
            {
                Console.Write($"Нет такой буквы! ");
                Alphabet = Alphabet.Substring(0, Alphabet.IndexOf(letter)).TrimEnd() + Alphabet.Substring(Alphabet.IndexOf(letter) + 1);
                return false;
            }
        }
    }
}
