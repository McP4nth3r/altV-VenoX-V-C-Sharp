using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using VenoXV.Core;
using VenoXV.Reallife.database;
using VenoXV.Reallife.Fun.Aktionen.SWT;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.model;

namespace VenoXV.Reallife.Fun.Aktionen.WT
{
    public class WT : IScript
    {

        public static IVehicle WT_TRUCK { get; set; }
        static Timer WTTimer = new Timer();


        //[AltV.Net.ClientEvent("Start_WT_Server")]
        public static void Start_WT_Server(IPlayer player, int baseball, int pistol, int pistol_ammo, int pistol50, int pistol50_ammo, int revolver, int revolver_ammo, int mp5, int mp5_ammo, int ak47, int ak47_ammo, int rifle, int rifle_ammo, int sniperrifle, int sniperrifle_ammo, int rpg, int rpg_ammo, int molotov, int totalcost)
        {
            try
            {
                if (Allround.isAktionPossible(player) == false)
                {
                    return;
                }
                else if (Allround.AktionAmLaufen(player))
                {
                    return;
                }
                Fraktions_Kassen fkasse = Database.GetFactionStats(player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                if(fkasse.money < totalcost)
                {
                   dxLibary.VnX.DrawNotification(player, "error", "Es ist nicht genug Geld in der Fraktion´s Kasse vorhanden!");
                   return;
                }
                Allround.ChangeAktionsState(true);

                Database.SetFactionStats(player.vnxGetElementData<int>(EntityData.PLAYER_FACTION), fkasse.money - totalcost, fkasse.weed, fkasse.koks, fkasse.mats);

                int baseball_final_value = baseball;
                int pistol_final_value = pistol;
                int pistol_ammo_final_value = pistol_ammo;


                int pistol50_final_value = pistol50;
                int pistol50_ammo_final_value = pistol50_ammo;

                int revolver_final_value = revolver;
                int revolver_ammo_final_value = revolver_ammo;

                int mp5_final_value = mp5;
                int mp5_ammo_final_value = mp5_ammo;


                int ak47_final_value = ak47;
                int ak47_ammo_final_value = ak47_ammo;
                int rifle_final_value = rifle;
                int rifle_ammo_final_value = rifle_ammo;




                int sniperrifle_final_value = sniperrifle;
                int sniperrifle_ammo_final_value = sniperrifle_ammo;

                int rpg_final_value = rpg;
                int rpg_ammo_final_value = rpg_ammo;


                int molotov_final_value = molotov;

                if (baseball_final_value > Constants.BASEBALL_MAX_LAGER) { baseball_final_value = Constants.BASEBALL_MAX_LAGER; }

                if (pistol_final_value > Constants.PISTOL_MAX_LAGER) { pistol_final_value = Constants.PISTOL_MAX_LAGER; }
                if (pistol_ammo_final_value > Constants.PISTOL_AMMO_MAX_LAGER) { pistol_ammo_final_value = Constants.PISTOL_AMMO_MAX_LAGER; }

                if (pistol50_final_value > Constants.PISTOL50_MAX_LAGER) { pistol50_final_value = Constants.PISTOL50_MAX_LAGER; }
                if (pistol50_ammo_final_value > Constants.PISTOL50_AMMO_MAX_LAGER) { pistol50_ammo_final_value = Constants.PISTOL50_AMMO_MAX_LAGER; }

                if (revolver_final_value > Constants.REVOLVER_MAX_LAGER) { revolver_final_value = Constants.REVOLVER_MAX_LAGER; }
                if (revolver_ammo_final_value > Constants.REVOLVER_AMMO_MAX_LAGER) { revolver_ammo_final_value = Constants.REVOLVER_AMMO_MAX_LAGER; }

                if (mp5_final_value > Constants.SHOTGUN_MAX_LAGER) { mp5_final_value = Constants.SHOTGUN_MAX_LAGER; }
                if (mp5_ammo_final_value > Constants.SHOTGUN_AMMO_MAX_LAGER) { mp5_ammo_final_value = Constants.SHOTGUN_AMMO_MAX_LAGER; }

                if (ak47_final_value > Constants.AK47_MAX_LAGER) { ak47_final_value = Constants.AK47_MAX_LAGER; }
                if (ak47_ammo_final_value > Constants.AK47_AMMO_MAX_LAGER) { ak47_ammo_final_value = Constants.AK47_AMMO_MAX_LAGER; }

                if (rifle_final_value > Constants.KARABINER_MAX_LAGER) { rifle_final_value = Constants.KARABINER_MAX_LAGER; }
                if (rifle_ammo_final_value > Constants.KARABINER_AMMO_MAX_LAGER) { rifle_ammo_final_value = Constants.KARABINER_AMMO_MAX_LAGER; }

               

                if (sniperrifle_final_value > Constants.SNIPER_MAX_LAGER) { sniperrifle_final_value = Constants.SNIPER_MAX_LAGER; }
                if (sniperrifle_ammo_final_value > Constants.SNIPER_AMMO_MAX_LAGER) { sniperrifle_ammo_final_value = Constants.SNIPER_AMMO_MAX_LAGER; }

                if (rpg_final_value > Constants.RPG_MAX_LAGER) { sniperrifle_final_value = Constants.RPG_MAX_LAGER; }
                if (rpg_ammo_final_value > Constants.RPG_AMMO_MAX_LAGER) { sniperrifle_ammo_final_value = Constants.RPG_AMMO_MAX_LAGER; }

                if (molotov_final_value > Constants.TRAENENGAS_MAX_LAGER) { molotov_final_value = Constants.TRAENENGAS_MAX_LAGER; }


                /*player.SendChatMessage("baseball : " + baseball);
                player.SendChatMessage("stungun : " + stungun);
                player.SendChatMessage("pistol : " + pistol);
                player.SendChatMessage("pistol_ammo : " + pistol_ammo);
                player.SendChatMessage("pistol50 : " + pistol50);
                player.SendChatMessage("pistol50_ammo : " + pistol50_ammo);
                player.SendChatMessage("mp5 : " + mp5);
                player.SendChatMessage("mp5_ammo : " + mp5_ammo);
                player.SendChatMessage("ak47 : " + ak47);
                player.SendChatMessage("ak47_ammo : " + ak47_ammo);
                player.SendChatMessage("rifle : " + rifle);
                player.SendChatMessage("rifle_ammo : " + rifle_ammo);
                player.SendChatMessage("advancedrifle : " + advancedrifle);
                player.SendChatMessage("advancedrifle_ammo : " + advancedrifle_ammo);
                player.SendChatMessage("sniperrifle : " + sniperrifle);
                player.SendChatMessage("sniperrifle_ammo : " + sniperrifle_ammo);
                player.SendChatMessage("smokegrenade : " + smokegrenade);*/






                Marker_WT.CreateFactionWTEnter(false, "WT");
                WT_TRUCK = Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Terbyte, new Position(2861.777f, 1519.65f, 24.56755f), new Rotation(0,0,70f));
                WT_TRUCK.EngineOn = true;
                WT_TRUCK.SetData(EntityData.VEHICLE_MODEL, "WT");
                WT_TRUCK.SetData(EntityData.VEHICLE_PLATE, "WT");
                Core.VnX.VehiclevnxSetSharedData(WT_TRUCK, "kms", 0);
                Core.VnX.VehiclevnxSetSharedData(WT_TRUCK, "gas", 100);
                WT_TRUCK.NumberplateText = "VenoX";
                WT_TRUCK.SetData("AKTIONS_FAHRZEUG", true);
                WT_TRUCK.SetData(EntityData.VEHICLE_NOT_SAVED, true);

                WT_TRUCK.SetData(EntityData.WEAPON_BASEBALL, baseball_final_value);
                WT_TRUCK.SetData(EntityData.WEAPON_PISTOL, pistol_final_value);
                WT_TRUCK.SetData(EntityData.WEAPON_PISTOL_AMMO, pistol_ammo_final_value);
                WT_TRUCK.SetData(EntityData.WEAPON_PISTOL50, pistol50_final_value);
                WT_TRUCK.SetData(EntityData.WEAPON_PISTOL50_AMMO, pistol50_ammo_final_value);
                WT_TRUCK.SetData(EntityData.WEAPON_REVOLVER, revolver_final_value);
                WT_TRUCK.SetData(EntityData.WEAPON_REVOLVER_AMMO, revolver_ammo_final_value);
                WT_TRUCK.SetData(EntityData.WEAPON_MP5, mp5_final_value);
                WT_TRUCK.SetData(EntityData.WEAPON_MP5_AMMO, mp5_ammo_final_value);
                WT_TRUCK.SetData(EntityData.WEAPON_AK47, ak47_final_value);
                WT_TRUCK.SetData(EntityData.WEAPON_AK47_AMMO, ak47_ammo_final_value);
                WT_TRUCK.SetData(EntityData.WEAPON_RIFLE, rifle_final_value);
                WT_TRUCK.SetData(EntityData.WEAPON_RIFLE_AMMO, rifle_ammo_final_value);
                WT_TRUCK.SetData(EntityData.WEAPON_SNIPERRIFLE, sniperrifle_final_value);
                WT_TRUCK.SetData(EntityData.WEAPON_SNIPERRIFLE_AMMO, sniperrifle_ammo_final_value);
                WT_TRUCK.SetData(EntityData.WEAPON_RPG, rpg_final_value);
                WT_TRUCK.SetData(EntityData.WEAPON_RPG_AMMO, rpg_ammo_final_value);
                WT_TRUCK.SetData(EntityData.WEAPON_MOLOTOV, molotov_final_value);
                //player.SetIntoIVehicle(WT_TRUCK, -1);



                WTTimer.Elapsed += new ElapsedEventHandler(ChangeActionStateWT);
                WTTimer.Interval = 20 * 60000;
                WTTimer.Enabled = true;

                RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(175,0,0) + "[Illegal]: Ein Waffentruck wurde beladen!");
            }
            catch
            {
            }
        }
        public static void ChangeActionStateWT(object unused, ElapsedEventArgs e)
        {
            WTTimer.Stop();
            foreach (IVehicle Vehicle in Alt.GetAllVehicles())
            {
                if (Vehicle.vnxGetElementData<bool>("AKTIONS_FAHRZEUG") == true)
                {
                    Allround.ChangeAktionsTimer(DateTime.Now.AddHours(1));
                    Allround.ChangeAktionsState(false);
                    RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(175,175,175)+"Der Waffentruck wurde wegen Zeitüberschreitung zerstört!");
                    WT_TRUCK.Remove();
                }
            }
        }

        public static void FinishWT(IPlayer player, IVehicle WT_TRUCK, int FID)
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
