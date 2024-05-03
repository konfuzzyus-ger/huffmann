using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class huffmann
    {
        List<string> enc_alpha = new List<string>();
        List<Node> Alphabet = new List<Node>();
        Node encoding = null;

        public huffmann(List<string> enc_alpha, List<Node> alphabet)
        {
            this.enc_alpha = enc_alpha;
            this.Alphabet = alphabet;
        }

        public void algorithm()
        {
            int c_alphabet = Alphabet.Count;
            int c_enc = enc_alpha.Count;
            while (c_alphabet > c_enc)
            {
                c_alphabet = c_alphabet - (c_enc - 1);
            }
            int dummy_elemts_number = c_enc - c_alphabet;
            for (int i = 0; i < dummy_elemts_number; i++)
            {
                Alphabet.Add(new DummyLeaf(enc_alpha.Count));
            }
            while (Alphabet.Count > 1)
            {
                Alphabet.Sort((x, y) => x.weight.CompareTo(y.weight));
                Node n = new Node(enc_alpha.Count);
                for (int i = 0; i < enc_alpha.Count; i++)
                {
                    if (n.children_limit_reached)
                    {
                        throw new AccessViolationException("Maximal limit of child-objects reached!");
                    }
                    n.addChildren = Alphabet[i];
                }
                foreach (Node c in n.getChildren)
                {
                    Alphabet.Remove(c);
                }
                Alphabet.Add(n);
            }
            if (Alphabet.Count == 1)
            {
                encoding = Alphabet[0];
            }
        }

        public Dictionary<string, string> getEncoding
        {
            get
            {
                if (encoding == null)
                {
                    throw new Exception("Algortihm was not executed yet");
                }
                Dictionary<String, string> result = new Dictionary<string, string>();
                bool final_level = false;
                List<Node> nodes = new List<Node>();
                nodes.Add(encoding);
                while (!final_level || nodes.Count > 0)
                {
                    final_level = true;
                    Node currentNode = nodes[0];
                    nodes.RemoveAt(0);
                    int cnt_enc_alp = 0;
                    foreach (Node c in currentNode.getChildren)
                    {
                        if (cnt_enc_alp >= enc_alpha.Count)
                        {
                            throw new Exception("Something went really bad!");
                        }
                        c.path = currentNode.path + enc_alpha[cnt_enc_alp];
                        if (c.isDummy) { continue; }
                        if (!c.isLeaf)
                        {
                            nodes.Add(c);
                            final_level = false;
                        }
                        else if (c.isLeaf)
                        {
                            result.Add(c.Label, c.path);
                        }
                        cnt_enc_alp++;
                    }
                }

                return result;
            }
        }
    }
}
