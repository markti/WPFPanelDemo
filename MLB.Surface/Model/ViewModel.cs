using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace MLB.Model
{
    public class ViewModel : INotifyPropertyChanged
    {
        BaseballTeam selectedTeam;

        public BaseballTeam SelectedTeam
        {
            get { return selectedTeam; }
            set 
            { 
                selectedTeam = value;
                OnPropertyChanged("SelectedTeam");
            }
        }

        public List<BaseballTeam> Teams { get; set; }
        public List<TeamInfo> InfoList { get; set; }
        public List<TeamInfo> InjuredPlayers { get; set; }

        public ViewModel()
        {
            InjuredPlayers = new List<TeamInfo>();

            InjuredPlayers.Add(new TeamInfo() { ImagePath = "Resources/Images/Menu/Sick.png" });
            InjuredPlayers.Add(new TeamInfo() { ImagePath = "Resources/Images/Menu/Sick.png" });
            InjuredPlayers.Add(new TeamInfo() { ImagePath = "Resources/Images/Menu/Sick.png" });
            InjuredPlayers.Add(new TeamInfo() { ImagePath = "Resources/Images/Menu/Sick.png" });
            InjuredPlayers.Add(new TeamInfo() { ImagePath = "Resources/Images/Menu/Sick.png" });

            InfoList = new List<TeamInfo>();

            InfoList.Add(new TeamInfo() { ImagePath = "Resources/Images/Menu/Field.png" });
            InfoList.Add(new TeamInfo() { ImagePath = "Resources/Images/Menu/Ambulance.png" });
            InfoList.Add(new TeamInfo() { ImagePath = "Resources/Images/Menu/Helmet.png" });
            InfoList.Add(new TeamInfo() { ImagePath = "Resources/Images/Menu/Games.png" });
            InfoList.Add(new TeamInfo() { ImagePath = "Resources/Images/Menu/Ticket.png" });
            InfoList.Add(new TeamInfo() { ImagePath = "Resources/Images/Menu/Envelope.png" });
            InfoList.Add(new TeamInfo() { ImagePath = "Resources/Images/Menu/Exit.png" });

            Teams = new List<BaseballTeam>();

            Teams.Add(new BaseballTeam() { HomeTown = "Arizona", Mascot = "Diamond Backs", ColorCode = "FFC31F26", LogoImagePath = "Resources/Images/Logos/ARI.png", InsigniaImagePath = "Resources/Images/Caps/ARI.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "Atlanta", Mascot = "Braves", ColorCode = "FF012C63", LogoImagePath = "Resources/Images/Logos/ATL.png", InsigniaImagePath = "Resources/Images/Caps/ATL.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "Baltimore", Mascot = "Orioles", ColorCode = "FF000000", LogoImagePath = "Resources/Images/Logos/BAL.png", InsigniaImagePath = "Resources/Images/Caps/BAL.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "Boston", Mascot = "Red Sox", ColorCode = "FF051C43", LogoImagePath = "Resources/Images/Logos/?", InsigniaImagePath = "Resources/Images/Caps/BOS.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "Chicago", Mascot = "Cubs", ColorCode = "FF083884", LogoImagePath = "Resources/Images/Logos/CHC.png", InsigniaImagePath = "Resources/Images/Caps/CHC.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "Cincinati", Mascot = "Reds", ColorCode = "FFFF0028", LogoImagePath = "Resources/Images/Logos/CIN.png", InsigniaImagePath = "Resources/Images/Caps/CIN.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "Cleveland", Mascot = "Indians", ColorCode = "FF001842", LogoImagePath = "Resources/Images/Logos/?", InsigniaImagePath = "Resources/Images/Caps/CLE.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "Colorado", Mascot = "Rockies", ColorCode = "FF000000", LogoImagePath = "Resources/Images/Logos/?", InsigniaImagePath = "Resources/Images/Caps/COL.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "Chicago", Mascot = "White Sox", ColorCode = "FF000000", LogoImagePath = "Resources/Images/Logos/CWS.png", InsigniaImagePath = "Resources/Images/Caps/CWS.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "Detroit", Mascot = "Tigers", ColorCode = "FF001842", LogoImagePath = "Resources/Images/Logos/DET.png", InsigniaImagePath = "Resources/Images/Caps/DET.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "Florida", Mascot = "Marlins", ColorCode = "FF000000", LogoImagePath = "Resources/Images/Logos/FLA.png", InsigniaImagePath = "Resources/Images/Caps/FLA.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "Houston", Mascot = "Astros", ColorCode = "FF000000", LogoImagePath = "Resources/Images/Logos/HOU.png", InsigniaImagePath = "Resources/Images/Caps/HOU.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "Kansas City", Mascot = "Royals", ColorCode = "FF0B246B", LogoImagePath = "Resources/Images/Logos/KCR.png", InsigniaImagePath = "Resources/Images/Caps/KCR.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "California", Mascot = "Angels", ColorCode = "FFCE0F41", LogoImagePath = "Resources/Images/Logos/LAA.png", InsigniaImagePath = "Resources/Images/Caps/LAA.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "Los Angeles", Mascot = "Dodgers", ColorCode = "FF083884", LogoImagePath = "Resources/Images/Logos/LAD.png", InsigniaImagePath = "Resources/Images/Caps/LAD.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "Milwaukee", Mascot = "Brewers", ColorCode = "FF000F30", LogoImagePath = "Resources/Images/Logos/MIL.png", InsigniaImagePath = "Resources/Images/Caps/MIL.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "Minnesota", Mascot = "Twins", ColorCode = "FF051C43", LogoImagePath = "Resources/Images/Logos/MIN.png", InsigniaImagePath = "Resources/Images/Caps/MIN.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "New York", Mascot = "Mets", ColorCode = "FF0E276B", LogoImagePath = "Resources/Images/Logos/NYM.png", InsigniaImagePath = "Resources/Images/Caps/NYM.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "New York", Mascot = "Yankees", ColorCode = "FF0F1C43", LogoImagePath = "Resources/Images/Logos/?", InsigniaImagePath = "Resources/Images/Caps/NYY.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "Oakland", Mascot = "As", ColorCode = "FF003928", LogoImagePath = "Resources/Images/Logos/OAK.png", InsigniaImagePath = "Resources/Images/Caps/OAK.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "Philadelphia", Mascot = "Phillies", ColorCode = "FFD30016", LogoImagePath = "Resources/Images/Logos/PHI.png", InsigniaImagePath = "Resources/Images/Caps/PHI.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "Pittsburgh", Mascot = "Pirates", ColorCode = "FF000000", LogoImagePath = "Resources/Images/Logos/PIT.png", InsigniaImagePath = "Resources/Images/Caps/PIT.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "San Diego", Mascot = "Padres", ColorCode = "FF213A65", LogoImagePath = "Resources/Images/Logos/SDP.png", InsigniaImagePath = "Resources/Images/Caps/SDP.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "Seattle", Mascot = "Mariners", ColorCode = "FF0B3F57", LogoImagePath = "Resources/Images/Logos/?", InsigniaImagePath = "Resources/Images/Caps/SEA.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "San Fransico", Mascot = "Giants", ColorCode = "FF000000", LogoImagePath = "Resources/Images/Logos/SFG.png", InsigniaImagePath = "Resources/Images/Caps/SFG.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "St. Louis", Mascot = "Cardinals", ColorCode = "FFDE1000", LogoImagePath = "Resources/Images/Logos/STL.png", InsigniaImagePath = "Resources/Images/Caps/STL.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "Tampa Bay", Mascot = "Rays", ColorCode = "FF00265D", LogoImagePath = "Resources/Images/Logos/TBR.png", InsigniaImagePath = "Resources/Images/Caps/TBR.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "Texas", Mascot = "Rangers", ColorCode = "FF16288E", LogoImagePath = "Resources/Images/Logos/TEX.png", InsigniaImagePath = "Resources/Images/Caps/TEX.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "Toronto", Mascot = "Blue Jays", ColorCode = "FF000000", LogoImagePath = "Resources/Images/Logos/TOR.png", InsigniaImagePath = "Resources/Images/Caps/TOR.png" });
            Teams.Add(new BaseballTeam() { HomeTown = "Washington", Mascot = "Nationals", ColorCode = "FFD31044", LogoImagePath = "Resources/Images/Logos/WAS.png", InsigniaImagePath = "Resources/Images/Caps/WAS.png" });

        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public class BaseballTeam
    {
        public string HomeTown { get; set; }
        public string Mascot { get; set; }
        public string ColorCode { get; set; }
        //public Color CapColor
        //{
        //    get { return Color
        //}
        public string LogoImagePath { get; set; }
        public string InsigniaImagePath { get; set; }
    }

    public class TeamInfo
    {
        public string ImagePath { get; set; }
    }
}