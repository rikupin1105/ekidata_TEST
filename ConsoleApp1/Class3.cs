using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ConsoleApp1
{
    class Class3
    {
        public static void pro3(int code)
        {
            string url = @"http://www.ekidata.jp/api/g/" + code + ".json";
            var wc = new WebClient();
            var json = wc.DownloadString(url);
            json = json.Replace("if(typeof(xml)=='undefined') xml = {};", "");
            json = json.Replace("xml.data = ", "");
            json = json.Replace("if(typeof(xml.onload)=='function') xml.onload(xml.data);", "");
            json = json.Replace("\n", "");

            var y = JsonConvert.DeserializeObject<Station1>(json);
            for (int i = 0; i < y.StationG.Length; i++)
            {
                Console.WriteLine(y.StationG[i].LineName);
            }
        }
        public partial class Station1
        {
            [JsonProperty("station_g")]
            public StationG[] StationG { get; set; }
        }

        public partial class StationG
        {
            [JsonProperty("pref_cd")]
            public long PrefCd { get; set; }

            [JsonProperty("line_cd")]
            public long LineCd { get; set; }

            [JsonProperty("line_name")]
            public string LineName { get; set; }

            [JsonProperty("station_cd")]
            public long StationCd { get; set; }

            [JsonProperty("station_name")]
            public string StationName { get; set; }
        }
    }
}
