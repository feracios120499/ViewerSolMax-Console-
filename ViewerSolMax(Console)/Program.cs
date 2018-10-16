using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewerSolMax_Console_
{
    class Program
    {
        class ViewPart
        {
            private int startLine = 0;

            public int StartLine
            {
                get { return startLine; }
                set
                {
                    if (value >= 0)
                        if(value<=Lines.Count)
                            startLine = value;
                }
            }

            public int Length { get; set; } = 12;
            public List<string> Lines { get; set; }
            public List<string> GetPartLines()
            {
                List<string> partLines = new List<string>();
                for (int i = StartLine; i <= StartLine + Length; i++)
                {
                    partLines.Add(Lines[i]);
                }
                return partLines;
            }
            public void CommandKey(ConsoleKey key)
            {
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        this.StartLine++;
                        break;
                    case ConsoleKey.UpArrow:
                        this.StartLine--;
                        break;
                    case ConsoleKey.LeftArrow:
                        this.StartLine -= Length;
                        break;
                    case ConsoleKey.RightArrow:
                        this.StartLine += Length;
                        break;
                    default: break;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("1)futures_tick_data.csv");
            Console.WriteLine("2)spot_tick_data.csv");
            var chose=Console.ReadKey(true).KeyChar;
            string path=null;
            switch (chose)
            {
                case '1':
                    path = "futures_tick_data.csv";
                    break;
                case '2':
                    path = "spot_tick_data.csv";
                    break;
                default:
                    Console.WriteLine("Не правильный ввод");
                    Main(null);
                    break;

            }
            var viewer = new ViewPart();
            do
            {
                Console.Clear();
                viewer.Lines = File.ReadAllLines(path).ToList();
                foreach (var item in viewer.GetPartLines())
                {
                    Console.WriteLine(item);
                }
                viewer.CommandKey(Console.ReadKey(true).Key);

            } while (true);
        }
    }
}
