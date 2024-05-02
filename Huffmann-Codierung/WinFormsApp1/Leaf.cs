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
        int children_count_max = 2;
        protected string Label = string.Empty;
        protected double _weight = 0;
        public Node()
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

        public bool children_limit_reached
        {
            get { return leaf ? false : children.Count >= children_count_max; }
        }


    }

    internal class Leaf : Node
    {
        public Leaf(string Label, double possibility)
        {
            base.leaf = true;
            base.Label = Label;
            base._weight = possibility;
        }
    }

    internal class DummyLeaf : Node
    {
        public DummyLeaf()
        {
            base._weight = 0;
            base.Label = "Dummy";
            base.leaf = true;
            base.dummy = true;
        }
    }


}
