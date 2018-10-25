using Xunit;
using LagerVerwaltungWebServiceApi.Model;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;

namespace XUnitTestProjectLagerVerwaltungWebService
{
    public class UnitTestLager
    {
        [Fact]
        public void LagerGetID2ByID2()
        {
            var request = (HttpWebRequest)WebRequest.Create("https://localhost:44323/api/Lager/2");
            request.Method = "GET";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            var response = (HttpWebResponse)request.GetResponse();
            string content = string.Empty;

            using (var stream = response.GetResponseStream())
            {
                using (var sr = new StreamReader(stream))
                {
                    content = sr.ReadToEnd();
                }
            }
            var releases = JObject.Parse(content);

            for (int i = 0; i <= releases.Count; i++)
            {
                var x = releases.Children();
            }
            Assert.True(releases["id"].ToString() == 2.ToString());
        }

        [Fact]
        public void LagerGetAllByGet()
        {
            var request = (HttpWebRequest)WebRequest.Create("https://localhost:44323/api/Lager");
            request.Method = "GET";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            var response = (HttpWebResponse)request.GetResponse();
            string content = string.Empty;

            using (var stream = response.GetResponseStream())
            {
                using (var sr = new StreamReader(stream))
                {
                    content = sr.ReadToEnd();
                }
            }

            IList lagerListe = new List<Lager>();

            
            var JsonObjectliste = Newtonsoft.Json.JsonConvert.DeserializeObject(content);
            var liste = JsonObjectliste as JToken;

            IList sammlung = new List<JToken>();
            JToken x = liste[2];
            Assert.True(x["id"].ToString() == 3.ToString());
        }
    }
}