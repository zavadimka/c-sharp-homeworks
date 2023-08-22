using Udemy117ChessPlayers;

namespace Udemy117ChessGamers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetPlayersByCondition("Top100ChessPlayers.csv");
        }

        static void GetPlayersByCondition (string file)
        {
            var players = File.ReadAllLines(file)
                                            .Skip(1)
                                            .Select(ChessPlayer.ParseChessPlayersCsv)
                                            .Where(player => player.Country == "RUS" && player.Rating > 2700)
                                            .OrderBy(player => player.BirthYear)
                                            .ToList();

            foreach (var player in players)
            {
                Console.WriteLine(player);
            }
        }
    }
}