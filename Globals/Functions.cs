using AltV.Net;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV.Reallife.Core;
using VenoXV.Reallife.model;

namespace VenoXV.Globals
{
    public class Functions : IScript
    {
        public static List<BlipModel> BlipList = new List<BlipModel>();
        
        public static bool IstargetInAnotherLobby(IPlayer player, IPlayer target)
        {
            try
            {
                string CurrentPlayerLobby = player.vnxGetElementData<string>(VenoXV.globals.EntityData.PLAYER_CURRENT_GAMEMODE);
                string CurrenttargetLobby = target.vnxGetElementData<string>(VenoXV.globals.EntityData.PLAYER_CURRENT_GAMEMODE);
                if (CurrentPlayerLobby != CurrenttargetLobby)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }        
        public static bool IstargetInSameLobby(IPlayer player, IPlayer target)
        {
            try
            {
                string CurrentPlayerLobby = player.vnxGetElementData<string>(VenoXV.globals.EntityData.PLAYER_CURRENT_GAMEMODE);
                string CurrenttargetLobby = target.vnxGetElementData<string>(VenoXV.globals.EntityData.PLAYER_CURRENT_GAMEMODE);
                if (CurrentPlayerLobby == CurrenttargetLobby)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
