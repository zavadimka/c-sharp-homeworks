using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CSharpStepikHomework12_1_13
{
    public class Character
    {
        private int _healthPoints;

        public string CharacterType { get; }
        public int Strength { get; }
        public int Agility { get; }
        public int Vitality { get; }
        public int Intellect { get; }
        public string CharacterName { get; }

        public int HealthPoints
        {
            get { return _healthPoints; }
            private set
            {
                if (value >= 0)
                {
                    _healthPoints = value;
                }
                else
                {
                    _healthPoints = 0;
                }
            }
        }
        public int ManaPoints { get; private set; }
        private int PhysicalArmor { get; }
        public int MagicArmor { get; }
        public string WeaponType { get; }
        public int PhysicalDamage { get; }
        public int MagicDamage { get; }

        public Character(string characterType, int strength, int agility, int vitality, int intellect, string characterName)
        {
            CharacterType = characterType;
            CharacterName = characterName;

            Strength = strength;
            Agility = agility;
            Vitality = vitality;
            Intellect = intellect;

            HealthPoints = Vitality * 4;
            ManaPoints = Intellect * 4;
            PhysicalArmor = Agility / 2;
            MagicArmor = Intellect / 2;




            switch (characterType)
            {
                case "Knight":
                    Strength = Strength + 2;
                    HealthPoints = HealthPoints + 15;
                    PhysicalArmor = PhysicalArmor + 2;
                    WeaponType = "sword";
                    PhysicalDamage = Strength + 5;
                    break;
                case "Thief":
                    Agility = Agility + 3;
                    PhysicalArmor = Agility / 2;
                    WeaponType = "dagger";
                    PhysicalDamage = Agility + 5;
                    break;
                case "Mage":
                    Intellect = Intellect + 5;
                    ManaPoints = Intellect * 4 + 25;
                    MagicArmor = Intellect / 2 + 2;
                    WeaponType = "staff";
                    PhysicalDamage = Strength + 15;
                    MagicDamage = 10;
                    break;
            }
        }

        private int ChainlightningCast()
        {
            int chainlightningDamage = MagicDamage + Intellect;
            return chainlightningDamage;
        }

        public static List<Character> GetCharacters(List<string> inputStrings)
        {
            var characterList = new List<Character>();

            for (int i = 0; i < inputStrings.Count; i++)
            {
                string[] characterStats = inputStrings[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string characterType = characterStats[0].Substring(0, 1).ToUpper() + characterStats[0].Substring(1);
                int strength = int.Parse(characterStats[1]);
                int agility = int.Parse(characterStats[2]);
                int vitality = int.Parse(characterStats[3]);
                int intellect = int.Parse(characterStats[4]);
                string characterName = characterStats[5];

                for (int j = 6; j < characterStats.Length; j++)
                {
                    characterName += " " + characterStats[j];
                }

                Character newCharacter = new Character(characterType, strength, agility, vitality, intellect, characterName);
                characterList.Add(newCharacter);
            }

            return characterList;
        }

        private int GetPhysicalDamage(int physicalDamage)
        {
            int damage = physicalDamage - PhysicalArmor - Agility;
            if (damage < 0)
            {
                damage = 0;
            }

            HealthPoints = HealthPoints - damage;
            return damage;
        }

        private int GetMagicDamage(int magicDamage)
        {
            int damage = magicDamage - MagicArmor - Intellect;
            if (damage < 0)
            {
                damage = 0;
            }

            HealthPoints = HealthPoints - damage;
            return damage;
        }

        public static void GetBattle(List<Character> heroesList, List<Character> enemiesList)
        {
            Console.WriteLine("Stay a while and listen, and I will tell you a story. A story of Dungeons and Dragons, of Orcs and Goblins, of Ghouls and Ghosts, of Kings and Quests, but most importantly -- of Heroes and NoobCo -- Well... A story of Heroes.");

            int heroesCountOrigin = heroesList.Count;

            if (heroesList.Count == 1)
            {
                heroesCountOrigin = 1;

                if (enemiesList.Count == 1)
                {
                    Console.WriteLine($"So here starts the journey of our hero {heroesList[0].CharacterType} {heroesList[0].CharacterName} got order to eliminate the local bandit known as {enemiesList[0].CharacterType} {enemiesList[0].CharacterName}.");
                }
                else
                {
                    Console.Write($"So here starts the journey of our hero {heroesList[0].CharacterType} {heroesList[0].CharacterName} got order to eliminate the local gang consists of well known bandits: {enemiesList[0].CharacterType} {enemiesList[0].CharacterName}");
                    for (int i = 1; i < enemiesList.Count; i++)
                    {
                        Console.Write($", {enemiesList[i].CharacterType} {enemiesList[i].CharacterName}");
                    }
                    Console.WriteLine(".");
                }
            }
            else
            {
                if (enemiesList.Count == 1)
                {
                    Console.Write($"So here starts the journey of our heroes: {heroesList[0].CharacterType} {heroesList[0].CharacterName}");
                    for (int i = 1; i < heroesList.Count; i++)
                    {
                        Console.Write($", {heroesList[i].CharacterType} {heroesList[i].CharacterName}");
                    }
                    Console.WriteLine($" got order to eliminate the local bandit known as {enemiesList[0].CharacterType} {enemiesList[0].CharacterName}.");
                }
                else
                {
                    Console.Write($"So here starts the journey of our heroes: {heroesList[0].CharacterType} {heroesList[0].CharacterName}");
                    for (int i = 1; i < heroesList.Count; i++)
                    {
                        Console.Write($", {heroesList[i].CharacterType} {heroesList[i].CharacterName}");
                    }
                    Console.Write($" got order to eliminate the local gang consists of well known bandits: {enemiesList[0].CharacterType} {enemiesList[0].CharacterName}");
                    for (int i = 1; i < enemiesList.Count; i++)
                    {
                        Console.Write($", {enemiesList[i].CharacterType} {enemiesList[i].CharacterName}");
                    }
                    Console.WriteLine(".");
                }

                Console.Write(heroesList[0].CharacterType + " " + heroesList[0].CharacterName);
                for (int i = 1; i < heroesList.Count; i++)
                {
                    Console.Write($", {heroesList[i].CharacterType} {heroesList[i].CharacterName}");
                }
                Console.Write($" engaged the {enemiesList[0].CharacterType} {enemiesList[0].CharacterName}");
                for (int i = 1; i < enemiesList.Count; i++)
                {
                    Console.Write($", {enemiesList[i].CharacterType} {enemiesList[i].CharacterName}");
                }
                Console.WriteLine(".");
            }

            // Начало сражения
            do
            {
                for (int i = 0; i < heroesList.Count; i++)
                {

                    if (heroesList[i].CharacterType == "Mage" && heroesList[i].ManaPoints >= 40)
                    {
                        foreach (var enemy in enemiesList)
                        {
                            int damage = enemy.GetMagicDamage(heroesList[i].ChainlightningCast());
                            Console.WriteLine($"{heroesList[i].CharacterType} {heroesList[i].CharacterName} attacking {enemy.CharacterType} {enemy.CharacterName} with chain lightning.");
                            Console.WriteLine($"{enemy.CharacterType} {enemy.CharacterName} get hit for {damage} hp and have {enemy.HealthPoints} hp left!");
                            
                            if (enemy.HealthPoints == 0)
                            {
                                Console.WriteLine($"{enemy.CharacterType} {enemy.CharacterName} is defeated!");
                            }
                        }
                        heroesList[i].ManaPoints -= 40;
                    }
                    else
                    {
                        int idxOfAttChar = enemiesList.IndexOf(enemiesList.Find(enemy => enemy.HealthPoints + enemy.PhysicalArmor == enemiesList.Min(enemy => enemy.HealthPoints + enemy.PhysicalArmor)));
                        int damage = enemiesList[idxOfAttChar].GetPhysicalDamage(heroesList[i].PhysicalDamage);
                        Console.WriteLine($"{heroesList[i].CharacterType} {heroesList[i].CharacterName} attacking {enemiesList[idxOfAttChar].CharacterType} {enemiesList[idxOfAttChar].CharacterName} with {heroesList[i].WeaponType}.");
                        Console.WriteLine($"{enemiesList[idxOfAttChar].CharacterType} {enemiesList[idxOfAttChar].CharacterName} get hit for {damage} hp and have {enemiesList[idxOfAttChar].HealthPoints} hp left!");

                        if (enemiesList[idxOfAttChar].HealthPoints == 0)
                        {
                            Console.WriteLine($"{enemiesList[idxOfAttChar].CharacterType} {enemiesList[idxOfAttChar].CharacterName} is defeated!");
                        }
                    }

                    enemiesList.RemoveAll(enemy => enemy.HealthPoints == 0);
                }

                for (int i = 0; i < enemiesList.Count; i++)
                {
                    if (enemiesList[i].CharacterType == "Mage" && enemiesList[i].ManaPoints >= 40)
                    {
                        foreach (var hero in heroesList)
                        {
                            int damage = hero.GetMagicDamage(enemiesList[i].ChainlightningCast());
                            Console.WriteLine($"{enemiesList[i].CharacterType} {enemiesList[i].CharacterName} attacking {hero.CharacterType} {hero.CharacterName} with chain lightning.");
                            Console.WriteLine($"{hero.CharacterType} {hero.CharacterName} get hit for {damage} hp and have {hero.HealthPoints} hp left!");

                            if (hero.HealthPoints == 0)
                            {
                                Console.WriteLine($"{hero.CharacterType} {hero.CharacterName} is defeated!");
                            }
                        }
                        enemiesList[i].ManaPoints -= 40;
                    }
                    else
                    {
                        int idxOfAttChar = heroesList.IndexOf(heroesList.Find(hero => hero.HealthPoints + hero.PhysicalArmor == heroesList.Min(hero => hero.HealthPoints + hero.PhysicalArmor)));
                        int damage = heroesList[idxOfAttChar].GetPhysicalDamage(enemiesList[i].PhysicalDamage);
                        Console.WriteLine($"{enemiesList[i].CharacterType} {enemiesList[i].CharacterName} attacking {heroesList[idxOfAttChar].CharacterType} {heroesList[idxOfAttChar].CharacterName} with {enemiesList[i].WeaponType}.");
                        Console.WriteLine($"{heroesList[idxOfAttChar].CharacterType} {heroesList[idxOfAttChar].CharacterName} get hit for {damage} hp and have {heroesList[idxOfAttChar].HealthPoints} hp left!");

                        if (heroesList[idxOfAttChar].HealthPoints == 0)
                        {
                            Console.WriteLine($"{heroesList[idxOfAttChar].CharacterType} {heroesList[idxOfAttChar].CharacterName} is defeated!");
                        }
                    }

                    heroesList.RemoveAll(hero => hero.HealthPoints == 0);
                    if (heroesList.Count == 0)
                    {
                        break;
                    }
                }

                if (enemiesList.Count == 0)
                {
                    break;
                }
            }
            while (heroesList.Count > 0);

            if (enemiesList.Count == 0)
            {
                Console.WriteLine("Congratulations!");
            }
            else
            {
                if (heroesCountOrigin == 1)
                {
                    Console.WriteLine($"Unfortunately our hero was brave, yet not enough skilled, or just lack of luck.");
                }
                else
                {
                    Console.WriteLine("Unfortunately our heroes were brave, yet not enough skilled, or just lack of luck.");
                }
            }
        }
    }
}
