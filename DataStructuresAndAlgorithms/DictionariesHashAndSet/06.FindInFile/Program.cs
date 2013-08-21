using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FindInFile
{
    class Program
    {
        public static HashSet<Entry> ReadPhones(StreamReader sr)
        {
            HashSet<Entry> entries = new HashSet<Entry>();
            
            while (sr.Peek() >= 0)
            {
                string line;
                line = sr.ReadLine();
                string[] phones = line.Split(new char[] { '|' });
                for (int i = 0; i < phones.Length; i+=3)
                {
                    entries.Add(new Entry(phones[i].Trim(), phones[i + 1].Trim(), phones[i + 2].Trim()));
                }
            }
            return entries;
        }

        public static Queue<Command> ReadCommands(StreamReader sr)
        {
            Queue<Command> commands = new Queue<Command>();
            while (sr.Peek() >= 0)
            {
                string line;
                line = sr.ReadLine();
                var args = line.Split(new char[] { '(' })[1];
                string[] splittedCommands = args.Split(new char[] { ',' });

                if (splittedCommands.Length == 1)
                {
                    commands.Enqueue(new Command(splittedCommands[0].Substring(0, splittedCommands[0].Length-1)));
                }
                else
                {
                    commands.Enqueue(new Command(splittedCommands[0], splittedCommands[1].Substring(0, splittedCommands[1].Length - 1)));
                }
            }

            return commands;
        }

        static void Main(string[] args)
        {
            StreamReader phonesReader = new StreamReader("phones.txt");
            HashSet<Entry> phones = ReadPhones(phonesReader);

            StreamReader commandsReader = new StreamReader("commands.txt");
            Queue<Command> commands = ReadCommands(commandsReader);

            while (commands.Count > 0)
            {
                var command = commands.Peek();
                var matches = phones.Where(x => x.Name == command.Name);
                if (command.Town != null)
                {
                    matches.Union(phones.Where(x => x.Name == command.Name && x.Town == command.Town));
                }
                foreach(var match in matches)
                {
                    Console.WriteLine(match);
                }
                commands.Dequeue();
            }
        }
    }
}
