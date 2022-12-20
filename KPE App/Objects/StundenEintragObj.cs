using CommunityToolkit.Mvvm.ComponentModel;
using Java.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPE_App.Objects
{
    public class StundenEintragObj : ObservableObject
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string ProjektNummer { get; set; }
        public string FreiText { get; set; }

        private DateTime _AnfangDatum = DateTime.Now.Date + new TimeSpan(8, 0, 0);
        public DateTime AnfangDatum
        {
            get { return _AnfangDatum; }
            set { SetProperty(ref _AnfangDatum, value); }
        }

        private DateTime _EndDatum = DateTime.Now.Date + new TimeSpan(16, 0, 0);
        public DateTime EndDatum
        {
            get { return _EndDatum; }
            set { SetProperty(ref _EndDatum, value); }
        }
    }
}
