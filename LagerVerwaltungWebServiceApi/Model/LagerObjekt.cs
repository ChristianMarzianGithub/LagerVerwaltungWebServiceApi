using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LagerVerwaltungWebServiceApi.Helper;

namespace LagerVerwaltungWebServiceApi.Model
{
    public class LagerObjekt
    {
        public int id { get; set; }
        public string bezeichnung { get; set; }

        public void saveLagerObjekt()
        {
            id = DBHelper.getNewId("LagerArt");
            DBHelper.ExecuteSQLCommand("INSERT INTO LAGERART(ID,BEZEICHNUNG)VALUES(" + id.ToString() + ",'" + bezeichnung + "')");
        }

        public void deleteLagerObjekt()
        {
            DBHelper.ExecuteSQLCommand("DELETE FROM LAGERART WHERE ID =" + id.ToString());
        }

        public void updateLagerObjekt()
        {
            DBHelper.ExecuteSQLCommand("UPDATE LAGERObjekt SET BEZEICHNUNG ='" + bezeichnung + "' WHERE ID =" + id.ToString());
        }
    }
}
