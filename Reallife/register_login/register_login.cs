using AltV.Net.Elements.Entities;
using System;
using VenoXV.Reallife.database;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.model;
using VenoXV.Reallife.vnx_stored_files;
using VenoXV.Reallife.Core;
using VenoXV.Reallife.factions;
using VenoXV.Anti_Cheat;
using VenoXV.Reallife.Woltlab;
using VenoXV.Reallife.Vehicles;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;

namespace VenoXV.Reallife.register_login
{
    public class Login : IScript
    {

        public static string GetCurrentChangelogs()
        {
                return
               "" +
               "10.12.2019 <br>---------------------------------<br>"
               + " - Version 1.1.1 ist nun Online.<br>"
               + " - EVENT MODE wurde entfernt.<br>"
               + " - 225.000$ wurde entfernt.<br>"
               + " - More Infos Cooming Soon...<br>"
               ;
        }

        public static void InitializePlayerData(IPlayer player)
        {
            try
            {
                // Spawn pos 2
                Position rotation = new Position(0.0f, 0.0f, 0.0f);
                player.Position = new Position(152.26f, -1004.47f, -99.00f);
                player.Dimension = player.Id;

                player.Health = 100;
                player.Armor = 0;

                // Clear weapons 
                player.RemoveAllWeapons();

                // Initialize shared entity data
                player.SetData(EntityData.PLAYER_SEX, 0);
                player.SetData(EntityData.PLAYER_MONEY, 0);
                player.SetData(EntityData.PLAYER_BANK, 3500);
                player.SetData(EntityData.PLAYER_PLAYING, false);
                // Initialize entity data
                player.SetData(EntityData.PLAYER_NAME, string.Empty);
                player.SetData(EntityData.PLAYER_SPAWN_POS, new Position(-2286.745f, 356.3762f, 175.317f));
                player.SetData(EntityData.PLAYER_SPAWN_ROT, rotation); 
                player.SetData(EntityData.PLAYER_ADMIN_RANK, 0);
                player.SetData(EntityData.PLAYER_AGE, 18);
                player.SetData(EntityData.PLAYER_HEALTH, 100);
                player.SetData(EntityData.PLAYER_ARMOR, 0);
                player.SetData(EntityData.PLAYER_PHONE, 0);
                player.SetData(EntityData.PLAYER_KILLED, 0);
                player.SetData(EntityData.PLAYER_FACTION, 0);
                player.SetData(EntityData.PLAYER_ZIVIZEIT, DateTime.Now);
                player.SetData(EntityData.PLAYER_JOB, "-");
                player.SetData(EntityData.PLAYER_VIP_LEVEL, "-");
                player.SetData(EntityData.PLAYER_LIEFERJOB_LEVEL, 0);
                player.SetData(EntityData.PLAYER_BUSJOB_LEVEL, 0);
                player.SetData(EntityData.PLAYER_AIRPORTJOB_LEVEL, 0);
                player.SetData(EntityData.PLAYER_RANK, 0);
                player.SetData(EntityData.PLAYER_ON_DUTY, 0);
                player.SetData(EntityData.PLAYER_RENT_HOUSE, 0);
                player.SetData(EntityData.PLAYER_HOUSE_ENTERED, 0);
                player.SetData(EntityData.PLAYER_BUSINESS_ENTERED, 0);

                player.SetData(EntityData.PLAYER_PERSONALAUSWEIS, 0);
                player.SetData(EntityData.PLAYER_FÜHRERSCHEIN, 0);
                player.SetData(EntityData.PLAYER_MOTORRAD_FÜHRERSCHEIN, 0);
                player.SetData(EntityData.PLAYER_LKW_FÜHRERSCHEIN, 0);
                player.SetData(EntityData.PLAYER_HELIKOPTER_FÜHRERSCHEIN, 0);
                player.SetData(EntityData.PLAYER_FLUGSCHEIN_A_FÜHRERSCHEIN, 0);
                player.SetData(EntityData.PLAYER_FLUGSCHEIN_B_FÜHRERSCHEIN, 0);
                player.SetData(EntityData.PLAYER_MOTORBOOT_FÜHRERSCHEIN, 0);
                player.SetData(EntityData.PLAYER_ANGEL_FÜHRERSCHEIN, 0);
                player.SetData(EntityData.PLAYER_WAFFEN_FÜHRERSCHEIN, 0);
                player.SetData(EntityData.PLAYER_ADVENTSKALENEDER, 0);

                player.SetData(EntityData.PLAYER_PLAYED, 0);
                player.SetData(EntityData.PLAYER_STATUS, 0);
                player.SetData(EntityData.PLAYER_SPAWNPOINT, "noobspawn");
                player.SetData(EntityData.PLAYER_QUESTS, 0);
                player.SetData(EntityData.PLAYER_FACTION, 0);
                Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_WANTEDS, 0);
                player.SetData(EntityData.PLAYER_KNASTZEIT, 0);
                player.SetData(EntityData.PLAYER_KAUTION, 0);
                Core.VnX.SetSharedSettingsData(player, "settings_atm", "ja");
                Core.VnX.SetSharedSettingsData(player, "settings_haus", "ja");
                Core.VnX.SetSharedSettingsData(player, "settings_tacho", "ja");
                Core.VnX.SetSharedSettingsData(player, "settings_quest", "ja");
                Core.VnX.SetSharedSettingsData(player, "settings_reporter", "ja");
                Core.VnX.SetSharedSettingsData(player, "settings_globalchat", "ja");
                Core.VnX.SetSharedSettingsData(player, EntityData.PLAYER_STATUS, "VenoX");
                Core.VnX.SetSharedSettingsData(player, "SocialState_NAMETAG", "VenoX");
                Core.VnX.vnxSetSharedData(player, "HideHUD", 1);
                Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_HUNGER, 60);
                player.SetData(Verleih.HAVE_PLAYER_RENTED_VEHICLE, 0);

                //Tactic 

                player.SetData(EntityData.PLAYER_TACTIC_KILLS, 0);
                player.SetData(EntityData.PLAYER_TACTIC_TODE, 0);

                player.SetData(EntityData.PLAYER_REALLIFE_HUD, 0);

                player.SetData(EntityData.PLAYER_ZOMBIE_KILLS, 0);
                player.SetData(EntityData.PLAYER_ZOMBIE_PLAYERS_KILLED, 0);
                player.SetData(EntityData.PLAYER_ZOMBIE_TODE, 0);

            }
            catch { }
        }

        public static void LoadCharacterData(IPlayer player, PlayerModel character)
        {
            try
            {


                player.SetData(EntityData.PLAYER_SEX, character.sex);

                player.SetData(EntityData.PLAYER_SQL_ID, character.id);
                player.SetData(EntityData.PLAYER_NAME, character.realName);
                player.SetData(EntityData.PLAYER_HEALTH, character.health);
                player.SetData(EntityData.PLAYER_ARMOR, character.armor);
                player.SetData(EntityData.PLAYER_AGE, character.age);
                player.SetData(EntityData.PLAYER_SPAWN_POS, character.position);
                player.SetData(EntityData.PLAYER_SPAWN_ROT, character.rotation);
                player.SetData(EntityData.PLAYER_PHONE, character.phone);
                player.SetData(EntityData.PLAYER_KILLED, character.killed);
                player.SetData(EntityData.PLAYER_JOB, character.job);
                player.SetData(EntityData.PLAYER_LIEFERJOB_LEVEL, character.LIEFERJOB_LEVEL);
                player.SetData(EntityData.PLAYER_AIRPORTJOB_LEVEL, character.AIRPORTJOB_LEVEL);
                player.SetData(EntityData.PLAYER_BUSJOB_LEVEL, character.BUSJOB_LEVEL);
                player.SetData(EntityData.PLAYER_RANK, character.rank);
                player.SetData(EntityData.PLAYER_ON_DUTY, 0);
                player.SetData(EntityData.PLAYER_RENT_HOUSE, character.houseRent);
                player.SetData(EntityData.PLAYER_HOUSE_ENTERED, character.houseEntered);
                player.SetData(EntityData.PLAYER_BUSINESS_ENTERED, character.businessEntered);
                player.SetData(EntityData.PLAYER_PLAYED, character.played);
                player.SetData(EntityData.PLAYER_STATUS, character.status);
                player.SetData(EntityData.PLAYER_SPAWNPOINT, character.spawn);
                player.SetData(EntityData.PLAYER_ZIVIZEIT, character.zivizeit);
                player.SetData(EntityData.PLAYER_QUESTS, character.quests);
                Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_WANTEDS, character.wanteds);
                player.SetData(EntityData.PLAYER_KNASTZEIT, character.knastzeit);
                player.SetData(EntityData.PLAYER_KAUTION, character.kaution);
                player.SetData(EntityData.PLAYER_ADVENTSKALENEDER, character.adventskalender);


                player.SetData(EntityData.PLAYER_PERSONALAUSWEIS, character.Personalausweis);
                player.SetData(EntityData.PLAYER_FÜHRERSCHEIN, character.Autofuehrerschein);
                player.SetData(EntityData.PLAYER_MOTORRAD_FÜHRERSCHEIN, character.Motorradfuehrerschein);
                player.SetData(EntityData.PLAYER_LKW_FÜHRERSCHEIN, character.LKWfuehrerschein);
                player.SetData(EntityData.PLAYER_HELIKOPTER_FÜHRERSCHEIN, character.Helikopterfuehrerschein);
                player.SetData(EntityData.PLAYER_FLUGSCHEIN_A_FÜHRERSCHEIN, character.FlugscheinKlasseA);
                player.SetData(EntityData.PLAYER_FLUGSCHEIN_B_FÜHRERSCHEIN, character.FlugscheinKlasseB);
                player.SetData(EntityData.PLAYER_MOTORBOOT_FÜHRERSCHEIN, character.Motorbootschein);
                player.SetData(EntityData.PLAYER_ANGEL_FÜHRERSCHEIN, character.Angelschein);
                player.SetData(EntityData.PLAYER_WAFFEN_FÜHRERSCHEIN, character.Waffenschein);
                player.SetData(EntityData.PLAYER_HANDCUFFED, false);

                Core.VnX.SetSharedSettingsData(player, "settings_atm", character.atm);
                Core.VnX.SetSharedSettingsData(player, "settings_haus", character.haus);
                Core.VnX.SetSharedSettingsData(player, "settings_tacho", character.tacho);
                Core.VnX.SetSharedSettingsData(player, "settings_quest", character.quest_anzeigen);
                Core.VnX.SetSharedSettingsData(player, "settings_reporter", character.reporter);
                Core.VnX.SetSharedSettingsData(player, "settings_globalchat", character.globalchat);
                Core.VnX.SetSharedSettingsData(player, EntityData.PLAYER_STATUS, character.SocialState);
                Core.VnX.SetSharedSettingsData(player, "SocialState_NAMETAG", character.SocialState);
                Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_ADMIN_ON_DUTY, 0);

                Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_FACTION, character.faction);
                Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_ADMIN_RANK, character.adminRank);
                Core.VnX.vnxSetSharedData(player, "HideHUD", 1);
                Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_BANK, character.bank);
                Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_MONEY, character.money);
                player.SetData(Verleih.HAVE_PLAYER_RENTED_VEHICLE, 0);

                player.SetData(EntityData.PLAYER_TACTIC_KILLS, character.tactic_kills);
                player.SetData(EntityData.PLAYER_TACTIC_TODE, character.tactic_tode);
                player.SetData(EntityData.PLAYER_REALLIFE_HUD, character.REALLIFE_HUD);


                player.SetData(EntityData.PLAYER_ZOMBIE_KILLS, character.zombie_kills);
                player.SetData(EntityData.PLAYER_ZOMBIE_PLAYERS_KILLED, character.zombie_player_kills);
                player.SetData(EntityData.PLAYER_ZOMBIE_TODE, character.zombie_tode);
            }
            catch { }
        }


        /*
        public bool isBetaPlayer(IPlayer player)
        {
            if (
                player.SocialClubId.ToString() == "Vegeta16992"
                || player.SocialClubId.ToString() == "LargePeach"
                || player.SocialClubId.ToString() == "SxyJessie"
                || player.SocialClubId.ToString() == "_Energetic_"

                )
            { 
                return true;
            }
            return false;
        }*/
        

        public static void OnSelectedReallifeGM(IPlayer player)
        {
            try
            {
                LoadDatasAfterLogin(player);
            }
            catch { }
        }


        //[AltV.Net.ClientEvent("HelpButtonPressed_Login")]
        public void SendAllAdminsLoginHelpNotify(IPlayer player)
        {
            admin.Admin.sendAdminNotification("[" +player.Name + " | " + player.SocialClubId.ToString() + "] : Braucht hilfe beim Einloggen! Einer sollte im Teamspeak 3 Warten...");
            logfile.WriteLogs("connect",player.Name + " | " + player.SocialClubId.ToString() + " Brauchte hilfe beim Einloggen!");
        }
        private static int GetRandomNumber()
        {
            Random random = new Random();
            int cevent = random.Next(1, 15);
            return cevent;
        }

        //[AltV.Net.ClientEvent("Load_New_Login_Cam")]
        public static void CreateNewLogin_Cam(IPlayer player, int number, int new_lastNumber)
        {
            try
            {
                int cevent = GetRandomNumber();
                if (number == cevent || new_lastNumber == cevent)
                {
                    CreateNewLogin_Cam(player, GetRandomNumber(), new_lastNumber);
                    return;
                }
                player.Dimension = 0;
                //ToDo : ZwischenLösung Finden! player.Transparency = 0;
                player.Emit("FreezePlayerPLAYER_VnX", true);

                if (cevent == 1)
                {
                    Position StartPosition = new Position(411.4904f, -956.7184f, 50);
                    Position EndPosition = new Position(420.6378f, -1050.697f, 55);
                    int Fov = 50;
                    int time = 60000;
                    Rotation StartRotation = new Rotation(320, 0, 180);
                    Rotation EndRotation = new Rotation(320, 0, 220);
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.Position = new Position(411.4904f, -956.7184f, 20);
                }
                else if (cevent == 2)
                {
                    Position StartPosition = new Position(-2283.365f, 419.0807f, 200);
                    Position EndPosition = new Position(-2324.99f, 408.6786f, 200);

                    Rotation StartRotation = new Rotation(320, 0, 180);
                    Rotation EndRotation = new Rotation(320, 0, 220);
                    int time = 60000;
                    int Fov = 50;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.Position = new Position(-2295.875f, 377.0148f, 230);
                }
                else if (cevent == 3)
                {
                    Position StartPosition = new Position(-1000.456f, 197.4469f, 66.5f);
                    Position EndPosition = new Position(-1039.38f, 200.267f, 62.56097f);

                    Position StartRotation = new Position(0, 0, 88);
                    Position EndRotation = new Position(0, 0, 88);
                    int time = 60000;
                    int Fov = 50;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.Position = new Position(-1043.623f, 193.3604f, 60f);
                }
                else if (cevent == 4)
                {
                    Position StartPosition = new Position(-545.0013f, -950.6284f, 38f);
                    Position EndPosition = new Position(-516.2668f, -887.1884f, 42f);

                    Position StartRotation = new Position(320, 0, 30);
                    Position EndRotation = new Position(320, 0, 100);
                    int time = 60000;
                    int Fov = 50;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.Position = new Position(-545.0013f, -950.6284f, 20f);
                }
                else if (cevent == 5)
                {
                    Position StartPosition = new Position(902.6528f, -1068.302f, 48f);
                    Position EndPosition = new Position(905.508f, -1020.261f, 50f);

                    Position StartRotation = new Position(320, 0, 35);
                    Position EndRotation = new Position(320, 0, 100);
                    int time = 60000;
                    int Fov = 50;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.Position = new Position(902.6528f, -1068.302f, 38f);
                }
                else if (cevent == 6)
                {
                    Position StartPosition = new Position(179.6578f, -644.4746f, 60.44452f);
                    Position EndPosition = new Position(211.5414f, -657.911f, 60.07743f);

                    Position StartRotation = new Position(320, 0, 195);
                    Position EndRotation = new Position(320, 0, 108);
                    int time = 60000;
                    int Fov = 50;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.Position = new Position(170.3055f, -671.4557f, 60.14089f);
                }
                else if (cevent == 7)
                {
                    Position StartPosition = new Position(-1532.188f, -59.43741f, 70.07549f);
                    Position EndPosition = new Position(-1585.257f, -70.50438f, 70.94582f);

                    Position StartRotation = new Position(320, 0, 147);
                    Position EndRotation = new Position(320, 0, 220);
                    int time = 60000;
                    int Fov = 50;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.Position = new Position(-1532.188f, -59.43741f, 70.07549f);
                }
                else if (cevent == 8)
                {
                    Position StartPosition = new Position(100.4224f, -1905.601f, 40f);
                    Position EndPosition = new Position(66.55393f, -1945.313f, 40f);

                    Position StartRotation = new Position(320, 0, 200);
                    Position EndRotation = new Position(320, 0, 280);
                    int time = 60000;
                    int Fov = 50;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.Position = new Position(66.55393f, -1945.313f, 50.94582f);
                }
                else if (cevent == 9)
                {
                    Position StartPosition = new Position(528.9905f, -192.5913f, 65f);
                    Position EndPosition = new Position(520.888f, -165.4624f, 65f);

                    Position StartRotation = new Position(320, 0, 320);
                    Position EndRotation = new Position(320, 0, 237);
                    int time = 60000;
                    int Fov = 50;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.Position = new Position(528.9905f, -192.5913f, 62f);
                }
                else if (cevent == 10)
                {
                    Position StartPosition = new Position(385.6806f, -541.5113f, 40f);
                    Position EndPosition = new Position(339.2675f, -547.7947f, 40f);

                    Position StartRotation = new Position(320, 0, 100);
                    Position EndRotation = new Position(320, 0, 100);
                    int time = 60000;
                    int Fov = 50;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.Position = new Position(339.2675f, -547.7947f, 20f);
                }
                else if (cevent == 11)
                {
                    Position StartPosition = new Position(258.2238f, -2060.314f, 30f);
                    Position EndPosition = new Position(290.6969f, -2113.237f, 30f);

                    Position StartRotation = new Position(320, 0, 240);
                    Position EndRotation = new Position(320, 0, 0);
                    int time = 60000;
                    int Fov = 50;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.Position = new Position(258.2238f, -2060.314f, 10f);
                }
                else if (cevent == 12)
                {
                    Position StartPosition = new Position(-2159.688f, -1025.8f, 10f);
                    Position EndPosition = new Position(-2018.205f, -1115.911f, 10f);

                    Position StartRotation = new Position(0, 0, 344);
                    Position EndRotation = new Position(0, 0, 326);
                    int time = 60000;
                    int Fov = 50;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.Position = new Position(-2018.205f, -1115.911f, 20f);
                }
                else if (cevent == 13)
                {
                    Position StartPosition = new Position(626.6843f, 1159.774f, 330.9638f);
                    Position EndPosition = new Position(799.3394f, 1129.184f, 330.9638f);

                    Position StartRotation = new Position(0, 0, 290);
                    Position EndRotation = new Position(0, 0, 30);
                    int time = 60000;
                    int Fov = 50;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.Position = new Position(626.6843f, 1159.774f, 278.9638f);
                }
                else if (cevent == 14)
                {
                    Position StartPosition = new Position(-81.49934f, -1140.647f, 35f);
                    Position EndPosition = new Position(45.82481f, -1135.694f, 35f);

                    Position StartRotation = new Position(335, 0, 325);
                    Position EndRotation = new Position(335, 0, 48);
                    int time = 60000;
                    int Fov = 50;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.Position = new Position(45.82481f, -1135.694f, 15f);
                }
                else if (cevent == 15)
                {
                    Position StartPosition = new Position(-555.4027f, -268.2709f, 52f);
                    Position EndPosition = new Position(-483.5658f, -234.1534f, 52f);

                    Position StartRotation = new Position(335, 0, 1);
                    Position EndRotation = new Position(335, 0, 58);
                    int time = 60000;
                    int Fov = 50;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.Position = new Position(-555.4027f, -268.2709f, 30f);
                }
            }
            catch { }
        }

        [Command("createcameraevent")]
        public static void CreateCameraTestEvent(IPlayer player, float x, float y, float z, int rotx, int roty, int rotz)
        {
            Core.VnX.vnxSetSharedData(player, "HideHUD", 1);
            AntiCheat_Allround.StopTimerTeleport(player);
            Position LastPosition = player.Position;
            Position StartPosition = LastPosition;
            Position EndPosition = new Position(x, y, z);

            Rotation StartRotation = player.Rotation;
            Rotation EndRotation = new Rotation(rotx, roty, rotz);
            int time = 60000;
            int Fov = 50;
            player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, 0, 1);
            player.Position = LastPosition;
        }

        [Command("createfullcameraevent")]
        public static void CreateFullCameraTestEvent(IPlayer player, float startx, float starty, float startz, float endx, float endy, float endz, int rotx, int roty, int rotz)
        {
            Core.VnX.vnxSetSharedData(player, "HideHUD", 1);
            AntiCheat_Allround.StopTimerTeleport(player);
            Position LastPosition = player.Position;
            Position StartPosition = new Position(startx, starty, startz);
            Position EndPosition = new Position(endx, endy, endz);

            Rotation StartRotation = player.Rotation;
            Rotation EndRotation = new Rotation(rotx, roty, rotz);
            int time = 60000;
            int Fov = 50;
            player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, 0, 1);
            player.Position = LastPosition;
        }


        [Command("stopcameraevent")]
        public static void StopCurrentCameraEvent(IPlayer player)
        {
            player.Emit("DestroyCamera_Event");
        }



        //[AltV.Net.ClientEvent("load_data_login")]
        public static void LoadDatasRemote(IPlayer player)
        {
            try
            {
                if (player.vnxGetElementData<bool>(EntityData.PLAYER_PLAYING) == false)
                {
                    if (player.vnxGetElementData<bool>("SPIELER_BAN_ABGELAUFEN") == true)
                    {
                        player.SendChatMessage( "~r~Du bist nun Entbannt, verhalte dich in Zukunft besser!");
                        player.SendChatMessage( "~r~Du bist nun Entbannt, verhalte dich in Zukunft besser!");
                    }
                    player.SendChatMessage( "!{0,150,200}_____________________________________");
                    player.SendChatMessage( "Willkommen auf VenoX - Reallife.");
                    player.SendChatMessage( "Teamspeak 3 : ts3.VenoX-Reallife.com");
                    player.SendChatMessage( "Forum : www.VenoX-Reallife.com");
                    player.SendChatMessage( "Controlpanel : cp.venox-reallife.com");
                    player.SendChatMessage( "Viel Spaß beim Spielen wünscht dir dein VenoX - Reallife Team.");
                    player.SendChatMessage( "!{0,150,200}_____________________________________");

                    premium.viplevels.VIPLEVELS.SendVIPNotify(player);
                    //ToDo : Fix & find another Way! player.Name = player.vnxGetElementData(EntityData.PLAYER_NAME);
                    //player.Rotation = player.vnxGetElementData<int>(EntityData.PLAYER_SPAWN_ROT);
                    //player.Health = player.vnxGetElementData<int>(EntityData.PLAYER_HEALTH);
                    //player.Armor = player.vnxGetElementData<int>(EntityData.PLAYER_ARMOR);
                    Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY));
                    Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_KNASTZEIT, player.vnxGetElementData<int>(EntityData.PLAYER_KNASTZEIT));
                    Core.VnX.vnxSetSharedData(player, "PLAYER_QUESTSPLAYER", player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS));
                    Spawn.spawnplayer_on_spawnpoint(player);
                    Settings.VnX.LoadSettingsData(player);
                    Core.VnX.vnxSetSharedData(player, "HideHUD", 0);
                    anzeigen.Usefull.VnX.UpdateHUD(player);
                    AntiCheat_Allround.StartTimerTeleport(player);
                    Faction.CreateFactionBaseBlip(player);
                    Fun.Aktionen.Shoprob.Shoprob.CreateShopRobPedsIPlayer(player);
                    // Toggle connection flag
                    player.SetData(EntityData.PLAYER_PLAYING, true);
                    player.SetSyncedMetaData("PLAYER_LOGGED_IN", true);
                    //ToDo : ZwischenLösung Finden! player.Transparency = 255;
                    Environment.Gzone.Zone.CreateGreenzone(player);
                    gangwar.Allround._gangwarManager.UpdateData(player);
                    CreateGasBlips(player);
                    player.SetData("EXECUTED_GW_AREAS", true);

                    Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_HUNGER, 100);
                    //ToDo : ZwischenLösung Finden! player.Transparency = 255;
                }
            }
            catch { }
        }


        public static void LoadDatasAfterLogin(IPlayer player)
        {
            try
            {
                player.Emit("Reallife:LoadHUD", player.vnxGetElementData<int>(EntityData.PLAYER_REALLIFE_HUD));
                // Player must have a character selected
                if (player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID) <= 0)
                {
                    return;
                }
                else
                {
                    foreach (IVehicle Vehicle in Alt.GetAllVehicles())
                    {

                        string owner = Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER);
                        if (owner != null && owner ==player.Name)
                        {
                            Vehicle.Dimension = 0;
                            Core.VnX.IVehiclevnxSetSharedData(Vehicle,EntityData.VEHICLE_DIMENSION, 0);
                        }
                        // JOB 
                        if (
                        Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_JOB) == Constants.JOB_CITY_TRANSPORT && Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) ==player.Name
                        || Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_JOB) == Constants.JOB_AIRPORT && Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) ==player.Name
                        || Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_JOB) == Constants.JOB_BUS && Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) ==player.Name
                        )
                        {
                            if (Vehicle != null)
                            {
                                AltV.Net.Alt.RemoveVehicle(Vehicle);
                            }
                        }

                        //Test Vehilce Delete
                        if (Vehicle.vnxGetElementData<bool>("TEST_FAHRZEUG") == true && Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) ==player.Name)
                        {
                            Vehicle.Remove();
                        }
                    }


                    int playerSqlId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);


                    // Give the weapons to the player
                    Reallife.weapons.Weapons.GivePlayerWeaponItems(player);

                    player.Emit("movecamtocurrentposPLAYER");

                    if (player.vnxGetElementData<int>(EntityData.PLAYER_KILLED) == 1)
                    {
                        player.Health = 0;
                        Core.VnX.UpdateHUDArmorHealth(player);
                        
                    }
                }
            }
            catch { }
        }



       

        //[AltV.Net.ClientEvent("loginAccount")]
        public void LoginAccountEvent(IPlayer player, string password)
        {
            try
            {
                bool login = Database.LoginAccount(player.SocialClubId.ToString(), password);
                if (login == true)
                {
                    player.Emit("clearLoginWindow", 1);
                    player.Emit("preload_gm_list");
                    Preload.GetAllPlayersInAllGamemodes(player);
                    return;
                }
                else
                {
                    if (Database.LoginAccountBySerial(player.HardwareIdHash.ToString(), password) == true)
                    {
                        player.Emit("clearLoginWindow", 1);
                        player.Emit("preload_gm_list");
                        Preload.GetAllPlayersInAllGamemodes(player);
                        return;
                    }
                    else
                    {
                        player.Emit("showLoginError");
                    }
                }
            }
            catch { }
        }



        //[AltV.Net.ClientEvent("registerAccount")]
        public void RegisterAccountEvent(IPlayer player, string nickname, string email, string password, string passwordwdh, string geschlecht, bool evalid)
        {
            try
            {
                if (!Database.FindAccount(player.SocialClubId.ToString()) || !Database.FindAccountBySerial(player.HardwareIdHash.ToString()))
                {
                    //Alt.Log("shit : " + nickname + email + password + passwordwdh + geschlecht);
                    if (nickname.Length < 1 || email.Length < 1 || password.Length < 1 || passwordwdh.Length < 1 || geschlecht == null)
                    {
                        return;
                    }
                    bool hasData = Database.FindCharacterName(nickname);
                    if (hasData)
                    {
                        player.Emit("show_register_error", "1", "Nickname ist bereits vergeben!");
                        return;
                    }
                    if (password != passwordwdh)
                    {
                        player.Emit("show_register_error", "1", "Passwörter sind nicht identisch!");
                        return;
                    }
                    if (evalid == false)
                    {
                        player.Emit("show_register_error", "1", "Ungültige E-Mail!");
                    }
                    string geschlechtalsstring = "Männlich";
                    if (geschlecht == "1")
                    {
                        geschlechtalsstring = "Weiblich";
                    }
                    //ToDo : Fix & find another Way! player.Name = nickname;
                    Database.RegisterAccount(player.Name, player.SocialClubId.ToString(), player.HardwareIdHash.ToString(), email, password, geschlechtalsstring);
                    _ = Program.CreateForumUser(player.Name, email, password);
                    player.Emit("clearRegisterWindow_first");
                    player.Emit("showCharacterCreationMenu");
                    Core.VnX.vnxSetSharedData(player, "PLAYER_LOGGED_IN", 1);
                    
                    anzeigen.Usefull.VnX.PutPlayerInRandomDim(player);
                    if (geschlecht == "1") { ChangeCharacterSexEvent(player, 1); }
                    else { ChangeCharacterSexEvent(player, 0); }
                    Database.SetVIPStats(Database.GetAccountUID(player.SocialClubId.ToString()), "Abgelaufen", 0);
                    player.SetData(EntityData.PLAYER_VIP_LEVEL, "-");
                    gangwar.Allround._gangwarManager.UpdateData(player);
                }
            }
            catch (Exception ex)
            {
                Alt.Log("[EXCEPTION RegisterAccountEvent] " + ex.Message);
                Alt.Log("[EXCEPTION RegisterAccountEvent] " + ex.StackTrace);
            }
        }


        //[AltV.Net.ClientEvent("changeCharacterSex")]
        public static void ChangeCharacterSexEvent(IPlayer player, int sex)
        {
            try
            {
                // Set the model of the player
                //NAPI.Player.SetPlayerSkin(player, sex == 0 ? PedHash.FreemodeMale01 : PedHash.FreemodeFemale01);
                // Remove player's clothes
                //ToDo Sie Clientseitig Laden! : player.SetClothes(11, 15, 0);
                //ToDo Sie Clientseitig Laden! : player.SetClothes(3, 15, 0);
                //ToDo Sie Clientseitig Laden! : player.SetClothes(8, 15, 0);

                // Save sex entity shared data
                player.SetData(EntityData.PLAYER_SEX, sex);
            }
            catch (Exception ex)
            {
                Alt.Log("[EXCEPTION ChangeCharacterSexEvent] " + ex.Message);
                Alt.Log("[EXCEPTION ChangeCharacterSexEvent] " + ex.StackTrace);
            }
        }

        public static void CreateGasBlips(IPlayer player)
        {
            foreach (var Tankstellen in Constants.AUTO_ZAPF_LIST_BLIPS)
            {
                player.Emit("ShowTankstellenBlips", Tankstellen);
            }
        }

        //[AltV.Net.ClientEvent("createCharacter")]
        public void CreateCharacterEvent(IPlayer player, string skinJson)
        {
            try
            {
                bool hasCharakter = Database.FindCharacter(player.SocialClubId.ToString());
                if (!hasCharakter)
                {
                    /*SkinModel skinModel = NAPI.Util.FromJson<SkinModel>(skinJson);
                    
                    // Apply the skin to the character
                    player.SetData(EntityData.PLAYER_SKIN_MODEL, skinModel);
                    Customization.ApplyPlayerCustomization(player, skinModel, player.vnxGetElementData<int>(EntityData.PLAYER_SEX));
                    int UID = Database.GetAccountUID(player.SocialClubId.ToString());
                    int playerId = Database.CreateCharacter(player, UID, skinModel);

                    if (playerId > 0)
                    {

                        PlayerModel character = Database.LoadCharacterInformationById(playerId);
                        LoadCharacterData(player, character);

                        player.Dimension = 0;
                        player.Emit("characterCreatedSuccessfully");
                        Spawn.spawnplayer_on_spawnpoint(player);
                        Settings.VnX.LoadSettingsData(player);
                        Core.VnX.vnxSetSharedData(player, "HideHUD", 0);
                        Core.VnX.vnxSetSharedData(player, EntityData.PLAYER_QUESTS, 0);
                        Core.VnX.vnxSetSharedData(player, "PLAYER_QUESTSPLAYER", 0);
                        anzeigen.Usefull.VnX.UpdateHUD(player);
                        CreateGasBlips(player);
                        AntiCheat_Allround.StartTimerTeleport(player);
                         dxLibary.VnX.SetElementFrozen(player, false);
                        player.SetData(EntityData.PLAYER_PLAYING, true);
                        player.Emit("Reallife:LoadHUD", 0);
                    }*/
                }
            }
            catch (Exception ex)
            {
                Alt.Log("[EXCEPTION CreateCharacterEvent] " + ex.Message);
                Alt.Log("[EXCEPTION CreateCharacterEvent] " + ex.StackTrace);
            }
        }

        //[AltV.Net.ClientEvent("setCharacterIntoCreator")]
        public void SetCharacterIntoCreatorEvent(IPlayer player)
        {
            try
            {
                // Set player's position
                //ToDo : ZwischenLösung Finden! player.Transparency = 255;
                player.Rotation = new Rotation(0.0f, 0.0f, 180.0f);
                player.Position = new Position(152.3787f, -1000.644f, -99f);
            }
            catch (Exception ex)
            {
                Alt.Log("[EXCEPTION SetCharacterIntoCreatorEvent] " + ex.Message);
                Alt.Log("[EXCEPTION SetCharacterIntoCreatorEvent] " + ex.StackTrace);
            }
        }

        //[AltV.Net.ClientEvent("Send_Player_Where_From")]
        public void Send_To_Server_Where_Player_From(IPlayer player, string Where)
        {
            try
            {
                int howmuchp = Database.GetPlayerWhereFromList(Where);
                Database.SetPlayerWhereFromList(Where, howmuchp + 1);
            }
            catch (Exception ex)
            {
                Alt.Log("[EXCEPTION Send_To_Server_Where_Player_From] " + ex.Message);
                Alt.Log("[EXCEPTION Send_To_Server_Where_Player_From] " + ex.StackTrace);
            }
        }
    }
}