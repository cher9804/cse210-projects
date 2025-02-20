using System;

namespace InfiniteAdventure.Quests
{
    /// <summary>
    /// A quest that requires multiple completions, with an extra bonus when finished.
    /// </summary>
    public class ChecklistQuest : QuestBase
    {
        private int _progressCount;
        private int _targetCount;
        private int _bonusXP;
        private bool _completed;

        public ChecklistQuest(string title, string details, int xp, int progressCount, int targetCount, int bonusXP, bool completed)
            : base(title, details, xp)
        {
            _progressCount = progressCount;
            _targetCount = targetCount;
            _bonusXP = bonusXP;
            _completed = completed;
        }

        public override void RecordProgress()
        {
            if (_completed)
            {
                Console.WriteLine($"Quest '{Title}' has been fully completed already.");
                return;
            }

            _progressCount++;
            Console.WriteLine($"Progress on '{Title}' updated! +{ExperiencePoints} XP earned!");

            if (_progressCount >= _targetCount)
            {
                _completed = true;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Extra Reward! You finished '{Title}' and gained an additional {_bonusXP} XP!");
                Console.ResetColor();
            }
        }

        public override bool IsCompleted() => _progressCount >= _targetCount;

        public override string GetSummary()
        {
            string status = IsCompleted() ? "[✓]" : "[ ]";
            return $"{status} {Title}: {Details} - {ExperiencePoints} XP - Progress: {_progressCount}/{_targetCount}";
        }

        public override string Serialize()
        {
            return $"Checklist|{Title}|{Details}|{ExperiencePoints}|{_progressCount}|{_targetCount}|{_bonusXP}|{_completed}";
        }
    }
}
