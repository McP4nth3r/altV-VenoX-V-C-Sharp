using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV.Reallife.Core;

namespace VenoXV.Globals
{
    public class Globals : IScript
    {
        public static void OnResourceStart()
        {
            try
            {
                Reallife.Globals.Main.OnResourceStart();
                Tactics.globals.Globals.OnResourceStart();
                SevenTowers.Lobby.Main.OnResourceStart();
            }
            catch { }
        }

        [ScriptEvent(ScriptEventType.ColShape)]
        public static void OnColShape(IColShape shape, IEntity entity, bool state)
        {
            try
            {
                IPlayer player = entity as IPlayer;
                if (state)  { Reallife.Globals.Main.OnPlayerEnterIColShape(shape, player); }
                else        { Reallife.Globals.Main.OnPlayerExitIColShape(shape, player); }
            }
            catch{}
        }

        [ScriptEvent(ScriptEventType.PlayerDead)]
        public static void OnPlayerDeath(IPlayer player, IPlayer killer, uint reason)
        {
            if (player.vnxGetElementData<string>(VenoXV.globals.EntityData.PLAYER_CURRENT_GAMEMODE) == VenoXV.globals.EntityData.GAMEMODE_TACTICS)
            {
                if (Functions.IstargetInSameLobby(player, killer) || killer == null)
                { if (killer == null) { killer = Reallife.Core.RageAPI.GetPlayerFromName(player.vnxGetElementData<string>(Tactics.globals.EntityData.PLAYER_LAST_DAMAGED_BY)); }
                    VenoXV.Tactics.environment.Death.OnPlayerDeath(player, killer);
                }
                return;
            }
            else if (player.vnxGetElementData<string>(VenoXV.globals.EntityData.PLAYER_CURRENT_GAMEMODE) == VenoXV.globals.EntityData.GAMEMODE_REALLIFE)
            {
                if (killer == null || Functions.IstargetInSameLobby(player, killer))
                {
                    VenoXV.Reallife.Environment.Death.OnPlayerDeath(player, killer, reason);
                }
            }
        }

        //[ServerEvent(Event.Update)]
        public static void OnUpdate(object unused)
        {
            try
            {
                Reallife.Globals.Main.OnUpdate();
                Tactics.globals.Globals.OnUpdate();
                Zombie.globals.Main.OnUpdate();
            }
            catch{}
        }

        //[ServerEvent(Event.PlayerDisconnected)]
        public void OnPlayerDisconnected(IPlayer player, string type, string reason)
        {
            try
            {
                Reallife.Globals.Main.OnPlayerDisconnected(player, type, reason);
                Tactics.globals.Globals.OnPlayerDisconnect(player, type, reason);
            }
            catch { }
        }

        [ScriptEvent(ScriptEventType.WeaponDamage)]
        public static void WeaponDamage(IPlayer source, IPlayer target, uint weapon, UInt16 damage, Position offset, AltV.Net.Data.BodyPart bodypart)
        {
            //Reallife.Core.Debug.OutputDebugString("Source :" + source.Name + " | target : " + target.Name + " | Weapon : " + weapon + " | damage " + damage + " | offset : " + offset + " | Bodypart : " + bodypart);
            AltV.Net.Enums.WeaponModel weaponModel = (AltV.Net.Enums.WeaponModel)weapon;
            //Reallife.Core.Debug.OutputDebugString("Deine Waffe umkonvertiert heißt : " + weaponModel);
            //Reallife.Core.Debug.OutputDebugString(DateTime.Now + "Deine Target : " + target.Name);
            if (target != null && source != null)
            {
                Tactics.weapons.Combat.OnHittedEntity(source, target, weaponModel, bodypart);
            }
        }

    }
}
