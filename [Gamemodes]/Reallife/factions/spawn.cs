//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

using System;
using System.Linq;
using System.Numerics;
using AltV.Net;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.house;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV.Core;
using VenoXV.Models;
using Main = VenoXV._Globals_.Main;

namespace VenoXV.Reallife.factions
{
    public class Spawn : IScript
    {
        //ColShapeModel SpawnLSPD = RageAPI.CreateColShapeSphere(new Vector3(469.8354f, -985.0742f, 33.89248f), 3, VenoXV.Globals.Main.REALLIFE_DIMENSION);
        //ColShapeModel SpawnARMY = RageAPI.CreateColShapeSphere(new Vector3(468.65933f, -3205.8594f, 9.784668f), 3, VenoXV.Globals.Main.REALLIFE_DIMENSION);
        //ColShapeModel SpawnARMY2 = RageAPI.CreateColShapeSphere(new Vector3(-2089.4636f, 3273.7056f, 32.801514f), 3, VenoXV.Globals.Main.REALLIFE_DIMENSION);

        public static void SpawnPlayerOnSpawnpoint(VnXPlayer player)
        {
            try
            {
                player.Reallife.Hunger = 100;
                VenoX.TriggerClientEvent(player, "start_screen_fx", "RaceTurbo", 2000, false);
                player.Dimension = Main.ReallifeDimension;
                player.Freeze = true;
                player.FreezeAfterMs(10000, false);
                if (player.Reallife.JailTime > 0)
                {
                    Random random = new Random();
                    int dim = random.Next(1, 9999);
                    player.Dimension = dim;
                    player.SetPosition = Constants.JailSpawns[random.Next(3)];
                    player.Reallife.Handcuffed = false;
                    return;
                }
                if (player.Reallife.Faction != Constants.FactionNone) player.SetTeam(player.Reallife.Faction);
                else player.SetTeam(player.Id + 153);
                
                switch (player.Reallife.SpawnLocation)
                {
                    case "noobspawn":
                        player.SetPosition = new Vector3(-2286.745f, 356.3762f, 175.317f);
                        return;
                    case "Rathaus":
                        player.SetPosition = new Vector3(-533.1649f, -211.0938f, 37.64977f);
                        return;
                    case "Wuerfelpark":
                        player.SetPosition = new Vector3(180.3914f, -923.7885f, 30.68681f);
                        return;
                    case "Street":
                        player.SpawnPlayer(player.Reallife.LastPosition);
                        return;
                    case "Basis":
                        switch (player.Reallife.Faction)
                        {
                            case Constants.FactionLspd:
                                player.SetPosition = new Vector3(469.8354f, -985.0742f, 33.89248f);
                                return;
                            case Constants.FactionLcn:
                                player.Dimension = player.Reallife.Faction;
                                player.SetPosition = new Vector3(266.2531f, -1007.264f, -101.0095f);
                                return;
                            case Constants.FactionYakuza:
                                player.Dimension = player.Reallife.Faction;
                                player.SetPosition = new Vector3(339.3727f, -997.0941f, -99.19626f);
                                return;
                            case Constants.FactionTerrorclosed:
                                player.SetPosition = new Vector3(469.8354f, -985.0742f, 33.89248f);
                                return;
                            case Constants.FactionNews:
                                player.SetPosition = new Vector3(-562.649f, -920.7836f, 23.87799f);
                                return;
                            case Constants.FactionFbi:
                                player.SetPosition = new Vector3(139.1606f, -762.1356f, 45.75201f);
                                return;
                            case Constants.FactionNarcos:
                                player.Dimension = player.Reallife.Faction;
                                player.SetPosition = new Vector3(-1283.504f, 432.7738f, 97.52215f);
                                return;
                            case Constants.FactionUsarmy:
                                player.SetPosition = new Vector3(468.65933f, -3205.8594f, 9.784668f);
                                return;
                            case Constants.FactionSamcro:
                                player.SetPosition = new Vector3(982.0083f, -100.8747f, 74.84512f);
                                return;
                            case Constants.FactionEmergency:
                                player.SetPosition = new Vector3(319.5905f, -560.0225f, 28.74378f);
                                return;
                            case Constants.FactionMechanik:
                                player.SetPosition = new Vector3(482.47913f, -1312.9846f, 29.195557f);
                                return;
                            case Constants.FactionBallas:
                                player.Dimension = player.Reallife.Faction;
                                player.SetPosition = new Vector3(266.2531f, -1007.264f, -101.0095f);
                                return;
                            case Constants.FactionCompton:
                                player.Dimension = player.Reallife.Faction;
                                player.SetPosition = new Vector3(266.2531f, -1007.264f, -101.0095f);
                                return;
                        }
                        return;
                    case "Basis-2":
                        if (player.Reallife.Faction == Constants.FactionUsarmy)
                            player.SetPosition = new Vector3(-2089.4636f, 3273.7056f, 32.801514f);
                        break;
                    case "House":
                        foreach (var house in House.HouseList.ToList().Where(house => player.Reallife.HouseRent > 0 || player.Username == house.Owner))
                        {
                            player.SetPosition = House.GetHouseExitPoint(house.Ipl);
                            player.Dimension = house.Id;
                            player.Reallife.HouseIpl = house.Ipl;
                            player.Reallife.HouseEntered = house.Id;
                        }
                        return;
                }
                
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

    }
}
