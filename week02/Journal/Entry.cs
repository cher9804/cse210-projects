using System;
using System.ComponentModel;

public class Entry
{
    public string _date {get; set;} //sirve para serializar los datos en Json o cualquier otro que lo necesite
    public string _promptText {get; set;}
    public string _entryText {get; set;}
    // get the entry from the user
    // display method: goes to the file and get all entries 
    public Entry() { } //esto se usa para poder hacer la serializacion en Json

    public Entry(string date, string prompt, string entry)
    {
        _date = date;
        _promptText = prompt;
        _entryText = entry;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}\n{_entryText}");
    }

}