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
        
        public Form1()
        {
            InitializeComponent();
            
        }
        public static string BiteConverterToString(byte [] data)
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
            try
            {

                DES DESalg = DES.Create();
                encryptTextBox.Text = "Testuojam gyvenimo prasme 123!";
                generatedKeyTextBox.Text = "password";
                string sData = encryptTextBox.Text;
                string key = generatedKeyTextBox.Text;
                DESalg.Key = ASCIIEncoding.ASCII.GetBytes(key);
              //  byte[] keyToByte = StringToBite(key);
                byte[] Data = EncryptTextToMemory(sData, DESalg.Key, DESalg.IV);
                string encryptedText = ASCIIEncoding.ASCII.GetString(Data);
                string IV = BiteConverterToString(DESalg.IV);
                encryptedTextResultTextBox.Text = encryptedText;
                vectorTextBox.Text = IV;
                
            }
            catch (Exception es)
            {
                Console.WriteLine(es.Message);
            }
        }
        private void decryptButton_Click(object sender, EventArgs e)
        {
            DES DESalg = DES.Create();
            string decryptText = decryptTextBox.Text;
            string key = keyToDecyptherTextBox.Text;
            DESalg.Key = ASCIIEncoding.ASCII.GetBytes(key);
            string IV = vectorDecryptTextBox.Text;
            byte[] dData= StringToBite(decryptText);
            byte[] keyToByte = StringToBite(key);
            byte[] IVToByte = StringToBite(IV);
            string decryptedtext = DecryptTextFromMemory(dData, DESalg.Key, IVToByte);
            decryptedTextResultBox.Text = decryptedtext;




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

        private void generatedKeyTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
