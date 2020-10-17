using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswoedEncryptor
{
    public partial class TextFileDecryptor : Form
    {
        public TextFileDecryptor()
        {
            InitializeComponent();
        }

        private void DecryptFile(string FileDir)
        {
            try
            {
                
                string Key = textBox1.Text;
                string strToDecrypt = File.ReadAllText(FileDir);
                string DecryptedString = Encryptor.StringCipher.Decrypt(strToDecrypt, Key);
                    
                File.WriteAllText(FileDir, DecryptedString);
                
                MessageBox.Show("Decrypted " + FileName, "Done");
            }
            catch (CryptographicException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        string FileName;


        
        private void label2_Click(object sender,EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog FileDialog = new OpenFileDialog();
            FileDialog.InitialDirectory = "F:";
            FileDialog.Filter = "Text files (*.txt)|*.txt|All files(*.*)|*.*";
            FileDialog.Title = "Select a file for encryption";
            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = FileDialog.FileName;
            }
            label3.Text = FileName;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        
            DecryptFile(FileName);
            

        }
    }
}
