using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV._RootCore_.Sync;
using VenoXV.Anti_Cheat;
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
                dxLibary.VnX.SetElementFrozen(player, true);
                if (cevent == 1)
                {
                    Vector3 StartPosition = new Vector3(411.4904f, -956.7184f, 50);
                    Vector3 EndPosition = new Vector3(420.6378f, -1050.697f, 55);
                    int Fov = 75;
                    int time = 60000;
                    Vector3 StartRotation = new Rotation(320, 0, 180);
                    Vector3 EndRotation = new Rotation(320, 0, 220);
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.SetPosition = new Vector3(411.4904f, -956.7184f, 20);

                }
                else if (cevent == 2)
                {
                    Vector3 StartPosition = new Vector3(-2283.365f, 419.0807f, 200);
                    Vector3 EndPosition = new Vector3(-2324.99f, 408.6786f, 200);

                    Vector3 StartRotation = new Rotation(320, 0, 180);
                    Vector3 EndRotation = new Rotation(320, 0, 220);
                    int time = 60000;
                    int Fov = 75;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.SetPosition = new Vector3(-2295.875f, 377.0148f, 230);
                }
                else if (cevent == 3)
                {
                    Vector3 StartPosition = new Vector3(-1000.456f, 197.4469f, 66.5f);
                    Vector3 EndPosition = new Vector3(-1039.38f, 200.267f, 62.56097f);

                    Vector3 StartRotation = new Vector3(0, 0, 88);
                    Vector3 EndRotation = new Vector3(0, 0, 88);
                    int time = 60000;
                    int Fov = 75;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.SetPosition = new Vector3(-1043.623f, 193.3604f, 60f);
                }
                else if (cevent == 4)
                {
                    Vector3 StartPosition = new Vector3(-545.0013f, -950.6284f, 38f);
                    Vector3 EndPosition = new Vector3(-516.2668f, -887.1884f, 42f);

                    Vector3 StartRotation = new Vector3(320, 0, 30);
                    Vector3 EndRotation = new Vector3(320, 0, 100);
                    int time = 60000;
                    int Fov = 75;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.SetPosition = new Vector3(-545.0013f, -950.6284f, 20f);
                }
                else if (cevent == 5)
                {
                    Vector3 StartPosition = new Vector3(902.6528f, -1068.302f, 48f);
                    Vector3 EndPosition = new Vector3(905.508f, -1020.261f, 50f);

                    Vector3 StartRotation = new Vector3(320, 0, 35);
                    Vector3 EndRotation = new Vector3(320, 0, 100);
                    int time = 60000;
                    int Fov = 75;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.SetPosition = new Vector3(902.6528f, -1068.302f, 38f);
                }
                else if (cevent == 6)
                {
                    Vector3 StartPosition = new Vector3(179.6578f, -644.4746f, 60.44452f);
                    Vector3 EndPosition = new Vector3(211.5414f, -657.911f, 60.07743f);

                    Vector3 StartRotation = new Vector3(320, 0, 195);
                    Vector3 EndRotation = new Vector3(320, 0, 108);
                    int time = 60000;
                    int Fov = 75;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.SetPosition = new Vector3(170.3055f, -671.4557f, 60.14089f);
                }
                else if (cevent == 7)
                {
                    Vector3 StartPosition = new Vector3(-1532.188f, -59.43741f, 70.07549f);
                    Vector3 EndPosition = new Vector3(-1585.257f, -70.50438f, 70.94582f);

                    Vector3 StartRotation = new Vector3(320, 0, 147);
                    Vector3 EndRotation = new Vector3(320, 0, 220);
                    int time = 60000;
                    int Fov = 75;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.SetPosition = new Vector3(-1532.188f, -59.43741f, 70.07549f);
                }
                else if (cevent == 8)
                {
                    Vector3 StartPosition = new Vector3(100.4224f, -1905.601f, 40f);
                    Vector3 EndPosition = new Vector3(66.55393f, -1945.313f, 40f);

                    Vector3 StartRotation = new Vector3(320, 0, 200);
                    Vector3 EndRotation = new Vector3(320, 0, 280);
                    int time = 60000;
                    int Fov = 75;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.SetPosition = new Vector3(66.55393f, -1945.313f, 50.94582f);
                }
                else if (cevent == 9)
                {
                    Vector3 StartPosition = new Vector3(528.9905f, -192.5913f, 65f);
                    Vector3 EndPosition = new Vector3(520.888f, -165.4624f, 65f);

                    Vector3 StartRotation = new Vector3(320, 0, 320);
                    Vector3 EndRotation = new Vector3(320, 0, 237);
                    int time = 60000;
                    int Fov = 75;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.SetPosition = new Vector3(528.9905f, -192.5913f, 62f);
                }
                else if (cevent == 10)
                {
                    Vector3 StartPosition = new Vector3(385.6806f, -541.5113f, 40f);
                    Vector3 EndPosition = new Vector3(339.2675f, -547.7947f, 40f);

                    Vector3 StartRotation = new Vector3(320, 0, 100);
                    Vector3 EndRotation = new Vector3(320, 0, 100);
                    int time = 60000;
                    int Fov = 75;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.SetPosition = new Vector3(339.2675f, -547.7947f, 20f);
                }
                else if (cevent == 11)
                {
                    Vector3 StartPosition = new Vector3(258.2238f, -2060.314f, 30f);
                    Vector3 EndPosition = new Vector3(290.6969f, -2113.237f, 30f);

                    Vector3 StartRotation = new Vector3(320, 0, 240);
                    Vector3 EndRotation = new Vector3(320, 0, 0);
                    int time = 60000;
                    int Fov = 75;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.SetPosition = new Vector3(258.2238f, -2060.314f, 10f);
                }
                else if (cevent == 12)
                {
                    Vector3 StartPosition = new Vector3(-2159.688f, -1025.8f, 10f);
                    Vector3 EndPosition = new Vector3(-2018.205f, -1115.911f, 10f);

                    Vector3 StartRotation = new Vector3(0, 0, 344);
                    Vector3 EndRotation = new Vector3(0, 0, 326);
                    int time = 60000;
                    int Fov = 75;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.SetPosition = new Vector3(-2018.205f, -1115.911f, 20f);
                }
                else if (cevent == 13)
                {
                    Vector3 StartPosition = new Vector3(626.6843f, 1159.774f, 330.9638f);
                    Vector3 EndPosition = new Vector3(799.3394f, 1129.184f, 330.9638f);

                    Vector3 StartRotation = new Vector3(0, 0, 290);
                    Vector3 EndRotation = new Vector3(0, 0, 30);
                    int time = 60000;
                    int Fov = 75;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.SetPosition = new Vector3(626.6843f, 1159.774f, 278.9638f);
                }
                else if (cevent == 14)
                {
                    Vector3 StartPosition = new Vector3(-81.49934f, -1140.647f, 35f);
                    Vector3 EndPosition = new Vector3(45.82481f, -1135.694f, 35f);

                    Vector3 StartRotation = new Vector3(335, 0, 325);
                    Vector3 EndRotation = new Vector3(335, 0, 48);
                    int time = 60000;
                    int Fov = 75;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.SetPosition = new Vector3(45.82481f, -1135.694f, 15f);
                }
                else if (cevent == 15)
                {
                    Vector3 StartPosition = new Vector3(-555.4027f, -268.2709f, 52f);
                    Vector3 EndPosition = new Vector3(-483.5658f, -234.1534f, 52f);

                    Vector3 StartRotation = new Vector3(335, 0, 1);
                    Vector3 EndRotation = new Vector3(335, 0, 58);
                    int time = 60000;
                    int Fov = 75;
                    player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, cevent, new_lastNumber);
                    player.SetPosition = new Vector3(-555.4027f, -268.2709f, 30f);
                }
            }
            catch { }
        }


        [Command("createcameraevent")]
        public static void CreateCameraTestEvent(Client player, float x, float y, float z, int rotx, int roty, int rotz)
        {
            player.vnxSetStreamSharedElementData("HideHUD", 1);
            AntiCheat_Allround.StopTimerTeleport(player);
            Position LastPosition = player.Position;
            Position StartPosition = LastPosition;
            Position EndPosition = new Position(x, y, z);

            Rotation StartRotation = player.Rotation;
            Rotation EndRotation = new Rotation(rotx, roty, rotz);
            int time = 60000;
            int Fov = 50;
            player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, 0, 1);
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
                Core.Debug.OutputDebugString("POS 1 CAMERA EVENT CREATED");
                return;
            }
            if (Pos2 == new Vector3(0, 0, 0))
            {
                Pos2 = new Vector3(player.Position.X, player.Position.Y, POS2_Z);
                Core.Debug.OutputDebugString("POS 2 CAMERA EVENT CREATED");
            }
            player.vnxSetStreamSharedElementData("HideHUD", 1);
            AntiCheat_Allround.StopTimerTeleport(player);
            Position LastPosition = player.Position;
            Position StartPosition = Pos1;
            Position EndPosition = Pos2;

            Rotation StartRotation = new Rotation(rot1x, rot1y, rot1z);
            Rotation EndRotation = new Rotation(rot2x, rot2y, rot2z);
            //int Fov = 50;
            player.Emit("SetCamera_Event_Login", StartPosition, EndPosition, StartRotation, EndRotation, Fov, time, 0, 1);
            player.SetPosition = LastPosition;
        }

        [Command("resetcamera")]
        public static void ResetCamera(Client player)
        {
            Pos1 = new Vector3();
            Pos2 = new Vector3();
            Core.Debug.OutputDebugString("CAMERAS RESETTED!!");

        }




        [Command("stopcameraevent")]
        public static void StopCurrentCameraEvent(Client player)
        {
            player.Emit("DestroyCamera_Event");
        }



        [ClientEvent("load_data_login")]
        public static void LoadDatasRemote(Client player)
        {
            try
            {
                player.Emit("Reallife:LoadHUD", player.Reallife.HUD);
                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 200) + "_____________________________________");
                player.SendTranslatedChatMessage("Willkommen auf VenoX - Reallife.");
                player.SendTranslatedChatMessage("Teamspeak 3 : ts3.VenoX-Reallife.com");
                player.SendTranslatedChatMessage("Forum : www.VenoX-Reallife.com");
                player.SendTranslatedChatMessage("Controlpanel : cp.venox-reallife.com");
                player.SendTranslatedChatMessage("Viel Spaß beim Spielen wünscht dir dein VenoX - Reallife Team.");
                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 150, 200) + "_____________________________________");
                premium.viplevels.VIPLEVELS.SendVIPNotify(player);
                Spawn.spawnplayer_on_spawnpoint(player);
                Settings.VnX.LoadSettingsData(player);
                player.vnxSetStreamSharedElementData("HideHUD", 0);
                AntiCheat_Allround.StartTimerTeleport(player);
                Faction.CreateFactionBaseBlip(player);
                Fun.Aktionen.Shoprob.Shoprob.CreateShopRobPedsIPlayer(player);
                Environment.Gzone.Zone.CreateGreenzone(player);
                gangwar.Allround._gangwarManager.UpdateData(player);
                CreateGasBlips(player);
                List<InventoryModel> inventory = anzeigen.Inventar.Main.GetPlayerInventory(player);
                player.Emit("Inventory:Update", JsonConvert.SerializeObject(inventory));
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
                CreateGasBlips(player);
                foreach (VehicleModel Vehicle in Alt.GetAllVehicles())
                {
                    string owner = Vehicle.Owner;
                    if (owner != null && owner == player.Username)
                    {
                        Vehicle.Dimension = 0;
                    }
                    // JOB 
                    if (
                    Vehicle.Job == Constants.JOB_CITY_TRANSPORT && Vehicle.Owner == player.Username
                    || Vehicle.Job == Constants.JOB_AIRPORT && Vehicle.Owner == player.Username
                    || Vehicle.Job == Constants.JOB_BUS && Vehicle.Owner == player.Username
                    )
                    {
                        if (Vehicle != null)
                        {
                            AltV.Net.Alt.RemoveVehicle(Vehicle);
                        }
                    }

                    //Test Vehilce Delete
                    if (Vehicle.vnxGetElementData<bool>("TEST_FAHRZEUG") == true && Vehicle.Owner == player.Username)
                    {
                        Vehicle.Remove();
                    }
                    //}


                    int playerSqlId = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);


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

        public static void OnSelectedReallifeGM(Client player)
        {
            try { LoadDatasAfterLogin(player); }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnSelectedReallifeGM", ex); }
        }



        public static void CreateGasBlips(Client player)
        {
            foreach (var Tankstellen in Constants.AUTO_ZAPF_LIST_BLIPS)
            {
                player.Emit("ShowTankstellenBlips", Tankstellen);
            }
        }

        //[AltV.Net.ClientEvent("Send_Player_Where_From")]
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