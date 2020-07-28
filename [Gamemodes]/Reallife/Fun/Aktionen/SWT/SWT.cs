using AltV.Net;
using AltV.Net.Elements.Entities;
using System;
using System.Linq;
using System.Timers;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Fun.Aktionen.SWT
{
    public class SWT : IScript
    {

        public static IVehicle SWT_TRUCK { get; set; }
        static Timer SWTTimer = new Timer();


        //[AltV.Net.ClientEvent("Start_SWT_Server")]

        public static void ChangeActionStateSWT(object unused, ElapsedEventArgs e)
        {
            SWTTimer.Stop();
            foreach (VehicleModel Vehicle in VenoXV.Globals.Main.ReallifeVehicles.ToList())
            {
                if (Vehicle.vnxGetElementData<bool>("AKTIONS_FAHRZEUG") == true)
                {
                    Allround.ChangeAktionsTimer(DateTime.Now.AddHours(1));
                    Allround.ChangeAktionsState(false);
                    RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(200, 0, 0) + "Der Staatswaffentruck wurde wegen Zeitüberschreitung zerstört!");

                    SWT_TRUCK.Remove();
                }
            }
        }

        public static void FinishSWT(Client player, IVehicle SWT_TRUCK, int FID)
        {
            try
            {
                Allround.ChangeAktionsState(false);
                Allround.ChangeAktionsTimer(DateTime.Now.AddHours(1));


                int nightstick = SWT_TRUCK.vnxGetElementData<int>("nightstick");
                int stungun = SWT_TRUCK.vnxGetElementData<int>("stungun");
                int pistol = SWT_TRUCK.vnxGetElementData<int>("pistol");
                int pistol_ammo = SWT_TRUCK.vnxGetElementData<int>("pistol_ammo");
                int pistol50 = SWT_TRUCK.vnxGetElementData<int>("pistol50");
                int pistol50_ammo = SWT_TRUCK.vnxGetElementData<int>("pistol50_ammo");
                int pumpshotgun = SWT_TRUCK.vnxGetElementData<int>("pumpshotgun");
                int pumpshotgun_ammo = SWT_TRUCK.vnxGetElementData<int>("pumpshotgun_ammo");
                int combatpdw = SWT_TRUCK.vnxGetElementData<int>("combatpdw");
                int combatpdw_ammo = SWT_TRUCK.vnxGetElementData<int>("combatpdw_ammo");
                int carbinerifle = SWT_TRUCK.vnxGetElementData<int>("carbinerifle");
                int carbinerifle_ammo = SWT_TRUCK.vnxGetElementData<int>("carbinerifle_ammo");
                int advancedrifle = SWT_TRUCK.vnxGetElementData<int>("advancedrifle");
                int advancedrifle_ammo = SWT_TRUCK.vnxGetElementData<int>("advancedrifle_ammo");
                int sniperrifle = SWT_TRUCK.vnxGetElementData<int>("sniperrifle");
                int sniperrifle_ammo = SWT_TRUCK.vnxGetElementData<int>("sniperrifle_ammo");
                int smokegrenade = SWT_TRUCK.vnxGetElementData<int>("smokegrenade");

                Fraktions_Waffenlager fraktion = Database.GetFactionWaffenlager(FID);

                if (FID == Constants.FACTION_LSPD || FID == Constants.FACTION_FBI || FID == Constants.FACTION_USARMY)
                {
                    Database.SetFactionWeaponlager(Constants.FACTION_LSPD, 0,
                    fraktion.weapon_nightstick + nightstick,
                    0, fraktion.weapon_tazer + stungun,
                    fraktion.weapon_pistol + pistol,
                    fraktion.weapon_pistol50 + pistol50,
                    0,
                    fraktion.weapon_pumpshotgun + pumpshotgun,
                    fraktion.weapon_combatpdw + combatpdw,
                    0,
                    0,
                    fraktion.weapon_carbinerifle + carbinerifle,
                    fraktion.weapon_advancedrifle + advancedrifle,
                    0,
                    0,
                    fraktion.weapon_sniperrifle,
                    0, 0, 0, fraktion.weapon_smokegrenade + smokegrenade,
                    fraktion.weapon_pistol_ammo + pistol_ammo,
                    fraktion.weapon_pistol50_ammo + pistol50_ammo,
                    0,
                    fraktion.weapon_pumpshotgun_ammo + pumpshotgun_ammo,
                    fraktion.weapon_combatpdw_ammo + fraktion.weapon_combatpdw_ammo,
                    0,
                    0,
                    fraktion.weapon_carbinerifle_ammo + carbinerifle_ammo,
                    fraktion.weapon_advancedrifle_ammo + advancedrifle_ammo,
                    0, 0, fraktion.weapon_sniperrifle_ammo + sniperrifle_ammo, 0
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION FinishSWT] " + ex.Message);
                Console.WriteLine("[EXCEPTION FinishSWT] " + ex.StackTrace);
            }
        }

    }
}
