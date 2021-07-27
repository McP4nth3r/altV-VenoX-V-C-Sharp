using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using AltV.Net.Elements.Entities;
using Newtonsoft.Json;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Globals_;
using VenoXV.Core;
using VenoXV.Reallife.model;

namespace VenoXV.Models.SubClasses.PlayerModel
{
    public class Inventory
    {
        private readonly VnXPlayer _player;
        public List<ItemModel> Items { get; }

        public void Update()
        {
            Debug.OutputDebugString("Update()");
            List<ItemModel> inventory = Items;
            VenoX.TriggerClientEvent(_player, "Inventory:Update", JsonConvert.SerializeObject(inventory));
        }
        public void GiveItem(string itemHash, ItemType itemArt, int itemAmount, bool calculateIfExists, int dimension = Main.ReallifeDimension, float weight = 0.1f, bool save = true, int id = -1)
        {
            try
            {
                int playerId = _player.UID;
                Debug.OutputDebugString("UID : " + playerId);
                if (playerId > 0)
                {
                    Debug.OutputDebugString("Id : " + id);
                    var item = id != -1 ? _Globals_.Inventory.Inventory.DatabaseItems.ToList().FirstOrDefault(x => x.Id == id) : _player.Inventory.Items.ToList().FirstOrDefault(x => x.Hash == itemHash);

                    if (item == null)
                    {
                        item = new ItemModel
                        {
                            Amount = itemAmount,
                            Dimension = dimension,
                            Position = new Vector3(0.0f, 0.0f, 0.0f),
                            Hash = itemHash,
                            Uid = playerId,
                            Type = itemArt,
                            Weight = weight
                        };
                        if (save)
                        {
                            item.Id = Database.Database.AddNewItem(item);
                            _Globals_.Inventory.Inventory.DatabaseItems.Add(item);
                        }
                        Items.Add(item);
                    }
                    else
                    {
                        if (calculateIfExists) item.Amount += itemAmount;
                        else item.Amount = itemAmount;
                        // Update if item not exists.
                        ItemModel inventoryItem = Items.ToList().FirstOrDefault(x => x.Id == item.Id);
                        if (inventoryItem is null)
                            Items.Add(item);
                    }
                }
                Update();
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public Inventory(Player player)
        {
            try
            {
                _player = (VnXPlayer)player;
                Items = new List<ItemModel>();
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}
