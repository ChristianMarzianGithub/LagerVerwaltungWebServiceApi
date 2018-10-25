using LagerVerwaltungWebServiceApi.Helper;
using System.Data.SqlClient;

namespace LagerVerwaltungWebServiceApi.Model
{
    public class Lager: LagerMainModel
    {
        public int? lagerArtID { get; set; }

        public override void update(string table)
        {
            string sqlCommand = "Update Lager";
            if(bezeichnung != "")
            {
                sqlCommand += " SET BEZEICHNUNG = " + bezeichnung;
            }
            else if ((bezeichnung == "") && (id == null))
            {
                if (lagerArtID != null)
                {
                    sqlCommand += ",SET LagerArtID = " + lagerArtID;
                }
            }            
            if (lagerArtID != null)
            {
                sqlCommand += " SET LagerArtID = " + lagerArtID;
            }
            else
            {
                if (bezeichnung != "")
                {
                    sqlCommand += " SET BEZEICHNUNG = " + bezeichnung;
                }
            }
                            
            sqlCommand += " WHERE ID =" + id;

            SqlConnection conn = DBHelper.getDBConnect();
            SqlCommand comm = new SqlCommand(sqlCommand, conn);
            comm.ExecuteNonQuery();
        }
    }
}