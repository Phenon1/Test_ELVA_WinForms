using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Test_ELVA_WinForms.Model
{
    class OSM : GeoPos
    {
        readonly static public string name= "Open Street Map";
        static GeoRootJSON geo;

        public class GeoRootJSON
        {
            public int place_id { get; set; }
            public string licence { get; set; }
            public string osm_type { get; set; }
            public int osm_id { get; set; }
            public string[] boundingbox { get; set; }
            public string lat { get; set; }
            public string lon { get; set; }
            public string display_name { get; set; }
            public string _class { get; set; }
            public string type { get; set; }
            public float importance { get; set; }
            public string icon { get; set; }
            public Geojson geojson { get; set; }
        }

        public class Geojson
        {
            public string type { get; set; }
            public float[][][][] coordinates { get; set; }
        }




        public string GetJson(string where)
        {
            connection = $"https://nominatim.openstreetmap.org/search?q={where}&format=json&polygon_geojson=1";
            Json = GetJsonFromURL();
            Json = Json.Remove(Json.Length - 1).Remove(0, 1);
            geo = JsonSerializer.Deserialize<GeoRootJSON>(Json);
            return Json;
        }
        public string Serilize()
        {
           return  JsonSerializer.Serialize(geo);
        }

        public void Trim(int step)
        {
            foreach(var r in geo.geojson.coordinates)
            {
                for (int j = 0; j < r.Length; j ++)
                {
                   List<float[]> newGeo = new List<float[]>();
                   for(int i=0;i<r[j].Length;i+=step)
                    {
                        newGeo.Add(r[j][i]);
                    }
                    r[j] = newGeo.ToArray();
                    
                }
            }
        }


    }
}
