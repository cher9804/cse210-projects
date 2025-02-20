using InfiniteAdventure.Management;

namespace InfiniteAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            // Entry point for the Infinite Adventure game.
            QuestManager manager = new QuestManager();
            manager.StartAdventure();
        }
    }
}
