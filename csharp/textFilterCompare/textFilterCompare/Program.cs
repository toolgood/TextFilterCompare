using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using AhoCorasick;
using NReco.Text;
using ToolGood.Words;

namespace textFilterCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = LoadKeywords();
            var text = File.ReadAllText("Talk.txt");

            //WordsSearchSearch(list, text);
            WordsSearchExSearch(list, text);
            AhoCorasickDoubleArrayTrieSearch(list, text);

            Console.ReadKey();
        }


        private static void RegexSearch(List<string> list, string txt)
        {
            list = list.OrderBy(q => q).ToList();
            var str = string.Join("|", list);
            str = Regex.Replace(str, @"([\\\.\+\*\-\(\)\[\]\{\}!])", @"\$1");

            var re = new Regex(str, RegexOptions.IgnoreCase);



        }
        private static void RegexTreeSearch(List<string> list, string txt)
        {
            var tf1 = new TrieFilter();
            foreach (var item in list)
            {
                tf1.AddKey(item);
            }
            var str2 = tf1.ToString();
            var re2 = new Regex(str2);



        }
        private static void TrieSearch(List<string> list, string txt)
        {
            var tf1 = new TrieFilter();
            foreach (var item in list)
            {
                tf1.AddKey(item);
            }


        }

        private static void AhoCorasickSearch(List<string> list, string txt)
        {
            AhoCorasickSearch ahoCorasickSearch = new AhoCorasickSearch(list);


        }

        private static void AhoCorasickDoubleArrayTrieSearch(List<string> list, string txt)
        {
            var keywords = new Dictionary<string, string>();
            for (int i = 0; i < list.Count; i++)
            {
                keywords[list[i]] = list[i];
            }
            var matcher = new AhoCorasickDoubleArrayTrie<string>(keywords);
            var fs = File.OpenWrite("AhoCorasickDoubleArrayTrie.dat");
            matcher.Save(fs, true);
            fs.Close();

            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 100000; i++)
            {
                matcher.ParseText(txt);
            }
            watch.Stop();
            Console.WriteLine(" AhoCorasickDoubleArrayTrie: " + watch.ElapsedMilliseconds.ToString("N0") + "ms");
        }

        private static void WordsSearchSearch(List<string> list, string txt)
        {
            WordsSearch wordsSearch = new WordsSearch();
            wordsSearch.SetKeywords(list);

 

            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 100000; i++)
            {
                wordsSearch.FindAll(txt);
            }
            watch.Stop();
            Console.WriteLine("WordsSearch: " + watch.ElapsedMilliseconds.ToString("N0") + "ms");
        }

        private static void WordsSearchExSearch(List<string> list, string txt)
        {
            WordsSearchEx wordsSearch = new WordsSearchEx();
            wordsSearch.SetKeywords(list);
            wordsSearch.Save("WordsSearchEx.dat");

            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 100000; i++)
            {
                wordsSearch.FindAll(txt);
            }
            watch.Stop();
            Console.WriteLine("WordsSearchEx: " + watch.ElapsedMilliseconds.ToString("N0") + "ms");
        }



        private static List<string> LoadKeywords()
        {
            List<string> list = new List<string>();
            using (StreamReader sw = new StreamReader(File.OpenRead("BadWord.txt")))
            {
                string key = sw.ReadLine();
                while (key != null)
                {
                    if (key != string.Empty)
                    {
                        list.Add(key.Split("\t")[0]);
                    }
                    key = sw.ReadLine();
                }
            }
            return list;
        }
    }
}
