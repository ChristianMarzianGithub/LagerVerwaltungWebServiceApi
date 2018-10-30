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
            id = DBHelper.getNewId("LAGEROBJEKT");
            DBHelper.ExecuteSQLCommand("INSERT INTO LAGEROBJEKT(ID,BEZEICHNUNG)VALUES(" + id.ToString() + ",'" + bezeichnung + "')");
        }

        public void deleteLagerObjekt()
        {
            DBHelper.ExecuteSQLCommand("DELETE FROM LAGEROBJEKT WHERE ID =" + id.ToString());
        }

        public void updateLagerObjekt()
        {
            DBHelper.ExecuteSQLCommand("UPDATE LAGEROBJEKT SET BEZEICHNUNG ='" + bezeichnung + "' WHERE ID =" + id.ToString());
        }
    }
}
