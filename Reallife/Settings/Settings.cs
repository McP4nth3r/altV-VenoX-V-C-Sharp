using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV.Reallife.Core;
using VenoXV.Reallife.database;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.house;
using VenoXV.Reallife.model;

namespace VenoXV.Reallife.Settings
{
    public class VnX : IScript
    {

        [Command("settings")]
        public static void LoadSettingsWindow(IPlayer player)
        {
            try
            {
                player.Emit("LOAD_SETTINGS_VNX");
            }
            catch { }
        }


        public static void LoadSettingsData(IPlayer player)
        {
            try
            {
                if (player.vnxGetElementData<string>("settings_atm") == "ja")
                {
                    player.Emit("ShowATMBlips");
                }

                if (player.vnxGetElementData<string>("settings_quest") == "ja")
                {
                    Core.VnX.SetSharedSettingsData(player, "settings_quest", "ja");
                }
                if (player.vnxGetElementData<string>("settings_haus") == "ja")
                {
                    if (House.houseList != null)
                    {
                        foreach (HouseModel house in House.houseList)
                        {
                            if (house.status == Constants.HOUSE_STATE_BUYABLE)
                            {
                                player.Emit("ShowHouseBlips", house.position, 2, "Haus [Verkauf]");
                            }
                            else
                            {
                                player.Emit("ShowHouseBlips", house.position, 76, "Haus");
                            }
                        }
                    }
                }
                if (player.vnxGetElementData<string>("settings_tacho") == "ja")
                {
                    Core.VnX.SetSharedSettingsData(player, "settings_tacho", "ja");
                }
                if (player.vnxGetElementData<string>("settings_reporter") == "ja")
                {
                    Core.VnX.SetSharedSettingsData(player, "settings_reporter", "ja");
                }

                if (player.vnxGetElementData<string>("settings_globalchat") == "ja")
                {
                    Core.VnX.SetSharedSettingsData(player, "settings_globalchat", "ja");
                }
            }
            catch { }
        }




        //[AltV.Net.ClientEvent("ATM_STATE_CHANGE_SERVER")]
        public void ATM_STATE_CHANGE_SERVER(IPlayer player, bool state)
        {
            try
            {
                if (state == true)
                {

                    player.Emit("ShowATMBlips");
                    Core.VnX.SetSharedSettingsData(player, "settings_atm", "ja");
                }
                else
                {

                    player.Emit("Destroy_ATMBlips");
                    Core.VnX.SetSharedSettingsData(player, "settings_atm", "nein");
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("HAUS_STATE_CHANGE_SERVER")]
        public void HAUS_STATE_CHANGE_SERVER(IPlayer player, bool state)
        {
            try
            {
                if (state == true)
                {
                    Core.VnX.SetSharedSettingsData(player, "settings_haus", "ja");
                    if (House.houseList != null)
                    {
                        foreach (HouseModel house in House.houseList)
                        {
                            if (house.status == Constants.HOUSE_STATE_BUYABLE)
                            {
                                player.Emit("ShowHouseBlips", house.position, 2, "Haus [Verkauf]");
                            }
                            else
                            {
                                player.Emit("ShowHouseBlips", house.position, 76, "Haus");
                            }
                        }
                    }
                }
                else
                {
                    player.Emit("getTableShit");
                    Core.VnX.SetSharedSettingsData(player, "settings_haus", "nein");
                    //foreach (HouseModel house in House.houseList)
                    // {
                    player.Emit("Destroy_HouseBlips");
                    // }
                }
            }
            catch { }

        }

        //[AltV.Net.ClientEvent("TACHO_STATE_CHANGE_SERVER")]
        public void TACHO_STATE_CHANGE_SERVER(IPlayer player, bool state)
        {
            try
            {
                if (state == true)
                {
                    Core.VnX.SetSharedSettingsData(player, "settings_tacho", "ja");
                }
                else
                {
                    Core.VnX.SetSharedSettingsData(player, "settings_tacho", "nein");
                }
            }
            catch { }

        }


        //[AltV.Net.ClientEvent("QUEST_STATE_CHANGE_SERVER")]
        public void QUEST_STATE_CHANGE_SERVER(IPlayer player, bool state)
        {
            try
            {
                if (state == true)
                {
                    Core.VnX.SetSharedSettingsData(player, "settings_quest", "ja");
                }
                else
                {
                    Core.VnX.SetSharedSettingsData(player, "settings_quest", "nein");
                }
                anzeigen.Usefull.VnX.UpdateHUD(player);
            }
            catch { }

        }

        //[AltV.Net.ClientEvent("HUD_STATE_CHANGE_SERVER")]
        public void HUD_STATE_CHANGE_SERVER(IPlayer player, int state)
        {
            try
            {
                if(state == 0)
                {
                    player.SetData(EntityData.PLAYER_REALLIFE_HUD, 0);
                }                
                else if(state == 1)
                {
                    player.SetData(EntityData.PLAYER_REALLIFE_HUD, 1);
                }
                else
                {
                    Console.WriteLine("ID : " + state);
                }
                player.Emit("Reallife:LoadHUD", player.vnxGetElementData<int>(EntityData.PLAYER_REALLIFE_HUD));
                anzeigen.Usefull.VnX.UpdateHUD(player);
            }
            catch { }

        }


        //[AltV.Net.ClientEvent("REPORTER_STATE_CHANGE_SERVER")]
        public void REPORTER_STATE_CHANGE_SERVER(IPlayer player, bool state)
        {
            try
            {
                if (state == true)
                {
                    Core.VnX.SetSharedSettingsData(player, "settings_reporter", "ja");
                }
                else
                {
                    Core.VnX.SetSharedSettingsData(player, "settings_reporter", "nein");
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("GLOBALCHAT_STATE_CHANGE_SERVER")]
        public void GLOBALCHAT_STATE_CHANGE_SERVER(IPlayer player, bool state)
        {
            try
            {
                if (state == true)
                {
                    Core.VnX.SetSharedSettingsData(player, "settings_globalchat", "ja");
                }
                else
                {
                    Core.VnX.SetSharedSettingsData(player, "settings_globalchat", "nein");
                }
            }
            catch { }
        }


        //[AltV.Net.ClientEvent("onClickedSpawn")]
        public void ChangePlayerSpawnpoint(IPlayer player, string spawn)
        {
            try
            {
                if (spawn == "Noobspawn")
                {
                    player.SetData(EntityData.PLAYER_SPAWNPOINT, "noobspawn");
                    player.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " [Settings] : " + RageAPI.GetHexColorcode(255,255,255) + "Spawnpoint gesetzt auf Noobspawn!");
                }
                else if (spawn == "Rathaus")
                {
                    player.SetData(EntityData.PLAYER_SPAWNPOINT, "Rathaus");
                    player.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " [Settings] : " + RageAPI.GetHexColorcode(255,255,255) + "Spawnpoint gesetzt auf Rathaus!");
                }                
                else if (spawn == "Wuerfelpark")
                {
                    player.SetData(EntityData.PLAYER_SPAWNPOINT, "Wuerfelpark");
                    player.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " [Settings] : " + RageAPI.GetHexColorcode(255,255,255) + "Spawnpoint gesetzt auf Würfelpark!");
                }
                else if (spawn == "Basis")
                {
                    int playerFaction = player.vnxGetElementData<int>(EntityData.PLAYER_FACTION);
                    if (playerFaction > 0)
                    {
                        player.SetData(EntityData.PLAYER_SPAWNPOINT, "Basis");
                        player.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " [Settings] : " + RageAPI.GetHexColorcode(255,255,255) + "Spawnpoint gesetzt auf Basis!");
                    }
                    else
                    {
                        player.SendChatMessage( Constants.Rgba_ERROR + "Dafür musst du in einer Fraktion sein!");
                    }
                }
                else if (spawn == "Haus")
                {
                    foreach (HouseModel house in House.houseList)
                    {
                        if (player.vnxGetElementData<int>(EntityData.PLAYER_RENT_HOUSE) > 0 ||player.GetVnXName<string>() == house.owner)
                        {
                            player.SetData(EntityData.PLAYER_SPAWNPOINT, "House");
                            player.SendChatMessage(RageAPI.GetHexColorcode(0,200,255) + " [Settings] : " + RageAPI.GetHexColorcode(255,255,255) + "Spawnpoint gesetzt auf Haus!");
                        }
                    }
                }
            }
            catch { }
        }

    }
}
