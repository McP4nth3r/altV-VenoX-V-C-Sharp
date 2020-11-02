using AltV.Net;
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
        public static void LoadSettingsWindow(VnXPlayer player)
        {
            try { Alt.Server.TriggerClientEvent(player, "Settings:Show"); }
            catch { }
        }


        public static async void LoadSettingsData(VnXPlayer player)
        {
            try
            {
                if (player.Settings.ShowATM == 1)
                {
                    Alt.Server.TriggerClientEvent(player, "Reallife:ShowATMBlips");
                }
                if (player.Settings.ShowHouse == 1)
                {
                    if (House.houseList != null)
                    {
                        string TranslatedText = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Haus [Verkauf]");
                        string TranslatedText1 = await _Language_.Main.GetTranslatedTextAsync((_Language_.Main.Languages)player.Language, "Haus [Verkauf]");
                        foreach (HouseModel house in House.houseList)
                        {
                            if (house.status == Constants.HOUSE_STATE_BUYABLE)
                            {
                                Alt.Server.TriggerClientEvent(player, "ShowHouseBlips", house.position, 2, TranslatedText);
                            }
                            else
                            {
                                Alt.Server.TriggerClientEvent(player, "ShowHouseBlips", house.position, 76, TranslatedText1);
                            }
                        }
                    }
                }
            }
            catch { }
        }




        //[AltV.Net.ClientEvent("ATM_STATE_CHANGE_SERVER")]
        public void ATM_STATE_CHANGE_SERVER(VnXPlayer player, bool state)
        {
            try
            {
                if (state == true)
                {

                    Alt.Server.TriggerClientEvent(player, "Reallife:ShowATMBlips");
                    player.vnxSetStreamSharedElementData("settings_atm", "ja");
                }
                else
                {

                    Alt.Server.TriggerClientEvent(player, "Reallife:DestroyATMBlips");
                    player.vnxSetStreamSharedElementData("settings_atm", "nein");
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("HAUS_STATE_CHANGE_SERVER")]
        public void HAUS_STATE_CHANGE_SERVER(VnXPlayer player, bool state)
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
                                Alt.Server.TriggerClientEvent(player, "ShowHouseBlips", house.position, 2, "Haus [Verkauf]");
                            }
                            else
                            {
                                Alt.Server.TriggerClientEvent(player, "ShowHouseBlips", house.position, 76, "Haus");
                            }
                        }
                    }
                }
                else
                {
                    Alt.Server.TriggerClientEvent(player, "getTableShit");
                    player.vnxSetStreamSharedElementData("settings_haus", "nein");
                    //foreach (HouseModel house in House.houseList)
                    // {
                    Alt.Server.TriggerClientEvent(player, "Reallife:DestroyHouseBlips");
                    // }
                }
            }
            catch { }

        }

        //[AltV.Net.ClientEvent("TACHO_STATE_CHANGE_SERVER")]
        public void TACHO_STATE_CHANGE_SERVER(VnXPlayer player, bool state)
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
        public void QUEST_STATE_CHANGE_SERVER(VnXPlayer player, bool state)
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
            }
            catch { }

        }

        //[AltV.Net.ClientEvent("HUD_STATE_CHANGE_SERVER")]
        public void HUD_STATE_CHANGE_SERVER(VnXPlayer player, int state)
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
                Alt.Server.TriggerClientEvent(player, "Reallife:LoadHUD", player.vnxGetElementData<int>(EntityData.PLAYER_REALLIFE_HUD));
            }
            catch { }

        }


        //[AltV.Net.ClientEvent("REPORTER_STATE_CHANGE_SERVER")]
        public void REPORTER_STATE_CHANGE_SERVER(VnXPlayer player, bool state)
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
        public void GLOBALCHAT_STATE_CHANGE_SERVER(VnXPlayer player, bool state)
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


        [ClientEvent("Settings:SelectSpawnpoint")]
        public void ChangePlayerSpawnpoint(VnXPlayer player, int spawn)
        {
            try
            {
                switch (spawn)
                {
                    case 0:
                        player.Reallife.SpawnLocation = "noobspawn";
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " [Settings] : " + RageAPI.GetHexColorcode(255, 255, 255) + "Spawnpoint gesetzt auf Noobspawn!");
                        break;
                    case 1:
                        player.Reallife.SpawnLocation = "Rathaus";
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " [Settings] : " + RageAPI.GetHexColorcode(255, 255, 255) + "Spawnpoint gesetzt auf Rathaus!");
                        break;
                    case 2:
                        player.Reallife.SpawnLocation = "Wuerfelpark";
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " [Settings] : " + RageAPI.GetHexColorcode(255, 255, 255) + "Spawnpoint gesetzt auf Würfelpark!");
                        break;
                    case 3:
                        if (player.Reallife.Faction > 0)
                        {
                            player.Reallife.SpawnLocation = "Basis";
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " [Settings] : " + RageAPI.GetHexColorcode(255, 255, 255) + "Spawnpoint gesetzt auf Basis!");
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "Dafür musst du in einer Fraktion sein!");
                        }
                        break;
                    case 4:
                        if (player.Reallife.Faction > 0)
                        {
                            if (player.Reallife.Faction == Constants.FACTION_USARMY)
                            {
                                player.Reallife.SpawnLocation = "Basis-2";
                                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 255) + " [Settings] : " + RageAPI.GetHexColorcode(255, 255, 255) + "Spawnpoint gesetzt auf Basis-2!");
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "Deine Fraktion hat keine zweite Base!");
                            }
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "Dafür musst du in einer Fraktion sein!");
                        }
                        break;
                }
            }
            catch { }
        }

    }
}
