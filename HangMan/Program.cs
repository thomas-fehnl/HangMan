using System;
using System.IO;
using System.Linq;

namespace HangMan
{
    class Program
    {
        public static void Main(string[] args)
        {
            GameLoop();
        }

        private static void GameLoop()
        {
            var wordList = File.ReadAllLines(@"C:\temp\words.txt").ToList();
            var rand = new Random();

            while (wordList.Count > 0)
            {
                var cnt = 0;
                var misses = string.Empty;
                var pos = rand.Next(wordList.Count);
                var word = wordList[pos].ToUpper();
                var sw = new StringWriter();
                for (var i = 0; i < word.Length; i++)
                    sw.Write("_ ");
                var mask = sw.ToString().ToCharArray();
                wordList.RemoveAt(pos);

                while (true)
                {
                    Console.Clear();
                    //Console.WriteLine(word); Console.WriteLine();
                    Console.WriteLine(mask); Console.WriteLine();
                    DisplayScore(cnt);
                    Console.WriteLine(misses); Console.WriteLine();
                    var ch = char.ToUpper(Console.ReadKey(true).KeyChar);
                    if (!misses.Contains(ch))
                    {
                        if (word.Contains(ch))
                        {
                            for (var i = 0; i < word.Length; i++)
                                if (word[i] == ch)
                                    mask[i * 2] = ch;
                        }
                        else
                        {
                            misses += ch + " ";
                            cnt++;
                        }
                        if (!mask.Contains('_'))
                        {
                            Console.Clear();
                            Console.WriteLine("BINGO!"); Console.WriteLine();
                            Console.WriteLine(mask);
                            DisplayScore(cnt);
                            Console.ReadKey(true);
                            break;
                        }
                        if (cnt >= 11)
                        {
                            Console.Clear();
                            Console.WriteLine("LEIDER VERLOREN."); Console.WriteLine();
                            Console.WriteLine(word); Console.WriteLine();
                            Console.WriteLine(mask); Console.WriteLine();
                            DisplayScore(cnt);
                            Console.WriteLine(misses);
                            Console.ReadKey(true);
                            break;
                        }
                    }
                }
            }
        }

        private static void DisplayScore(int score)
        {
            switch (score)
            {
                case 0:
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    break;
                case 1:
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(@"/ \");
                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(@" |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@"/ \");
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine(@" _____");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@"/ \");
                    Console.WriteLine();
                    break;
                case 4:
                    Console.WriteLine();
                    Console.WriteLine(@" _____");
                    Console.WriteLine(@" |/");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@"/ \");
                    Console.WriteLine();
                    break;
                case 5:
                    Console.WriteLine();
                    Console.WriteLine(@" _____");
                    Console.WriteLine(@" |/  |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@"/ \");
                    Console.WriteLine();
                    break;
                case 6:
                    Console.WriteLine();
                    Console.WriteLine(@" _____");
                    Console.WriteLine(@" |/  |");
                    Console.WriteLine(@" |   O");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@"/ \");
                    Console.WriteLine();
                    break;
                case 7:
                    Console.WriteLine();
                    Console.WriteLine(@" _____");
                    Console.WriteLine(@" |/  |");
                    Console.WriteLine(@" |   O");
                    Console.WriteLine(@" |   |");
                    Console.WriteLine(@" |   |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@"/ \");
                    Console.WriteLine();
                    break;
                case 8:
                    Console.WriteLine();
                    Console.WriteLine(@" _____");
                    Console.WriteLine(@" |/  |");
                    Console.WriteLine(@" |   O");
                    Console.WriteLine(@" |  /|");
                    Console.WriteLine(@" |   |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@"/ \");
                    Console.WriteLine();
                    break;
                case 9:
                    Console.WriteLine();
                    Console.WriteLine(@" _____");
                    Console.WriteLine(@" |/  |");
                    Console.WriteLine(@" |   O");
                    Console.WriteLine(@" |  /|\");
                    Console.WriteLine(@" |   |");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@"/ \");
                    Console.WriteLine();
                    break;
                case 10:
                    Console.WriteLine();
                    Console.WriteLine(@" _____");
                    Console.WriteLine(@" |/  |");
                    Console.WriteLine(@" |   O");
                    Console.WriteLine(@" |  /|\");
                    Console.WriteLine(@" |   |");
                    Console.WriteLine(@" |  /");
                    Console.WriteLine(@"/ \");
                    Console.WriteLine();
                    break;
                case 11:
                    Console.WriteLine();
                    Console.WriteLine(@" _____");
                    Console.WriteLine(@" |/  |");
                    Console.WriteLine(@" |   O");
                    Console.WriteLine(@" |  /|\");
                    Console.WriteLine(@" |   |");
                    Console.WriteLine(@" |  / \");
                    Console.WriteLine(@"/ \");
                    Console.WriteLine();
                    break;
                default:
                    throw new NotSupportedException(score.ToString());
            }
        }
    }
}
