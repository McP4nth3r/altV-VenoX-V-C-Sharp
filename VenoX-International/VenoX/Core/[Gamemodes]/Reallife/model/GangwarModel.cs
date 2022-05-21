using System;
using AltV.Net.Data;
using MySql.Data.MySqlClient;

namespace VenoX.Core._Gamemodes_.Reallife.model
{
    public class GangwarModel
    {

        public string GangAreaName { get; set; }
        public float GangAreaPosx { get; set; }
        public float GangAreaPosy { get; set; }
        public float GangAreaPosz { get; set; }
        public float GangAreaRadius { get; set; }
        public int GangAreaRotation { get; set; }
        public Position GangAreaPosition { get; set; }
        public float GangAreaTkPosx { get; set; }
        public float GangAreaTkPosy { get; set; }
        public float GangAreaTkPosz { get; set; }
        public Position GangAreaTkPosition { get; set; }
        public int Aktiv { get; set; }


        public int GangAreaOwner { get; set; }
        public DateTime GangAreaCooldown { get; set; }


        public GangwarModel(MySqlDataReader reader)
        {
            GangAreaName = reader.GetString("gang_area");
            GangAreaPosx = reader.GetFloat("gang_area_x");
            GangAreaPosy = reader.GetFloat("gang_area_y");
            GangAreaPosz = reader.GetFloat("gang_area_z");
            GangAreaRadius = reader.GetInt32("radius");
            GangAreaRotation = reader.GetInt32("rotation");
            GangAreaPosition = new Position(GangAreaPosx, GangAreaPosy, GangAreaPosz);
            GangAreaTkPosx = reader.GetFloat("tk_x");
            GangAreaTkPosy = reader.GetFloat("tk_y");
            GangAreaTkPosz = reader.GetFloat("tk_z");
            GangAreaTkPosition = new Position(GangAreaTkPosx, GangAreaTkPosy, GangAreaTkPosz);
            GangAreaOwner = reader.GetInt32("FID");
            GangAreaCooldown = reader.GetDateTime("cooldown");
            Aktiv = reader.GetInt32("activated");

        }
    }
}
