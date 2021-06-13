using System;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.house;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV.Models;
using Main = VenoXV._Language_.Main;

namespace VenoXV.Settings
{
    public class VnX : IScript
    {

        [Command("settings")]
        public static void LoadSettingsWindow(VnXPlayer player)
        {
            try { VenoX.TriggerClientEvent(player, "Settings:Show"); }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }


        public static async void LoadSettingsData(VnXPlayer player)
        {
            try
            {
                if (player.Settings.ShowAtm == 1) VenoX.TriggerClientEvent(player, "Reallife:ShowATMBlips");
                if (player.Settings.ShowHouse != 1) return;
                if (House.HouseList == null) return;
                string translatedText = await Main.GetTranslatedTextAsync((Main.Languages)player.Language, "Haus [Verkauf]");
                string translatedText1 = await Main.GetTranslatedTextAsync((Main.Languages)player.Language, "Haus [Verkauf]");
                foreach (HouseModel house in House.HouseList)
                {
                    if (house.Status == Constants.HouseStateBuyable)
                        VenoX.TriggerClientEvent(player, "ShowHouseBlips", house.Position, 2, translatedText);
                    else
                        VenoX.TriggerClientEvent(player, "ShowHouseBlips", house.Position, 76, translatedText1);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }




        //[AltV.Net.ClientEvent("ATM_STATE_CHANGE_SERVER")]
        public void ATM_STATE_CHANGE_SERVER(VnXPlayer player, bool state)
        {
            try
            {
                if (state)
                {

                    VenoX.TriggerClientEvent(player, "Reallife:ShowATMBlips");
                    player.VnxSetStreamSharedElementData("settings_atm", "ja");
                }
                else
                {

                    VenoX.TriggerClientEvent(player, "Reallife:DestroyATMBlips");
                    player.VnxSetStreamSharedElementData("settings_atm", "nein");
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        //[AltV.Net.ClientEvent("HAUS_STATE_CHANGE_SERVER")]
        public void HAUS_STATE_CHANGE_SERVER(VnXPlayer player, bool state)
        {
            try
            {
                if (state)
                {
                    player.VnxSetStreamSharedElementData("settings_haus", "ja");
                    if (House.HouseList != null)
                    {
                        foreach (HouseModel house in House.HouseList)
                        {
                            if (house.Status == Constants.HouseStateBuyable)
                            {
                                VenoX.TriggerClientEvent(player, "ShowHouseBlips", house.Position, 2, "Haus [Verkauf]");
                            }
                            else
                            {
                                VenoX.TriggerClientEvent(player, "ShowHouseBlips", house.Position, 76, "Haus");
                            }
                        }
                    }
                }
                else
                {
                    VenoX.TriggerClientEvent(player, "getTableShit");
                    player.VnxSetStreamSharedElementData("settings_haus", "nein");
                    //foreach (HouseModel house in House.houseList)
                    // {
                    VenoX.TriggerClientEvent(player, "Reallife:DestroyHouseBlips");
                    // }
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}

        }

        //[AltV.Net.ClientEvent("TACHO_STATE_CHANGE_SERVER")]
        public void TACHO_STATE_CHANGE_SERVER(VnXPlayer player, bool state)
        {
            try
            {
                if (state)
                {
                    player.VnxSetStreamSharedElementData("settings_tacho", "ja");
                }
                else
                {
                    player.VnxSetStreamSharedElementData("settings_tacho", "nein");
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}

        }


        //[AltV.Net.ClientEvent("QUEST_STATE_CHANGE_SERVER")]
        public void QUEST_STATE_CHANGE_SERVER(VnXPlayer player, bool state)
        {
            try
            {
                if (state)
                {
                    player.VnxSetStreamSharedElementData("settings_quest", "ja");
                }
                else
                {
                    player.VnxSetStreamSharedElementData("settings_quest", "nein");
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}

        }

        //[AltV.Net.ClientEvent("HUD_STATE_CHANGE_SERVER")]
        public void HUD_STATE_CHANGE_SERVER(VnXPlayer player, int state)
        {
            try
            {
                switch (state)
                {
                    case 0:
                        player.VnxSetElementData(EntityData.PlayerReallifeHud, 0);
                        break;
                    case 1:
                        player.VnxSetElementData(EntityData.PlayerReallifeHud, 1);
                        break;
                    default:
                        Console.WriteLine("ID : " + state);
                        break;
                }

                VenoX.TriggerClientEvent(player, "Reallife:LoadHUD", player.VnxGetElementData<int>(EntityData.PlayerReallifeHud));
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}

        }


        //[AltV.Net.ClientEvent("REPORTER_STATE_CHANGE_SERVER")]
        public void REPORTER_STATE_CHANGE_SERVER(VnXPlayer player, bool state)
        {
            try
            {
                if (state)
                {
                    player.VnxSetStreamSharedElementData("settings_reporter", "ja");
                }
                else
                {
                    player.VnxSetStreamSharedElementData("settings_reporter", "nein");
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        //[AltV.Net.ClientEvent("GLOBALCHAT_STATE_CHANGE_SERVER")]
        public void GLOBALCHAT_STATE_CHANGE_SERVER(VnXPlayer player, bool state)
        {
            try
            {
                if (state)
                {
                    player.VnxSetStreamSharedElementData("settings_globalchat", "ja");
                }
                else
                {
                    player.VnxSetStreamSharedElementData("settings_globalchat", "nein");
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }


        [VenoXRemoteEvent("Settings:SelectHUD")]
        public static void ChangePlayerHUD(VnXPlayer player, int hud)
        {
            //player.Settings.
            player.Settings.ReallifeHud = hud;
        }

        [VenoXRemoteEvent("Settings:SelectSpawnpoint")]
        public static void ChangePlayerSpawnpoint(VnXPlayer player, int spawn)
        {
            try
            {
                switch (spawn)
                {
                    case 0:
                        player.Reallife.SpawnLocation = "Noobspawn";
                        player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " [Settings] : " + RageApi.GetHexColorcode(255, 255, 255) + "Spawnpoint gesetzt auf Noobspawn!");
                        break;
                    case 1:
                        player.Reallife.SpawnLocation = "Rathaus";
                        player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " [Settings] : " + RageApi.GetHexColorcode(255, 255, 255) + "Spawnpoint gesetzt auf Rathaus!");
                        break;
                    case 2:
                        player.Reallife.SpawnLocation = "Wuerfelpark";
                        player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " [Settings] : " + RageApi.GetHexColorcode(255, 255, 255) + "Spawnpoint gesetzt auf Würfelpark!");
                        break;
                    case 3:
                        if (player.Reallife.Faction > 0)
                        {
                            player.Reallife.SpawnLocation = "Basis";
                            player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " [Settings] : " + RageApi.GetHexColorcode(255, 255, 255) + "Spawnpoint gesetzt auf Basis!");
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(Constants.RgbaError + "Dafür musst du in einer Fraktion sein!");
                        }
                        break;
                    case 4:
                        if (player.Reallife.Faction > 0)
                        {
                            if (player.Reallife.Faction == Constants.FactionUsarmy)
                            {
                                player.Reallife.SpawnLocation = "Basis-2";
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 255) + " [Settings] : " + RageApi.GetHexColorcode(255, 255, 255) + "Spawnpoint gesetzt auf Basis-2!");
                            }
                            else
                            {
                                player.SendTranslatedChatMessage(Constants.RgbaError + "Deine Fraktion hat keine zweite Base!");
                            }
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(Constants.RgbaError + "Dafür musst du in einer Fraktion sein!");
                        }
                        break;
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

    }
}
