//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
using AltV.Net;
using System;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.house;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Factions
{
    public class Spawn : IScript
    {

        //[AltV.Net.ClientEvent("SpawnPlayer_On_Spawnpoint")]
        public static void spawnplayer_on_spawnpoint(Client player)
        {
            try
            {
                player.SpawnPlayer(player.Position);
                player.Reallife.Hunger = 100;
                Alt.Server.TriggerClientEvent(player, "start_screen_fx", "RaceTurbo", 2000, false);
                player.Dimension = 0;
                if (player.Reallife.Knastzeit > 0)
                {
                    Random random = new Random();
                    int dim = random.Next(1, 9999);
                    player.Dimension = dim;
                    player.SetPosition = Constants.JAIL_SPAWNS[random.Next(3)];
                    player.vnxSetElementData(EntityData.PLAYER_HANDCUFFED, false);
                    Alt.Server.TriggerClientEvent(player, "toggleHandcuffed", false);
                    return;
                }
                if (player.Reallife.SpawnLocation == "noobspawn")
                {
                    // Noob Spawn
                    player.SetPosition = new Vector3(-2286.745f, 356.3762f, 175.317f);
                }
                else if (player.Reallife.SpawnLocation == "Rathaus")
                {
                    player.SetPosition = new Vector3(-533.1649f, -211.0938f, 37.64977f);
                }
                else if (player.Reallife.SpawnLocation == "Wuerfelpark")
                {
                    player.SetPosition = new Vector3(180.3914f, -923.7885f, 30.68681f);
                }
                else
                {
                    if (player.Reallife.SpawnLocation == "Basis")
                    {
                        //Dimension für Böse Fraktionen mit mehreren Gleichen interiors einstellen!.
                        if (Allround.isBadFaction(player))
                        {
                            player.Dimension = player.Reallife.Faction;
                        }
                        if (player.Reallife.Faction == Constants.FACTION_POLICE)
                        {
                            //LSPD Spawn
                            player.SetPosition = new Vector3(469.8354f, -985.0742f, 33.89248f);
                        }
                        else if (player.Reallife.Faction == Constants.FACTION_COSANOSTRA)
                        {
                            //Mafia Spawn
                            player.SetPosition = new Vector3(266.2531f, -1007.264f, -101.0095f);
                        }
                        else if (player.Reallife.Faction == Constants.FACTION_YAKUZA)
                        {
                            player.SetPosition = new Vector3(339.3727f, -997.0941f, -99.19626f);
                        }
                        else if (player.Reallife.Faction == Constants.FACTION_TERRORCLOSED)
                        {
                            player.SetPosition = new Vector3(469.8354f, -985.0742f, 33.89248f);
                        }
                        else if (player.Reallife.Faction == Constants.FACTION_NEWS)
                        {
                            player.SetPosition = new Vector3(-562.649f, -920.7836f, 23.87799f);
                        }
                        else if (player.Reallife.Faction == Constants.FACTION_FBI)
                        {
                            player.SetPosition = new Vector3(139.1606f, -762.1356f, 45.75201f);
                        }
                        else if (player.Reallife.Faction == Constants.FACTION_MS13)
                        {
                            player.SetPosition = new Vector3(-1283.504f, 432.7738f, 97.52215f);
                            player.Dimension = Constants.FACTION_MS13;
                        }
                        else if (player.Reallife.Faction == Constants.FACTION_USARMY)
                        {
                            if (player.Reallife.FactionRank == 0) { player.SetPosition = new Vector3(-2089.4636f, 3273.7056f, 32.801514f); }
                            else { player.SetPosition = new Vector3(468.65933f, -3205.8594f, 9.784668f); }
                        }
                        else if (player.Reallife.Faction == Constants.FACTION_SAMCRO)
                        {
                            player.SetPosition = new Vector3(982.0083f, -100.8747f, 74.84512f);
                            //player.Dimension = Constants.FACTION_SAMCRO;
                        }
                        else if (player.Reallife.Faction == Constants.FACTION_EMERGENCY)
                        {
                            player.Dimension = Constants.FACTION_NONE;
                            player.SetPosition = new Vector3(319.5905f, -560.0225f, 28.74378f);
                        }
                        else if (player.Reallife.Faction == Constants.FACTION_MECHANIK)
                        {
                            player.Dimension = Constants.FACTION_NONE;
                            player.SetPosition = new Vector3(-440.58463f, -1693.833f, 19.186768f);
                        }
                        else if (player.Reallife.Faction == Constants.FACTION_BALLAS)
                        {
                            player.SetPosition = new Vector3(266.2531f, -1007.264f, -101.0095f);
                        }
                        else if (player.Reallife.Faction == Constants.FACTION_GROVE)
                        {
                            player.SetPosition = new Vector3(266.2531f, -1007.264f, -101.0095f);
                        }
                    }
                    else if (player.Reallife.SpawnLocation == "HOTELLS")
                    {

                    }
                    else if (player.Reallife.SpawnLocation == "HOTELLV")
                    {

                    }
                    else if (player.Reallife.SpawnLocation == "House")
                    {
                        foreach (HouseModel house in House.houseList)
                        {
                            if (player.Reallife.HouseRent > 0 || player.Username == house.owner)
                            {
                                player.SetPosition = Main.GetHouseIplExit(house.ipl);
                                player.Dimension = house.id;
                                player.vnxSetElementData(EntityData.PLAYER_IPL, house.ipl);
                                player.vnxSetElementData(EntityData.PLAYER_HOUSE_ENTERED, house.id);
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

    }
}
