//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//

using System;
using System.Linq;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using VenoX.Core._Gamemodes_.Reallife.quests;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Globals_;
using VenoXV.Core;
using VenoXV.Models;
using EntityData = VenoXV._Globals_.EntityData;
using Main = VenoXV._Notifications_.Main;
using VehicleModel = AltV.Net.Enums.VehicleModel;
using VnX = VenoXV._Gamemodes_.Reallife.dxLibary.VnX;

namespace VenoXV._Gamemodes_.Reallife.Vehicles
{
    public class Verleih : IScript
    {
        public const string CurrentVehicleRent = "CURRENT_VEHICLE_RENT";
        public const string HavePlayerRentedVehicle = "HAVE_PLAYER_RENTED_VEHICLE";
        public static Position NoobspawnRentals = new Position(-2302.477f, 365.9013f, 173.5f);
        public static Position LspdRentals = new Position(333.5797f, -949.9188f, 29.55218f);
        public static int FaggioCosts = 75;
        public static int PantoCosts = 119;

        //Col Creation
        public static ColShapeModel NoobspawnVerleihColShapeModel = RageApi.CreateColShapeSphere(new Position(-2302.628f, 366.7664f, 2), 2);
        public static ColShapeModel LspdVerleihCol = RageApi.CreateColShapeSphere(new Position(333.6211f, -950.823f, 2), 2);
        public static void OnResourceStart()
        {
            RageApi.CreateBlip("VenoX Rental Service", NoobspawnRentals, 545, 3, true);
            RageApi.CreateBlip("VenoX Rental Service", LspdRentals, 545, 3, true);
        }
        
        /// <param name="player">Player who´s the Owner</param>
        /// <param name="roller">Is it A Roller? If No it should be a Panto.</param>
        public static void GetNearestRentalsSpawn(VnXPlayer player, bool roller)
        {
            try
            {
                if (player.Position.Distance(NoobspawnRentals) <= 5)
                {
                    if (roller)
                    {
                        Functions.CreateVehicle(player, VehicleModel.Faggio, new Position(-2282.231f, 404.0836f, 174.4667f), 120f, new Rgba(0, 255, 155, 255), new Rgba(0, 0, 0, 255), true, true, Constants.JobNone, "VenoX");
                    }
                    else
                    {
                        Functions.CreateVehicle(player, VehicleModel.Panto, new Position(-2283.869f, 407.4549f, 174.4667f), 120f, new Rgba(0, 255, 155, 255), new Rgba(0, 0, 0, 255), true, true, Constants.JobNone, "VenoX");
                    }
                }
                else if (player.Position.Distance(LspdRentals) <= 5)
                {
                    if (roller)
                    {
                        Functions.CreateVehicle(player, VehicleModel.Faggio, new Position(340.4336f, -950.1079f, 29.41012f), 120f, new Rgba(0, 255, 155, 255), new Rgba(0, 0, 0, 255), true, true, Constants.JobNone, "VenoX");
                    }
                    else
                    {
                        Functions.CreateVehicle(player, VehicleModel.Panto, new Position(346.5351f, -950.4115f, 29.39716f), 120f, new Rgba(0, 255, 155, 255), new Rgba(0, 0, 0, 255), true, true, Constants.JobNone, "VenoX");
                    }
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        //Function will be called by Lib.
        public static void GivePlayerRentedIVehicle(VnXPlayer player, int value)
        {
            try
            {
                if (player.VnxGetElementData<int>(HavePlayerRentedVehicle) == 0)
                {
                    if (value == 0)
                    {
                        int playerMoney = player.Reallife.Money;
                        if (playerMoney >= FaggioCosts)
                        {
                            player.VnxSetStreamSharedElementData(EntityData.PlayerMoney, playerMoney - FaggioCosts);
                            player.VnxSetStreamSharedElementData(HavePlayerRentedVehicle, 1);
                            player.VnxSetStreamSharedElementData(CurrentVehicleRent, 0);
                            GetNearestRentalsSpawn(player, true);
                            //VnX.CreateCTimer(player, "VnX_Rentals", 60000);
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(Constants.RgbaError + "Du hast nicht genug Geld! ");
                        }
                    }
                    else
                    {
                        int playerMoney = player.Reallife.Money;
                        if (player.Reallife.Money >= PantoCosts)
                        {
                            player.VnxSetStreamSharedElementData(EntityData.PlayerMoney, playerMoney - PantoCosts);
                            player.VnxSetStreamSharedElementData(HavePlayerRentedVehicle, 1);
                            player.VnxSetStreamSharedElementData(CurrentVehicleRent, 1);
                            GetNearestRentalsSpawn(player, false);
                            //VnX.CreateCTimer(player, "VnX_Rentals", 60000);
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(Constants.RgbaError + "Du hast nicht genug Geld!");
                        }
                    }

                }
                else
                {
                    player.SendTranslatedChatMessage("Du hast bereits ein Fahrzeug ausgeliehen!");
                    player.SendTranslatedChatMessage("Warte bis dein Fahrzeug abläuft oder benutze /stoprent !");
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        [Command("updaterent")]
        public void Update_VenoX_Rentals(VnXPlayer player)
        {
            try
            {
                int playerMoney = player.Reallife.Money;
                if (player.VnxGetElementData<int>(CurrentVehicleRent) == 0)
                {
                    if (player.Reallife.Money >= FaggioCosts)
                    {
                        player.VnxSetStreamSharedElementData(EntityData.PlayerMoney, playerMoney - FaggioCosts);
                        VenoX.TriggerClientEvent(player, "VnX_UpdateRent", player);
                    }
                    else
                    {
                        Main.DrawNotification(player, Main.Types.Error, "Du hast nicht genug Geld!");
                    }
                }
                else if (player.VnxGetElementData<int>(CurrentVehicleRent) == 1)
                {
                    if (player.Reallife.Money >= PantoCosts)
                    {
                        player.VnxSetStreamSharedElementData(EntityData.PlayerMoney, playerMoney - PantoCosts);
                        VenoX.TriggerClientEvent(player, "VnX_UpdateRent", player);
                    }
                    else
                    {
                        Main.DrawNotification(player, Main.Types.Error, "Du hast nicht genug Geld!");
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
                foreach (Models.VehicleModel vehicle in _Globals_.Main.ReallifeVehicles.ToList())
                {
                    if (vehicle.Rented && vehicle.Owner == player.Username)
                    {
                        player.VnxSetStreamSharedElementData(HavePlayerRentedVehicle, 0);
                        RageApi.DeleteVehicleThreadSafe(vehicle);
                        player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 255) + "[VenoX Rental] : " + RageApi.GetHexColorcode(255, 255, 255) + "Dein Mietverhältnis wurde beendet!");
                    }
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        [Command("stoprent")]
        public void stop_Fahrzeug_Verleih(VnXPlayer player)
        {
            try
            {
                if (player.VnxGetElementData<int>(HavePlayerRentedVehicle) == 1)
                {
                    destroy_Fahrzeug_verleih(player);
                }
                else
                {
                    Main.DrawNotification(player, Main.Types.Error, "VenoX Rental : <br>Du hast bei uns kein Fahrzeug gemietet!");
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public static bool OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (shape != NoobspawnVerleihColShapeModel || shape != LspdVerleihCol) return false;

                //anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_VENOXRENTALS);
                if (Quests.QuestDict.ContainsKey(Quests.QuestVenoxrentals))
                    Quests.OnQuestDone(player, Quests.QuestDict[Quests.QuestVenoxrentals]);
                VnX.DrawWindowSelection(player, "VenoX Rentals", "Wilkommen bei VenoX Rentals, <br>hier kannst du dir ein Fahrzeug ausleihen <br>gegen eine geringe Gebühr.", "Roller<br>[75$]", "Smart<br>[119$]");
                return true;
            }
            catch { return false; }
        }
    }
}
