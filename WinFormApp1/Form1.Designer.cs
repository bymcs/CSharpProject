namespace WinFormApp1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnRead = new Button();
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            btnRead2 = new Button();
            SuspendLayout();
            // 
            // btnRead
            // 
            btnRead.Location = new Point(12, 32);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(433, 35);
            btnRead.TabIndex = 0;
            btnRead.Text = "Read DB and Write";
            btnRead.UseVisualStyleBackColor = true;
            btnRead.Click += btnRead_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 87);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(433, 308);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(477, 87);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(424, 308);
            richTextBox2.TabIndex = 3;
            richTextBox2.Text = "";
            // 
            // btnRead2
            // 
            btnRead2.Location = new Point(477, 32);
            btnRead2.Name = "btnRead2";
            btnRead2.Size = new Size(424, 35);
            btnRead2.TabIndex = 4;
            btnRead2.Text = "Read Excel and Write";
            btnRead2.UseVisualStyleBackColor = true;
            btnRead2.Click += btnRead2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(917, 405);
            Controls.Add(btnRead2);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            Controls.Add(btnRead);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "DB READ and WRITE APP";
            ResumeLayout(false);
        }

        #endregion

        private Button btnRead;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private Button btnRead2;
    }
}