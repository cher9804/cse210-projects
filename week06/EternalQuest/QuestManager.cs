using System;
using System.Collections.Generic;
using System.IO;
using InfiniteAdventure.Quests;

namespace InfiniteAdventure.Management
{
    /// <summary>
    /// Manages quests, tracks player stats, and handles saving/loading.
    /// </summary>
    public class QuestManager
    {
        private List<QuestBase> _quests;
        private int _totalScore;
        private int _currentLevel;
        private int _currentXP;
        private int _xpThreshold;
        private string _dailyChallenge;
        private Dictionary<string, bool> _achievements;
        private Random _random;

        public QuestManager()
        {
            _quests = new List<QuestBase>();
            _totalScore = 0;
            _currentLevel = 1;
            _currentXP = 0;
            _xpThreshold = 100;
            _random = new Random();

            _achievements = new Dictionary<string, bool>
            {
                {"First Quest Completed", false},
                {"Reached Level 5", false}
            };

            SetDailyChallenge();
        }

        public void StartAdventure()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n=== INFINITE ADVENTURE ===");
                Console.WriteLine("1. Show Status");
                Console.WriteLine("2. Show Quests");
                Console.WriteLine("3. Add a New Quest");
                Console.WriteLine("4. Log Quest Progress");
                Console.WriteLine("5. Save Adventure");
                Console.WriteLine("6. Load Adventure");
                Console.WriteLine("7. Exit Adventure");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        DisplayStatus();
                        break;
                    case "2":
                        ListQuests();
                        break;
                    case "3":
                        CreateQuest();
                        break;
                    case "4":
                        LogProgress();
                        break;
                    case "5":
                        SaveAdventure();
                        break;
                    case "6":
                        LoadAdventure();
                        break;
                    case "7":
                        Console.WriteLine("Farewell, brave adventurer!");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose wisely.");
                        break;
                }
            }
        }

        private void DisplayStatus()
        {
            Console.WriteLine($"Level: {_currentLevel} | XP: {_currentXP}/{_xpThreshold} | Total Score: {_totalScore}");
            Console.WriteLine($"Today's Challenge: {_dailyChallenge}");
        }

        private void GainXP(int points)
        {
            _currentXP += points;
            Console.WriteLine($"You earned {points} XP!");

            while (_currentXP >= _xpThreshold)
            {
                _currentXP -= _xpThreshold;
                LevelUp();
            }
        }

        private void LevelUp()
        {
            _currentLevel++;
            _xpThreshold += 50;
            Console.WriteLine($"*** LEVEL UP! Now at Level {_currentLevel} ***");

            if (_currentLevel == 5 && !_achievements["Reached Level 5"])
            {
                _achievements["Reached Level 5"] = true;
                Console.WriteLine("Achievement Unlocked: Reached Level 5!");
            }
        }

        private void SetDailyChallenge()
        {
            string[] challenges = { "Complete 3 quests", "Earn 200 XP", "Finish a checklist quest" };
            _dailyChallenge = challenges[_random.Next(challenges.Length)];
        }

        public void ListQuests()
        {
            if (_quests.Count == 0)
            {
                Console.WriteLine("No quests available. Embark on a new quest!");
                return;
            }

            Console.WriteLine("\nYour Active Quests:");
            foreach (QuestBase quest in _quests)
            {
                Console.WriteLine(quest.GetInfo());
            }
        }

        public void CreateQuest()
        {
            Console.Write("\nEnter quest title: ");
            string title = Console.ReadLine();

            Console.Write("Enter quest details: ");
            string details = Console.ReadLine();

            Console.Write("Enter experience points: ");
            int xp;
            while (!int.TryParse(Console.ReadLine(), out xp) || xp < 0)
            {
                Console.Write("Please enter a valid XP amount: ");
            }

            Console.WriteLine("\nSelect quest type: ");
            Console.WriteLine("1. One-Time Quest");
            Console.WriteLine("2. Recurring Quest");
            Console.WriteLine("3. Checklist Quest");
            string choice = Console.ReadLine();

            QuestBase newQuest = choice switch
            {
                "1" => new OneTimeQuest(title, details, xp, false),
                "2" => new RecurringQuest(title, details, xp),
                "3" => CreateChecklistQuest(title, details, xp),
                _   => null
            };

            if (newQuest != null)
            {
                _quests.Add(newQuest);
                Console.WriteLine("Quest added to your adventure!");
            }
            else
            {
                Console.WriteLine("Invalid quest type selected.");
            }
        }

        private QuestBase CreateChecklistQuest(string title, string details, int xp)
        {
            Console.Write("Enter the required number of completions: ");
            int target;
            while (!int.TryParse(Console.ReadLine(), out target) || target <= 0)
            {
                Console.Write("Please enter a valid target number: ");
            }

            Console.Write("Enter bonus XP for full completion: ");
            int bonus;
            while (!int.TryParse(Console.ReadLine(), out bonus) || bonus < 0)
            {
                Console.Write("Please enter a valid bonus XP value: ");
            }

            return new ChecklistQuest(title, details, xp, 0, target, bonus, false);
        }

        public void LogProgress()
        {
            if (_quests.Count == 0)
            {
                Console.WriteLine("No quests to update. Create one first!");
                return;
            }

            Console.WriteLine("Select a quest to log progress:");
            for (int i = 0; i < _quests.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_quests[i].GetInfo()}");
            }

            if (int.TryParse(Console.ReadLine(), out int selection) && selection > 0 && selection <= _quests.Count)
            {
                QuestBase selectedQuest = _quests[selection - 1];
                selectedQuest.RecordProgress();
                _totalScore += selectedQuest.GetXP();
                GainXP(selectedQuest.GetXP());
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        public void SaveAdventure()
        {
            Console.Write("Enter a save file name: ");
            string filename = Console.ReadLine();

            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    // Write file header
                    writer.WriteLine($"SaveFile|{filename}");

                    // Write player stats
                    writer.WriteLine($"Stats|{_totalScore}|{_currentLevel}|{_currentXP}|{_xpThreshold}");

                    // Write quests
                    foreach (QuestBase quest in _quests)
                    {
                        writer.WriteLine(quest.Serialize());
                    }
                }
                Console.WriteLine($"Adventure saved successfully to '{filename}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving adventure: {ex.Message}");
            }
        }

        public void LoadAdventure()
        {
            Console.Write("Enter the name of the save file: ");
            string filename = Console.ReadLine();

            if (!File.Exists(filename))
            {
                Console.WriteLine("Save file not found.");
                return;
            }

            try
            {
                _quests.Clear();
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');

                        if (parts[0] == "SaveFile")
                        {
                            Console.WriteLine($"Loading adventure from: {parts[1]}");
                        }
                        else if (parts[0] == "Stats")
                        {
                            _totalScore = int.Parse(parts[1]);
                            _currentLevel = int.Parse(parts[2]);
                            _currentXP = int.Parse(parts[3]);
                            _xpThreshold = int.Parse(parts[4]);
                        }
                        else
                        {
                            _quests.Add(QuestBase.Deserialize(line));
                        }
                    }
                }
                Console.WriteLine($"Adventure loaded successfully from '{filename}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading adventure: {ex.Message}");
            }
        }
    }
}
