using LagerVerwaltungWebServiceApi.Helper;

namespace LagerVerwaltungWebServiceApi.Model
{
    public class LagerMainModel
    {
        public int? id { get; set; }
        public string bezeichnung { get; set; }

        public void save(string table)
        {   
            id = DBHelper.getNewId(table);
            DBHelper.ExecuteSQLCommand("INSERT INTO " + table + "(ID,BEZEICHNUNG)VALUES(" + id.ToString() + ",'" + bezeichnung + "')");
        }

        public void delete(string table)
        {
            DBHelper.ExecuteSQLCommand("DELETE FROM " + table +" WHERE ID =" + id.ToString());
        }

        virtual public  void update(string table)
        {
            DBHelper.ExecuteSQLCommand("UPDATE " + table + " SET BEZEICHNUNG ='" + bezeichnung + "' WHERE ID =" + id.ToString());
        }
    }
}