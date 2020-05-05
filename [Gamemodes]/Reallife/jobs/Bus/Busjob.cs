using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using System.Collections.Generic;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.jobs.Bus
{
    public class Busjob : IScript
    {

        public static string BUSJOB_LEVEL = "BUSJOB_LEVEL";
        public static int BUSJOB_LEVEL_ONE_MONEY = 70;
        public static int BUSJOB_ROUND_BONUS = 350;
        public static int INITIALIZE_MAX_BUSSTATIONS = -1; // Lädt die Maximalen Bus Stations 
        // BusJob Punkte
        public static List<Position> AbgabepunkteLVLONE = new List<Position>
        {
            new Position(402.7597f, -669.9449f, 28.87156f),
            new Position(302.9639f, -768.7956f, 29.31038f),
            new Position(242.534f, -939.2287f, 29.2601f),
            new Position(359.3319f, -1067.105f, 29.5447f),
            new Position(897.1827f, -1010.566f, 33.59047f),
            new Position(1108.925f, -966.1584f, 46.56064f),
            new Position(1196.669f, -482.2346f, 65.89335f),
            new Position(974.1281f, -154.7098f, 73.54858f),
            new Position(663.8275f, -12.00813f, 83.75602f),
            new Position(491.0322f, -267.3286f, 47.25852f),
            new Position(409.1723f, -376.7289f, 46.92794f),
            new Position(239.2503f, -596.1932f, 42.80185f),
            new Position(114.1052f, -934.5211f, 29.78245f),
            new Position(-464.8549f, -825.6618f, 30.52075f),
            new Position(-625.824f, -708.9153f, 29.65393f),
            new Position(-617.0618f, -411.9111f, 34.76335f),
            new Position(-508.3139f, -287.5774f, 35.42538f),
            new Position(-362.8997f, -334.1208f, 31.55053f),
            new Position(-20.96489f, -274.9718f, 46.76252f),
            new Position(101.634f, -535.82f, 43.20762f),
            new Position(241.4493f, -862.4976f, 29.70812f),
            new Position(442.8245f, -683.4969f, 28.69056f),
        };

        public static void OnResourceStart()
        {
            try
            {
                // Erstellt für jede Koordinate in der Tabelle eine Bus - Station.
                foreach (Position BusCoord in AbgabepunkteLVLONE)
                {
                    INITIALIZE_MAX_BUSSTATIONS += 1; // Load Max. Stations 
                    //NAPI.Object.CreateObject(3272282878, new Position(BusCoord.X, BusCoord.Y, BusCoord.Z - 1), new Position(0, 0, 0), 0);
                }
            }
            catch { }
        }

        public static void StartBusJob(PlayerModel player, int value)
        {
            try
            {   // Die punkte abfragen!
                player.vnxSetElementData(BUSJOB_LEVEL, 0);
                dxLibary.VnX.DrawNotification(player, "info", "Mach VenoX Mobil!");
                Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 3000);

                Position Destination = AbgabepunkteLVLONE[0];

                JoB_Allround.JobAbgabeMarker = Alt.CreateColShapeSphere(Destination, 5f);
                dxLibary.VnX.DrawCustomZielBlip(player, "Abgabe[Bus - Job]", Destination, 1, 480, 0, 0, 0, 0, 0, 0);
                dxLibary.VnX.DrawWaypoint(player, Destination.X, Destination.Y);
                JoB_Allround.JobAbgabeMarker.vnxSetElementData(EntityData.PLAYER_JOB_COLSHAPE_OWNER, player.GetVnXName());
                JoB_Allround.JobAbgabeMarker.vnxSetElementData(EntityData.PLAYER_IS_JOB_COL, true);
                Core.VnX.SetDelayedBoolSharedData(player, EntityData.PLAYER_IS_IN_JOB, true, 1500);
                if (value == 1) { VenoXV.Globals.Functions.CreateVehicle(player, AltV.Net.Enums.VehicleModel.Bus, new Position(466.3002f, -595.9792f, 28.10545f), 190, new Rgba(0, 0, 0, 255), new Rgba(0, 0, 0, 255), true, false, Constants.JOB_BUS, "VenoX"); }
                else if (value == 2) { VenoXV.Globals.Functions.CreateVehicle(player, AltV.Net.Enums.VehicleModel.Airbus, new Position(466.3002f, -595.9792f, 28.10545f), 190, new Rgba(0, 0, 0, 255), new Rgba(0, 0, 0, 255), true, false, Constants.JOB_BUS, "VenoX"); }
                else if (value == 3) { VenoXV.Globals.Functions.CreateVehicle(player, AltV.Net.Enums.VehicleModel.Coach, new Position(466.3002f, -595.9792f, 28.10545f), 190, new Rgba(0, 0, 0, 255), new Rgba(0, 0, 0, 255), true, false, Constants.JOB_BUS, "VenoX"); }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du hast nichts ausgewählt!");
                }
            }
            catch { }
        }

        public static void TriggerToNextMarker(PlayerModel player)
        {
            try
            {
                if (player.IsInVehicle)
                {
                    int CurrentBosStation = player.vnxGetElementData<int>(BUSJOB_LEVEL);

                    if (CurrentBosStation == INITIALIZE_MAX_BUSSTATIONS) // WENN DER SPIELER MAXIMALE RUNDEN ERREICHT
                    {
                        player.SendChatMessage(RageAPI.GetHexColorcode(255, 0, 0) + "Du hast eine Runde Erfolgreich absolviert :)");
                        player.SendChatMessage(RageAPI.GetHexColorcode(255, 0, 0) + "Dein Bonus beträgt : " + BUSJOB_ROUND_BONUS + " $");
                        player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + BUSJOB_ROUND_BONUS);
                        player.vnxSetElementData(BUSJOB_LEVEL, 0);
                    }
                    else
                    {
                        player.vnxSetElementData(BUSJOB_LEVEL, CurrentBosStation + 1);
                    }

                    Position Destination = AbgabepunkteLVLONE[(int)player.vnxGetElementData<int>(BUSJOB_LEVEL)];
                    dxLibary.VnX.DrawNotification(player, "info", "+ " + BUSJOB_LEVEL_ONE_MONEY + " $");
                    JoB_Allround.JobAbgabeMarker = Alt.CreateColShapeSphere(Destination, 5f);
                    dxLibary.VnX.DrawCustomZielBlip(player, "Abgabe[Bus - Job]", Destination, 1, 480, 0, 0, 0, 0, 0, 0);
                    dxLibary.VnX.DrawWaypoint(player, Destination.X, Destination.Y);
                    JoB_Allround.JobAbgabeMarker.vnxSetElementData(EntityData.PLAYER_JOB_COLSHAPE_OWNER, player.GetVnXName());
                    JoB_Allround.JobAbgabeMarker.vnxSetElementData(EntityData.PLAYER_IS_JOB_COL, true);
                    player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) + BUSJOB_LEVEL_ONE_MONEY);
                    dxLibary.VnX.SetIVehicleElementFrozen(player.Vehicle, player, true);
                    dxLibary.VnX.SetDelayedIVehicleElementFrozen(player.Vehicle, player, false, 5000);
                    player.vnxSetElementData(EntityData.PLAYER_BUSJOB_LEVEL, player.vnxGetElementData<int>(EntityData.PLAYER_BUSJOB_LEVEL) + 1);
                }
            }
            catch
            {

            }
        }
    }
}
