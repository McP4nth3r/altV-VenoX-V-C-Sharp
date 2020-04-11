using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV.Core;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.model;

namespace VenoXV.Reallife.Fun.Aktionen.Shoprob
{
    public class Shoprob : IScript
    {

        public static int SHOP_COOLDOWN_TIME = 45; // Zeit bis ein Rob wieder verfügbar ist.
        public static int SHOP_ROB_TIME = 2; // Zeit bis zum Geld.
        public static int SHOP_ROB_MONEY = 500; // Geld Pro Erfolgreichen Raub.
        // Blip Property
        public static string SHOP_BLIP_NAME_POSSIBLE = "Shop";
        public static string SHOP_BLIP_NAME_BEING_ROBBED = "Shop [Wird ausgeraubt]";
        public static string SHOP_BLIP_NAME_HAVE_COOLDOWN = "Shop [Wurde ausgeraubt]";
        public static int SHOP_BLIP_ID = 52;
        public static int SHOP_Rgba_POSSIBLE = 0;
        public static int SHOP_Rgba_BEING_ROBBED = 1;
        public static int SHOP_Rgba_HAVE_COOLDOWN = 3;



        public static Dictionary<Position, int> ShopSkins;
        //public static Blip[] ShopBlips { get; set; }
        public static List<BlipModel> ShopBlips = new List<BlipModel>();
        public static List<IColShape> ShopIColShapes = new List<IColShape>();

        public static string SHOP_COOLDOWN = "SHOP_COOLDOWN";
        public static string SHOP_ROB_POSSIBLE = "SHOP_ROB_POSSIBLE";
        public static string SHOP_ROB_STARTED = "SHOP_ROB_STARTED";
        public static string PLAYER_ROB_STARTED = "PLAYER_ROB_STARTED";
        public static string SHOP_IS_COL = "SHOP_IS_COL";
        public static string SHOP_ID = "SHOP_ID";
        public static string SHOP_ROB_ID = "SHOP_ROB_ID";
        public static string SHOP_ROB_TIMEREMAINING = "SHOP_ROB_TIMEREMAINING";



        public static void OnResourceStart()
        {
            try
            {
                ShopSkins = new Dictionary<Position, int>();
                ShopSkins.Add(new Position(24.24327f, -1346.118f, 29.49702f), 270);
                ShopSkins.Add(new Position(372.7189f, 328.0656f, 103.5664f), 244);
                ShopSkins.Add(new Position(-1819.942f, 794.4971f, 138.0827f), 129);
                ShopSkins.Add(new Position(549.4589f, 2670.45f, 42.15649f), 100);
                ShopSkins.Add(new Position(1959.275f, 3740.932f, 32.34375f), 302);
                ShopSkins.Add(new Position(1697.698f, 4922.631f, 42.06367f), 312);
                ShopSkins.Add(new Position(1728.447f, 6416.808f, 35.03723f), 244);
                ShopSkins.Add(new Position(2676.558f, 3280.039f, 55.24113f), 336);
                ShopSkins.Add(new Position(-3040.581f, 583.8331f, 7.908929f), 16);
                ShopSkins.Add(new Position(-3243.882f, 999.9205f, 12.8307f), 355);
                ShopSkins.Add(new Position(2555.6470f, 380.6631f, 108.6230f), 359);
                ShopSkins.Add(new Position(-46.37407f, -1758.421f, 29.42101f), 45);
                ShopSkins.Add(new Position(1165.225f, -322.968f, 69.20506f), 90);
                ShopSkins.Add(new Position(-705.5671f, -913.6476f, 19.21559f), 90);
                ShopSkins.Add(new Position(-1221.789f, -908.7315f, 12.32635f), 41);
                ShopSkins.Add(new Position(-1485.897f, -377.8762f, 40.16339f), 134);
                ShopSkins.Add(new Position(-2966.026f, 391.2458f, 15.04331f), 91);
                ShopSkins.Add(new Position(1133.733f, -982.4885f, 46.41581f), 280);
                ShopSkins.Add(new Position(1391.8386f, 3606.2598f, 34.9809f), 200);

                int SHOP_ID_COUNTER = 0;
                foreach (var ShopCoord in ShopSkins)
                {
                    IColShape Col = Alt.CreateColShapeSphere(ShopCoord.Key, 2.25f);
                    Col.vnxSetElementData(SHOP_COOLDOWN, DateTime.Now);
                    Col.vnxSetElementData(SHOP_ROB_TIMEREMAINING, DateTime.Now);
                    Col.vnxSetElementData(SHOP_ROB_POSSIBLE, true);
                    Col.vnxSetElementData(SHOP_ROB_STARTED, false);
                    Col.vnxSetElementData(SHOP_IS_COL, true);
                    Col.vnxSetElementData(SHOP_ID, SHOP_ID_COUNTER);
                    ShopIColShapes.Add(Col);
                    BlipModel blip = new BlipModel();
                    blip.Name = SHOP_BLIP_NAME_POSSIBLE;
                    blip.posX = ShopCoord.Key.X;
                    blip.posY = ShopCoord.Key.Y;
                    blip.posZ = ShopCoord.Key.Z;
                    blip.Sprite = SHOP_BLIP_ID;
                    blip.Color = SHOP_Rgba_POSSIBLE;
                    blip.ShortRange = true;
                    VenoXV.Globals.Functions.BlipList.Add(blip);
                    ShopBlips.Add(blip);
                    SHOP_ID_COUNTER += 1;

                }
            }
            catch { }
        }

        


        public static void CreateShopRobPedsIPlayer(IPlayer player)
        {
            try
            {
                if (player.IsAiming)
                {

                }
                foreach (var ShopCoord in ShopSkins)
                {
                    player.Emit("ShopRob:CreateNPC", "s_m_m_ups_01", ShopCoord.Key, ShopCoord.Value);
                }
            }
            catch { }
        }


        public static void OnPlayerEnterIColShape(IColShape shape, IPlayer player)
        {
            try
            {
                if(shape.vnxGetElementData<bool>(SHOP_IS_COL) == true) // == True = BugFix ( Cannot not Convert null to Bolean) < --- Server Crash verhindung.
                {
                    player.Emit("CreateShopWindow");
                    player.vnxSetElementData(SHOP_ID, shape.vnxGetElementData<int>(SHOP_ID));
                }
            }
            catch { }
        }

        public static void OnShopRobClickServer(IPlayer player)
        {
            try
            {
                if (player.vnxGetElementData<bool>(PLAYER_ROB_STARTED) != true)
                {
                    if (player.vnxGetElementData<bool>(SHOP_ID) != false)
                    {
                        if (factions.Allround.isStateFaction(player) == false)
                        {
                            int CURRENT_ID = player.vnxGetElementData<int>(SHOP_ID);
                            if (ShopIColShapes[CURRENT_ID].vnxGetElementData<bool>(SHOP_ROB_STARTED) == false && ShopIColShapes[CURRENT_ID].vnxGetElementData<DateTime>(SHOP_COOLDOWN) <= DateTime.Now)
                            {
                                //Blip RobbedBlip = ShopBlips[CURRENT_ID];
                                //RobbedBlip.Color = Convert.ToByte(SHOP_Rgba_BEING_ROBBED);
                                //RobbedBlip. = SHOP_BLIP_NAME_BEING_ROBBED;
                                player.vnxSetElementData(SHOP_ROB_ID, CURRENT_ID);
                                player.vnxSetElementData(PLAYER_ROB_STARTED, true);
                                ShopIColShapes[CURRENT_ID].vnxSetElementData(SHOP_ROB_POSSIBLE, false);
                                ShopIColShapes[CURRENT_ID].vnxSetElementData(SHOP_ROB_STARTED, true);
                                ShopIColShapes[CURRENT_ID].vnxSetElementData(SHOP_ROB_TIMEREMAINING, DateTime.Now.AddMinutes(SHOP_ROB_TIME));
                                factions.Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(200,0,0) + "Der 24/7 Shop[" + CURRENT_ID + "] wird ausgeraubt! Ihr habt genau 120 Sekunden Zeit!");
                                anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_START_SHOPROB);
                            }
                        }
                        else
                        {
                            dxLibary.VnX.DrawNotification(player, "error", "Du bist in einer Staatsfraktion!");
                        }
                    } 
                }
            }
            catch{}
        }
        
        public static void OnUpdate()
        {
            try
            {
                foreach (IPlayer player in Alt.GetAllPlayers())
                {
                    foreach (IColShape col in ShopIColShapes)
                    {
                        if (col.vnxGetElementData<bool>(SHOP_ROB_STARTED) == true && col.vnxGetElementData<DateTime>(SHOP_ROB_TIMEREMAINING) <= DateTime.Now)
                        {
                            int CURRENT_ID = col.vnxGetElementData<int>(SHOP_ID);
                            if (player.vnxGetElementData<int>(SHOP_ROB_ID) == CURRENT_ID)
                            {
                                if (player.Health >= 0 && player.Position.Distance(new Position (ShopBlips[CURRENT_ID].posX, ShopBlips[CURRENT_ID].posY, ShopBlips[CURRENT_ID].posZ)) < 7)
                                {
                                    //Blip RobbedBlip = ShopBlips[CURRENT_ID];
                                    //RobbedBlip.Color = Convert.ToByte(SHOP_Rgba_HAVE_COOLDOWN);
                                    //RobbedBlip.Name = SHOP_BLIP_NAME_HAVE_COOLDOWN;

                                    col.vnxSetElementData(SHOP_ROB_STARTED, false);
                                    col.vnxSetElementData(SHOP_ROB_POSSIBLE, false);
                                    col.vnxSetElementData(SHOP_COOLDOWN, DateTime.Now.AddMinutes(SHOP_COOLDOWN_TIME));
                                    player.vnxSetElementData(PLAYER_ROB_STARTED, false);
                                    factions.Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(200,0,0) + "Der 24/7 Shop[" + CURRENT_ID + "] Raub war Erfolgreich!");
                                    player.SendChatMessage(RageAPI.GetHexColorcode(175,0,0) + "Der Shopraub war Erfolgreich! Du erhältst " + SHOP_ROB_MONEY + " $");
                                    player.vnxSetStreamSharedElementData( EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + SHOP_ROB_MONEY);
                                }
                                else
                                {
                                    //Blip RobbedBlip = ShopBlips[CURRENT_ID];
                                    //RobbedBlip.Color = Convert.ToByte(SHOP_Rgba_HAVE_COOLDOWN);
                                    //RobbedBlip.Name = SHOP_BLIP_NAME_HAVE_COOLDOWN;


                                    col.vnxSetElementData(SHOP_ROB_STARTED, false);
                                    col.vnxSetElementData(SHOP_ROB_POSSIBLE, false);
                                    col.vnxSetElementData(SHOP_COOLDOWN, DateTime.Now.AddMinutes(SHOP_COOLDOWN_TIME));

                                    player.vnxSetElementData(PLAYER_ROB_STARTED, false);
                                    player.SendChatMessage(RageAPI.GetHexColorcode(200,0,0) + "Der Shopraub wurde abgebrochen da du dich zu weit entfernt hast vom Shop!");
                                    factions.Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0,200,0) + "Der 24/7 Shop[" + CURRENT_ID + "] Raub war nicht Erfolgreich! Der Spieler ist abgehauen.");
                                }
                            }
                        }
                        else if (col.vnxGetElementData<bool>(SHOP_ROB_STARTED) == true && col.vnxGetElementData<DateTime>(SHOP_ROB_TIMEREMAINING) > DateTime.Now)
                        {
                            int CURRENT_ID = col.vnxGetElementData<int>(SHOP_ID);
                            if (player.vnxGetElementData<int>(SHOP_ROB_ID) == CURRENT_ID)
                            {
                                if (player.Health <= 0 || player.Position.Distance(new Position(ShopBlips[CURRENT_ID].posX, ShopBlips[CURRENT_ID].posY, ShopBlips[CURRENT_ID].posZ)) > 7)
                                {
                                    //Blip RobbedBlip = ShopBlips[CURRENT_ID];
                                    //RobbedBlip.Color = Convert.ToByte(SHOP_Rgba_HAVE_COOLDOWN);
                                    //RobbedBlip.Name = SHOP_BLIP_NAME_HAVE_COOLDOWN;


                                    col.vnxSetElementData(SHOP_ROB_STARTED, false);
                                    col.vnxSetElementData(SHOP_ROB_POSSIBLE, false);
                                    col.vnxSetElementData(SHOP_COOLDOWN, DateTime.Now.AddMinutes(SHOP_COOLDOWN_TIME));

                                    player.vnxSetElementData(PLAYER_ROB_STARTED, false);
                                    player.SendChatMessage(RageAPI.GetHexColorcode(200,0,0) + "Der Shopraub wurde abgebrochen da du dich zu weit entfernt hast vom Shop!");
                                    factions.Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0,200,0) + "Der 24/7 Shop[" + CURRENT_ID + "] Raub war nicht Erfolgreich! Der Spieler ist abgehauen.");
                                }
                            }
                        }
                    }
                }
            }
            catch { } 
        }

        public static void OnPlayerDisconnected(IPlayer player, string type, string reason)
        {
            try
            {
                foreach (IColShape col in ShopIColShapes)
                {
                    if (col.vnxGetElementData<bool>(SHOP_ROB_STARTED) == true && col.vnxGetElementData<DateTime>(SHOP_ROB_TIMEREMAINING) >= DateTime.Now)
                    {
                        int CURRENT_ID = col.vnxGetElementData<int>(SHOP_ID);
                        if (player.vnxGetElementData<int>(SHOP_ROB_ID) == CURRENT_ID)
                        {
                           // Blip RobbedBlip = ShopBlips[CURRENT_ID];
                            //RobbedBlip.Color = Convert.ToByte(SHOP_Rgba_HAVE_COOLDOWN);
                            //RobbedBlip.Name = SHOP_BLIP_NAME_HAVE_COOLDOWN;
                            col.vnxSetElementData(SHOP_ROB_STARTED, false);
                            col.vnxSetElementData(SHOP_ROB_POSSIBLE, false);
                            col.vnxSetElementData(SHOP_COOLDOWN, DateTime.Now.AddMinutes(SHOP_COOLDOWN_TIME));
                            factions.Faction.CreateCustomStateFactionMessage(RageAPI.GetHexColorcode(0,200,0) + "Der 24/7 Shop[" + CURRENT_ID + "] Raub war nicht Erfolgreich! Der Spieler ist Disconnected.");
                        }
                    }
                }
            }
            catch { }
        }

        public static void OnMinuteSpend()
        {
            try
            {
                foreach (IColShape col in Alt.GetAllColShapes())
                {
                    if (col.vnxGetElementData<bool>(SHOP_IS_COL) == true)
                    {
                        if(col.vnxGetElementData<DateTime>(SHOP_COOLDOWN) <= DateTime.Now && col.vnxGetElementData<bool>(SHOP_ROB_POSSIBLE) == false && col.vnxGetElementData<bool>(SHOP_ROB_STARTED) == false)
                        {
                            int CURRENT_ID = col.vnxGetElementData<int>(SHOP_ID);
                            col.vnxSetElementData(SHOP_ROB_POSSIBLE, true);
                            //Blip RobbedBlip = ShopBlips[CURRENT_ID];
                            //RobbedBlip.Color = Convert.ToByte(SHOP_Rgba_HAVE_COOLDOWN);
                            //RobbedBlip.Name = SHOP_BLIP_NAME_POSSIBLE; // Reset Data.
                        }
                    }
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("OnShopWindowBTNClickServer")]
        public static void OnShopWindowBTNClickServer(IPlayer player, int value)
        {
            try
            {
                if (value == 1)
                {

                }
                else if (value == 2)
                {

                }
                else if (value == 3)
                {

                }
                else if (value == 4)
                {

                }
                else if (value == 5)
                {

                }
                else if (value == 6)
                {

                }
                else if (value == 7)
                {

                }
                else if (value == 8)
                {

                }
                else if (value == 9)
                {
                    OnShopRobClickServer(player);
                }

            }
            catch {}
        }
        
    }
}

