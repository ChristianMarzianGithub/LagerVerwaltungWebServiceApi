using LagerVerwaltungWebServiceApi.Helper;

namespace LagerVerwaltungWebServiceApi.Model
{
    public class LagerPosition
    {
        public int lagerID { get; set; }
        public int lagerObjektID { get; set; }
        public int anzahl { get; set; }

        public void saveLagerPosition()
        {
            lagerID = DBHelper.getNewId("lagerID");
            DBHelper.ExecuteSQLCommand("INSERT INTO LAGERPOSITION(LAGERID,LAGEROBJEKTID,ANZAHL)VALUES(" + lagerID.ToString() + ",'" 
                + lagerObjektID + "," + anzahl.ToString() + "," + "')");
        }

        public void deleteLagerPosition()
        {
            DBHelper.ExecuteSQLCommand("DELETE FROM LAGERART WHERE LagerID = '" + lagerID.ToString() + "' AND LagerObjektID = '" + lagerObjektID + "'");
        }

        public void updateLagerPosition()
        {
            DBHelper.ExecuteSQLCommand("UPDATE LAGERObjekt SET ANZAHL ='" + anzahl + "' WHERE LAGERID =" + lagerID.ToString() + " AND LAGEROBJEKTID = '" + lagerObjektID + "'");
        }
    }
}