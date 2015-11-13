using Newtonsoft.Json;
using System.Collections.Generic;

namespace App2
{
    //"<root>\r\n  <data value=\"2\">1</data>\r\n  <list>0</list>\r\n</root>"

    public class Car
    {
        public Root root { get; set; }
    }

    public class Root
    {
        public Data data { get; set; }

        [JsonConverter(typeof(MyJsonConverter<string>))]
        public List<string> list { get; set; }
    }

    public class Data
    {
        [JsonProperty("@value")]
        public string value { get; set; }

        [JsonProperty("#text")]
        public string text { get; set; }
    }
}