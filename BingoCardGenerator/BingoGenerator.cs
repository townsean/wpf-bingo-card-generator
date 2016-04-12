using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoCardGenerator
{
    public class BingoGenerator
    {
        private string[] wordBank;
        private Random random;
        List<string[]> generatedCards;

        public BingoGenerator(HashSet<string> words)
        {
            if (words.Count > 75)
                throw new ArgumentException("Must be 75 unique words");
            wordBank = words.ToArray();
            generatedCards = new List<string[]>();
            random = new Random();
        }

        public string[] GenerateUniqueCard()
        {
            string[] card = new string[25];
            bool[] used = new bool[wordBank.Length - 1];
            for (int i = 0; i < 25; i++)
            {
                if (i == 12)
                {
                    card[i] = "BABY!";
                }
                else
                {
                    var index = random.Next(wordBank.Length - 1);
                    while (used[index])
                    {
                        index = random.Next(wordBank.Length - 1);
                    }
                    used[index] = true;
                    card[i] = wordBank[index];
                }
            }

            foreach (var generated in generatedCards)
            {
                if (card.SequenceEqual(generated))
                {
                    card = GenerateUniqueCard();
                }
            }

            generatedCards.Add(card);
            return card;
        }
    }
}
