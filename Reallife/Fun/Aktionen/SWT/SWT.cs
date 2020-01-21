﻿using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using VenoXV.Reallife.Core;
using VenoXV.Reallife.database;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.model;

namespace VenoXV.Reallife.Fun.Aktionen.SWT
{
    public class SWT : IScript
    {

        public static IVehicle SWT_TRUCK { get; set; }
        static Timer SWTTimer = new Timer();


        //[AltV.Net.ClientEvent("Start_SWT_Server")]
        public static void Start_SWT_Server(IPlayer player, int nightstick, int stungun, int pistol, int pistol_ammo, int pistol50, int pistol50_ammo, int pumpshotgun, int pumpshotgun_ammo, int combatpdw, int combatpdw_ammo, int carbinerifle, int carbinerifle_ammo, int advancedrifle, int advancedrifle_ammo, int sniperrifle, int sniperrifle_ammo, int smokegrenade, int totalcost)
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
                Allround.ChangeAktionsState(true);
                Fraktions_Kassen fkasse = Database.GetFactionStats(Constants.FACTION_POLICE);
                if(fkasse.money < totalcost)
                {
                   dxLibary.VnX.DrawNotification(player, "error", "Es ist nicht genug Geld in der Fraktion´s Kasse vorhanden!");
                   return;
                }

                Database.SetFactionStats(Constants.FACTION_POLICE, fkasse.money - totalcost, fkasse.weed, fkasse.koks, fkasse.mats);

                int nightstick_final_value = nightstick;
                int stungun_final_value = stungun;
                int pistol_final_value = pistol;
                int pistol_ammo_final_value = pistol_ammo;


                int pistol50_final_value = pistol50;
                int pistol50_ammo_final_value = pistol50_ammo;
                int pumpshotgun_final_value = pumpshotgun;
                int pumpshotgun_ammo_final_value = pumpshotgun_ammo;


                int combatpdw_final_value = combatpdw;
                int combatpdw_ammo_final_value = combatpdw_ammo;
                int carbinerifle_final_value = carbinerifle;
                int carbinerifle_ammo_final_value = carbinerifle_ammo;


                int advancedrifle_final_value = advancedrifle;
                int advancedrifle_ammo_final_value = advancedrifle_ammo;

                int sniperrifle_final_value = sniperrifle;
                int sniperrifle_ammo_final_value = sniperrifle_ammo;


                int smokegrenade_final_value = smokegrenade;

                if (nightstick_final_value > Constants.NIGHTSTICK_MAX_LAGER) { nightstick_final_value = Constants.NIGHTSTICK_MAX_LAGER; }
                if (stungun_final_value > Constants.STUNGUN_MAX_LAGER) { stungun_final_value = Constants.STUNGUN_MAX_LAGER; }

                if (pistol_final_value > Constants.PISTOL_MAX_LAGER) { pistol_final_value = Constants.PISTOL_MAX_LAGER; }
                if (pistol_ammo_final_value > Constants.PISTOL_AMMO_MAX_LAGER) { pistol_ammo_final_value = Constants.PISTOL_AMMO_MAX_LAGER; }

                if (pistol50_final_value > Constants.PISTOL50_MAX_LAGER) { pistol50_final_value = Constants.PISTOL50_MAX_LAGER; }
                if (pistol50_ammo_final_value > Constants.PISTOL50_AMMO_MAX_LAGER) { pistol50_ammo_final_value = Constants.PISTOL50_AMMO_MAX_LAGER; }

                if (pumpshotgun_final_value > Constants.SHOTGUN_MAX_LAGER) { pumpshotgun_final_value = Constants.SHOTGUN_MAX_LAGER; }
                if (pumpshotgun_ammo_final_value > Constants.SHOTGUN_AMMO_MAX_LAGER) { pumpshotgun_ammo_final_value = Constants.SHOTGUN_AMMO_MAX_LAGER; }

                if (combatpdw_final_value > Constants.COMBATPDW_MAX_LAGER) { combatpdw_final_value = Constants.COMBATPDW_MAX_LAGER; }
                if (combatpdw_ammo_final_value > Constants.COMBATPDW_AMMO_MAX_LAGER) { combatpdw_ammo_final_value = Constants.COMBATPDW_AMMO_MAX_LAGER; }

                if (carbinerifle_final_value > Constants.KARABINER_MAX_LAGER) { carbinerifle_final_value = Constants.KARABINER_MAX_LAGER; }
                if (carbinerifle_ammo_final_value > Constants.KARABINER_AMMO_MAX_LAGER) { carbinerifle_ammo_final_value = Constants.KARABINER_AMMO_MAX_LAGER; }

                if (advancedrifle_final_value > Constants.ADVANCEDRIFLE_MAX_LAGER) { advancedrifle_final_value = Constants.ADVANCEDRIFLE_MAX_LAGER; }
                if (advancedrifle_ammo_final_value > Constants.ADVANCEDRIFLE_AMMO_MAX_LAGER) { advancedrifle_ammo_final_value = Constants.ADVANCEDRIFLE_AMMO_MAX_LAGER; }

                if (sniperrifle_final_value > Constants.SNIPER_MAX_LAGER) { sniperrifle_final_value = Constants.SNIPER_MAX_LAGER; }
                if (sniperrifle_ammo_final_value > Constants.SNIPER_AMMO_MAX_LAGER) { sniperrifle_ammo_final_value = Constants.SNIPER_AMMO_MAX_LAGER; }

                if (smokegrenade_final_value > Constants.TRAENENGAS_MAX_LAGER) { smokegrenade_final_value = Constants.TRAENENGAS_MAX_LAGER; }


                /*player.SendChatMessage("nightstick : " + nightstick);
                player.SendChatMessage("stungun : " + stungun);
                player.SendChatMessage("pistol : " + pistol);
                player.SendChatMessage("pistol_ammo : " + pistol_ammo);
                player.SendChatMessage("pistol50 : " + pistol50);
                player.SendChatMessage("pistol50_ammo : " + pistol50_ammo);
                player.SendChatMessage("pumpshotgun : " + pumpshotgun);
                player.SendChatMessage("pumpshotgun_ammo : " + pumpshotgun_ammo);
                player.SendChatMessage("combatpdw : " + combatpdw);
                player.SendChatMessage("combatpdw_ammo : " + combatpdw_ammo);
                player.SendChatMessage("carbinerifle : " + carbinerifle);
                player.SendChatMessage("carbinerifle_ammo : " + carbinerifle_ammo);
                player.SendChatMessage("advancedrifle : " + advancedrifle);
                player.SendChatMessage("advancedrifle_ammo : " + advancedrifle_ammo);
                player.SendChatMessage("sniperrifle : " + sniperrifle);
                player.SendChatMessage("sniperrifle_ammo : " + sniperrifle_ammo);
                player.SendChatMessage("smokegrenade : " + smokegrenade);*/

                Marker_WT.CreateFactionWTEnter(false, "SWT");
                SWT_TRUCK = Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Terbyte, new Position(1813.723f, 3685.898f, 33.84286f), new Rotation(0,0,115));
                SWT_TRUCK.EngineOn = true;
                SWT_TRUCK.SetData(EntityData.VEHICLE_MODEL, "SWT");
                SWT_TRUCK.SetData(EntityData.VEHICLE_PLATE, "SWT");
                Core.VnX.IVehiclevnxSetSharedData(SWT_TRUCK, "kms", 0);
                Core.VnX.IVehiclevnxSetSharedData(SWT_TRUCK, "gas", 100);
                SWT_TRUCK.NumberplateText = "VenoX";
                SWT_TRUCK.SetData("AKTIONS_FAHRZEUG", true);
                SWT_TRUCK.SetData(EntityData.VEHICLE_NOT_SAVED, true);

                SWT_TRUCK.SetData("nightstick", nightstick_final_value);
                SWT_TRUCK.SetData("stungun", stungun_final_value);
                SWT_TRUCK.SetData("pistol", pistol_final_value);
                SWT_TRUCK.SetData("pistol_ammo", pistol_ammo_final_value);
                SWT_TRUCK.SetData("pistol50", pistol50_final_value);
                SWT_TRUCK.SetData("pistol50_ammo", pistol50_ammo_final_value);
                SWT_TRUCK.SetData("pumpshotgun", pumpshotgun_final_value);
                SWT_TRUCK.SetData("pumpshotgun_ammo", pumpshotgun_ammo_final_value);
                SWT_TRUCK.SetData("combatpdw", combatpdw_final_value);
                SWT_TRUCK.SetData("combatpdw_ammo", combatpdw_ammo_final_value);
                SWT_TRUCK.SetData("carbinerifle", carbinerifle_final_value);
                SWT_TRUCK.SetData("carbinerifle_ammo", carbinerifle_ammo_final_value);
                SWT_TRUCK.SetData("advancedrifle", advancedrifle_final_value);
                SWT_TRUCK.SetData("advancedrifle_ammo", advancedrifle_ammo_final_value);
                SWT_TRUCK.SetData("sniperrifle", sniperrifle_final_value);
                SWT_TRUCK.SetData("sniperrifle_ammo", sniperrifle_ammo_final_value);
                SWT_TRUCK.SetData("smokegrenade", smokegrenade_final_value);
                //player.SetIntoIVehicle(SWT_TRUCK, -1);



                SWTTimer.Elapsed += new ElapsedEventHandler(ChangeActionStateSWT);
                SWTTimer.Interval = 20 * 60000;
                SWTTimer.Enabled = true;

                Reallife.Core.RageAPI.SendChatMessageToAll("!{0,175,0}[Staat] : Ein Staatswaffentruck wurde beladen!");
            }
            catch
            {
            }
        }
        public static void ChangeActionStateSWT(object unused, ElapsedEventArgs e)
        {
            SWTTimer.Stop();
            foreach (IVehicle Vehicle in Alt.GetAllVehicles())
            {
                if (Vehicle.vnxGetElementData<bool>("AKTIONS_FAHRZEUG") == true)
                {
                    Allround.ChangeAktionsTimer(DateTime.Now.AddHours(1));
                    Allround.ChangeAktionsState(false);
                    Reallife.Core.RageAPI.SendChatMessageToAll("!{200,0,0}Der Staatswaffentruck wurde wegen Zeitüberschreitung zerstört!");

                    SWT_TRUCK.Remove();
                }
            }
        }

        public static void FinishSWT(IPlayer player, IVehicle SWT_TRUCK, int FID)
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

                if (FID == Constants.FACTION_POLICE || FID == Constants.FACTION_FBI || FID == Constants.FACTION_USARMY)
                {
                    Database.SetFactionWeaponlager(Constants.FACTION_POLICE, 0, 
                    fraktion.weapon_nightstick + nightstick,
                    0,fraktion.weapon_tazer + stungun, 
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
                    0,0,0,fraktion.weapon_smokegrenade + smokegrenade,
                    fraktion.weapon_pistol_ammo + pistol_ammo,
                    fraktion.weapon_pistol50_ammo + pistol50_ammo,
                    0,
                    fraktion.weapon_pumpshotgun_ammo + pumpshotgun_ammo,
                    fraktion.weapon_combatpdw_ammo + fraktion.weapon_combatpdw_ammo,
                    0,
                    0,
                    fraktion.weapon_carbinerifle_ammo + carbinerifle_ammo,
                    fraktion.weapon_advancedrifle_ammo + advancedrifle_ammo,
                    0,0,fraktion.weapon_sniperrifle_ammo+  sniperrifle_ammo,0
                    );
                }
            }
            catch (Exception ex)
            {
                Alt.Log("[EXCEPTION FinishSWT] " + ex.Message);
                Alt.Log("[EXCEPTION FinishSWT] " + ex.StackTrace);
            }
        }

    }
}
