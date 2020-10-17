using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswoedEncryptor
{
    public partial class TextFileEncryptor : Form
    {
        public TextFileEncryptor()
        {
            InitializeComponent();
        }

        private void EncryptFile(string FileDir)
        {
            
            
                
                string Key = textBox1.Text;
                string strToEncrypt = File.ReadAllText(FileDir);
                string EncryptedStr= Encryptor.StringCipher.Encrypt(strToEncrypt, Key);
                
                File.WriteAllText(FileDir, EncryptedStr);
                
           
            
        }
        string FileName;

        private void button1_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog FileDialog = new OpenFileDialog();
            FileDialog.InitialDirectory="F:";
            FileDialog.Filter = "Text files (*.txt)|*.txt|All files(*.*)|*.*";
            FileDialog.Title = "Select a file for encryption";
            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = FileDialog.FileName;
            }
            label3.Text = FileName;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EncryptFile(FileName);
            MessageBox.Show("Encrypted "+FileName,"Done");
        }
    }
}
