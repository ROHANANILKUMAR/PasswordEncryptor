using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswoedEncryptor
{
    public partial class StringEncrypt : Form
    {
        public StringEncrypt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string strEncText=textBox1.Text;
            string strEncPass = textBox2.Text;

            string EncryptedText=Encryptor.StringCipher.Encrypt(strEncText,  strEncPass);
            MessageBox.Show(EncryptedText,"Done");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strEncText = textBox1.Text;
            string strEncPass = textBox2.Text;
            string EncryptedText = Encryptor.StringCipher.Encrypt(strEncText, strEncPass);
            Clipboard.SetText(EncryptedText);
            MessageBox.Show(EncryptedText+"  Copied to clipboard", "Done");
        }
    }
}
