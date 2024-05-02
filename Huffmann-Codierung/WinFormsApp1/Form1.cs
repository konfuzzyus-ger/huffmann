namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Add("0");
            listBox1.Items.Add("1");
            listBox1.Items.Add("2");

            string[][] data = [
                ["a", "0,1", ""],
                ["b", "0,2", ""],
                ["c", "0,5", ""],
                ["d", "0.2", ""]
                ];
            foreach (string[] datarow in data ) {
                dataGridView1.Rows.Add(datarow);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selected = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(selected);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRowCollection Rows = dataGridView1.Rows;
            List<Node> Nodes = new List<Node>();
            foreach (DataGridViewRow row in Rows)
            {
                string Label = (string)row.Cells[0].Value;
                string dbl = (string)row.Cells[1].Value;
                if (dbl == null)
                {
                    continue;
                }
                dbl = dbl.Replace(".", ",");
                if (!double.TryParse(dbl, out double posibility))
                {
                    continue;
                }
                if (posibility > 1)
                {
                    continue;
                }
                Leaf l = new Leaf(Label, posibility);
                Nodes.Add(l); 
            }
            List<string> enc_alpha = new List<string>();
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                enc_alpha.Add(listBox1.Items[i].ToString());
            }
            huffmann h = new huffmann(enc_alpha, Nodes);
            h.algorithm();
            return;
        }
    }
}
