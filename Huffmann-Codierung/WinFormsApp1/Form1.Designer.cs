namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button1 = new Button();
            bindingSource1 = new BindingSource(components);
            dataGridView1 = new DataGridView();
            Symbol = new DataGridViewTextBoxColumn();
            Wahrscheinlichkeit = new DataGridViewTextBoxColumn();
            Code = new DataGridViewTextBoxColumn();
            listBox1 = new ListBox();
            button2 = new Button();
            textBox1 = new TextBox();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Berechnen";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Symbol, Wahrscheinlichkeit, Code });
            dataGridView1.Location = new Point(12, 58);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(356, 607);
            dataGridView1.TabIndex = 1;
            // 
            // Symbol
            // 
            Symbol.HeaderText = "Symbol";
            Symbol.Name = "Symbol";
            // 
            // Wahrscheinlichkeit
            // 
            Wahrscheinlichkeit.HeaderText = "Wahrscheinlichkeit";
            Wahrscheinlichkeit.Name = "Wahrscheinlichkeit";
            // 
            // Code
            // 
            Code.HeaderText = "Code";
            Code.Name = "Code";
            Code.ReadOnly = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(706, 58);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(352, 544);
            listBox1.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(706, 642);
            button2.Name = "button2";
            button2.Size = new Size(171, 23);
            button2.TabIndex = 3;
            button2.Text = "hinzufügen";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(706, 613);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(352, 23);
            textBox1.TabIndex = 4;
            // 
            // button3
            // 
            button3.Location = new Point(883, 642);
            button3.Name = "button3";
            button3.Size = new Size(175, 23);
            button3.TabIndex = 5;
            button3.Text = "löschen";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1070, 730);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(listBox1);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private BindingSource bindingSource1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Symbol;
        private DataGridViewTextBoxColumn Wahrscheinlichkeit;
        private DataGridViewTextBoxColumn Code;
        private ListBox listBox1;
        private Button button2;
        private TextBox textBox1;
        private Button button3;
    }
}
