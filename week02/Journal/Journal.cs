using System;
using System.IO; //for the file
using System.Text.Json; //for the json calls


public class Journal
{
    public List<Entry> _entries = new List<Entry>(); //crea lista de clase entry

    // adding an entry to the list
    public void AddEntry(Entry newEntry)
    {

        _entries.Add(newEntry);
    }
    // dispplay data from the file / data entered: go to the display method in entry
    public void DisplayAll()
    {
        foreach (Entry e in _entries) //
        {
            e.Display(); //"e" hace referencia al Entry item en el que estamos parados en el foreach 0-infinito
        }
    }
    // saving to a file
    public void SaveToFileTxt(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))//igual al with de python y el openfile, al usarlo, el archivo se cierra solo cuando se sale de la funcion
        {
            outputFile.WriteLine("Date|Prompt|Response");

            foreach (Entry e in _entries)
            {
                string date = e._date;
                string prompt = e._promptText;
                string entry = e._entryText;

                outputFile.WriteLine($"{date}|{prompt}|{entry}");
            }
        }
    }
    public void SaveToFileCsv(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            outputFile.WriteLine("Date,Prompt,Response");

            foreach (Entry e in _entries)
            {
                string date = $"\"{e._date.Replace("\"", "\"\"")}\"";//se hace escaped para que los caracteres especiales o las comillas se tomen como literales y se hace escape complete de los variables
                string prompt = $"\"{e._promptText.Replace("\"", "\"\"")}\"";
                string entry = $"\"{e._entryText.Replace("\"", "\"\"")}\"";


                outputFile.WriteLine($"{date},{prompt},{entry}");
            }
        }
    }

    public void SaveToFileJson(string file)
    {
        string json = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(file, json);//usa el get and set de la class Entry para poder serializar los datos en Json
    }



    // loading from a file, read the file
    // public void LoadFromFile(string file)
    // {
    //     _entries.Clear();//limpia la lista entries para asegurarnos de que al cargar un archivo, la lista este limpia

    //     string[] lines = File.ReadAllLines(file);
    //     for (int i = 1; i < lines.Length; i++) // Skip the header row
    //     {
    //         string line = lines[i];
    //         string[] parts = line.Split("\",\"", StringSplitOptions.None);

    //         if (parts.Length >= 3)
    //         {
    //             string date = parts[0].Trim('"');
    //             string prompt = parts[1].Trim('"');
    //             string response = parts[2].Trim('"');
    //             Entry entry = new Entry(date, prompt, response);
    //             _entries.Add(entry);
    //         }
    //     }
    // }

    public void LoadFromFileCsv(string file)
    {
        _entries.Clear();

        string[] lines = File.ReadAllLines(file).Skip(1).ToArray();//lee el archivo por lineas y hace skip del primero y lo vuelve array de nuevo, todo se guarda en lines en un array
        foreach (string line in lines)
        {
            string[] parts = line.Split("\",\"", StringSplitOptions.None);//THis wont ignore ninguno, todos seran tomados en cuenta pero si usan StringSplitOptions.RemoveEmptyEntries:any empty substrings in the result would be removed
            if (parts.Length >= 3)
            {
                string date = parts[0].Trim('"');//for additional quotes
                string promptText = parts[1].Trim('"');
                string entryText = parts[2].Trim('"');
                Entry entry = new Entry(date, promptText, entryText);
                _entries.Add(entry);
            }
        }
    }
    public void LoadFromFileTxt(string file)
    {
        _entries.Clear();

        string[] lines = File.ReadAllLines(file).Skip(1).ToArray();
        foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            if (parts.Length >= 3)
            {
                string date = parts[0].Trim();
                string promptText = parts[1].Trim();
                string entryText = parts[2].Trim();
                Entry entry = new Entry(date, promptText, entryText);
                _entries.Add(entry);
            }
        }
    }
    public void LoadFromFileJson(string file)
    {
        string json = File.ReadAllText(file);//lee el json file
        _entries = JsonSerializer.Deserialize<List<Entry>>(json) ?? new List<Entry>(); //usa el get and set de la class Entry para poder serializar los datos en Json
    }


}