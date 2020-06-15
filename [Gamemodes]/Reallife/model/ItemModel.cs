using AltV.Net.Data;

namespace VenoXV._Gamemodes_.Reallife.model
{
    public class ItemModel
    {
        public int id { get; set; }
        public string hash { get; set; }
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
            ItemModel itemModel = new ItemModel
            {
                id = id,
                hash = hash,
                ownerIdentifier = ownerIdentifier,
                amount = amount,
                position = position,
                dimension = dimension,
                ITEM_ART = ITEM_ART,
                type = type,
                objectHandle = objectHandle
            };
            return itemModel;
        }
    }
}
