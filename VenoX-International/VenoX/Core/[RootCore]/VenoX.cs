using System;
using System.Collections.Generic;
using AltV.Net;
using AltV.Net.Async;
using VenoX.Core._Globals_;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._RootCore_
{
    public class VenoX : IScript
    {
        public static List<VnXPlayer> GetAllPlayers()
        {
            try { return Initialize.AllPlayers; }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); return new List<VnXPlayer>(); }
        }

        public static void TriggerClientEvent(VnXPlayer player, string eventName, params object[] args)
        {
            try
            {
                player.EmitLocked(eventName, args);
                //Alt.Server.TriggerClientEvent(player, EventName, args);
                //Core.Debug.OutputDebugString("[ClientEvent] : [" + player.Name + "] | [" + player.Username + "] called EventName : " + EventName);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }        
        public static void TriggerAsyncClientEvent(VnXPlayer player, string eventName, params object[] args)
        {
            try
            {
                lock (player)
                    player.EmitAsync(eventName, args);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        public static void TriggerPreloadEvent(VnXPlayer player, string text, string eventName, params object[] args)
        {
            try
            {
                if (player is null || !player.Exists) return;
                player.PreloadEvents.Add(new LoadingModel { EventText = text, EventName = eventName, EventArgs = args, EventSend = DateTime.Now });
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }

        public static void TriggerEventForAll(string eventName, params object[] args)
        {
            try
            {
                if (Initialize.AllPlayers.Count <= 0) return;
                Alt.EmitAllClients(eventName, args);
                //Core.Debug.OutputDebugString("[ClientEvent] : called EventName for everyone : " + EventName);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
        public static List<ColShapeModel> GetAllColShapes()
        {
            try { return Sync.Sync.ColShapeList; }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); return new List<ColShapeModel>(); }
        }
        [ScriptEvent(ScriptEventType.PlayerEvent)]
        public static void OnServerEventReceive(VnXPlayer player, string eventName, params object[] args)
        {
            try
            {
                //string Parameter = "";
                //foreach (object obj in args) Parameter += " | " + args.ToString();
                //Core.Debug.OutputDebugString("[ServerEvent] : [" + player.Name + "] | [" + player.Username + "] called EventName : " + EventName + " | Args : " + string.Join(", ", args));
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
    }
}
