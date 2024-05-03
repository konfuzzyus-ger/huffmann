namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        Dictionary<string, string> _encoding = null;
        public Form1()
        {
            InitializeComponent();

            //Initialize with data for easy testing
            listBox1.Items.Add("0");
            listBox1.Items.Add("1");

            textBox2.Text = "ACAACTTCGTCGCGCACATCCA";

            string[][] data = [
                ["AC", "0,09", ""],
                ["AA", "0,09", ""],
                ["CT", "0,09", ""],
                ["TC", "0,18", ""],
                ["GT", "0,09", ""],
                ["CG", "0.18", ""],
                ["CA", "0.28", ""]];
            foreach (string[] datarow in data)
            {
                dataGridView1.Rows.Add(datarow);
            }
        }

        //add symbol for encoding
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
            textBox1.Clear();
        }

        //remove symbol for encoding
        private void button3_Click(object sender, EventArgs e)
        {
            int selected = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(selected);
        }

        //generate encoding-code
        private void button1_Click(object sender, EventArgs e)
        {
            //Read Alphabet to encode to
            List<string> enc_alpha = new List<string>();
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                enc_alpha.Add(listBox1.Items[i].ToString());
            }

            //read symbols which will be encoded
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

            //Initialize huffmann-code-class and execute generation of code
            huffmann h = new huffmann(enc_alpha, Nodes);
            h.algorithm();

            //show and save results
            Dictionary<string, string> encoding = h.getEncoding;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string letter = (string)dataGridView1.Rows[i].Cells[0].Value;
                if (letter == null)
                {
                    continue;
                }
                dataGridView1.Rows[i].Cells[2].Value = encoding[letter];
            }
            _encoding = encoding;
            Encode.Enabled = true;
        }

        //encode given text with generated code
        private void button4_Click(object sender, EventArgs e)
        {
            string input = textBox2.Text;
            string output = string.Empty;
            while(input.Length > 0)
            {
                foreach (string x in _encoding.Keys)
                {
                    if (input.StartsWith(x)) {
                        output += _encoding[x];
                        input = input.Substring(x.Length);
                        break;
                    }
                }
            }
            textBox3.Text = output;
        }
    }
}
