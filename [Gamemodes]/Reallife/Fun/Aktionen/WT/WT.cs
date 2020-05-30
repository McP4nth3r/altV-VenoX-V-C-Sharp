using AltV.Net;
using AltV.Net.Elements.Entities;
using System;
using System.Timers;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Globals_.EntityDatas;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Fun.Aktionen.WT
{
    public class WT : IScript
    {

        public static IVehicle WT_TRUCK { get; set; }
        static Timer WTTimer = new Timer();

        public static void ChangeActionStateWT(object unused, ElapsedEventArgs e)
        {
            WTTimer.Stop();
            foreach (VehicleModel Vehicle in Alt.GetAllVehicles())
            {
                if (Vehicle.vnxGetElementData<bool>("AKTIONS_FAHRZEUG") == true)
                {
                    Allround.ChangeAktionsTimer(DateTime.Now.AddHours(1));
                    Allround.ChangeAktionsState(false);
                    RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(175, 175, 175) + "Der Waffentruck wurde wegen Zeitüberschreitung zerstört!");
                    WT_TRUCK.Remove();
                }
            }
        }

        public static void FinishWT(Client player, IVehicle WT_TRUCK, int FID)
        {
            try
            {
                Allround.ChangeAktionsState(false);
                Allround.ChangeAktionsTimer(DateTime.Now.AddHours(1));


                int baseball = WT_TRUCK.vnxGetElementData<int>(EntityData.WEAPON_BASEBALL);
                int pistol = WT_TRUCK.vnxGetElementData<int>(EntityData.WEAPON_PISTOL);
                int pistol_ammo = WT_TRUCK.vnxGetElementData<int>(EntityData.WEAPON_PISTOL_AMMO);
                int pistol50 = WT_TRUCK.vnxGetElementData<int>(EntityData.WEAPON_PISTOL50);
                int pistol50_ammo = WT_TRUCK.vnxGetElementData<int>(EntityData.WEAPON_PISTOL50_AMMO);
                int revolver = WT_TRUCK.vnxGetElementData<int>(EntityData.WEAPON_REVOLVER);
                int revolver_ammo = WT_TRUCK.vnxGetElementData<int>(EntityData.WEAPON_REVOLVER_AMMO);
                int mp5 = WT_TRUCK.vnxGetElementData<int>(EntityData.WEAPON_MP5);
                int mp5_ammo = WT_TRUCK.vnxGetElementData<int>(EntityData.WEAPON_MP5_AMMO);
                int ak47 = WT_TRUCK.vnxGetElementData<int>(EntityData.WEAPON_AK47);
                int ak47_ammo = WT_TRUCK.vnxGetElementData<int>(EntityData.WEAPON_AK47_AMMO);
                //int gusenberg_ammo = WT_TRUCK.vnxGetElementData("gusenberg_ammo");
                int gusenberg_ammo = 0;
                int rifle = WT_TRUCK.vnxGetElementData<int>(EntityData.WEAPON_RIFLE);
                int rifle_ammo = WT_TRUCK.vnxGetElementData<int>(EntityData.WEAPON_RIFLE_AMMO);
                int sniperrifle = WT_TRUCK.vnxGetElementData<int>(EntityData.WEAPON_SNIPERRIFLE);
                int sniperrifle_ammo = WT_TRUCK.vnxGetElementData<int>(EntityData.WEAPON_SNIPERRIFLE_AMMO);

                int rpg = WT_TRUCK.vnxGetElementData<int>(EntityData.WEAPON_RPG);
                int rpg_ammo = WT_TRUCK.vnxGetElementData<int>(EntityData.WEAPON_RPG_AMMO);


                int molotov = WT_TRUCK.vnxGetElementData<int>(EntityData.WEAPON_MOLOTOV);

                Fraktions_Waffenlager fraktion = Database.GetFactionWaffenlager(FID);

                if (FID > 0)
                {
                    Database.SetFactionWeaponlager(FID, 0, 0, fraktion.weapon_baseball + baseball, 0, fraktion.weapon_pistol + pistol, fraktion.weapon_pistol50 + pistol50,
                        fraktion.weapon_revolver + revolver, 0, 0, fraktion.weapon_mp5 + mp5, fraktion.weapon_assaultrifle + ak47, 0, 0, fraktion.weapon_gusenberg + gusenberg_ammo, fraktion.weapon_rifle + rifle, fraktion.weapon_sniperrifle + sniperrifle,
                        fraktion.weapon_rpg + rpg, 0, fraktion.weapon_molotov + molotov, 0, fraktion.weapon_pistol_ammo + pistol_ammo, fraktion.weapon_pistol50_ammo + pistol50_ammo,
                        fraktion.weapon_revolver_ammo + revolver_ammo, 0, 0, fraktion.weapon_mp5_ammo + mp5_ammo, fraktion.weapon_assaultrifle_ammo + ak47_ammo, 0, 0, fraktion.weapon_gusenberg + gusenberg_ammo, fraktion.weapon_rifle_ammo + rifle_ammo, fraktion.weapon_sniperrifle_ammo + sniperrifle_ammo, fraktion.weapon_rpg_ammo + rpg_ammo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION FinishWT] " + ex.Message);
                Console.WriteLine("[EXCEPTION FinishWT] " + ex.StackTrace);
            }
        }

    }
}
