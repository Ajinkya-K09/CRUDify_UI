using CRUDify_UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDify_UI.Interface
{
    public interface IFootballerDocument
    {
        string SportsType { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string FullName { get; set; }

        string PlayingNation { get; set; }

        string BirthNation { get; set; }

        string Club { get; set; }

        string Position { get; set; }

        Awards Awards { get; set; }

        bool IsActivePlayer { get; set; }

        int MatchesPlayed { get; set; }
    }
}
