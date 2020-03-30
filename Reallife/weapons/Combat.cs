using AltV.Net;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV.Core;
using VenoXV.Reallife.Globals;

namespace VenoXV.Reallife.weapons
{
    public class Combat : IScript
    {
        public static Dictionary<AltV.Net.Enums.WeaponModel, float> DamageValues;

        // WEAPON DAMAGE SYSTEM
        public const float TAZER_DAMAGE = 1;
        public const float PISTOL_DAMAGE = 15;
        public const float PISTOL50_DAMAGE = 25;
        public const float REVOLVER_DAMAGE = 30;
        public const float SHOTGUN_DAMAGE = 40;
        public const float PDW_DAMAGE = 12;
        public const float MP5_DAMAGE = 9;
        public const float MINISMG_DAMAGE = 7;
        public const float AK47_DAMAGE = 14;
        public const float KARABINER_DAMAGE = 11;
        public const float ADVANCEDRIFLE_DAMAGE = 13;
        public const float RIFLE_DAMAGE = 10;
        public const float SNIPER_DAMAGE = 50;


        // HIT BONE MULE 
        public const string BONE_HEAD = "SKEL_Head"; // Kopf.
        public const float BONE_HEAD_DAMAGE_MUL = 1.9f;
        public const string BONE_BECKEN = "SKEL_Pelvis"; // Auch bekannt als Penis!
        public const float BONE_BECKEN_DAMAGE_MUL = 2.5f;


        public static float GetBoneDamageMul(string hitbone)
        {
            try
            {
                if (hitbone == BONE_HEAD) { return BONE_HEAD_DAMAGE_MUL; }
                else if (hitbone == BONE_BECKEN) { return BONE_BECKEN_DAMAGE_MUL; }
                else { return 1; }
            }
            catch { return 1; }
        }

        public static void OnResourceStart()
        {
            DamageValues = new Dictionary<AltV.Net.Enums.WeaponModel, float>();
            DamageValues.Add(AltV.Net.Enums.WeaponModel.StunGun, TAZER_DAMAGE); // Tazer
            DamageValues.Add(AltV.Net.Enums.WeaponModel.Pistol, PISTOL_DAMAGE); // Pistol
            DamageValues.Add(AltV.Net.Enums.WeaponModel.Pistol50, PISTOL50_DAMAGE); // Pistol50
            DamageValues.Add(AltV.Net.Enums.WeaponModel.HeavyRevolver, REVOLVER_DAMAGE); // Revolver
            DamageValues.Add(AltV.Net.Enums.WeaponModel.PumpShotgun, SHOTGUN_DAMAGE); // Shotgun (Ammu & State )
            DamageValues.Add(AltV.Net.Enums.WeaponModel.CombatPDW, PDW_DAMAGE);  // PDW DAMAGE
            DamageValues.Add(AltV.Net.Enums.WeaponModel.MiniSMG, MINISMG_DAMAGE); // MINISMG DAMAGE
            DamageValues.Add(AltV.Net.Enums.WeaponModel.SMG, MP5_DAMAGE); // MP5 DAMAGE
            DamageValues.Add(AltV.Net.Enums.WeaponModel.AssaultRifle, AK47_DAMAGE); // Ak-47 DAMAGE
            DamageValues.Add(AltV.Net.Enums.WeaponModel.CarbineRifle, KARABINER_DAMAGE); // M4A1 - KARABINER DAMAGE
            DamageValues.Add(AltV.Net.Enums.WeaponModel.AdvancedRifle, ADVANCEDRIFLE_DAMAGE); // ADVANCEDRIFLE - KAMPFGEWEHR DAMAGE
            DamageValues.Add(AltV.Net.Enums.WeaponModel.Musket, RIFLE_DAMAGE); // MUSKET - RIFLE DAMAGE
            DamageValues.Add(AltV.Net.Enums.WeaponModel.SniperRifle, SNIPER_DAMAGE); // SNIPERRIFLE - DAMAGE
        }

        public static float GetWeaponDamage(AltV.Net.Enums.WeaponModel Weapon)
        {
            try
            {
                return DamageValues[Weapon];
            }
            catch { return 1; }
        }


        //[AltV.Net.ClientEvent("OnHittedEntity")]
        public static void OnHittedEntity(IPlayer player, string target_name, string currentWeapon, string hitBone)
        {
            try
            {
                
                // DEBUG - DEV
                /*
                NAPI.Chat.SendChatMessageToAll("Hitbone : " + hitBone);
                NAPI.Chat.SendChatMessageToAll("target : " + target.GetVnXName<string>());
                NAPI.Chat.SendChatMessageToAll("currentWeapon : " + currentWeapon);*/
                /*
                if (target != null) // If Target is a Real Player Niggah
                {

                    if (player.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_GAMEMODE) == EntityData.GAMEMODE_TACTICS && target.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_GAMEMODE) == EntityData.GAMEMODE_TACTICS)
                    {
                        Tactics.weapons.Combat.OnHittedEntity(player, target, currentWeapon, hitBone);
                        return;
                    }

                    AltV.Net.Enums.WeaponModel WeaponHash = (AltV.Net.Enums.WeaponModel)Enum.Parse(typeof(AltV.Net.Enums.WeaponModel), currentWeapon, true);
                    
                    if (currentWeapon == "Pistol") { WeaponHash = AltV.Net.Enums.WeaponModel.Pistol; }
                    else if (currentWeapon == "Tazer") { WeaponHash = AltV.Net.Enums.WeaponModel.StunGun; }
                    else if (currentWeapon == "Revolver") { WeaponHash = AltV.Net.Enums.WeaponModel.HeavyRevolver; }
                    else if (currentWeapon == "Pistol 50.") { WeaponHash = AltV.Net.Enums.WeaponModel.Pistol50; }
                    else if (currentWeapon == "Einsatz PDW") { WeaponHash = AltV.Net.Enums.WeaponModel.CombatPDW; }
                    else if (currentWeapon == "MP") { WeaponHash = AltV.Net.Enums.WeaponModel.SMG; }
                    else if (currentWeapon == "Kampfgewehr") { WeaponHash = AltV.Net.Enums.WeaponModel.AdvancedRifle; }
                    else if (currentWeapon == "Karabiner") { WeaponHash = AltV.Net.Enums.WeaponModel.CarbineRifle; }
                    else if (currentWeapon == "Pump Shotgun") { WeaponHash = AltV.Net.Enums.WeaponModel.PumpShotgun; }
                    else if (currentWeapon == "Sniper") { WeaponHash = AltV.Net.Enums.WeaponModel.SniperRifle; }

                    if (WeaponHash != AltV.Net.Enums.WeaponModel.Fist)
                    {
                        if (target.vnxGetElementData<int>(EntityData.PLAYER_ADMIN_ON_DUTY) != 1) // Cancel Events for Aduty Players!
                        {
                            if (target.Health <= 0) // If Target is Dead Niggah then he should Return.
                            {
                                return;
                            }

                            // If Weapon is Sniper && BONE == HEAD THEN KILL DONE
                            if (WeaponHash == AltV.Net.Enums.WeaponModel.SniperRifle && hitBone == BONE_HEAD)
                            {
                                target.Health = 0;
                                target.SetData("PLAYER_GOT_HITTED", true);
                                Core.VnX.SetDelayedBoolSharedData(target, "PLAYER_GOT_HITTED", false, 30000);
                                player.Emit("log_dmg_ped", target, currentWeapon, 200);
                                if (target.Health <= 0)
                                {
                                    Environment.Death.OnPlayerDeath(target, player, 0);
                                }
                                Core.VnX.UpdateHUDArmorHealth(target);
                                return;
                            }

                            float Damage = GetWeaponDamage(WeaponHash); // GetWeaponDamageNiggah
                            Damage *= GetBoneDamageMul(hitBone); //Damage * BoneMule , If Bone != Penis or Head then Multiplikator = 1 Niggah.

                            IVehicle veh = target.Vehicle; //Get The Target IVehicle Nigga
                            if (veh != null) // If Target is in IVehicle this boi then 
                            {
                                //ToDo what if it´s nil ? if (veh.vnxGetSharedData<int>("VEHICLE_HEALTH_SERVER") == false) { veh.SetSyncedMetaData("VEHICLE_HEALTH_SERVER", 1000); /* Fix if no Value! }
                                float vehdamage = Damage * 2;
                                target.Emit("set_bodyhealth", veh.vnxGetSharedData<int>("VEHICLE_HEALTH_SERVER") - Convert.ToInt32(vehdamage)); // Set The Engine Health from the Target Lower.
                                Environment.Death.Log_Damage_veh(player, target, currentWeapon.ToString(), veh.vnxGetSharedData<int>("VEHICLE_HEALTH_SERVER") - vehdamage + );
                                veh.SetSyncedMetaData("VEHICLE_HEALTH_SERVER", veh.vnxGetSharedData<int>("VEHICLE_HEALTH_SERVER") - vehdamage);
                                // NAPI.Chat.SendChatMessageToAll("IVehicle Health : " + veh.GetSharedData("VEHICLE_HEALTH_SERVER"));
                            }
                            else
                            {
                                gangwar.Allround.ProcessDamage(player, target, Damage);
                                if (target.Armor > 0)
                                {
                                    ulong Adiff = target.Armor - Damage;
                                    if (Adiff <= 0)
                                    {
                                        target.Health += Adiff;
                                        target.Armor = 0;
                                        player.Emit("log_dmg_ped", target, currentWeapon, Convert.ToInt32(Damage));
                                    }
                                    else
                                    {
                                        target.Armor -= Convert.ToInt32(Damage);
                                        player.Emit("log_dmg_ped", target, currentWeapon, Convert.ToInt32(Damage));
                                    }
                                }
                                else
                                {
                                    target.Health -= Convert.ToInt32(Damage);
                                    if (target.Health <= 0
                                    {
                                        Environment.Death.OnPlayerDeath(target, player, 0);
                                        gangwar.Allround.ProcessKill(player, target);
                                    }
                                    player.Emit("log_dmg_ped", target, currentWeapon, Convert.ToInt32(Damage));
                                    target.SetData("PLAYER_GOT_HITTED", true);
                                    Core.VnX.SetDelayedBoolSharedData(target, "PLAYER_GOT_HITTED", false, 30000);
                                }
                                Core.VnX.UpdateHUDArmorHealth(target);
                            }
                        }
                    }

                }*/
            }
            catch
            {
            }
        }
    }
}
