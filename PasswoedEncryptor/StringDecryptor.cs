using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswoedEncryptor
{
    public partial class StringDecryptor : Form
    {
        public StringDecryptor()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ToDecrypt=textBox1.Text;
            string DecryptionPassword = textBox2.Text;

            string DecryptedProduct=Encryptor.StringCipher.Decrypt(ToDecrypt, DecryptionPassword);

            MessageBox.Show("Decrypted : "+DecryptedProduct, "Decryption success");
        }
        #region WindowsCode
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion


        private void button2_Click(object sender, EventArgs e)
        {
            string ToDecrypt = textBox1.Text;
            string DecryptionPassword = textBox2.Text;

            string DecryptedProduct = Encryptor.StringCipher.Decrypt(ToDecrypt, DecryptionPassword);

            Clipboard.SetText(DecryptedProduct);
            MessageBox.Show("Decrypted : '" + DecryptedProduct + "', Copied to clipboard ", "Decryption success");
        }

        
    }
}
