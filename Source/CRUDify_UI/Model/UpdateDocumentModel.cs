using Prism.Mvvm;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls.Ribbon;

namespace CRUDify_UI.Model
{
    public class UpdateDocumentModel
    {
        public UpdateDocumentModel(string firstName, string lastName, string fullName, string position, string club, string birthNation, string playingNation, int worldCups, int clubCups, bool isactivePlayer, int matchesPlayed)
        {
            UpdateOptionStatus = "CR7 and LM10";

            SportsType = "Football";
            Awards = new Awards();

            FirstName = firstName;
            LastName = lastName;
            FullName = fullName;
            PlayingNation = playingNation;
            BirthNation = birthNation;
            Club = club;
            Position = position;
            Awards.WorldCups = worldCups;
            Awards.ClubCups = clubCups;
            MatchesPlayed = matchesPlayed;
            IsActivePlayer = isactivePlayer;
        }

        public string UpdateOptionStatus { get; set; }

        public string SportsType { get; private set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string Club { get; set; }

        public string Position { get; set; }

        public string PlayingNation { get; set; }

        public string BirthNation { get; set; }

        public Awards Awards { get; set; }

        public bool IsActivePlayer { get; set; }

        public int MatchesPlayed { get; set; }
    }
}
