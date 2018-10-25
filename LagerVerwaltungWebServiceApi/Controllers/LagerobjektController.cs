using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LagerVerwaltungWebServiceApi.Helper;
using LagerVerwaltungWebServiceApi.Model;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;

namespace LagerVerwaltungWebServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LagerobjektController : Lager
    {
        // GET: api/LagerObjekt
        [HttpGet]
        public IEnumerable<LagerObjekt> Get()
        {
            SqlConnection conn = DBHelper.getDBConnect();
            SqlCommand comm = new SqlCommand("SELECT ID,BEZEICHNUNG FROM LagerObjekt", conn);
            SqlDataReader read = comm.ExecuteReader();

            int i = 0;
            var liste = new List<LagerObjekt>();
            while (read.Read())
            {
                liste.Add(new LagerObjekt()
                {
                    id = read.GetInt32(0),
                    bezeichnung = read.GetString(1)
                });
                i++;
            }
            return liste;
        }

        // GET: api/LagerObjekt/5
        [HttpGet("{id}")]
        public LagerObjekt Get(int id)
        {
            SqlConnection conn = DBHelper.getDBConnect();
            SqlCommand comm = new SqlCommand("SELECT BEZEICHNUNG FROM LAGEROBJEKT WHERE ID =" + id.ToString(), conn);
            SqlDataReader read = comm.ExecuteReader();

            var liste = new List<LagerObjekt>();
            LagerObjekt lagerObj = null;
            while (read.Read())
            {
                lagerObj = new LagerObjekt()
                {
                    id = read.GetInt32(0),
                    bezeichnung = read.GetString(1)
                };
            }
            return lagerObj;
        }

        // POST: api/LagerObjekt
        [HttpPost]
        public void Post([FromBody] object value)
        {
            JObject obj = JObject.Parse(value.ToString());
            string Bezeichnung = obj["Bezeichnung"].ToString();

            LagerObjekt LagerObj = new LagerObjekt();
            LagerObj.id = DBHelper.getNewId("Lager");
            LagerObj.bezeichnung = Bezeichnung;

            LagerObj.saveLagerObjekt();

        }
        

        // PUT: api/LagerObjekt/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            JObject obj = JObject.Parse(value.ToString());
            LagerObjekt LagerObj = new LagerObjekt();
            LagerObj.id = int.Parse(obj["id"].ToString());            
            LagerObj.bezeichnung = obj["Bezeichnung"].ToString();
            LagerObj.updateLagerObjekt();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            LagerObjekt LagerObj = new LagerObjekt();
            LagerObj.id = id;
            LagerObj.deleteLagerObjekt();
        }
    }
}
