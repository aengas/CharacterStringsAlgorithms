using System;
using System.Collections.Generic;

namespace CharacterStringsAlgorithms.Anagrams
{
    public class AnagramCalculator
    {
        public static List<HashSet<string>> Anagrams(string[] input)               // input er en tabell med strenger
        {
            var d = new Dictionary<string, HashSet<string>>();              // mapper input til en liste med ord med signatur s
            foreach (string word in input)                                  // grupperer ord i hendhold til signaturen
            {
                string signature = Sorted(word);                            // kalkuler signaturen
                if (d.ContainsKey(signature))
                {
                    if (!d[signature].Contains(word))                       // ikke legg til ordet hvis det allerede er der
                    {
                        d[signature].Add(word);                             // legg til et ord til den eksisterende signaturen
                    }
                }
                else
                {
                    d[signature] = new HashSet<string> { word };            // legg til en ny signatur og dens første ord
                }
                
            }

            var returnList = new List<HashSet<string>>();
            // hent ut anagrammer, der man ignorerer anagramgrupper med størrelse 1
            foreach (KeyValuePair<string, HashSet<string>> s in d)
            {
                if (s.Value.Count > 1)
                {
                    returnList.Add(s.Value);
                }
            }

            return returnList;
        }

        private static string Sorted(string input)
        {
            char[] characters = input.ToCharArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}
