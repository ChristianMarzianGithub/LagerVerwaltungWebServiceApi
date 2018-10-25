using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using LagerVerwaltungWebServiceApi.Helper;
using LagerVerwaltungWebServiceApi.Model;
using Newtonsoft.Json.Linq;

namespace LagerVerwaltungWebServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LagerArtController : ControllerBase
    {
        // GET: api/LagerArt
        [HttpGet]
        public IEnumerable<LagerArt> Get()
        {
            SqlDataReader dataReader = DBHelper.GetDataReader("SELECT ID,BEZEICHNUNG FROM LAGERART");

            var liste = new List<LagerArt>();
            while (dataReader.Read())
            {
                liste.Add(new LagerArt
                {
                    id = dataReader.GetInt32(0),
                    bezeichnung = dataReader.GetString(1)

                });
            }
            return liste;
        }

        // GET: api/LagerArt/5
        [HttpGet("{id}")]
        public LagerArt Get(int id)
        {
            SqlDataReader dataReader = DBHelper.GetDataReader("SELECT ID,BEZEICHNUNG FROM LAGERART WHERE ID =" + id.ToString());
            var lagerArtObj = new LagerArt();
            while (dataReader.Read())
            {
                lagerArtObj.id = dataReader.GetInt32(0);
                lagerArtObj.bezeichnung = dataReader.GetString(1);
            }
            return lagerArtObj;
        }

        // POST: api/LagerArt
        [HttpPost]
        public void Post([FromBody] object value)
        {
            JObject obj = JObject.Parse(value.ToString());
            string Bezeichnung = obj["Bezeichnung"].ToString();            
            LagerArt LagerArtObj = new LagerArt();            
            LagerArtObj.bezeichnung = Bezeichnung;
            LagerArtObj.save("LagerArt");
        }

        // PUT: api/LagerArt/5
        [HttpPut]
        public void Put([FromBody] object value)
        {
            JObject obj = JObject.Parse(value.ToString());
            int id = int.Parse(obj["Id"].ToString());
            string Bezeichnung = obj["Bezeichnung"].ToString();
            LagerArt LagerArtObj = new LagerArt();
            LagerArtObj.bezeichnung = Bezeichnung;
            LagerArtObj.id = id;
            LagerArtObj.update("LagerArt");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            LagerArt LagerArtObj = new LagerArt();
            LagerArtObj.id = id;
            LagerArtObj.delete("LagerArt");
        }
    }
}
