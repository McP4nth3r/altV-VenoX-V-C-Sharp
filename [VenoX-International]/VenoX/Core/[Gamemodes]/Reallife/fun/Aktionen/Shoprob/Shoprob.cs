using System;
using System.Collections.Generic;
using System.Linq;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using VenoXV._Gamemodes_.Reallife.factions;
using VenoXV._Gamemodes_.Reallife.quests;
using VenoXV._Globals_;
using VenoXV.Core;
using VenoXV.Models;
using VenoXV.Reallife.factions;
using Main = VenoXV._Notifications_.Main;

namespace VenoXV._Gamemodes_.Reallife.Fun.Aktionen.Shoprob
{
    public class Shoprob : IScript
    {

        public static int ShopCooldownTime = 45; // Zeit bis ein Rob wieder verfügbar ist.
        public static int ShopRobTime = 2; // Zeit bis zum Geld.
        public static int ShopRobMoney = 500; // Geld Pro Erfolgreichen Raub.
        // Blip Property
        public static string ShopBlipNamePossible = "Shop";
        public static string ShopBlipNameBeingRobbed = "Shop [Wird ausgeraubt]";
        public static string ShopBlipNameHaveCooldown = "Shop [Wurde ausgeraubt]";
        public static int ShopBlipId = 52;
        public static int ShopRgbaPossible = 0;
        public static int ShopRgbaBeingRobbed = 1;
        public static int ShopRgbaHaveCooldown = 3;



        public static Dictionary<Position, int> ShopSkins;
        //public static Blip[] ShopBlips { get; set; }
        public static List<BlipModel> ShopBlips = new List<BlipModel>();
        public static List<ColShapeModel> ShopColShapeModels = new List<ColShapeModel>();

        public static string ShopCooldown = "SHOP_COOLDOWN";
        public static string ShopRobPossible = "SHOP_ROB_POSSIBLE";
        public static string ShopRobStarted = "SHOP_ROB_STARTED";
        public static string PlayerRobStarted = "PLAYER_ROB_STARTED";
        public static string ShopIsCol = "SHOP_IS_COL";
        public static string ShopId = "SHOP_ID";
        public static string ShopRobId = "SHOP_ROB_ID";
        public static string ShopRobTimeremaining = "SHOP_ROB_TIMEREMAINING";



        public static void OnResourceStart()
        {
            try
            {
                ShopSkins = new Dictionary<Position, int>
                {
                    { new Position(24.24327f, -1346.118f, 29.49702f), 270 },
                    { new Position(372.7189f, 328.0656f, 103.5664f), 244 },
                    { new Position(-1819.942f, 794.4971f, 138.0827f), 129 },
                    { new Position(549.4589f, 2670.45f, 42.15649f), 100 },
                    { new Position(1959.275f, 3740.932f, 32.34375f), 302 },
                    { new Position(1697.698f, 4922.631f, 42.06367f), 312 },
                    { new Position(1728.447f, 6416.808f, 35.03723f), 244 },
                    { new Position(2676.558f, 3280.039f, 55.24113f), 336 },
                    { new Position(-3040.581f, 583.8331f, 7.908929f), 16 },
                    { new Position(-3243.882f, 999.9205f, 12.8307f), 355 },
                    { new Position(2555.6470f, 380.6631f, 108.6230f), 359 },
                    { new Position(-46.37407f, -1758.421f, 29.42101f), 45 },
                    { new Position(1165.225f, -322.968f, 69.20506f), 90 },
                    { new Position(-705.5671f, -913.6476f, 19.21559f), 90 },
                    { new Position(-1221.789f, -908.7315f, 12.32635f), 41 },
                    { new Position(-1485.897f, -377.8762f, 40.16339f), 134 },
                    { new Position(-2966.026f, 391.2458f, 15.04331f), 91 },
                    { new Position(1133.733f, -982.4885f, 46.41581f), 280 },
                    { new Position(1391.8386f, 3606.2598f, 34.9809f), 200 }
                };

                int shopIdCounter = 0;
                foreach (var shopCoord in ShopSkins)
                {
                    ColShapeModel col = RageApi.CreateColShapeSphere(shopCoord.Key, 2.25f);
                    col.VnxSetElementData(ShopCooldown, DateTime.Now);
                    col.VnxSetElementData(ShopRobTimeremaining, DateTime.Now);
                    col.VnxSetElementData(ShopRobPossible, true);
                    col.VnxSetElementData(ShopRobStarted, false);
                    col.VnxSetElementData(ShopIsCol, true);
                    col.VnxSetElementData(ShopId, shopIdCounter);
                    ShopColShapeModels.Add(col);
                    BlipModel blip = new BlipModel
                    {
                        Name = ShopBlipNamePossible,
                        PosX = shopCoord.Key.X,
                        PosY = shopCoord.Key.Y,
                        PosZ = shopCoord.Key.Z,
                        Sprite = ShopBlipId,
                        Color = ShopRgbaPossible,
                        ShortRange = true
                    };
                    RageApi.CreateBlip(ShopBlipNamePossible, shopCoord.Key, ShopBlipId, ShopRgbaPossible, true);
                    ShopBlips.Add(blip);
                    shopIdCounter += 1;

                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }




        public static void CreateShopRobPedsIPlayer(VnXPlayer player)
        {
            try
            {
                if (player.IsAiming)
                {

                }
                foreach (var shopCoord in ShopSkins)
                {
                    VenoX.TriggerClientEvent(player, "ShopRob:CreateNPC", "s_m_m_ups_01", shopCoord.Key, shopCoord.Value);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }


        public static void OnPlayerEnterColShapeModel(ColShapeModel shape, VnXPlayer player)
        {
            try
            {
                if (shape.VnxGetElementData<bool>(ShopIsCol)) // == True = BugFix ( Cannot not Convert null to Bolean) < --- Server Crash verhindung.
                {
                    VenoX.TriggerClientEvent(player, "CreateShopWindow");
                    player.VnxSetElementData(ShopId, shape.VnxGetElementData<int>(ShopId));
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public static void OnShopRobClickServer(VnXPlayer player)
        {
            try
            {
                if (player.VnxGetElementData<bool>(PlayerRobStarted) != true)
                {
                    if (player.VnxGetElementData<bool>(ShopId))
                    {
                        if (Allround.IsStateFaction(player) == false)
                        {
                            int currentId = player.VnxGetElementData<int>(ShopId);
                            if (ShopColShapeModels[currentId].VnxGetElementData<bool>(ShopRobStarted) != false ||
                                ShopColShapeModels[currentId].VnxGetElementData<DateTime>(ShopCooldown) > DateTime.Now)
                                return;
                            //Blip RobbedBlip = ShopBlips[CURRENT_ID];
                            //RobbedBlip.Color = Convert.ToByte(SHOP_Rgba_BEING_ROBBED);
                            //RobbedBlip. = SHOP_BLIP_NAME_BEING_ROBBED;
                            player.VnxSetElementData(ShopRobId, currentId);
                            player.VnxSetElementData(PlayerRobStarted, true);
                            ShopColShapeModels[currentId].VnxSetElementData(ShopRobPossible, false);
                            ShopColShapeModels[currentId].VnxSetElementData(ShopRobStarted, true);
                            ShopColShapeModels[currentId].VnxSetElementData(ShopRobTimeremaining, DateTime.Now.AddMinutes(ShopRobTime));
                            Faction.CreateCustomStateFactionMessage(RageApi.GetHexColorcode(200, 0, 0) + "Der 24/7 Shop[" + currentId + "] wird ausgeraubt! Ihr habt genau 120 Sekunden Zeit!");
                            //anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_START_SHOPROB);
                            if (Quests.QuestDict.ContainsKey(Quests.QuestStartShoprob))
                                Quests.OnQuestDone(player, Quests.QuestDict[Quests.QuestStartShoprob]);
                        }
                        else
                        {
                            Main.DrawNotification(player, Main.Types.Error, "Du bist in einer Staatsfraktion!");
                        }
                    }
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public static void OnUpdate()
        {
            try
            {
                foreach (VnXPlayer player in _Globals_.Main.ReallifePlayers.ToList())
                {
                    foreach (ColShapeModel col in ShopColShapeModels)
                    {
                        if (col.VnxGetElementData<bool>(ShopRobStarted) && col.VnxGetElementData<DateTime>(ShopRobTimeremaining) <= DateTime.Now)
                        {
                            int currentId = col.VnxGetElementData<int>(ShopId);
                            if (player.VnxGetElementData<int>(ShopRobId) != currentId) continue;
                            if (player.Health >= 0 && player.Position.Distance(new Position(ShopBlips[currentId].PosX, ShopBlips[currentId].PosY, ShopBlips[currentId].PosZ)) < 7)
                            {
                                //Blip RobbedBlip = ShopBlips[CURRENT_ID];
                                //RobbedBlip.Color = Convert.ToByte(SHOP_Rgba_HAVE_COOLDOWN);
                                //RobbedBlip.Name = SHOP_BLIP_NAME_HAVE_COOLDOWN;

                                col.VnxSetElementData(ShopRobStarted, false);
                                col.VnxSetElementData(ShopRobPossible, false);
                                col.VnxSetElementData(ShopCooldown, DateTime.Now.AddMinutes(ShopCooldownTime));
                                player.VnxSetElementData(PlayerRobStarted, false);
                                Faction.CreateCustomStateFactionMessage(RageApi.GetHexColorcode(200, 0, 0) + "Der 24/7 Shop[" + currentId + "] Raub war Erfolgreich!");
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(175, 0, 0) + "Der Shopraub war Erfolgreich! Du erhältst " + ShopRobMoney + " $");
                                player.VnxSetStreamSharedElementData(EntityData.PlayerMoney, player.Reallife.Money + ShopRobMoney);
                            }
                            else
                            {
                                //Blip RobbedBlip = ShopBlips[CURRENT_ID];
                                //RobbedBlip.Color = Convert.ToByte(SHOP_Rgba_HAVE_COOLDOWN);
                                //RobbedBlip.Name = SHOP_BLIP_NAME_HAVE_COOLDOWN;
                                col.VnxSetElementData(ShopRobStarted, false);
                                col.VnxSetElementData(ShopRobPossible, false);
                                col.VnxSetElementData(ShopCooldown, DateTime.Now.AddMinutes(ShopCooldownTime));

                                player.VnxSetElementData(PlayerRobStarted, false);
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Der Shopraub wurde abgebrochen da du dich zu weit entfernt hast vom Shop!");
                                Faction.CreateCustomStateFactionMessage(RageApi.GetHexColorcode(0, 200, 0) + "Der 24/7 Shop[" + currentId + "] Raub war nicht Erfolgreich! Der Spieler ist abgehauen.");
                            }
                        }
                        else if (col.VnxGetElementData<bool>(ShopRobStarted) && col.VnxGetElementData<DateTime>(ShopRobTimeremaining) > DateTime.Now)
                        {
                            int currentId = col.VnxGetElementData<int>(ShopId);
                            if (player.VnxGetElementData<int>(ShopRobId) != currentId) continue;
                            if (player.Health <= 0 || player.Position.Distance(new Position(ShopBlips[currentId].PosX, ShopBlips[currentId].PosY, ShopBlips[currentId].PosZ)) > 7)
                            {
                                //Blip RobbedBlip = ShopBlips[CURRENT_ID];
                                //RobbedBlip.Color = Convert.ToByte(SHOP_Rgba_HAVE_COOLDOWN);
                                //RobbedBlip.Name = SHOP_BLIP_NAME_HAVE_COOLDOWN;


                                col.VnxSetElementData(ShopRobStarted, false);
                                col.VnxSetElementData(ShopRobPossible, false);
                                col.VnxSetElementData(ShopCooldown, DateTime.Now.AddMinutes(ShopCooldownTime));

                                player.VnxSetElementData(PlayerRobStarted, false);
                                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(200, 0, 0) + "Der Shopraub wurde abgebrochen da du dich zu weit entfernt hast vom Shop!");
                                Faction.CreateCustomStateFactionMessage(RageApi.GetHexColorcode(0, 200, 0) + "Der 24/7 Shop[" + currentId + "] Raub war nicht Erfolgreich! Der Spieler ist abgehauen.");
                            }
                        }
                    }
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public static void OnPlayerDisconnected(VnXPlayer player, string type, string reason)
        {
            try
            {
                foreach (ColShapeModel col in ShopColShapeModels)
                {
                    if (!col.VnxGetElementData<bool>(ShopRobStarted) ||
                        col.VnxGetElementData<DateTime>(ShopRobTimeremaining) < DateTime.Now) continue;
                    int currentId = col.VnxGetElementData<int>(ShopId);
                    if (player.VnxGetElementData<int>(ShopRobId) == currentId)
                    {
                        // Blip RobbedBlip = ShopBlips[CURRENT_ID];
                        //RobbedBlip.Color = Convert.ToByte(SHOP_Rgba_HAVE_COOLDOWN);
                        //RobbedBlip.Name = SHOP_BLIP_NAME_HAVE_COOLDOWN;
                        col.VnxSetElementData(ShopRobStarted, false);
                        col.VnxSetElementData(ShopRobPossible, false);
                        col.VnxSetElementData(ShopCooldown, DateTime.Now.AddMinutes(ShopCooldownTime));
                        Faction.CreateCustomStateFactionMessage(RageApi.GetHexColorcode(0, 200, 0) + "Der 24/7 Shop[" + currentId + "] Raub war nicht Erfolgreich! Der Spieler ist Disconnected.");
                    }
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        public static void OnMinuteSpend()
        {
            try
            {
                return;
                foreach (IColShape col in Alt.GetAllColShapes())
                {
                    if (col.VnxGetElementData<bool>(ShopIsCol))
                    {
                        if (col.VnxGetElementData<DateTime>(ShopCooldown) <= DateTime.Now && col.VnxGetElementData<bool>(ShopRobPossible) == false && col.VnxGetElementData<bool>(ShopRobStarted) == false)
                        {
                            int currentId = col.VnxGetElementData<int>(ShopId);
                            col.VnxSetElementData(ShopRobPossible, true);
                            //Blip RobbedBlip = ShopBlips[CURRENT_ID];
                            //RobbedBlip.Color = Convert.ToByte(SHOP_Rgba_HAVE_COOLDOWN);
                            //RobbedBlip.Name = SHOP_BLIP_NAME_POSSIBLE; // Reset Data.
                        }
                    }
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

        //[AltV.Net.ClientEvent("OnShopWindowBTNClickServer")]
        public static void OnShopWindowBTNClickServer(VnXPlayer player, int value)
        {
            try
            {
                switch (value)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        OnShopRobClickServer(player);
                        break;
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }

    }
}

