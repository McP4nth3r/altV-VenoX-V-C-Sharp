using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using VenoXV.Anti_Cheat;
using VenoXV.Core;
using VenoXV.Reallife.character;
using VenoXV.Reallife.database;
using VenoXV.Reallife.factions;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.model;
using VenoXV.Reallife.Vehicles;
using VenoXV.Reallife.vnx_stored_files;
using VenoXV.Reallife.Woltlab;

namespace VenoXV.Reallife.register_login
{
    public class Login : IScript
    {
        [Command("createtestnotify")]
        public static void CreateTestNotify(IPlayer player, string text)
        {
            dxLibary.VnX.DrawNotification(player, "info", text);
            dxLibary.VnX.DrawNotification(player, "warning", text);
            dxLibary.VnX.DrawNotification(player, "error", text);
        }
        public static string GetCurrentChangelogs()
        {
            return "" +
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
                player.SetVnXName<string>("Random-Player");
                player.vnxSetElementData<object>(EntityData.PLAYER_SEX, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_MONEY, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_BANK, 3500);
                player.vnxSetElementData<object>(EntityData.PLAYER_PLAYING, false);
                // Initialize entity data
                player.vnxSetElementData<object>(EntityData.PLAYER_NAME, string.Empty);
                player.vnxSetElementData<object>(EntityData.PLAYER_SPAWN_POS, new Position(-2286.745f, 356.3762f, 175.317f));
                player.vnxSetElementData<object>(EntityData.PLAYER_SPAWN_ROT, rotation);
                player.vnxSetElementData<object>(EntityData.PLAYER_ADMIN_RANK, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_AGE, 18);
                player.vnxSetElementData<object>(EntityData.PLAYER_HEALTH, 100);
                player.vnxSetElementData<object>(EntityData.PLAYER_ARMOR, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_PHONE, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_KILLED, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_FACTION, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_ZIVIZEIT, DateTime.Now);
                player.vnxSetElementData<object>(EntityData.PLAYER_JOB, "-");
                player.vnxSetElementData<object>(EntityData.PLAYER_VIP_LEVEL, "-");
                player.vnxSetElementData<object>(EntityData.PLAYER_LIEFERJOB_LEVEL, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_BUSJOB_LEVEL, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_AIRPORTJOB_LEVEL, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_RANK, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_ON_DUTY, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_RENT_HOUSE, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_HOUSE_ENTERED, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_BUSINESS_ENTERED, 0);

                player.vnxSetElementData<object>(EntityData.PLAYER_PERSONALAUSWEIS, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_FÜHRERSCHEIN, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_MOTORRAD_FÜHRERSCHEIN, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_LKW_FÜHRERSCHEIN, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_HELIKOPTER_FÜHRERSCHEIN, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_FLUGSCHEIN_A_FÜHRERSCHEIN, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_FLUGSCHEIN_B_FÜHRERSCHEIN, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_MOTORBOOT_FÜHRERSCHEIN, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_ANGEL_FÜHRERSCHEIN, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_WAFFEN_FÜHRERSCHEIN, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_ADVENTSKALENEDER, 0);

                player.vnxSetElementData<object>(EntityData.PLAYER_PLAYED, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_STATUS, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_SPAWNPOINT, "noobspawn");
                player.vnxSetElementData<object>(EntityData.PLAYER_QUESTS, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_FACTION, 0);
                player.vnxSetSharedElementData<object>(EntityData.PLAYER_WANTEDS, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_KNASTZEIT, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_KAUTION, 0);
                player.vnxSetSharedElementData<object>("settings_atm", "ja");
                player.vnxSetSharedElementData<object>("settings_haus", "ja");
                player.vnxSetSharedElementData<object>("settings_tacho", "ja");
                player.vnxSetSharedElementData<object>("settings_quest", "ja");
                player.vnxSetSharedElementData<object>("settings_reporter", "ja");
                player.vnxSetSharedElementData<object>("settings_globalchat", "ja");
                player.vnxSetSharedElementData<object>(EntityData.PLAYER_STATUS, "VenoX");
                player.vnxSetSharedElementData<object>("SocialState_NAMETAG", "VenoX");
                player.vnxSetSharedElementData<object>("HideHUD", 1);
                player.vnxSetSharedElementData<object>(EntityData.PLAYER_HUNGER, 60);
                player.vnxSetElementData<object>(Verleih.HAVE_PLAYER_RENTED_VEHICLE, 0);

                //Tactic 

                player.vnxSetElementData<object>(EntityData.PLAYER_TACTIC_KILLS, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_TACTIC_TODE, 0);

                player.vnxSetElementData<object>(EntityData.PLAYER_REALLIFE_HUD, 0);

                player.vnxSetElementData<object>(EntityData.PLAYER_ZOMBIE_KILLS, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_ZOMBIE_PLAYERS_KILLED, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_ZOMBIE_TODE, 0);

            }
            catch { }
        }

        public static void LoadCharacterData(IPlayer player, PlayerModel character)
        {
            try
            {


                player.vnxSetElementData<object>(EntityData.PLAYER_SEX, character.sex);

                player.vnxSetElementData<object>(EntityData.PLAYER_SQL_ID, character.id);
                player.vnxSetElementData<object>(EntityData.PLAYER_NAME, character.realName);
                player.vnxSetElementData<object>(EntityData.PLAYER_HEALTH, character.health);
                player.vnxSetElementData<object>(EntityData.PLAYER_ARMOR, character.armor);
                player.vnxSetElementData<object>(EntityData.PLAYER_AGE, character.age);
                player.vnxSetElementData<object>(EntityData.PLAYER_SPAWN_POS, character.position);
                player.vnxSetElementData<object>(EntityData.PLAYER_SPAWN_ROT, character.rotation);
                player.vnxSetElementData<object>(EntityData.PLAYER_PHONE, character.phone);
                player.vnxSetElementData<object>(EntityData.PLAYER_KILLED, character.killed);
                player.vnxSetElementData<object>(EntityData.PLAYER_JOB, character.job);
                player.vnxSetElementData<object>(EntityData.PLAYER_LIEFERJOB_LEVEL, character.LIEFERJOB_LEVEL);
                player.vnxSetElementData<object>(EntityData.PLAYER_AIRPORTJOB_LEVEL, character.AIRPORTJOB_LEVEL);
                player.vnxSetElementData<object>(EntityData.PLAYER_BUSJOB_LEVEL, character.BUSJOB_LEVEL);
                player.vnxSetElementData<object>(EntityData.PLAYER_RANK, character.rank);
                player.vnxSetElementData<object>(EntityData.PLAYER_ON_DUTY, 0);
                player.vnxSetElementData<object>(EntityData.PLAYER_RENT_HOUSE, character.houseRent);
                player.vnxSetElementData<object>(EntityData.PLAYER_HOUSE_ENTERED, character.houseEntered);
                player.vnxSetElementData<object>(EntityData.PLAYER_BUSINESS_ENTERED, character.businessEntered);
                player.vnxSetElementData<object>(EntityData.PLAYER_PLAYED, character.played);
                player.vnxSetElementData<object>(EntityData.PLAYER_STATUS, character.status);
                player.vnxSetElementData<object>(EntityData.PLAYER_SPAWNPOINT, character.spawn);
                player.vnxSetElementData<object>(EntityData.PLAYER_ZIVIZEIT, character.zivizeit);
                player.vnxSetElementData<object>(EntityData.PLAYER_QUESTS, character.quests);
                player.vnxSetSharedElementData<object>(EntityData.PLAYER_WANTEDS, character.wanteds);
                player.vnxSetElementData<object>(EntityData.PLAYER_KNASTZEIT, character.knastzeit);
                player.vnxSetElementData<object>(EntityData.PLAYER_KAUTION, character.kaution);
                player.vnxSetElementData<object>(EntityData.PLAYER_ADVENTSKALENEDER, character.adventskalender);


                player.vnxSetElementData<object>(EntityData.PLAYER_PERSONALAUSWEIS, character.Personalausweis);
                player.vnxSetElementData<object>(EntityData.PLAYER_FÜHRERSCHEIN, character.Autofuehrerschein);
                player.vnxSetElementData<object>(EntityData.PLAYER_MOTORRAD_FÜHRERSCHEIN, character.Motorradfuehrerschein);
                player.vnxSetElementData<object>(EntityData.PLAYER_LKW_FÜHRERSCHEIN, character.LKWfuehrerschein);
                player.vnxSetElementData<object>(EntityData.PLAYER_HELIKOPTER_FÜHRERSCHEIN, character.Helikopterfuehrerschein);
                player.vnxSetElementData<object>(EntityData.PLAYER_FLUGSCHEIN_A_FÜHRERSCHEIN, character.FlugscheinKlasseA);
                player.vnxSetElementData<object>(EntityData.PLAYER_FLUGSCHEIN_B_FÜHRERSCHEIN, character.FlugscheinKlasseB);
                player.vnxSetElementData<object>(EntityData.PLAYER_MOTORBOOT_FÜHRERSCHEIN, character.Motorbootschein);
                player.vnxSetElementData<object>(EntityData.PLAYER_ANGEL_FÜHRERSCHEIN, character.Angelschein);
                player.vnxSetElementData<object>(EntityData.PLAYER_WAFFEN_FÜHRERSCHEIN, character.Waffenschein);
                player.vnxSetElementData<object>(EntityData.PLAYER_HANDCUFFED, false);

                player.vnxSetSharedElementData<object>("settings_atm", character.atm);
                player.vnxSetSharedElementData<object>("settings_haus", character.haus);
                player.vnxSetSharedElementData<object>("settings_tacho", character.tacho);
                player.vnxSetSharedElementData<object>("settings_quest", character.quest_anzeigen);
                player.vnxSetSharedElementData<object>("settings_reporter", character.reporter);
                player.vnxSetSharedElementData<object>("settings_globalchat", character.globalchat);
                player.vnxSetSharedElementData<object>(EntityData.PLAYER_STATUS, character.SocialState);
                player.vnxSetSharedElementData<object>("SocialState_NAMETAG", character.SocialState);
                player.vnxSetSharedElementData<object>(EntityData.PLAYER_ADMIN_ON_DUTY, 0);

                player.vnxSetSharedElementData<object>(EntityData.PLAYER_FACTION, character.faction);
                player.vnxSetSharedElementData<object>(EntityData.PLAYER_ADMIN_RANK, character.adminRank);
                player.vnxSetSharedElementData<object>("HideHUD", 1);
                player.vnxSetSharedElementData<object>(EntityData.PLAYER_BANK, character.bank);
                player.vnxSetSharedElementData<object>(EntityData.PLAYER_MONEY, character.money);
                player.vnxSetElementData<object>(Verleih.HAVE_PLAYER_RENTED_VEHICLE, 0);

                player.vnxSetElementData<object>(EntityData.PLAYER_TACTIC_KILLS, character.tactic_kills);
                player.vnxSetElementData<object>(EntityData.PLAYER_TACTIC_TODE, character.tactic_tode);
                player.vnxSetElementData<object>(EntityData.PLAYER_REALLIFE_HUD, character.REALLIFE_HUD);


                player.vnxSetElementData<object>(EntityData.PLAYER_ZOMBIE_KILLS, character.zombie_kills);
                player.vnxSetElementData<object>(EntityData.PLAYER_ZOMBIE_PLAYERS_KILLED, character.zombie_player_kills);
                player.vnxSetElementData<object>(EntityData.PLAYER_ZOMBIE_TODE, character.zombie_tode);
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
            admin.Admin.sendAdminNotification("[" + player.GetVnXName<string>() + " | " + player.SocialClubId.ToString() + "] : Braucht hilfe beim Einloggen! Einer sollte im Teamspeak 3 Warten...");
            logfile.WriteLogs("connect", player.GetVnXName<string>() + " | " + player.SocialClubId.ToString() + " Brauchte hilfe beim Einloggen!");
        }
        private static int GetRandomNumber()
        {
            Random random = new Random();
            int cevent = random.Next(1, 15);
            return cevent;
        }

        [ClientEvent("Load_New_Login_Cam")]
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
            player.vnxSetSharedElementData<object>("HideHUD", 1);
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
            player.vnxSetSharedElementData<object>("HideHUD", 1);
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



        [AltV.Net.ClientEvent("load_data_login")]
        public static void LoadDatasRemote(IPlayer player)
        {
            try
            {
                if (player.vnxGetElementData<bool>(EntityData.PLAYER_PLAYING) == false)
                {
                    if (player.vnxGetElementData<bool>("SPIELER_BAN_ABGELAUFEN") == true)
                    {
                        player.SendChatMessage("~r~Du bist nun Entbannt, verhalte dich in Zukunft besser!");
                        player.SendChatMessage("~r~Du bist nun Entbannt, verhalte dich in Zukunft besser!");
                    }
                    player.SendChatMessage(RageAPI.GetHexColorcode(0, 150, 200) + "_____________________________________");
                    player.SendChatMessage("Willkommen auf VenoX - Reallife.");
                    player.SendChatMessage("Teamspeak 3 : ts3.VenoX-Reallife.com");
                    player.SendChatMessage("Forum : www.VenoX-Reallife.com");
                    player.SendChatMessage("Controlpanel : cp.venox-reallife.com");
                    player.SendChatMessage("Viel Spaß beim Spielen wünscht dir dein VenoX - Reallife Team.");
                    player.SendChatMessage(RageAPI.GetHexColorcode(0, 150, 200) + "_____________________________________");

                    premium.viplevels.VIPLEVELS.SendVIPNotify(player);
                    //ToDo : Fix & find another Way! player.GetVnXName<string>() = player.vnxGetElementData(EntityData.PLAYER_NAME);
                    //player.Rotation = player.vnxGetElementData<int>(EntityData.PLAYER_SPAWN_ROT);
                    //player.Health = player.vnxGetElementData<int>(EntityData.PLAYER_HEALTH);
                    //player.Armor = player.vnxGetElementData<int>(EntityData.PLAYER_ARMOR);
                    player.vnxSetSharedElementData<object>(EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY));
                    player.vnxSetSharedElementData<object>(EntityData.PLAYER_KNASTZEIT, player.vnxGetElementData<int>(EntityData.PLAYER_KNASTZEIT));
                    player.vnxSetSharedElementData<object>("PLAYER_QUESTSPLAYER", player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS));
                    Spawn.spawnplayer_on_spawnpoint(player);
                    Settings.VnX.LoadSettingsData(player);
                    player.vnxSetSharedElementData<object>("HideHUD", 0);
                    anzeigen.Usefull.VnX.UpdateHUD(player);
                    AntiCheat_Allround.StartTimerTeleport(player);
                    Faction.CreateFactionBaseBlip(player);
                    Fun.Aktionen.Shoprob.Shoprob.CreateShopRobPedsIPlayer(player);
                    // Toggle connection flag
                    player.vnxSetElementData<object>(EntityData.PLAYER_PLAYING, true);
                    player.SetSyncedMetaData("PLAYER_LOGGED_IN", true);
                    //ToDo : ZwischenLösung Finden! player.Transparency = 255;
                    Environment.Gzone.Zone.CreateGreenzone(player);
                    gangwar.Allround._gangwarManager.UpdateData(player);
                    CreateGasBlips(player);

                    player.vnxSetSharedElementData<object>(EntityData.PLAYER_HUNGER, 100);
                    //ToDo : ZwischenLösung Finden! player.Transparency = 255;
                }
            }
            catch { }
        }


        public static void LoadDatasAfterLogin(IPlayer player)
        {
            try
            {
                anzeigen.Inventar.Main.OnPlayerConnect(player);
                List<BlipModel> AlleBlips = VenoXV.Globals.Functions.BlipList;

                player.Emit("Reallife:LoadHUD", player.vnxGetElementData<int>(EntityData.PLAYER_REALLIFE_HUD));
                player.Emit("BlipClass:CreateBlip", JsonConvert.SerializeObject(AlleBlips));
                RootCore.Sync.LoadAllTextLabels(player);
                if (player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID) <= 0)
                {
                    return;
                }
                else
                {
                    foreach (IVehicle Vehicle in Alt.GetAllVehicles())
                    {
                        string owner = Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER);
                        if (owner != null && owner == player.GetVnXName<string>())
                        {
                            Vehicle.Dimension = 0;
                            Vehicle.vnxSetSharedElementData<object>(EntityData.VEHICLE_DIMENSION, 0);
                        }
                        // JOB 
                        if (
                        Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_JOB) == Constants.JOB_CITY_TRANSPORT && Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) == player.GetVnXName<string>()
                        || Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_JOB) == Constants.JOB_AIRPORT && Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) == player.GetVnXName<string>()
                        || Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_JOB) == Constants.JOB_BUS && Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) == player.GetVnXName<string>()
                        )
                        {
                            if (Vehicle != null)
                            {
                                AltV.Net.Alt.RemoveVehicle(Vehicle);
                            }
                        }

                        //Test Vehilce Delete
                        if (Vehicle.vnxGetElementData<bool>("TEST_FAHRZEUG") == true && Vehicle.vnxGetElementData<string>(EntityData.VEHICLE_OWNER) == player.GetVnXName<string>())
                        {
                            Vehicle.Remove();
                        }
                    }


                    int playerSqlId = player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID);


                    // Give the weapons to the player
                    Reallife.weapons.Weapons.GivePlayerWeaponItems(player);

                    player.Emit("movecamtocurrentpos_client");

                    if (player.vnxGetElementData<int>(EntityData.PLAYER_KILLED) == 1)
                    {
                        player.Health = 0;
                        Core.VnX.UpdateHUDArmorHealth(player);

                    }
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("LoadDatasAfterLogin", ex); }
        }



        Dictionary<string, IPlayer> playerNames = new Dictionary<string, IPlayer>();


        [ClientEvent("loginAccount")]
        public void LoginAccountEvent(IPlayer player, string username, string password)
        {
            try
            {
                bool login = Database.LoginAccountByName(username, password);
                if (login == true)
                {
                    player.SetVnXName<string>(username);
                    if (username.ToLower() != player.GetVnXName<string>().ToLower())
                    {
                        player.SendChatMessage("Bitte änder in den Alt:V Einstellungen deinen Benutzernamen!");
                        player.Kick("Bitte änder in den Alt:V Einstellungen deinen Benutzernamen!");
                        return;
                    }
                    player.Emit("DestroyLoginWindow");
                    player.Emit("preload_gm_list");
                    Preload.GetAllPlayersInAllGamemodes(player);

                    bool hasDataName = Database.FindAccountByName(username);

                    if (hasDataName)
                    {
                        bool hasCharakter = Database.FindCharacterByUID(Database.GetAccountUIDByName(username));
                        if (hasCharakter)
                        {
                            int player_uid = Database.GetAccountUIDByName(username);
                            if (player_uid < 0)
                            {
                                return;
                            }
                            PlayerModel character = Database.LoadCharacterInformationById(player_uid);
                            SkinModel skinModel = Database.GetCharacterSkin(player_uid);
                            if (character != null && character.realName != null)
                            {
                                player.vnxSetElementData<object>(Globals.EntityData.PLAYER_SKIN_MODEL, skinModel);
                                player.Model = character.sex == 0 ? Alt.Hash("mp_m_freemode_01") : Alt.Hash("mp_f_freemode_01");
                                Login.LoadCharacterData(player, character);
                                player.vnxSetSharedElementData<object>("HideHUD", 1);
                                anzeigen.Usefull.VnX.UpdateHUD(player);
                                Customization.ApplyPlayerClothes(player);
                                Customization.ApplyPlayerCustomization(player, skinModel, character.sex);
                                Customization.ApplyPlayerTattoos(player);

                                foreach (var Tankstellen in Globals.Constants.AUTO_ZAPF_LIST_BLIPS)
                                {
                                    player.Emit("ShowTankstellenBlips", Tankstellen);
                                }
                            }
                            else
                            {
                                admin.Admin.sendAdminNotification(player.GetVnXName<string>() + " | " + player.SocialClubId.ToString() + " hat Probleme beim Einloggen! Schwerwiegender Fehler... Bitte bei Solid_Snake melden !");
                            }
                        }
                        else
                        {
                            player.Emit("LoadReallifeGamemodeRemote");
                            // //ToDo : Fix & find another Way! player.GetVnXName<string>() = Database.GetAccountSpielerName(player.SocialClubId.ToString());
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
                            player.vnxSetElementData<object>(VenoXV.Globals.EntityData.PLAYER_CURRENT_GAMEMODE, VenoXV.Globals.EntityData.GAMEMODE_REALLIFE);
                        }
                        return;
                    }
                    return;

                }
                else
                {
                    player.Emit("showLoginError");
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("ShowLogin", ex); }
        }



        //[AltV.Net.ClientEvent("registerAccount")]
        public void RegisterAccountEvent(IPlayer player, string nickname, string email, string password, string passwordwdh, string geschlecht, bool evalid)
        {
            try
            {
                if (!Database.FindAccount(player.SocialClubId.ToString()) || !Database.FindAccountBySerial(player.HardwareIdHash.ToString()))
                {
                    //Console.WriteLine("shit : " + nickname + email + password + passwordwdh + geschlecht);
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
                    //ToDo : Fix & find another Way! player.GetVnXName<string>() = nickname;
                    Database.RegisterAccount(player.GetVnXName<string>(), player.SocialClubId.ToString(), player.HardwareIdHash.ToString(), email, password, geschlechtalsstring);
                    _ = Program.CreateForumUser(player.GetVnXName<string>(), email, password);
                    player.Emit("clearRegisterWindow_first");
                    player.Emit("showCharacterCreationMenu");
                    player.vnxSetSharedElementData<object>("PLAYER_LOGGED_IN", 1);

                    anzeigen.Usefull.VnX.PutPlayerInRandomDim(player);
                    if (geschlecht == "1") { ChangeCharacterSexEvent(player, 1); }
                    else { ChangeCharacterSexEvent(player, 0); }
                    Database.SetVIPStats(Database.GetAccountUID(player.SocialClubId.ToString()), "Abgelaufen", 0);
                    player.vnxSetElementData<object>(EntityData.PLAYER_VIP_LEVEL, "-");
                    gangwar.Allround._gangwarManager.UpdateData(player);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION RegisterAccountEvent] " + ex.Message);
                Console.WriteLine("[EXCEPTION RegisterAccountEvent] " + ex.StackTrace);
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
                player.vnxSetElementData<object>(EntityData.PLAYER_SEX, sex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION ChangeCharacterSexEvent] " + ex.Message);
                Console.WriteLine("[EXCEPTION ChangeCharacterSexEvent] " + ex.StackTrace);
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
                    player.vnxSetElementData<object>(EntityData.PLAYER_SKIN_MODEL, skinModel);
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
                        player.vnxSetSharedElementData<object>( "HideHUD", 0);
                        player.vnxSetSharedElementData<object>( EntityData.PLAYER_QUESTS, 0);
                        player.vnxSetSharedElementData<object>( "PLAYER_QUESTSPLAYER", 0);
                        anzeigen.Usefull.VnX.UpdateHUD(player);
                        CreateGasBlips(player);
                        AntiCheat_Allround.StartTimerTeleport(player);
                         dxLibary.VnX.SetElementFrozen(player, false);
                        player.vnxSetElementData<object>(EntityData.PLAYER_PLAYING, true);
                        player.Emit("Reallife:LoadHUD", 0);
                    }*/
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION CreateCharacterEvent] " + ex.Message);
                Console.WriteLine("[EXCEPTION CreateCharacterEvent] " + ex.StackTrace);
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
                Console.WriteLine("[EXCEPTION SetCharacterIntoCreatorEvent] " + ex.Message);
                Console.WriteLine("[EXCEPTION SetCharacterIntoCreatorEvent] " + ex.StackTrace);
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
                Console.WriteLine("[EXCEPTION Send_To_Server_Where_Player_From] " + ex.Message);
                Console.WriteLine("[EXCEPTION Send_To_Server_Where_Player_From] " + ex.StackTrace);
            }
        }
    }
}