using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace page1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                string invadingForce = textBox5.Text.Trim();
                int phase5Needed = int.Parse(textBox7.Text.Trim());
                int aidLevel = int.Parse(textBox6.Text.Trim());

                
                if (invadingForce.Equals("Darth Vader", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("God Help you");
                }
                else if (phase5Needed == 0 || aidLevel == 0)
                {
                    throw new InvalidOperationException("Phase 5 needed and aid level cannot be zero.");
                }
                else
                {
                    
                    MessageBox.Show($"Aid sent with {phase5Needed} Phase 5 and aid level of {aidLevel}.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers for Phase 5 Needed and Aid Level.");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
