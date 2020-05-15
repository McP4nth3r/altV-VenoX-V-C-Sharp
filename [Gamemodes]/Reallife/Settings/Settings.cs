﻿using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using System;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.house;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Settings
{
    public class VnX : IScript
    {

        [Command("settings")]
        public static void LoadSettingsWindow(Client player)
        {
            try
            {
                player.Emit("LOAD_SETTINGS_VNX");
            }
            catch { }
        }


        public static void LoadSettingsData(Client player)
        {
            try
            {
                if (player.vnxGetElementData<string>("settings_atm") == "ja")
                {
                    player.Emit("ShowATMBlips");
                }

                if (player.vnxGetElementData<string>("settings_quest") == "ja")
                {
                    player.vnxSetStreamSharedElementData("settings_quest", "ja");
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
                    player.vnxSetStreamSharedElementData("settings_tacho", "ja");
                }
                if (player.vnxGetElementData<string>("settings_reporter") == "ja")
                {
                    player.vnxSetStreamSharedElementData("settings_reporter", "ja");
                }

                if (player.vnxGetElementData<string>("settings_globalchat") == "ja")
                {
                    player.vnxSetStreamSharedElementData("settings_globalchat", "ja");
                }
            }
            catch { }
        }




        //[AltV.Net.ClientEvent("ATM_STATE_CHANGE_SERVER")]
        public void ATM_STATE_CHANGE_SERVER(Client player, bool state)
        {
            try
            {
                if (state == true)
                {

                    player.Emit("ShowATMBlips");
                    player.vnxSetStreamSharedElementData("settings_atm", "ja");
                }
                else
                {

                    player.Emit("Destroy_ATMBlips");
                    player.vnxSetStreamSharedElementData("settings_atm", "nein");
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("HAUS_STATE_CHANGE_SERVER")]
        public void HAUS_STATE_CHANGE_SERVER(Client player, bool state)
        {
            try
            {
                if (state == true)
                {
                    player.vnxSetStreamSharedElementData("settings_haus", "ja");
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
                    player.vnxSetStreamSharedElementData("settings_haus", "nein");
                    //foreach (HouseModel house in House.houseList)
                    // {
                    player.Emit("Destroy_HouseBlips");
                    // }
                }
            }
            catch { }

        }

        //[AltV.Net.ClientEvent("TACHO_STATE_CHANGE_SERVER")]
        public void TACHO_STATE_CHANGE_SERVER(Client player, bool state)
        {
            try
            {
                if (state == true)
                {
                    player.vnxSetStreamSharedElementData("settings_tacho", "ja");
                }
                else
                {
                    player.vnxSetStreamSharedElementData("settings_tacho", "nein");
                }
            }
            catch { }

        }


        //[AltV.Net.ClientEvent("QUEST_STATE_CHANGE_SERVER")]
        public void QUEST_STATE_CHANGE_SERVER(Client player, bool state)
        {
            try
            {
                if (state == true)
                {
                    player.vnxSetStreamSharedElementData("settings_quest", "ja");
                }
                else
                {
                    player.vnxSetStreamSharedElementData("settings_quest", "nein");
                }
                anzeigen.Usefull.VnX.UpdateHUD(player);
            }
            catch { }

        }

        //[AltV.Net.ClientEvent("HUD_STATE_CHANGE_SERVER")]
        public void HUD_STATE_CHANGE_SERVER(Client player, int state)
        {
            try
            {
                if (state == 0)
                {
                    player.vnxSetElementData(EntityData.PLAYER_REALLIFE_HUD, 0);
                }
                else if (state == 1)
                {
                    player.vnxSetElementData(EntityData.PLAYER_REALLIFE_HUD, 1);
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
        public void REPORTER_STATE_CHANGE_SERVER(Client player, bool state)
        {
            try
            {
                if (state == true)
                {
                    player.vnxSetStreamSharedElementData("settings_reporter", "ja");
                }
                else
                {
                    player.vnxSetStreamSharedElementData("settings_reporter", "nein");
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("GLOBALCHAT_STATE_CHANGE_SERVER")]
        public void GLOBALCHAT_STATE_CHANGE_SERVER(Client player, bool state)
        {
            try
            {
                if (state == true)
                {
                    player.vnxSetStreamSharedElementData("settings_globalchat", "ja");
                }
                else
                {
                    player.vnxSetStreamSharedElementData("settings_globalchat", "nein");
                }
            }
            catch { }
        }


        //[AltV.Net.ClientEvent("onClickedSpawn")]
        public void ChangePlayerSpawnpoint(Client player, string spawn)
        {
            try
            {
                if (spawn == "Noobspawn")
                {
                    player.vnxSetElementData(EntityData.PLAYER_SPAWNPOINT, "noobspawn");
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " [Settings] : " + RageAPI.GetHexColorcode(255, 255, 255) + "Spawnpoint gesetzt auf Noobspawn!");
                }
                else if (spawn == "Rathaus")
                {
                    player.vnxSetElementData(EntityData.PLAYER_SPAWNPOINT, "Rathaus");
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " [Settings] : " + RageAPI.GetHexColorcode(255, 255, 255) + "Spawnpoint gesetzt auf Rathaus!");
                }
                else if (spawn == "Wuerfelpark")
                {
                    player.vnxSetElementData(EntityData.PLAYER_SPAWNPOINT, "Wuerfelpark");
                    player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " [Settings] : " + RageAPI.GetHexColorcode(255, 255, 255) + "Spawnpoint gesetzt auf Würfelpark!");
                }
                else if (spawn == "Basis")
                {
                    int playerFaction = player.vnxGetElementData<int>(EntityData.PLAYER_FACTION);
                    if (playerFaction > 0)
                    {
                        player.vnxSetElementData(EntityData.PLAYER_SPAWNPOINT, "Basis");
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " [Settings] : " + RageAPI.GetHexColorcode(255, 255, 255) + "Spawnpoint gesetzt auf Basis!");
                    }
                    else
                    {
                        player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "Dafür musst du in einer Fraktion sein!");
                    }
                }
                else if (spawn == "Haus")
                {
                    foreach (HouseModel house in House.houseList)
                    {
                        if (player.vnxGetElementData<int>(EntityData.PLAYER_RENT_HOUSE) > 0 || player.GetVnXName() == house.owner)
                        {
                            player.vnxSetElementData(EntityData.PLAYER_SPAWNPOINT, "House");
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " [Settings] : " + RageAPI.GetHexColorcode(255, 255, 255) + "Spawnpoint gesetzt auf Haus!");
                        }
                    }
                }
            }
            catch { }
        }

    }
}
