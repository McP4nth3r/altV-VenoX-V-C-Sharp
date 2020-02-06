using AltV.Net.Elements.Entities;
using AltV.Net;
using VenoXV.Tactics;
using VenoXV.Reallife;
using VenoXV.Reallife.database;
using VenoXV.globals;
using VenoXV.Reallife.register_login;
using VenoXV.Reallife.character;
using VenoXV.Reallife.model;
using VenoXV.Reallife.vnx_stored_files;
using System;
using VenoXV.Reallife.Core;
using AltV.Net.Resources.Chat.Api;

namespace VenoXV.Reallife
{
    namespace My.Package
    {
        internal class MyResource : Resource
        {
            public override void OnStart()
            {
                VenoXV.Globals.Globals.OnResourceStart();
                Console.WriteLine("Started");
            }

            public override void OnStop()
            {
                Console.WriteLine("Stopped");
            }
        }
    }
    public class Preload : IScript
    {

        [ClientEvent("Load_selected_gm_server")]
        public static void Load_selected_gm_server(IPlayer player, int value)
        {
            if(value == 0)
            {
                player.SetData(EntityData.PLAYER_CURRENT_GAMEMODE, EntityData.GAMEMODE_REALLIFE); //Reallife Gamemode Selected
                register_login.Login.OnSelectedReallifeGM(player);
                player.Emit("Player:ChangeCurrentLobby", "Reallife");
            }
            else if(value == 1)
            {
                if (player.vnxGetElementData<int>(Reallife.Globals.EntityData.PLAYER_ADMIN_RANK) >= Reallife.Globals.Constants.ADMINLVL_TSUPPORTER)
                {
                    player.SetData(EntityData.PLAYER_CURRENT_GAMEMODE, EntityData.GAMEMODE_ZOMBIE); //Tactics Gamemode Selected
                    Zombie.World.Main.OnSelectedZombieGM(player);
                    player.Emit("Load_Zombie_GM");
                    player.Emit("Player:ChangeCurrentLobby", "Zombies");
                }
            }
            else if(value == 2)
            {
                player.SetData(EntityData.PLAYER_CURRENT_GAMEMODE, EntityData.GAMEMODE_TACTICS); //Tactics Gamemode Selected
                Tactics.Lobby.Main.OnSelectedTacticsGM(player);
                player.Emit("Player:ChangeCurrentLobby", "Tactics");
            }
        }



        public static void GetAllPlayersInAllGamemodes(IPlayer player)
        {
            try
            {
                int ZombiePlayers = 0;
                int ReallifePlayers = 0;
                int TacticsPlayers = 0;
                foreach (IPlayer players in Alt.GetAllPlayers())
                {
                    if (players.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_GAMEMODE) == EntityData.GAMEMODE_REALLIFE) { ReallifePlayers += 1; }
                    else if (players.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_GAMEMODE) == EntityData.GAMEMODE_TACTICS) { TacticsPlayers += 1; }
                    else if (players.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_GAMEMODE) == EntityData.GAMEMODE_ZOMBIE) { ZombiePlayers += 1; }
                }
                player.Emit("LoadPreloadUserInfo", ZombiePlayers + " Online.", ReallifePlayers + " Online.", TacticsPlayers + " Online.");
            }
            catch { }
        }

        [ScriptEvent(ScriptEventType.PlayerConnect)]
        public void PlayerConnect(IPlayer player, string reason)
        {
            try
            {
                Login.InitializePlayerData(player);
                player.Emit("showLoginWindow", "Willkommen auf VenoX", Login.GetCurrentChangelogs());
                //ShowLogin(player);
                Core.Debug.OutputDebugString("[CONNECTED] : " + player.Name + " | SERIAL : " + player.HardwareIdHash + " | SOCIALCLUB : " + player.SocialClubId + " | IP : " + player.Ip);
                player.SetData(EntityData.PLAYER_CURRENT_GAMEMODE, EntityData.GAMEMODE_NONE); // None Gamemode
                Login.CreateNewLogin_Cam(player, 0, 0);
            }
            catch(Exception ex) { Core.Debug.CatchExceptions("PlayerConnect", ex); }
        }



        public static void ShowLogin(IPlayer player)
        {
            try
            {
                //----------------------------------------------------------------------------------------------------------------------//
                player.Model = Alt.Hash("Strperf01SMM");
                //ToDo : Alpha einstellen.
                Login.InitializePlayerData(player);

                if (Database.FindCharacterBan(player.SocialClubId.ToString()))
                {
                    Core.Debug.OutputDebugString("Found Character Ban");
                    Accountbans ban = Database.GetAccountbans(player.SocialClubId.ToString());
                    if (ban.banzeit > DateTime.Now && ban.Bantype == "Timeban")
                    {
                        player.Emit("LoadReallifeGamemodeRemote");
                        DateTime banzeitdatetime = ban.banzeit;
                        string banzeitalsstring = banzeitdatetime.ToString("dd.MM.yyyy - HH:mm:ss");
                        string baninfotext = "Bei Fragen oder Problemen steht unser Admin Team dir gerne zur Verfügung unter: <br>www.venox-reallife.com <br>ts3.venox-reallife.com";
                        player.Emit("createBanWindow", Database.GetAccountSpielerName(player.SocialClubId.ToString()), banzeitalsstring + " Uhr.", ban.banreason, baninfotext);
                        player.Kick("~r~Grund : ~h~" + ban.banreason);
                        return;
                    }
                    else if (ban.Bantype == "Permaban")
                    {
                        player.Emit("LoadReallifeGamemodeRemote");
                        DateTime banzeitdatetime = ban.banzeit;
                        string banzeitalsstring = "Permanent";
                        string baninfotext = "Bei Fragen oder Problemen steht unser Admin Team dir gerne zur Verfügung unter: <br>www.venox-reallife.com <br>ts3.venox-reallife.com";
                        player.Emit("createBanWindow", Database.GetAccountSpielerName(player.SocialClubId.ToString().ToString()), banzeitalsstring, ban.banreason, baninfotext);
                        player.Kick("~r~Grund : ~h~" + ban.banreason);
                        return;
                    }
                    else
                    {
                        Database.RemoveOldBan(player.SocialClubId.ToString());
                        player.SetData("SPIELER_BAN_ABGELAUFEN", true);
                    }
                }
                else if (Database.FindCharacterBanBySerial(player.HardwareIdHash.ToString()))
                {
                    //----------------------------------------------------------------------------------------------------------------------//
                    Core.Debug.OutputDebugString("Found Character Ban by serial");
                    player.Model = Alt.Hash("Strperf01SMM");
                    Login.InitializePlayerData(player);

                    if (Database.FindCharacterBanBySerial(player.HardwareIdHash.ToString()))
                    {
                        Accountbans ban = Database.GetAccountbansBySerial(player.HardwareIdHash.ToString());
                        if (ban.banzeit > DateTime.Now && ban.Bantype == "Timeban")
                        {
                            DateTime banzeitdatetime = ban.banzeit;
                            string banzeitalsstring = banzeitdatetime.ToString("dd.MM.yyyy - HH:mm:ss");
                            string baninfotext = "Bei Fragen oder Problemen steht unser Admin Team dir gerne zur Verfügung unter: <br>www.venox-reallife.com <br>ts3.venox-reallife.com";
                            player.Emit("createBanWindow", Database.GetAccountSpielerName(player.SocialClubId.ToString().ToString()), banzeitalsstring + " Uhr.", ban.banreason, baninfotext);
                            player.Kick("~r~Grund : ~h~" + ban.banreason);
                            return;
                        }
                        else if (ban.Bantype == "Permaban")
                        {
                            DateTime banzeitdatetime = ban.banzeit;
                            string banzeitalsstring = "Permanent";
                            string baninfotext = "Bei Fragen oder Problemen steht unser Admin Team dir gerne zur Verfügung unter: <br>www.venox-reallife.com <br>ts3.venox-reallife.com";
                            player.Emit("createBanWindow", Database.GetAccountSpielerName(player.SocialClubId.ToString().ToString()), banzeitalsstring, ban.banreason, baninfotext);
                            player.Kick("~r~Grund : ~h~" + ban.banreason);
                            return;
                        }
                        else
                        {
                            Database.RemoveOldBanBySerial(player.HardwareIdHash.ToString());
                            player.SetData("SPIELER_BAN_ABGELAUFEN", true);
                        }
                    }
                }

                bool hasData = Database.FindAccount(player.SocialClubId.ToString().ToString());
                bool hasDataSerial = Database.FindAccountBySerial(player.HardwareIdHash.ToString());

                if (hasDataSerial)
                {
                    Core.Debug.OutputDebugString("charakter has data serial");
                    bool hasCharakter = Database.FindCharacterByUID(Database.GetAccountUIDBySerial(player.HardwareIdHash.ToString()));
                    if (hasCharakter)
                    {
                        Database.SetPlayerSocialClubByUID(Database.GetAccountUIDBySerial(player.HardwareIdHash.ToString()), player.SocialClubId.ToString());
                        logfile.WriteLogs("connect", "[Connect][Login]Social Club Name : " + player.SocialClubId.ToString() + " connected.");
                        int player_uid = Database.GetAccountUIDBySerial(player.HardwareIdHash.ToString());
                        if (player_uid < 0)
                        {
                            return;
                        }
                        PlayerModel character = Database.LoadCharacterInformationById(player_uid);
                        SkinModel skinModel = Database.GetCharacterSkin(player_uid);
                        if (character != null && character.realName != null)
                        {
                            player.SetData(Globals.EntityData.PLAYER_SKIN_MODEL, skinModel);
                            player.Model = character.sex == 0 ? Alt.Hash("FreemodeMale01") : Alt.Hash("FreemodeFemale01");
                            Login.LoadCharacterData(player, character);
                            Core.VnX.vnxSetSharedData(player, "HideHUD", 1);
                            anzeigen.Usefull.VnX.UpdateHUD(player);
                            Customization.ApplyPlayerCustomization(player, skinModel, character.sex);
                            Customization.ApplyPlayerClothes(player);
                            Customization.ApplyPlayerTattoos(player);

                            foreach (var Tankstellen in Globals.Constants.AUTO_ZAPF_LIST_BLIPS)
                            {
                                player.Emit("ShowTankstellenBlips", Tankstellen);
                            }
                            //player.SetData(EntityData.SERVER_TIME, DateTime.Now.ToString("HH:mm:ss"));
                            player.Dimension = 0;
                            player.Emit("FreezePlayerPLAYER_VnX", true);
                            player.Emit("showLoginWindow", "Willkommen zurück " +player.Name, Login.GetCurrentChangelogs());
                            //player.Emit("showLoginWindow", "EVENT MODE ONLINE", GetCurrentChangelogs());
                            Login.CreateNewLogin_Cam(player, 0, 0);
                        }
                        else
                        {
                            admin.Admin.sendAdminNotification(player.Name + " | " + player.SocialClubId.ToString() + " hat Probleme beim Einloggen! Schwerwiegender Fehler... Bitte bei Solid_Snake melden !");
                        }
                    }
                    else
                    {
                        player.Emit("LoadReallifeGamemodeRemote");
                        // //ToDo : Fix & find another Way! player.Name = Database.GetAccountSpielerName(player.SocialClubId.ToString());
                        //player.Transparency = 255;
                        string Geschlecht = Database.GetAccountGeschlecht(player.SocialClubId.ToString());
                        int Geschlecht_ = 0;
                        if (Geschlecht == "Männlich")
                        {
                            Geschlecht_ = 0;
                        }
                        else
                        {
                            Geschlecht_ = 1;
                        }
                        Login.ChangeCharacterSexEvent(player, Geschlecht_);
                        player.Emit("showCharacterCreationMenu");
                        player.SetData(EntityData.PLAYER_CURRENT_GAMEMODE, EntityData.GAMEMODE_REALLIFE);
                    }
                    return;
                }
                //----------------------------------------------------------------------------------------------------------------------//
                else if (hasData)
                {
                    Core.Debug.OutputDebugString("charakter has data socialname");
                    //Falls der Spieler keine Serial in der DB hat weil er vor dem 28.09.2019 - 17:19 sich registriert hat , dann sollte er jetzt eine SERIAL Gesetzt bekommen!.
                    Database.SetPlayerSerial(player.SocialClubId.ToString(), player.HardwareIdHash.ToString());
                    bool hasCharakter = Database.FindCharacterByUID((int)Database.GetAccountUID(player.SocialClubId.ToString()));
                    if (hasCharakter)
                    {
                        logfile.WriteLogs("connect", "[Connect][Login]Social Club Name : " + player.SocialClubId.ToString() + " connected.");
                        int player_uid = Database.GetAccountUID(player.SocialClubId.ToString());
                        if (player_uid < 0)
                        {
                            return;
                        }
                        PlayerModel character = Database.LoadCharacterInformationById(player_uid);
                        SkinModel skinModel = Database.GetCharacterSkin(player_uid);
                        if (character != null && character.realName != null)
                        {
                            //ToDo : Fix & find another Way! player.Name = character.realName;
                            player.SetData(Globals.EntityData.PLAYER_SKIN_MODEL, skinModel);
                            player.Model = character.sex == 0 ? Alt.Hash("FreemodeMale01") : Alt.Hash("FreemodeFemale01");

                            Login.LoadCharacterData(player, character);
                            Core.VnX.vnxSetSharedData(player, "HideHUD", 1);
                            anzeigen.Usefull.VnX.UpdateHUD(player);
                            Customization.ApplyPlayerCustomization(player, skinModel, character.sex);
                            Customization.ApplyPlayerClothes(player);
                            Customization.ApplyPlayerTattoos(player);

                            foreach (var Tankstellen in Globals.Constants.AUTO_ZAPF_LIST_BLIPS)
                            {
                                player.Emit("ShowTankstellenBlips", Tankstellen);
                            }
                            player.Dimension = 0;
                            player.Emit("FreezePlayerPLAYER_VnX", true);
                            player.Emit("showLoginWindow", "Willkommen zurück " +player.Name, Login.GetCurrentChangelogs());
                            //player.Emit("showLoginWindow", "EVENT MODE ONLINE", GetCurrentChangelogs());
                            Login.CreateNewLogin_Cam(player, 0, 0);
                        }
                        else
                        {
                            admin.Admin.sendAdminNotification(player.Name + " | " + player.SocialClubId.ToString() + " hat Probleme beim Einloggen! Schwerwiegender Fehler... Bitte bei Solid_Snake melden !");
                        }
                    }
                    else
                    {
                        player.Emit("LoadReallifeGamemodeRemote");
                        //ToDo : Fix & find another Way! player.Name = Database.GetAccountSpielerName(player.SocialClubId.ToString());
                        //ToDo : ZwischenLösung Finden! player.Transparency = 255;
                        string Geschlecht = Database.GetAccountGeschlecht(player.SocialClubId.ToString());
                        int Geschlecht_ = 0;
                        if (Geschlecht == "Männlich")
                        {
                            Geschlecht_ = 0;
                        }
                        else
                        {
                            Geschlecht_ = 1;
                        }
                        Login.ChangeCharacterSexEvent(player, Geschlecht_);
                        player.Emit("showCharacterCreationMenu");
                        player.SetData(EntityData.PLAYER_CURRENT_GAMEMODE, EntityData.GAMEMODE_REALLIFE);
                    }
                }
                else
                {
                    Core.Debug.OutputDebugString("register event started");
                    player.Emit("LoadReallifeGamemodeRemote");
                    logfile.WriteLogs("connect", "[Connect][Register]Social Club Name : " + player.SocialClubId.ToString() + " connected.");
                    //ToDo : ZwischenLösung Finden! player.Transparency = 0;
                    player.Emit("FreezePlayerPLAYER_VnX", true);
                    player.Emit("showRegisterWindow", "Willkommen auf VenoX");
                    player.Dimension = 0;
                    Login.CreateNewLogin_Cam(player, 0, 0);
                    player.SetData(EntityData.PLAYER_CURRENT_GAMEMODE, EntityData.GAMEMODE_REALLIFE);
                }


                //----------------------------------------------------------------------------------------------------------------------//
                //----------------------------------------------------------------------------------------------------------------------//
                //----------------------------------------------------------------------------------------------------------------------//
                //----------------------------------------------------------------------------------------------------------------------//


            }
            catch { }
        }
    }
}
