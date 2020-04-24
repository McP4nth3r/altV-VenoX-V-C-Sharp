using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using MySql.Data.MySqlClient;
using System;
using VenoXV._Gamemodes_.Reallife.Globals;

namespace VenoXV._Gamemodes_.Reallife.model
{
    public class GangwarModel
    {

        public string gang_area_name { get; set; }
        public float gang_area_posx { get; set; }
        public float gang_area_posy { get; set; }
        public float gang_area_posz { get; set; }
        public float gang_area_radius { get; set; }
        public int gang_area_rotation { get; set; }
        public Position gang_area_position { get; set; }
        public float gang_area_tk_posx { get; set; }
        public float gang_area_tk_posy { get; set; }
        public float gang_area_tk_posz { get; set; }
        public Position gang_area_tk_position { get; set; }
        public int aktiv { get; set; }


        public int GANG_AREA_OWNER { get; set; }
        public DateTime GANG_AREA_COOLDOWN { get; set; }


        public GangwarModel(MySqlDataReader reader)
        {
            this.gang_area_name = reader.GetString("gang_area");
            this.gang_area_posx = reader.GetFloat("gang_area_x");
            this.gang_area_posy = reader.GetFloat("gang_area_y");
            this.gang_area_posz = reader.GetFloat("gang_area_z");
            this.gang_area_radius = reader.GetInt32("radius");
            this.gang_area_rotation = reader.GetInt32("rotation");
            this.gang_area_position = new Position(gang_area_posx, gang_area_posy, gang_area_posz);
            this.gang_area_tk_posx = reader.GetFloat("tk_x");
            this.gang_area_tk_posy = reader.GetFloat("tk_y");
            this.gang_area_tk_posz = reader.GetFloat("tk_z");
            this.gang_area_tk_position = new Position(gang_area_tk_posx, gang_area_tk_posy, gang_area_tk_posz);
            this.GANG_AREA_OWNER = reader.GetInt32("FID");
            this.GANG_AREA_COOLDOWN = reader.GetDateTime("cooldown");
            this.aktiv = reader.GetInt32("activated");

        }
    }
}
