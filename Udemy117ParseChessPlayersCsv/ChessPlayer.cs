using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy117ChessPlayers
{
    public class ChessPlayer
    {
        public int Rank { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Country { get; private set; }
        public int Rating { get; private set; }
        public int BirthYear { get; private set; }


        public static ChessPlayer ParseChessPlayersCsv(string chessPlayerString)
        {
            string[] data = chessPlayerString.Split(';');

            ChessPlayer player = new ChessPlayer()
            {
                Rank = int.Parse(data[0]),
                FirstName = data[1].Split(',')[1].Trim(),
                LastName = data[1].Split(',')[0].Trim(),
                Country = data[3],
                Rating = int.Parse(data[4]),
                BirthYear = int.Parse(data[6]),
            };

            return player;
        }

        public override string ToString()
        {
            return $"{Rank} {FirstName} {LastName} {Country} {Rating} {BirthYear}";
        }


    }
}
