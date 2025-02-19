using System;
using System.Linq;
using System.Security.Permissions;

namespace VoetbalClassLibrary
{
    public class Footballer
    {
        private static readonly string[] validPositions = new string[] { "aanvaller", "doelman", "middenvelder", "verdediger" };

        public string FirstName { get; set; }
        public string LastName { get; set; }

        private int _jerseyNumber;

        public int JerseyNumber
        {
            get { return _jerseyNumber; }
            set
            {
                if (value > 0 && value < 100)
                {
                    _jerseyNumber = value;
                }
                else
                {
                    throw new ArgumentException("Rugnummer moet tussen 0 en 100 liggen.");
                }
            }
        }

        private string _position;

        public string Position
        {
            get { return _position; }
            set
            {
                if (validPositions.Contains(value.ToLower()))
                {
                    _position = value;
                }
                else
                {
                    throw new ArgumentException("Ongeldige waarde voor positie");
                }
            }
        }

        public int NumberOfGoals { get; set; }

        public Footballer(string firstName, string lastName, int jerseyNumber, string position, int numberOfGoals)
        {
            FirstName = firstName;
            LastName = lastName;
            JerseyNumber = jerseyNumber;
            Position = position;
            NumberOfGoals = numberOfGoals;
        }

        public Footballer(string firstName, string lastName, int jerseyNumber) :
            this(firstName, lastName, jerseyNumber, validPositions[2], 0)
        {
        }

        public string Information()
        {
            return $"Voetballer {ToString()} ({JerseyNumber}) heeft dit seizoen {NumberOfGoals} doelen gescoord.\n" +
                $"Positie: {Position}";
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }
    }
}