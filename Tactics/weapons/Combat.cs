using AltV.Net;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV.Reallife.Core;
using VenoXV.Tactics.globals;

namespace VenoXV.Tactics.weapons
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
        public const float AK47_DAMAGE = 14;
        public const float KARABINER_DAMAGE = 11;
        public const float ADVANCEDRIFLE_DAMAGE = 13;
        public const float RIFLE_DAMAGE = 10;
        public const float SNIPER_DAMAGE = 5;


        // HIT BONE MULE 
        public const string BONE_HEAD = "SKEL_Head"; // Kopf.
        public const float BONE_HEAD_DAMAGE_MUL = 1.9f;
        public const string BONE_BECKEN = "SKEL_Pelvis"; // Auch bekannt als Penis!
        public const float BONE_BECKEN_DAMAGE_MUL = 2.5f;


        public static float GetBoneDamageMul(AltV.Net.Data.BodyPart hitbone)
        {
            try
            {
                if (hitbone == AltV.Net.Data.BodyPart.Head) { return BONE_HEAD_DAMAGE_MUL; }
                else if (hitbone == AltV.Net.Data.BodyPart.Pelvis) { return BONE_BECKEN_DAMAGE_MUL; }
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

        
        public static void OnHittedEntity(IPlayer player, IPlayer target, AltV.Net.Enums.WeaponModel WeaponModel, AltV.Net.Data.BodyPart hitBone)
        {
            try
            {
                target.SetData(EntityData.PLAYER_LAST_DAMAGED_BY, player.GetVnXName<string>());
                if(target.vnxGetElementData<string>(globals.EntityData.PLAYER_CURRENT_TEAM) == player.vnxGetElementData<string>(globals.EntityData.PLAYER_CURRENT_TEAM))
                {
                    return;
                }
                else if(player.vnxGetElementData<bool>(globals.EntityData.PLAYER_IS_DEAD) == true)
                {
                    return;
                }
                else if (target.Health <= 0) // If target is Dead Niggah then he should Return.
                {
                    return;
                }

                Reallife.Core.Debug.OutputDebugString("Target Team : " + target.vnxGetElementData<string>(globals.EntityData.PLAYER_CURRENT_TEAM));
                Reallife.Core.Debug.OutputDebugString("Player Team : " + player.vnxGetElementData<string>(globals.EntityData.PLAYER_CURRENT_TEAM));

                // If Weapon is Sniper && BONE == HEAD THEN KILL DONE
                if (WeaponModel == AltV.Net.Enums.WeaponModel.SniperRifle && hitBone == AltV.Net.Data.BodyPart.Head)
                {
                    target.Health = 0;
                    return;
                }

                float Damage = GetWeaponDamage(WeaponModel); // GetWeaponDamageNiggah
                Damage *= GetBoneDamageMul(hitBone); //Damage * BoneMule , If Bone != Penis or Head then Multiplikator = 1 Niggah.

                IVehicle veh = target.Vehicle; //Get The target IVehicle Nigga
                if (veh != null) // If target is in IVehicle this boi then 
                {
                   /* if (veh.GetSharedData("VEHICLE_HEALTH_SERVER") == null) { veh.vnxSetSharedData("VEHICLE_HEALTH_SERVER", 1000); // Fix if no Value! }
                    float vehdamage = Damage * 2;
                    target.Emit("set_bodyhealth", veh.GetSharedData("VEHICLE_HEALTH_SERVER") - Convert.ToInt32(vehdamage)); // Set The Engine Health from the target Lower.
                    VenoXV.Reallife.Core.VnX.VehiclevnxSetSharedData(veh, "VEHICLE_HEALTH_SERVER", veh.GetSharedData("VEHICLE_HEALTH_SERVER") - vehdamage);*/
                    // Reallife.Core.RageAPI.SendChatMessageToAll("IVehicle Health : " + veh.GetSharedData("VEHICLE_HEALTH_SERVER"));
                }
                else
                {
                    
                    player.SetData(globals.EntityData.PLAYER_DAMAGE_DONE, player.vnxGetElementData<float>(globals.EntityData.PLAYER_DAMAGE_DONE) + Damage);
                    player.SetSyncedMetaData(globals.EntityData.PLAYER_DAMAGE_DONE, player.vnxGetElementData<float>(globals.EntityData.PLAYER_DAMAGE_DONE) + Damage);
                    //Reallife.Core.VnX.vnxSetSharedData(player,globals.EntityData.PLAYER_DAMAGE_DONE, player.vnxGetElementData<float>(globals.EntityData.PLAYER_DAMAGE_DONE) + Damage);
                    player.Emit("Globals:PlayHitsound");
                    if (target.Armor > 0)
                    {
                        int Adiff = target.Armor - Convert.ToInt32(Damage);
                        if (Adiff <= 0)
                        {
                            target.Health += (ushort)Adiff;
                            target.Armor = 0;
                        }
                        else
                        {
                            target.Armor -= (ushort)Damage;
                        }
                    }
                    else
                    {
                        target.Health -= (ushort)Damage;
                    }
                    Lobby.Main.SyncPlayerStats();
                }

            }
            catch {}
        }
    }
}
