using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangedMan
{
    internal class Words
    {
        //list of easy words
        protected readonly string[] easy = new string[] {"mitochondria", "encyclopedia", "malnurishment", "engineering", "microsoft",
                                                "cellphone", "hippopotamus", "neighborhood", "leatherman",
                                                "shakespeare", "bollocks", "cryptocurrency", "milleniumfalcon", "discombobulated"};
        //list of hard words
        protected readonly string[] hard = new string[] {"effuse","audible", "rend", "virtu", "lingo", "chasm", "robust", "beget", "onset", 
                                                "scythe", "racy", "lucid", "altar", "probe", "whet"};
        public Words() { }

        //returning a random word to guess by choice
        public string GetWord(bool choice)
        {
            int index = GenerateWord();
            if (choice) return easy[index];
            else return hard[index];
        }

        //generating a random number to get a random word from the array
        private int GenerateWord()
        {
            Random random = new Random();
            return random.Next(0, easy.Length - 1);
        }
    }
}
