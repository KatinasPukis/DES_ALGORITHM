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
        static string key;
        public DES DESalg = DES.Create();
        public Form1()
        {
            InitializeComponent();
            
        }
        public static string BiteConverterToString(byte[] data)
        {
            byte[] bytes = data;
            Console.WriteLine("The byte array: ");
            Console.WriteLine("   {0}\n", BitConverter.ToString(bytes));
            string s = Convert.ToBase64String(bytes);
            Console.WriteLine("The base 64 string:\n   {0}\n", s);

            return s;
        }
        public static byte[] StringToBite(string byteString)
        {

            // Restore the byte array.
            byte[] newBytes = Convert.FromBase64String(byteString);
            Console.WriteLine("The restored byte array: ");
            Console.WriteLine("   {0}\n", BitConverter.ToString(newBytes));
            return newBytes;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            // ENCRYPT BUTTON
            //DES DES = DES.Create();
            //key = generatedKeyTextBox.Text;
            //text = encryptTextBox.Text;
            //DES.Key = ASCIIEncoding.ASCII.GetBytes(key);
            //vectorTextBox.Text =ASCIIEncoding.ASCII.GetString( DES.IV);

            //byte[] data= EncryptText(text, DES.Key);
            //encryptedTextResultTextBox.Text = ASCIIEncoding.ASCII.GetString(data);
            try
            {

                
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
                DESalg.Key = ASCIIEncoding.ASCII.GetBytes(key);

                //  byte[] keyToByte = StringToBite(key);
                byte[] Data = EncryptTextToMemory(sData, DESalg.Key, DESalg.IV);
                string encryptedText = Encoding.ASCII.GetString(Data);
               // string encryptedText = BiteConverterToString(Data);
                string IV = System.Text.Encoding.ASCII.GetString(DESalg.IV);
                 //string IV = BiteConverterToString(DESalg.IV);
                encryptedTextResultTextBox.Text = encryptedText.ToString();
                vectorTextBox.Text = IV.ToString();

            }
            catch (Exception es)
            {
                Console.WriteLine(es.Message);
            }



        }
        private void decryptButton_Click(object sender, EventArgs e)
        {
            // DECRYPT BUTTON
           
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
            DESalg.Key = ASCIIEncoding.ASCII.GetBytes(key);
           // DESalg.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            byte[] dData = Encoding.ASCII.GetBytes(decryptText);
            string decryptedtext = DecryptTextFromMemory(dData, DESalg.Key, DESalg.IV);
            encryptedTextResultTextBox.Text = decryptedtext;


        }
        public static byte[] EncryptTextToMemory(string Data, byte[] Key, byte[] IV)
        {
            try
            {
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();

                // Create a new DES object.
                DES DESalg = DES.Create();

                // Create a CryptoStream using the MemoryStream
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                    DESalg.CreateEncryptor(Key, IV),
                    CryptoStreamMode.Write);

                // Convert the passed string to a byte array.
                byte[] toEncrypt = new ASCIIEncoding().GetBytes(Data);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(toEncrypt, 0, toEncrypt.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the
                // MemoryStream that holds the
                // encrypted data.
                byte[] ret = mStream.ToArray();
                // Close the streams.
                cStream.Close();
                mStream.Close();

                // Return the encrypted buffer.

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
                // Create a new MemoryStream using the passed
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(Data);

                // Create a new DES object.
                DES DESalg = DES.Create();

                // Create a CryptoStream using the MemoryStream
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    DESalg.CreateDecryptor(Key, IV),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[Data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it.
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
            try
            {
                DES.Key = ASCIIEncoding.ASCII.GetBytes(key);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(key);
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
            try
            {
                DES.Key = ASCIIEncoding.ASCII.GetBytes(key);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(key);
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
        

        //public static byte[] EncryptTextToMemory(string Data, byte[] Key, byte[] IV)
        //{
        //    try
        //    {
        //        // Create a MemoryStream.
        //        MemoryStream mStream = new MemoryStream();

        //        // Create a new DES object.
        //        DES DESalg = DES.Create();

        //        // Create a CryptoStream using the MemoryStream
        //        // and the passed key and initialization vector (IV).
        //        CryptoStream cStream = new CryptoStream(mStream,
        //            DESalg.CreateEncryptor(Key, IV),
        //            CryptoStreamMode.Write);

        //        // Convert the passed string to a byte array.
        //        byte[] toEncrypt = new ASCIIEncoding().GetBytes(Data);

        //        // Write the byte array to the crypto stream and flush it.
        //        cStream.Write(toEncrypt, 0, toEncrypt.Length);
        //        cStream.FlushFinalBlock();

        //        // Get an array of bytes from the
        //        // MemoryStream that holds the
        //        // encrypted data.
        //        byte[] ret = mStream.ToArray();
        //        // Close the streams.
        //        cStream.Close();
        //        mStream.Close();
               
        //        // Return the encrypted buffer.
                
        //        return ret;
        //    }
        //    catch (CryptographicException e)
        //    {
        //        Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
        //        return null;
        //    }
        //}
        //public static string DecryptTextFromMemory(byte[] Data, byte[] Key, byte[] IV)
        //{
        //    try
        //    {
        //        // Create a new MemoryStream using the passed
        //        // array of encrypted data.
        //        MemoryStream msDecrypt = new MemoryStream(Data);

        //        // Create a new DES object.
        //        DES DESalg = DES.Create();

        //        // Create a CryptoStream using the MemoryStream
        //        // and the passed key and initialization vector (IV).
        //        CryptoStream csDecrypt = new CryptoStream(msDecrypt,
        //            DESalg.CreateDecryptor(Key, IV),
        //            CryptoStreamMode.Read);

        //        // Create buffer to hold the decrypted data.
        //        byte[] fromEncrypt = new byte[Data.Length];

        //        // Read the decrypted data out of the crypto stream
        //        // and place it into the temporary buffer.
        //        csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

        //        //Convert the buffer into a string and return it.
        //        return new ASCIIEncoding().GetString(fromEncrypt);
        //    }
        //    catch (CryptographicException e)
        //    {
        //        Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
        //        return null;
        //    }
        //}

        private void generatedKeyTextBox_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
