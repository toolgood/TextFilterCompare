using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using AhoCorasick;
using ToolGood.Words;

namespace textFilterCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = LoadKeywords();
            var text = File.ReadAllText("Talk.txt");

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

        private static void WordsSearchSearch(List<string> list, string txt)
        {
            WordsSearch wordsSearch = new WordsSearch();
            wordsSearch.SetKeywords(list);


        }

        private static void WordsSearchExSearch(List<string> list, string txt)
        {
            WordsSearchEx wordsSearch = new WordsSearchEx();
            wordsSearch.SetKeywords(list);


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
                        list.Add(key);
                    }
                    key = sw.ReadLine();
                }
            }
            return list;
        }
    }
}
