using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    //general node class
    internal class Node
    {
        //basic specifics of class 
        //Leaf --> no children
        //dumy --> Leaf but without label
        protected bool leaf = false;
        protected bool dummy = false;

        //class variables to hold information
        List<Node> children = new List<Node>();
        protected int children_count_max = 2;
        protected string _label = string.Empty;
        protected double _weight = 0;
        string _path = string.Empty;

        //general constructor to init Node with max children
        public Node(int enc_alphabet_count)
        {
            children_count_max = enc_alphabet_count;
        }

        //empty constructor for derived classes
        protected Node()
        {

        }

        //callculate weight of node
        public double weight
        {
            get
            {
                //if leaf there is nothing to calc
                if (leaf)
                {
                    return _weight;
                }

                //if node we can calculate weight with the weight of our children  
                double sum = 0;
                foreach (Node child in children)
                {
                    sum += child.weight;
                }
                return sum;
            }
        }

        //sets or gets code-word for this node
        public string path
        {
            get { return _path; }
            set { _path = value; }
        }

        //Checks if node has already all possible children it could possibly have
        public bool children_limit_reached
        {
            get { return leaf ? false : children.Count >= children_count_max; }
        }

        //adds a child-node
        public Node addChildren
        {
            set { children.Add(value); }
        }

        //returns or sets list of child nodes
        public List<Node> getChildren
        {
            get { return children; }
            set { children = value; }
        }

        //Functions to return preset stuff and check if class has specific attributes
        public bool isLeaf { get { return leaf; } }
        public bool isDummy { get { return dummy;} }
        public string Label { get { return _label; } }

    }

    //special class for leafs, holds Labels
    internal class Leaf : Node
    {
        //constructor specific for leafs initializes the same as Node but also the possibility(weight) and the label
        public Leaf(string Label, double possibility)
        {
            base.children_count_max = 0;
            base.leaf = true;
            base._label = Label;
            base._weight = possibility;
        }
    }

    //dummy leaf initalizations of Node as dummy leaf but with amount of children which should be zero
    internal class DummyLeaf : Node
    {
        public DummyLeaf()
        {
            base.children_count_max = 0;
            base._weight = 0;
            base._label = "Dummy";
            base.leaf = true;
            base.dummy = true;
        }
    }


}
