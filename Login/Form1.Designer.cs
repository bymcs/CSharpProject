namespace LoginEkrani
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
            label1 = new Label();
            label2 = new Label();
            textBoxKullaniciAdi = new TextBox();
            textBoxSifre = new TextBox();
            buttonKaydol = new Button();
            buttonGiris = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 31);
            label1.Name = "label1";
            label1.Size = new Size(21, 15);
            label1.TabIndex = 0;
            label1.Text = "ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 60);
            label2.Name = "label2";
            label2.Size = new Size(23, 15);
            label2.TabIndex = 1;
            label2.Text = "PS:";
            // 
            // textBoxKullaniciAdi
            // 
            textBoxKullaniciAdi.Location = new Point(65, 28);
            textBoxKullaniciAdi.Name = "textBoxKullaniciAdi";
            textBoxKullaniciAdi.Size = new Size(147, 23);
            textBoxKullaniciAdi.TabIndex = 2;
            // 
            // textBoxSifre
            // 
            textBoxSifre.Location = new Point(65, 57);
            textBoxSifre.Name = "textBoxSifre";
            textBoxSifre.Size = new Size(147, 23);
            textBoxSifre.TabIndex = 3;
            // 
            // buttonKaydol
            // 
            buttonKaydol.Location = new Point(38, 98);
            buttonKaydol.Name = "buttonKaydol";
            buttonKaydol.Size = new Size(75, 23);
            buttonKaydol.TabIndex = 4;
            buttonKaydol.Text = "Kaydol";
            buttonKaydol.UseVisualStyleBackColor = true;
            buttonKaydol.Click += buttonKaydol_Click;
            // 
            // buttonGiris
            // 
            buttonGiris.Location = new Point(137, 98);
            buttonGiris.Name = "buttonGiris";
            buttonGiris.Size = new Size(75, 23);
            buttonGiris.TabIndex = 5;
            buttonGiris.Text = "Giriş";
            buttonGiris.UseVisualStyleBackColor = true;
            buttonGiris.Click += buttonGiris_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 149);
            Controls.Add(buttonGiris);
            Controls.Add(buttonKaydol);
            Controls.Add(textBoxSifre);
            Controls.Add(textBoxKullaniciAdi);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBoxKullaniciAdi;
        private TextBox textBoxSifre;
        private Button buttonKaydol;
        private Button buttonGiris;
    }
}