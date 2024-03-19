using Prism.Mvvm;
using System.Windows.Controls.Ribbon;

namespace CRUDify_UI.Model
{
    public class UpdateDocumentModel : BindableBase
    {
        private string m_firstName;
        private string m_lastName;
        private string m_fullName;
        private string m_playingNation;
        private string m_birthNation;
        private string m_club;
        private string m_position;
        private bool m_isActivePlayer;
        private int m_matchesPlayed;

        public UpdateDocumentModel()
        {
            UpdateOptionStatus = "CR7 and LM10";
            SportsType = "Football";
            AwardsData = new Awards();
        }

        public string UpdateOptionStatus { get; set; }

        public string SportsType { get; private set; }

        public string FirstName
        {
            get
            {
                return m_firstName;
            }

            set
            {
                m_firstName = value;
                RaisePropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get
            {
                return m_lastName;
            }
            set
            {
                m_lastName = value;
                RaisePropertyChanged(nameof(LastName));
            }
        }

        public string FullName
        {
            get
            {
                return m_fullName;
            }
            set
            {
                m_fullName = value;
                RaisePropertyChanged(nameof(FullName));
            }
        }

        public string PlayingNation
        {
            get
            {
                return m_playingNation;
            }
            set
            {
                m_playingNation = value;
                RaisePropertyChanged(nameof(PlayingNation));
            }
        }

        public string BirthNation
        {
            get
            {
                return m_birthNation;
            }
            set
            {
                m_birthNation = value;
                RaisePropertyChanged(nameof(BirthNation));
            }
        }

        public string Club
        {
            get
            {
                return m_club;
            }
            set
            {
                m_club = value;
                RaisePropertyChanged(nameof(Club));
            }
        }

        public string Position
        {
            get
            {
                return m_position;
            }
            set
            {
                m_position = value;
                RaisePropertyChanged(nameof(Position));
            }
        }

        public Awards AwardsData { get; set; }

        public bool IsActivePlayer
        {
            get
            {
                return m_isActivePlayer;
            }
            set
            {
                m_isActivePlayer = value;
                RaisePropertyChanged(nameof(IsActivePlayer));
            }
        }

        public int MatchesPlayed
        {
            get
            {
                return m_matchesPlayed;
            }
            set
            {
                m_matchesPlayed = value;
                RaisePropertyChanged(nameof(MatchesPlayed));
            }
        }
    }
}
