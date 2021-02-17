namespace VenoXV._Gamemodes_.Reallife.model
{
    public class BusinessClothesModel
    {
        public int Type { get; set; }
        public string Description { get; set; }
        public int BodyPart { get; set; }
        public int ClothesId { get; set; }
        public int Sex { get; set; }
        public int Products { get; set; }

        public BusinessClothesModel(int type, string description, int bodyPart, int clothesId, int sex, int products)
        {
            this.Type = type;
            this.Description = description;
            this.BodyPart = bodyPart;
            this.ClothesId = clothesId;
            this.Sex = sex;
            this.Products = products;
        }
    }
}
