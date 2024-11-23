using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    class Reference
    {
        public string ReferenceText { get; private set; }

        public Reference(string reference)
        {
            ReferenceText = reference;
        }

        public override string ToString()
        {
            return ReferenceText;
        }
    }

    class Word
    {
        public string Text { get; private set; }
        public bool IsHidden { get; private set; }

        public Word(string text)
        {
            Text = text;
            IsHidden = false;
        }

        public void Hide()
        {
            IsHidden = true;
        }

        public string Display()
        {
            return IsHidden ? new string('_', Text.Length) : Text;
        }
    }

    class Scripture
    {
        public Reference Reference { get; private set; }
        private List<Word> Words { get; set; }

        public Scripture(string reference, string text)
        {
            Reference = new Reference(reference);
            Words = text.Split(' ').Select(word => new Word(word)).ToList();
        }

        public void HideRandomWord()
        {
            var unhiddenWords = Words.Where(w => !w.IsHidden).ToList();
            if (unhiddenWords.Any())
            {
                var random = new Random();
                var wordToHide = unhiddenWords[random.Next(unhiddenWords.Count)];
                wordToHide.Hide();
            }
        }

        public bool AreAllWordsHidden()
        {
            return Words.All(w => w.IsHidden);
        }

        public string Display()
        {
            return $"{Reference}\n" + string.Join(" ", Words.Select(w => w.Display()));
        }
    }

    class ScriptureMemorizer
    {
        private Scripture _scripture;

        public ScriptureMemorizer(Scripture scripture)
        {
            _scripture = scripture;
        }

        public void Start()
        {
            while (!_scripture.AreAllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(_scripture.Display());
                Console.WriteLine("Press Enter to hide a word or type 'quit' to exit: ");
                var userInput = Console.ReadLine();

                if (userInput?.ToLower() == "quit")
                {
                    break;
                }

                _scripture.HideRandomWord();
            }
            Console.Clear();
            Console.WriteLine(_scripture.Display());
            Console.WriteLine("All words are now hidden. Goodbye!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string scriptureText = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
            string scriptureReference = "John 3:16";

            var scripture = new Scripture(scriptureReference, scriptureText);
            var memorizer = new ScriptureMemorizer(scripture);
            memorizer.Start();
        }
    }
}