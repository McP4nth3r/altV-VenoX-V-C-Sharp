using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV.Reallife.admin;
using VenoXV.Anti_Cheat;
using VenoXV.Reallife.anzeigen.Usefull;
using VenoXV.Reallife.character;
using VenoXV.Reallife.database;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.model;
using VenoXV.Reallife.Core;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using AltV.Net.Data;

namespace VenoXV.Reallife.factions
{
    public class Allround : IScript
    {
        public static Position LCN_Teleport_Base_Enter = new Position(-1038.044f, 222.168f, 64.37566f);
        public static Position LCN_Teleport_Base_Exit = new Position(266.1213f, -1007.609f, -101.0086f);

        public static Position FIB_Teleport_Heli_Exit = new Position(141.338f, -734.9205f, 262.8516f);
        public static Position FIB_Teleport_Heli_Enter = new Position(142.3689f, -769.2345f, 45.75201f);
        public static Position FIB_Teleport_Garage_Exit = new Position(144.0502f, -688.8917f, 33.12821f);
        public static Position FIB_Teleport_Garage_Enter = new Position(141.121f, -765.5373f, 45.75201f);

        public static Position Emergency_Teleport_Heli_Enter = new Position(359.6378f, -584.9634f, 28.81754f);
        public static Position Emergency_Teleport_Heli_Exit = new Position(338.7505f, -583.8655f, 74.16565f);

        public static Position Ballas_Teleport_Base_Enter = new Position(294.0073f, -2087.792f, 17.66358f);
        public static Position Ballas_Teleport_Base_Exit = new Position(266.1213f, -1007.609f, -101.0086f);

        public static Position Compton_Teleport_Base_Enter = new Position(126.6941f, -1930.021f, 21.38243f);
        public static Position Compton_Teleport_Base_Exit = new Position(266.1213f, -1007.609f, -101.0086f);

        public static Position YAKUZA_Teleport_Base_Enter = new Position(-1516.701f, 851.7410f, 181.5947f);
        public static Position YAKUZA_Teleport_Base_Exit = new Position(346.4642f, -1013.237f, -99.19626f);

        public static Position MS13_Teleport_Base_Enter = new Position(-1549.369f, -91.01895f, 54.92917f);
        public static Position MS13_Teleport_Base_Exit = new Position(-1289.76f, 449.9201f, 97.90071f);

        public static Position SAM_Teleport_Base_Enter = new Position(982.1898f, -103.258f, 74.84872f); // 982,1898, -103,258, 74,84872
        public static Position SAM_Teleport_Base_Exit = new Position(981.1188f, -102.3915f, 74.84511f); // 981.1188, -102.3915, 74.84511

        public static Position MS13_Teleport_Base_heli_Enter = new Position(-1554.938f, -115.0005f, 54.51854f);
        public static Position MS13_Teleport_Base_heli_Exit = new Position(-1553.669f, -106.2555f, 67.1683f);

        public static Position LCN_Teleport_Base_heli_Enter = new Position(-1043.062f, 237.1805f, 64.16475f);
        public static Position LCN_Teleport_Base_heli_Exit = new Position(-1045.745f, 236.1165f, 71.88445f);




        public static Position LSPD_FGUNS_COL = new Position(451.5455f, -993.3593f, 30.6896f);
        public static IColShape LSPDCOL_FGUNS = Alt.CreateColShapeSphere( LSPD_FGUNS_COL,2f );

        public static Position FBI_FGUNS_COL = new Position(136.1328f, -761.8464f, 45.75203f);
        public static IColShape FBICOL_FGUNS = Alt.CreateColShapeSphere(  FBI_FGUNS_COL, 1.5f);


        public static Position BAD_INTERIOR_FGUNS_COL = new Position(256.6112f, -996.761f, -99.00867f);
        public static Position BAD_INTERIOR2_FGUNS_COL = new Position(350.1265f, -993.4926f, -99.19615f);
        public static Position BAD_INTERIOR3_FGUNS_COL = new Position(973.5081f, -101.8594f, 74.84988f);
        public static Position BAD_INTERIOR4_FGUNS_COL = new Position(-1286.099f, 438.3797f, 94.09482f);
        public static IColShape BAD_INTERIOR_FGUNS = Alt.CreateColShapeSphere(BAD_INTERIOR_FGUNS_COL, 1.5f);
        public static IColShape BAD_INTERIOR2_FGUNS = Alt.CreateColShapeSphere(BAD_INTERIOR2_FGUNS_COL, 1.5f);
        public static IColShape BAD_INTERIOR3_FGUNS = Alt.CreateColShapeSphere(BAD_INTERIOR3_FGUNS_COL, 1.5f);
        public static IColShape BAD_INTERIOR4_FGUNS = Alt.CreateColShapeSphere(BAD_INTERIOR4_FGUNS_COL, 1.5f);
        

        public static void OnResourceStart()
        {
            
            BAD_INTERIOR3_FGUNS.Dimension = Constants.FACTION_SAMCRO;
            BAD_INTERIOR4_FGUNS.Dimension = Constants.FACTION_MS13;
            //ToDo: ClientSide erstellen NAPI.
            //.CreateTextLabel("LCN Eingang", LCN_Teleport_Base_Enter, 10.0f, 0.5f, 4, new Rgba(40, 40, 40, 255));
            RageAPI.CreateTextLabel("LCN Eingang", LCN_Teleport_Base_Enter, 10.0f, 0.5f, 4, new Rgba(40, 40, 40, 255));
            RageAPI.CreateTextLabel("LCN Ausgang", LCN_Teleport_Base_Exit, 10.0f, 0.5f, 4, new Rgba(40, 40, 40, 255), Constants.FACTION_COSANOSTRA);

            RageAPI.CreateTextLabel("Yakuza Eingang", YAKUZA_Teleport_Base_Enter, 10.0f, 0.5f, 4, new Rgba(175, 0, 0, 255));
            RageAPI.CreateTextLabel("Yakuza Ausgang", YAKUZA_Teleport_Base_Exit, 10.0f, 0.5f, 4, new Rgba(175, 0, 0, 255), Constants.FACTION_YAKUZA);

            RageAPI.CreateTextLabel("Mitarbeiter Ausgang", FIB_Teleport_Heli_Exit, 10.0f, 0.5f, 4, new Rgba(0, 86, 184, 255));
            RageAPI.CreateTextLabel("Mitarbeiter Eingang", FIB_Teleport_Heli_Enter, 10.0f, 0.5f, 4, new Rgba(0, 86, 184, 255));
            RageAPI.CreateTextLabel("Tiefgaragen Ausgang", FIB_Teleport_Garage_Exit, 10.0f, 0.5f, 4, new Rgba(0, 86, 184, 255));
            RageAPI.CreateTextLabel("Tiefgaragen Eingang", FIB_Teleport_Garage_Enter, 10.0f, 0.5f, 4, new Rgba(0, 86, 184, 255));

            RageAPI.CreateTextLabel("Mitarbeiter Eingang", Emergency_Teleport_Heli_Enter, 10.0f, 0.5f, 4, new Rgba(255, 51, 51, 255));
            RageAPI.CreateTextLabel("Mitarbeiter Ausgang", Emergency_Teleport_Heli_Exit, 10.0f, 0.5f, 4, new Rgba(255, 51, 51, 255));

            RageAPI.CreateTextLabel("Narcos Eingang", MS13_Teleport_Base_Enter, 10.0f, 0.5f, 4, new Rgba(128, 129, 150, 255));
            RageAPI.CreateTextLabel("Narcos Ausgang", MS13_Teleport_Base_Exit, 10.0f, 0.5f, 4, new Rgba(128, 129, 150, 255), Constants.FACTION_MS13);

            RageAPI.CreateTextLabel("SAMCRO Eingang", SAM_Teleport_Base_Enter, 10.0f, 0.5f, 4, new Rgba(128, 129, 150, 255));
            RageAPI.CreateTextLabel("SAMCRO Ausgang", SAM_Teleport_Base_Exit, 10.0f, 0.5f, 4, new Rgba(128, 129, 150, 255), Constants.FACTION_SAMCRO);

            RageAPI.CreateTextLabel("Narcos Dach Eingang", MS13_Teleport_Base_heli_Enter, 10.0f, 0.5f, 4, new Rgba(128, 129, 150, 255), Constants.FACTION_NONE);
            RageAPI.CreateTextLabel("Narcos Dach Ausgang", MS13_Teleport_Base_heli_Exit, 10.0f, 0.5f, 4, new Rgba(128, 129, 150, 255), Constants.FACTION_NONE);

            RageAPI.CreateTextLabel("Mafia Dach Eingang", LCN_Teleport_Base_heli_Enter, 10.0f, 0.5f, 4, new Rgba(40, 40, 40, 255), Constants.FACTION_NONE);
            RageAPI.CreateTextLabel("Mafia Dach Ausgang", LCN_Teleport_Base_heli_Exit, 10.0f, 0.5f, 4, new Rgba(40, 40, 40, 255), Constants.FACTION_NONE);

            RageAPI.CreateTextLabel("Rollin Height´s Eingang", Ballas_Teleport_Base_Enter, 10.0f, 0.5f, 4, new Rgba(138, 43, 226, 255));
            RageAPI.CreateTextLabel("Rollin Height´s Ausgang", Ballas_Teleport_Base_Exit, 10.0f, 0.5f, 4, new Rgba(138, 43, 226, 255), Constants.FACTION_BALLAS);
            RageAPI.CreateTextLabel("Danke für Alles" + "\n_______________\n" + "For Palma", new Position(276.7415f, -2066.709f, 17.17801f), 10.0f, 0.5f, 4, new Rgba(138, 43, 226, 255), 0);


            RageAPI.CreateTextLabel("Compton Family´s Eingang", Compton_Teleport_Base_Enter, 10.0f, 0.5f, 4, new Rgba(0, 152, 0, 255));
            RageAPI.CreateTextLabel("Compton Family´s Ausgang", Compton_Teleport_Base_Exit, 10.0f, 0.5f, 4, new Rgba(0, 152, 0, 255), Constants.FACTION_GROVE);


            //ToDo: Requesting Offices NAPI.World.RequestIpl ("ex_sm_15_office_01b");


            /* IColShapes */

            RageAPI.CreateTextLabel("L.S.P.D Equip", LSPD_FGUNS_COL, 10.0f, 0.5f, 4, new Rgba(0, 105, 145, 255));

            RageAPI.CreateTextLabel("F.I.B Equip", FBI_FGUNS_COL, 10.0f, 0.5f, 4, new Rgba(0, 86, 184, 255));


            RageAPI.CreateTextLabel("BAD Equip", BAD_INTERIOR_FGUNS_COL, 10.0f, 0.5f, 4, new Rgba(200, 0, 0, 255));
            RageAPI.CreateTextLabel("BAD Equip", BAD_INTERIOR2_FGUNS_COL, 10.0f, 0.5f, 4, new Rgba(200, 0, 0, 255));
            RageAPI.CreateTextLabel("BAD Equip", BAD_INTERIOR3_FGUNS_COL, 10.0f, 0.5f, 4, new Rgba(200, 0, 0, 255));
            RageAPI.CreateTextLabel("BAD Equip", BAD_INTERIOR4_FGUNS_COL, 10.0f, 0.5f, 4, new Rgba(200, 0, 0, 255));

            BAD_INTERIOR_FGUNS.SetData("isWeaponSelectShape", true);
            BAD_INTERIOR2_FGUNS.SetData("isWeaponSelectShape", true);
            BAD_INTERIOR3_FGUNS.SetData("isWeaponSelectShape", true);
            BAD_INTERIOR4_FGUNS.SetData("isWeaponSelectShape", true);

        }

        public static void OnPlayerEnterIColShape(IColShape shape, IPlayer player)
        {
            try
            {
                if (shape == LSPDCOL_FGUNS)
                {
                    if(isStateFaction(player))
                    {
                        Fraktions_Waffenlager fweapon = Database.GetFactionWaffenlager(Constants.FACTION_POLICE);
                        player.Emit("showStateWeaponWindow",

                        "Schlagstock [" + fweapon.weapon_nightstick + "/" + Constants.NIGHTSTICK_MAX_LAGER + "]",

                        "Tazer [" + fweapon.weapon_tazer + "/" + Constants.STUNGUN_MAX_LAGER + "]",

                        "Pistol [" + fweapon.weapon_pistol + "/" + Constants.PISTOL_MAX_LAGER + "]",

                        "Pistol 50 [" + fweapon.weapon_pistol50 + "/" + Constants.PISTOL50_MAX_LAGER + "]",

                        "Shotgun [" + fweapon.weapon_pumpshotgun + "/" + Constants.SHOTGUN_MAX_LAGER + "]",

                        "Einsatz PDW[" + fweapon.weapon_combatpdw + "/" + Constants.COMBATPDW_MAX_LAGER + "]",

                        "Karabiner [" + fweapon.weapon_carbinerifle + "/" + Constants.KARABINER_MAX_LAGER + "]",

                        "Advancedrifle[" + fweapon.weapon_advancedrifle + "/" + Constants.ADVANCEDRIFLE_MAX_LAGER + "]",

                        "Sniper [" + fweapon.weapon_sniperrifle + "/" + Constants.SNIPER_MAX_LAGER + "]",

                        "<br>Pistolen Magazin : " + fweapon.weapon_pistol_ammo+
                        "<br>Pistol50 Magazin : " + fweapon.weapon_pistol50_ammo +
                        "<br>Shotgun Magazin : " + fweapon.weapon_pumpshotgun_ammo +
                        "<br>PDW Magazin : " + fweapon.weapon_combatpdw_ammo +
                        "<br>Karabiner Magazin : " + fweapon.weapon_carbinerifle_ammo +
                        "<br>Advanced Magazin : " + fweapon.weapon_advancedrifle_ammo +
                        "<br>Sniper Magazin : " + fweapon.weapon_sniperrifle_ammo,

                        player.vnxGetElementData<int>(EntityData.PLAYER_RANK));
                    }
                }
                else if(shape == FBICOL_FGUNS)
                {
                    if (isStateFaction(player))
                    {
                        Fraktions_Waffenlager fweapon = Database.GetFactionWaffenlager(Constants.FACTION_POLICE);
                        player.Emit("showStateWeaponWindow",

                        "Schlagstock [" + fweapon.weapon_nightstick + "/" + Constants.NIGHTSTICK_MAX_LAGER + "]",

                        "Tazer [" + fweapon.weapon_tazer + "/" + Constants.STUNGUN_MAX_LAGER + "]",

                        "Pistol [" + fweapon.weapon_pistol + "/" + Constants.PISTOL_MAX_LAGER + "]",

                        "Pistol 50 [" + fweapon.weapon_pistol50 + "/" + Constants.PISTOL50_MAX_LAGER + "]",

                        "Shotgun [" + fweapon.weapon_pumpshotgun + "/" + Constants.SHOTGUN_MAX_LAGER + "]",

                        "Einsatz PDW[" + fweapon.weapon_combatpdw + "/" + Constants.COMBATPDW_MAX_LAGER + "]",

                        "Karabiner [" + fweapon.weapon_carbinerifle + "/" + Constants.KARABINER_MAX_LAGER + "]",

                        "Advancedrifle[" + fweapon.weapon_advancedrifle + "/" + Constants.ADVANCEDRIFLE_MAX_LAGER + "]",

                        "Sniper [" + fweapon.weapon_sniperrifle + "/" + Constants.SNIPER_MAX_LAGER + "]",

                        "<br>Pistolen Magazin : " + fweapon.weapon_pistol_ammo +
                        "<br>Pistol50 Magazin : " + fweapon.weapon_pistol50_ammo +
                        "<br>Shotgun Magazin : " + fweapon.weapon_pumpshotgun_ammo +
                        "<br>PDW Magazin : " + fweapon.weapon_combatpdw_ammo +
                        "<br>Karabiner Magazin : " + fweapon.weapon_carbinerifle_ammo +
                        "<br>Advanced Magazin : " + fweapon.weapon_advancedrifle_ammo +
                        "<br>Sniper Magazin : " + fweapon.weapon_sniperrifle_ammo,

                        player.vnxGetElementData<int>(EntityData.PLAYER_RANK));
                    }
                }
                else if(shape.vnxGetElementData<bool>("isWeaponSelectShape") == true)
                {
                    if (isBadFaction(player))
                    {
                        Fraktions_Waffenlager fweapon = Database.GetFactionWaffenlager(player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                        player.Emit("showBadWeaponWindow",

                        "Baseball [" + fweapon.weapon_baseball + "/" + Constants.BASEBALL_MAX_LAGER + "]",

                        "Pistol [" + fweapon.weapon_pistol + "/" + Constants.PISTOL_MAX_LAGER + "]",

                        "Pistol 50 [" + fweapon.weapon_pistol50 + "/" + Constants.PISTOL50_MAX_LAGER + "]",

                        "Revoler [" + fweapon.weapon_revolver + "/" + Constants.REVOLVER_MAX_LAGER + "]",

                        "Mp5 [" + fweapon.weapon_mp5 + "/" + Constants.MP5_MAX_LAGER + "]",

                        "Ak47 [" + fweapon.weapon_assaultrifle + "/" + Constants.AK47_MAX_LAGER + "]",

                        "Rifle [" + fweapon.weapon_rifle + "/" + Constants.RIFLE_MAX_LAGER + "]",

                        "Sniper[" + fweapon.weapon_sniperrifle + "/" + Constants.SNIPER_MAX_LAGER + "]",

                        "RPG [" + fweapon.weapon_rpg + "/" + Constants.RPG_MAX_LAGER + "]",

                        "<br>Baseball : " + fweapon.weapon_baseball +
                        "<br>Pistol Magazin : " + fweapon.weapon_pistol_ammo +
                        "<br>Pistol50 Magazin : " + fweapon.weapon_pistol50_ammo +
                        "<br>Revoler Magazin : " + fweapon.weapon_revolver_ammo +
                        "<br>Mp5 Magazin : " + fweapon.weapon_mp5_ammo +
                        "<br>Ak47 Magazin : " + fweapon.weapon_assaultrifle_ammo +
                        "<br>Rifle Magazin : " + fweapon.weapon_rifle_ammo +
                        "<br>Sniper Magazin : " + fweapon.weapon_sniperrifle_ammo +
                        "<br>RPG Magazin : " + fweapon.weapon_rpg_ammo,

                        player.vnxGetElementData<int>(EntityData.PLAYER_RANK));
                    }
                }
            }
            catch { }
        }

        public static bool isBadFaction(IPlayer player)
        {
            try
            {
                int player_Fraktion = player.vnxGetElementData<int>(EntityData.PLAYER_FACTION);
                if
                (player_Fraktion == Constants.FACTION_COSANOSTRA || player_Fraktion == Constants.FACTION_YAKUZA ||
                player_Fraktion == Constants.FACTION_MS13 || player_Fraktion == Constants.FACTION_SAMCRO ||
                player_Fraktion == Constants.FACTION_BALLAS || player_Fraktion == Constants.FACTION_GROVE)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool isStateFaction(IPlayer player)
        {
            try
            {
                int player_Fraktion = player.vnxGetElementData<int>(EntityData.PLAYER_FACTION);
                if (player_Fraktion == Constants.FACTION_POLICE || player_Fraktion == Constants.FACTION_FBI || player_Fraktion == Constants.FACTION_USARMY)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }
        public static bool isStateIVehicle(IVehicle Vehicle)
        {
            try
            {
                int VEHICLE_Fraktion = Vehicle.vnxGetElementData<int>(EntityData.VEHICLE_FACTION);
                if (VEHICLE_Fraktion == Constants.FACTION_POLICE || VEHICLE_Fraktion == Constants.FACTION_FBI || VEHICLE_Fraktion == Constants.FACTION_USARMY)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool isBadIVehicle(IVehicle Vehicle)
        {
            try
            {
                int VEHICLE_Fraktion = Vehicle.vnxGetElementData<int>(EntityData.VEHICLE_FACTION);
                if (VEHICLE_Fraktion == Constants.FACTION_COSANOSTRA || VEHICLE_Fraktion == Constants.FACTION_YAKUZA || VEHICLE_Fraktion == Constants.FACTION_MS13|| VEHICLE_Fraktion == Constants.FACTION_SAMCRO|| VEHICLE_Fraktion == Constants.FACTION_BALLAS|| VEHICLE_Fraktion == Constants.FACTION_GROVE)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool isNeutralIVehicle(IVehicle Vehicle)
        {
            try
            {
                int VEHICLE_Fraktion = Vehicle.vnxGetElementData<int>(EntityData.VEHICLE_FACTION);
                if (VEHICLE_Fraktion == Constants.FACTION_NEWS || VEHICLE_Fraktion == Constants.FACTION_EMERGENCY || VEHICLE_Fraktion == Constants.FACTION_MECHANIK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
            return false;
            }
        }


        public static bool isNeutralFaction(IPlayer player)
        {
            try
            {
                int player_Fraktion = player.vnxGetElementData<int>(EntityData.PLAYER_FACTION);
                if (player_Fraktion == Constants.FACTION_EMERGENCY || player_Fraktion == Constants.FACTION_NEWS || player_Fraktion == Constants.FACTION_MECHANIK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {

            }
            return false;
        }


        public static bool IsNearFactionTeleporter(IPlayer player)
        {
            try
            {
                int player_Fraktion = player.vnxGetElementData<int>(EntityData.PLAYER_FACTION);

                if (player_Fraktion == Constants.FACTION_NONE)
                {
                    return false;
                }
                int Anticheat_Teleport_MSTIME = 1000;


                if (player_Fraktion == Constants.FACTION_COSANOSTRA || isStateFaction(player) || Admin.HaveAdminRights(player))
                {
                    // Eingang
                    if (LCN_Teleport_Base_Enter.Distance(player.Position) < 1.25f)
                    {
                        if(player.vnxGetElementData<bool>("TELEPORT_ANTICHEAT_COOLDOWN") == true)
                        {
                            dxLibary.VnX.DrawNotification(player, "warning", "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetData("TELEPORT_ANTICHEAT_COOLDOWN", true);
                        Core.VnX.SetDelayedBoolSharedData(player, "TELEPORT_ANTICHEAT_COOLDOWN", false,3000);
                        AntiCheat_Allround.SetTimeOutTeleport(player, Anticheat_Teleport_MSTIME);
                        player.Position = LCN_Teleport_Base_Exit;
                        player.Dimension = Constants.FACTION_COSANOSTRA;
                        return true;
                    }
                    else if (LCN_Teleport_Base_Exit.Distance(player.Position) < 1.25f && player.Dimension == Constants.FACTION_COSANOSTRA)
                    {
                        if (player.vnxGetElementData<bool>("TELEPORT_ANTICHEAT_COOLDOWN") == true)
                        {
                            dxLibary.VnX.DrawNotification(player, "warning", "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetData("TELEPORT_ANTICHEAT_COOLDOWN", true);
                        Core.VnX.SetDelayedBoolSharedData(player, "TELEPORT_ANTICHEAT_COOLDOWN", false, 3000);
                        AntiCheat_Allround.SetTimeOutTeleport(player, Anticheat_Teleport_MSTIME);
                        player.Position = LCN_Teleport_Base_Enter;
                        player.Dimension = 0;
                        return true;
                    }

                    // HELI DACH
                    if (LCN_Teleport_Base_heli_Enter.Distance(player.Position) < 1.25f)
                    {
                        if (player.vnxGetElementData<bool>("TELEPORT_ANTICHEAT_COOLDOWN") == true)
                        {
                            dxLibary.VnX.DrawNotification(player, "warning", "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetData("TELEPORT_ANTICHEAT_COOLDOWN", true);
                        Core.VnX.SetDelayedBoolSharedData(player, "TELEPORT_ANTICHEAT_COOLDOWN", false, 3000);
                        AntiCheat_Allround.SetTimeOutTeleport(player, Anticheat_Teleport_MSTIME);
                        player.Position = LCN_Teleport_Base_heli_Exit;
                        player.Dimension = 0;
                        return true;
                    }

                    if (LCN_Teleport_Base_heli_Exit.Distance(player.Position) < 1.25f)
                    {
                        if (player.vnxGetElementData<bool>("TELEPORT_ANTICHEAT_COOLDOWN") == true)
                        {
                            dxLibary.VnX.DrawNotification(player, "warning", "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetData("TELEPORT_ANTICHEAT_COOLDOWN", true);
                        Core.VnX.SetDelayedBoolSharedData(player, "TELEPORT_ANTICHEAT_COOLDOWN", false, 3000);
                        AntiCheat_Allround.SetTimeOutTeleport(player, Anticheat_Teleport_MSTIME);
                        player.Position = LCN_Teleport_Base_heli_Enter;
                        player.Dimension = 0;
                        return true;
                    }
                }

                if (player_Fraktion == Constants.FACTION_YAKUZA || isStateFaction(player) || Admin.HaveAdminRights(player))
                {
                    // Eingang
                    if (YAKUZA_Teleport_Base_Enter.Distance(player.Position) < 1.55f)
                    {
                        if (player.vnxGetElementData<bool>("TELEPORT_ANTICHEAT_COOLDOWN") == true)
                        {
                            dxLibary.VnX.DrawNotification(player, "warning", "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetData("TELEPORT_ANTICHEAT_COOLDOWN", true);
                        Core.VnX.SetDelayedBoolSharedData(player, "TELEPORT_ANTICHEAT_COOLDOWN", false, 3000);
                        AntiCheat_Allround.SetTimeOutTeleport(player, Anticheat_Teleport_MSTIME);
                        player.Position = YAKUZA_Teleport_Base_Exit;
                        player.Dimension = Constants.FACTION_YAKUZA;
                        return true;
                    }
                    else if (YAKUZA_Teleport_Base_Exit.Distance(player.Position) < 1.55f && player.Dimension == Constants.FACTION_YAKUZA)
                    {
                        if (player.vnxGetElementData<bool>("TELEPORT_ANTICHEAT_COOLDOWN") == true)
                        {
                            dxLibary.VnX.DrawNotification(player, "warning", "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetData("TELEPORT_ANTICHEAT_COOLDOWN", true);
                        Core.VnX.SetDelayedBoolSharedData(player, "TELEPORT_ANTICHEAT_COOLDOWN", false, 3000);
                        AntiCheat_Allround.SetTimeOutTeleport(player, Anticheat_Teleport_MSTIME);
                        player.Position = YAKUZA_Teleport_Base_Enter;
                        player.Dimension = 0;
                        return true;
                    }
                }

                if (player_Fraktion == Constants.FACTION_FBI || isStateFaction(player) || Admin.HaveAdminRights(player))
                {
                    // Eingang
                    if (FIB_Teleport_Heli_Enter.Distance(player.Position) < 1.25f)
                    {
                        if (player.vnxGetElementData<bool>("TELEPORT_ANTICHEAT_COOLDOWN") == true)
                        {
                            dxLibary.VnX.DrawNotification(player, "warning", "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetData("TELEPORT_ANTICHEAT_COOLDOWN", true);
                        Core.VnX.SetDelayedBoolSharedData(player, "TELEPORT_ANTICHEAT_COOLDOWN", false, 3000);
                        AntiCheat_Allround.SetTimeOutTeleport(player, Anticheat_Teleport_MSTIME);
                        player.Position = FIB_Teleport_Heli_Exit;
                        return true;
                    }
                    else if (FIB_Teleport_Heli_Exit.Distance(player.Position) < 1.25f)
                    {
                        if (player.vnxGetElementData<bool>("TELEPORT_ANTICHEAT_COOLDOWN") == true)
                        {
                            dxLibary.VnX.DrawNotification(player, "warning", "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetData("TELEPORT_ANTICHEAT_COOLDOWN", true);
                        Core.VnX.SetDelayedBoolSharedData(player, "TELEPORT_ANTICHEAT_COOLDOWN", false, 3000);
                        AntiCheat_Allround.SetTimeOutTeleport(player, Anticheat_Teleport_MSTIME);
                        player.Position = FIB_Teleport_Heli_Enter;
                        return true;
                    }
                    if (FIB_Teleport_Garage_Enter.Distance(player.Position) < 1.25f)
                    {
                        if (player.vnxGetElementData<bool>("TELEPORT_ANTICHEAT_COOLDOWN") == true)
                        {
                            dxLibary.VnX.DrawNotification(player, "warning", "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetData("TELEPORT_ANTICHEAT_COOLDOWN", true);
                        Core.VnX.SetDelayedBoolSharedData(player, "TELEPORT_ANTICHEAT_COOLDOWN", false, 3000);
                        AntiCheat_Allround.SetTimeOutTeleport(player, Anticheat_Teleport_MSTIME);
                        player.Position = FIB_Teleport_Garage_Exit;
                        return true;
                    }
                    else if (FIB_Teleport_Garage_Exit.Distance(player.Position) < 1.25f)
                    {
                        if (player.vnxGetElementData<bool>("TELEPORT_ANTICHEAT_COOLDOWN") == true)
                        {
                            dxLibary.VnX.DrawNotification(player, "warning", "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetData("TELEPORT_ANTICHEAT_COOLDOWN", true);
                        Core.VnX.SetDelayedBoolSharedData(player, "TELEPORT_ANTICHEAT_COOLDOWN", false, 3000);
                        AntiCheat_Allround.SetTimeOutTeleport(player, Anticheat_Teleport_MSTIME);
                        player.Position = FIB_Teleport_Garage_Enter;
                        return true;
                    }
                }

                if (player_Fraktion == Constants.FACTION_EMERGENCY || isStateFaction(player) || Admin.HaveAdminRights(player))
                {
                    // Eingang
                    if (Emergency_Teleport_Heli_Enter.Distance(player.Position) < 1.25f)
                    {
                        if (player.vnxGetElementData<bool>("TELEPORT_ANTICHEAT_COOLDOWN") == true)
                        {
                            dxLibary.VnX.DrawNotification(player, "warning", "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetData("TELEPORT_ANTICHEAT_COOLDOWN", true);
                        Core.VnX.SetDelayedBoolSharedData(player, "TELEPORT_ANTICHEAT_COOLDOWN", false, 3000);
                        AntiCheat_Allround.SetTimeOutTeleport(player, Anticheat_Teleport_MSTIME);
                        player.Position = Emergency_Teleport_Heli_Exit;
                        return true;
                    }
                    else if (Emergency_Teleport_Heli_Exit.Distance(player.Position) < 1.25f)
                    {
                        if (player.vnxGetElementData<bool>("TELEPORT_ANTICHEAT_COOLDOWN") == true)
                        {
                            dxLibary.VnX.DrawNotification(player, "warning", "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetData("TELEPORT_ANTICHEAT_COOLDOWN", true);
                        Core.VnX.SetDelayedBoolSharedData(player, "TELEPORT_ANTICHEAT_COOLDOWN", false, 3000);
                        AntiCheat_Allround.SetTimeOutTeleport(player, Anticheat_Teleport_MSTIME);
                        player.Position = Emergency_Teleport_Heli_Enter;
                        return true;
                    }
                }

                if (player_Fraktion == Constants.FACTION_MS13 || isStateFaction(player) || Admin.HaveAdminRights(player))
                {
                    // Eingang
                    if (MS13_Teleport_Base_Enter.Distance(player.Position) < 1.25f)
                    {
                        if (player.vnxGetElementData<bool>("TELEPORT_ANTICHEAT_COOLDOWN") == true)
                        {
                            dxLibary.VnX.DrawNotification(player, "warning", "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetData("TELEPORT_ANTICHEAT_COOLDOWN", true);
                        Core.VnX.SetDelayedBoolSharedData(player, "TELEPORT_ANTICHEAT_COOLDOWN", false, 3000);
                        AntiCheat_Allround.SetTimeOutTeleport(player, Anticheat_Teleport_MSTIME);
                        player.Position = MS13_Teleport_Base_Exit;
                        player.Dimension = Constants.FACTION_MS13;
                        return true;
                    }
                    else if (MS13_Teleport_Base_Exit.Distance(player.Position) < 1.25f && player.Dimension == Constants.FACTION_MS13)
                    {
                        if (player.vnxGetElementData<bool>("TELEPORT_ANTICHEAT_COOLDOWN") == true)
                        {
                            dxLibary.VnX.DrawNotification(player, "warning", "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetData("TELEPORT_ANTICHEAT_COOLDOWN", true);
                        Core.VnX.SetDelayedBoolSharedData(player, "TELEPORT_ANTICHEAT_COOLDOWN", false, 3000);
                        AntiCheat_Allround.SetTimeOutTeleport(player, Anticheat_Teleport_MSTIME);
                        player.Position = MS13_Teleport_Base_Enter;
                        player.Dimension = 0;
                        return true;
                    }

                    // Eingang
                    else if (MS13_Teleport_Base_heli_Enter.Distance(player.Position) < 1.25f)
                    {
                        if (player.vnxGetElementData<bool>("TELEPORT_ANTICHEAT_COOLDOWN") == true)
                        {
                            dxLibary.VnX.DrawNotification(player, "warning", "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetData("TELEPORT_ANTICHEAT_COOLDOWN", true);
                        Core.VnX.SetDelayedBoolSharedData(player, "TELEPORT_ANTICHEAT_COOLDOWN", false, 3000);
                        AntiCheat_Allround.SetTimeOutTeleport(player, Anticheat_Teleport_MSTIME);
                        player.Position = MS13_Teleport_Base_heli_Exit;
                        return true;
                    }
                    else if (MS13_Teleport_Base_heli_Exit.Distance(player.Position) < 1.25f)
                    {
                        if (player.vnxGetElementData<bool>("TELEPORT_ANTICHEAT_COOLDOWN") == true)
                        {
                            dxLibary.VnX.DrawNotification(player, "warning", "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetData("TELEPORT_ANTICHEAT_COOLDOWN", true);
                        Core.VnX.SetDelayedBoolSharedData(player, "TELEPORT_ANTICHEAT_COOLDOWN", false, 3000);
                        AntiCheat_Allround.SetTimeOutTeleport(player, Anticheat_Teleport_MSTIME);
                        player.Position = MS13_Teleport_Base_heli_Enter;
                        return true;
                    }
                }

                if (player_Fraktion == Constants.FACTION_BALLAS || isStateFaction(player) || Admin.HaveAdminRights(player))
                {
                    // Eingang
                    if (Ballas_Teleport_Base_Enter.Distance(player.Position) < 1.25f)
                    {
                        if (player.vnxGetElementData<bool>("TELEPORT_ANTICHEAT_COOLDOWN") == true)
                        {
                            dxLibary.VnX.DrawNotification(player, "warning", "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetData("TELEPORT_ANTICHEAT_COOLDOWN", true);
                        Core.VnX.SetDelayedBoolSharedData(player, "TELEPORT_ANTICHEAT_COOLDOWN", false, 3000);
                        AntiCheat_Allround.SetTimeOutTeleport(player, Anticheat_Teleport_MSTIME);
                        player.Position = Ballas_Teleport_Base_Exit;
                        player.Dimension = Constants.FACTION_BALLAS;
                        return true;
                    }
                    else if (Ballas_Teleport_Base_Exit.Distance(player.Position) < 1.25f && player.Dimension == Constants.FACTION_BALLAS)
                    {
                        if (player.vnxGetElementData<bool>("TELEPORT_ANTICHEAT_COOLDOWN") == true)
                        {
                            dxLibary.VnX.DrawNotification(player, "warning", "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetData("TELEPORT_ANTICHEAT_COOLDOWN", true);
                        Core.VnX.SetDelayedBoolSharedData(player, "TELEPORT_ANTICHEAT_COOLDOWN", false, 3000);
                        AntiCheat_Allround.SetTimeOutTeleport(player, Anticheat_Teleport_MSTIME);
                        player.Position = Ballas_Teleport_Base_Enter;
                        player.Dimension = 0;
                        return true;
                    }
                }

                if (player_Fraktion == Constants.FACTION_GROVE || isStateFaction(player) || Admin.HaveAdminRights(player))
                {
                    // Eingang
                    if (Compton_Teleport_Base_Enter.Distance(player.Position) < 1.25f)
                    {
                        if (player.vnxGetElementData<bool>("TELEPORT_ANTICHEAT_COOLDOWN") == true)
                        {
                            dxLibary.VnX.DrawNotification(player, "warning", "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetData("TELEPORT_ANTICHEAT_COOLDOWN", true);
                        Core.VnX.SetDelayedBoolSharedData(player, "TELEPORT_ANTICHEAT_COOLDOWN", false, 3000);
                        AntiCheat_Allround.SetTimeOutTeleport(player, Anticheat_Teleport_MSTIME);
                        player.Position = Compton_Teleport_Base_Exit;
                        player.Dimension = Constants.FACTION_GROVE;
                        return true;
                    }
                    else if (Compton_Teleport_Base_Exit.Distance(player.Position) < 1.25f && player.Dimension == Constants.FACTION_GROVE)
                    {
                        if (player.vnxGetElementData<bool>("TELEPORT_ANTICHEAT_COOLDOWN") == true)
                        {
                            dxLibary.VnX.DrawNotification(player, "warning", "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetData("TELEPORT_ANTICHEAT_COOLDOWN", true);
                        Core.VnX.SetDelayedBoolSharedData(player, "TELEPORT_ANTICHEAT_COOLDOWN", false, 3000);
                        AntiCheat_Allround.SetTimeOutTeleport(player, Anticheat_Teleport_MSTIME);
                        player.Position = Compton_Teleport_Base_Enter;
                        player.Dimension = 0;
                        return true;
                    }
                }

                if (player_Fraktion == Constants.FACTION_SAMCRO || isStateFaction(player) || Admin.HaveAdminRights(player))
                {
                    // Eingang
                    if (SAM_Teleport_Base_Enter.Distance(player.Position) < 1.25f)
                    {
                        if (player.vnxGetElementData<bool>("TELEPORT_ANTICHEAT_COOLDOWN") == true)
                        {
                            dxLibary.VnX.DrawNotification(player, "warning", "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetData("TELEPORT_ANTICHEAT_COOLDOWN", true);
                        Core.VnX.SetDelayedBoolSharedData(player, "TELEPORT_ANTICHEAT_COOLDOWN", false, 3000);
                        AntiCheat_Allround.SetTimeOutTeleport(player, Anticheat_Teleport_MSTIME);
                        player.Position = SAM_Teleport_Base_Exit;
                        player.Dimension = Constants.FACTION_SAMCRO;
                        return true;
                    }
                    else if (SAM_Teleport_Base_Exit.Distance(player.Position) < 1.25f && player.Dimension == Constants.FACTION_SAMCRO)
                    {
                        if (player.vnxGetElementData<bool>("TELEPORT_ANTICHEAT_COOLDOWN") == true)
                        {
                            dxLibary.VnX.DrawNotification(player, "warning", "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetData("TELEPORT_ANTICHEAT_COOLDOWN", true);
                        Core.VnX.SetDelayedBoolSharedData(player, "TELEPORT_ANTICHEAT_COOLDOWN", false, 3000);
                        AntiCheat_Allround.SetTimeOutTeleport(player, Anticheat_Teleport_MSTIME);
                        player.Position = SAM_Teleport_Base_Enter;
                        player.Dimension = 0;
                        return true;
                    }
                }
            }
            catch { }
            return false;
        }


        [Command("zivizeit")]
        public static void Zivizeit(IPlayer player)
        {
            try
            {
                if (player.vnxGetElementData<DateTime>(EntityData.PLAYER_ZIVIZEIT) < DateTime.Now)
                {
                    player.SendChatMessage(RageAPI.GetHexColorcode(0,200,0) + "Zivizeit Abgelaufen. [" + player.vnxGetElementData<DateTime>(EntityData.PLAYER_ZIVIZEIT) + "]");
                }
                else
                {
                    player.SendChatMessage(RageAPI.GetHexColorcode(175,0,0) +"Zivizeit läuft noch. [" + player.vnxGetElementData<DateTime>(EntityData.PLAYER_ZIVIZEIT) + "]");
                }
            }
            catch { }
        }

        [Command("selfuninvite")]
        public static void Selfuninvite(IPlayer player)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) != Constants.FACTION_NONE)
                {
                    Faction.CreateFactionInformation(player.vnxGetElementData<int>(EntityData.PLAYER_FACTION),player.GetVnXName<string>() + " hat die Fraktion verlassen...");
                    player.SetData(EntityData.PLAYER_FACTION, Constants.FACTION_NONE);
                    anzeigen.Usefull.VnX.OnFactionChange(player);
                    player.SetData(EntityData.PLAYER_SPAWNPOINT, "noobspawn");
                    player.SetData(EntityData.PLAYER_ZIVIZEIT, DateTime.Now.AddDays(1));
                    dxLibary.VnX.DrawNotification(player, "info", "Du hast dich selbst uninvitet!");
                }
            }
            catch { }

        }

        [Command("invite")]
        private void InvitePlayerToFaction(IPlayer player, IPlayer target)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) != Constants.FACTION_NONE && player.vnxGetElementData<int>(EntityData.PLAYER_RANK) >= 4)
                {
                    if (target.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_NONE)
                    {
                        if (target.vnxGetElementData<DateTime>(EntityData.PLAYER_ZIVIZEIT) < DateTime.Now)
                        {
                            target.SetData(EntityData.PLAYER_FACTION, player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                            target.SetData(EntityData.PLAYER_RANK, 0);
                            anzeigen.Usefull.VnX.OnFactionChange(target);
                           target.SendChatMessage(RageAPI.GetHexColorcode(0,150,0) + "Du wurdest soeben in eine Fraktion aufgenommen! Tippe /t [Text] für den Chat und F2, um mehr zu erfahren!");
                            player.SendChatMessage(RageAPI.GetHexColorcode(0,150,0) + "Du hast den Spieler " + target.Name + " in deine Fraktion aufgenommen!");
                        }
                        else
                        {
                            player.SendChatMessage(RageAPI.GetHexColorcode(175,0,0) + "Der Spieler " + target.Name + " hat noch eine Zivizeit am laufen. [" + target.vnxGetElementData<DateTime>(EntityData.PLAYER_ZIVIZEIT) + "]");
                        }
                    }
                    else
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Der Spieler ist bereits in einer Fraktion!");
                    }
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Erst ab Rank 4 möglich!");
                }
            }
            catch { }
        }

        [Command("uninvite")]
        private void UninviteFromFactionPlayer(IPlayer player, IPlayer target)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) != Constants.FACTION_NONE && player.vnxGetElementData<int>(EntityData.PLAYER_RANK) >= 4)
                {
                    if (target.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == player.vnxGetElementData<int>(EntityData.PLAYER_FACTION))
                    {
                        if (target.Name ==player.GetVnXName<string>())
                        {
                            dxLibary.VnX.DrawNotification(player, "error", "Du kannst dich nicht selbst Rauswerfen... Nutze /selfuninvite");
                            return;
                        }
                        if (target.vnxGetElementData<int>(EntityData.PLAYER_RANK) < 5)
                        {
                            target.SetData(EntityData.PLAYER_FACTION, 0);
                            target.SetData(EntityData.PLAYER_RANK, 0);
                            target.SetData(EntityData.PLAYER_SPAWNPOINT, "noobspawn");
                            anzeigen.Usefull.VnX.OnFactionChange(target);
                            player.SetData(EntityData.PLAYER_ZIVIZEIT, DateTime.Now.AddDays(1));
                            target.SendChatMessage(RageAPI.GetHexColorcode(175,0,0) + "Du wurdest soeben aus deiner Fraktion geworfen!");
                            player.SendChatMessage(RageAPI.GetHexColorcode(0,175,0) +"Du hast den Spieler " + target.Name + " aus deiner Fraktion entfernt!");
                        }
                        else
                        {
                            dxLibary.VnX.DrawNotification(player, "error", "Du kannst keinen Leader un-inviten!");
                        }
                    }
                    else
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Der Spieler ist nicht in deiner Fraktion!");
                    }
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Erst ab Rank 4 möglich!");
                }
            }
            catch { }
        }


        [Command("giverank")]
        public static void SetPlayerFraktionsRang(IPlayer player, IPlayer target, int number)
        {
            try
            {
                if(number > 4 || number < 0)
                {
                    return;
                }
                if (player.vnxGetElementData<int>(EntityData.PLAYER_RANK) >= 4 && player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) > Constants.FACTION_NONE)
                {
                    if (target.vnxGetElementData<int>(EntityData.PLAYER_FACTION) != player.vnxGetElementData<int>(EntityData.PLAYER_FACTION))
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Der Spieler ist nicht in deiner Fraktion!");
                        return;
                    }
                    if (target.vnxGetElementData<int>(EntityData.PLAYER_RANK) == 5)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du kannst einen Leader/Co-Leader nicht seinen Rang ändern!");
                        return;
                    }
                    if (target.vnxGetElementData<int>(EntityData.PLAYER_RANK) == number)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Der Spieler hat bereits diesen Rang...");
                        return;
                    }
                    string rankString = string.Empty;
                    foreach (FactionModel factionModel in Constants.FACTION_RANK_LIST)
                    {
                        if (factionModel.faction == player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) && factionModel.rank == number)
                        {
                            rankString = player.vnxGetElementData<int>(EntityData.PLAYER_SEX) == Constants.SEX_MALE ? factionModel.deIScriptionMale : factionModel.deIScriptionFemale;
                            break;
                        }
                    }
                    if (target.vnxGetElementData<int>(EntityData.PLAYER_RANK) < number)
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(0,175,0) +"Glückwunsch, du wurdest soeben von " +player.GetVnXName<string>() + " zum " + rankString + " befördert!");

                    }
                    else
                    {
                        target.SendChatMessage(RageAPI.GetHexColorcode(175,0,0) + "Du wurdest soeben von " +player.GetVnXName<string>() + " zum " + rankString + " degradiert!");
                    }
                    player.SendChatMessage(RageAPI.GetHexColorcode(0,175,0) +"Du hast " + target.Name + " soeben Rang " + rankString + " ( " + number + " ) gegeben!");
                    target.SetData(EntityData.PLAYER_RANK, number);

                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du bist nicht befugt!");
                }
            }
            catch 
            {
            }
        }

        //[AltV.Net.ClientEvent("goDUTYBADServer")]
        public void GoDUTYBADServer(IPlayer player, string state)
        {
            try
            {
                int playerSex = player.vnxGetElementData<int>(EntityData.PLAYER_SEX);
                int playerFaction = player.vnxGetElementData<int>(EntityData.PLAYER_FACTION);

                if (player.vnxGetElementData<int>(EntityData.PLAYER_KILLED) != 0)
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Diese Aktion ist derzeit nicht Möglich!");
                }

                if (state == "anziehen")
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) > Constants.FACTION_NONE)
                    {
                        foreach (UniformModel uniform in Constants.UNIFORM_LIST)
                        {
                            if (uniform.type == 0 && uniform.factionJob == playerFaction && playerSex == uniform.characterSex)
                            {
                                //ToDo Sie Clientseitig Laden! : player.SetClothes(uniform.uniformSlot, uniform.uniformDrawable, uniform.uniformTexture);
                            }
                            else if (uniform.type == 1 && playerSex == uniform.characterSex)
                            {
                                //ToDo Sie Clientseitig Laden! : player.SetClothes(uniform.uniformSlot, uniform.uniformDrawable, uniform.uniformTexture);
                            }
                        }
                        AntiCheat_Allround.SetTimeOutHealth(player, 5000);
                        player.Health = 100;
                        player.Armor = 100;
                        player.SetData(EntityData.PLAYER_ARMOR, 100);
                        if (isBadFaction(player))
                        {
                            player.SetData(EntityData.PLAYER_ON_DUTY_BAD, 1);
                        }
                        else if(isNeutralFaction(player))
                        {
                            player.SetData(EntityData.PLAYER_ON_DUTY_NEUTRAL, 1);
                        }
                    }
                }
                else
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_KILLED) != 0) 
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Diese Aktion ist derzeit nicht Möglich!");
                    }

                    Customization.ApplyPlayerClothes(player);
                    player.SetData(EntityData.PLAYER_ON_DUTY_BAD, 0);


                    // Load selected character
                    PlayerModel character = Database.LoadCharacterInformationById(player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID));
                    SkinModel skinModel = Database.GetCharacterSkin(player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID));

                    //ToDo : Fix & find another Way! player.GetVnXName<string>() = character.realName;
                    player.SetData(EntityData.PLAYER_SKIN_MODEL, skinModel);
                                                player.Model = character.sex == 0 ? Alt.Hash("FreemodeMale01") : Alt.Hash("FreemodeFemale01");
                    Customization.ApplyPlayerCustomization(player, skinModel, character.sex);
                    Customization.ApplyPlayerClothes(player);
                    Customization.ApplyPlayerTattoos(player);
                    AntiCheat_Allround.SetTimeOutHealth(player, 5000);
                    player.Health = 100;
                    player.Armor = 100;
                    weapons.Weapons.GivePlayerWeaponItems(player);


                    if (isBadFaction(player))
                    {
                        player.SetData(EntityData.PLAYER_ON_DUTY_BAD, 0);
                    }
                    else if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_NEWS)
                    {
                        player.SetData(EntityData.PLAYER_ON_DUTY_NEUTRAL, 0);
                    }
                }
            }
            catch
            {
            }
        }

        //[AltV.Net.ClientEvent("goDUTYServer")]
        public void GoDutyIPlayer(IPlayer player)
        {
            try
            {
                int playerSex = player.vnxGetElementData<int>(EntityData.PLAYER_SEX);
                int playerFaction = player.vnxGetElementData<int>(EntityData.PLAYER_FACTION);

                if (player.vnxGetElementData<int>(EntityData.PLAYER_KILLED) != 0)
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Diese Aktion ist derzeit nicht Möglich!");
                }
                else if (isStateFaction(player))
                {
                    foreach (UniformModel uniform in Constants.UNIFORM_LIST)
                    {
                        if (uniform.type == 0 && uniform.factionJob == playerFaction && playerSex == uniform.characterSex)
                        {
                            //ToDo Sie Clientseitig Laden! : player.SetClothes(uniform.uniformSlot, uniform.uniformDrawable, uniform.uniformTexture);
                        }
                        else if (uniform.type == 1 && playerSex == uniform.characterSex)
                        {
                            //ToDo Sie Clientseitig Laden! : player.SetClothes(uniform.uniformSlot, uniform.uniformDrawable, uniform.uniformTexture);
                        }
                    }
                    player.SetData(EntityData.PLAYER_ON_DUTY, 1);
                    AntiCheat_Allround.SetTimeOutHealth(player, 5000);
                    player.Health = 100;
                    player.Armor = 100;
                    weapons.Weapons.GivePlayerWeaponItems(player);
                }
            }
            catch
            {
            }
        }

        //[AltV.Net.ClientEvent("goSWATServer")]
        public void goSWATDutyPlayer(IPlayer player)
        {
            try
            {
                AntiCheat_Allround.SetTimeOutHealth(player, 5000);
                player.Model = Alt.Hash("Swat01SMY");
                player.SetData(EntityData.PLAYER_ON_DUTY, 1);
                weapons.Weapons.GivePlayerWeaponItems(player);
            }
            catch
            {
            }
        }

        //[AltV.Net.ClientEvent("goOFFDUTYServer")]
        public void OffDuty_Server_ÈVENT(IPlayer player)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_KILLED) != 0)
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Diese Aktion ist derzeit nicht Möglich!");
                }
                else if (player.vnxGetElementData<int>(EntityData.PLAYER_ON_DUTY) == 1)
                {
                    AntiCheat_Allround.SetTimeOutHealth(player, 5000);
                    // Populate player's clothes
                    Customization.ApplyPlayerClothes(player);

                    // We set the player off duty
                    player.SetData(EntityData.PLAYER_ON_DUTY, 0);

                    // Load selected character
                    PlayerModel character = Database.LoadCharacterInformationById(player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID));
                    SkinModel skinModel = Database.GetCharacterSkin(player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID));

                    player.SetData(EntityData.PLAYER_SKIN_MODEL, skinModel);
                    player.Model = character.sex == 0 ? Alt.Hash("FreemodeMale01") : Alt.Hash("FreemodeFemale01");
                    Customization.ApplyPlayerCustomization(player, skinModel, character.sex);
                    Customization.ApplyPlayerClothes(player);
                    Customization.ApplyPlayerTattoos(player);
                    anzeigen.Usefull.VnX.RemoveAllWeapons(player);
                }
            }
            catch
            {
            }
        }

    }
}
