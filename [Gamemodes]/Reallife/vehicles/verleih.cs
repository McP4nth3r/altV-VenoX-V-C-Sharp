//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using System.Linq;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Vehicles
{
    public class Verleih : IScript
    {
        public const string CURRENT_VEHICLE_RENT = "CURRENT_VEHICLE_RENT";
        public const string HAVE_PLAYER_RENTED_VEHICLE = "HAVE_PLAYER_RENTED_VEHICLE";
        public static Position NOOBSPAWN_RENTALS = new Position(-2302.477f, 365.9013f, 173.5f);
        public static Position LSPD_RENTALS = new Position(333.5797f, -949.9188f, 29.55218f);
        public static int FAGGIO_COSTS = 75;
        public static int PANTO_COSTS = 119;





        //Col Creation
        public static ColShapeModel NoobspawnVerleihColShapeModel = RageAPI.CreateColShapeSphere(new Position(-2302.628f, 366.7664f, 2), 2);
        public static ColShapeModel LSPDVerleihCol = RageAPI.CreateColShapeSphere(new Position(333.6211f, -950.823f, 2), 2);
        public static void OnResourceStart()
        {
            Core.RageAPI.CreateBlip("VenoX Rental Service", NOOBSPAWN_RENTALS, 545, 3, true);
            Core.RageAPI.CreateBlip("VenoX Rental Service", LSPD_RENTALS, 545, 3, true);
        }





        /// <param name="player">Player who´s the Owner</param>
        /// <param name="Roller">Is it A Roller? If No it should be a Panto.</param>
        public static void GetNearestRentalsSpawn(VnXPlayer player, bool Roller)
        {
            try
            {
                if (player.Position.Distance(NOOBSPAWN_RENTALS) <= 5)
                {
                    if (Roller)
                    {
                        VenoXV.Globals.Functions.CreateVehicle(player, AltV.Net.Enums.VehicleModel.Faggio, new Position(-2282.231f, 404.0836f, 174.4667f), 120f, new Rgba(0, 255, 155, 255), new Rgba(0, 0, 0, 255), true, true, Constants.JOB_NONE, "VenoX");
                    }
                    else
                    {
                        VenoXV.Globals.Functions.CreateVehicle(player, AltV.Net.Enums.VehicleModel.Panto, new Position(-2283.869f, 407.4549f, 174.4667f), 120f, new Rgba(0, 255, 155, 255), new Rgba(0, 0, 0, 255), true, true, Constants.JOB_NONE, "VenoX");
                    }
                }
                else if (player.Position.Distance(LSPD_RENTALS) <= 5)
                {
                    if (Roller)
                    {
                        VenoXV.Globals.Functions.CreateVehicle(player, AltV.Net.Enums.VehicleModel.Faggio, new Position(340.4336f, -950.1079f, 29.41012f), 120f, new Rgba(0, 255, 155, 255), new Rgba(0, 0, 0, 255), true, true, Constants.JOB_NONE, "VenoX");
                    }
                    else
                    {
                        VenoXV.Globals.Functions.CreateVehicle(player, AltV.Net.Enums.VehicleModel.Panto, new Position(346.5351f, -950.4115f, 29.39716f), 120f, new Rgba(0, 255, 155, 255), new Rgba(0, 0, 0, 255), true, true, Constants.JOB_NONE, "VenoX");
                    }
                }
            }
            catch { }
        }

        //Function will be called by Lib.
        public static void GivePlayerRentedIVehicle(VnXPlayer player, int value)
        {
            try
            {
                if (player.vnxGetElementData<int>(HAVE_PLAYER_RENTED_VEHICLE) == 0)
                {
                    if (value == 0)
                    {
                        int playerMoney = player.Reallife.Money;
                        if (playerMoney >= FAGGIO_COSTS)
                        {
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playerMoney - FAGGIO_COSTS);
                            player.vnxSetStreamSharedElementData(HAVE_PLAYER_RENTED_VEHICLE, 1);
                            player.vnxSetStreamSharedElementData(CURRENT_VEHICLE_RENT, 0);
                            GetNearestRentalsSpawn(player, true);
                            //VnX.CreateCTimer(player, "VnX_Rentals", 60000);
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "Du hast nicht genug Geld! ");
                        }
                    }
                    else
                    {
                        int playerMoney = player.Reallife.Money;
                        if (player.Reallife.Money >= PANTO_COSTS)
                        {
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playerMoney - PANTO_COSTS);
                            player.vnxSetStreamSharedElementData(HAVE_PLAYER_RENTED_VEHICLE, 1);
                            player.vnxSetStreamSharedElementData(CURRENT_VEHICLE_RENT, 1);
                            GetNearestRentalsSpawn(player, false);
                            //VnX.CreateCTimer(player, "VnX_Rentals", 60000);
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "Du hast nicht genug Geld!");
                        }
                    }

                }
                else
                {
                    player.SendTranslatedChatMessage("Du hast bereits ein Fahrzeug ausgeliehen!");
                    player.SendTranslatedChatMessage("Warte bis dein Fahrzeug abläuft oder benutze /stoprent !");
                }
            }
            catch { }
        }

        [Command("updaterent")]
        public void Update_VenoX_Rentals(VnXPlayer player)
        {
            try
            {
                int playerMoney = player.Reallife.Money;
                if (player.vnxGetElementData<int>(CURRENT_VEHICLE_RENT) == 0)
                {
                    if (player.Reallife.Money >= FAGGIO_COSTS)
                    {
                        player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playerMoney - FAGGIO_COSTS);
                        Alt.Server.TriggerClientEvent(player, "VnX_UpdateRent", player);
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                    }
                }
                else if (player.vnxGetElementData<int>(CURRENT_VEHICLE_RENT) == 1)
                {
                    if (player.Reallife.Money >= PANTO_COSTS)
                    {
                        player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playerMoney - PANTO_COSTS);
                        Alt.Server.TriggerClientEvent(player, "VnX_UpdateRent", player);
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                    }
                }
            }
            catch
            {
            }
        }

        //[AltV.Net.ClientEvent("Destroy_Verleih_Rentals")]
        public void destroy_Fahrzeug_verleih(VnXPlayer player)
        {
            try
            {
                foreach (VehicleModel Vehicle in VenoXV.Globals.Main.ReallifeVehicles.ToList())
                {
                    if (Vehicle.Rented && Vehicle.Owner == player.Username)
                    {
                        player.vnxSetStreamSharedElementData(HAVE_PLAYER_RENTED_VEHICLE, 0);
                        RageAPI.DeleteVehicleThreadSafe(Vehicle);
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + "[VenoX Rental] : " + RageAPI.GetHexColorcode(255, 255, 255) + "Dein Mietverhältnis wurde beendet!");
                    }
                }
            }
            catch { }
        }

        [Command("stoprent")]
        public void stop_Fahrzeug_Verleih(VnXPlayer player)
        {
            try
            {
                if (player.vnxGetElementData<int>(HAVE_PLAYER_RENTED_VEHICLE) == 1)
                {
                    destroy_Fahrzeug_verleih(player);
                }
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "VenoX Rental : <br>Du hast bei uns kein Fahrzeug gemietet!");
                }
            }
            catch { }
        }

        public static void OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (shape == NoobspawnVerleihColShapeModel || shape == LSPDVerleihCol)
                {
                    anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_VENOXRENTALS);
                    dxLibary.VnX.DrawWindowSelection(player, "VenoX Rentals", "Wilkommen bei VenoX Rentals, <br>hier kannst du dir ein Fahrzeug ausleihen <br>gegen eine geringe Gebühr.", "Roller<br>[75$]", "Smart<br>[119$]");
                }
            }
            catch { }
        }
    }
}
