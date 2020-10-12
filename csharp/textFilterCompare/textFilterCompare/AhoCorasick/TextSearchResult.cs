namespace AhoCorasick
{
    public class TextSearchResult
    {
        public TextSearchResult(string keyword, int end)
        {
            Success = true;
            Keyword = keyword;
            SearchString = keyword;
            End = end;
            Start = End - Keyword.Length + 1;
        }

        protected TextSearchResult()
        {
            Success = false;
            Start = -1;
            End = -1;
            SearchString = null;
            Keyword = null;
        }

        public bool Success { get; private set; }
        public int Start { get; private set; }
        public int End { get; private set; }
        public string SearchString { get; private set; }
        public string Keyword { get; private set; }
        public static TextSearchResult Empty { get { return new TextSearchResult(); } }

        public override string ToString()
        {
            return Keyword;
        }

    }
}
