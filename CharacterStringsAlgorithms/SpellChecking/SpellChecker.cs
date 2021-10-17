using System;

namespace CharacterStringsAlgorithms.SpellChecking
{
    public class SpellChecker
    {
        private readonly TrieNode m_t;
        public const string AsciiLetters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public SpellChecker(string[] s)
        {
            m_t = Trie(s);
        }

        // Legg et ord til treet
        private TrieNode Add(TrieNode t, string w, int i = 0)
        {
            if (t == null)
            {
                t = new TrieNode();
            }

            if (i == w.Length)
            {
                t.IsWord = true;
            }
            else
            {
                t.S[w[i]] = Add(t.S[w[i]], w, i + 1);
            }

            return t;
        }

        // Bygg treet for ordene i ordboken s
        private TrieNode Trie(string[] s)
        {
            TrieNode t = null;
            foreach (string w in s)
            {
                t = Add(t, w);
            }

            return t;
        }

        // Kjør stavekontroll på et ord mot treet
        public string SpellCheck(string w)
        {
            if (m_t == null)
            {
                throw new Exception("Treet er ikke initialisert");
            }

            int dist = 0;
            while (true)
            {
                string u = Search(m_t, dist, w);
                if (u != null)  // Treff på distanse dist
                {
                    return u;
                }

                dist += 1;
            }
        }

        private string Search(TrieNode t, int dist, string w, int i = 0)
        {
            if (i == w.Length)
            {
                if (t != null && t.IsWord && dist == 0)
                {
                    return "";
                }

                return null;
            }

            if (t == null)
            {
                return null;
            }

            string f = Search(t.S[w[i]], dist, w, i + 1);           // matching
            if (f != null)
            {
                return w[i] + f;
            }

            if (dist == 0)
            {
                return null;
            }

            foreach (char c in AsciiLetters)
            {
                f = Search(t.S[c], dist - 1, w, i);                 // innsetting
                if (f != null)
                {
                    return c + f;
                }

                f = Search(t.S[c], dist - 1, w, i + 1);             // substitusjon
                if (f != null)
                {
                    return c + f;
                }
            }

            return Search(t, dist - 1, w, i + 1);                   // sletting
        }
    }
}