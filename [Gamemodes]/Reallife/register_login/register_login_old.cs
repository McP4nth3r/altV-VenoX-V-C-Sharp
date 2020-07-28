using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.Factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV._RootCore_.Sync;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.register_login
{
    public class Login : IScript
    {
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

        //[AltV.Net.ClientEvent("HelpButtonPressed_Login")]
        public void SendAllAdminsLoginHelpNotify(Client player)
        {
            admin.Admin.sendAdminNotification("[" + player.Username + " | " + player.SocialClubId.ToString() + "] : Braucht hilfe beim Einloggen! Einer sollte im Teamspeak 3 Warten...");
            logfile.WriteLogs("connect", player.Username + " | " + player.SocialClubId.ToString() + " Brauchte hilfe beim Einloggen!");
        }
        private static int GetRandomNumber()
        {
            Random random = new Random();
            int cevent = random.Next(1, 15);
            return cevent;
        }


        [ClientEvent("Load_New_Login_Cam")]
        public static void CreateNewLogin_Cam(Client player, int number, int new_lastNumber)
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
                Vector3 StartPosition = new Vector3();
                Vector3 EndPosition = new Vector3();
                int Fov = 0;
                int time = 0;
                Vector3 StartRotation = new Vector3();
                Vector3 EndRotation = new Vector3();
                switch (cevent)
                {
                    case 1:
                        StartPosition = new Vector3(411.4904f, -956.7184f, 50);
                        EndPosition = new Vector3(420.6378f, -1050.697f, 55);
                        Fov = 75;
                        time = 60000;
                        StartRotation = new Rotation(320, 0, 180);
                        EndRotation = new Rotation(320, 0, 220);
                        break;
                    case 2:
                        StartPosition = new Vector3(-2283.365f, 419.0807f, 200);
                        EndPosition = new Vector3(-2324.99f, 408.6786f, 200);
                        StartRotation = new Rotation(320, 0, 180);
                        EndRotation = new Rotation(320, 0, 220);
                        time = 60000;
                        Fov = 75;
                        break;
                    case 3:
                        StartPosition = new Vector3(-1000.456f, 197.4469f, 66.5f);
                        EndPosition = new Vector3(-1039.38f, 200.267f, 62.56097f);
                        StartRotation = new Vector3(0, 0, 88);
                        EndRotation = new Vector3(0, 0, 88);
                        time = 60000;
                        Fov = 75;
                        break;
                    case 4:
                        StartPosition = new Vector3(-545.0013f, -950.6284f, 38f);
                        EndPosition = new Vector3(-516.2668f, -887.1884f, 42f);
                        StartRotation = new Vector3(320, 0, 30);
                        EndRotation = new Vector3(320, 0, 100);
                        time = 60000;
                        Fov = 75;
                        break;
                    case 5:
                        StartPosition = new Vector3(902.6528f, -1068.302f, 48f);
                        EndPosition = new Vector3(905.508f, -1020.261f, 50f);
                        StartRotation = new Vector3(320, 0, 35);
                        EndRotation = new Vector3(320, 0, 100);
                        time = 60000;
                        Fov = 75;
                        break;
                    case 6:
                        StartPosition = new Vector3(179.6578f, -644.4746f, 60.44452f);
                        EndPosition = new Vector3(211.5414f, -657.911f, 60.07743f);
                        StartRotation = new Vector3(320, 0, 195);
                        EndRotation = new Vector3(320, 0, 108);
                        time = 60000;
                        Fov = 75;
                        break;
                    case 7:
                        StartPosition = new Vector3(-1532.188f, -59.43741f, 70.07549f);
                        EndPosition = new Vector3(-1585.257f, -70.50438f, 70.94582f);
                        StartRotation = new Vector3(320, 0, 147);
                        EndRotation = new Vector3(320, 0, 220);
                        time = 60000;
                        Fov = 75;
                        break;
                    case 8:
                        StartPosition = new Vector3(100.4224f, -1905.601f, 40f);
                        EndPosition = new Vector3(66.55393f, -1945.313f, 40f);
                        StartRotation = new Vector3(320, 0, 200);
                        EndRotation = new Vector3(320, 0, 280);
                        time = 60000;
                        Fov = 75;
                        break;
                    case 9:
                        StartPosition = new Vector3(528.9905f, -192.5913f, 65f);
                        EndPosition = new Vector3(520.888f, -165.4624f, 65f);
                        StartRotation = new Vector3(320, 0, 320);
                        EndRotation = new Vector3(320, 0, 237);
                        time = 60000;
                        Fov = 75;
                        break;
                    case 10:
                        StartPosition = new Vector3(385.6806f, -541.5113f, 40f);
                        EndPosition = new Vector3(339.2675f, -547.7947f, 40f);
                        StartRotation = new Vector3(320, 0, 100);
                        EndRotation = new Vector3(320, 0, 100);
                        time = 60000;
                        Fov = 75;
                        break;
                    case 11:
                        StartPosition = new Vector3(258.2238f, -2060.314f, 30f);
                        EndPosition = new Vector3(290.6969f, -2113.237f, 30f);
                        StartRotation = new Vector3(320, 0, 240);
                        EndRotation = new Vector3(320, 0, 0);
                        time = 60000;
                        Fov = 75;
                        break;
                    case 12:
                        StartPosition = new Vector3(-2159.688f, -1025.8f, 10f);
                        EndPosition = new Vector3(-2018.205f, -1115.911f, 10f);
                        StartRotation = new Vector3(0, 0, 344);
                        EndRotation = new Vector3(0, 0, 326);
                        time = 60000;
                        Fov = 75;
                        break;
                    case 13:
                        StartPosition = new Vector3(626.6843f, 1159.774f, 330.9638f);
                        EndPosition = new Vector3(799.3394f, 1129.184f, 330.9638f);
                        StartRotation = new Vector3(0, 0, 290);
                        EndRotation = new Vector3(0, 0, 30);
                        time = 60000;
                        Fov = 75;
                        break;
                    case 14:
                        StartPosition = new Vector3(-81.49934f, -1140.647f, 35f);
                        EndPosition = new Vector3(45.82481f, -1135.694f, 35f);
                        StartRotation = new Vector3(335, 0, 325);
                        EndRotation = new Vector3(335, 0, 48);
                        time = 60000;
                        Fov = 75;
                        break;
                    case 15:
                        StartPosition = new Vector3(-555.4027f, -268.2709f, 52f);
                        EndPosition = new Vector3(-483.5658f, -234.1534f, 52f);
                        StartRotation = new Vector3(335, 0, 1);
                        EndRotation = new Vector3(335, 0, 58);
                        time = 60000;
                        Fov = 75;
                        break;
                }
                Alt.Server.TriggerClientEvent(player, "SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                player.SetPosition = new Vector3(StartPosition.X, StartPosition.Y, StartPosition.Z - 200);
                player.Freeze = true;
            }
            catch { }
        }


        [Command("createcameraevent")]
        public static void CreateCameraTestEvent(Client player, float x, float y, float z, int rotx, int roty, int rotz)
        {
            player.vnxSetStreamSharedElementData("HideHUD", 1);
            //AntiCheat_Allround.StopTimerTeleport(player);
            Position LastPosition = player.Position;
            Position StartPosition = LastPosition;
            Position EndPosition = new Position(x, y, z);

            Rotation StartRotation = player.Rotation;
            Rotation EndRotation = new Rotation(rotx, roty, rotz);
            int time = 60000;
            int Fov = 50;
            Alt.Server.TriggerClientEvent(player, "SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, 0, 1);
            player.SetPosition = LastPosition;
        }


        public static Vector3 Pos1;
        public static Vector3 Pos2;
        [Command("createfullcameraevent")]
        public static void CreateFullCameraTestEvent(Client player, float POS1_Z, float POS2_Z, int rot1x, int rot1y, int rot1z, int rot2x, int rot2y, int rot2z, int time, int Fov)
        {
            if (Pos1 == new Vector3(0, 0, 0))
            {
                Pos1 = new Vector3(player.Position.X, player.Position.Y, POS1_Z);
                Debug.OutputDebugString("POS 1 CAMERA EVENT CREATED");
                return;
            }
            else
            {
                Vector3 lastPos1 = Pos1;
                Pos1 = new Vector3(lastPos1.X, lastPos1.Y, POS2_Z);
            }
            if (Pos2 == new Vector3(0, 0, 0))
            {
                Pos2 = new Vector3(player.Position.X, player.Position.Y, POS2_Z);
                Debug.OutputDebugString("POS 2 CAMERA EVENT CREATED");
            }
            else
            {
                Vector3 lastPos2 = Pos2;
                Pos2 = new Vector3(lastPos2.X, lastPos2.Y, POS2_Z);
            }
            player.vnxSetStreamSharedElementData("HideHUD", 1);
            //AntiCheat_Allround.StopTimerTeleport(player);
            Position LastPosition = player.Position;
            Position StartPosition = Pos1;
            Position EndPosition = Pos2;

            Rotation StartRotation = new Rotation(rot1x, rot1y, rot1z);
            Rotation EndRotation = new Rotation(rot2x, rot2y, rot2z);
            //int Fov = 50;
            Alt.Server.TriggerClientEvent(player, "SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, 0, 1);
            player.SetPosition = LastPosition;
        }

        [Command("resetcamera")]
        public static void ResetCamera(Client player)
        {
            Pos1 = new Vector3();
            Pos2 = new Vector3();
            Debug.OutputDebugString("CAMERAS RESETTED!!");
        }




        [Command("stopcameraevent")]
        public static void StopCurrentCameraEvent(Client player)
        {
            Alt.Server.TriggerClientEvent(player, "DestroyCamera_Event");
        }



        [ClientEvent("load_data_login")]
        public static void LoadDatasRemote(Client player)
        {
            try
            {
                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 200) + "_____________________________________");
                player.SendTranslatedChatMessage("Willkommen auf VenoX - Reallife.");
                player.SendTranslatedChatMessage("Teamspeak 3 : ts3.VenoX-Reallife.com");
                player.SendTranslatedChatMessage("Forum : www.VenoX-Reallife.com");
                player.SendTranslatedChatMessage("Controlpanel : cp.venox-reallife.com");
                player.SendTranslatedChatMessage("Viel Spaß beim Spielen wünscht dir dein VenoX - Reallife Team.");
                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 200) + "_____________________________________");
                premium.viplevels.VIPLEVELS.SendVIPNotify(player);
                Spawn.SpawnPlayerOnSpawnpoint(player);
                Settings.VnX.LoadSettingsData(player);
                player.vnxSetStreamSharedElementData("HideHUD", 0);
                Fun.Aktionen.Shoprob.Shoprob.CreateShopRobPedsIPlayer(player);
                Environment.Gzone.Zone.CreateGreenzone(player);
                gangwar.Allround._gangwarManager.UpdateData(player);
                List<InventoryModel> inventory = anzeigen.Inventar.Main.GetPlayerInventory(player);
                Alt.Server.TriggerClientEvent(player, "Inventory:Update", JsonConvert.SerializeObject(inventory));
            }
            catch { }
        }


        public static void LoadDatasAfterLogin(Client player)
        {
            try
            {

                _Preload_.Character_Creator.Main.LoadCharacterSkin(player);
                character.Customization.ApplyPlayerClothes(player);
                anzeigen.Inventar.Main.OnPlayerConnect(player);
                Sync.LoadBlips(player);
                foreach (VehicleModel Vehicle in VenoXV.Globals.Main.ReallifeVehicles.ToList())
                {
                    string owner = Vehicle.Owner;
                    if (owner != null && owner == player.Username)
                    {
                        Vehicle.Dimension = 0;
                    }
                }
                // Give the weapons to the player
                weapons.Weapons.GivePlayerWeaponItems(player);

                Alt.Server.TriggerClientEvent(player, "movecamtocurrentpos_client");

                if (player.vnxGetElementData<int>(EntityData.PLAYER_KILLED) == 1)
                {
                    player.Health = 0;
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("LoadDatasAfterLogin", ex); }
        }

        public static void OnSelectedReallifeGM(Client player)
        {
            try { LoadDatasAfterLogin(player); handy.Allround.UpdatePhonePlayerlist(); }
            catch (Exception ex) { Debug.CatchExceptions("OnSelectedReallifeGM", ex); }
        }

        [ClientEvent("Send_Player_Where_From")]
        public void Send_To_Server_Where_Player_From(Client player, string Where)
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