using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();
    private List<string> prompts = new List<string>
    {
        "What is a good teaching that you learned today?",
        "Something funny that happened to you",
        "What skill did you developed today? If don't fell that developed anything, what you think you could do tommorow?",
        "How did you helped someone today?",
        "How you fell today?"
    };

    public void AddEntry(string prompt, string response)
    {
        entries.Add(new JournalEntry(prompt, response));
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry.ToString());
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine(entry.ToString());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split('|');
                if (parts.Length == 3)
                {
                    entries.Add(new JournalEntry(parts[1].Trim(), parts[2].Trim())
                    {
                        Date = parts[0].Trim()
                    });
                }
            }
        }
    }

    public string GetRandomPrompt()
    {
        Random rnd = new Random();
        return prompts[rnd.Next(prompts.Count)];
    }
}
