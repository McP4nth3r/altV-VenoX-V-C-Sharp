using AltV.Net.Elements.Entities;
using System;

namespace VenoXV._Gamemodes_.Reallife.model
{
    public class CarShopVehicleModel
    {
        public string model { get; set; }
        public AltV.Net.Enums.VehicleModel hash { get; set; }
        public int carShop { get; set; }
        public int type { get; set; }
        public int speed { get; set; }
        public int price { get; set; }

        public CarShopVehicleModel(string model, AltV.Net.Enums.VehicleModel hash, int carShop, int type, int price)
        {
            this.model = model;
            this.hash = hash;
            this.carShop = carShop;
            this.type = type;
            this.price = price;
        }
    }
}
