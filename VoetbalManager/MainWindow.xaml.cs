using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VoetbalManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /*
            Team team = new Team("Kayserispor");
            team.AddPlayer(new Footballer("Murat", "Akin", 2, "middenvelder", 3), false);
            team.AddPlayer(new Footballer("Igor", "Akinfejev", 4, "doelman", 0), false);
            team.AddPlayer(new Footballer("Kerem", "Aktürkoglu", 5, "aanvaller", 10), true);
            team.AddPlayer(new Footballer("Chuba", "Akpom", 3, "verdediger", 1), false);

            teamsComboBox.Items.Add(team);
            teamsComboBox.SelectedIndex = 0;
            */
        }

        private void TeamsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            // TODO: Controleer of een team geselecteerd is en toon vervolgens al de informatie van het team.
            // Selecteer vervolgens automatisch de eerste speler van het geselecteerde Team.
        }

        private void RemovePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Verwijder de geselecteerde speler van het geselecteerde team.
        }

        private void FootballersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: Toon het resultaat van Information() van de geselecteerde speler (footballer) in playerInfoTextBox.
        }

        private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Maak een Footballer aan op basis van de invulvelden en voeg de Footballer toe aan het geselecteerde Team.
            
            UpdateUI();
        }

        private void AddTeamButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Maak een Team aan op basis van de inhoud uit teamNameTextBox en voeg het team toe aan teamsComboBox.

            UpdateUI();
        }
    }
}
