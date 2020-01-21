using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;

namespace VenoXV.Reallife.model
{
    public class ItemModel
    {
        public int id { get; set; }
        public string hash { get; set; }
        public string ownerEntity { get; set; }
        public int ownerIdentifier { get; set; }
        public int amount { get; set; }
        public Position position { get; set; }
        public int dimension { get; set; }

        public string ITEM_ART { get; set; }
        public int type { get; set; }


        //public GTANetworkAPI.Object objectHandle { get; set; }
        public AltV.Net.IBaseBaseObjectPool objectHandle { get; set; }

        public ItemModel Copy()
        {
            ItemModel itemModel = new ItemModel();
            itemModel.id = id;
            itemModel.hash = hash;
            itemModel.ownerEntity = ownerEntity;
            itemModel.ownerIdentifier = ownerIdentifier;
            itemModel.amount = amount;
            itemModel.position = position;
            itemModel.dimension = dimension;
            itemModel.ITEM_ART = ITEM_ART;
            itemModel.type = type;
            itemModel.objectHandle = objectHandle;
            return itemModel;
        }
    }
}
