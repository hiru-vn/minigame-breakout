using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace minigame_breakout
{
    public partial class KeyLogin : Form
    {
        private object pass;

        public object FileOpen { get; private set; }

        public KeyLogin()
        {
           
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Key = textBox1.Text.ToString();
            if(textBox1.Text==null)
                MessageBox.Show("Mật khẩu chưa nhập! ", "Thông báo", MessageBoxButtons.OK);
            if (int.Parse(Key) % 2 == 0)
            {
                using (MD5 md5 = MD5.Create())
                {
                    string hash = GetMd5Hash(md5, Key);
                    System.IO.StreamWriter str = System.IO.File.AppendText("user.txt");
                    str.WriteLine(hash);
                    str.Close();
                    this.Hide();
                    StartScreen startScreen = new StartScreen();
                    startScreen.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Sai mật khẩu! ", "Thông báo", MessageBoxButtons.OK);
            }

        }
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void KeyLogin_Load(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists("user.txt"))
            {
                var myfile = System.IO.File.Create("user.txt");
                myfile.Close();
            }
            string pass = System.IO.File.ReadAllText("user.txt");
            if (pass.Length !=0 ) {
                this.Hide();
                StartScreen startScreen = new StartScreen();
                startScreen.ShowDialog();
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
