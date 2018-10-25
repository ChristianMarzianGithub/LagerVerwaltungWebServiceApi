using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LagerVerwaltungWebServiceApi.Helper;
using System.Data.SqlClient;
using LagerVerwaltungWebServiceApi.Model;
using Newtonsoft.Json.Linq;

namespace LagerVerwaltungWebServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LagerController : ControllerBase
    {
        // GET: api/Lager
        [HttpGet]
        public IEnumerable <Lager> Get()
        {
            SqlConnection conn = DBHelper.getDBConnect();
            SqlCommand comm = new SqlCommand("SELECT ID,BEZEICHNUNG,LAGERARTID FROM LAGER", conn);
            SqlDataReader read = comm.ExecuteReader();

            int i = 0;
            var liste = new List<Lager>();            
            while (read.Read())
            {
                liste.Add(new Lager()
                {
                    id = read.GetInt32(0),
                    bezeichnung = read.GetString(1),
                    lagerArtID = read.GetInt32(2)
                });
                i++;
            }
            return liste;
        }

        // GET: api/Lager/5
        [HttpGet("{id}")]
        public Lager Get(int id)
        {
            SqlConnection conn = DBHelper.getDBConnect();
            SqlCommand comm = new SqlCommand("SELECT ID,BEZEICHNUNG,LAGERARTID FROM LAGER WHERE ID =" + id.ToString(), conn);
            SqlDataReader read = comm.ExecuteReader();
                        
            var liste = new List<Lager>();
            Lager lagerObj = null;
            while (read.Read())
            {
                lagerObj = new Lager()
                {
                    id = read.GetInt32(0),
                    bezeichnung = read.GetString(1),
                    lagerArtID = read.GetInt32(2)
                };
            }    
            return lagerObj;
        }

        // POST: api/Lager
        [HttpPost]
        public void Post([FromBody] object value)
        {
            JObject obj = JObject.Parse(value.ToString());
            string Bezeichnung = obj["Bezeichnung"].ToString();
            int LagerArtID = int.Parse(obj["LagerArtID"].ToString());

            Lager LagerObj = new Lager();
            LagerObj.id = DBHelper.getNewId("Lager");
            LagerObj.bezeichnung = Bezeichnung;
            LagerObj.lagerArtID = LagerArtID;

            LagerObj.save("Lager");
        }

        // PUT: api/Lager/5
        [HttpPut("{id}")]
        public void Put([FromBody] object value)
        {
            JObject obj = JObject.Parse(value.ToString());
            Lager LagerObj = new Lager();
            LagerObj.id = int.Parse(obj["id"].ToString());
            LagerObj.lagerArtID = int.Parse(obj["LagerArtID"].ToString());
            LagerObj.bezeichnung = obj["Bezeichnung"].ToString();
            LagerObj.update("Lager");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Lager LagerObj = new Lager();
            LagerObj.id = id;
            LagerObj.delete("Lager");
        }
    }
}
