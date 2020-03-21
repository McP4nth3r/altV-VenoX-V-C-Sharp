using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.EntitySync;
using AltV.Net.EntitySync.ServerEvent;
using AltV.Net.EntitySync.SpatialPartitions;
using DasNiels.AltV.Streamers;
using System;
using System.Collections.Generic;
using System.Numerics;
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
                AltEntitySync.Init(1, 100,
                   repository => new ServerEventNetworkLayer(repository),
                   () => new LimitedGrid3(50_000, 50_000, 100, 10_000, 10_000, 600),
                   new IdProvider()
                );
                Reallife.Globals.Main.OnResourceStart();
                Tactics.globals.Globals.OnResourceStart();
                SevenTowers.Lobby.Main.OnResourceStart();
                DynamicTextLabel textLabel = TextLabelStreamer.CreateDynamicTextLabel("Some Text", new Vector3(469.8354f, -985.0742f, 33.89248f), 0, true, new Rgba(255, 255, 255, 255));
            }
            catch (Exception ex) { Reallife.Core.Debug.CatchExceptions("OnResourceStart", ex); }
        }



        [ScriptEvent(ScriptEventType.ColShape)]
        public static void OnColShape(IColShape shape, AltV.Net.Elements.Entities.IEntity entity, bool state)
        {
            try
            {
                IPlayer player = entity as IPlayer;
                if (player == null) return;
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

        public static void OnUpdate(object unused)
        {
            try
            {
                Reallife.Globals.Main.OnUpdate();
                Tactics.globals.Globals.OnUpdate();
                Zombie.globals.Main.OnUpdate();
                SevenTowers.globals.Main.OnUpdate();
            }
            catch{}
        }

        [ScriptEvent(ScriptEventType.PlayerDisconnect)]
        public void OnPlayerDisconnected(IPlayer player, string reason)
        {
            try
            {
                string type = string.Empty;
                Reallife.Globals.Main.OnPlayerDisconnected(player, type, reason);
                Tactics.globals.Globals.OnPlayerDisconnect(player, type, reason);
                SevenTowers.globals.Main.OnPlayerDisconnect(player);
            }
            catch { }
        }

        [ScriptEvent(ScriptEventType.WeaponDamage)]
        public static void WeaponDamage(IPlayer source, IPlayer target, uint weapon, UInt16 damage, Position offset, AltV.Net.Data.BodyPart bodypart)
        {
            //Reallife.Core.Debug.OutputDebugString("Source :" + source.Name + " | target : " + target.GetVnXName<string>() + " | Weapon : " + weapon + " | damage " + damage + " | offset : " + offset + " | Bodypart : " + bodypart);
            AltV.Net.Enums.WeaponModel weaponModel = (AltV.Net.Enums.WeaponModel)weapon;
            //Reallife.Core.Debug.OutputDebugString("Deine Waffe umkonvertiert heißt : " + weaponModel);
            //Reallife.Core.Debug.OutputDebugString(DateTime.Now + "Deine Target : " + target.GetVnXName<string>());
            if (target != null && source != null)
            {
                Tactics.weapons.Combat.OnHittedEntity(source, target, weaponModel, bodypart);
            }
        }

    }
}
