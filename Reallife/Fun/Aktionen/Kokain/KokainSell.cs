
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Threading.Tasks;
using VenoXV.Core;
using VenoXV.Reallife.database;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.model;

namespace VenoXV.Reallife.Fun.Aktionen.Kokain
{
    public class KokainSell : IScript
    {
        public static IColShape KokainSell_Col = Alt.CreateColShapeSphere(new Position(140.425f, -239.0754f, 51.52684f), 1.5f);
        public static void OnResourceStart()
        {
            BlipModel blip = new BlipModel();
            Position pos = new Position(140.425f, -239.0754f, 51.52684f);
            blip.Name = "Dealer";
            blip.posX = pos.X;
            blip.posY = pos.Y;
            blip.posZ = pos.Z;
            blip.Sprite = 51;
            blip.Color = 27;
            blip.ShortRange = true;
            VenoXV.Globals.Functions.BlipList.Add(blip);
        }

        public static void OnPlayerEnterIColShape(IColShape shape, IPlayer player)
        {
            try
            {
                if (shape == KokainSell_Col)
                {
                    dxLibary.VnX.DrawInputWindow(player, "Kokain Dealer", "Hast du etwas Koks für mich?<br>Ich zahle dir pro Gramm 30$....", "Verkaufen");
                }
            }
            catch { }
        }
        public static void SellKokain(IPlayer player, int value)
        {
            try
            {
                ItemModel KOKS = Main.GetPlayerItemModelFromHash(player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), Constants.ITEM_HASH_KOKS);
                if(KOKS != null)
                {
                    if(value > 0)
                    {
                        if(value <= KOKS.amount)
                        {
                            int koksverkauf = value * 30;
                            player.SendChatMessage( "Du hast " + RageAPI.GetHexColorcode(0,150,200) + value + "g " + RageAPI.GetHexColorcode(255, 255,255) + " Kokain für " + RageAPI.GetHexColorcode(0,150,200) + koksverkauf + "$ " + RageAPI.GetHexColorcode(255, 255,255) + "verkauft.");
                            player.vnxSetSharedElementData<object>( EntityData.PLAYER_MONEY, player.vnxGetElementData<int>(EntityData.PLAYER_MONEY) + koksverkauf);
                            dxLibary.VnX.DestroyWindow(player, dxLibary.VnX.WINDOW_INPUT);
                            KOKS.amount -= value;
                                // Update the amount into the database
                                Database.UpdateItem(KOKS);
                            if (KOKS.amount == 0)
                            {
                                // Remove the item from the database
                                Database.RemoveItem(KOKS.id);
                               anzeigen.Inventar.Main.CurrentOnlineItemList.Remove(KOKS);
                            }
                        }
                        else
                        {
                            dxLibary.VnX.DrawNotification(player, "error", "Soviel Kokain hast du nicht!");
                        }
                    }
                    else
                    {
                        dxLibary.VnX.DrawNotification(player, "error", "Mindestens 1g Koks!");
                    }
                }
                else
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du hast kein Kokain!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION SellKokain] " + ex.Message);
                Console.WriteLine("[EXCEPTION SellKokain] " + ex.StackTrace);
            }
        }
    }
}
