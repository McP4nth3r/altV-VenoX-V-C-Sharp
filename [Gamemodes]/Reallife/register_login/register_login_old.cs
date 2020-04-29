using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.character;
using VenoXV._Gamemodes_.Reallife.database;
using VenoXV._Gamemodes_.Reallife.factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._RootCore_.Models;
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

        [Command("tuneveh")]
        public void TuneVehicle(IPlayer player, string aktion, int tuningindex = 0, int r = 255, int g = 255, int b = 255, int color1 = 0, int color2 = 0)
        {
            try
            {
                aktion = aktion.ToLower();
                if (!player.IsInVehicle) { return; }
                IVehicle veh = player.Vehicle;

                veh.ModKit = 1;
                switch (aktion)
                {
                    case "neon":
                        veh.SetNeonActive(true, true, true, true);
                        veh.NeonColor = new Rgba((byte)r, (byte)g, (byte)b, 255);
                        break;
                    case "repair":
                        veh.Repair();
                        break;
                    case "color1rgb":
                        veh.PrimaryColorRgb = new Rgba((byte)r, (byte)g, (byte)b, 255);
                        break;
                    case "color2rgb":
                        veh.SecondaryColorRgb = new Rgba((byte)r, (byte)g, (byte)b, 255);
                        break;
                    case "color1":
                        veh.PrimaryColor = (byte)color1;
                        break;
                    case "color2":
                        veh.SecondaryColor = (byte)color2;
                        break;
                    case "dirtlevel":
                        veh.DirtLevel = (byte)tuningindex;
                        break;
                    case "armor":
                        veh.SetMod(AltV.Net.Enums.VehicleModType.Armor, (byte)tuningindex);
                        break;
                    case "window":
                        veh.SetMod(AltV.Net.Enums.VehicleModType.WindowTint, (byte)tuningindex);
                        break;
                    case "spoiler":
                        veh.SetMod(AltV.Net.Enums.VehicleModType.Spoilers, (byte)tuningindex);
                        break;
                    case "xenon":
                        veh.SetMod(AltV.Net.Enums.VehicleModType.Xenon, (byte)tuningindex);
                        break;
                    case "engine":
                        veh.SetMod(AltV.Net.Enums.VehicleModType.Engine, (byte)tuningindex);
                        break;
                    case "brakes":
                        veh.SetMod(AltV.Net.Enums.VehicleModType.Brakes, (byte)tuningindex);
                        break;
                    case "platec":
                        veh.SetMod(AltV.Net.Enums.VehicleModType.Plate, (byte)tuningindex);
                        break;
                    case "hood":
                        veh.SetMod(AltV.Net.Enums.VehicleModType.Hood, (byte)tuningindex);
                        break;
                    case "turbo":
                        veh.SetMod(AltV.Net.Enums.VehicleModType.Turbo, (byte)tuningindex);
                        break;
                    case "wheels":
                        veh.SetMod(AltV.Net.Enums.VehicleModType.Spoilers, (byte)tuningindex);
                        break;
                    case "roof":
                        veh.SetMod(AltV.Net.Enums.VehicleModType.Roof, (byte)tuningindex);
                        break;
                }
                Core.Debug.OutputDebugString("Aktion : " + aktion + " called : tuningindex :  " + tuningindex);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("tuneveh", ex); }
        }


        //[AltV.Net.ClientEvent("HelpButtonPressed_Login")]
        public void SendAllAdminsLoginHelpNotify(IPlayer player)
        {
            admin.Admin.sendAdminNotification("[" + player.GetVnXName() + " | " + player.SocialClubId.ToString() + "] : Braucht hilfe beim Einloggen! Einer sollte im Teamspeak 3 Warten...");
            logfile.WriteLogs("connect", player.GetVnXName() + " | " + player.SocialClubId.ToString() + " Brauchte hilfe beim Einloggen!");
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
                    player.Position = new Vector3(411.4904f, -956.7184f, 20);

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
                    player.Position = new Vector3(-2295.875f, 377.0148f, 230);
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
                    player.Position = new Vector3(-1043.623f, 193.3604f, 60f);
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
                    player.Position = new Vector3(-545.0013f, -950.6284f, 20f);
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
                    player.Position = new Vector3(902.6528f, -1068.302f, 38f);
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
                    player.Position = new Vector3(170.3055f, -671.4557f, 60.14089f);
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
                    player.Position = new Vector3(-1532.188f, -59.43741f, 70.07549f);
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
                    player.Position = new Vector3(66.55393f, -1945.313f, 50.94582f);
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
                    player.Position = new Vector3(528.9905f, -192.5913f, 62f);
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
                    player.Position = new Vector3(339.2675f, -547.7947f, 20f);
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
                    player.Position = new Vector3(258.2238f, -2060.314f, 10f);
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
                    player.Position = new Vector3(-2018.205f, -1115.911f, 20f);
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
                    player.Position = new Vector3(626.6843f, 1159.774f, 278.9638f);
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
                    player.Position = new Vector3(45.82481f, -1135.694f, 15f);
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
                    player.Position = new Vector3(-555.4027f, -268.2709f, 30f);
                }
            }
            catch { }
        }


        [Command("createcameraevent")]
        public static void CreateCameraTestEvent(IPlayer player, float x, float y, float z, int rotx, int roty, int rotz)
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
            player.Position = LastPosition;
        }


        public static Vector3 Pos1;
        public static Vector3 Pos2;
        [Command("createfullcameraevent")]
        public static void CreateFullCameraTestEvent(IPlayer player, float POS1_Z, float POS2_Z, int rot1x, int rot1y, int rot1z, int rot2x, int rot2y, int rot2z, int time, int Fov)
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
            player.Position = LastPosition;
        }

        [Command("resetcamera")]
        public static void ResetCamera(IPlayer player)
        {
            Pos1 = new Vector3();
            Pos2 = new Vector3();
            Core.Debug.OutputDebugString("CAMERAS RESETTED!!");

        }




        [Command("stopcameraevent")]
        public static void StopCurrentCameraEvent(IPlayer player)
        {
            player.Emit("DestroyCamera_Event");
        }



        [ClientEvent("load_data_login")]
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
                    //ToDo : Fix & find another Way! player.GetVnXName() = player.vnxGetElementData(EntityData.PLAYER_NAME);
                    //player.Rotation = player.vnxGetElementData<int>(EntityData.PLAYER_SPAWN_ROT);
                    //player.Health = player.vnxGetElementData<int>(EntityData.PLAYER_HEALTH);
                    //player.Armor = player.vnxGetElementData<int>(EntityData.PLAYER_ARMOR);
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY));
                    player.vnxSetStreamSharedElementData(EntityData.PLAYER_KNASTZEIT, player.vnxGetElementData<int>(EntityData.PLAYER_KNASTZEIT));
                    player.vnxSetStreamSharedElementData("PLAYER_QUESTSPLAYER", player.vnxGetElementData<int>(EntityData.PLAYER_QUESTS));
                    Spawn.spawnplayer_on_spawnpoint(player);
                    Settings.VnX.LoadSettingsData(player);
                    player.vnxSetStreamSharedElementData("HideHUD", 0);
                    anzeigen.Usefull.VnX.UpdateHUD(player);
                    AntiCheat_Allround.StartTimerTeleport(player);
                    Faction.CreateFactionBaseBlip(player);
                    Fun.Aktionen.Shoprob.Shoprob.CreateShopRobPedsIPlayer(player);
                    // Toggle connection flag
                    player.vnxSetElementData(EntityData.PLAYER_PLAYING, true);
                    player.SetSyncedMetaData("PLAYER_LOGGED_IN", true);
                    //ToDo : ZwischenLösung Finden! player.Transparency = 255;
                    Environment.Gzone.Zone.CreateGreenzone(player);
                    gangwar.Allround._gangwarManager.UpdateData(player);
                    CreateGasBlips(player);

                    player.vnxSetStreamSharedElementData(EntityData.PLAYER_HUNGER, 100);
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
                CreateGasBlips(player);
                /*if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID) <= 0)
                {
                    //return;
                }
                else
                {*/
                foreach (IVehicle Vehicle in Alt.GetAllVehicles())
                {
                    string owner = Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_OWNER);
                    if (owner != null && owner == player.GetVnXName())
                    {
                        Vehicle.Dimension = 0;
                        Vehicle.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.VEHICLE_DIMENSION, 0);
                    }
                    // JOB 
                    if (
                    Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_JOB) == Constants.JOB_CITY_TRANSPORT && Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_OWNER) == player.GetVnXName()
                    || Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_JOB) == Constants.JOB_AIRPORT && Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_OWNER) == player.GetVnXName()
                    || Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_JOB) == Constants.JOB_BUS && Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_OWNER) == player.GetVnXName()
                    )
                    {
                        if (Vehicle != null)
                        {
                            AltV.Net.Alt.RemoveVehicle(Vehicle);
                        }
                    }

                    //Test Vehilce Delete
                    if (Vehicle.vnxGetElementData<bool>("TEST_FAHRZEUG") == true && Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_OWNER) == player.GetVnXName())
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

        public static void OnSelectedReallifeGM(IPlayer player)
        {
            try { LoadDatasAfterLogin(player); }
            catch (Exception ex) { Core.Debug.CatchExceptions("OnSelectedReallifeGM", ex); }
        }




        public static void CreateGasBlips(IPlayer player)
        {
            foreach (var Tankstellen in Constants.AUTO_ZAPF_LIST_BLIPS)
            {
                player.Emit("ShowTankstellenBlips", Tankstellen);
            }
        }

        [ClientEvent("createCharacter")]
        public void CreateCharacterEvent(IPlayer player, string skinJson)
        {
            try
            {
                bool hasCharakter = Database.FindCharacter(player.SocialClubId.ToString());
                if (!hasCharakter)
                {
                    //SkinModel skinModel = NAPI.Util.FromJson<SkinModel>(skinJson);
                    SkinModel skinModel = JsonConvert.DeserializeObject<SkinModel>(skinJson);

                    // Apply the skin to the character
                    player.vnxSetElementData(EntityData.PLAYER_SKIN_MODEL, skinModel);
                    Customization.ApplyPlayerCustomization(player, skinModel, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SEX));
                    int UID = Database.GetAccountUID(player.SocialClubId.ToString());
                    int playerId = Database.CreateCharacter(player, UID, skinModel);

                    if (playerId > 0)
                    {

                        PlayerModel character = Database.LoadCharacterInformationById(playerId);
                        _Gamemodes_.Reallife.register_login.Main.LoadCharacterData(player, character);

                        player.Dimension = 0;
                        player.Emit("characterCreatedSuccessfully");
                        Spawn.spawnplayer_on_spawnpoint(player);
                        Settings.VnX.LoadSettingsData(player);
                        player.vnxSetStreamSharedElementData("HideHUD", 0);
                        player.vnxSetStreamSharedElementData(EntityData.PLAYER_QUESTS, 0);
                        player.vnxSetStreamSharedElementData("PLAYER_QUESTSPLAYER", 0);
                        anzeigen.Usefull.VnX.UpdateHUD(player);
                        CreateGasBlips(player);
                        AntiCheat_Allround.StartTimerTeleport(player);
                        dxLibary.VnX.SetElementFrozen(player, false);
                        player.vnxSetElementData(EntityData.PLAYER_PLAYING, true);
                        player.Emit("Reallife:LoadHUD", 0);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION CreateCharacterEvent] " + ex.Message);
                Console.WriteLine("[EXCEPTION CreateCharacterEvent] " + ex.StackTrace);
            }
        }



        [Command("gethash")]
        public static void GetHash(IPlayer player, string hash)
        {
            Core.Debug.OutputDebugString("[" + hash + "] : " + Alt.Hash(hash));
        }

        [ClientEvent("setCharacterIntoCreator")]
        public void SetCharacterIntoCreatorEvent(IPlayer player)
        {
            try
            {
                // Set player's position
                player.SetPlayerAlpha(255);
                player.SetPlayerVisible(true);
                player.Rotation = new Rotation(0.0f, 0.0f, 180.0f);
                player.SpawnPlayer(new Position(152.3787f, -1000.644f, -99f));
                player.SetPlayerSkin(Alt.Hash("mp_m_freemode_01"));
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