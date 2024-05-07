using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    internal partial class Graph : Form
    {
        public Graph(Node n)
        {
            InitializeComponent();
            treeView1.BeginUpdate();            
            display_node(treeView1.Nodes, n);
            treeView1.EndUpdate();
            treeView1.ExpandAll();
        }

        private void display_node(TreeNodeCollection tree,  Node node)
        {
            if (node.isLeaf) {
                tree.Add($"{node.path} - {node.Label}");
                return;
            }
            if (node.isDummy)
            {
                return;
            }
            TreeNode newNode = new TreeNode(node.path);
            if (string.IsNullOrEmpty(node.path))
            {
                newNode.Text = "Root";
            }
            tree.Add(newNode);
            foreach(Node n in node.getChildren)
            {
                display_node(newNode.Nodes, n);
            }
        }
    }
}
