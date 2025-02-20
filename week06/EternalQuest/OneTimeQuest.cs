using System;

namespace InfiniteAdventure.Quests
{
    /// <summary>
    /// A quest that can be completed only once.
    /// </summary>
    public class OneTimeQuest : QuestBase
    {
        private bool _completed;

        public OneTimeQuest(string title, string details, int xp, bool completed) 
            : base(title, details, xp)
        {
            _completed = completed;
        }

        public override void RecordProgress()
        {
            if (!_completed)
            {
                _completed = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Quest '{Title}' finished! +{ExperiencePoints} XP earned!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"Quest '{Title}' is already completed.");
            }
        }

        public override bool IsCompleted() => _completed;

        public override string GetSummary()
        {
            return _completed 
                ? $"[✓] {Title}: {Details} - {ExperiencePoints} XP - Completed: Yes"
                : $"[ ] {Title}: {Details} - {ExperiencePoints} XP - Completed: No";
        }

        public override string Serialize()
        {
            return $"OneTime|{Title}|{Details}|{ExperiencePoints}|{_completed}";
        }
    }
}
