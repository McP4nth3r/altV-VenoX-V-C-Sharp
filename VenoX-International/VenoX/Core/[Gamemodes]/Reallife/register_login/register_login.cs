using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;
using VenoX.Core._Admin_;
using VenoX.Core._Gamemodes_.Reallife.environment.Greenzone;
using VenoX.Core._Gamemodes_.Reallife.factions;
using VenoX.Core._Gamemodes_.Reallife.fun.Aktionen.Shoprob;
using VenoX.Core._Gamemodes_.Reallife.globals;
using VenoX.Core._Gamemodes_.Reallife.model;
using VenoX.Core._Gamemodes_.Reallife.premium.viplevels;
using VenoX.Core._Gamemodes_.Reallife.quests;
using VenoX.Core._Globals_;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;
using VenoX.Core._RootCore_.Sync;
using VenoX.Core._RootCore_.vnx_stored_files;
using VenoX.Debug;
using Allround = VenoX.Core._Gamemodes_.Reallife.gangwar.Allround;
using VnX = VenoX.Core._Globals_.Settings.VnX;
using Weapons = VenoX.Core._Gamemodes_.Reallife.weapons.Weapons;

namespace VenoX.Core._Gamemodes_.Reallife.register_login
{
    public class Login : IScript
    {
        public static string GetCurrentChangelogs()
        {
            string changelog = "";
            changelog += "16.05.2022 <br>---------------------------------<br>";
            changelog += " - [Root] : Joining english roleplay lobby was not language-synced with the player [Fixed].<br>";
            changelog += " - [Client] : Fixed multiple bugs.<br>";
            changelog += " - [Root] : reworked on deprecated internal venox voids.<br>";
            changelog += " - [Root] : Reworked on 'makeleader' command.br>";
            changelog += " - [Client] : Updated VenoX-Phone V.1.0.1<br>";
            changelog += " - [Root] : Updated Language API from VenoX + Changed main language to english.\nTranslation's are now much faster than before.<br>";
            return changelog;
        }


        //[AltV.Net.ClientEvent("HelpButtonPressed_Login")]
        public void SendAllAdminsLoginHelpNotify(VnXPlayer player)
        {
            Admin.SendAdminNotification("[" + player.CharacterUsername + " | " + player.SocialClubId + "] : Braucht hilfe beim Einloggen! Einer sollte im Teamspeak 3 Warten...");
            Logfile.WriteLogs("connect", player.CharacterUsername + " | " + player.SocialClubId + " Brauchte hilfe beim Einloggen!");
        }
        private static int GetRandomNumber()
        {
            Random random = new Random();
            int cevent = random.Next(1, 15);
            return cevent;
        }


        [VenoXRemoteEvent("Load_New_Login_Cam")]
        public static void CreateNewLogin_Cam(VnXPlayer player, int number, int newLastNumber)
        {
            try
            {
                int cevent = GetRandomNumber();
                if (number == cevent || newLastNumber == cevent)
                {
                    CreateNewLogin_Cam(player, GetRandomNumber(), newLastNumber);
                    return;
                }
                player.Dimension = _Globals_.Initialize.ReallifeDimension + player.Language;
                //ToDo : ZwischenLösung Finden! player.Transparency = 0;
                Vector3 startPosition = new Vector3();
                Vector3 endPosition = new Vector3();
                int fov = 0;
                int time = 0;
                Vector3 startRotation = new Vector3();
                Vector3 endRotation = new Vector3();
                switch (cevent)
                {
                    case 1:
                        startPosition = new Vector3(411.4904f, -956.7184f, 50);
                        endPosition = new Vector3(420.6378f, -1050.697f, 55);
                        fov = 75;
                        time = 60000;
                        startRotation = new Rotation(320, 0, 180);
                        endRotation = new Rotation(320, 0, 220);
                        break;
                    case 2:
                        startPosition = new Vector3(-2283.365f, 419.0807f, 200);
                        endPosition = new Vector3(-2324.99f, 408.6786f, 200);
                        startRotation = new Rotation(320, 0, 180);
                        endRotation = new Rotation(320, 0, 220);
                        time = 60000;
                        fov = 75;
                        break;
                    case 3:
                        startPosition = new Vector3(-1000.456f, 197.4469f, 66.5f);
                        endPosition = new Vector3(-1039.38f, 200.267f, 62.56097f);
                        startRotation = new Vector3(0, 0, 88);
                        endRotation = new Vector3(0, 0, 88);
                        time = 60000;
                        fov = 75;
                        break;
                    case 4:
                        startPosition = new Vector3(-545.0013f, -950.6284f, 38f);
                        endPosition = new Vector3(-516.2668f, -887.1884f, 42f);
                        startRotation = new Vector3(320, 0, 30);
                        endRotation = new Vector3(320, 0, 100);
                        time = 60000;
                        fov = 75;
                        break;
                    case 5:
                        startPosition = new Vector3(902.6528f, -1068.302f, 48f);
                        endPosition = new Vector3(905.508f, -1020.261f, 50f);
                        startRotation = new Vector3(320, 0, 35);
                        endRotation = new Vector3(320, 0, 100);
                        time = 60000;
                        fov = 75;
                        break;
                    case 6:
                        startPosition = new Vector3(179.6578f, -644.4746f, 60.44452f);
                        endPosition = new Vector3(211.5414f, -657.911f, 60.07743f);
                        startRotation = new Vector3(320, 0, 195);
                        endRotation = new Vector3(320, 0, 108);
                        time = 60000;
                        fov = 75;
                        break;
                    case 7:
                        startPosition = new Vector3(-1532.188f, -59.43741f, 70.07549f);
                        endPosition = new Vector3(-1585.257f, -70.50438f, 70.94582f);
                        startRotation = new Vector3(320, 0, 147);
                        endRotation = new Vector3(320, 0, 220);
                        time = 60000;
                        fov = 75;
                        break;
                    case 8:
                        startPosition = new Vector3(100.4224f, -1905.601f, 40f);
                        endPosition = new Vector3(66.55393f, -1945.313f, 40f);
                        startRotation = new Vector3(320, 0, 200);
                        endRotation = new Vector3(320, 0, 280);
                        time = 60000;
                        fov = 75;
                        break;
                    case 9:
                        startPosition = new Vector3(528.9905f, -192.5913f, 65f);
                        endPosition = new Vector3(520.888f, -165.4624f, 65f);
                        startRotation = new Vector3(320, 0, 320);
                        endRotation = new Vector3(320, 0, 237);
                        time = 60000;
                        fov = 75;
                        break;
                    case 10:
                        startPosition = new Vector3(385.6806f, -541.5113f, 40f);
                        endPosition = new Vector3(339.2675f, -547.7947f, 40f);
                        startRotation = new Vector3(320, 0, 100);
                        endRotation = new Vector3(320, 0, 100);
                        time = 60000;
                        fov = 75;
                        break;
                    case 11:
                        startPosition = new Vector3(258.2238f, -2060.314f, 30f);
                        endPosition = new Vector3(290.6969f, -2113.237f, 30f);
                        startRotation = new Vector3(320, 0, 240);
                        endRotation = new Vector3(320, 0, 0);
                        time = 60000;
                        fov = 75;
                        break;
                    case 12:
                        startPosition = new Vector3(-2159.688f, -1025.8f, 10f);
                        endPosition = new Vector3(-2018.205f, -1115.911f, 10f);
                        startRotation = new Vector3(0, 0, 344);
                        endRotation = new Vector3(0, 0, 326);
                        time = 60000;
                        fov = 75;
                        break;
                    case 13:
                        startPosition = new Vector3(626.6843f, 1159.774f, 330.9638f);
                        endPosition = new Vector3(799.3394f, 1129.184f, 330.9638f);
                        startRotation = new Vector3(0, 0, 290);
                        endRotation = new Vector3(0, 0, 30);
                        time = 60000;
                        fov = 75;
                        break;
                    case 14:
                        startPosition = new Vector3(-81.49934f, -1140.647f, 35f);
                        endPosition = new Vector3(45.82481f, -1135.694f, 35f);
                        startRotation = new Vector3(335, 0, 325);
                        endRotation = new Vector3(335, 0, 48);
                        time = 60000;
                        fov = 75;
                        break;
                    case 15:
                        startPosition = new Vector3(-555.4027f, -268.2709f, 52f);
                        endPosition = new Vector3(-483.5658f, -234.1534f, 52f);
                        startRotation = new Vector3(335, 0, 1);
                        endRotation = new Vector3(335, 0, 58);
                        time = 60000;
                        fov = 75;
                        break;
                }
                _RootCore_.VenoX.TriggerClientEvent(player, "SetCamera_Event_Login", startPosition, endPosition, startRotation, endRotation, fov, time, cevent, newLastNumber);
                player.SetPosition = new Vector3(startPosition.X, startPosition.Y, startPosition.Z - 200);
                player.Freeze = true;
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }


        [Command("createcameraevent")]
        public static void CreateCameraTestEvent(VnXPlayer player, float x, float y, float z, int rotx, int roty, int rotz)
        {
            //AntiCheat_Allround.StopTimerTeleport(player);
            Position lastPosition = player.Position;
            Position startPosition = lastPosition;
            Position endPosition = new Position(x, y, z);

            Rotation startRotation = player.Rotation;
            Rotation endRotation = new Rotation(rotx, roty, rotz);
            int time = 60000;
            int fov = 50;
            _RootCore_.VenoX.TriggerClientEvent(player, "SetCamera_Event_Login", startPosition, endPosition, startRotation, endRotation, fov, time, 0, 1);
            player.SetPosition = lastPosition;
        }


        public static Vector3 Pos1;
        public static Vector3 Pos2;
        [Command("createfullcameraevent")]
        public static void CreateFullCameraTestEvent(VnXPlayer player, float pos1Z, float pos2Z, int rot1X, int rot1Y, int rot1Z, int rot2X, int rot2Y, int rot2Z, int time, int fov)
        {
            if (Pos1 == new Vector3(0, 0, 0))
            {
                Pos1 = new Vector3(player.Position.X, player.Position.Y, pos1Z);
                ConsoleHandling.OutputDebugString("POS 1 CAMERA EVENT CREATED");
                return;
            }

            Vector3 lastPos1 = Pos1;
            Pos1 = new Vector3(lastPos1.X, lastPos1.Y, pos2Z);
            if (Pos2 == new Vector3(0, 0, 0))
            {
                Pos2 = new Vector3(player.Position.X, player.Position.Y, pos2Z);
                ConsoleHandling.OutputDebugString("POS 2 CAMERA EVENT CREATED");
            }
            else
            {
                Vector3 lastPos2 = Pos2;
                Pos2 = new Vector3(lastPos2.X, lastPos2.Y, pos2Z);
            }
            player.VnxSetStreamSharedElementData("HideHUD", 1);
            //AntiCheat_Allround.StopTimerTeleport(player);
            Position lastPosition = player.Position;
            Position startPosition = Pos1;
            Position endPosition = Pos2;

            Rotation startRotation = new Rotation(rot1X, rot1Y, rot1Z);
            Rotation endRotation = new Rotation(rot2X, rot2Y, rot2Z);
            //int Fov = 50;
            _RootCore_.VenoX.TriggerClientEvent(player, "SetCamera_Event_Login", startPosition, endPosition, startRotation, endRotation, fov, time, 0, 1);
            player.SetPosition = lastPosition;
        }

        [Command("resetcamera")]
        public static void ResetCamera(VnXPlayer player)
        {
            Pos1 = new Vector3();
            Pos2 = new Vector3();
            ConsoleHandling.OutputDebugString("CAMERAS RESETTED!!");
        }




        [Command("stopcameraevent")]
        public static void StopCurrentCameraEvent(VnXPlayer player)
        {
            _RootCore_.VenoX.TriggerClientEvent(player, "DestroyCamera_Event");
        }



        [VenoXRemoteEvent("load_data_login")]
        public static void LoadDatasRemote(VnXPlayer player)
        {
            try
            {
                player.SendChatMessage(RageApi.GetHexColorcode(0, 150, 200) + "_____________________________________");
                player.SendTranslatedChatMessage("Welcome to VenoX - International | Roleplay Lobby.");
                player.SendTranslatedChatMessage("Forum : www.venox-international.com");
                player.SendTranslatedChatMessage("Controlpanel : cp.venox-international.com");
                player.SendTranslatedChatMessage("Your VenoX - International team wishes you a lot of fun while playing.");
                player.SendChatMessage(RageApi.GetHexColorcode(0, 150, 200) + "_____________________________________");
                Viplevels.SendVipNotify(player);
                Spawn.SpawnPlayerOnSpawnpoint(player);
                VnX.LoadSettingsData(player);
                Shoprob.CreateShopRobPedsIPlayer(player);
                Zone.CreateGreenzone(player);
                Allround.GangwarManager.UpdateData(player);
                List<ItemModel> inventory = anzeigen.Inventar.Main.GetPlayerInventory(player);
                _RootCore_.VenoX.TriggerClientEvent(player, "Inventory:Update", JsonConvert.SerializeObject(inventory));
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }


        private static void LoadPlayerSpecificDataAfterLogin(VnXPlayer player)
        {
            try
            {
                //player.SetPlayerSkin(player.Sex == 0 ? (uint)AltV.Net.Enums.PedModel.FreemodeMale01 : (uint)AltV.Net.Enums.PedModel.FreemodeFemale01);
                _Preload_.Character_Creator.Main.LoadCharacterSkin(player);
                Customization.ApplyPlayerClothes(player);
                anzeigen.Inventar.Main.OnPlayerConnect(player);
                Sync.LoadBlips(player);
                foreach (VehicleModel vehicle in from vehicle in Initialize.ReallifeVehicles.ToList() let owner = vehicle.Owner where owner != null && owner == player.CharacterUsername select vehicle)
                {
                    vehicle.Dimension = (_Globals_.Initialize.ReallifeDimension + player.Language);
                }
                // Give the weapons to the player
                Weapons.GivePlayerWeaponItems(player);

                _RootCore_.VenoX.TriggerClientEvent(player, "movecamtocurrentpos_client");

                if (player.Dead == 1) player.SetHealth = 0;

            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        public static void OnSelectedReallifeGM(VnXPlayer player)
        {
            try
            {
                foreach (HouseIplModel obj in Constants.HouseIplList)
                    player.LoadIpl(obj.Ipl);

                LoadPlayerSpecificDataAfterLogin(player);
                handy.Allround.UpdatePhonePlayerlist();
                player.Settings.ShowQuests = 1;
                Quests.ShowCurrentQuest(player);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
    }
}