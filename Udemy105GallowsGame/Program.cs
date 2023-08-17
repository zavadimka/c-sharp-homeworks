namespace Udemy105GallowsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GallowGame game = new GallowGame();

            game.StartGame();

            Console.WriteLine();
            Console.WriteLine("Чтобы закрыть окно, нажмите любую кнопку...");
            Console.ReadLine();

        }
    }
}