﻿using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Globals_
{
    public class Commands : IScript
    {
        [Command("skipround")]
        public static async void SkipRound(Client player, string gm)
        {
            string Gamemode = gm.ToLower();
            switch (Gamemode)
            {
                case "seventowers":
                    _Gamemodes_.SevenTowers.Main.StartNewRound();
                    break;
                case "tactics":
                    if (player.AdminRank >= _Gamemodes_.Reallife.Globals.Constants.ADMINLVL_MODERATOR)
                    {
                        await Task.Run(async () =>
                        {
                            string text = await _Language_.Main.TranslateText("hat die Tactic Runde übersprungen!", "de", _Language_.Main.GetClientLanguagePair(player));
                            _Gamemodes_.Tactics.Globals.Functions.SendTacticRoundMessage(_Gamemodes_.Reallife.Globals.Constants.Rgba_ADMIN_CLANTAG + player.Username + " " + text);
                            _Gamemodes_.Reallife.vnx_stored_files.logfile.WriteLogs("tactics_admin", player.Username + text);
                            _Gamemodes_.Tactics.Globals.Functions.ShowOutroScreen("[VnX]" + player.Username + text);
                        });
                    }
                    break;
                case "race":
                    if (player.AdminRank >= _Gamemodes_.Reallife.Globals.Constants.ADMINLVL_MODERATOR)
                    {
                        await Task.Run(async () =>
                        {
                            string text = await _Language_.Main.TranslateText(" hat das Rennen übersprungen!", "de", _Language_.Main.GetClientLanguagePair(player));
                            _Gamemodes_.Race.Globals.Functions.SendRaceRoundMessage(Core.RageAPI.GetHexColorcode(200, 0, 0) + player.Name + text);
                            _Gamemodes_.Race.Lobby.Main.StartNewRound();
                        });
                    }
                    break;
            }
        }

        [Command("pos")]
        public static void GetPlayerPos(Client player)
        {
            Core.Debug.OutputDebugString("Position : " + player.Position.X.ToString().Replace(".", ",") + "f, " + player.Position.Y.ToString().Replace(".", ",") + "f, " + player.Position.Z.ToString().Replace(".", ",") + "f");
            Vector3 rot = player.Rotation;
            if (player.IsInVehicle)
            {
                rot = player.Vehicle.Rotation;
            }
            RageAPI.CreateMarker(0, player.Position, new Vector3(1, 1, 1), new int[] { 0, 150, 200, 255 }, player, player.Dimension);
            Core.Debug.OutputDebugString("Rotation : " + rot.X.ToString().Replace(".", ",") + "f, " + rot.Y.ToString().Replace(".", ",") + "f, " + rot.Z.ToString().Replace(".", ",") + "f");
            player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 0) + "Position : " + player.Position.X.ToString().Replace(".", ",") + "f, " + player.Position.Y.ToString().Replace(".", ",") + "f, " + player.Position.Z.ToString().Replace(".", ",") + "f");
            player.SendChatMessage(RageAPI.GetHexColorcode(0, 150, 200) + "Rotation : " + rot.X.ToString().Replace(".", ",") + "f, " + rot.Y.ToString().Replace(".", ",") + "f, " + rot.Z.ToString().Replace(".", ",") + "f");
        }

        public static List<CameraModel> CurrentPlayerCameras = new List<CameraModel>();
        private static int GetCameraCount(Client player)
        {
            try
            {
                int counter = 0;
                foreach (CameraModel camera in CurrentPlayerCameras)
                {
                    if (camera.CameraCreator == player.Username) { counter++; }
                }
                return counter;
            }
            catch { return 0; }
        }

        [Command("createcam1")]
        public static void CreateEasyCameraMovement(Client player, double x, double y, double z, double rot_start, double rot_stop, int duration)
        {
            int ID = GetCameraCount(player);
            if (ID > 3)
            {
                player.SendTranslatedChatMessage(Core.RageAPI.GetHexColorcode(200, 0, 0) + "Du hast bereits 3 Cameras gespeichert... nutze /deletecam [CAM_ID] oder /getallcams");
                return;
            }
            CameraModel PlayerCamera = new CameraModel
            {
                CameraCreator = player.Username,
                StartPosition = player.Position,
                StartRotation = new Vector3(0, 0, (float)rot_start),
                EndPosition = new Vector3((float)x, (float)y, (float)z),
                EndRotation = new Vector3(0, 0, (float)rot_stop),
                DurationInMS = duration,
                ID = ID
            };
            //CurrentPlayerCameras.Add(PlayerCamera);
            Alt.Server.TriggerClientEvent(player, "Player:CreateCameraMovement", player.Position.X, player.Position.Y, player.Position.Z, rot_start, x, y, z, rot_stop, duration);
        }
        [Command("stopcam")]
        public static void StopCurrentCamera(Client player)
        {
            player?.Emit("Player:DestroyCamera");
        }


        [Command("deletallcams")]
        public static void DeleteAllCams(Client player)
        {
            foreach (CameraModel cam in CurrentPlayerCameras)
            {
                if (cam.CameraCreator == player.Username)
                {
                    CurrentPlayerCameras.Remove(cam);
                }
            }
            player.SendTranslatedChatMessage(Core.RageAPI.GetHexColorcode(0, 200, 0) + "Alle Cam´s wurden gelöscht!");
        }

        [Command("deletecam")]
        public static void DeletePlayerCameras(Client player, int ID)
        {
            foreach (CameraModel cam in CurrentPlayerCameras)
            {
                if (cam.CameraCreator == player.Username && cam.ID == ID)
                {
                    player.SendTranslatedChatMessage(Core.RageAPI.GetHexColorcode(200, 0, 0) + "Du hast die Cam[ID: " + ID + "] gelöscht!");
                    CurrentPlayerCameras.Remove(cam);
                }
            }
        }

        [Command("getallcams")]
        public static void GetAllPlayerCams(Client player)
        {
            foreach (CameraModel cam in CurrentPlayerCameras)
            {
                if (cam.CameraCreator == player.Username)
                {
                    player.SendTranslatedChatMessage(Core.RageAPI.GetHexColorcode(0, 150, 200) + "Cam [ID : " + cam.ID + "]");
                }
            }
        }

        [Command("playcam")]
        public static void PlayCamByID(Client player, int ID)
        {
            foreach (CameraModel cam in CurrentPlayerCameras)
            {
                if (cam.CameraCreator == player.Username && cam.ID == ID)
                {
                    Alt.Server.TriggerClientEvent(player, "Player:CreateCameraMovement", cam.StartPosition.X, cam.StartPosition.Y, cam.StartPosition.Z, cam.StartRotation.Z, cam.EndPosition.X, cam.EndPosition.Y, cam.EndPosition.Z, cam.EndRotation.Z, cam.DurationInMS);
                }
            }
        }
    }
}
