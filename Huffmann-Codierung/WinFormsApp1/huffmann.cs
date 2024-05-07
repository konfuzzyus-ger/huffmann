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
        //variables for encoding alphabet, alphabet which will be encoded based on possibility and the final encoding
        List<string> enc_alpha = new List<string>();
        List<Node> Alphabet = new List<Node>();
        Node encoding = null;

        //initializes class with encoding alphabet and alphabet with possibilites
        public huffmann(List<string> enc_alpha, List<Node> alphabet)
        {
            this.enc_alpha = enc_alpha;
            this.Alphabet = alphabet;
        }

        //executes huffman algorithm
        public void algorithm()
        {
            //calculate the number of dummy leafs needed
            int c_alphabet = Alphabet.Count;
            int c_enc = enc_alpha.Count;
            while (c_alphabet > c_enc)
            {
                c_alphabet = c_alphabet - (c_enc - 1);
            }
            int dummy_elemts_number = c_enc - c_alphabet;

            //generate dummy leafes
            for (int i = 0; i < dummy_elemts_number; i++)
            {
                Alphabet.Add(new DummyLeaf());
            }

            //huffman algrithm
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

            //store encoding as tree
            if (Alphabet.Count == 1)
            {
                encoding = Alphabet[0];
            }
        }

        //generate Code list by alphabet to be encoded
        public Dictionary<string, string> getEncoding
        {
            get
            {
                //check if encoding exists
                if (encoding == null)
                {
                    throw new Exception("Algortihm was not executed yet");
                }

                //bread first search (bfs) through tree
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
                        //check if symbols are left otherwise something went wrong
                        if (cnt_enc_alp >= enc_alpha.Count)
                        {
                            throw new Exception("Something went really bad!");
                        }

                        //assign path to current selected children
                        c.path = currentNode.path + enc_alpha[cnt_enc_alp];

                        //ignore dummy nodes
                        if (c.isDummy) { continue; }

                        //add children if they are nodes to list of nodes to search
                        if (!c.isLeaf)
                        {
                            nodes.Add(c);
                            final_level = false;
                        } //if Lead then direct add to result
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

        public Node getGraph
        {
            get
            {
                return encoding;
            }
        }
    }
}
