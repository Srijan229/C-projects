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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            button1.Click += Button1_Click; 
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int destroyerCount = GetShipCount(textBox1.Text);
                int battleshipCount = GetShipCount(textBox2.Text);
                int phase5ShipCount = GetShipCount(textBox3.Text);

                
                int totalShips = destroyerCount + battleshipCount + phase5ShipCount;

                
                int requiredDeployment = (int)(totalShips * 0.4);

                
                if (totalShips < 4)
                {
                    string missingShips = CheckForMissingShips(destroyerCount, battleshipCount, phase5ShipCount);
                    MessageBox.Show($"Need more ships: {missingShips}");
                }
                else
                {
                    MessageBox.Show($"Total Ships: {totalShips}\nShips to deploy: {requiredDeployment}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private int GetShipCount(string input) =>
            int.TryParse(input, out int count) ? count : 0;

        private string CheckForMissingShips(int destroyerCount, int battleshipCount, int phase5ShipCount) =>
            new[] {
                new { Type = "Destroyers", Count = destroyerCount },
                new { Type = "Battleships", Count = battleshipCount },
                new { Type = "Phase 5 Ships", Count = phase5ShipCount }
            }
            .Where(ship => ship.Count < 1)
            .Select(ship => ship.Type)
            .Aggregate((current, next) => current + ", " + next);

        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
