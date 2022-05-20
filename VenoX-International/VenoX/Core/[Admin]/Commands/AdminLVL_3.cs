using System;
using System.Linq;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using VenoX.Core._Gamemodes_.Reallife.globals;
using VenoX.Core._Preload_;
using VenoX.Core._Preload_.Model;
using VenoX.Core._Preload_.Register;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Database;
using VenoX.Core._RootCore_.Models;
using VenoX.Core._RootCore_.vnx_stored_files;
using VenoX.Debug;
using EntityData = VenoX.Core._Globals_.EntityData;
using Main = VenoX.Core._Language_.Main;
using VnX = VenoX.Core._Gamemodes_.Reallife.anzeigen.Usefull.VnX;

namespace VenoX.Core._Admin_.Commands
{
    public class AdminLvl3 : IScript
    {
        /////////////////////////////////////////////////SUPPORTER/////////////////////////////////////////////////
        /////////////////////////////////////////////////SUPPORTER/////////////////////////////////////////////////
        /////////////////////////////////////////////////SUPPORTER/////////////////////////////////////////////////
        /////////////////////////////////////////////////SUPPORTER/////////////////////////////////////////////////
        /////////////////////////////////////////////////SUPPORTER/////////////////////////////////////////////////


        [Command("goto", true)]
        public void TpCommand(VnXPlayer player, string targetName)
        {
            VnXPlayer target = RageApi.GetPlayerFromName(targetName);
            if (target == null) return;
            if (player.AdminRank >= Constants.AdminlvlSupporter)
            {
                // We get the player from the input string
                // Change player's position and dimension
                //AntiCheat_Allround.SetTimeOutTeleport(player, 2000);
                player.SetPosition = target.Position;
                player.Dimension = target.Dimension;
                player.SendChatMessage(RageApi.GetHexColorcode(255, 255, 255) + "Du hast dich zu " + RageApi.GetHexColorcode(0, 200, 255) + target.CharacterUsername + " " + RageApi.GetHexColorcode(255, 255, 255) + "teleportiert!");
                target.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + "[VnX]" + player.CharacterUsername + " " + RageApi.GetHexColorcode(255, 255, 255) + "hat sich zu dir teleportiert!");
                Logfile.WriteLogs("admin", player.CharacterUsername + " hat sich zu " + target.CharacterUsername + " geportet!");
            }
        }

        [Command("gethere", true)]
        public void BringCommand(VnXPlayer player, string targetName)
        {
            VnXPlayer target = RageApi.GetPlayerFromName(targetName);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.AdminlvlSupporter)
            {
                if (target != null)
                {
                    // Change target's position and dimension
                    //AntiCheat_Allround.SetTimeOutTeleport(target, 2000);
                    target.SetPosition = player.Position;
                    target.Dimension = player.Dimension;
                    player.SendChatMessage(RageApi.GetHexColorcode(255, 255, 255) + "Du hast " + RageApi.GetHexColorcode(0, 200, 255) + target.CharacterUsername + " " + RageApi.GetHexColorcode(255, 255, 255) + " zu dir teleportiert!");
                    target.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + "[VnX]" + player.CharacterUsername + " " + RageApi.GetHexColorcode(255, 255, 255) + "hat dich zu ihm teleportiert!");
                    Logfile.WriteLogs("admin", player.CharacterUsername + " hat " + target.CharacterUsername + " zu sich geportet!");
                }
                else
                {
                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "[Admin - Info]" + RageApi.GetHexColorcode(255, 255, 255) + " : Spieler wurde nicht gefunden!");
                }
            }
        }

        [Command("charakter")]
        public void CharacterCommand(VnXPlayer player, string action, string targetName, string amount)
        {
            try
            {
                VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                if (target == null) { return; }
                if (player.AdminRank > Constants.AdminlvlSupporter)
                {
                    // We check whether the player is connected
                    if (target != null && target.Playing)
                    {
                        if (int.TryParse(amount, out int value))
                        {
                            string message = string.Empty;
                            switch (action.ToLower())
                            {
                                case "bank":
                                    if (player.AdminRank > Constants.AdminlvlStellvp)
                                    {
                                        target.Reallife.Bank = value;
                                        player.SendTranslatedChatMessage("~g~Du hast das Bankgeld von " + target.CharacterUsername + " auf : " + value + " gesetzt!");
                                        target.SendTranslatedChatMessage(Constants.RgbaAdminClantag + player.CharacterUsername + "hat dein Bankgeld auf : " + value + " gesetzt!");
                                        Logfile.WriteLogs("admin", "[ID:" + player.Id + "]" + player.CharacterUsername + " hat das Bankgeld von " + target.CharacterUsername + " Auf " + value + " gesetzt!");
                                    }
                                    break;
                                case "money":
                                    if (player.AdminRank > Constants.AdminlvlStellvp)
                                    {
                                        target.Reallife.Money = value;
                                        player.SendTranslatedChatMessage("~g~Du hast das Bargeld von " + target.CharacterUsername + " auf : " + value + " gesetzt!");
                                        target.SendTranslatedChatMessage(Constants.RgbaAdminClantag + player.CharacterUsername + " hat dein Bargeld auf : " + value + " gesetzt!");
                                        Logfile.WriteLogs("admin", "[ID:" + player.Id + "]" + player.CharacterUsername + " hat das Bargeld von " + target.CharacterUsername + " Auf " + value + " gesetzt!");
                                    }
                                    break;
                                case "dimension":
                                    if (player.AdminRank > Constants.AdminlvlSupporter)
                                    {
                                        target.Dimension = value;
                                        player.SendTranslatedChatMessage("~g~Du hast " + target.CharacterUsername + " Dimension auf " + value + " gesetzt!");
                                        target.SendTranslatedChatMessage(Constants.RgbaAdminClantag + player.CharacterUsername + " hat deine Dimension auf :  " + value + " gesetzt!");
                                        Logfile.WriteLogs("admin", "[ID:" + player.Id + "]" + player.CharacterUsername + " hat " + target.CharacterUsername + " in die Dimension " + value + " verschoben!");

                                    }
                                    break;
                            }
                        }

                    }
                    else
                    {
                        player.SendTranslatedChatMessage(Constants.RgbaError + "SPIELER NICHT GEFUNDEN");
                    }

                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        [Command("getdim")]
        public static void GetAdminDimension(VnXPlayer player, string targetName)
        {
            VnXPlayer target = RageApi.GetPlayerFromName(targetName);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.AdminlvlModerator)
            {
                player.SendTranslatedChatMessage(target.CharacterUsername + " hat dimension : " + target.Dimension);
            }
        }

        [Command("lobbykick")]
        public static async void KickTargetFromLobby(VnXPlayer player, string targetName)
        {
            VnXPlayer target = RageApi.GetPlayerFromName(targetName);
            if (target == null) return;
            if (player.AdminRank >= Constants.AdminlvlSupporter)
            {
                string translatedText = await Main.GetTranslatedTextAsync((global::VenoX.Core._Language_.Constants.Languages)player.Language, "got kicked by");
                RageApi.SendChatMessageToAll(RageApi.GetHexColorcode(200, 0, 0) + target.CharacterUsername + " " + translatedText + " " + player.CharacterUsername);
                Preload.ShowGamemodeSelection(target);
            }
        }

        [Command("revive")]
        public void ReviveCommand(VnXPlayer player, string targetName)
        {
            VnXPlayer target = RageApi.GetPlayerFromName(targetName);
            if (target == null) return;
            if (player.AdminRank >= Constants.AdminlvlSupporter)
            {
                if (target != null)
                {
                    if (target.IsDead)
                    {
                        target.SpawnPlayer(target.Position);
                        player.SendChatMessage("~g~You revived " + target.CharacterUsername + ".");
                        target.SendChatMessage(Constants.RgbaAdminClantag + player.CharacterUsername + " revived you.");
                        Logfile.WriteLogs("admin", player.CharacterUsername + " hat " + target.CharacterUsername + " wiederbelebt!");
                        _RootCore_.VenoX.TriggerClientEvent(target, "destroyKrankenhausTimer");
                        _RootCore_.VenoX.TriggerClientEvent(target, "VnX_DestroyIPlayerSideTimer_KH");
                        foreach (VnXPlayer medics in Enumerable.ToList<VnXPlayer>(_Globals_.Initialize.ReallifePlayers))
                            if (medics.Reallife.Faction == Constants.FactionEmergency)
                                _RootCore_.VenoX.TriggerClientEvent(medics, "Destroy_MedicBlips", target.CharacterUsername);
                    }
                }
            }
        }



        [Command("prison")]
        public void JailCommand(VnXPlayer player, string target, int zeit, string grund)
        {
            try
            {
                if (player.AdminRank >= Constants.AdminlvlSupporter)
                {
                    bool found = Database.FindCharacterByName(target);
                    if (found)
                    {
                        string socialClubId = Database.GetCharacterSocialName(target);
                        string spielerName = Database.GetAccountPlayerName(socialClubId);
                        VnXPlayer targetplayer = RageApi.GetPlayerFromName(spielerName);
                        int uid = Database.GetCharakterUid(spielerName);
                        if (Database.FindCharakterPrison(spielerName))
                        {
                            int prisonTime = Database.GetCharakterPrisonTime(spielerName);
                            Database.UpdatePlayerPrisonTime(uid, prisonTime + zeit, grund, player.CharacterUsername, DateTime.Now);
                            Logfile.WriteLogs("admin", "[" + player.SocialClubId + "][" + player.CharacterUsername + "] hat [" + socialClubId + "][" + target + "] für " + zeit + " Minuten ins Prison gesteckt! Grund : " + grund);
                            RageApi.SendTranslatedChatMessageToAll(RageApi.GetHexColorcode(200, 0, 0) + spielerName + " wurde von [VnX]" + player.CharacterUsername + " für " + zeit + " Minuten ins Prison gesteckt! Grund : " + grund);
                        }
                        else
                        {
                            Database.AddPlayerToPrison(uid, spielerName, zeit, grund, player.CharacterUsername, DateTime.Now);
                            Logfile.WriteLogs("admin", "[" + player.SocialClubId + "][" + player.CharacterUsername + "] hat [" + socialClubId + "][" + target + "] für " + zeit + " Minuten ins Prison gesteckt! Grund : " + grund);
                            RageApi.SendTranslatedChatMessageToAll(RageApi.GetHexColorcode(200, 0, 0) + spielerName + " wurde von [VnX]" + player.CharacterUsername + " für " + zeit + " Minuten ins Prison gesteckt! Grund : " + grund);
                        }
                        if (targetplayer != null)
                        {
                            //AntiCheat_Allround.SetTimeOutTeleport(targetplayer, 5000);
                            targetplayer.Dimension = _Globals_.Initialize.ReallifeDimension + targetplayer.Language;
                            targetplayer.SetPosition = new Position(1651.441f, 2569.83f, 45.56486f);
                            VnX.RemoveAllWeapons(targetplayer);
                            targetplayer.VnxSetElementData(EntityData.PlayerPrisonTime, zeit);
                        }
                    }
                    else
                    {
                        _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, "Es wurde kein Spieler mit dem Namen " + target + " gefunden!");
                    }
                }
                else
                {
                    _Globals_.Notification.DrawNotification(player, _Globals_.Notification.Types.Error, "Du bist nicht Befugt!");
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        [Command("spec")]
        public void ReconCommand(VnXPlayer player, string targetName)
        {
            try
            {
                VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                if (target == null) return;
                if (player.AdminRank > Constants.AdminlvlSupporter)
                {
                    //anzeigen.Usefull.VnX.SpectatePlayer(player, target, 0);
                    Admin.SendAdminInformation(player.CharacterUsername + " spectatet grade " + target.CharacterUsername + "!");
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        [Command("specoff")]
        public void RecoffCommand(VnXPlayer player)
        {
            if (player.AdminRank > Constants.AdminlvlSupporter)
            {
                //anzeigen.Usefull.VnX.SpectatePlayer(player, player, 1);
                Admin.SendAdminInformation(player.CharacterUsername + " hat aufgehört " + player.CharacterUsername + " zu spectaten!");
            }
        }

        [Command("timeban")]
        public void timeban_player(VnXPlayer player, string targetName, int zeit, params string[] grundArray)
        {
            try
            {/*
                string grund = string.Join(" ", grundArray);
                if (player.AdminRank >= Constants.AdminlvlSupporter)
                {
                    VnXPlayer target = RageApi.GetPlayerFromName(targetName);
                    if (target is null)
                    {
                        foreach (AccountModel accClass in Register.AccountList)
                        {
                            if (accClass.Name.ToLower() == targetName.ToLower())
                            {
                                BanModel banClass = new BanModel
                                {
                                    Uid = accClass.Uid,
                                    Name = accClass.Name,
                                    HardwareId = accClass.HardwareId,
                                    HardwareIdExHash =
                                    accClass.HardwareIdExhash,
                                    DiscordId = "",
                                    Ip = "",
                                    SocialClubId = accClass.SocialId,
                                    BanCreated = DateTime.Now,
                                    BannedTill = DateTime.Now.AddHours(zeit),
                                    BanType = "Timeban"
                                };
                                Admin.PlayerBans.Add(banClass);
                                Database.AddPlayerTimeBan(accClass.Uid, accClass.Name, accClass.HardwareId, accClass.HardwareIdExhash, accClass.SocialId, "", "", grund, player.CharacterUsername, zeit);
                                Logfile.WriteLogs("admin", player.CharacterUsername + " banned " + accClass.Name + " for " + zeit + " Hours! Reason : " + grund);
                                RageApi.SendChatMessageToAll(RageApi.GetHexColorcode(200, 0, 0) + player.CharacterUsername + " banned " + accClass.Name + " for " + zeit + " Hours! Reason : " + grund);
                                return;
                            }
                        }
                    }
                    else
                    {
                        BanModel banClass = new BanModel
                        {
                            Uid = target.CharacterId,
                            Name = target.Name,
                            HardwareId = target.HardwareIdHash.ToString(),
                            HardwareIdExHash = target.HardwareIdExHash.ToString(),
                            DiscordId = target.Discord.Id,
                            Ip = target.Ip,
                            SocialClubId = target.SocialClubId.ToString(),
                            BanCreated = DateTime.Now,
                            BannedTill = DateTime.Now.AddHours(zeit),
                            BanType = "Timeban"
                        };
                        Admin.PlayerBans.Add(banClass);
                        Database.AddPlayerTimeBan(target.CharacterId, target.CharacterUsername, target.HardwareIdHash.ToString(), target.HardwareIdExHash.ToString(), target.SocialClubId.ToString(), target.Ip, target.Discord.Id, grund, player.CharacterUsername, zeit);
                        Logfile.WriteLogs("admin", player.CharacterUsername + " banned " + target.CharacterUsername + " permanently! Reason : " + grund);
                        RageApi.SendChatMessageToAll(RageApi.GetHexColorcode(200, 0, 0) + player.CharacterUsername + " banned " + target.CharacterUsername + " for " + zeit + " Hours! Reason : " + grund);
                        target.Kick(grund);
                        //RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + SpielerName + " wurde von [VnX]" + player.Username + " permanent gebannt! Grund : " + grund);
                    }
                }
                */
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }


    }
}
