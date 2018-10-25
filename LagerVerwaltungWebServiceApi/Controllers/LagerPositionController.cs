using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using LagerVerwaltungWebServiceApi.Helper;
using LagerVerwaltungWebServiceApi.Model;
using Newtonsoft.Json.Linq;

namespace LagerVerwaltungWebServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LagerPositionController : LagerMainModel
    {
        // GET: api/LagerPosition
        [HttpGet]
        public IEnumerable<LagerPosition> Get()
        {
            SqlDataReader dataReader = DBHelper.GetDataReader("SELECT LAGERID,LAGEROBJEKTID,ANZAHL FROM LAGERPOSITION");

            var liste = new List<LagerPosition>();
            
            while (dataReader.Read())
            {
                liste.Add(new LagerPosition
                {
                    lagerID = dataReader.GetInt32(0),
                    lagerObjektID = dataReader.GetInt32(1),
                    anzahl = dataReader.GetInt32(2)
                });
            }
            return liste;
        }

        // GET: api/LagerPosition/5
        [HttpGet("{id}")]
        public LagerPosition Get(int id)
        {
            SqlDataReader dataReader = DBHelper.GetDataReader("SELECT LagerID,LagerObjektID,Anzahl FROM LAGERART WHERE ID =" + id.ToString());
            var LagerPosition = new LagerPosition();
            while (dataReader.Read())
            {
                LagerPosition.lagerID = dataReader.GetInt32(0);
                LagerPosition.lagerObjektID = dataReader.GetInt32(1);
                LagerPosition.anzahl = dataReader.GetInt32(2);
            }
            return LagerPosition;
        }

        // POST: api/LagerPosition
        [HttpPost]
        public void Post([FromBody] object value)
        {
            JObject obj = JObject.Parse(value.ToString());
            string LagerObjektID = obj["LagerObjektID"].ToString();
            string Anzahl = obj["Anzahl"].ToString();
            LagerPosition LagerPos = new LagerPosition();
            LagerPos.lagerObjektID = int.Parse(LagerObjektID);
            LagerPos.anzahl = int.Parse(Anzahl);
            LagerPos.lagerObjektID = int.Parse("LagerArt");
        }

        // PUT: api/LagerPosition/5
        [HttpPut("{LagerID,LagerObjektID}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{LagerID,LagerObjektID}")]
        public void Delete(int id)
        {
        }
    }
}
