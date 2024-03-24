using CRUDify_UI.DatabaseServices;
using CRUDify_UI.Model;
using DbConnector;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace CRUDify_UI.ViewModel
{
    public class UpdateDocumentViewModel : BindableBase, IDataErrorInfo
    {
        private string m_firstName;
        private string m_lastName;
        private string m_fullName;
        private string m_playingNation;
        private string m_birthNation;
        private string m_club;
        private string m_position;
        private bool m_isActivePlayer;
        private string m_matchesPlayed;
        private string m_worldCups;
        private string m_clubCups;
        private bool m_isButtonDisabled;


        public UpdateDocumentViewModel()
        {
            ApplyCommand = new DelegateCommand(ApplyBtnHandler, CanApply);
            WorldCups = ClubCups = MatchesPlayed = "0";
        }

        private bool CanApply()
        {
            if (FirstName == null || LastName == null || FullName == null || PlayingNation == null || BirthNation == null
                || Club == null || Position == null)
            {
                return IsButtonEnabled = false;
            }

            else if (!IsConvertableToInt(WorldCups) || !IsConvertableToInt(ClubCups) || !IsConvertableToInt(MatchesPlayed))
            {
                return IsButtonEnabled = false;
            }

            return IsButtonEnabled = true;
        }

        public DelegateCommand ApplyCommand { get; set; }

        public UpdateDocumentModel ModelObj { get; set; }
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
                ApplyCommand.RaiseCanExecuteChanged();
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
                ApplyCommand.RaiseCanExecuteChanged();
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
                ApplyCommand.RaiseCanExecuteChanged();
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
                ApplyCommand.RaiseCanExecuteChanged();
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
                ApplyCommand.RaiseCanExecuteChanged();
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
                ApplyCommand.RaiseCanExecuteChanged();
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
                ApplyCommand.RaiseCanExecuteChanged();
            }
        }

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
                ApplyCommand.RaiseCanExecuteChanged();
            }
        }

        public string MatchesPlayed
        {
            get
            {
                return m_matchesPlayed;
            }
            set
            {
                m_matchesPlayed = value;
                RaisePropertyChanged(nameof(MatchesPlayed));
                ApplyCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsButtonEnabled
        {
            get
            {
                return m_isButtonDisabled;
            }

            set
            {
                m_isButtonDisabled = value;
                RaisePropertyChanged(nameof(IsButtonEnabled));
            }
        }

        public string WorldCups
        {
            get
            {
                return m_worldCups;
            }
            set
            {
                m_worldCups = value;
                RaisePropertyChanged(nameof(WorldCups));
                ApplyCommand.RaiseCanExecuteChanged();
            }
        }

        public string ClubCups
        {
            get
            {
                return m_clubCups;
            }
            set
            {
                m_clubCups = value;
                RaisePropertyChanged(nameof(ClubCups));
                ApplyCommand.RaiseCanExecuteChanged();
            }
        }

        public string ErrorValidationMessage { get; private set; }

        public string Error => throw new NotImplementedException();

        public string this[string propertyName]
        {
            get
            {
                ErrorValidationMessage = string.Empty;
                var propertyValue = GetType().GetProperty(propertyName)?.GetValue(this);
                switch (propertyName)
                {
                    case nameof(FirstName):
                    case nameof(LastName):
                    case nameof(FullName):
                    case nameof(PlayingNation):
                    case nameof(BirthNation):
                    case nameof(Club):
                    case nameof(Position):
                        if (string.IsNullOrEmpty(propertyValue?.ToString()))
                        {
                            ErrorValidationMessage = "Cannot have empty value " + ": " + propertyName;
                        }
                        break;

                    case nameof(WorldCups):
                    case nameof(ClubCups):
                    case nameof(MatchesPlayed):
                        if (!int.TryParse(propertyValue?.ToString(), out int parsedValue))
                        {
                            ErrorValidationMessage = "Wrong input type " + ": " + propertyName;
                        }
                        break;
                }

                return ErrorValidationMessage;
            }
        }

        private void ApplyBtnHandler()
        {
            var dbFieldMapperObj = new DatabaseFieldsMapper(StoreModelData());
            var bsonDocConverter = new BsonDocumentConverter();
            var bsonDoc = bsonDocConverter.GenerateBsonDoc(dbFieldMapperObj);

            var dbConnection = new DatabaseConnection();
            dbConnection.FootballCollection.InsertOneAsync(bsonDoc);
        }

        private UpdateDocumentModel StoreModelData()
        {
            var modelObj = new UpdateDocumentModel(firstName: FirstName, lastName: LastName, fullName: FullName, position: Position, club: Club, birthNation: BirthNation,
                playingNation: PlayingNation, worldCups: ParseToInt(WorldCups), clubCups: ParseToInt(ClubCups), isactivePlayer: IsActivePlayer, matchesPlayed: ParseToInt(MatchesPlayed));

            return modelObj;
        }

        private bool IsConvertableToInt(string value)
        {
            return int.TryParse(value, out int parsedValue);
        }

        private int ParseToInt(string value)
        {
            int.TryParse(value, out int parsedIntValue);
            return parsedIntValue;
        }
    }
}
