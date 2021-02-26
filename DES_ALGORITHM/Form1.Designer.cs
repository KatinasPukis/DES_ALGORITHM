namespace DES_ALGORITHM
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.encryptTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.encrypButton = new System.Windows.Forms.Button();
            this.encryptedTextResultTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.decryptTextBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.decryptedTextResultBox = new System.Windows.Forms.RichTextBox();
            this.decryptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // encryptTextBox
            // 
            this.encryptTextBox.Location = new System.Drawing.Point(70, 53);
            this.encryptTextBox.Name = "encryptTextBox";
            this.encryptTextBox.Size = new System.Drawing.Size(257, 61);
            this.encryptTextBox.TabIndex = 0;
            this.encryptTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Text to encrypt:";
            // 
            // encrypButton
            // 
            this.encrypButton.Location = new System.Drawing.Point(126, 312);
            this.encrypButton.Name = "encrypButton";
            this.encrypButton.Size = new System.Drawing.Size(116, 43);
            this.encrypButton.TabIndex = 2;
            this.encrypButton.Text = "Encrypt";
            this.encrypButton.UseVisualStyleBackColor = true;
            this.encrypButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // encryptedTextResultTextBox
            // 
            this.encryptedTextResultTextBox.Location = new System.Drawing.Point(70, 198);
            this.encryptedTextResultTextBox.Name = "encryptedTextResultTextBox";
            this.encryptedTextResultTextBox.ReadOnly = true;
            this.encryptedTextResultTextBox.Size = new System.Drawing.Size(257, 61);
            this.encryptedTextResultTextBox.TabIndex = 3;
            this.encryptedTextResultTextBox.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Encrypted text:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(424, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Text to decrypt:";
            // 
            // decryptTextBox
            // 
            this.decryptTextBox.Location = new System.Drawing.Point(429, 53);
            this.decryptTextBox.Name = "decryptTextBox";
            this.decryptTextBox.Size = new System.Drawing.Size(257, 61);
            this.decryptTextBox.TabIndex = 5;
            this.decryptTextBox.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(424, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Decrypted text:";
            // 
            // decryptedTextResultBox
            // 
            this.decryptedTextResultBox.Location = new System.Drawing.Point(429, 198);
            this.decryptedTextResultBox.Name = "decryptedTextResultBox";
            this.decryptedTextResultBox.ReadOnly = true;
            this.decryptedTextResultBox.Size = new System.Drawing.Size(257, 61);
            this.decryptedTextResultBox.TabIndex = 7;
            this.decryptedTextResultBox.Text = "";
            // 
            // decryptButton
            // 
            this.decryptButton.Location = new System.Drawing.Point(485, 312);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(116, 43);
            this.decryptButton.TabIndex = 9;
            this.decryptButton.Text = "Decrypt";
            this.decryptButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.decryptButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.decryptedTextResultBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.decryptTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.encryptedTextResultTextBox);
            this.Controls.Add(this.encrypButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.encryptTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox encryptTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button encrypButton;
        private System.Windows.Forms.RichTextBox encryptedTextResultTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox decryptTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox decryptedTextResultBox;
        private System.Windows.Forms.Button decryptButton;
    }
}

