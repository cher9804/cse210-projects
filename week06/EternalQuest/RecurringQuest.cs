using System;

namespace InfiniteAdventure.Quests
{
    /// <summary>
    /// A quest that never ends – you can complete it repeatedly.
    /// </summary>
    public class RecurringQuest : QuestBase
    {
        public RecurringQuest(string title, string details, int xp)
            : base(title, details, xp) {}

        public override void RecordProgress()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Progress logged for '{Title}'! +{ExperiencePoints} XP. Keep up the momentum!");
            Console.ResetColor();
        }

        public override bool IsCompleted() => false;

        public override string GetSummary()
        {
            return $"{Title}: {Details} - {ExperiencePoints} XP (Recurring)";
        }

        public override string Serialize()
        {
            return $"Recurring|{Title}|{Details}|{ExperiencePoints}";
        }
    }
}
