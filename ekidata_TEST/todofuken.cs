using Newtonsoft.Json;
using System;
using System.Net;

namespace ConsoleApp1
{
    class todofuken
    {
        public static void pro1(int code)
        {
            string url = @"http://www.ekidata.jp/api/p/" + code + ".json";
            var wc = new WebClient();
            var json = wc.DownloadString(url);
            json = json.Replace("if(typeof(xml)=='undefined') xml = {};", "");
            json = json.Replace("xml.data = ", "");
            json = json.Replace("if(typeof(xml.onload)=='function') xml.onload(xml.data);", "");
            json = json.Replace("\n", "");

            var y = JsonConvert.DeserializeObject<Station>(json);
            for (int i = 0; i < y.Line.Length; i++)
            {
                Console.Write(y.Line[i].LineCd + " ");
                Console.WriteLine(y.Line[i].LineName);
            }
        }

        public partial class Station
        {
            [JsonProperty("line")]
            public Line[] Line { get; set; }
        }

        public partial class Line
        {
            [JsonProperty("line_cd")]
            public long LineCd { get; set; }

            [JsonProperty("line_name")]
            public string LineName { get; set; }
        }
    }
}
