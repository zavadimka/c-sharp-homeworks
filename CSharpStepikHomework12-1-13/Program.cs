namespace CSharpStepikHomework12_1_13
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> heroStats = new List<string>();
            List<string> enemyStats = new List<string>();
            
            string startFlag = Console.ReadLine();
            string inputString = Console.ReadLine();

            while (inputString != "enemy")
            {
                heroStats.Add(inputString);
                inputString = Console.ReadLine();
            }

            inputString = Console.ReadLine();
            while (inputString != "end")
            {
                enemyStats.Add(inputString);
                inputString = Console.ReadLine();
            }

            List<Character> heroesList = new List<Character>();
            List<Character> enemiesList = new List<Character>();

            heroesList.AddRange(Character.GetCharacters(heroStats));
            enemiesList.AddRange(Character.GetCharacters(enemyStats));

            Character.GetBattle(heroesList, enemiesList);
        }
    }
}