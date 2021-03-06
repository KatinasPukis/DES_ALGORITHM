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
            this.decryptButton = new System.Windows.Forms.Button();
            this.generatedKeyTextBox = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.IVTextBox = new System.Windows.Forms.Label();
            this.vectorTextBox = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.ECBcheckBox = new System.Windows.Forms.CheckBox();
            this.CBCcheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // encryptTextBox
            // 
            this.encryptTextBox.Location = new System.Drawing.Point(73, 79);
            this.encryptTextBox.Name = "encryptTextBox";
            this.encryptTextBox.Size = new System.Drawing.Size(257, 61);
            this.encryptTextBox.TabIndex = 0;
            this.encryptTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Text to encrypt/decrypt:";
            // 
            // encrypButton
            // 
            this.encrypButton.Location = new System.Drawing.Point(73, 360);
            this.encrypButton.Name = "encrypButton";
            this.encrypButton.Size = new System.Drawing.Size(116, 43);
            this.encrypButton.TabIndex = 2;
            this.encrypButton.Text = "Encrypt";
            this.encrypButton.UseVisualStyleBackColor = true;
            this.encrypButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // encryptedTextResultTextBox
            // 
            this.encryptedTextResultTextBox.Location = new System.Drawing.Point(73, 293);
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
            this.label2.Location = new System.Drawing.Point(68, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Encrypted text:";
            // 
            // decryptButton
            // 
            this.decryptButton.Location = new System.Drawing.Point(214, 360);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(116, 43);
            this.decryptButton.TabIndex = 9;
            this.decryptButton.Text = "Decrypt";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // generatedKeyTextBox
            // 
            this.generatedKeyTextBox.Location = new System.Drawing.Point(73, 171);
            this.generatedKeyTextBox.Name = "generatedKeyTextBox";
            this.generatedKeyTextBox.Size = new System.Drawing.Size(257, 28);
            this.generatedKeyTextBox.TabIndex = 10;
            this.generatedKeyTextBox.Text = "";
            this.generatedKeyTextBox.TextChanged += new System.EventHandler(this.generatedKeyTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(68, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Key:";
            // 
            // IVTextBox
            // 
            this.IVTextBox.AutoSize = true;
            this.IVTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IVTextBox.Location = new System.Drawing.Point(68, 206);
            this.IVTextBox.Name = "IVTextBox";
            this.IVTextBox.Size = new System.Drawing.Size(40, 25);
            this.IVTextBox.TabIndex = 15;
            this.IVTextBox.Text = "IV:";
            // 
            // vectorTextBox
            // 
            this.vectorTextBox.Location = new System.Drawing.Point(73, 234);
            this.vectorTextBox.Name = "vectorTextBox";
            this.vectorTextBox.Size = new System.Drawing.Size(257, 28);
            this.vectorTextBox.TabIndex = 14;
            this.vectorTextBox.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(83, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(222, 29);
            this.label8.TabIndex = 18;
            this.label8.Text = "DES ALGORITHM";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 419);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(255, 419);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "File";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ECBcheckBox
            // 
            this.ECBcheckBox.AutoSize = true;
            this.ECBcheckBox.Location = new System.Drawing.Point(154, 423);
            this.ECBcheckBox.Name = "ECBcheckBox";
            this.ECBcheckBox.Size = new System.Drawing.Size(47, 17);
            this.ECBcheckBox.TabIndex = 22;
            this.ECBcheckBox.Text = "ECB";
            this.ECBcheckBox.UseVisualStyleBackColor = true;
            // 
            // CBCcheckBox
            // 
            this.CBCcheckBox.AutoSize = true;
            this.CBCcheckBox.Location = new System.Drawing.Point(202, 423);
            this.CBCcheckBox.Name = "CBCcheckBox";
            this.CBCcheckBox.Size = new System.Drawing.Size(47, 17);
            this.CBCcheckBox.TabIndex = 23;
            this.CBCcheckBox.Text = "CBC";
            this.CBCcheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 450);
            this.Controls.Add(this.CBCcheckBox);
            this.Controls.Add(this.ECBcheckBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.IVTextBox);
            this.Controls.Add(this.vectorTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.generatedKeyTextBox);
            this.Controls.Add(this.decryptButton);
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
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.RichTextBox generatedKeyTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label IVTextBox;
        private System.Windows.Forms.RichTextBox vectorTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox ECBcheckBox;
        private System.Windows.Forms.CheckBox CBCcheckBox;
    }
}

