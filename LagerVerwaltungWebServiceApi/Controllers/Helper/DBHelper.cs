using System.Data.SqlClient;

namespace LagerVerwaltungWebServiceApi.Helper
{
    public static class DBHelper
    {
        public static SqlConnection getDBConnect()
        {
            SqlConnection conn = null;
            if (System.Environment.MachineName == "LPE846-17")
            {
                conn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=lagerDB;User Id=innosoft;Password=dispo");//Arbeitsrechner
            }
            else
            {
                conn = new SqlConnection("Server=localhost\\SQL2014;Database=lagerDB;User Id=sa;Password=dispo");//Zuhause
            }
            conn.Open();
            return conn;
        }

        public static int getNewId(string table)
        {
            int retVal = 0;
            SqlConnection conn = getDBConnect();
            SqlCommand comm = new SqlCommand("SELECT (max(id) + 1) as NewId from " + table, conn);
            SqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                if(reader.IsDBNull(0))//is data == null ?
                {
                    retVal = 1;
                }
                else
                {
                    retVal = reader.GetInt32(0);
                }
            }
            return retVal;
        }

        public static SqlDataReader GetDataReader(string query)
        {
            SqlConnection conn = getDBConnect();
            SqlCommand comm = new SqlCommand(query, conn);
            return comm.ExecuteReader();
        }

        public static void ExecuteSQLCommand(string query)
        {
            SqlConnection conn = getDBConnect();
            SqlCommand comm = new SqlCommand(query, conn);
            comm.ExecuteNonQuery();
        }
    }
}
