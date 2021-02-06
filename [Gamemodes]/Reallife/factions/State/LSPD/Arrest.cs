using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using System;
using VenoXV._Gamemodes_.Reallife.factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Factions.LSPD
{
    public class Arrest : IScript
    {

        public const int KostenProWanted = 350;

        [Command("bail")]
        public static void BailPayPlayer(VnXPlayer player)
        {
            try
            {
                int kaution = player.vnxGetElementData<int>(EntityData.PLAYER_KAUTION);
                if (kaution > 0)
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_KNASTZEIT) > 0)
                    {
                        if (player.Reallife.Money >= kaution)
                        {
                            Fraktions_Kassen fkasse = Database.GetFactionStats(Constants.FACTION_LSPD);
                            Database.SetFactionStats(Constants.FACTION_LSPD, fkasse.money + kaution, fkasse.weed, fkasse.koks, fkasse.mats);
                            Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 200, 0) + player.Username + " hat die Kaution in Höhe von " + kaution + "$ bezahlt!");
                            player.vnxSetStreamSharedElementData(VenoXV._Globals_.EntityData.PLAYER_MONEY, player.Reallife.Money - kaution);
                            player.vnxSetStreamSharedElementData(EntityData.PLAYER_KNASTZEIT, 0);
                            //AntiCheat_Allround.SetTimeOutTeleport(player, 7000);
                            player.SetPosition = new Position(427.5651f, -981.0995f, 30.71008f);
                            player.Dimension = VenoXV._Globals_.Main.REALLIFE_DIMENSION + player.Language;
                            player.Reallife.Kaution = 0;
                            player.SendTranslatedChatMessage("{007d00}Du bist nun Frei! Verhalte dich in Zukunft besser!");
                            player.Freeze = false;
                        }
                        else if (player.Reallife.Bank >= kaution)
                        {
                            Fraktions_Kassen fkasse = Database.GetFactionStats(Constants.FACTION_LSPD);
                            Database.SetFactionStats(Constants.FACTION_LSPD, fkasse.money + kaution, fkasse.weed, fkasse.koks, fkasse.mats);
                            Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 200, 0) + player.Username + " hat die Kaution in Höhe von " + kaution + "$ bezahlt!");
                            player.Reallife.Bank -= kaution;
                            //AntiCheat_Allround.SetTimeOutTeleport(player, 7000);
                            player.vnxSetStreamSharedElementData(EntityData.PLAYER_KNASTZEIT, 0);
                            player.SetPosition = new Position(427.5651f, -981.0995f, 30.71008f);
                            player.Dimension = VenoXV._Globals_.Main.REALLIFE_DIMENSION + player.Language;
                            player.Reallife.Kaution = 0;
                            player.SendTranslatedChatMessage("{007d00}Du bist nun Frei! Verhalte dich in Zukunft besser!");
                            player.Freeze = false;
                        }
                        else
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        }
                    }
                }
            }
            catch { }
        }
        [Command("bailinfo")]
        public static void BailInfoPlayer(VnXPlayer player)
        {
            try
            {
                if (player.Reallife.Knastzeit > 0)
                {
                    if (player.Reallife.Kaution > 0)
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 200) + "----------------------------------");
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 200) + "Du hast eine Kaution von " + player.vnxGetElementData<int>(EntityData.PLAYER_KAUTION) + "$!");
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 200) + "nutze /bail um die Kaution zu bezahlen.");
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 200) + "----------------------------------");
                    }

                }
            }
            catch { }
        }
        [Command("jailtime")]
        public static void GetPlayerJailTime(VnXPlayer player)
        {
            try
            {
                if (player.Reallife.Knastzeit > 0)
                {
                    player.SendTranslatedChatMessage("Du bist noch " + RageAPI.GetHexColorcode(0, 200, 255) + " " + player.vnxGetElementData<int>(VenoXV._Globals_.EntityData.PLAYER_PRISON_TIME) + RageAPI.GetHexColorcode(255, 255, 255) + " Minuten im Prison!");
                }
            }
            catch { }
        }

        [Command("tie")]
        public static void TiePlayerinIVehicle(VnXPlayer player, string target_name)
        {
            try
            {
                if (Allround.isStateFaction(player))
                {
                    VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
                    if (target == null) return;
                    if (player.Reallife.OnDuty != 1)
                    {
                        _Notifications_.Main.DrawTranslatedNotification(player, _Notifications_.Main.Types.Error, "Du bist kein Staatsfraktionist im Dienst!");
                        return;
                    }
                    if (player.Position.Distance(target.Position) > 2.5f)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist zuweit von " + target.Username + " entfernt...");
                        return;
                    }
                    if (!target.Reallife.Handcuffed)
                    {
                        target.Reallife.Handcuffed = true;
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Du hast " + target.Username + " gefesselt!");
                        _Notifications_.Main.DrawNotification(target, _Notifications_.Main.Types.Warning, player.Username + " hat dich gefesselt!");
                    }
                    else
                    {
                        target.Reallife.Handcuffed = false;
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Du hast " + target.Username + " Handschellen entfernt!");
                        _Notifications_.Main.DrawNotification(target, _Notifications_.Main.Types.Info, player.Username + " hat deine Handschellen abgenommen!");
                    }

                }
            }
            catch
            {
            }
        }


        [Command("grab")]
        public static void GrabPlayer(VnXPlayer player, string target_name)
        {
            try
            {
                if (Allround.isStateFaction(player))
                {
                    VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
                    if (target == null) return;
                    if (player.IsInVehicle)
                    {
                        if (target.vnxGetElementData<bool>(EntityData.PLAYER_HANDCUFFED))
                        {
                            if (player.Position.Distance(target.Position) > 2.5f)
                            {
                                _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist zuweit von " + target.Username + " entfernt...");
                                return;
                            }
                            VehicleModel vehicle = (VehicleModel)player.Vehicle;
                            target.WarpIntoVehicle(vehicle, 2);
                            //target.vnxGetElementData(SetIntoIVehicle(IVehicle, 2);
                        }
                    }
                }
            }
            catch
            {
            }
        }


        [Command("arrest")]
        public void ArrestPlayerCMD(VnXPlayer player, string target_name, int kaution)
        {
            try
            {
                VnXPlayer target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                Position arrestpositioncar = new Position(479.1359f, -1021.734f, 28.00093f);
                if (player.Position.Distance(arrestpositioncar) < 3.5f)
                {
                    if (Allround.isStateFaction(player) == false)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist kein Beamter im Dienst!");
                        return;
                    }
                    // We check whether the player is connected
                    if (target != null && target.Playing == true)
                    {
                        if (target.Reallife.Wanteds == 0)
                        {
                            player.SendTranslatedChatMessage("{007d00}Der Spieler hat keine Wanteds!");

                        }
                        else if (target.Reallife.Knastzeit > 0)
                        {
                            player.SendTranslatedChatMessage("{007d00}Der Spieler ist bereits im Knast!");
                        }
                        else
                        {
                            if (target.Position.Distance(arrestpositioncar) < 3.5f)
                            {
                                VehicleModel vehicle = (VehicleModel)target.Vehicle;
                                if (Allround.isStateIVehicle(vehicle))
                                {
                                    Fraktions_Kassen fkasse = Database.GetFactionStats(Constants.FACTION_LSPD);
                                    if (kaution == 1)
                                    {
                                        //Kaution Code
                                        Database.SetFactionStats(Constants.FACTION_LSPD, fkasse.money + target.Reallife.Wanteds * 400, fkasse.weed, fkasse.koks, fkasse.mats);
                                        target.SendChatMessage(RageAPI.GetHexColorcode(0, 150, 0) + Faction.GetPlayerFactionRank(player) + " | " + player.Username + " hat dich Eingesperrt für " + KostenProWanted * target.Reallife.Wanteds + "$ Kaution & " + target.Reallife.Wanteds * 4 + " Minuten!");
                                        player.SendChatMessage(RageAPI.GetHexColorcode(0, 150, 0) + "Du hast " + target.Username + " Eingesperrt für " + KostenProWanted * target.Reallife.Wanteds + "$ Kaution & " + target.Reallife.Wanteds * 4 + " Minuten.");
                                        target.Reallife.Knastzeit = target.Reallife.Wanteds * 4;
                                        target.Reallife.Kaution = KostenProWanted * target.Reallife.Wanteds;
                                        target.Reallife.Wanteds = 0;
                                        Random random = new Random();
                                        int dim = random.Next(1, 9999);
                                        target.Dimension = dim;
                                        target.SetPosition = Constants.JAIL_SPAWNS[random.Next(3)];
                                        target.Reallife.Handcuffed = false;
                                        anzeigen.Usefull.VnX.RemoveAllWeapons(target);
                                    }
                                    else
                                    {
                                        Database.SetFactionStats(Constants.FACTION_LSPD, fkasse.money + target.Reallife.Wanteds * 400, fkasse.weed, fkasse.koks, fkasse.mats);
                                        // Ohne Kaution Knast code
                                        target.SendChatMessage(RageAPI.GetHexColorcode(0, 150, 0) + "Officer " + player.Username + " hat dich Eingesperrt ohne Kaution für " + target.Reallife.Wanteds * 5 + " Minuten.");
                                        player.SendChatMessage(RageAPI.GetHexColorcode(0, 150, 0) + "Du hast " + target.Username + " Eingesperrt für " + target.Reallife.Wanteds * 5 + " Minuten.");
                                        target.Reallife.Knastzeit = target.Reallife.Wanteds * 5;
                                        target.Reallife.Kaution = 0;
                                        target.Reallife.Wanteds = 0;
                                        Random random = new Random();
                                        int dim = random.Next(1, 9999);
                                        target.Dimension = dim;
                                        target.SetPosition = Constants.JAIL_SPAWNS[random.Next(3)];
                                        target.Reallife.Handcuffed = false;
                                        anzeigen.Usefull.VnX.RemoveAllWeapons(target);
                                    }
                                    target.Freeze = true;
                                    RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(0, 0, 175) + Faction.GetPlayerFactionRank(player) + " | " + player.Username + " hat " + target.Username + " eingesperrt.");
                                }
                            }
                            else
                            {
                                _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Der Spieler " + target.Username + " ist nicht im PD Hinterhof!");
                            }
                        }
                    }
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist nicht auf dem PD Hinterhof!");
                }
            }
            catch
            {
            }
        }

        public static ColShapeModel stellenColShapeModel = RageAPI.CreateColShapeSphere(new Position(441.0676f, -981.1415f, 30.68959f), 1);
        public static bool OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (shape != stellenColShapeModel) return false;
                VenoX.TriggerClientEvent(player, "showStellenWindow", "Wilkommen im Los Santos Police Department,<br> hier kannst du dich stellen falls du <br>gesucht wirst. <br>Dadurch erhältst du eine geringere Strafe.");
                return true;
            }
            catch { return false; }
        }


        [ClientEvent("Stellen_Server_Event")]
        public void Stellen_server_event(VnXPlayer player)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) == 0)
                {
                    player.SendTranslatedChatMessage("Du hast keine Wanteds!");
                }
                else
                {
                    RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(0, 145, 200) + player.Username + RageAPI.GetHexColorcode(255, 255, 255) + " hat sich gestellt!");
                    player.vnxSetElementData(EntityData.PLAYER_KNASTZEIT, player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * 4);
                    player.vnxSetElementData(EntityData.PLAYER_KAUTION, player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * KostenProWanted);
                    BailInfoPlayer(player);
                    player.vnxSetStreamSharedElementData(EntityData.PLAYER_WANTEDS, 0);
                    anzeigen.Usefull.VnX.RemoveAllWeapons(player);
                    Random random = new Random();
                    int dim = random.Next(1, 9999);
                    player.Dimension = dim;
                    player.SetPosition = Constants.JAIL_SPAWNS[random.Next(0, Constants.JAIL_SPAWNS.Count)];
                }
            }
            catch
            {
            }
        }
    }
}
