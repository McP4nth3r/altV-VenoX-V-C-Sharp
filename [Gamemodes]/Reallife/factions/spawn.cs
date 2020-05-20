//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
using AltV.Net;
using AltV.Net.Data;
using System;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.house;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;
using VenoXV.Anti_Cheat;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.factions
{
    public class Spawn : IScript
    {

        //[AltV.Net.ClientEvent("SpawnPlayer_On_Spawnpoint")]
        public static void spawnplayer_on_spawnpoint(Client player)
        {
            try
            {
                player.SpawnPlayer(player.Position);
                player.vnxSetElementData(EntityData.PLAYER_KILLED, 0);
                player.vnxSetStreamSharedElementData(EntityData.PLAYER_HUNGER, 100);
                player.Emit("start_screen_fx", "RaceTurbo", 2000, false);

                if (player.vnxGetElementData<int>(EntityData.PLAYER_KNASTZEIT) > 0)
                {
                    Random random = new Random();
                    int dim = random.Next(1, 9999);
                    player.Dimension = dim;
                    player.SetPosition = Constants.JAIL_SPAWNS[random.Next(3)];
                    player.vnxSetElementData(EntityData.PLAYER_HANDCUFFED, false);
                    player.Emit("toggleHandcuffed", false);
                    return;
                }
                if (player.vnxGetElementData<string>(EntityData.PLAYER_SPAWNPOINT) == "noobspawn")
                {
                    // Noob Spawn
                    player.SetPosition = new Position(-2286.745f, 356.3762f, 175.317f);
                }
                else if (player.vnxGetElementData<string>(EntityData.PLAYER_SPAWNPOINT) == "Rathaus")
                {
                    player.SetPosition = new Position(-533.1649f, -211.0938f, 37.64977f);
                }
                else if (player.vnxGetElementData<string>(EntityData.PLAYER_SPAWNPOINT) == "Wuerfelpark")
                {
                    player.SetPosition = new Position(180.3914f, -923.7885f, 30.68681f);
                }
                else
                {
                    if (player.vnxGetElementData<string>(EntityData.PLAYER_SPAWNPOINT) == "Basis")
                    {
                        //Dimension für Böse Fraktionen mit mehreren Gleichen interiors einstellen!.
                        if (Allround.isBadFaction(player))
                        {
                            player.Dimension = player.vnxGetElementData<int>(EntityData.PLAYER_FACTION);
                        }
                        if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_POLICE)
                        {
                            //LSPD Spawn
                            player.SetPosition = new Position(469.8354f, -985.0742f, 33.89248f);
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_COSANOSTRA)
                        {
                            //Mafia Spawn
                            player.SetPosition = new Position(266.2531f, -1007.264f, -101.0095f);
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_YAKUZA)
                        {
                            player.SetPosition = new Position(339.3727f, -997.0941f, -99.19626f);
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_TERRORCLOSED)
                        {
                            player.SetPosition = new Position(469.8354f, -985.0742f, 33.89248f);
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_NEWS)
                        {
                            player.SetPosition = new Position(-562.649f, -920.7836f, 23.87799f);
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_FBI)
                        {
                            player.SetPosition = new Position(139.1606f, -762.1356f, 45.75201f);
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_MS13)
                        {
                            player.SetPosition = new Position(-1283.504f, 432.7738f, 97.52215f);
                            player.Dimension = Constants.FACTION_MS13;
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_SAMCRO)
                        {
                            player.SetPosition = new Position(982.0083f, -100.8747f, 74.84512f);
                            //player.Dimension = Constants.FACTION_SAMCRO;
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_EMERGENCY)
                        {
                            player.Dimension = Constants.FACTION_NONE;
                            player.SetPosition = new Position(319.5905f, -560.0225f, 28.74378f);
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_BALLAS)
                        {
                            player.SetPosition = new Position(266.2531f, -1007.264f, -101.0095f);
                        }
                        else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_GROVE)
                        {
                            player.SetPosition = new Position(266.2531f, -1007.264f, -101.0095f);
                        }
                    }
                    else if (player.vnxGetElementData<string>(EntityData.PLAYER_SPAWNPOINT) == "HOTELLS")
                    {

                    }
                    else if (player.vnxGetElementData<string>(EntityData.PLAYER_SPAWNPOINT) == "HOTELLV")
                    {

                    }
                    else if (player.vnxGetElementData<string>(EntityData.PLAYER_SPAWNPOINT) == "House")
                    {
                        foreach (HouseModel house in House.houseList)
                        {
                            if (player.vnxGetElementData<int>(EntityData.PLAYER_RENT_HOUSE) > 0 || player.GetVnXName() == house.owner)
                            {
                                AntiCheat_Allround.SetTimeOutTeleport(player, 2000);
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
