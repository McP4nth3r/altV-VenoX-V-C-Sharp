using System;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using VenoX.Core._Gamemodes_.Reallife.globals;
using VenoX.Core._Gamemodes_.Reallife.model;
using VenoX.Core._Globals_;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Database;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;
using EntityData = VenoX.Core._Gamemodes_.Reallife.globals.EntityData;
using VnX = VenoX.Core._Gamemodes_.Reallife.anzeigen.Usefull.VnX;

namespace VenoX.Core._Gamemodes_.Reallife.factions.State.LSPD
{
    public class Arrest : IScript
    {

        public const int KostenProWanted = 350;

        [Command("bail")]
        public static void BailPayPlayer(VnXPlayer player)
        {
            try
            {
                int kaution = player.VnxGetElementData<int>(EntityData.PlayerKaution);
                if (kaution > 0)
                {
                    if (player.VnxGetElementData<int>(EntityData.PlayerKnastzeit) > 0)
                    {
                        if (player.Reallife.Money >= kaution)
                        {
                            FraktionsKassen fkasse = Database.GetFactionStats(Constants.FactionLspd);
                            Database.SetFactionStats(Constants.FactionLspd, fkasse.Money + kaution, fkasse.Weed, fkasse.Koks, fkasse.Mats);
                            Faction.CreateCustomStateFactionMessage(RageApi.GetHexColorcode(0, 200, 0) + player.CharacterUsername + " hat die Kaution in Höhe von " + kaution + "$ bezahlt!");
                            player.VnxSetStreamSharedElementData(_Globals_.EntityData.PlayerMoney, player.Reallife.Money - kaution);
                            player.VnxSetStreamSharedElementData(EntityData.PlayerKnastzeit, 0);
                            //AntiCheat_Allround.SetTimeOutTeleport(player, 7000);
                            player.SetPosition = new Position(427.5651f, -981.0995f, 30.71008f);
                            player.Dimension = _Globals_.Initialize.ReallifeDimension + player.Language;
                            player.Reallife.PrisonBail = 0;
                            player.SendTranslatedChatMessage("{007d00}Du bist nun Frei! Verhalte dich in Zukunft besser!");
                            player.Freeze = false;
                        }
                        else if (player.Reallife.Bank >= kaution)
                        {
                            FraktionsKassen fkasse = Database.GetFactionStats(Constants.FactionLspd);
                            Database.SetFactionStats(Constants.FactionLspd, fkasse.Money + kaution, fkasse.Weed, fkasse.Koks, fkasse.Mats);
                            Faction.CreateCustomStateFactionMessage(RageApi.GetHexColorcode(0, 200, 0) + player.CharacterUsername + " hat die Kaution in Höhe von " + kaution + "$ bezahlt!");
                            player.Reallife.Bank -= kaution;
                            //AntiCheat_Allround.SetTimeOutTeleport(player, 7000);
                            player.VnxSetStreamSharedElementData(EntityData.PlayerKnastzeit, 0);
                            player.SetPosition = new Position(427.5651f, -981.0995f, 30.71008f);
                            player.Dimension = _Globals_.Initialize.ReallifeDimension + player.Language;
                            player.Reallife.PrisonBail = 0;
                            player.SendTranslatedChatMessage("{007d00}Du bist nun Frei! Verhalte dich in Zukunft besser!");
                            player.Freeze = false;
                        }
                        else
                        {
                            _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, "Du hast nicht genug Geld!");
                        }
                    }
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
        [Command("bailinfo")]
        public static void BailInfoPlayer(VnXPlayer player)
        {
            try
            {
                if (player.Reallife.PrisonTime > 0)
                {
                    if (player.Reallife.PrisonBail > 0)
                    {
                        player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 150, 200) + "----------------------------------");
                        player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 150, 200) + "Du hast eine Kaution von " + player.VnxGetElementData<int>(EntityData.PlayerKaution) + "$!");
                        player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 150, 200) + "nutze /bail um die Kaution zu bezahlen.");
                        player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 150, 200) + "----------------------------------");
                    }

                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
        [Command("jailtime")]
        public static void GetPlayerJailTime(VnXPlayer player)
        {
            try
            {
                if (player.Reallife.PrisonTime > 0)
                {
                    player.SendTranslatedChatMessage("Du bist noch " + RageApi.GetHexColorcode(0, 200, 255) + " " + player.VnxGetElementData<int>(_Globals_.EntityData.PlayerPrisonTime) + RageApi.GetHexColorcode(255, 255, 255) + " Minuten im Prison!");
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        [Command("tie")]
        public static void TiePlayerinIVehicle(VnXPlayer player, string targetName)
        {
            try
            {
                if (factions.Allround.IsStateFaction(player))
                {
                    VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                    if (target == null) return;
                    if (player.Reallife.OnDuty != 1)
                    {
                        Notification.DrawTranslatedNotification(player, _Globals_.Notification.Types.Error, "Du bist kein Staatsfraktionist im Dienst!");
                        return;
                    }
                    if (player.Position.Distance(target.Position) > 2.5f)
                    {
                        _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, "Du bist zuweit von " + target.CharacterUsername + " entfernt...");
                        return;
                    }
                    if (!target.Reallife.Handcuffed)
                    {
                        target.Reallife.Handcuffed = true;
                        _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Info, "Du hast " + target.CharacterUsername + " gefesselt!");
                        _Globals_.Notification.DrawNotification(target, _Globals_.Notification.Types.Warning, player.CharacterUsername + " hat dich gefesselt!");
                    }
                    else
                    {
                        target.Reallife.Handcuffed = false;
                        _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Info, "Du hast " + target.CharacterUsername + " Handschellen entfernt!");
                        _Globals_.Notification.DrawNotification(target, _Globals_.Notification.Types.Info, player.CharacterUsername + " hat deine Handschellen abgenommen!");
                    }

                }
            }
            catch
            {
            }
        }


        [Command("grab")]
        public static void GrabPlayer(VnXPlayer player, string targetName)
        {
            try
            {
                if (factions.Allround.IsStateFaction(player))
                {
                    VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                    if (target == null) return;
                    if (player.IsInVehicle)
                    {
                        if (target.VnxGetElementData<bool>(EntityData.PlayerHandcuffed))
                        {
                            if (player.Position.Distance(target.Position) > 2.5f)
                            {
                                _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, "Du bist zuweit von " + target.CharacterUsername + " entfernt...");
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
        public void ArrestPlayerCmd(VnXPlayer player, string targetName, int kaution)
        {
            try
            {
                VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                if (target == null) { return; }
                Position arrestpositioncar = new Position(479.1359f, -1021.734f, 28.00093f);
                if (player.Position.Distance(arrestpositioncar) < 3.5f)
                {
                    if (factions.Allround.IsStateFaction(player) == false)
                    {
                        _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, "Du bist kein Beamter im Dienst!");
                        return;
                    }
                    // We check whether the player is connected
                    if (target != null && target.Playing)
                    {
                        if (target.Reallife.WantedStars == 0)
                        {
                            player.SendTranslatedChatMessage("{007d00}Der Spieler hat keine Wanteds!");

                        }
                        else if (target.Reallife.PrisonTime > 0)
                        {
                            player.SendTranslatedChatMessage("{007d00}Der Spieler ist bereits im Knast!");
                        }
                        else
                        {
                            if (target.Position.Distance(arrestpositioncar) < 3.5f)
                            {
                                VehicleModel vehicle = (VehicleModel)target.Vehicle;
                                if (factions.Allround.IsStateIVehicle(vehicle))
                                {
                                    FraktionsKassen fkasse = Database.GetFactionStats(Constants.FactionLspd);
                                    if (kaution == 1)
                                    {
                                        //Kaution Code
                                        Database.SetFactionStats(Constants.FactionLspd, fkasse.Money + target.Reallife.WantedStars * 400, fkasse.Weed, fkasse.Koks, fkasse.Mats);
                                        target.SendChatMessage(RageApi.GetHexColorcode(0, 150, 0) + Faction.GetPlayerFactionRank(player) + " | " + player.CharacterUsername + " hat dich Eingesperrt für " + KostenProWanted * target.Reallife.WantedStars + "$ Kaution & " + target.Reallife.WantedStars * 4 + " Minuten!");
                                        player.SendChatMessage(RageApi.GetHexColorcode(0, 150, 0) + "Du hast " + target.CharacterUsername + " Eingesperrt für " + KostenProWanted * target.Reallife.WantedStars + "$ Kaution & " + target.Reallife.WantedStars * 4 + " Minuten.");
                                        target.Reallife.PrisonTime = target.Reallife.WantedStars * 4;
                                        target.Reallife.PrisonBail = KostenProWanted * target.Reallife.WantedStars;
                                        target.Reallife.WantedStars = 0;
                                        Random random = new Random();
                                        int dim = random.Next(1, 9999);
                                        target.Dimension = dim;
                                        target.SetPosition = Constants.JailSpawns[random.Next(3)];
                                        target.Reallife.Handcuffed = false;
                                        VnX.RemoveAllWeapons(target);
                                    }
                                    else
                                    {
                                        Database.SetFactionStats(Constants.FactionLspd, fkasse.Money + target.Reallife.WantedStars * 400, fkasse.Weed, fkasse.Koks, fkasse.Mats);
                                        // Ohne Kaution Knast code
                                        target.SendChatMessage(RageApi.GetHexColorcode(0, 150, 0) + "Officer " + player.CharacterUsername + " hat dich Eingesperrt ohne Kaution für " + target.Reallife.WantedStars * 5 + " Minuten.");
                                        player.SendChatMessage(RageApi.GetHexColorcode(0, 150, 0) + "Du hast " + target.CharacterUsername + " Eingesperrt für " + target.Reallife.WantedStars * 5 + " Minuten.");
                                        target.Reallife.PrisonTime = target.Reallife.WantedStars * 5;
                                        target.Reallife.PrisonBail = 0;
                                        target.Reallife.WantedStars = 0;
                                        Random random = new Random();
                                        int dim = random.Next(1, 9999);
                                        target.Dimension = dim;
                                        target.SetPosition = Constants.JailSpawns[random.Next(3)];
                                        target.Reallife.Handcuffed = false;
                                        VnX.RemoveAllWeapons(target);
                                    }
                                    target.Freeze = true;
                                    RageApi.SendTranslatedChatMessageToAll(RageApi.GetHexColorcode(0, 0, 175) + Faction.GetPlayerFactionRank(player) + " | " + player.CharacterUsername + " hat " + target.CharacterUsername + " eingesperrt.");
                                }
                            }
                            else
                            {
                                _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, "Der Spieler " + target.CharacterUsername + " ist nicht im PD Hinterhof!");
                            }
                        }
                    }
                }
                else
                {
                    _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, "Du bist nicht auf dem PD Hinterhof!");
                }
            }
            catch
            {
            }
        }

        public static ColShapeModel StellenColShapeModel = RageApi.CreateColShapeSphere(new Position(441.0676f, -981.1415f, 30.68959f), 1);
        public static bool OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (shape != StellenColShapeModel) return false;
                _RootCore_.VenoX.TriggerClientEvent(player, "showStellenWindow", "Wilkommen im Los Santos Police Department,<br> hier kannst du dich stellen falls du <br>gesucht wirst. <br>Dadurch erhältst du eine geringere Strafe.");
                return true;
            }
            catch { return false; }
        }


        [VenoXRemoteEvent("Stellen_Server_Event")]
        public void Stellen_server_event(VnXPlayer player)
        {
            try
            {
                if (player.VnxGetElementData<int>(EntityData.PlayerWanteds) == 0)
                {
                    player.SendTranslatedChatMessage("Du hast keine Wanteds!");
                }
                else
                {
                    RageApi.SendTranslatedChatMessageToAll(RageApi.GetHexColorcode(0, 145, 200) + player.CharacterUsername + RageApi.GetHexColorcode(255, 255, 255) + " hat sich gestellt!");
                    player.VnxSetElementData(EntityData.PlayerKnastzeit, player.VnxGetElementData<int>(EntityData.PlayerWanteds) * 4);
                    player.VnxSetElementData(EntityData.PlayerKaution, player.VnxGetElementData<int>(EntityData.PlayerWanteds) * KostenProWanted);
                    BailInfoPlayer(player);
                    player.VnxSetStreamSharedElementData(EntityData.PlayerWanteds, 0);
                    VnX.RemoveAllWeapons(player);
                    Random random = new Random();
                    int dim = random.Next(1, 9999);
                    player.Dimension = dim;
                    player.SetPosition = Constants.JailSpawns[random.Next(0, Constants.JailSpawns.Count)];
                }
            }
            catch
            {
            }
        }
    }
}
