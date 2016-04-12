using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoCardGenerator
{
    public class BingoCardGeneratorVM
    {
        private BingoGenerator _bingoGenerator;
        private List<string[]> _cards = new List<string[]>(40);

        public BingoCardGeneratorVM()
        {
            _bingoGenerator = new BingoGenerator(new HashSet<string> { 
                "hangers", "swaddle blanket", "receiving blanket", "carrier", "bottle brush", 
                "pacifier", "wipes", "burp cloth", "bib", "bottle",
                "nursing pillow", "hand sanitizer", "wipes dispenser", "diaper bag", "wash cloth",
                "gas drops",  "diapers", "thermometer", "nasal aspirator", "shampoo",
                "tub", "hooded towel", "bodysuit", "pants", "cap",
                "monitor", "activity gym", "bouncer", "car seat", "lotion",
                "grooming kit", "powder", "changing station", "diaper ointment", "crib bedding",
                "nursing cover", "pacifier holder", "teether", "breast pump", "diapers",
                "jumper", "learning toys", "swing", "book", "gift card", 
                "socks", "shoes", "laundry detergent", "stroller", "breastfeeding accessories",
                "bottle warmer", "bottle sterilizer", "nursing pad", "home safety", "first aid kit",
                "humidifer", "air purifier", "dental care", "bath toys", "bottle drying rack",
                "wall decor", "nursery lighting", "sippy cup", "shirt", "mittens",
                "high chair", "mobile", "rattle", "diaper pail", "gate", "nail clippers",
                "faucet cover", "dishwasher basket", "diaper caddy", "utensils", "wet bag"
            });

            for (int x = 0; x < 40; x++)
            {
                _cards.Add(_bingoGenerator.GenerateUniqueCard());
            }
        }

        public List<string[]> Cards { get { return _cards; } }
    }
}
