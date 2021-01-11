using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using VenoXV._Admin_;
using VenoXV._Gamemodes_.Reallife.character;
using VenoXV._Gamemodes_.Reallife.factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Factions
{
    public class Allround : IScript
    {
        public static Position LCN_Teleport_Base_Enter = new Position(-842.2286f, -25.041758f, 40.38391f);
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

        //public static Position SAM_Teleport_Base_Enter = new Position(982.1898f, -103.258f, 74.84872f); // 982,1898, -103,258, 74,84872
        //public static Position SAM_Teleport_Base_Exit = new Position(981.1188f, -102.3915f, 74.84511f); // 981.1188, -102.3915, 74.84511

        public static Position MS13_Teleport_Base_heli_Enter = new Position(-1554.938f, -115.0005f, 54.51854f);
        public static Position MS13_Teleport_Base_heli_Exit = new Position(-1553.669f, -106.2555f, 67.1683f);

        public static Position LCN_Teleport_Base_heli_Enter = new Position(-855.75824f, -33.66593f, 44.141357f);
        public static Position LCN_Teleport_Base_heli_Exit = new Position(-849.33624f, -27.995604f, 50.931885f);




        public static Position LSPD_FGUNS_COL = new Position(451.5455f, -993.3593f, 30.6896f);
        public static ColShapeModel LSPDCOL_FGUNS = RageAPI.CreateColShapeSphere(LSPD_FGUNS_COL, 2f);

        public static Position FBI_FGUNS_COL = new Position(136.1328f, -761.8464f, 45.75203f);
        public static ColShapeModel FBICOL_FGUNS = RageAPI.CreateColShapeSphere(FBI_FGUNS_COL, 1.5f);


        public static Position BAD_INTERIOR_FGUNS_COL = new Position(256.6112f, -996.761f, -99.00867f);
        public static Position BAD_INTERIOR2_FGUNS_COL = new Position(350.1265f, -993.4926f, -99.19615f);
        public static Position BAD_INTERIOR3_FGUNS_COL = new Position(973.5081f, -101.8594f, 74.84988f);
        public static Position BAD_INTERIOR4_FGUNS_COL = new Position(-1286.099f, 438.3797f, 94.09482f);
        public static ColShapeModel BAD_INTERIOR_FGUNS = RageAPI.CreateColShapeSphere(BAD_INTERIOR_FGUNS_COL, 1.5f);
        public static ColShapeModel BAD_INTERIOR2_FGUNS = RageAPI.CreateColShapeSphere(BAD_INTERIOR2_FGUNS_COL, 1.5f);
        public static ColShapeModel BAD_INTERIOR3_FGUNS = RageAPI.CreateColShapeSphere(BAD_INTERIOR3_FGUNS_COL, 1.5f);
        public static ColShapeModel BAD_INTERIOR4_FGUNS = RageAPI.CreateColShapeSphere(BAD_INTERIOR4_FGUNS_COL, 1.5f);


        public static void OnResourceStart()
        {
            //Wantedgründe Laden : 
            Police.AddToWantedDictionary();
            //
            BAD_INTERIOR3_FGUNS.Dimension = Constants.FACTION_SAMCRO;
            BAD_INTERIOR4_FGUNS.Dimension = Constants.FACTION_NARCOS;
            //ToDo: ClientSide erstellen NAPI.
            //.CreateTextLabel("LCN Eingang", LCN_Teleport_Base_Enter, 10.0f, 0.5f, 4, new Rgba(40, 40, 40, 255));
            RageAPI.CreateTextLabel("LCN Eingang", LCN_Teleport_Base_Enter, 10.0f, 0.5f, 4, new int[] { 40, 40, 40, 255 });
            RageAPI.CreateTextLabel("LCN Ausgang", LCN_Teleport_Base_Exit, 10.0f, 0.5f, 4, new int[] { 40, 40, 40, 255 }, Constants.FACTION_LCN);

            RageAPI.CreateTextLabel("Yakuza Eingang", YAKUZA_Teleport_Base_Enter, 10.0f, 0.5f, 4, new int[] { 175, 0, 0, 255 });
            RageAPI.CreateTextLabel("Yakuza Ausgang", YAKUZA_Teleport_Base_Exit, 10.0f, 0.5f, 4, new int[] { 175, 0, 0, 255 }, Constants.FACTION_YAKUZA);

            RageAPI.CreateTextLabel("Mitarbeiter Ausgang", FIB_Teleport_Heli_Exit, 10.0f, 0.5f, 4, new int[] { 0, 86, 184, 255 });
            RageAPI.CreateTextLabel("Mitarbeiter Eingang", FIB_Teleport_Heli_Enter, 10.0f, 0.5f, 4, new int[] { 0, 86, 184, 255 });
            RageAPI.CreateTextLabel("Tiefgaragen Ausgang", FIB_Teleport_Garage_Exit, 10.0f, 0.5f, 4, new int[] { 0, 86, 184, 255 });
            RageAPI.CreateTextLabel("Tiefgaragen Eingang", FIB_Teleport_Garage_Enter, 10.0f, 0.5f, 4, new int[] { 0, 86, 184, 255 });

            RageAPI.CreateTextLabel("Mitarbeiter Eingang", Emergency_Teleport_Heli_Enter, 10.0f, 0.5f, 4, new int[] { 255, 51, 51, 255 });
            RageAPI.CreateTextLabel("Mitarbeiter Ausgang", Emergency_Teleport_Heli_Exit, 10.0f, 0.5f, 4, new int[] { 255, 51, 51, 255 });

            RageAPI.CreateTextLabel("Narcos Eingang", MS13_Teleport_Base_Enter, 10.0f, 0.5f, 4, new int[] { 128, 129, 150, 255 });
            RageAPI.CreateTextLabel("Narcos Ausgang", MS13_Teleport_Base_Exit, 10.0f, 0.5f, 4, new int[] { 128, 129, 150, 255 }, Constants.FACTION_NARCOS);

            //RageAPI.CreateTextLabel("SAMCRO Eingang", SAM_Teleport_Base_Enter, 10.0f, 0.5f, 4, new int[] { 128, 129, 150, 255 });
            //RageAPI.CreateTextLabel("SAMCRO Ausgang", SAM_Teleport_Base_Exit, 10.0f, 0.5f, 4, new int[] { 128, 129, 150, 255 }, Constants.FACTION_SAMCRO);

            RageAPI.CreateTextLabel("Narcos Dach Eingang", MS13_Teleport_Base_heli_Enter, 10.0f, 0.5f, 4, new int[] { 128, 129, 150, 255 }, Constants.FACTION_NONE);
            RageAPI.CreateTextLabel("Narcos Dach Ausgang", MS13_Teleport_Base_heli_Exit, 10.0f, 0.5f, 4, new int[] { 128, 129, 150, 255 }, Constants.FACTION_NONE);

            RageAPI.CreateTextLabel("Mafia Dach Eingang", LCN_Teleport_Base_heli_Enter, 10.0f, 0.5f, 4, new int[] { 40, 40, 40, 255 }, Constants.FACTION_NONE);
            RageAPI.CreateTextLabel("Mafia Dach Ausgang", LCN_Teleport_Base_heli_Exit, 10.0f, 0.5f, 4, new int[] { 40, 40, 40, 255 }, Constants.FACTION_NONE);

            RageAPI.CreateTextLabel("Rollin Height´s Eingang", Ballas_Teleport_Base_Enter, 10.0f, 0.5f, 4, new int[] { 138, 43, 226, 255 });
            RageAPI.CreateTextLabel("Rollin Height´s Ausgang", Ballas_Teleport_Base_Exit, 10.0f, 0.5f, 4, new int[] { 138, 43, 226, 255 }, Constants.FACTION_BALLAS);
            //RageAPI.CreateTextLabel("Danke für Alles" + "\n_______________\n" + "For Palma", new Position(276.7415f, -2066.709f, 17.17801f), 10.0f, 0.5f, 4, new int[] { 138, 43, 226, 255 }, 0);


            RageAPI.CreateTextLabel("Compton Family´s Eingang", Compton_Teleport_Base_Enter, 10.0f, 0.5f, 4, new int[] { 0, 152, 0, 255 });
            RageAPI.CreateTextLabel("Compton Family´s Ausgang", Compton_Teleport_Base_Exit, 10.0f, 0.5f, 4, new int[] { 0, 152, 0, 255 }, Constants.FACTION_COMPTON);


            //ToDo: Requesting Offices NAPI.World.RequestIpl ("ex_sm_15_office_01b");


            /* ColShapeModels */

            RageAPI.CreateTextLabel("L.S.P.D Equip", LSPD_FGUNS_COL, 10.0f, 0.5f, 4, new int[] { 0, 105, 145, 255 });

            RageAPI.CreateTextLabel("F.I.B Equip", FBI_FGUNS_COL, 10.0f, 0.5f, 4, new int[] { 0, 86, 184, 255 });


            RageAPI.CreateTextLabel("BAD Equip", BAD_INTERIOR_FGUNS_COL, 10.0f, 0.5f, 4, new int[] { 200, 0, 0, 255 });
            RageAPI.CreateTextLabel("BAD Equip", BAD_INTERIOR2_FGUNS_COL, 10.0f, 0.5f, 4, new int[] { 200, 0, 0, 255 });
            RageAPI.CreateTextLabel("BAD Equip", BAD_INTERIOR3_FGUNS_COL, 10.0f, 0.5f, 4, new int[] { 200, 0, 0, 255 });
            RageAPI.CreateTextLabel("BAD Equip", BAD_INTERIOR4_FGUNS_COL, 10.0f, 0.5f, 4, new int[] { 200, 0, 0, 255 });

            BAD_INTERIOR_FGUNS.vnxSetElementData("isWeaponSelectShape", true);
            BAD_INTERIOR2_FGUNS.vnxSetElementData("isWeaponSelectShape", true);
            BAD_INTERIOR3_FGUNS.vnxSetElementData("isWeaponSelectShape", true);
            BAD_INTERIOR4_FGUNS.vnxSetElementData("isWeaponSelectShape", true);

        }


        private static Dictionary<string, AltV.Net.Enums.WeaponModel> FgunsWeapons = new Dictionary<string, AltV.Net.Enums.WeaponModel>
        {
            {   "Schlagstock",  AltV.Net.Enums.WeaponModel.Nightstick },
            {   "Tazer",        AltV.Net.Enums.WeaponModel.StunGun },
            {   "Pistole",      AltV.Net.Enums.WeaponModel.Pistol },
            {   "Pistole50",    AltV.Net.Enums.WeaponModel.Pistol50 },
            {   "Shotgun",      AltV.Net.Enums.WeaponModel.PumpShotgun },
            {   "PDW",          AltV.Net.Enums.WeaponModel.CombatPDW },
            {   "Karabiner",    AltV.Net.Enums.WeaponModel.CarbineRifle },
            {   "Kampfgewehr",  AltV.Net.Enums.WeaponModel.AdvancedRifle },
            {   "Sniper",       AltV.Net.Enums.WeaponModel.SniperRifle },
        };

        public static void UpdateFgunsWindow(VnXPlayer player)
        {
            if (isStateFaction(player))
            {
                WaffenlagerModel fweapon = Fraktionswaffenlager.GetWaffenlagerById(Constants.FACTION_LSPD);

                VenoX.TriggerClientEvent(player, "fguns:ForceStateWindowUpdate",
                    "Schlagstock", " [ " + fweapon.weapon_nightstick.Amount + " ] ",
                    "Tazer", " [ " + fweapon.weapon_tazer.Amount + " ] ",
                    "Pistole", " [ " + fweapon.weapon_pistol.Amount + " ] ",
                    "Pistole50", " [ " + fweapon.weapon_pistol50.Amount + " ] ",
                    "Shotgun", " [ " + fweapon.weapon_pumpshotgun.Amount + " ] ",
                    "PDW", " [ " + fweapon.weapon_combatpdw.Amount + " ] ",
                    "Karabiner", " [ " + fweapon.weapon_carbinerifle.Amount + " ] ",
                    "Kampfgewehr", " [ " + fweapon.weapon_advancedrifle.Amount + " ] ",
                    "Sniper", " [ " + fweapon.weapon_sniperrifle.Amount + " ] "
                    );
            }
            else
            {
                //WaffenlagerModel fweapon = Fraktionswaffenlager.GetWaffenlagerById(player.Reallife.Faction);

            }
        }


        [ClientEvent("fguns:selectweapon")]
        public static void FgunsSelectWeapon(VnXPlayer player, string weapon)
        {
            try
            {
                if (player.Reallife.Faction == Constants.FACTION_NONE) return;
                if (!FgunsWeapons.TryGetValue(weapon, out AltV.Net.Enums.WeaponModel WeaponHash))
                {
                    Debug.OutputDebugString("fguns:selectweapon not found weapon ID : " + weapon);
                    return;
                }
                WaffenlagerModel fweapon = Fraktionswaffenlager.GetWaffenlagerById(player.Reallife.Faction);

            }
            catch (Exception) { }
        }

        public static void OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (shape == LSPDCOL_FGUNS || shape == FBICOL_FGUNS)
                {
                    if (isStateFaction(player))
                    {
                        WaffenlagerModel fweapon = Fraktionswaffenlager.GetWaffenlagerById(Constants.FACTION_LSPD);
                        VenoX.TriggerClientEvent(player, "fguns:Open", true);
                        UpdateFgunsWindow(player);
                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static bool isBadFaction(VnXPlayer player)
        {
            try
            {
                int player_Fraktion = player.Reallife.Faction;
                if
                (player_Fraktion == Constants.FACTION_LCN || player_Fraktion == Constants.FACTION_YAKUZA ||
                player_Fraktion == Constants.FACTION_NARCOS || player_Fraktion == Constants.FACTION_SAMCRO ||
                player_Fraktion == Constants.FACTION_BALLAS || player_Fraktion == Constants.FACTION_COMPTON)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return false; }
        }
        public static bool isStateFaction(VnXPlayer player)
        {
            try
            {
                int player_Fraktion = player.Reallife.Faction;
                if (player_Fraktion == Constants.FACTION_LSPD || player_Fraktion == Constants.FACTION_FBI || player_Fraktion == Constants.FACTION_USARMY)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return false; }
        }
        public static bool isStateIVehicle(VehicleModel Vehicle)
        {
            try
            {
                int VEHICLE_Fraktion = Vehicle.Faction;
                if (VEHICLE_Fraktion == Constants.FACTION_LSPD || VEHICLE_Fraktion == Constants.FACTION_FBI || VEHICLE_Fraktion == Constants.FACTION_USARMY)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return false; }
        }

        public static bool isBadIVehicle(VehicleModel Vehicle)
        {
            try
            {
                int VEHICLE_Fraktion = Vehicle.Faction;
                if (VEHICLE_Fraktion == Constants.FACTION_LCN || VEHICLE_Fraktion == Constants.FACTION_YAKUZA || VEHICLE_Fraktion == Constants.FACTION_NARCOS || VEHICLE_Fraktion == Constants.FACTION_SAMCRO || VEHICLE_Fraktion == Constants.FACTION_BALLAS || VEHICLE_Fraktion == Constants.FACTION_COMPTON)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return false; }
        }
        public static bool isNeutralIVehicle(VehicleModel Vehicle)
        {
            try
            {
                int VEHICLE_Fraktion = Vehicle.Faction;
                if (VEHICLE_Fraktion == Constants.FACTION_NEWS || VEHICLE_Fraktion == Constants.FACTION_EMERGENCY || VEHICLE_Fraktion == Constants.FACTION_MECHANIK)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return false; }
        }


        public static bool isNeutralFaction(VnXPlayer player)
        {
            try
            {
                int player_Fraktion = player.Reallife.Faction;
                if (player_Fraktion == Constants.FACTION_EMERGENCY || player_Fraktion == Constants.FACTION_NEWS || player_Fraktion == Constants.FACTION_MECHANIK)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return false; }
        }


        public static bool IsNearFactionTeleporter(VnXPlayer player)
        {
            try
            {
                int player_Fraktion = player.Reallife.Faction;

                if (player_Fraktion == Constants.FACTION_NONE)
                {
                    return false;
                }
                int CoolDown = 3;
                if (player_Fraktion == Constants.FACTION_LCN || isStateFaction(player) || Admin.HaveAdminRights(player))
                {
                    // Eingang
                    if (LCN_Teleport_Base_Enter.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(CoolDown);
                        player.SetPosition = LCN_Teleport_Base_Exit;
                        player.Dimension = Constants.FACTION_LCN;
                        return true;
                    }
                    else if (LCN_Teleport_Base_Exit.Distance(player.Position) < 1.25f && player.Dimension == Constants.FACTION_LCN)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(CoolDown);
                        player.SetPosition = LCN_Teleport_Base_Enter;
                        player.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                        return true;
                    }

                    // HELI DACH
                    if (LCN_Teleport_Base_heli_Enter.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(CoolDown);
                        player.SetPosition = LCN_Teleport_Base_heli_Exit;
                        player.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                        return true;
                    }

                    if (LCN_Teleport_Base_heli_Exit.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(CoolDown);
                        player.SetPosition = LCN_Teleport_Base_heli_Enter;
                        player.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                        return true;
                    }
                }

                if (player_Fraktion == Constants.FACTION_YAKUZA || isStateFaction(player) || Admin.HaveAdminRights(player))
                {
                    // Eingang
                    if (YAKUZA_Teleport_Base_Enter.Distance(player.Position) < 1.55f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(CoolDown);
                        player.SetPosition = YAKUZA_Teleport_Base_Exit;
                        player.Dimension = Constants.FACTION_YAKUZA;
                        return true;
                    }
                    else if (YAKUZA_Teleport_Base_Exit.Distance(player.Position) < 1.55f && player.Dimension == Constants.FACTION_YAKUZA)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(CoolDown);
                        player.SetPosition = YAKUZA_Teleport_Base_Enter;
                        player.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                        return true;
                    }
                }

                if (player_Fraktion == Constants.FACTION_FBI || isStateFaction(player) || Admin.HaveAdminRights(player))
                {
                    // Eingang
                    if (FIB_Teleport_Heli_Enter.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(CoolDown);
                        player.SetPosition = FIB_Teleport_Heli_Exit;
                        return true;
                    }
                    else if (FIB_Teleport_Heli_Exit.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(CoolDown);
                        player.SetPosition = FIB_Teleport_Heli_Enter;
                        return true;
                    }
                    if (FIB_Teleport_Garage_Enter.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(CoolDown);
                        player.SetPosition = FIB_Teleport_Garage_Exit;
                        return true;
                    }
                    else if (FIB_Teleport_Garage_Exit.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(CoolDown);
                        player.SetPosition = FIB_Teleport_Garage_Enter;
                        return true;
                    }
                }

                if (player_Fraktion == Constants.FACTION_EMERGENCY || isStateFaction(player) || Admin.HaveAdminRights(player))
                {
                    // Eingang
                    if (Emergency_Teleport_Heli_Enter.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(CoolDown);
                        player.SetPosition = Emergency_Teleport_Heli_Exit;
                        return true;
                    }
                    else if (Emergency_Teleport_Heli_Exit.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(CoolDown);
                        player.SetPosition = Emergency_Teleport_Heli_Enter;
                        return true;
                    }
                }

                if (player_Fraktion == Constants.FACTION_NARCOS || isStateFaction(player) || Admin.HaveAdminRights(player))
                {
                    // Eingang
                    if (MS13_Teleport_Base_Enter.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(CoolDown);
                        player.SetPosition = MS13_Teleport_Base_Exit;
                        player.Dimension = Constants.FACTION_NARCOS;
                        return true;
                    }
                    else if (MS13_Teleport_Base_Exit.Distance(player.Position) < 1.25f && player.Dimension == Constants.FACTION_NARCOS)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(CoolDown);
                        player.SetPosition = MS13_Teleport_Base_Enter;
                        player.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                        return true;
                    }

                    // Eingang
                    else if (MS13_Teleport_Base_heli_Enter.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(CoolDown);
                        player.SetPosition = MS13_Teleport_Base_heli_Exit;
                        return true;
                    }
                    else if (MS13_Teleport_Base_heli_Exit.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(CoolDown);
                        player.SetPosition = MS13_Teleport_Base_heli_Enter;
                        return true;
                    }
                }

                if (player_Fraktion == Constants.FACTION_BALLAS || isStateFaction(player) || Admin.HaveAdminRights(player))
                {
                    // Eingang
                    if (Ballas_Teleport_Base_Enter.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }

                        player.SetPosition = Ballas_Teleport_Base_Exit;
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(CoolDown);
                        player.Dimension = Constants.FACTION_BALLAS;
                        return true;
                    }
                    else if (Ballas_Teleport_Base_Exit.Distance(player.Position) < 1.25f && player.Dimension == Constants.FACTION_BALLAS)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetPosition = Ballas_Teleport_Base_Enter;
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(CoolDown);
                        player.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                        return true;
                    }
                }

                if (player_Fraktion == Constants.FACTION_COMPTON || isStateFaction(player) || Admin.HaveAdminRights(player))
                {
                    // Eingang
                    if (Compton_Teleport_Base_Enter.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetPosition = Compton_Teleport_Base_Exit;
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(CoolDown);
                        player.Dimension = Constants.FACTION_COMPTON;
                        return true;
                    }
                    else if (Compton_Teleport_Base_Exit.Distance(player.Position) < 1.25f && player.Dimension == Constants.FACTION_COMPTON)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetPosition = Compton_Teleport_Base_Enter;
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(CoolDown);
                        player.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                        return true;
                    }
                }

                if (player_Fraktion == Constants.FACTION_SAMCRO || isStateFaction(player) || Admin.HaveAdminRights(player))
                {
                    // Eingang
                    /*if (SAM_Teleport_Base_Enter.Distance(player.Position) < 1.25f)
                    {
                        if(player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        
                        Core.VnX.SetDelayedBoolSharedData(player, "TELEPORT_ANTICHEAT_COOLDOWN", false, 3000);
                        
                        player.SetPosition = SAM_Teleport_Base_Exit;
                        player.Dimension = Constants.FACTION_SAMCRO;
                        return true;
                    }
                    else if (SAM_Teleport_Base_Exit.Distance(player.Position) < 1.25f && player.Dimension == Constants.FACTION_SAMCRO)
                    {
                        if(player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        
                        Core.VnX.SetDelayedBoolSharedData(player, "TELEPORT_ANTICHEAT_COOLDOWN", false, 3000);
                        
                        player.SetPosition = SAM_Teleport_Base_Enter;
                        player.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                        return true;
                    }*/
                }
            }
            catch { }
            return false;
        }


        [Command("zivizeit")]
        public static void Zivizeit(VnXPlayer player)
        {
            try
            {
                if (player.vnxGetElementData<DateTime>(EntityData.PLAYER_ZIVIZEIT) < DateTime.Now)
                {
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 0) + "Zivizeit Abgelaufen. [" + player.vnxGetElementData<DateTime>(EntityData.PLAYER_ZIVIZEIT) + "]");
                }
                else
                {
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(175, 0, 0) + "Zivizeit läuft noch. [" + player.vnxGetElementData<DateTime>(EntityData.PLAYER_ZIVIZEIT) + "]");
                }
            }
            catch { }
        }

        [Command("selfuninvite")]
        public static void Selfuninvite(VnXPlayer player)
        {
            try
            {
                if (player.Reallife.Faction != Constants.FACTION_NONE)
                {
                    Faction.CreateFactionInformation(player.Reallife.Faction, player.Username + " hat die Fraktion verlassen...");
                    player.Reallife.Faction = Constants.FACTION_NONE;
                    player.Reallife.SpawnLocation = "noobspawn";
                    player.Reallife.Zivizeit = DateTime.Now.AddDays(1);
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Du hast dich selbst uninvitet!");
                }
            }
            catch { }

        }

        [Command("invite")]
        public static void InvitePlayerToFaction(VnXPlayer player, string target_name)
        {
            try
            {
                VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.Reallife.Faction != Constants.FACTION_NONE && player.Reallife.FactionRank >= 4)
                {
                    if (target.Reallife.Faction == Constants.FACTION_NONE)
                    {
                        if (target.Reallife.Zivizeit < DateTime.Now)
                        {
                            target.Reallife.Faction = player.Reallife.Faction;
                            target.Reallife.FactionRank = 0;
                            target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 0) + "Du wurdest soeben in eine Fraktion aufgenommen! Tippe /t [Text] für den Chat und F2, um mehr zu erfahren!");
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 0) + "Du hast den Spieler " + target.Username + " in deine Fraktion aufgenommen!");
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(175, 0, 0) + "Der Spieler " + target.Username + " hat noch eine Zivizeit am laufen. [" + target.vnxGetElementData<DateTime>(EntityData.PLAYER_ZIVIZEIT) + "]");
                        }
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Der Spieler ist bereits in einer Fraktion!");
                    }
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Erst ab Rank 4 möglich!");
                }
            }
            catch { }
        }

        [Command("uninvite")]
        public static void UninviteFromFactionPlayer(VnXPlayer player, string target_name)
        {
            try
            {
                VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (player.Reallife.Faction != Constants.FACTION_NONE && player.Reallife.FactionRank >= 4)
                {
                    if (target.Reallife.Faction == player.Reallife.Faction)
                    {
                        if (target.Username == player.Username)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du kannst dich nicht selbst Rauswerfen... Nutze /selfuninvite");
                            return;
                        }
                        if (target.Reallife.FactionRank < 5)
                        {
                            target.Reallife.Faction = 0;
                            target.Reallife.FactionRank = 0;
                            target.Reallife.SpawnLocation = "noobspawn";
                            target.Reallife.Zivizeit = DateTime.Now.AddDays(1);
                            target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(175, 0, 0) + "Du wurdest soeben aus deiner Fraktion geworfen!");
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 175, 0) + "Du hast den Spieler " + target.Username + " aus deiner Fraktion entfernt!");
                        }
                        else
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du kannst keinen Leader un-inviten!");
                        }
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Der Spieler ist nicht in deiner Fraktion!");
                    }
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Erst ab Rank 4 möglich!");
                }
            }
            catch { }
        }


        [Command("giverank")]
        public static void SetPlayerFraktionsRang(VnXPlayer player, string target_name, int number)
        {
            try
            {
                VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                if (number > 4 || number < 0)
                {
                    return;
                }
                if (player.Reallife.FactionRank >= 4 && player.Reallife.Faction > Constants.FACTION_NONE)
                {
                    if (target.Reallife.Faction != player.Reallife.Faction)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Der Spieler ist nicht in deiner Fraktion!");
                        return;
                    }
                    if (target.Reallife.FactionRank == 5)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du kannst einen Leader/Co-Leader nicht seinen Rang ändern!");
                        return;
                    }
                    if (target.Reallife.FactionRank == number)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Der Spieler hat bereits diesen Rang...");
                        return;
                    }
                    string rankString = string.Empty;
                    foreach (FactionModel factionModel in Constants.FACTION_RANK_LIST)
                    {
                        if (factionModel.faction == player.Reallife.Faction && factionModel.rank == number)
                        {
                            rankString = player.Sex == Constants.SEX_MALE ? factionModel.descriptionMale : factionModel.descriptionFemale;
                            break;
                        }
                    }
                    if (target.Reallife.FactionRank < number)
                    {
                        target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 175, 0) + "Glückwunsch, du wurdest soeben von " + player.Username + " zum " + rankString + " befördert!");
                    }
                    else
                    {
                        target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(175, 0, 0) + "Du wurdest soeben von " + player.Username + " zum " + rankString + " degradiert!");
                    }
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 175, 0) + "Du hast " + target.Username + " soeben Rang " + rankString + " ( " + number + " ) gegeben!");
                    target.Reallife.FactionRank = number;

                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist nicht befugt!");
                }
            }
            catch
            {
            }
        }

        [ClientEvent("goDUTYBADServer")]
        public void GoDUTYBADServer(VnXPlayer player, string state)
        {
            try
            {
                int playerSex = player.Sex;
                int playerFaction = player.Reallife.Faction;

                if (player.IsDead) { _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Diese Aktion ist derzeit nicht Möglich!"); return; }

                if (state == "anziehen")
                {
                    if (player.Reallife.Faction > Constants.FACTION_NONE)
                    {
                        foreach (UniformModel uniform in Constants.UNIFORM_LIST)
                        {
                            if (uniform.type == 0 && uniform.factionJob == playerFaction && playerSex == uniform.characterSex)
                            {
                                RageAPI.SetClothes(player, uniform.uniformSlot, uniform.uniformDrawable, uniform.uniformTexture);
                            }
                            else if (uniform.type == 1 && playerSex == uniform.characterSex)
                            {
                                RageAPI.SetClothes(player, uniform.uniformSlot, uniform.uniformDrawable, uniform.uniformTexture);
                            }
                        }
                        player.SetHealth = 200;
                        player.SetArmor = 100;
                        if (isBadFaction(player))
                        {
                            player.Reallife.OnDutyBad = 1;
                        }
                        else if (isNeutralFaction(player))
                        {
                            player.Reallife.OnDutyNeutral = 1;
                        }
                    }
                }
                else
                {
                    Customization.ApplyPlayerClothes(player);
                    player.SpawnPlayer(player.Position);
                    Customization.ApplyPlayerClothes(player);
                    player.SetHealth = 200;
                    player.SetArmor = 100;
                    weapons.Weapons.GivePlayerWeaponItems(player);
                    if (isBadFaction(player))
                    {
                        player.Reallife.OnDutyBad = 0;
                    }
                    else if (isNeutralFaction(player))
                    {
                        player.Reallife.OnDutyNeutral = 0;
                    }
                }
            }
            catch
            {
            }
        }

        [ClientEvent("goDUTYServer")]
        public void GoDutyIPlayer(VnXPlayer player)
        {
            try
            {
                int playerSex = player.Sex;
                int playerFaction = player.Reallife.Faction;
                if (player.IsDead)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Diese Aktion ist derzeit nicht Möglich!");
                    return;
                }
                if (isStateFaction(player))
                {
                    foreach (UniformModel uniform in Constants.UNIFORM_LIST)
                    {
                        if (uniform.type == 0 && uniform.factionJob == playerFaction && playerSex == uniform.characterSex)
                        {
                            RageAPI.SetClothes(player, uniform.uniformSlot, uniform.uniformDrawable, uniform.uniformTexture);
                        }
                        else if (uniform.type == 1 && playerSex == uniform.characterSex)
                        {
                            RageAPI.SetProp(player, uniform.uniformSlot, uniform.uniformDrawable, uniform.uniformTexture);
                        }
                    }
                    player.Reallife.OnDuty = 1;
                    player.SetHealth = 200;
                    player.SetArmor = 100;
                    weapons.Weapons.GivePlayerWeaponItems(player);
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        [ClientEvent("goSWATServer")]
        public void goSWATDutyPlayer(VnXPlayer player)
        {
            try
            {
                if (player.IsDead)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Diese Aktion ist derzeit nicht Möglich!");
                    return;
                }
                if (!isStateFaction(player)) { return; }

                player.Reallife.OnDuty = 1;
                player.SetHealth = 200;
                player.SetArmor = 100;
                player.SetClothes(6, 24, 0);
                player.SetClothes(4, 33, 0);
                player.SetClothes(9, 7, 1);
                player.SetClothes(11, 50, 0);
                player.SetProp(0, 144, 0);
                player.SetClothes(3, 4, 0);
                player.SetClothes(8, 15, 0);
                weapons.Weapons.GivePlayerWeaponItems(player);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }

        }

        [ClientEvent("goOFFDUTYServer")]
        public void OffDuty_Server_EVENT(VnXPlayer player)
        {
            try
            {
                if (player.IsDead)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Diese Aktion ist derzeit nicht Möglich!");
                    return;
                }
                if (player.Reallife.OnDuty == 1)
                {
                    // Populate player's clothes
                    Customization.ApplyPlayerClothes(player);

                    // We set the player off duty
                    player.Reallife.OnDuty = 0;
                    // Load selected character
                    player.SpawnPlayer(player.Position);
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
