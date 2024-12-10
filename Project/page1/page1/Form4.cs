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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        
        public interface IShip
        {
            int Count { get; }
            int RequiredShips { get; }
        }

        
        public interface IShipDetails
        {
            string ShipType { get; }
            string GetDetails();
        }

        
        public class Starship : IShip, IShipDetails
        {
            public int Count { get; private set; }
            public string ShipType => "Starship";

            public int RequiredShips => Math.Max(0, 10 - Count);

            public Starship(int count)
            {
                Count = count;
            }

            public string GetDetails()
            {
                return $"{ShipType}: {Count} present, {RequiredShips} required.";
            }
        }

        public class Battleship : IShip, IShipDetails
        {
            public int Count { get; private set; }
            public string ShipType => "Battleship";

            public int RequiredShips => Math.Max(0, 10 - Count);

            public Battleship(int count)
            {
                Count = count;
            }

            public string GetDetails()
            {
                return $"{ShipType}: {Count} present, {RequiredShips} required.";
            }
        }

        public class ExploratoryShip : IShip, IShipDetails
        {
            public int Count { get; private set; }
            public string ShipType => "Exploratory Ship";

            public int RequiredShips => Math.Max(0, 10 - Count);

            public ExploratoryShip(int count)
            {
                Count = count;
            }

            public string GetDetails()
            {
                return $"{ShipType}: {Count} present, {RequiredShips} required.";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int starshipCount, battleshipCount, exploratoryShipCount;

                bool isStarshipValid = int.TryParse(textBox5.Text, out starshipCount);
                bool isBattleshipValid = int.TryParse(textBox6.Text, out battleshipCount);
                bool isExploratoryShipValid = int.TryParse(textBox7.Text, out exploratoryShipCount);

                if (isStarshipValid && isBattleshipValid && isExploratoryShipValid)
                {
                    var starship = new Starship(starshipCount);
                    var battleship = new Battleship(battleshipCount);
                    var exploratoryShip = new ExploratoryShip(exploratoryShipCount);

                    string resultMessage = $"{starship.GetDetails()}\n" +
                                           $"{battleship.GetDetails()}\n" +
                                           $"{exploratoryShip.GetDetails()}";

                    textBox8.Text = resultMessage;
                }
                else
                {
                    MessageBox.Show("Please enter valid numbers for all ship types.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox8_TextChanged(object sender, EventArgs e) { }
        private void textBox5_TextChanged(object sender, EventArgs e) { }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
