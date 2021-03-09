using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace DES_ALGORITHM
{
    public partial class Form1 : Form
    {
        Encoding encoding = Encoding.GetEncoding("437");
        static string key;
        static string IV;

       
        public Form1()
        {
            InitializeComponent();
            
        }
       
        public void button1_Click(object sender, EventArgs e)
        {
            // ENCRYPT BUTTON
            try
            {

                DES DESalg = DES.Create();
                string sData = encryptTextBox.Text;
                string key = generatedKeyTextBox.Text;
                if(ECBcheckBox.Checked)
                {
                    DESalg.Mode = CipherMode.ECB;
                }
                if (CBCcheckBox.Checked)
                {
                    DESalg.Mode = CipherMode.CBC;
                }
                if(encryptTextBox.Text!="")
                {
                    if(key.Length>=8 && key.Length<=8)
                    {
                DESalg.Key = encoding.GetBytes(key);
                byte[] Data = EncryptTextToMemory(sData, DESalg.Key, DESalg.IV);
                string encryptedText = encoding.GetString(Data);
               
                string IV = encoding.GetString(DESalg.IV);
                 
                encryptedTextResultTextBox.Text = encryptedText.ToString();
                vectorTextBox.Text = IV.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Error key lenght is :" + key.Length +'\n'+ "Key has to be 8 characters long!");
                    }

                }
                else
                {
                    MessageBox.Show("Error text is empty!");
                }

            }
            catch (Exception es)
            {
                Console.WriteLine(es.Message);
            }



        }
        private void decryptButton_Click(object sender, EventArgs e)
        {
            // DECRYPT BUTTON
            DES DESalg = DES.Create();
            if (ECBcheckBox.Checked)
            {
                DESalg.Mode = CipherMode.ECB;
            }
            if (CBCcheckBox.Checked)
            {
                DESalg.Mode = CipherMode.CBC;
            }
            string decryptText = encryptTextBox.Text;
            string key = generatedKeyTextBox.Text;
            string IV = vectorTextBox.Text;
            DESalg.Key = encoding.GetBytes(key);
            DESalg.IV = encoding.GetBytes(IV);
            byte[] dData = encoding.GetBytes(decryptText);
            string decryptedtext = DecryptTextFromMemory(dData, DESalg.Key, DESalg.IV);
            encryptedTextResultTextBox.Text = decryptedtext;


        }
        public static byte[] EncryptTextToMemory(string Data, byte[] Key, byte[] IV)
        {
            try
            {
                // sukuriamas memory stream
                MemoryStream mStream = new MemoryStream();

                // naujas des obejktas
                DES DESalg = DES.Create();

                // sukuriamas cryptostream naudojant memeorystream
                // perduodamas raktas bei IV vektorius
                CryptoStream cStream = new CryptoStream(mStream,
                    DESalg.CreateEncryptor(Key, IV),
                    CryptoStreamMode.Write);

                // perduota string paverciame i byte array
                byte[] toEncrypt = new ASCIIEncoding().GetBytes(Data);

                // byte array perasom i crypto stream
                cStream.Write(toEncrypt, 0, toEncrypt.Length);
                cStream.FlushFinalBlock();

                // Gauti masyva bytu is memory stream kuris laiko uzsifruota data

                byte[] ret = mStream.ToArray();
                // Close the streams.
                cStream.Close();
                mStream.Close();

                // Return the uzsifruotas buffer

                return ret;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }
        public static string DecryptTextFromMemory(byte[] Data, byte[] Key, byte[] IV)
        {
            try
            {
                MemoryStream msDecrypt = new MemoryStream(Data);
                DES DESalg = DES.Create();
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    DESalg.CreateDecryptor(Key, IV),
                    CryptoStreamMode.Read);
                byte[] fromEncrypt = new byte[Data.Length];
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                return new ASCIIEncoding().GetString(fromEncrypt);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            key = generatedKeyTextBox.Text;
            if(openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                string source = openFileDialog1.FileName;
                saveFileDialog1.Filter = "des files |*.des";
                if(saveFileDialog1.ShowDialog()==DialogResult.OK)
                {
                    string destination = saveFileDialog1.FileName;
                    EncryptFile(source, destination, key);
                }

            }
        }
        private void EncryptFile(string source, string destination , string key)
        {
            FileStream fsInput = new FileStream(source, FileMode.Open, FileAccess.Read);
            FileStream fsEncrypted = new FileStream(destination, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            IV = vectorTextBox.Text;
            if (ECBcheckBox.Checked)
            {
                DES.Mode = CipherMode.ECB;
            }
            if (CBCcheckBox.Checked)
            {
                DES.Mode = CipherMode.CBC;
            }
            try
            {
                DES.Key = ASCIIEncoding.ASCII.GetBytes(key);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(IV);
                ICryptoTransform desencrypt = DES.CreateEncryptor();
                CryptoStream cryptoStream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);
                byte[] byteInput = new byte[fsInput.Length - 0];
                fsInput.Read(byteInput, 0, byteInput.Length);
                cryptoStream.Write(byteInput, 0, byteInput.Length);
                cryptoStream.Close();

            }
            catch
            {
                MessageBox.Show("Error ENCRYPT");
                return;
            }
            fsInput.Close();
            fsEncrypted.Close();
        }
        private void DecryptFile(string source, string destination, string key)
        {

            FileStream fsInput = new FileStream(source, FileMode.Open, FileAccess.Read);
            FileStream fsEncrypted = new FileStream(destination, FileMode.Create, FileAccess.Write);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            IV = vectorTextBox.Text;
            if (ECBcheckBox.Checked)
            {
                DES.Mode = CipherMode.ECB;
            }
            if (CBCcheckBox.Checked)
            {
                DES.Mode = CipherMode.CBC;
            }
            try
            {
                DES.Key = ASCIIEncoding.ASCII.GetBytes(key);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(IV);
                ICryptoTransform desencrypt = DES.CreateDecryptor();
                CryptoStream cryptoStream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);
                byte[] byteInput = new byte[fsInput.Length - 0];
                fsInput.Read(byteInput, 0, byteInput.Length);
                cryptoStream.Write(byteInput, 0, byteInput.Length);
                cryptoStream.Close();

            }
            catch
            {
                MessageBox.Show("Error Decrpyt");
                return;
            }
            fsInput.Close();
            fsEncrypted.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            key = generatedKeyTextBox.Text;
            openFileDialog1.Filter = "des files |*.des";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string source = openFileDialog1.FileName;
                saveFileDialog1.Filter = "txt files |*.txt";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string destination = saveFileDialog1.FileName;
                    DecryptFile(source, destination, key);
                }
            }
        }
        

        private void generatedKeyTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
