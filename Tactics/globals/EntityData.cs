using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace VenoXV.Tactics.globals
{
    public class EntityData : IScript
    {
        // Einzelne EntityDatas :)
        public static string PLAYER_JOINED_TACTICS = "PLAYER_JOINED_TACTICS";
        public static string PLAYER_SPAWNED_TACTICS = "PLAYER_SPAWNED_TACTICS";
        public static string PLAYER_CURRENT_TEAM = "PLAYER_CURRENT_TEAM";
        public static string PLAYER_DAMAGE_DONE = "PLAYER_DAMAGE_DONE";
        public static string PLAYER_KILLED_PLAYERS = "PLAYER_KILLED_PLAYERS";
        public static string PLAYER_IS_DEAD = "PLAYER_IS_DEAD";
        public static string PLAYER_LEFT_ROUND = "PLAYER_LEFT_ROUND";
        public static string PLAYER_DISCONNECTED_ROUND = "PLAYER_DISCONNECTED_ROUND";

        // STATIC STRINGS
        public static string BFAC_NAME = "Grove Street";
        public static Rgba BFAC_Rgba = new Rgba(0, 152, 0,255);
        public static string COPS_NAME = "L.S.P.D";
        public static Rgba COPS_Rgba = new Rgba(0, 140, 183, 255);


    }
}
