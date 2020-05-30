using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.Environment.ammunation
{
    public class Ammunation : IScript
    {
        public static void OnResourceStart()
        {
            RageAPI.CreateBlip("Ammunation", new System.Numerics.Vector3(21.11444f, -1106.664f, 29.79703f), 110, 4, false);
        }

        //[AltV.Net.ClientEvent("Buy_Item_Ammo_S")]
        public void BuyWeaponAmmuAmmunation(Client player, string item)
        {
            try
            {
                int playerId = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);
                int playermoney = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY);
                if (item == "Pistolen Magazin")
                {
                    ItemModel Pistole = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOLE);
                    if (Pistole != null)
                    {
                        if (playermoney >= 90)
                        {
                            VenoXV._Gamemodes_.Reallife.Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_PISTOL_AMMO, Constants.ITEM_ART_MAGAZIN, 12, true);
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 90);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageAPI.GetHexColorcode(0, 200, 255) + " Pistolen Magazin " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                        }
                    }
                    else
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Kauf dir erst eine Pistole!");
                    }
                }
                else if (item == "Pistole 50 Magazin")
                {
                    ItemModel Pistole50 = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOLE50);
                    if (Pistole50 != null)
                    {
                        if (playermoney >= 165)
                        {
                            VenoXV._Gamemodes_.Reallife.Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_PISTOL_AMMO, Constants.ITEM_ART_MAGAZIN, 9, true);
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 165);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageAPI.GetHexColorcode(0, 200, 255) + " Pistolen 50. Magazin " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                        }
                    }
                    else
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Kauf dir erst eine Pistole!");
                    }
                }
                else if (item == "Revolver Magazin")
                {
                    ItemModel Revolver = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_REVOLVER);
                    if (Revolver != null)
                    {
                        if (playermoney >= 220)
                        {
                            VenoXV._Gamemodes_.Reallife.Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_PISTOL_AMMO, Constants.ITEM_ART_MAGAZIN, 9, true);
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 220);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageAPI.GetHexColorcode(0, 200, 255) + " Revolver Magazin " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                        }
                    }
                    else
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Kauf dir erst eine Pistole!");
                    }
                }
                else if (item == "Shotgun Magazin")
                {
                    ItemModel Shotgun = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_SHOTGUN);
                    if (Shotgun != null)
                    {
                        if (playermoney >= 100)
                        {
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 100);
                            Shotgun.amount = Shotgun.amount + 6;
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.PumpShotgun, Shotgun.amount);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein paar " + RageAPI.GetHexColorcode(0, 200, 255) + " Schrotkugeln " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                            Database.UpdateItem(Shotgun);
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                        }
                    }
                    else
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Kauf dir erst eine Pistole!");
                    }
                }
                else if (item == "PDW Magazin")
                {
                    ItemModel PDW = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PDW);
                    if (PDW != null)
                    {
                        if (playermoney >= 450)
                        {
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 450);
                            PDW.amount = PDW.amount + 30;
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.CombatPDW, PDW.amount);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageAPI.GetHexColorcode(0, 200, 255) + " PDW Magazin " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                            Database.UpdateItem(PDW);
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                        }
                    }
                    else
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Kauf dir erst eine Pistole!");
                    }
                }
                else if (item == "Rifle Magazin")
                {
                    ItemModel Rifle = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_ADVANCEDRIFLE);
                    if (Rifle != null)
                    {
                        if (playermoney >= 535)
                        {
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 535);
                            Rifle.amount = Rifle.amount + 30;
                            player.SetWeaponAmmo(AltV.Net.Enums.WeaponModel.AdvancedRifle, Rifle.amount);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageAPI.GetHexColorcode(0, 200, 255) + " Rifle Magazin " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                            Database.UpdateItem(Rifle);
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                        }
                    }
                    else
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Kauf dir erst eine Pistole!");
                    }
                }
            }
            catch
            {
            }
        }


        //[AltV.Net.ClientEvent("Buy_Item_S")]
        public void BuyWeaponAmmunation(Client player, string item)
        {
            try
            {
                int playerId = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID);
                int playermoney = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_MONEY);
                if (item == "Weste")
                {
                    if (playermoney >= 100)
                    {
                        if (player.Armor != 100)
                        {
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 100);
                            player.Armor = 100;
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast bereits eine " + RageAPI.GetHexColorcode(0, 200, 255) + " " + item);
                        }
                    }
                    else
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                    }
                }
                else if (item == "Messer")
                {
                    ItemModel SWITCHBLADE = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_SWITCHBLADE);
                    if (SWITCHBLADE == null) // WEED
                    {
                        if (playermoney >= 200)
                        {
                            VenoXV._Gamemodes_.Reallife.Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_SWITCHBLADE, Constants.ITEM_ART_WAFFE, 1, false);
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 200);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageAPI.GetHexColorcode(0, 200, 255) + " " + item + " " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                        }
                    }
                    else
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast bereits ein Messer!");
                    }
                }
                else if (item == "Fallschirm")
                {
                    ItemModel FALLSCHIRM = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_FALLSCHIRM);
                    if (FALLSCHIRM == null) // WEED
                    {
                        if (playermoney >= 925)
                        {
                            VenoXV._Gamemodes_.Reallife.Globals.Main.GivePlayerItem(player, Constants.ITEM_ART_FALLSCHIRM, Constants.ITEM_ART_FALLSCHIRM, 1, false);
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 925);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast einen " + RageAPI.GetHexColorcode(0, 200, 255) + " " + item + " " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                        }
                    }
                    else
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast bereits einen Fallschirm!");
                    }
                }
                else if (item == "Pistole")
                {
                    ItemModel Pistole = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOLE);
                    if (Pistole == null) // WEED
                    {
                        if (playermoney >= 265)
                        {
                            VenoXV._Gamemodes_.Reallife.Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_PISTOLE, Constants.ITEM_ART_WAFFE, 1, false);
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 265);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageAPI.GetHexColorcode(0, 200, 255) + " " + item + " " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                        }
                    }
                    else
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast bereits eine Pistole!");
                    }
                }
                else if (item == "Pistole50")
                {
                    ItemModel Pistole50 = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PISTOLE50);
                    if (Pistole50 == null) // WEED
                    {
                        if (playermoney >= 385)
                        {
                            VenoXV._Gamemodes_.Reallife.Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_PISTOLE50, Constants.ITEM_ART_WAFFE, 1, false);
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 385);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageAPI.GetHexColorcode(0, 200, 255) + " " + item + " " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                        }
                    }
                    else
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast bereits eine Pistole 50 !");
                    }
                }
                else if (item == "Revolver")
                {
                    ItemModel Revolver = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_REVOLVER);
                    if (Revolver == null) // WEED
                    {
                        if (playermoney >= 400)
                        {
                            VenoXV._Gamemodes_.Reallife.Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_REVOLVER, Constants.ITEM_ART_WAFFE, 1, false);
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 400);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageAPI.GetHexColorcode(0, 200, 255) + " " + item + " " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                        }
                    }
                    else
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast bereits eine Revolver!");
                    }
                }
                else if (item == "Shotgun")
                {
                    ItemModel Shotgun = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_SHOTGUN);
                    if (Shotgun == null) // WEED
                    {
                        if (playermoney >= 600)
                        {
                            VenoXV._Gamemodes_.Reallife.Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_SHOTGUN, Constants.ITEM_ART_WAFFE, 1, false);
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 600);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageAPI.GetHexColorcode(0, 200, 255) + " " + item + " " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                        }
                    }
                    else
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast bereits eine Shotgun!");
                    }
                }
                else if (item == "PDW")
                {
                    ItemModel PDW = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_PDW);
                    if (PDW == null) // WEED
                    {
                        if (playermoney >= 800)
                        {
                            VenoXV._Gamemodes_.Reallife.Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_PDW, Constants.ITEM_ART_WAFFE, 1, false);
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 800);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageAPI.GetHexColorcode(0, 200, 255) + " " + item + " " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                        }
                    }
                    else
                    {
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast bereits eine PDW!");
                    }
                }
                else if (item == "Rifle")
                {
                    ItemModel Rifle = Main.GetPlayerItemModelFromHash(playerId, Constants.ITEM_HASH_ADVANCEDRIFLE);
                    if (Rifle == null) // WEED
                    {
                        if (playermoney >= 950)
                        {
                            VenoXV._Gamemodes_.Reallife.Globals.Main.GivePlayerItem(player, Constants.ITEM_HASH_RIFLE, Constants.ITEM_ART_WAFFE, 1, false);
                            player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, playermoney - 950);
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(255, 255, 255) + "Du hast ein " + RageAPI.GetHexColorcode(0, 200, 255) + " " + item + " " + RageAPI.GetHexColorcode(255, 255, 255) + "gekauft!");
                            anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_GETADVANCEDRIFLE);

                        }
                        else
                        {
                            player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast nicht genug Geld!");
                        }
                    }
                    else
                    {
                        anzeigen.Usefull.VnX.UpdateQuestLVL(player, anzeigen.Usefull.VnX.QUEST_GETADVANCEDRIFLE);
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(200, 0, 0) + "Du hast bereits ein Gewehr!");
                    }
                }
                else
                {
                    player.SendTranslatedChatMessage("[Venox - Debug Module 1.0] : Ammunation Button konnte nicht geladen werden! Info # :" + item);
                }
            }
            catch
            {
            }
        }


        public static ColShapeModel AmmunationCOL = RageAPI.CreateColShapeSphere(new Position(20.84089f, -1106.488f, 29.79704f), 2);

        public static void OnPlayerEnterColShapeModel(IColShape shape, Client player)
        {
            try
            {
                if (shape == AmmunationCOL.Entity)
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_WAFFEN_FÜHRERSCHEIN) != 1)
                    {
                        player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "Du hast keinen Waffenschein!");
                        return;
                    }
                    player.Emit("ShowAmmunation_C");
                }
            }
            catch
            {
            }
        }
    }
}
