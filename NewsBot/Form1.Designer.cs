namespace NewsBot
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
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            keywordListBox = new TextBox();
            label1 = new Label();
            button3 = new Button();
            keywordInputBox = new TextBox();
            button4 = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(30, 52);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Start_Click;
            // 
            // button2
            // 
            button2.Location = new Point(130, 52);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 1;
            button2.Text = "stop";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Stop_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(445, 53);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(917, 553);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += LogBox;
            // 
            // textBox2
            // 
            keywordListBox.Location = new Point(30, 267);
            keywordListBox.Multiline = true;
            keywordListBox.Name = "textBox2";
            keywordListBox.ReadOnly = true;
            keywordListBox.ScrollBars = ScrollBars.Both;
            keywordListBox.Size = new Size(388, 339);
            keywordListBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 244);
            label1.Name = "label1";
            label1.Size = new Size(94, 20);
            label1.TabIndex = 4;
            label1.Text = "Keyword List";
            // 
            // button3
            // 
            button3.Location = new Point(302, 196);
            button3.Name = "button3";
            button3.Size = new Size(116, 29);
            button3.TabIndex = 5;
            button3.Text = "Keyword Add";
            button3.UseVisualStyleBackColor = true;
            button3.Click += KeywordAdd_Click;
            // 
            // textBox3
            // 
            keywordInputBox.Location = new Point(30, 198);
            keywordInputBox.Name = "textBox3";
            keywordInputBox.Size = new Size(253, 27);
            keywordInputBox.TabIndex = 6;
            // 
            // button4
            // 
            button4.Location = new Point(324, 232);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 7;
            button4.Text = "Delete";
            button4.UseVisualStyleBackColor = true;
            button4.Click += KeywordRemove_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(445, 30);
            label2.Name = "label2";
            label2.Size = new Size(34, 20);
            label2.TabIndex = 8;
            label2.Text = "Log";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1386, 620);
            Controls.Add(label2);
            Controls.Add(button4);
            Controls.Add(keywordInputBox);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(keywordListBox);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private TextBox keywordListBox;
        private Label label1;
        private Button button3;
        private TextBox keywordInputBox;
        private Button button4;
        private Label label2;
    }
}
