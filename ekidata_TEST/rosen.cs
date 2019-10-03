using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ConsoleApp1
{
    class rosen
    {
        public static void pro2(int code)
        {
            string url = @"http://www.ekidata.jp/api/l/" + code + ".json";
            var wc = new WebClient();
            var json = wc.DownloadString(url);
            json = json.Replace("if(typeof(xml)=='undefined') xml = {};", "");
            json = json.Replace("xml.data = ", "");
            json = json.Replace("if(typeof(xml.onload)=='function') xml.onload(xml.data);", "");
            json = json.Replace("\n", "");

            var y = JsonConvert.DeserializeObject<Station1>(json);
            for (int i = 0; i < y.StationL.Length; i++)
            {
                Console.Write(y.StationL[i].StationGCd+" ");
                Console.WriteLine(y.StationL[i].StationName);
            }
        }
        public partial class Station1
        {
            [JsonProperty("line_cd")]
            public long LineCd { get; set; }

            [JsonProperty("line_name")]
            public string LineName { get; set; }

            [JsonProperty("line_lon")]
            public double LineLon { get; set; }

            [JsonProperty("line_lat")]
            public double LineLat { get; set; }

            [JsonProperty("line_zoom")]
            public long LineZoom { get; set; }

            [JsonProperty("station_l")]
            public StationL[] StationL { get; set; }
        }

        public partial class StationL
        {
            [JsonProperty("station_cd")]
            public long StationCd { get; set; }

            [JsonProperty("station_g_cd")]
            public long StationGCd { get; set; }

            [JsonProperty("station_name")]
            public string StationName { get; set; }

            [JsonProperty("lon")]
            public double Lon { get; set; }

            [JsonProperty("lat")]
            public double Lat { get; set; }
        }
    }
}
