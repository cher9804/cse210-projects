using System;

namespace InfiniteAdventure.Quests
{
    /// <summary>
    /// The base class for all quests.
    /// </summary>
    public abstract class QuestBase
    {
        protected string Title;
        protected string Details;
        protected int ExperiencePoints;

        public QuestBase(string title, string details, int xp)
        {
            Title = title;
            Details = details;
            ExperiencePoints = xp;
        }

        public abstract void RecordProgress();
        public abstract bool IsCompleted();
        public abstract string GetSummary();
        public abstract string Serialize();

        public virtual string GetInfo()
        {
            return $"[ ] {Title}: {Details}";
        }

        public int GetXP() => ExperiencePoints;

        public static QuestBase Deserialize(string data)
        {
            string[] parts = data.Split('|');
            string type = parts[0];
            string title = parts[1];
            string details = parts[2];
            int xp = int.Parse(parts[3]);

            return type switch
            {
                "OneTime" => new OneTimeQuest(title, details, xp, bool.Parse(parts[4])),
                "Recurring" => new RecurringQuest(title, details, xp),
                "Checklist" => new ChecklistQuest(title, details, xp, 
                                    int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]), bool.Parse(parts[7])),
                _ => throw new Exception("Unknown quest type during deserialization")
            };
        }
    }
}
