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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringEncrypt TextEncryption = new StringEncrypt();
            TextEncryption.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringDecryptor Decryption = new StringDecryptor();
            Decryption.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TextFileEncryptor FileEncryption = new TextFileEncryptor();
            FileEncryption.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TextFileDecryptor FileDecryption = new TextFileDecryptor();
            FileDecryption.Show();
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yup,This is made by ROHAN", "Credits");
        }
    }
}
