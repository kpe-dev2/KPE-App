using Java.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPE_App.Objects
{
    public class StundenEintragObj
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int ProjektNummer { get; set; }
        public string FreiText { get; set; }
        public DateTime AnfangDatum { get; set; }
        public DateTime EndDatum { get; set; }
	}
}
