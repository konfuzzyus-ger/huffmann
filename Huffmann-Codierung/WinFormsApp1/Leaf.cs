using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Node
    {
        protected bool leaf = false;
        protected bool dummy = false;

        List<Node> children = new List<Node>();
        protected int children_count_max = 2;
        protected string _label = string.Empty;
        protected double _weight = 0;
        string _path = string.Empty;
        public Node(int enc_alphabet_count)
        {
            children_count_max = enc_alphabet_count;
        }

        protected Node()
        {

        }

        public double weight
        {
            get
            {
                if (leaf)
                {
                    return _weight;
                }
                double sum = 0;
                foreach (Node child in children)
                {
                    sum += child.weight;
                }
                return sum;
            }
        }

        public string path
        {
            get { return _path; }
            set { _path = value; }
        }

        public bool children_limit_reached
        {
            get { return leaf ? false : children.Count >= children_count_max; }
        }

        public Node addChildren
        {
            set { children.Add(value); }
        }

        public List<Node> getChildren
        {
            get { return children; }
            set { children = value; }
        }

        public bool isLeaf { get { return leaf; } }
        public bool isDummy { get { return dummy;} }

        public string Label { get { return _label; } }

    }

    internal class Leaf : Node
    {
        public Leaf(int enc_alphabet_count, string Label, double possibility)
        {
            base.children_count_max = enc_alphabet_count;
            base.leaf = true;
            base._label = Label;
            base._weight = possibility;
        }
    }

    internal class DummyLeaf : Node
    {
        public DummyLeaf(int enc_alphabet_count)
        {
            base.children_count_max = enc_alphabet_count;
            base._weight = 0;
            base._label = "Dummy";
            base.leaf = true;
            base.dummy = true;
        }
    }


}
