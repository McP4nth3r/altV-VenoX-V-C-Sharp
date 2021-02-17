using System.Collections.Generic;
using System.Numerics;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._Gamemodes_.Tactics.Lobby;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Models;
using VenoXV.Tactics.lobby;

namespace VenoXV._Globals_
{
    public class Commands : IScript
    {
        [Command("skipround")]
        public static async void SkipRound(VnXPlayer player, string gm, int lobby)
        {
            if (player.AdminRank < _Gamemodes_.Reallife.Globals.Constants.AdminlvlModerator) return;
            string gamemode = gm.ToLower();
            switch (gamemode)
            {
                case "seventowers":
                    _Gamemodes_.SevenTowers.Main.StartNewRound();
                    break;
                case "tactics":
                    Pointer._TacticLobbyPointers.TryGetValue(lobby, out Round val);
                    if (val is null)
                    {
                        player.SendTranslatedChatMessage("Tactic Lobby dont exists! Use a lobby between 0 - " + Pointer._TacticLobbyPointers.Count + "!");
                        return;
                    }
                    _Gamemodes_.Tactics.Globals.Functions.SendTacticRoundMessage("hat die Tactic Runde übersprungen!", val);
                    Logfile.WriteLogs("tactics_admin", player.Username + " Skipped the Tactic Round!");
                    _Gamemodes_.Tactics.Globals.Functions.ShowOutroScreen("[VnX]" + player.Username + " hat die Tactic Runde übersprungen!", val);
                    break;
                case "race":
                    string text = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, " hat das Rennen übersprungen!");
                    _Gamemodes_.Race.Globals.Functions.SendRaceRoundMessage(RageApi.GetHexColorcode(200, 0, 0) + player.Name + text);
                    _Gamemodes_.Race.Lobby.Main.StartNewRound();
                    break;
            }
        }

        [Command("pos")]
        public static void GetPlayerPos(VnXPlayer player)
        {
            Debug.OutputDebugString("Position : " + player.Position.X.ToString().Replace(".", ",") + "f, " + player.Position.Y.ToString().Replace(".", ",") + "f, " + player.Position.Z.ToString().Replace(".", ",") + "f");
            Vector3 rot = player.Rotation;
            if (player.IsInVehicle)
            {
                rot = player.Vehicle.Rotation;
            }
            RageApi.CreateMarker(0, player.Position, new Vector3(1, 1, 1), new[] { 0, 150, 200, 255 }, player, player.Dimension);
            Debug.OutputDebugString("Rotation : " + rot.X.ToString().Replace(".", ",") + "f, " + rot.Y.ToString().Replace(".", ",") + "f, " + rot.Z.ToString().Replace(".", ",") + "f");
            player.SendChatMessage(RageApi.GetHexColorcode(0, 200, 0) + "Position : " + player.Position.X.ToString().Replace(".", ",") + "f, " + player.Position.Y.ToString().Replace(".", ",") + "f, " + player.Position.Z.ToString().Replace(".", ",") + "f");
            player.SendChatMessage(RageApi.GetHexColorcode(0, 150, 200) + "Rotation : " + rot.X.ToString().Replace(".", ",") + "f, " + rot.Y.ToString().Replace(".", ",") + "f, " + rot.Z.ToString().Replace(".", ",") + "f");
        }

        public static List<CameraModel> CurrentPlayerCameras = new List<CameraModel>();
        private static int GetCameraCount(VnXPlayer player)
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
        public static void CreateEasyCameraMovement(VnXPlayer player, double x, double y, double z, double rotStart, double rotStop, int duration)
        {
            int id = GetCameraCount(player);
            if (id > 3)
            {
                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du hast bereits 3 Cameras gespeichert... nutze /deletecam [CAM_ID] oder /getallcams");
                return;
            }
            CameraModel playerCamera = new CameraModel
            {
                CameraCreator = player.Username,
                StartPosition = player.Position,
                StartRotation = new Vector3(0, 0, (float)rotStart),
                EndPosition = new Vector3((float)x, (float)y, (float)z),
                EndRotation = new Vector3(0, 0, (float)rotStop),
                DurationInMs = duration,
                Id = id
            };
            //CurrentPlayerCameras.Add(PlayerCamera);
            VenoX.TriggerClientEvent(player, "Player:CreateCameraMovement", player.Position.X, player.Position.Y, player.Position.Z, rotStart, x, y, z, rotStop, duration);
        }
        [Command("stopcam")]
        public static void StopCurrentCamera(VnXPlayer player)
        {
            VenoX.TriggerClientEvent(player, "Player:DestroyCamera");
        }


        [Command("deletallcams")]
        public static void DeleteAllCams(VnXPlayer player)
        {
            foreach (CameraModel cam in CurrentPlayerCameras)
            {
                if (cam.CameraCreator == player.Username)
                {
                    CurrentPlayerCameras.Remove(cam);
                }
            }
            player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 0) + "Alle Cam´s wurden gelöscht!");
        }

        [Command("deletecam")]
        public static void DeletePlayerCameras(VnXPlayer player, int id)
        {
            foreach (CameraModel cam in CurrentPlayerCameras)
            {
                if (cam.CameraCreator == player.Username && cam.Id == id)
                {
                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Du hast die Cam[ID: " + id + "] gelöscht!");
                    CurrentPlayerCameras.Remove(cam);
                }
            }
        }

        [Command("getallcams")]
        public static void GetAllPlayerCams(VnXPlayer player)
        {
            foreach (CameraModel cam in CurrentPlayerCameras)
            {
                if (cam.CameraCreator == player.Username)
                {
                    player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 150, 200) + "Cam [ID : " + cam.Id + "]");
                }
            }
        }

        [Command("playcam")]
        public static void PlayCamById(VnXPlayer player, int id)
        {
            foreach (CameraModel cam in CurrentPlayerCameras)
            {
                if (cam.CameraCreator == player.Username && cam.Id == id)
                {
                    VenoX.TriggerClientEvent(player, "Player:CreateCameraMovement", cam.StartPosition.X, cam.StartPosition.Y, cam.StartPosition.Z, cam.StartRotation.Z, cam.EndPosition.X, cam.EndPosition.Y, cam.EndPosition.Z, cam.EndRotation.Z, cam.DurationInMs);
                }
            }
        }
    }
}
