using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using System;
using VenoXV._Gamemodes_.Reallife.factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
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
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money - kaution);
                            player.vnxSetStreamSharedElementData(EntityData.PLAYER_KNASTZEIT, 0);
                            //AntiCheat_Allround.SetTimeOutTeleport(player, 7000);
                            player.SetPosition = new Position(427.5651f, -981.0995f, 30.71008f);
                            player.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                            player.vnxSetElementData(EntityData.PLAYER_KAUTION, 0);
                            player.SendTranslatedChatMessage("{007d00}Du bist nun Frei! Verhalte dich in Zukunft besser!");
                        }
                        else if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_BANK) >= kaution)
                        {
                            Fraktions_Kassen fkasse = Database.GetFactionStats(Constants.FACTION_LSPD);
                            Database.SetFactionStats(Constants.FACTION_LSPD, fkasse.money + kaution, fkasse.weed, fkasse.koks, fkasse.mats);
                            Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 200, 0) + player.Username + " hat die Kaution in Höhe von " + kaution + "$ bezahlt!");
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_BANK, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_BANK) - kaution);
                            //AntiCheat_Allround.SetTimeOutTeleport(player, 7000);
                            player.vnxSetStreamSharedElementData(EntityData.PLAYER_KNASTZEIT, 0);
                            player.SetPosition = new Position(427.5651f, -981.0995f, 30.71008f);
                            player.Dimension = VenoXV.Globals.Main.REALLIFE_DIMENSION;
                            player.vnxSetElementData(EntityData.PLAYER_KAUTION, 0);
                            player.SendTranslatedChatMessage("{007d00}Du bist nun Frei! Verhalte dich in Zukunft besser!");
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
                if (player.vnxGetElementData<int>(EntityData.PLAYER_KNASTZEIT) > 0)
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_KAUTION) > 0)
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
                if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_PRISON_TIME) > 0)
                {
                    player.SendTranslatedChatMessage("Du bist noch " + RageAPI.GetHexColorcode(0, 200, 255) + " " + player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_PRISON_TIME) + RageAPI.GetHexColorcode(255, 255, 255) + " Minuten im Prison!");
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
                    if (target == null) { return; }
                    if (player.Reallife.OnDuty != 1)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist kein Staatsfraktionist im Dienst!");
                        return;
                    }
                    if (player.Position.Distance(target.Position) > 2.5f)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist zuweit von " + target.Username + " entfernt...");
                        return;
                    }
                    if (target.IsInVehicle && target.vnxGetElementData<bool>(EntityData.PLAYER_HANDCUFFED) == false)
                    {
                        target.vnxSetElementData(EntityData.PLAYER_HANDCUFFED, true);
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Du hast " + target.Username + " gefesselt!");
                        _Notifications_.Main.DrawNotification(target, _Notifications_.Main.Types.Warning, player.Username + " hat dich gefesselt!");
                        // Disable some player movements
                        target.Emit("toggleHandcuffed", true);
                    }
                    else if (target.IsInVehicle && target.vnxGetElementData<bool>(EntityData.PLAYER_HANDCUFFED) == true)
                    {
                        target.vnxSetElementData(EntityData.PLAYER_HANDCUFFED, false);
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Du hast " + target.Username + " Handschellen entfernt!");
                        _Notifications_.Main.DrawNotification(target, _Notifications_.Main.Types.Info, player.Username + " hat deine Handschellen abgenommen!");
                        target.Emit("toggleHandcuffed", false);
                    }
                    else
                    {
                        if (target.vnxGetElementData<bool>(EntityData.PLAYER_HANDCUFFED) == false)
                        {
                            //GTANetworkAPI.Object cuff = NAPI.Object.CreateObject(-1281059971, new Position(0.0f, 0.0f, 0.0f), new Position(0.0f, 0.0f, 0.0f));
                            //cuff.AttachTo(target.vnxGetElementData<int>( "IK_R_Hand", new Position(0.0f, 0.0f, 0.0f), new Position(0.0f, 0.0f, 0.0f));
                            //target.Ani"mp_arresting", "idle", (int)(Constants.AnimationFlags.Loop | Constants.AnimationFlags.OnlyAnimateUpperBody | Constants.AnimationFlags.AllowPlayerControl));

                            player.vnxSetElementData(EntityData.PLAYER_ANIMATION, true);
                            target.vnxSetElementData(EntityData.PLAYER_HANDCUFFED, true);
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Du hast " + target.Username + " gefesselt!");
                            _Notifications_.Main.DrawNotification(target, _Notifications_.Main.Types.Warning, player.Username + " hat dich gefesselt!");
                            //target.Emit("Attach_Element_to_Entity", player, cuff);
                            // Disable some player movements
                            target.Emit("toggleHandcuffed", true);
                        }
                        else
                        {
                            /*GTANetworkAPI.Object cuff = target.vnxGetElementData<bool>(EntityData.PLAYER_HANDCUFFED);

                            cuff.Detach();
                            cuff.Remove();
                            */
                            //target.StopAnimation();
                            target.vnxSetElementData(EntityData.PLAYER_HANDCUFFED, false);
                            target.vnxSetElementData(EntityData.PLAYER_ANIMATION, false);

                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Du hast " + target.Username + " Handschellen entfernt!");
                            _Notifications_.Main.DrawNotification(target, _Notifications_.Main.Types.Info, player.Username + " hat deine Handschellen abgenommen!");

                            // Enable previously disabled player movements
                            target.Emit("toggleHandcuffed", false);
                        }
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
                    if (target == null) { return; }
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
                            //target.vnxGetElementData(SetIntoIVehicle(IVehicle, 2);
                        }
                    }
                }
            }
            catch
            {
            }
        }


        [Command("arrest", true)]
        public void ArrestPlayerCMD(VnXPlayer player, string target_name, string kaution)
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
                        if (target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) == 0)
                        {
                            player.SendTranslatedChatMessage("{007d00}Der Spieler hat keine Wanteds!");

                        }
                        else if (target.vnxGetElementData<int>(EntityData.PLAYER_KNASTZEIT) > 0)
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
                                    //Anti_Cheat.//AntiCheat_Allround.SetTimeOutTeleport(target, 7000);
                                    if (kaution == "1")
                                    {
                                        //Kaution Code
                                        Database.SetFactionStats(Constants.FACTION_LSPD, fkasse.money + target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * 400, fkasse.weed, fkasse.koks, fkasse.mats);
                                        target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 0) + Faction.GetPlayerFactionRank(player) + " | " + player.Username + " hat dich Eingesperrt für " + KostenProWanted * target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) + "$ Kaution & " + +target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * 4 + " Minuten!");
                                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 0) + "Du hast " + target.Username + " Eingesperrt für " + KostenProWanted * target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) + "$ Kaution & " + target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * 4 + " Minuten.");
                                        target.vnxSetElementData(EntityData.PLAYER_KNASTZEIT, target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * 4);
                                        target.vnxSetElementData(EntityData.PLAYER_KAUTION, KostenProWanted * target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS));
                                        target.vnxSetStreamSharedElementData(EntityData.PLAYER_WANTEDS, 0);
                                        anzeigen.Usefull.VnX.RemoveAllWeapons(target);
                                        Random random = new Random();
                                        int dim = random.Next(1, 9999);
                                        target.Dimension = dim;
                                        target.SetPosition = Constants.JAIL_SPAWNS[random.Next(3)];
                                        target.vnxSetElementData(EntityData.PLAYER_HANDCUFFED, false);
                                        target.Emit("toggleHandcuffed", false);
                                    }
                                    else
                                    {
                                        Database.SetFactionStats(Constants.FACTION_LSPD, fkasse.money + target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * 400, fkasse.weed, fkasse.koks, fkasse.mats);
                                        // Ohne Kaution Knast code
                                        target.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 0) + "Officer " + player.Username + " hat dich Eingesperrt ohne Kaution für " + target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * 5 + " Minuten.");
                                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 0) + "Du hast " + target.Username + " Eingesperrt für " + target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * 5 + " Minuten.");
                                        target.vnxSetElementData(EntityData.PLAYER_KNASTZEIT, target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * 5);
                                        target.vnxSetElementData(EntityData.PLAYER_KAUTION, 0);
                                        target.vnxSetStreamSharedElementData(EntityData.PLAYER_WANTEDS, 0);
                                        anzeigen.Usefull.VnX.RemoveAllWeapons(target);
                                        Random random = new Random();
                                        int dim = random.Next(1, 9999);
                                        target.Dimension = dim;
                                        target.SetPosition = Constants.JAIL_SPAWNS[random.Next(3)];
                                        target.vnxSetElementData(EntityData.PLAYER_HANDCUFFED, false);
                                        target.Emit("toggleHandcuffed", false);
                                    }
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
        public static void OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (shape == stellenColShapeModel)
                {
                    Alt.Server.TriggerClientEvent(player, "showStellenWindow", "Wilkommen im Los Santos Police Department,<br> hier kannst du dich stellen falls du <br>gesucht wirst. <br>Dadurch erhältst du eine geringere Strafe.");
                }
            }
            catch { }
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
