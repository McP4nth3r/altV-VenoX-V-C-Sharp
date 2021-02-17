using System;
using System.Linq;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._Preload_;
using VenoXV._Preload_.Model;
using VenoXV._Preload_.Register;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Models;
using EntityData = VenoXV._Globals_.EntityData;
using Main = VenoXV._Language_.Main;
using VnX = VenoXV._Gamemodes_.Reallife.anzeigen.Usefull.VnX;

namespace VenoXV.Commands
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
                player.SendChatMessage(RageApi.GetHexColorcode(255, 255, 255) + "Du hast dich zu " + RageApi.GetHexColorcode(0, 200, 255) + target.Username + " " + RageApi.GetHexColorcode(255, 255, 255) + "teleportiert!");
                target.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + "[VnX]" + player.Username + " " + RageApi.GetHexColorcode(255, 255, 255) + "hat sich zu dir teleportiert!");
                Logfile.WriteLogs("admin", player.Username + " hat sich zu " + target.Username + " geportet!");
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
                    player.SendChatMessage(RageApi.GetHexColorcode(255, 255, 255) + "Du hast " + RageApi.GetHexColorcode(0, 200, 255) + target.Username + " " + RageApi.GetHexColorcode(255, 255, 255) + " zu dir teleportiert!");
                    target.SendChatMessage(RageApi.GetHexColorcode(0, 200, 255) + "[VnX]" + player.Username + " " + RageApi.GetHexColorcode(255, 255, 255) + "hat dich zu ihm teleportiert!");
                    Logfile.WriteLogs("admin", player.Username + " hat " + target.Username + " zu sich geportet!");
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
                                        player.SendTranslatedChatMessage("~g~Du hast das Bankgeld von " + target.Username + " auf : " + value + " gesetzt!");
                                        target.SendTranslatedChatMessage(Constants.RgbaAdminClantag + player.Username + "hat dein Bankgeld auf : " + value + " gesetzt!");
                                        Logfile.WriteLogs("admin", "[ID:" + player.Id + "]" + player.Username + " hat das Bankgeld von " + target.Username + " Auf " + value + " gesetzt!");
                                    }
                                    break;
                                case "money":
                                    if (player.AdminRank > Constants.AdminlvlStellvp)
                                    {
                                        target.Reallife.Money = value;
                                        player.SendTranslatedChatMessage("~g~Du hast das Bargeld von " + target.Username + " auf : " + value + " gesetzt!");
                                        target.SendTranslatedChatMessage(Constants.RgbaAdminClantag + player.Username + " hat dein Bargeld auf : " + value + " gesetzt!");
                                        Logfile.WriteLogs("admin", "[ID:" + player.Id + "]" + player.Username + " hat das Bargeld von " + target.Username + " Auf " + value + " gesetzt!");
                                    }
                                    break;
                                case "dimension":
                                    if (player.AdminRank > Constants.AdminlvlSupporter)
                                    {
                                        target.Dimension = value;
                                        player.SendTranslatedChatMessage("~g~Du hast " + target.Username + " Dimension auf " + value + " gesetzt!");
                                        target.SendTranslatedChatMessage(Constants.RgbaAdminClantag + player.Username + " hat deine Dimension auf :  " + value + " gesetzt!");
                                        Logfile.WriteLogs("admin", "[ID:" + player.Id + "]" + player.Username + " hat " + target.Username + " in die Dimension " + value + " verschoben!");

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
            catch { }
        }

        [Command("getdim")]
        public static void GetAdminDimension(VnXPlayer player, string targetName)
        {
            VnXPlayer target = RageApi.GetPlayerFromName(targetName);
            if (target == null) { return; }
            if (player.AdminRank >= Constants.AdminlvlModerator)
            {
                player.SendTranslatedChatMessage(target.Username + " hat dimension : " + target.Dimension);
            }
        }

        [Command("lobbykick")]
        public static async void KickTargetFromLobby(VnXPlayer player, string targetName)
        {
            VnXPlayer target = RageApi.GetPlayerFromName(targetName);
            if (target == null) return;
            if (player.AdminRank >= Constants.AdminlvlSupporter)
            {
                string translatedText = await Main.GetTranslatedTextAsync((Main.Languages)player.Language, "got kicked by");
                RageApi.SendChatMessageToAll(RageApi.GetHexColorcode(200, 0, 0) + target.Username + " " + translatedText + " " + player.Username);
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
                        player.SendChatMessage("~g~You revived " + target.Username + ".");
                        target.SendChatMessage(Constants.RgbaAdminClantag + player.Username + " revived you.");
                        Logfile.WriteLogs("admin", player.Username + " hat " + target.Username + " wiederbelebt!");
                        VenoX.TriggerClientEvent(target, "destroyKrankenhausTimer");
                        VenoX.TriggerClientEvent(target, "VnX_DestroyIPlayerSideTimer_KH");
                        foreach (VnXPlayer medics in _Globals_.Main.ReallifePlayers.ToList())
                            if (medics.Reallife.Faction == Constants.FactionEmergency)
                                VenoX.TriggerClientEvent(medics, "Destroy_MedicBlips", target.Username);
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
                    bool found = Database.Database.FindCharacterByName(target);
                    if (found)
                    {
                        string socialClubId = Database.Database.GetCharakterSocialName(target);
                        string spielerName = Database.Database.GetAccountSpielerName(socialClubId);
                        VnXPlayer targetplayer = RageApi.GetPlayerFromName(spielerName);
                        int uid = Database.Database.GetCharakterUid(spielerName);
                        if (Database.Database.FindCharakterPrison(spielerName))
                        {
                            int prisonTime = Database.Database.GetCharakterPrisonTime(spielerName);
                            Database.Database.UpdatePlayerPrisonTime(uid, prisonTime + zeit, grund, player.Username, DateTime.Now);
                            Logfile.WriteLogs("admin", "[" + player.SocialClubId + "][" + player.Username + "] hat [" + socialClubId + "][" + target + "] für " + zeit + " Minuten ins Prison gesteckt! Grund : " + grund);
                            RageApi.SendTranslatedChatMessageToAll(RageApi.GetHexColorcode(200, 0, 0) + spielerName + " wurde von [VnX]" + player.Username + " für " + zeit + " Minuten ins Prison gesteckt! Grund : " + grund);
                        }
                        else
                        {
                            Database.Database.AddPlayerToPrison(uid, spielerName, zeit, grund, player.Username, DateTime.Now);
                            Logfile.WriteLogs("admin", "[" + player.SocialClubId + "][" + player.Username + "] hat [" + socialClubId + "][" + target + "] für " + zeit + " Minuten ins Prison gesteckt! Grund : " + grund);
                            RageApi.SendTranslatedChatMessageToAll(RageApi.GetHexColorcode(200, 0, 0) + spielerName + " wurde von [VnX]" + player.Username + " für " + zeit + " Minuten ins Prison gesteckt! Grund : " + grund);
                        }
                        if (targetplayer != null)
                        {
                            //AntiCheat_Allround.SetTimeOutTeleport(targetplayer, 5000);
                            targetplayer.Dimension = _Globals_.Main.ReallifeDimension + targetplayer.Language;
                            targetplayer.SetPosition = new Position(1651.441f, 2569.83f, 45.56486f);
                            VnX.RemoveAllWeapons(targetplayer);
                            targetplayer.VnxSetElementData(EntityData.PlayerPrisonTime, zeit);
                        }
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Es wurde kein Spieler mit dem Namen " + target + " gefunden!");
                    }
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du bist nicht Befugt!");
                }
            }
            catch { }
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
                    Admin.SendAdminInformation(player.Username + " spectatet grade " + target.Username + "!");
                }
            }
            catch { }
        }

        [Command("specoff")]
        public void RecoffCommand(VnXPlayer player)
        {
            if (player.AdminRank > Constants.AdminlvlSupporter)
            {
                //anzeigen.Usefull.VnX.SpectatePlayer(player, player, 1);
                Admin.SendAdminInformation(player.Username + " hat aufgehört " + player.Username + " zu spectaten!");
            }
        }

        [Command("timeban")]
        public void timeban_player(VnXPlayer player, string targetName, int zeit, params string[] grundArray)
        {
            try
            {
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
                                Database.Database.AddPlayerTimeBan(accClass.Uid, accClass.Name, accClass.HardwareId, accClass.HardwareIdExhash, accClass.SocialId, "", "", grund, player.Username, zeit);
                                Logfile.WriteLogs("admin", player.Username + " banned " + accClass.Name + " for " + zeit + " Hours! Reason : " + grund);
                                RageApi.SendChatMessageToAll(RageApi.GetHexColorcode(200, 0, 0) + player.Username + " banned " + accClass.Name + " for " + zeit + " Hours! Reason : " + grund);
                                return;
                            }
                        }
                    }
                    else
                    {
                        BanModel banClass = new BanModel
                        {
                            Uid = target.UID,
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
                        Database.Database.AddPlayerTimeBan(target.UID, target.Username, target.HardwareIdHash.ToString(), target.HardwareIdExHash.ToString(), target.SocialClubId.ToString(), target.Ip, target.Discord.Id, grund, player.Username, zeit);
                        Logfile.WriteLogs("admin", player.Username + " banned " + target.Username + " permanently! Reason : " + grund);
                        RageApi.SendChatMessageToAll(RageApi.GetHexColorcode(200, 0, 0) + player.Username + " banned " + target.Username + " for " + zeit + " Hours! Reason : " + grund);
                        target.Kick(grund);
                        //RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + SpielerName + " wurde von [VnX]" + player.Username + " permanent gebannt! Grund : " + grund);
                    }
                }
            }
            catch { }
        }


    }
}
