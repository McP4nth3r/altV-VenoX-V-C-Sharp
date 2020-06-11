using AltV.Net;
using System.Collections.Generic;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;

namespace VenoXV._Gamemodes_.Reallife.business
{
    public class Business : IScript
    {
        public static List<BusinessModel> businessList;
        public static int GetClothesProductsPrice(int id, int sex, int type, int slot)
        {
            try
            {
                int productsPrice = 10000;
                foreach (BusinessClothesModel clothesModel in Constants.BUSINESS_CLOTHES_LIST)
                {
                    if (clothesModel.type == type && (clothesModel.sex == sex || Constants.SEX_NONE == clothesModel.sex) && clothesModel.bodyPart == slot && clothesModel.clothesId == id)
                    {
                        productsPrice = clothesModel.products;
                        break;
                    }
                }
                return productsPrice;
            }
            catch { return 10000; }
        }
    }
}
