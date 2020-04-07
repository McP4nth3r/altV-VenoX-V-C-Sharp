using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using VenoXV.Core;

namespace VenoXV.Globals
{
    public class Main : IScript
    {
        public static List<IPlayer> ReallifePlayers = new List<IPlayer>();
        public static List<IPlayer> TacticsPlayers = new List<IPlayer>();
        public static List<IPlayer> ZombiePlayers = new List<IPlayer>();


        public static void AddPlayerIntoGamemodeList(IPlayer player, string Gamemode)
        {
            switch (Gamemode)
            {
                case EntityData.GAMEMODE_REALLIFE:
                    ReallifePlayers.Add(player);
                    break;
                case EntityData.GAMEMODE_TACTICS:
                    TacticsPlayers.Add(player);
                    break;
                case EntityData.GAMEMODE_ZOMBIE:
                    ZombiePlayers.Add(player);
                    break;
            }
        }
        public static void RemovePlayerFromGamemodeList(IPlayer player)
        {
            string Gamemode = player.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_GAMEMODE);
            switch (Gamemode)
            {
                case EntityData.GAMEMODE_REALLIFE:
                    ReallifePlayers.Remove(player);
                    break;
                case EntityData.GAMEMODE_TACTICS:
                    TacticsPlayers.Remove(player);
                    break;
                case EntityData.GAMEMODE_ZOMBIE:
                    ZombiePlayers.Remove(player);
                    break;
            }
        }


        public static void OnResourceStart()
        {
            try
            {
                /*AltEntitySync.Init(1, 100,
                   repository => new ServerEventNetworkLayer(repository),
                   () => new LimitedGrid3(50_000, 50_000, 100, 10_000, 10_000, 600),
                   new IdProvider()
                );*/
                Reallife.Globals.Main.OnResourceStart();
                Tactics.Globals.Main.OnResourceStart();
                SevenTowers.Lobby.Main.OnResourceStart();
                // DynamicTextLabel textLabel = TextLabelStreamer.CreateDynamicTextLabel("Some Text", new Vector3(469.8354f, -985.0742f, 33.89248f), 0, true, new Rgba(255, 255, 255, 255));
            }
            catch (Exception ex) { Debug.CatchExceptions("OnResourceStart", ex); }
        }



        [ScriptEvent(ScriptEventType.ColShape)]
        public static void OnColShape(IColShape shape, AltV.Net.Elements.Entities.IEntity entity, bool state)
        {
            try
            {
                IPlayer player = entity as IPlayer;
                if (player == null) return;
                if (state) { Reallife.Globals.Main.OnPlayerEnterIColShape(shape, player); }
                else { Reallife.Globals.Main.OnPlayerExitIColShape(shape, player); }
            }
            catch { }
        }

        [ScriptEvent(ScriptEventType.PlayerDead)]
        public static void OnPlayerDeath(IPlayer player, IPlayer killer, uint reason)
        {
            if (player.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_GAMEMODE) == EntityData.GAMEMODE_TACTICS)
            {
                if (Functions.IstargetInSameLobby(player, killer) || killer == null)
                {
                    if (killer == null) { killer = RageAPI.GetPlayerFromName(player.vnxGetElementData<string>(Tactics.Globals.EntityData.PLAYER_LAST_DAMAGED_BY)); }
                    VenoXV.Tactics.environment.Death.OnPlayerDeath(player, killer);
                }
                return;
            }
            else if (player.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_GAMEMODE) == EntityData.GAMEMODE_REALLIFE)
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
                Tactics.Globals.Main.OnUpdate();
                //Zombie.globals.Main.OnUpdate();
                //SevenTowers.globals.Main.OnUpdate();
            }
            catch { }
        }

        [ScriptEvent(ScriptEventType.PlayerDisconnect)]
        public void OnPlayerDisconnected(IPlayer player, string reason)
        {
            try
            {
                string type = string.Empty;
                Reallife.Globals.Main.OnPlayerDisconnected(player, type, reason);
                Tactics.Globals.Main.OnPlayerDisconnect(player, type, reason);
                SevenTowers.globals.Main.OnPlayerDisconnect(player);
            }
            catch { }
        }

        [ScriptEvent(ScriptEventType.WeaponDamage)]
        public static void WeaponDamage(IPlayer source, IPlayer target, uint weapon, UInt16 damage, Position offset, AltV.Net.Data.BodyPart bodypart)
        {
            //Debug.OutputDebugString("Source :" + source.Name + " | target : " + target.GetVnXName<string>() + " | Weapon : " + weapon + " | damage " + damage + " | offset : " + offset + " | Bodypart : " + bodypart);
            AltV.Net.Enums.WeaponModel weaponModel = (AltV.Net.Enums.WeaponModel)weapon;
            //Debug.OutputDebugString("Deine Waffe umkonvertiert heißt : " + weaponModel);
            //Debug.OutputDebugString(DateTime.Now + "Deine Target : " + target.GetVnXName<string>());
            if (target != null && source != null)
            {
                Tactics.weapons.Combat.OnHittedEntity(source, target, weaponModel, bodypart);
            }
        }


    }
}
