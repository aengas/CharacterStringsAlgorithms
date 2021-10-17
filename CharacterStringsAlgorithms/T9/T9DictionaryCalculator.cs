using System;
using System.Collections.Generic;

namespace CharacterStringsAlgorithms.T9
{
    public class T9DictionaryCalculator
    {
        private const string t9 = "22233344455566677778889999";
        //                         abcdefghijklmnopqrstuvwxyz   mapping på telefonen

        private readonly Dictionary<string, string> m_prop;

        public T9DictionaryCalculator(Dictionary<string, int> dic)
        {
            m_prop = PredictiveText(dic);
        }

        public static char LetterToDigit(char x)
        {
            if (x < 'a' || x > 'z')
            {
                throw new ArgumentException("x is not a digit", nameof(x));
            }

            return t9[x - 'a'];
        }

        public static string CodeWord(string word)
        {
            string returnString = "";
            for (int i = 0; i < word.Length; i++)
            {
                returnString += LetterToDigit(word[i]);
            }

            return returnString;
        }

        public static Dictionary<string, string> PredictiveText(Dictionary<string, int> dic)
        {
            // totalWeight[p] = total vekt av ord som har prefix p
            var totalWeight = new Dictionary<string, int>();
            foreach (KeyValuePair<string, int> wordWeight in dic)
            {
                string word = wordWeight.Key;
                int weight = wordWeight.Value;
                string prefix = "";
                foreach (char x in word)
                {
                    prefix += x;
                    if (totalWeight.ContainsKey(prefix))
                    {
                        totalWeight[prefix] += weight;
                    }
                    else
                    {
                        totalWeight[prefix] = weight;
                    }
                }
            }
            
            // prop[s] = prefix som skal vises for s
            var prop = new Dictionary<string, string>();
            foreach (string prefix in totalWeight.Keys)
            {
                string code = CodeWord(prefix);
                if (!prop.ContainsKey(code) || totalWeight[prop[code]] < totalWeight[prefix])
                {
                    prop[code] = prefix;
                }
            }

            return prop;
        }

        public string Propose(string seq)
        {
            if (m_prop.ContainsKey(seq))
            {
                return m_prop[seq];
            }

            return "MANUALLY";
        }
    }
}