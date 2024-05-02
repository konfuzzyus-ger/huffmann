using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class huffmann
    {
        List<string> enc_alpha = new List<string>();
        List<Node> Alphabet = new List<Node>();

        public huffmann(List<string> enc_alpha, List<Node> alphabet)
        {
            this.enc_alpha = enc_alpha;
            this.Alphabet = alphabet;
        }

        public void algorithm ()
        {
            int c_alphabet = Alphabet.Count;
            int c_enc = enc_alpha.Count;
            while(c_alphabet > c_enc) { 
                c_alphabet = c_alphabet - ( c_enc - 1 );
            }
            int dummy_elemts_number = c_enc - c_alphabet;
            for (int i = 0; i < dummy_elemts_number; i++)
            {
                Alphabet.Add(new DummyLeaf());
            }
            //List<Node> alphabet_ordered = Alphabet.OrderBy(o => o.weight);
        }
    }
}
