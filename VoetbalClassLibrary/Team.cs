using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoetbalClassLibrary
{
    public class Team
    {
        private List<Footballer> _footballers;

        public List<Footballer> Footballers
        {
            get { return _footballers; }
        }

        private Footballer _captain;

        public string Name { get; set; }

        public Team(String name)
        {
            this.Name = name;
            _footballers = new List<Footballer>();
        }

        public Footballer Captain
        {
            get { return _captain; }
            set
            {
                if (_footballers.Contains(value))
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
            foreach (var footballer in _footballers)
            {
                sum += footballer.NumberOfGoals;
            }
            return sum / _footballers.Count;
        }

        public string TeamInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} heeft {_footballers.Count} spelers");
            sb.AppendLine("-------------");
            foreach (var player in _footballers)
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

        public void AddPlayer(Footballer footballer, bool isCaptain)
        {
            _footballers.Add(footballer);
            if (isCaptain)
            {
                Captain = footballer;
            }
        }

        public void RemovePlayer(Footballer footballer)
        {
            _footballers.Remove(footballer);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
