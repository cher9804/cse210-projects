using System;
using System.CodeDom.Compiler;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?", "What was the best part of my day?", "How did I see the hand of the Lord in my life today?", "What was the strongest emotion I felt today?", "If I had one thing I could do over today, what would it be?","What was the weirdest thing you saw?","Who was the most interesting person you saw and what you though of that person?"
    };

    // generate a random prompt rom a list
    public string GetRandomPrompt()
    {
        Random randomGenerator = new Random();

        int randomIndex = randomGenerator.Next(0,_prompts.Count);


        return _prompts[randomIndex];
    }

}