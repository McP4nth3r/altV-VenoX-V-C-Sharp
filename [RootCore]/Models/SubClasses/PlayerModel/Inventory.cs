using AltV.Net.Elements.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.model;

namespace VenoXV._RootCore_.Models
{
    public class Inventory
    {
        private VnXPlayer Player;
        public List<ItemModel> Items { get; set; }

        public void Update()
        {
            List<ItemModel> inventory = Items;
            VenoX.TriggerClientEvent(Player, "Inventory:Update", JsonConvert.SerializeObject(inventory));
        }
        public void GiveItem(string ItemHash, ItemType ItemArt, int ItemAmount, bool CalculateIfExists, int Dimension = VenoXV._Globals_.Main.REALLIFE_DIMENSION, float Weight = 0.1f)
        {
            int playerId = Player.UID;
            if (playerId > 0)
            {
                ItemModel Item = Player.Inventory.Items.FirstOrDefault(x => x.Hash == ItemHash);
                if (Item == null)
                {
                    Item = new ItemModel
                    {
                        Amount = ItemAmount,
                        Dimension = VenoXV._Globals_.Main.REALLIFE_DIMENSION,
                        Position = new Vector3(0.0f, 0.0f, 0.0f),
                        Hash = ItemHash,
                        UID = playerId,
                        Type = ItemArt,
                        Weight = Weight
                    };
                    Item.Id = Database.Database.AddNewItem(Item);
                    _Globals_.Inventory.Inventory.DatabaseItems.Add(Item);
                    Items.Add(Item);
                }
                else
                {
                    if (CalculateIfExists) Item.Amount += ItemAmount;
                    else Item.Amount = ItemAmount;
                    // Update item in DbItem Entry list.
                    ItemModel DbItem = Player.Inventory.Items.FirstOrDefault(x => x.Id == Item.Id);
                    DbItem = Item;
                }
            }
            Update();
        }
        public Inventory(Player player)
        {
            try
            {
                Player = (VnXPlayer)player;
                Items = new List<ItemModel>();
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
