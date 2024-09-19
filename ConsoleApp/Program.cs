using System.ComponentModel;

namespace ConsoleApp;

class Program
{
    static List<string> words = [""];
    static List<string> shuffledWords = [""];

    static void Main(string[] args)
    {
        while (true)
        {
            var input = Console.ReadKey(true);

            if (input.Key == ConsoleKey.Backspace)
            {
                try
                {
                    while (string.IsNullOrEmpty(Program.words[^1]) && Program.words.Count > 1)
                    {
                        Program.words.RemoveAt(Program.words.Count - 1);
                    }

                    Program.words[^1] = Program.words[^1].Remove(Program.words[^1].Length - 1);
                }
                catch
                {
                    
                }
            }
            else
            {
                char key = input.KeyChar;

                if (Char.IsLetter(key))
                {
                    Program.words[^1] += key;
                }
                else
                {
                    Program.words.Add(key.ToString());
                    Program.words.Add("");
                }
            }

            Shuffle();
            Console.Write($"\r{new string(' ', Console.WindowWidth)}");
            Console.Write($"\r{string.Join("", Program.shuffledWords)}");
        }
    }

    static void Shuffle()
    {
        Program.shuffledWords = [];

        foreach (string word in Program.words)
        {
            if (word.Length < 4)
            {
                Program.shuffledWords.Add(word);
                continue;
            }
            else
            {
                var chars = new List<Char>(word.ToCharArray()).GetRange(1, word.Length - 2);

                ShuffleList(chars);

                Program.shuffledWords.Add(word[0] + new string(chars.ToArray()) + word[^1]);
            }

        }
    }

    static void ShuffleList<T>(List<T> list)
    {
        Random rng = new Random();

        for (int i = 0; i < list.Count - 1; i++)
        {
            if (rng.Next(2) == 0)
            {
                T temp = list[i];
                list[i] = list[i + 1];
                list[i + 1] = temp;
                i++;
            }
        }
    }
}