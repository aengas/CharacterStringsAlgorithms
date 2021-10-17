using System.Collections.Generic;

namespace CharacterStringsAlgorithms.SpellChecking
{
    public class TrieNode
    {
        public bool IsWord { get; set; }
        
        public Dictionary<char, TrieNode> S { get; }
        
        public TrieNode()
        {
            // Hver node vil ha 52 barn - de fleste vil være tomme
            IsWord = false;
            S = new Dictionary<char, TrieNode>();
            foreach (char c in SpellChecker.AsciiLetters)
            {
                S.Add(c, null);
            }
        }
    }
}