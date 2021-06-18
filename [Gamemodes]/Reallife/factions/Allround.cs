using System;
using System.Collections.Generic;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Enums;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.character;
using VenoXV._Gamemodes_.Reallife.Factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV.Core;
using VenoXV.Models;
using Main = VenoXV._Notifications_.Main;
using VehicleModel = VenoXV.Models.VehicleModel;
using VnX = VenoXV._Gamemodes_.Reallife.anzeigen.Usefull.VnX;
using Weapons = VenoXV._Gamemodes_.Reallife.weapons.Weapons;

namespace VenoXV.Reallife.factions
{
    public class Allround : IScript
    {
        public static Position LcnTeleportBaseEnter = new Position(-842.2286f, -25.041758f, 40.38391f);
        public static Position LcnTeleportBaseExit = new Position(266.1213f, -1007.609f, -101.0086f);

        public static Position FibTeleportHeliExit = new Position(141.338f, -734.9205f, 262.8516f);
        public static Position FibTeleportHeliEnter = new Position(142.3689f, -769.2345f, 45.75201f);
        public static Position FibTeleportGarageExit = new Position(144.0502f, -688.8917f, 33.12821f);
        public static Position FibTeleportGarageEnter = new Position(141.121f, -765.5373f, 45.75201f);

        public static Position EmergencyTeleportHeliEnter = new Position(359.6378f, -584.9634f, 28.81754f);
        public static Position EmergencyTeleportHeliExit = new Position(338.7505f, -583.8655f, 74.16565f);

        public static Position BallasTeleportBaseEnter = new Position(294.0073f, -2087.792f, 17.66358f);
        public static Position BallasTeleportBaseExit = new Position(266.1213f, -1007.609f, -101.0086f);

        public static Position ComptonTeleportBaseEnter = new Position(126.6941f, -1930.021f, 21.38243f);
        public static Position ComptonTeleportBaseExit = new Position(266.1213f, -1007.609f, -101.0086f);

        public static Position YakuzaTeleportBaseEnter = new Position(-1516.701f, 851.7410f, 181.5947f);
        public static Position YakuzaTeleportBaseExit = new Position(346.4642f, -1013.237f, -99.19626f);

        public static Position Ms13TeleportBaseEnter = new Position(-1549.369f, -91.01895f, 54.92917f);
        public static Position Ms13TeleportBaseExit = new Position(-1289.76f, 449.9201f, 97.90071f);

        //public static Position SAM_Teleport_Base_Enter = new Position(982.1898f, -103.258f, 74.84872f); // 982,1898, -103,258, 74,84872
        //public static Position SAM_Teleport_Base_Exit = new Position(981.1188f, -102.3915f, 74.84511f); // 981.1188, -102.3915, 74.84511

        public static Position Ms13TeleportBaseHeliEnter = new Position(-1554.938f, -115.0005f, 54.51854f);
        public static Position Ms13TeleportBaseHeliExit = new Position(-1553.669f, -106.2555f, 67.1683f);

        public static Position LcnTeleportBaseHeliEnter = new Position(-855.75824f, -33.66593f, 44.141357f);
        public static Position LcnTeleportBaseHeliExit = new Position(-849.33624f, -27.995604f, 50.931885f);




        public static Position LspdFgunsCol = new Position(451.5455f, -993.3593f, 30.6896f);
        public static ColShapeModel LspdcolFguns = RageApi.CreateColShapeSphere(LspdFgunsCol, 2f);

        public static Position FbiFgunsCol = new Position(136.1328f, -761.8464f, 45.75203f);
        public static ColShapeModel FbicolFguns = RageApi.CreateColShapeSphere(FbiFgunsCol, 1.5f);


        public static Position BadInteriorFgunsCol = new Position(256.6112f, -996.761f, -99.00867f);
        public static Position BadInterior2FgunsCol = new Position(350.1265f, -993.4926f, -99.19615f);
        public static Position BadInterior3FgunsCol = new Position(973.5081f, -101.8594f, 74.84988f);
        public static Position BadInterior4FgunsCol = new Position(-1286.099f, 438.3797f, 94.09482f);
        public static ColShapeModel BadInteriorFguns = RageApi.CreateColShapeSphere(BadInteriorFgunsCol, 1.5f);
        public static ColShapeModel BadInterior2Fguns = RageApi.CreateColShapeSphere(BadInterior2FgunsCol, 1.5f);
        public static ColShapeModel BadInterior3Fguns = RageApi.CreateColShapeSphere(BadInterior3FgunsCol, 1.5f);
        public static ColShapeModel BadInterior4Fguns = RageApi.CreateColShapeSphere(BadInterior4FgunsCol, 1.5f);


        public static void OnResourceStart()
        {
            //Wantedgründe Laden : 
            Police.AddToWantedDictionary();
            //
            BadInterior3Fguns.Dimension = Constants.FactionSamcro;
            BadInterior4Fguns.Dimension = Constants.FactionNarcos;
            //ToDo: ClientSide erstellen NAPI.
            //.CreateTextLabel("LCN Eingang", LCN_Teleport_Base_Enter, 10.0f, 0.5f, 4, new Rgba(40, 40, 40, 255));
            RageApi.CreateTextLabel("LCN Eingang", LcnTeleportBaseEnter, 10.0f, 0.5f, 4, new[] { 40, 40, 40, 255 });
            RageApi.CreateTextLabel("LCN Ausgang", LcnTeleportBaseExit, 10.0f, 0.5f, 4, new[] { 40, 40, 40, 255 }, Constants.FactionLcn);

            RageApi.CreateTextLabel("Yakuza Eingang", YakuzaTeleportBaseEnter, 10.0f, 0.5f, 4, new[] { 175, 0, 0, 255 });
            RageApi.CreateTextLabel("Yakuza Ausgang", YakuzaTeleportBaseExit, 10.0f, 0.5f, 4, new[] { 175, 0, 0, 255 }, Constants.FactionYakuza);

            RageApi.CreateTextLabel("Mitarbeiter Ausgang", FibTeleportHeliExit, 10.0f, 0.5f, 4, new[] { 0, 86, 184, 255 });
            RageApi.CreateTextLabel("Mitarbeiter Eingang", FibTeleportHeliEnter, 10.0f, 0.5f, 4, new[] { 0, 86, 184, 255 });
            RageApi.CreateTextLabel("Tiefgaragen Ausgang", FibTeleportGarageExit, 10.0f, 0.5f, 4, new[] { 0, 86, 184, 255 });
            RageApi.CreateTextLabel("Tiefgaragen Eingang", FibTeleportGarageEnter, 10.0f, 0.5f, 4, new[] { 0, 86, 184, 255 });

            RageApi.CreateTextLabel("Mitarbeiter Eingang", EmergencyTeleportHeliEnter, 10.0f, 0.5f, 4, new[] { 255, 51, 51, 255 });
            RageApi.CreateTextLabel("Mitarbeiter Ausgang", EmergencyTeleportHeliExit, 10.0f, 0.5f, 4, new[] { 255, 51, 51, 255 });

            RageApi.CreateTextLabel("Narcos Eingang", Ms13TeleportBaseEnter, 10.0f, 0.5f, 4, new[] { 128, 129, 150, 255 });
            RageApi.CreateTextLabel("Narcos Ausgang", Ms13TeleportBaseExit, 10.0f, 0.5f, 4, new[] { 128, 129, 150, 255 }, Constants.FactionNarcos);

            //RageAPI.CreateTextLabel("SAMCRO Eingang", SAM_Teleport_Base_Enter, 10.0f, 0.5f, 4, new int[] { 128, 129, 150, 255 });
            //RageAPI.CreateTextLabel("SAMCRO Ausgang", SAM_Teleport_Base_Exit, 10.0f, 0.5f, 4, new int[] { 128, 129, 150, 255 }, Constants.FACTION_SAMCRO);

            RageApi.CreateTextLabel("Narcos Dach Eingang", Ms13TeleportBaseHeliEnter, 10.0f, 0.5f, 4, new[] { 128, 129, 150, 255 }, Constants.FactionNone);
            RageApi.CreateTextLabel("Narcos Dach Ausgang", Ms13TeleportBaseHeliExit, 10.0f, 0.5f, 4, new[] { 128, 129, 150, 255 }, Constants.FactionNone);

            RageApi.CreateTextLabel("Mafia Dach Eingang", LcnTeleportBaseHeliEnter, 10.0f, 0.5f, 4, new[] { 40, 40, 40, 255 }, Constants.FactionNone);
            RageApi.CreateTextLabel("Mafia Dach Ausgang", LcnTeleportBaseHeliExit, 10.0f, 0.5f, 4, new[] { 40, 40, 40, 255 }, Constants.FactionNone);

            RageApi.CreateTextLabel("Rollin Height´s Eingang", BallasTeleportBaseEnter, 10.0f, 0.5f, 4, new[] { 138, 43, 226, 255 });
            RageApi.CreateTextLabel("Rollin Height´s Ausgang", BallasTeleportBaseExit, 10.0f, 0.5f, 4, new[] { 138, 43, 226, 255 }, Constants.FactionBallas);
            //RageAPI.CreateTextLabel("Danke für Alles" + "\n_______________\n" + "For Palma", new Position(276.7415f, -2066.709f, 17.17801f), 10.0f, 0.5f, 4, new int[] { 138, 43, 226, 255 }, 0);


            RageApi.CreateTextLabel("Compton Family´s Eingang", ComptonTeleportBaseEnter, 10.0f, 0.5f, 4, new[] { 0, 152, 0, 255 });
            RageApi.CreateTextLabel("Compton Family´s Ausgang", ComptonTeleportBaseExit, 10.0f, 0.5f, 4, new[] { 0, 152, 0, 255 }, Constants.FactionCompton);


            //ToDo: Requesting Offices NAPI.World.RequestIpl ("ex_sm_15_office_01b");


            /* ColShapeModels */

            RageApi.CreateTextLabel("L.S.P.D Equip", LspdFgunsCol, 10.0f, 0.5f, 4, new[] { 0, 105, 145, 255 });

            RageApi.CreateTextLabel("F.I.B Equip", FbiFgunsCol, 10.0f, 0.5f, 4, new[] { 0, 86, 184, 255 });


            RageApi.CreateTextLabel("BAD Equip", BadInteriorFgunsCol, 10.0f, 0.5f, 4, new[] { 200, 0, 0, 255 });
            RageApi.CreateTextLabel("BAD Equip", BadInterior2FgunsCol, 10.0f, 0.5f, 4, new[] { 200, 0, 0, 255 });
            RageApi.CreateTextLabel("BAD Equip", BadInterior3FgunsCol, 10.0f, 0.5f, 4, new[] { 200, 0, 0, 255 });
            RageApi.CreateTextLabel("BAD Equip", BadInterior4FgunsCol, 10.0f, 0.5f, 4, new[] { 200, 0, 0, 255 });

            BadInteriorFguns.VnxSetElementData("isWeaponSelectShape", true);
            BadInterior2Fguns.VnxSetElementData("isWeaponSelectShape", true);
            BadInterior3Fguns.VnxSetElementData("isWeaponSelectShape", true);
            BadInterior4Fguns.VnxSetElementData("isWeaponSelectShape", true);

        }


        private static Dictionary<string, WeaponModel> _fgunsWeapons = new Dictionary<string, WeaponModel>
        {
            {   "Schlagstock",  WeaponModel.Nightstick },
            {   "Tazer",        WeaponModel.StunGun },
            {   "Pistole",      WeaponModel.Pistol },
            {   "Pistole50",    WeaponModel.Pistol50 },
            {   "Shotgun",      WeaponModel.PumpShotgun },
            {   "PDW",          WeaponModel.CombatPDW },
            {   "Karabiner",    WeaponModel.CarbineRifle },
            {   "Kampfgewehr",  WeaponModel.AdvancedRifle },
            {   "Sniper",       WeaponModel.SniperRifle },
        };

        public static void UpdateFgunsWindow(VnXPlayer player)
        {
            if (IsStateFaction(player))
            {
                WaffenlagerModel fweapon = Fraktionswaffenlager.GetWaffenlagerById(Constants.FactionLspd);

                VenoX.TriggerClientEvent(player, "fguns:ForceStateWindowUpdate",
                    "Schlagstock", " [ " + fweapon.WeaponNightstick.Amount + " ] ",
                    "Tazer", " [ " + fweapon.WeaponTazer.Amount + " ] ",
                    "Pistole", " [ " + fweapon.WeaponPistol.Amount + " ] ",
                    "Pistole50", " [ " + fweapon.WeaponPistol50.Amount + " ] ",
                    "Shotgun", " [ " + fweapon.WeaponPumpshotgun.Amount + " ] ",
                    "PDW", " [ " + fweapon.WeaponCombatpdw.Amount + " ] ",
                    "Karabiner", " [ " + fweapon.WeaponCarbinerifle.Amount + " ] ",
                    "Kampfgewehr", " [ " + fweapon.WeaponAdvancedrifle.Amount + " ] ",
                    "Sniper", " [ " + fweapon.WeaponSniperrifle.Amount + " ] "
                    );
            }
        }


        [VenoXRemoteEvent("fguns:selectweapon")]
        public static void FgunsSelectWeapon(VnXPlayer player, string weapon)
        {
            try
            {
                if (player.Reallife.Faction == Constants.FactionNone) return;
                if (!_fgunsWeapons.TryGetValue(weapon, out WeaponModel weaponHash))
                {
                    Debug.OutputDebugString("fguns:selectweapon not found weapon ID : " + weapon);
                    return;
                }
                WaffenlagerModel fweapon = Fraktionswaffenlager.GetWaffenlagerById(player.Reallife.Faction);

            }
            catch (Exception ex)
            {
                Debug.CatchExceptions(ex);
            }        
        }

        public static bool OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (shape == LspdcolFguns || shape == FbicolFguns)
                {
                    if (IsStateFaction(player))
                    {
                        WaffenlagerModel fweapon = Fraktionswaffenlager.GetWaffenlagerById(Constants.FactionLspd);
                        VenoX.TriggerClientEvent(player, "fguns:Open", true);
                        UpdateFgunsWindow(player);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.CatchExceptions(ex);
                return false;
            }
        }

        public static bool IsBadFaction(VnXPlayer player)
        {
            try
            {
                int playerFraktion = player.Reallife.Faction;
                if
                (playerFraktion == Constants.FactionLcn || playerFraktion == Constants.FactionYakuza ||
                playerFraktion == Constants.FactionNarcos || playerFraktion == Constants.FactionSamcro ||
                playerFraktion == Constants.FactionBallas || playerFraktion == Constants.FactionCompton)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return false; }
        }
        public static bool IsStateFaction(VnXPlayer player)
        {
            try
            {
                int playerFraktion = player.Reallife.Faction;
                return playerFraktion == Constants.FactionLspd || playerFraktion == Constants.FactionFbi || playerFraktion == Constants.FactionUsarmy;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return false; }
        }
        public static bool IsStateIVehicle(VehicleModel vehicle)
        {
            try
            {
                int vehicleFraktion = vehicle.Faction;
                return vehicleFraktion == Constants.FactionLspd || vehicleFraktion == Constants.FactionFbi || vehicleFraktion == Constants.FactionUsarmy;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return false; }
        }

        public static bool IsBadIVehicle(VehicleModel vehicle)
        {
            try
            {
                int vehicleFraktion = vehicle.Faction;
                return vehicleFraktion == Constants.FactionLcn || vehicleFraktion == Constants.FactionYakuza || vehicleFraktion == Constants.FactionNarcos || vehicleFraktion == Constants.FactionSamcro || vehicleFraktion == Constants.FactionBallas || vehicleFraktion == Constants.FactionCompton;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return false; }
        }
        public static bool IsNeutralIVehicle(VehicleModel vehicle)
        {
            try
            {
                int vehicleFraktion = vehicle.Faction;
                return vehicleFraktion == Constants.FactionNews || vehicleFraktion == Constants.FactionEmergency || vehicleFraktion == Constants.FactionMechanik;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return false; }
        }


        public static bool IsNeutralFaction(VnXPlayer player)
        {
            try
            {
                int playerFraktion = player.Reallife.Faction;
                return playerFraktion == Constants.FactionEmergency || playerFraktion == Constants.FactionNews || playerFraktion == Constants.FactionMechanik;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); return false; }
        }


        public static bool IsNearFactionTeleporter(VnXPlayer player)
        {
            try
            {
                int playerFraktion = player.Reallife.Faction;

                if (playerFraktion == Constants.FactionNone)
                {
                    return false;
                }
                int coolDown = 3;
                if (playerFraktion == Constants.FactionLcn || IsStateFaction(player) || Admin.HaveAdminRights(player))
                {
                    // Eingang
                    if (LcnTeleportBaseEnter.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            Main.DrawTranslatedNotification(player, Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(coolDown);
                        player.SetPosition = LcnTeleportBaseExit;
                        player.Dimension = Constants.FactionLcn;
                        return true;
                    }

                    if (LcnTeleportBaseExit.Distance(player.Position) < 1.25f && player.Dimension == Constants.FactionLcn)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            Main.DrawTranslatedNotification(player, Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(coolDown);
                        player.SetPosition = LcnTeleportBaseEnter;
                        player.Dimension = _Globals_.Main.ReallifeDimension + player.Language;
                        return true;
                    }

                    // HELI DACH
                    if (LcnTeleportBaseHeliEnter.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            Main.DrawTranslatedNotification(player, Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(coolDown);
                        player.SetPosition = LcnTeleportBaseHeliExit;
                        player.Dimension = _Globals_.Main.ReallifeDimension + player.Language;
                        return true;
                    }

                    if (LcnTeleportBaseHeliExit.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            Main.DrawTranslatedNotification(player, Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(coolDown);
                        player.SetPosition = LcnTeleportBaseHeliEnter;
                        player.Dimension = _Globals_.Main.ReallifeDimension + player.Language;
                        return true;
                    }
                }

                if (playerFraktion == Constants.FactionYakuza || IsStateFaction(player) || Admin.HaveAdminRights(player))
                {
                    // Eingang
                    if (YakuzaTeleportBaseEnter.Distance(player.Position) < 1.55f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            Main.DrawTranslatedNotification(player, Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(coolDown);
                        player.SetPosition = YakuzaTeleportBaseExit;
                        player.Dimension = Constants.FactionYakuza;
                        return true;
                    }

                    if (YakuzaTeleportBaseExit.Distance(player.Position) < 1.55f && player.Dimension == Constants.FactionYakuza)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            Main.DrawTranslatedNotification(player, Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(coolDown);
                        player.SetPosition = YakuzaTeleportBaseEnter;
                        player.Dimension = _Globals_.Main.ReallifeDimension + player.Language;
                        return true;
                    }
                }

                if (playerFraktion == Constants.FactionFbi || IsStateFaction(player) || Admin.HaveAdminRights(player))
                {
                    // Eingang
                    if (FibTeleportHeliEnter.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            Main.DrawTranslatedNotification(player, Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(coolDown);
                        player.SetPosition = FibTeleportHeliExit;
                        return true;
                    }

                    if (FibTeleportHeliExit.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            Main.DrawTranslatedNotification(player, Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(coolDown);
                        player.SetPosition = FibTeleportHeliEnter;
                        return true;
                    }
                    if (FibTeleportGarageEnter.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            Main.DrawTranslatedNotification(player, Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(coolDown);
                        player.SetPosition = FibTeleportGarageExit;
                        return true;
                    }

                    if (FibTeleportGarageExit.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            Main.DrawTranslatedNotification(player, Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(coolDown);
                        player.SetPosition = FibTeleportGarageEnter;
                        return true;
                    }
                }

                if (playerFraktion == Constants.FactionEmergency || IsStateFaction(player) || Admin.HaveAdminRights(player))
                {
                    // Eingang
                    if (EmergencyTeleportHeliEnter.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            Main.DrawTranslatedNotification(player, Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(coolDown);
                        player.SetPosition = EmergencyTeleportHeliExit;
                        return true;
                    }

                    if (EmergencyTeleportHeliExit.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            Main.DrawTranslatedNotification(player, Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(coolDown);
                        player.SetPosition = EmergencyTeleportHeliEnter;
                        return true;
                    }
                }

                if (playerFraktion == Constants.FactionNarcos || IsStateFaction(player) || Admin.HaveAdminRights(player))
                {
                    // Eingang
                    if (Ms13TeleportBaseEnter.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            Main.DrawTranslatedNotification(player, Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(coolDown);
                        player.SetPosition = Ms13TeleportBaseExit;
                        player.Dimension = Constants.FactionNarcos;
                        return true;
                    }

                    if (Ms13TeleportBaseExit.Distance(player.Position) < 1.25f && player.Dimension == Constants.FactionNarcos)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            Main.DrawTranslatedNotification(player, Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(coolDown);
                        player.SetPosition = Ms13TeleportBaseEnter;
                        player.Dimension = _Globals_.Main.ReallifeDimension + player.Language;
                        return true;
                    }

                    // Eingang

                    if (Ms13TeleportBaseHeliEnter.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            Main.DrawTranslatedNotification(player, Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(coolDown);
                        player.SetPosition = Ms13TeleportBaseHeliExit;
                        return true;
                    }

                    if (Ms13TeleportBaseHeliExit.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            Main.DrawTranslatedNotification(player, Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(coolDown);
                        player.SetPosition = Ms13TeleportBaseHeliEnter;
                        return true;
                    }
                }

                if (playerFraktion == Constants.FactionBallas || IsStateFaction(player) || Admin.HaveAdminRights(player))
                {
                    // Eingang
                    if (BallasTeleportBaseEnter.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            Main.DrawTranslatedNotification(player, Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }

                        player.SetPosition = BallasTeleportBaseExit;
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(coolDown);
                        player.Dimension = Constants.FactionBallas;
                        return true;
                    }

                    if (BallasTeleportBaseExit.Distance(player.Position) < 1.25f && player.Dimension == Constants.FactionBallas)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            Main.DrawTranslatedNotification(player, Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetPosition = BallasTeleportBaseEnter;
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(coolDown);
                        player.Dimension = _Globals_.Main.ReallifeDimension + player.Language;
                        return true;
                    }
                }

                if (playerFraktion == Constants.FactionCompton || IsStateFaction(player) || Admin.HaveAdminRights(player))
                {
                    // Eingang
                    if (ComptonTeleportBaseEnter.Distance(player.Position) < 1.25f)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            Main.DrawTranslatedNotification(player, Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetPosition = ComptonTeleportBaseExit;
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(coolDown);
                        player.Dimension = Constants.FactionCompton;
                        return true;
                    }

                    if (ComptonTeleportBaseExit.Distance(player.Position) < 1.25f && player.Dimension == Constants.FactionCompton)
                    {
                        if (player.Reallife.LastFactionTeleport > DateTime.Now)
                        {
                            Main.DrawTranslatedNotification(player, Main.Types.Warning, "Bitte warte 3 Sekunden!");
                            return true;
                        }
                        player.SetPosition = ComptonTeleportBaseEnter;
                        player.Reallife.LastFactionTeleport = DateTime.Now.AddSeconds(coolDown);
                        player.Dimension = _Globals_.Main.ReallifeDimension + player.Language;
                        return true;
                    }
                }

                if (playerFraktion == Constants.FactionSamcro || IsStateFaction(player) || Admin.HaveAdminRights(player))
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
                        player.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION+ player.Language;
                        return true;
                    }*/
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
            return false;
        }


        [Command("zivizeit")]
        public static void Zivizeit(VnXPlayer player)
        {
            try
            {
                if (player.VnxGetElementData<DateTime>(EntityData.PlayerZivizeit) < DateTime.Now)
                {
                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 0) + "Zivizeit Abgelaufen. [" + player.VnxGetElementData<DateTime>(EntityData.PlayerZivizeit) + "]");
                }
                else
                {
                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(175, 0, 0) + "Zivizeit läuft noch. [" + player.VnxGetElementData<DateTime>(EntityData.PlayerZivizeit) + "]");
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        [Command("selfuninvite")]
        public static void Selfuninvite(VnXPlayer player)
        {
            try
            {
                if (player.Reallife.Faction != Constants.FactionNone)
                {
                    Faction.CreateFactionInformation(player.Reallife.Faction, player.Username + " hat die Fraktion verlassen...");
                    player.Reallife.Faction = Constants.FactionNone;
                    player.Reallife.SpawnLocation = "noobspawn";
                    player.Reallife.FactionCooldown = DateTime.Now.AddDays(1);
                    Main.DrawNotification(player, Main.Types.Info, "Du hast dich selbst uninvitet!");
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}

        }

        [Command("invite")]
        public static void InvitePlayerToFaction(VnXPlayer player, string targetName)
        {
            try
            {
                VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                if (target == null) { return; }
                if (player.Reallife.Faction != Constants.FactionNone && player.Reallife.FactionRank >= 4)
                {
                    if (target.Reallife.Faction == Constants.FactionNone)
                    {
                        if (target.Reallife.FactionCooldown < DateTime.Now)
                        {
                            target.Reallife.Faction = player.Reallife.Faction;
                            target.Reallife.FactionRank = 0;
                            target.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 150, 0) + "Du wurdest soeben in eine Fraktion aufgenommen! Tippe /t [Text] für den Chat und F2, um mehr zu erfahren!");
                            player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 150, 0) + "Du hast den Spieler " + target.Username + " in deine Fraktion aufgenommen!");
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageApi.GetHexColorcode(175, 0, 0) + "Der Spieler " + target.Username + " hat noch eine Zivizeit am laufen. [" + target.VnxGetElementData<DateTime>(EntityData.PlayerZivizeit) + "]");
                        }
                    }
                    else
                    {
                        Main.DrawNotification(player, Main.Types.Error, "Der Spieler ist bereits in einer Fraktion!");
                    }
                }
                else
                {
                    Main.DrawNotification(player, Main.Types.Error, "Erst ab Rank 4 möglich!");
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        [Command("uninvite")]
        public static void UninviteFromFactionPlayer(VnXPlayer player, string targetName)
        {
            try
            {
                VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                if (target == null) { return; }
                if (player.Reallife.Faction != Constants.FactionNone && player.Reallife.FactionRank >= 4)
                {
                    if (target.Reallife.Faction == player.Reallife.Faction)
                    {
                        if (target.Username == player.Username)
                        {
                            Main.DrawNotification(player, Main.Types.Error, "Du kannst dich nicht selbst Rauswerfen... Nutze /selfuninvite");
                            return;
                        }
                        if (target.Reallife.FactionRank < 5)
                        {
                            target.Reallife.Faction = 0;
                            target.Reallife.FactionRank = 0;
                            target.Reallife.SpawnLocation = "noobspawn";
                            target.Reallife.FactionCooldown = DateTime.Now.AddDays(1);
                            target.SendTranslatedChatMessage(RageApi.GetHexColorcode(175, 0, 0) + "Du wurdest soeben aus deiner Fraktion geworfen!");
                            player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 175, 0) + "Du hast den Spieler " + target.Username + " aus deiner Fraktion entfernt!");
                        }
                        else
                        {
                            Main.DrawNotification(player, Main.Types.Error, "Du kannst keinen Leader un-inviten!");
                        }
                    }
                    else
                    {
                        Main.DrawNotification(player, Main.Types.Error, "Der Spieler ist nicht in deiner Fraktion!");
                    }
                }
                else
                {
                    Main.DrawNotification(player, Main.Types.Error, "Erst ab Rank 4 möglich!");
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }


        [Command("giverank")]
        public static void SetPlayerFraktionsRang(VnXPlayer player, string targetName, int number)
        {
            try
            {
                VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                if (target == null) { return; }
                if (number > 4 || number < 0)
                {
                    return;
                }
                if (player.Reallife.FactionRank >= 4 && player.Reallife.Faction > Constants.FactionNone)
                {
                    if (target.Reallife.Faction != player.Reallife.Faction)
                    {
                        Main.DrawNotification(player, Main.Types.Error, "Der Spieler ist nicht in deiner Fraktion!");
                        return;
                    }
                    if (target.Reallife.FactionRank == 5)
                    {
                        Main.DrawNotification(player, Main.Types.Error, "Du kannst einen Leader/Co-Leader nicht seinen Rang ändern!");
                        return;
                    }
                    if (target.Reallife.FactionRank == number)
                    {
                        Main.DrawNotification(player, Main.Types.Error, "Der Spieler hat bereits diesen Rang...");
                        return;
                    }
                    string rankString = string.Empty;
                    foreach (FactionModel factionModel in Constants.FactionRankList)
                    {
                        if (factionModel.Faction == player.Reallife.Faction && factionModel.Rank == number)
                        {
                            rankString = player.Sex == Constants.SexMale ? factionModel.DescriptionMale : factionModel.DescriptionFemale;
                            break;
                        }
                    }
                    if (target.Reallife.FactionRank < number)
                    {
                        target.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 175, 0) + "Glückwunsch, du wurdest soeben von " + player.Username + " zum " + rankString + " befördert!");
                    }
                    else
                    {
                        target.SendTranslatedChatMessage(RageApi.GetHexColorcode(175, 0, 0) + "Du wurdest soeben von " + player.Username + " zum " + rankString + " degradiert!");
                    }
                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 175, 0) + "Du hast " + target.Username + " soeben Rang " + rankString + " ( " + number + " ) gegeben!");
                    target.Reallife.FactionRank = number;

                }
                else
                {
                    Main.DrawNotification(player, Main.Types.Error, "Du bist nicht befugt!");
                }
            }
            catch
            {
            }
        }

        [VenoXRemoteEvent("goDUTYBADServer")]
        public void GoDutybadServer(VnXPlayer player, string state)
        {
            try
            {
                int playerSex = player.Sex;
                int playerFaction = player.Reallife.Faction;

                if (player.IsDead) { Main.DrawNotification(player, Main.Types.Error, "Diese Aktion ist derzeit nicht Möglich!"); return; }

                if (state == "anziehen")
                {
                    if (player.Reallife.Faction > Constants.FactionNone)
                    {
                        foreach (UniformModel uniform in Constants.UniformList)
                        {
                            switch (uniform.Type)
                            {
                                case 0 when uniform.FactionJob == playerFaction && playerSex == uniform.CharacterSex:
                                case 1 when playerSex == uniform.CharacterSex:
                                    player.SetClothes(uniform.UniformSlot, uniform.UniformDrawable, uniform.UniformTexture);
                                    break;
                            }
                        }
                        player.SetHealth = 200;
                        player.SetArmor = 100;
                        if (IsBadFaction(player))
                        {
                            player.Reallife.OnDutyBad = 1;
                        }
                        else if (IsNeutralFaction(player))
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
                    Weapons.GivePlayerWeaponItems(player);
                    if (IsBadFaction(player))
                    {
                        player.Reallife.OnDutyBad = 0;
                    }
                    else if (IsNeutralFaction(player))
                    {
                        player.Reallife.OnDutyNeutral = 0;
                    }
                }
            }
            catch
            {
            }
        }

        [VenoXRemoteEvent("goDUTYServer")]
        public void GoDutyIPlayer(VnXPlayer player)
        {
            try
            {
                int playerSex = player.Sex;
                int playerFaction = player.Reallife.Faction;
                if (player.IsDead)
                {
                    Main.DrawNotification(player, Main.Types.Error, "Diese Aktion ist derzeit nicht Möglich!");
                    return;
                }
                if (IsStateFaction(player))
                {
                    foreach (UniformModel uniform in Constants.UniformList)
                    {
                        switch (uniform.Type)
                        {
                            case 0 when uniform.FactionJob == playerFaction && playerSex == uniform.CharacterSex:
                                player.SetClothes(uniform.UniformSlot, uniform.UniformDrawable, uniform.UniformTexture);
                                break;
                            case 1 when playerSex == uniform.CharacterSex:
                                player.SetProp(uniform.UniformSlot, uniform.UniformDrawable, uniform.UniformTexture);
                                break;
                        }
                    }
                    player.Reallife.OnDuty = 1;
                    player.SetHealth = 200;
                    player.SetArmor = 100;
                    Weapons.GivePlayerWeaponItems(player);
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        [VenoXRemoteEvent("goSWATServer")]
        public void GoSwatDutyPlayer(VnXPlayer player)
        {
            try
            {
                if (player.IsDead)
                {
                    Main.DrawNotification(player, Main.Types.Error, "Diese Aktion ist derzeit nicht Möglich!");
                    return;
                }
                if (!IsStateFaction(player)) { return; }

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
                Weapons.GivePlayerWeaponItems(player);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }

        }

        [VenoXRemoteEvent("goOFFDUTYServer")]
        public void OffDuty_Server_EVENT(VnXPlayer player)
        {
            try
            {
                if (player.IsDead)
                {
                    Main.DrawNotification(player, Main.Types.Error, "Diese Aktion ist derzeit nicht Möglich!");
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
                    VnX.RemoveAllWeapons(player);
                }
            }
            catch
            {
            }
        }

    }
}
