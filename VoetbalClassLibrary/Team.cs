using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoetbalClassLibrary
{
    public class Team
    {
        private List<Footballer> _players;

        public List<Footballer> Players
        {
            get { return _players; }
        }

        private Footballer _captain;

        public string Name { get; set; }

        public Team(String name)
        {
            this.Name = name;
            _players = new List<Footballer>();
        }

        public Footballer Captain
        {
            get { return _captain; }
            set
            {
                if (_players.Contains(value))
                {
                    _captain = value;
                }
                else
                {
                    throw new ArgumentException("De kapitein is niet deel van het team");
                }
            }
        }


        public double AverageNumberOfGoals()
        {
            double sum = 0;
            foreach (var footballer in _players)
            {
                sum += footballer.NumberOfGoals;
            }
            return sum / _players.Count;
        }

        public string TeamInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} heeft {_players.Count} spelers");
            sb.AppendLine("-------------");
            foreach (var player in _players)
            {
                if (player.Equals(_captain))
                {
                    sb.AppendLine(player.ToString() + " *");
                }
                else
                {
                    sb.AppendLine(player.ToString());
                }
            }
            sb.AppendLine("-------------");
            sb.AppendLine($"Gemiddeld aantal doelpunten: {AverageNumberOfGoals()}");
            return sb.ToString();
        }

        public void AddPlayer(Footballer player, bool isCaptain)
        {
            _players.Add(player);
            if (isCaptain)
            {
                Captain = player;
            }
        }

        public void RemovePlayer(Footballer player)
        {
            _players.Remove(player);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
