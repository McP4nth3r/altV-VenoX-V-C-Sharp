using AltV.Net;
using AltV.Net.Async;
using System;
using System.Collections.Generic;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._RootCore_
{
    public class VenoX : IScript
    {
        public static List<VnXPlayer> GetAllPlayers()
        {
            try { return _Globals_.Main.AllPlayers; }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return new List<VnXPlayer>(); }
        }

        public static void TriggerClientEvent(VnXPlayer player, string EventName, params object[] args)
        {
            try
            {
                player.EmitLocked(EventName, args);
                //Alt.Server.TriggerClientEvent(player, EventName, args);
                //Core.Debug.OutputDebugString("[ClientEvent] : [" + player.Name + "] | [" + player.Username + "] called EventName : " + EventName);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static void TriggerPreloadEvent(VnXPlayer player, string Text, string EventName, params object[] args)
        {
            try
            {
                if (player is null || !player.Exists) return;
                player.PreloadEvents.Add(new LoadingModel { EventText = Text, EventName = EventName, EventArgs = args, EventSend = DateTime.Now });
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }

        public static void TriggerEventForAll(string EventName, params object[] args)
        {
            try
            {
                if (_Globals_.Main.AllPlayers.Count <= 0) return;
                Alt.EmitAllClients(EventName, args);
                //Core.Debug.OutputDebugString("[ClientEvent] : called EventName for everyone : " + EventName);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public static List<ColShapeModel> GetAllColShapes()
        {
            try { return Sync.Sync.ColShapeList; }
            catch (Exception ex) { Debug.CatchExceptions(ex); return new List<ColShapeModel>(); }
        }
        [ScriptEvent(ScriptEventType.PlayerEvent)]
        public static void OnServerEventReceive(VnXPlayer player, string EventName, params object[] args)
        {
            try
            {
                //string Parameter = "";
                //foreach (object obj in args) Parameter += " | " + args.ToString();
                //Core.Debug.OutputDebugString("[ServerEvent] : [" + player.Name + "] | [" + player.Username + "] called EventName : " + EventName + " | Args : " + string.Join(", ", args));
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }


    }
}
