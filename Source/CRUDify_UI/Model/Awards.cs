using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDify_UI.Model
{
    public class Awards : BindableBase
    {
        private int m_worldCups;
        private int m_clubCups;

        public int WorldCups
        {
            get
            {
                return m_worldCups;
            }
            set
            {
                m_worldCups = value;
                RaisePropertyChanged(nameof(WorldCups));
            }
        }

        public int ClubCups
        {
            get
            {
                return m_clubCups;
            }
            set
            {
                m_clubCups = value;
                RaisePropertyChanged(nameof(ClubCups));
            }
        }

    }
}
