using System;

namespace VenoXV.Reallife.model
{
    public class BusinessClothesModel
    {
        public int type { get; set; }
        public string deIScription { get; set; }
        public int bodyPart { get; set; }
        public int clothesId { get; set; }
        public int sex { get; set; }
        public int products { get; set; }

        public BusinessClothesModel(int type, string deIScription, int bodyPart, int clothesId, int sex, int products)
        {
            this.type = type;
            this.deIScription = deIScription;
            this.bodyPart = bodyPart;
            this.clothesId = clothesId;
            this.sex = sex;
            this.products = products;
        }
    }
}
