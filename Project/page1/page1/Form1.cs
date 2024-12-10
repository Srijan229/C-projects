using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;

namespace page1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private void textBox3_TextChanged(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            string userId = textBox2.Text;
            string password = textBox3.Text;

            
            if (IsValidUserId(userId) && IsValidPassword(password))
            {
                
                Thread loginThread = new Thread(() =>
                {
                    if (VerifyCredentials(userId, password))
                    {
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show("Login successful!");
                            textBox6.Text = "Login successful!";
                        }));

                        Invoke(new Action(() =>
                        {
                            Form2 form2 = new Form2();
                            this.Hide();
                            form2.ShowDialog();
                            this.Show();
                        }));
                    }
                    else
                    {
                        Invoke(new Action(() =>
                        { 
                            MessageBox.Show("Invalid user ID or password.");
                            textBox6.Text = "Invalid user ID or password.";
                        }));
                    }
                });
                loginThread.Start();
            }
            else
            {
                MessageBox.Show("Invalid user ID or password format.");
                textBox6.Text = "Invalid user ID or password format.";
            }
        }

        private void button2_Click(object sender, EventArgs e) { }

        private bool IsValidUserId(string userId)
        {
            
            return Regex.IsMatch(userId, @"^\d{3}[a-zA-Z]{2}$");
        }

        private bool IsValidPassword(string password)
        {
            
            return password.Length >= 8 &&
                   Regex.IsMatch(password, @"[a-z]") &&   
                   Regex.IsMatch(password, @"[A-Z]") &&   
                   Regex.IsMatch(password, @"\d") &&      
                   Regex.IsMatch(password, @"[\W_]");     
        }

        private void RegisterUser(string userId, string password)
        {
            
            Console.WriteLine($"User ID: {userId}, Password: {password}");
        }

        private bool VerifyCredentials(string userId, string password)
        {
            
            return userId == "123ab" && password == "Password1!";
        }

        private void textBox4_TextChanged(object sender, EventArgs e) { }
    }
}
