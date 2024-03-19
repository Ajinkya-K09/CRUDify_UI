using CRUDify_UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDify_UI.DatabaseServices
{
    public class DatabaseFieldsMapper
    {
        public DatabaseFieldsMapper(UpdateDocumentModel modelObj)
        {
            SportsType = modelObj.SportsType;
            FirstName = modelObj.FirstName;
            LastName = modelObj.LastName;
            FullName = modelObj.FullName;
            PlayingNation = modelObj.PlayingNation;
            BirthNation = modelObj.BirthNation;
            Club = modelObj.Club;
            Position = modelObj.Position;
            AwardsData = new Awards()
            {
                WorldCups = modelObj.AwardsData.WorldCups,
                ClubCups = modelObj.AwardsData.ClubCups
            };

            IsActivePlayer = modelObj.IsActivePlayer;
            MatchesPlayed = modelObj.MatchesPlayed;
        }

        public string SportsType { get; private set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string PlayingNation { get; set; }

        public string BirthNation { get; set; }

        public string Club { get; set; }

        public string Position { get; set; }

        public Awards AwardsData { get; set; }

        public bool IsActivePlayer { get; set; }

        public int MatchesPlayed { get; set; }

    }
}
