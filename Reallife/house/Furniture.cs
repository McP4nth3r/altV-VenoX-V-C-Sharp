using AltV.Net.Elements.Entities;
using VenoXV.Reallife.database;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.model;
using System.Collections.Generic;
using System;
using AltV.Net;

namespace VenoXV.Reallife.house
{
    public class Furniture : IScript
    {
        private static List<FurnitureModel> furnitureList;

        public void LoadDatabaseFurniture()
        {
            furnitureList = Database.LoadAllFurniture();
           /* foreach (FurnitureModel furnitureModel in furnitureList)
            {
                furnitureModel.handle = NAPI.Object.CreateObject(furnitureModel.hash, furnitureModel.position, furnitureModel.rotation, (byte)furnitureModel.house);
            }*/
        }

        public List<FurnitureModel> GetFurnitureInHouse(int houseId)
        {
            List<FurnitureModel> list = new List<FurnitureModel>();
            foreach (FurnitureModel furniture in furnitureList)
            {
                if (furniture.house == houseId)
                {
                    list.Add(furniture);
                }
            }
            return list;
        }

        public FurnitureModel GetFurnitureById(int id)
        {
            FurnitureModel furniture = null;
            foreach (FurnitureModel furnitureModel in furnitureList)
            {
                if (furnitureModel.id == id)
                {
                    furniture = furnitureModel;
                    break;
                }
            }
            return furniture;
        }
        /*
        [Command(Messages.COM_FURNITURE, Messages.GEN_FURNITURE_COMMAND)]
        public void FurnitureCommand(IPlayer player, string action)
        {
            if (player.HasData<int>(EntityData.PLAYER_HOUSE_ENTERED) == true)
            {
                int houseId = player.vnxGetElementData<int>(EntityData.PLAYER_HOUSE_ENTERED);
                HouseModel house = House.GetHouseById(houseId);

                if (house != null && house.owner ==player.GetVnXName<string>())
                {
                    switch (action.ToLower())
                    {
                        case Messages.ARG_PLACE:
                            FurnitureModel furniture = new FurnitureModel();
                            furniture.hash = 1251197000;
                            furniture.house = houseId);
                            furniture.position = player.Position;
                            furniture.rotation = player.Rotation;
                            furniture.handle = NAPI.Object.CreateObject(furniture.hash, furniture.position, furniture.rotation, (byte)furniture.house);
                            furnitureList.Add(furniture);
                            break;
                        case Messages.ARG_MOVE:
                            string furnitureJson = JsonConvert.SerializeObject(GetFurnitureInHouse(houseId));
                            player.SetData(EntityData.PLAYER_MOVING_FURNITURE, true);
                            player.Emit("moveFurniture", furnitureJson);
                            break;
                        case Messages.ARG_REMOVE:
                            break;
                        default:
                            player.SendChatMessage(Constants.Rgba_HELP + Messages.GEN_FURNITURE_COMMAND);
                            break;
                    }
                }
                else
                {
                    player.SendChatMessage(Constants.Rgba_ERROR + Messages.ERR_PLAYER_NOT_HOUSE_OWNER);
                }
            }
            else
            {
                player.SendChatMessage(Constants.Rgba_ERROR + Messages.ERR_PLAYER_NOT_IN_HOUSE);
            }
        }*/
    }
}
