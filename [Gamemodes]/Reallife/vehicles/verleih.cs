//----------------------------------//
///// VenoX Gaming & Fun 2019 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
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
        public static IColShape NoobspawnVerleihIColShape = Alt.CreateColShapeSphere(new Position(-2302.628f, 366.7664f, 2), 2);
        public static IColShape LSPDVerleihCol = Alt.CreateColShapeSphere(new Position(333.6211f, -950.823f, 2), 2);
        public static void OnResourceStart()
        {
            // Noobspawn
            /*Blip NoobspawnVerleih = 
             * (NOOBSPAWN_RENTALS);
            NoobspawnVerleih.Name = "VenoX Rental Service";
            NoobspawnVerleih.Sprite = 545;
            NoobspawnVerleih.Rgba = 3;
            // LSPD
            Blip LSPDVerleih = NAPI.Blip.CreateBlip(LSPD_RENTALS);
            LSPDVerleih.Name = "VenoX Rental Service";
            LSPDVerleih.Sprite = 545;
            LSPDVerleih.Rgba = 3;
            NAPI.Object.CreateObject(1000639787, new Position(NOOBSPAWN_RENTALS.X, NOOBSPAWN_RENTALS.Y, NOOBSPAWN_RENTALS.Z - 1), new Position(0.0f, 0.0f, 0.0f), 0);
            NAPI.Object.CreateObject(1000639787, new Position(LSPD_RENTALS.X, LSPD_RENTALS.Y, LSPD_RENTALS.Z - 1), new Position(0.0f, 0.0f, 180f), 0);*/

            BlipModel blip = new BlipModel();
            Position pos = NOOBSPAWN_RENTALS;
            blip.Name = "VenoX Rental Service";
            blip.posX = pos.X;
            blip.posY = pos.Y;
            blip.posZ = pos.Z;
            blip.Sprite = 545;
            blip.Color = 3;
            blip.ShortRange = true;
            VenoXV.Globals.Functions.BlipList.Add(blip);

            BlipModel blip1 = new BlipModel();
            Position pos1 = LSPD_RENTALS;
            blip1.Name = "VenoX Rental Service";
            blip1.posX = pos1.X;
            blip1.posY = pos1.Y;
            blip1.posZ = pos1.Z;
            blip1.Sprite = 545;
            blip1.Color = 3;
            blip1.ShortRange = true;
            VenoXV.Globals.Functions.BlipList.Add(blip1);
        }





        /// <param name="player">Player who´s the Owner</param>
        /// <param name="Roller">Is it A Roller? If No it should be a Panto.</param>
        public static void GetNearestRentalsSpawn(PlayerModel player, bool Roller)
        {
            try
            {
                if (player.position.Distance(NOOBSPAWN_RENTALS) <= 5)
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
                else if (player.position.Distance(LSPD_RENTALS) <= 5)
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
        public static void GivePlayerRentedIVehicle(PlayerModel player, int value)
        {
            try
            {
                if (player.vnxGetElementData<int>(HAVE_PLAYER_RENTED_VEHICLE) == 0)
                {
                    if (value == 0)
                    {
                        int playerMoney = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY);
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
                            player.SendChatMessage(Constants.Rgba_ERROR + "Du hast nicht genug Geld! ");
                        }
                    }
                    else
                    {
                        int playerMoney = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY);
                        if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) >= PANTO_COSTS)
                        {
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playerMoney - PANTO_COSTS);
                            player.vnxSetStreamSharedElementData(HAVE_PLAYER_RENTED_VEHICLE, 1);
                            player.vnxSetStreamSharedElementData(CURRENT_VEHICLE_RENT, 1);
                            GetNearestRentalsSpawn(player, false);
                            //VnX.CreateCTimer(player, "VnX_Rentals", 60000);
                        }
                        else
                        {
                            player.SendChatMessage(Constants.Rgba_ERROR + "Du hast nicht genug Geld!");
                        }
                    }

                }
                else
                {
                    player.SendChatMessage("Du hast bereits ein Fahrzeug ausgeliehen!");
                    player.SendChatMessage("Warte bis dein Fahrzeug abläuft oder benutze /stoprent !");
                }
            }
            catch { }
        }

        [Command("updaterent")]
        public void Update_VenoX_Rentals(PlayerModel player)
        {
            try
            {
                int playerMoney = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY);
                if (player.vnxGetElementData<int>(CURRENT_VEHICLE_RENT) == 0)
                {
                    if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) >= FAGGIO_COSTS)
                    {
                        player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playerMoney - FAGGIO_COSTS);
                        player.Emit("VnX_UpdateRent", player);
                    }
                    else
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
                    }
                }
                else if (player.vnxGetElementData<int>(CURRENT_VEHICLE_RENT) == 1)
                {
                    if (player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY) >= PANTO_COSTS)
                    {
                        player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playerMoney - PANTO_COSTS);
                        player.Emit("VnX_UpdateRent", player);
                    }
                    else
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Du hast nicht genug Geld!");
                    }
                }
            }
            catch
            {
            }
        }

        //[AltV.Net.ClientEvent("Destroy_Verleih_Rentals")]
        public void destroy_Fahrzeug_verleih(PlayerModel player)
        {
            try
            {
                foreach (IVehicle Vehicle in Alt.GetAllVehicles())
                {
                    if (Vehicle.vnxGetElementData<bool>(VenoXV.Globals.EntityData.VEHICLE_RENTED) == true && Vehicle.vnxGetElementData<string>(VenoXV.Globals.EntityData.VEHICLE_OWNER) == player.GetVnXName())
                    {
                        player.vnxSetStreamSharedElementData(HAVE_PLAYER_RENTED_VEHICLE, 0);
                        Vehicle.Remove();
                        player.SendChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + "[VenoX Rental] : " + RageAPI.GetHexColorcode(255, 255, 255) + "Dein Mietverhältnis wurde beendet!");
                    }
                }
            }
            catch { }
        }

        [Command("stoprent")]
        public void stop_Fahrzeug_Verleih(PlayerModel player)
        {
            try
            {
                if (player.vnxGetElementData<int>(HAVE_PLAYER_RENTED_VEHICLE) == 1)
                {
                    destroy_Fahrzeug_verleih(player);
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "VenoX Rental : <br>Du hast bei uns kein Fahrzeug gemietet!");
                }
            }
            catch { }
        }

        public static void OnPlayerEnterIColShape(IColShape shape, PlayerModel player)
        {
            try
            {
                if (shape == NoobspawnVerleihIColShape || shape == LSPDVerleihCol)
                {
                    anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_VENOXRENTALS);
                    dxLibary.VnX.DrawWindowSelection(player, "VenoX Rentals", "Wilkommen bei VenoX Rentals, <br>hier kannst du dir ein Fahrzeug ausleihen <br>gegen eine geringe Gebühr.", "Roller<br>[75$]", "Smart<br>[119$]");
                }
            }
            catch { }
        }
    }
}
