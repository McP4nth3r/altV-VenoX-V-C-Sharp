using AltV.Net.Enums;

namespace VenoX.Core._Gamemodes_.Reallife.model
{
    public class CarShopVehicleModel
    {
        public string Model { get; set; }
        public VehicleModel Hash { get; set; }
        public int CarShop { get; set; }
        public string Type { get; set; }
        public int Speed { get; set; }
        public int Price { get; set; }

        public CarShopVehicleModel(string model, VehicleModel hash, int carShop, string type, int price)
        {
            this.Model = model;
            this.Hash = hash;
            this.CarShop = carShop;
            this.Type = type;
            this.Price = price;
        }
    }
}
