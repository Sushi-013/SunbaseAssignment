using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataUtils
{
    public class Client
    {
        public bool isManager { get; set; }
        public int id { get; set; }
        public string label { get; set; }
    }

    public class ClientData
    {
        public string address { get; set; }
        public string name { get; set; }
        public int points { get; set; }
    }

    public class Data
    {
        [JsonProperty("1")]
        public ClientData _1 { get; set; }

        [JsonProperty("2")]
        public ClientData _2 { get; set; }

        [JsonProperty("3")]
        public ClientData _3 { get; set; }
    }

    public class Root
    {
        public List<Client> clients { get; set; }
        public Data data { get; set; }
        public string label { get; set; }

    }
}
