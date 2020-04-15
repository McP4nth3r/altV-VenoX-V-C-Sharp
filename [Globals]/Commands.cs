﻿using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System.Collections.Generic;
using System.Numerics;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Globals_
{
    public class Commands : IScript
    {

        public static List<CameraModel> CurrentPlayerCameras = new List<CameraModel>();
        private static int GetCameraCount(IPlayer player)
        {
            try
            {
                int counter = 0;
                foreach (CameraModel camera in CurrentPlayerCameras)
                {
                    if (camera.CameraCreator == player.GetVnXName<string>()) { counter++; }
                }
                return counter;
            }
            catch { return 0; }
        }

        [Command("createcam1")]
        public static void CreateEasyCameraMovement(IPlayer player, double x, double y, double z, double rot_start, double rot_stop, int duration)
        {
            int ID = GetCameraCount(player);
            if (ID > 3)
            {
                player.SendChatMessage(Core.RageAPI.GetHexColorcode(200, 0, 0) + "Du hast bereits 3 Cameras gespeichert... nutze /deletecam [CAM_ID] oder /getallcams");
                return;
            }
            CameraModel PlayerCamera = new CameraModel
            {
                CameraCreator = player.GetVnXName<string>(),
                StartPosition = player.Position,
                StartRotation = new Vector3(0, 0, (float)rot_start),
                EndPosition = new Vector3((float)x, (float)y, (float)z),
                EndRotation = new Vector3(0, 0, (float)rot_stop),
                DurationInMS = duration,
                ID = ID
            };
            //CurrentPlayerCameras.Add(PlayerCamera);
            player.Emit("Player:CreateCameraMovement", player.Position.X, player.Position.Y, player.Position.Z, rot_start, x, y, z, rot_stop, duration);
        }
        [Command("stopcam")]
        public static void StopCurrentCamera(IPlayer player)
        {
            player?.Emit("Player:DestroyCamera");
        }


        [Command("deletallcams")]
        public static void DeleteAllCams(IPlayer player)
        {
            foreach (CameraModel cam in CurrentPlayerCameras)
            {
                if (cam.CameraCreator == player.GetVnXName<string>())
                {
                    CurrentPlayerCameras.Remove(cam);
                }
            }
            player.SendChatMessage(Core.RageAPI.GetHexColorcode(0, 200, 0) + "Alle Cam´s wurden gelöscht!");
        }

        [Command("deletecam")]
        public static void DeletePlayerCameras(IPlayer player, int ID)
        {
            foreach (CameraModel cam in CurrentPlayerCameras)
            {
                if (cam.CameraCreator == player.GetVnXName<string>() && cam.ID == ID)
                {
                    player.SendChatMessage(Core.RageAPI.GetHexColorcode(200, 0, 0) + "Du hast die Cam[ID: " + ID + "] gelöscht!");
                    CurrentPlayerCameras.Remove(cam);
                }
            }
        }

        [Command("getallcams")]
        public static void GetAllPlayerCams(IPlayer player)
        {
            foreach (CameraModel cam in CurrentPlayerCameras)
            {
                if (cam.CameraCreator == player.GetVnXName<string>())
                {
                    player.SendChatMessage(Core.RageAPI.GetHexColorcode(0, 150, 200) + "Cam [ID : " + cam.ID + "]");
                }
            }
        }

        [Command("playcam")]
        public static void PlayCamByID(IPlayer player, int ID)
        {
            foreach (CameraModel cam in CurrentPlayerCameras)
            {
                if (cam.CameraCreator == player.GetVnXName<string>() && cam.ID == ID)
                {
                    player.Emit("Player:CreateCameraMovement", cam.StartPosition.X, cam.StartPosition.Y, cam.StartPosition.Z, cam.StartRotation.Z, cam.EndPosition.X, cam.EndPosition.Y, cam.EndPosition.Z, cam.EndRotation.Z, cam.DurationInMS);
                }
            }
        }
    }
}
