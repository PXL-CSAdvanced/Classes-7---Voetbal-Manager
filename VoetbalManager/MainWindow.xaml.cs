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
using VoetbalClassLibrary;

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

            Team team = new Team("Kayserispor");
            team.AddPlayer(new Footballer("Murat", "Akin", 2, "middenvelder", 3), false);
            team.AddPlayer(new Footballer("Igor", "Akinfejev", 4, "doelman", 0), false);
            team.AddPlayer(new Footballer("Kerem", "Aktürkoglu", 5, "aanvaller", 10), true);
            team.AddPlayer(new Footballer("Chuba", "Akpom", 3, "verdediger", 1), false);

            teamsComboBox.Items.Add(team);
            teamsComboBox.SelectedIndex = 0;
        }

        private void TeamsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (teamsComboBox.SelectedIndex == -1)
            {
                addPlayerButton.IsEnabled = false;
            }
            else
            {
                addTeamButton.IsEnabled = true;
                Team selectedTeam = teamsComboBox.SelectedItem as Team;
                teamInfoTextBox.Text = selectedTeam.TeamInformation();
                footballersListBox.Items.Clear();
                foreach (var footballer in selectedTeam.Footballers)
                {
                    footballersListBox.Items.Add(footballer);
                }
            }
            if (footballersListBox.SelectedIndex != -1)
            {
                Footballer selectedFootballer = footballersListBox.SelectedItem as Footballer;
                playerInfoTextBox.Text = selectedFootballer.Information();
            }
        }

        private void RemovePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if (teamsComboBox.SelectedIndex != -1 && footballersListBox.SelectedIndex != -1)
            {
                Footballer selectedFootballer = footballersListBox.SelectedItem as Footballer;
                Team selectedTeam = teamsComboBox.SelectedItem as Team;
                selectedTeam.RemovePlayer(footballersListBox.SelectedItem as Footballer);
                footballersListBox.Items.Remove(selectedFootballer);
            }
            UpdateUI();
        }

        private void FootballersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (footballersListBox.SelectedIndex != -1)
            {
                Footballer selectedFootballer = footballersListBox.SelectedItem as Footballer;
                playerInfoTextBox.Text = selectedFootballer.Information();
            }
        }

        private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if (teamsComboBox.SelectedIndex != -1)
            {
                Footballer newPlayer = new Footballer(
                    firstNameTextBox.Text,
                    lastNameTextBox.Text,
                    Convert.ToInt32(jerseyNumberTextBox.Text),
                    positionTextBox.Text,
                    Convert.ToInt32(numberOfGoalsTextBox.Text));
                Team selectedTeam = teamsComboBox.SelectedItem as Team;
                selectedTeam.AddPlayer(newPlayer, isCaptainCheckBox.IsChecked == true);
            }
            UpdateUI();
        }

        private void AddTeamButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(teamNameTextBox.Text))
            {
                Team newTeam = new Team(teamNameTextBox.Text);
                teamsComboBox.Items.Add(newTeam);
                teamNameTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("Geef een team naam in", "Ongeldige input");
            }
            UpdateUI();
        }
    }
}
