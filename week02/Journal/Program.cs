using System;
using System.Reflection;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");

        Console.WriteLine("Welcome to the Journal Program!");

        int action;
        Journal journal = new Journal(); //necesita estar afuera y no dentro de los if statements

        do
        {
            Console.Write("Please select one of the following choices:");
            //verbatim permite que todo lo que se agrege sea literal, los saltos de linea, espacios y caracteres especiales
            Console.WriteLine(@"

1. Write
2. Display
3. Load
4. Save
5. Quit");


            Console.Write("What would you like to do? ");
            string actionString = Console.ReadLine();
            if (!int.TryParse(actionString, out action))//Trata de parse actionstring a int, si funciona el valor se asigna a action si no, debido al "!" que hace que se niegue el estatement produciendo un bool true, se imprime en la consola
            {
                Console.WriteLine("\nInvalid input. Please enter a number between 1 and 5.\n");
                continue;
            }

            if (action == 1)
            {
                // Random prompt; Add date to the 
                PromptGenerator generator = new PromptGenerator();
                string randomPrompt = generator.GetRandomPrompt();
                Console.WriteLine(randomPrompt);
                // Add enFtry to joutnal
                Console.Write(">");
                string entryText = Console.ReadLine();
                string date = DateTime.Now.ToShortDateString(); //se usa para obtener solo la fecha pequena 
                string promptText = randomPrompt;
                Entry newEntry = new Entry(date, promptText, entryText);

                journal._entries.Add(newEntry);

            }
            if (action == 2)
            {
                // File shows date, promtp and respond, each one of them
                journal.DisplayAll();
            }
            if (action == 3)
            {
                // asksfor the file name and format
                Console.Write("What is the file name? ");
                string fileName = Console.ReadLine(); 
                if (fileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase)) //chequea si termina en algun texto e ignora el case
                {
                    journal.LoadFromFileTxt(fileName); 
                }
                else if (fileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                {
                    journal.LoadFromFileCsv(fileName); 
                }
                else if (fileName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                {
                    journal.LoadFromFileJson(fileName); 
                }
                else
                {
                    Console.WriteLine("Unsupported file format. Please use .txt, .csv, or .json.");
                }


            }

            if (action == 4)
            {
                Console.Write("What is the file name? ");
                string fileName = Console.ReadLine();
                if (fileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    journal.SaveToFileTxt(fileName);
                }
                else if (fileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                {
                    journal.SaveToFileCsv(fileName);
                }
                else if (fileName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                {
                    journal.SaveToFileJson(fileName);
                }
                else
                {
                    Console.WriteLine("Unsupported file format. Use .txt, .csv, or .json.");
                }

            }

        }
        while (action != 5);



        // while





    }
}