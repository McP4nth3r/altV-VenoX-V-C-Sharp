﻿using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using VenoXV._Gamemodes_.Reallife.database;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;
using VenoXV.Anti_Cheat;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.factions.LSPD
{
    public class Arrest : IScript
    {

        public const int KostenProWanted = 350;

        [Command("bail")]
        public static void BailPayPlayer(PlayerModel player)
        {
            try
            {
                int kaution = player.vnxGetElementData<int>(EntityData.PLAYER_KAUTION);
                if (kaution > 0)
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_KNASTZEIT) > 0)
                    {
                        if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) >= kaution)
                        {
                            Fraktions_Kassen fkasse = Database.GetFactionStats(Constants.FACTION_POLICE);
                            Database.SetFactionStats(Constants.FACTION_POLICE, fkasse.money + kaution, fkasse.weed, fkasse.koks, fkasse.mats);
                            Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 200, 0) + player.GetVnXName() + " hat die Kaution in Höhe von " + kaution + "$ bezahlt!");
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) - kaution);
                            player.vnxSetStreamSharedElementData(EntityData.PLAYER_KNASTZEIT, 0);
                            AntiCheat_Allround.SetTimeOutTeleport(player, 7000);
                            player.position = new Position(427.5651f, -981.0995f, 30.71008f);
                            player.Dimension = 0;
                            player.vnxSetElementData(EntityData.PLAYER_KAUTION, 0);
                            player.SendChatMessage("{007d00}Du bist nun Frei! Verhalte dich in Zukunft besser!");
                            anzeigen.Usefull.VnX.UpdateHUD(player);
                        }
                        else if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_BANK) >= kaution)
                        {
                            Fraktions_Kassen fkasse = Database.GetFactionStats(Constants.FACTION_POLICE);
                            Database.SetFactionStats(Constants.FACTION_POLICE, fkasse.money + kaution, fkasse.weed, fkasse.koks, fkasse.mats);
                            Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0, 200, 0) + player.GetVnXName() + " hat die Kaution in Höhe von " + kaution + "$ bezahlt!");
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_BANK, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_BANK) - kaution);
                            AntiCheat_Allround.SetTimeOutTeleport(player, 7000);
                            player.vnxSetStreamSharedElementData(EntityData.PLAYER_KNASTZEIT, 0);
                            player.position = new Position(427.5651f, -981.0995f, 30.71008f);
                            player.Dimension = 0;
                            player.vnxSetElementData(EntityData.PLAYER_KAUTION, 0);
                            player.SendChatMessage("{007d00}Du bist nun Frei! Verhalte dich in Zukunft besser!");
                            anzeigen.Usefull.VnX.UpdateHUD(player);
                        }
                        else
                        {
                            dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
                        }
                    }
                }
            }
            catch { }
        }
        [Command("bailinfo")]
        public static void BailInfoPlayer(PlayerModel player)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_KNASTZEIT) > 0)
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_KAUTION) > 0)
                    {
                        player.SendChatMessage(RageAPI.GetHexColorcode(0, 150, 200) + "----------------------------------");
                        player.SendChatMessage(RageAPI.GetHexColorcode(0, 150, 200) + "Du hast eine Kaution von " + player.vnxGetElementData<int>(EntityData.PLAYER_KAUTION) + "$!");
                        player.SendChatMessage(RageAPI.GetHexColorcode(0, 150, 200) + "nutze /bail um die Kaution zu bezahlen.");
                        player.SendChatMessage(RageAPI.GetHexColorcode(0, 150, 200) + "----------------------------------");
                    }

                }
            }
            catch { }
        }
        [Command("jailtime")]
        public static void GetPlayerJailTime(PlayerModel player)
        {
            try
            {
                if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_PRISON_TIME) > 0)
                {
                    player.SendChatMessage("Du bist noch " + RageAPI.GetHexColorcode(0, 200, 255) + " " + player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_PRISON_TIME) + RageAPI.GetHexColorcode(255, 255, 255) + " Minuten im Prison!");
                }
            }
            catch { }
        }

        [Command("tie")]
        public static void TiePlayerinIVehicle(PlayerModel player, string target_name)
        {
            try
            {
                if (Allround.isStateFaction(player))
                {
                    PlayerModel target = RageAPI.GetPlayerFromName(target_name);
                    if (target == null) { return; }
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_ON_DUTY) != 1)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du bist kein Staatsfraktionist im Dienst!");
                        return;
                    }
                    if (player.position.Distance(target.position) > 2.5f)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du bist zuweit von " + target.GetVnXName() + " entfernt...");
                        return;
                    }
                    if (target.IsInVehicle && target.vnxGetElementData<bool>(EntityData.PLAYER_HANDCUFFED) == false)
                    {
                        target.vnxSetElementData(EntityData.PLAYER_HANDCUFFED, true);
                        dxLibary.VnX.DrawNotification(player, "info", "Du hast " + target.GetVnXName() + " gefesselt!");
                        dxLibary.VnX.DrawNotification(target, "warning", player.GetVnXName() + " hat dich gefesselt!");
                        // Disable some player movements
                        target.Emit("toggleHandcuffed", true);
                    }
                    else if (target.IsInVehicle && target.vnxGetElementData<bool>(EntityData.PLAYER_HANDCUFFED) == true)
                    {
                        target.vnxSetElementData(EntityData.PLAYER_HANDCUFFED, false);
                        dxLibary.VnX.DrawNotification(player, "info", "Du hast " + target.GetVnXName() + " Handschellen entfernt!");
                        dxLibary.VnX.DrawNotification(target, "info", player.GetVnXName() + " hat deine Handschellen abgenommen!");
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
                            dxLibary.VnX.DrawNotification(player, "info", "Du hast " + target.GetVnXName() + " gefesselt!");
                            dxLibary.VnX.DrawNotification(target, "warning", player.GetVnXName() + " hat dich gefesselt!");
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

                            dxLibary.VnX.DrawNotification(player, "info", "Du hast " + target.GetVnXName() + " Handschellen entfernt!");
                            dxLibary.VnX.DrawNotification(target, "info", player.GetVnXName() + " hat deine Handschellen abgenommen!");

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
        public static void GrabPlayer(PlayerModel player, string target_name)
        {
            try
            {
                if (Allround.isStateFaction(player))
                {
                    PlayerModel target = RageAPI.GetPlayerFromName(target_name);
                    if (target == null) { return; }
                    if (player.IsInVehicle)
                    {
                        if (target.vnxGetElementData<bool>(EntityData.PLAYER_HANDCUFFED))
                        {
                            if (player.position.Distance(target.position) > 2.5f)
                            {
                                dxLibary.VnX.DrawNotification(player, "error", "Du bist zuweit von " + target.GetVnXName() + " entfernt...");
                                return;
                            }
                            IVehicle Vehicle = player.Vehicle;
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
        public void ArrestPlayerCMD(PlayerModel player, string target_name, string kaution)
        {
            try
            {
                PlayerModel target = RageAPI.GetPlayerFromName(target_name);
                if (target == null) { return; }
                Position arrestpositioncar = new Position(479.1359f, -1021.734f, 28.00093f);
                if (player.position.Distance(arrestpositioncar) < 3.5f)
                {
                    if (Allround.isStateFaction(player) == false)
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du bist kein Beamter im Dienst!");
                        return;
                    }
                    // We check whether the player is connected
                    if (target != null && target.vnxGetElementData<bool>(EntityData.PLAYER_PLAYING) == true)
                    {
                        if (target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) == 0)
                        {
                            player.SendChatMessage("{007d00}Der Spieler hat keine Wanteds!");

                        }
                        else if (target.vnxGetElementData<int>(EntityData.PLAYER_KNASTZEIT) > 0)
                        {
                            player.SendChatMessage("{007d00}Der Spieler ist bereits im Knast!");
                        }
                        else
                        {
                            if (target.position.Distance(arrestpositioncar) < 3.5f)
                            {
                                IVehicle Vehicle = target.Vehicle;
                                if (Allround.isStateIVehicle(Vehicle))
                                {
                                    Fraktions_Kassen fkasse = Database.GetFactionStats(Constants.FACTION_POLICE);
                                    Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(target, 7000);
                                    if (kaution == "1")
                                    {
                                        //Kaution Code
                                        Database.SetFactionStats(Constants.FACTION_POLICE, fkasse.money + target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * 400, fkasse.weed, fkasse.koks, fkasse.mats);
                                        target.SendChatMessage(RageAPI.GetHexColorcode(0, 150, 0) + Faction.GetPlayerFactionRank(player) + " | " + player.GetVnXName() + " hat dich Eingesperrt für " + KostenProWanted * target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) + "$ Kaution & " + +target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * 4 + " Minuten!");
                                        player.SendChatMessage(RageAPI.GetHexColorcode(0, 150, 0) + "Du hast " + target.GetVnXName() + " Eingesperrt für " + KostenProWanted * target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) + "$ Kaution & " + target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * 4 + " Minuten.");
                                        target.vnxSetElementData(EntityData.PLAYER_KNASTZEIT, target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * 4);
                                        target.vnxSetElementData(EntityData.PLAYER_KAUTION, KostenProWanted * target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS));
                                        target.vnxSetStreamSharedElementData(EntityData.PLAYER_WANTEDS, 0);
                                        anzeigen.Usefull.VnX.UpdateHUD(target);
                                        anzeigen.Usefull.VnX.RemoveAllWeapons(target);
                                        Random random = new Random();
                                        int dim = random.Next(1, 9999);
                                        target.Dimension = dim;
                                        target.position = Constants.JAIL_SPAWNS[random.Next(3)];
                                        target.vnxSetElementData(EntityData.PLAYER_HANDCUFFED, false);
                                        target.Emit("toggleHandcuffed", false);
                                    }
                                    else
                                    {
                                        Database.SetFactionStats(Constants.FACTION_POLICE, fkasse.money + target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * 400, fkasse.weed, fkasse.koks, fkasse.mats);
                                        // Ohne Kaution Knast code
                                        target.SendChatMessage(RageAPI.GetHexColorcode(0, 150, 0) + "Officer " + player.GetVnXName() + " hat dich Eingesperrt ohne Kaution für " + target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * 5 + " Minuten.");
                                        player.SendChatMessage(RageAPI.GetHexColorcode(0, 150, 0) + "Du hast " + target.GetVnXName() + " Eingesperrt für " + target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * 5 + " Minuten.");
                                        target.vnxSetElementData(EntityData.PLAYER_KNASTZEIT, target.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * 5);
                                        target.vnxSetElementData(EntityData.PLAYER_KAUTION, 0);
                                        anzeigen.Usefull.VnX.UpdateHUD(target);
                                        target.vnxSetStreamSharedElementData(EntityData.PLAYER_WANTEDS, 0);
                                        anzeigen.Usefull.VnX.RemoveAllWeapons(target);
                                        Random random = new Random();
                                        int dim = random.Next(1, 9999);
                                        target.Dimension = dim;
                                        target.position = Constants.JAIL_SPAWNS[random.Next(3)];
                                        target.vnxSetElementData(EntityData.PLAYER_HANDCUFFED, false);
                                        target.Emit("toggleHandcuffed", false);
                                    }
                                    RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(0, 0, 175) + Faction.GetPlayerFactionRank(player) + " | " + player.GetVnXName() + " hat " + target.GetVnXName() + " eingesperrt.");
                                }
                            }
                            else
                            {
                                dxLibary.VnX.DrawNotification(player, "error", "Der Spieler " + target.GetVnXName() + " ist nicht im PD Hinterhof!");
                            }
                        }
                    }
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du bist nicht auf dem PD Hinterhof!");
                }
            }
            catch
            {
            }
        }

        public static IColShape stellenIColShape = Alt.CreateColShapeSphere(new Position(441.0676f, -981.1415f, 30.68959f), 1);
        public static void OnPlayerEnterIColShape(IColShape shape, PlayerModel player)
        {
            try
            {
                if (shape == stellenIColShape)
                {
                    player.Emit("showStellenWindow", "Wilkommen im Los Santos Police Department,<br> hier kannst du dich stellen falls du <br>gesucht wirst. <br>Dadurch erhältst du eine geringere Strafe.");
                }
            }
            catch { }
        }


        [ClientEvent("Stellen_Server_Event")]
        public void Stellen_server_event(PlayerModel player)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) == 0)
                {
                    player.SendChatMessage("Du hast keine Wanteds!");
                }
                else
                {
                    AntiCheat_Allround.SetTimeOutTeleport(player, 7000);
                    RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(0, 145, 200) + player.GetVnXName() + RageAPI.GetHexColorcode(255, 255, 255) + " hat sich gestellt!");
                    player.vnxSetElementData(EntityData.PLAYER_KNASTZEIT, player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * 4);
                    player.vnxSetElementData(EntityData.PLAYER_KAUTION, player.vnxGetElementData<int>(EntityData.PLAYER_WANTEDS) * KostenProWanted);
                    BailInfoPlayer(player);
                    player.vnxSetStreamSharedElementData(EntityData.PLAYER_WANTEDS, 0);
                    anzeigen.Usefull.VnX.RemoveAllWeapons(player);
                    anzeigen.Usefull.VnX.onWantedChange(player);
                    Random random = new Random();
                    int dim = random.Next(1, 9999);
                    player.Dimension = dim;
                    player.position = Constants.JAIL_SPAWNS[random.Next(3)];
                }
            }
            catch
            {

            }
        }
    }
}
