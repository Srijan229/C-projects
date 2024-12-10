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
    public partial class Form3 : Form
    {
        private PlanetExploration planetExploration;

        public Form3()
        {
            InitializeComponent();
            this.button1.Click += new System.EventHandler(this.button1_Click);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string planetName = textBox3.Text;
            if (!string.IsNullOrEmpty(planetName))
            {
                planetExploration = new PlanetExploration(planetName);
                planetExploration.EstablishCommunication();
                planetExploration.DisplayCommonMessage();

                
                string receivedMessage = "Exploration data received successfully!";
                planetExploration.ReceiveCommunication(receivedMessage);

                textBox4.Text = $"Communication established with {planetName}.\nMessage: {receivedMessage}";
            }
            else
            {
                MessageBox.Show("Please enter a planet name.");
            }
        }

        public abstract class Exploration
        {
            public abstract void EstablishCommunication();
            public abstract void ReceiveCommunication(string message);

            
            public void DisplayCommonMessage()
            {
                MessageBox.Show("Starting the exploration process...");
            }
        }

        public class PlanetExploration : Exploration
        {
            public string PlanetName { get; set; }

            public PlanetExploration(string planetName)
            {
                PlanetName = planetName;
            }

            public override void EstablishCommunication()
            {
                
                MessageBox.Show($"Establishing communication with {PlanetName}...");
            }

            public override void ReceiveCommunication(string message)
            {
                
                MessageBox.Show($"Received message from {PlanetName}: {message}");
            }
        }
    }
}
