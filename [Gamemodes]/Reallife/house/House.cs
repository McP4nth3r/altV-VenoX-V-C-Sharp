using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Models;
using Main = VenoXV._Language_.Main;

namespace VenoXV._Gamemodes_.Reallife.house
{
    public class House : IScript
    {
        public static List<HouseModel> HouseList;

        public static async void LoadDatabaseHouses()
        {
            HouseList = Database.Database.LoadAllHouses();
            foreach (HouseModel houseModel in HouseList)
            {
                string houseLabelText = await GetHouseLabelText(houseModel);
                RageApi.CreateTextLabel(houseLabelText, houseModel.Position, 20.0f, 0.75f, 4, new[] { 255, 255, 255, 255 }, houseModel.Dimension, null, true, true, houseModel.Id);
                //ToDo: Requesting Offices NAPI.World.RequestIpl (houseModel.ipl);
            }
        }

        public static HouseModel GetHouseById(int id)
        {
            HouseModel house = null;
            foreach (HouseModel houseModel in HouseList)
            {
                if (houseModel.Id == id)
                {
                    house = houseModel;
                    break;
                }
            }
            return house;
        }

        public static HouseModel GetClosestHouse(VnXPlayer player, float distance = 1.5f)
        {
            HouseModel house = null;
            foreach (HouseModel houseModel in HouseList)
            {
                if (player.Position.Distance(houseModel.Position) < distance)
                {
                    house = houseModel;
                    distance = player.Position.Distance(houseModel.Position);
                }
            }
            return house;
        }

        public static Position GetHouseExitPoint(string ipl)
        {
            try
            {
                Position exit = new Position(0, 0, 0);
                foreach (HouseIplModel houseIpl in Constants.HouseIplList)
                {
                    if (houseIpl.Ipl == ipl)
                    {
                        exit = houseIpl.Position;
                        break;
                    }
                }
                return exit;
            }
            catch { return new Position(0, 0, 0); }
        }

        public static bool HasPlayerHouseKeys(VnXPlayer player, HouseModel house)
        {
            try
            {
                return (player.Username == house.Owner || player.VnxGetElementData<int>(EntityData.PlayerRentHouse) == house.Id);
            }
            catch { return false; }
        }

        public static async Task<string> GetHouseLabelText(HouseModel house = null, Main.Languages pair = Main.Languages.German, int houseId = 0)
        {
            try
            {
                string label = string.Empty;

                if (pair is Main.Languages.German)
                {

                    switch (house.Status)
                    {
                        case Constants.HouseStateNone:
                            label = "~b~" + house.Name + "\n" + "~b~[ID] : ~w~" + house.Id + "\n" + "~b~Besitzer : ~w~" + house.Owner;
                            break;
                        case Constants.HouseStateRentable:
                            label = "~b~" + house.Name + "\n" + "~b~[ID] : ~w~" + house.Id + "\n" + "~b~Besitzer :~w~" + house.Owner + "\n" + "~b~Zu Vermieten" + "\n" + "~b~Preis : ~w~" + house.Rental + " $";
                            //label = house.name + "\n" + Messages.GEN_STATE_RENT + "\n" + house.rental + "$";
                            break;
                        case Constants.HouseStateBuyable:
                            label = "~b~" + house.Name + "\n" + "~b~[ID] : ~w~" + house.Id + "\n" + "~b~Zu Verkaufen" + "\n" + "~b~Preis : ~w~" + house.Price + " $";
                            break;
                    }
                    return label;
                }

                if (house is null)
                    house = HouseList.FirstOrDefault(x => x.Id == houseId);

                // if house couldn't be found.
                if (house is null) return "";
                switch (house.Status)
                {
                    case Constants.HouseStateNone:
                        label = "~b~" + await Main.GetTranslatedTextAsync(pair, house.Name) + "\n" + "~b~[ID] : ~w~" + house.Id + "\n" + "~b~" + await Main.GetTranslatedTextAsync(pair, "Besitzer") + " : ~w~" + house.Owner;
                        break;
                    case Constants.HouseStateRentable:
                        label = "~b~" + await Main.GetTranslatedTextAsync(pair, house.Name) + "\n" + "~b~[ID] : ~w~" + house.Id + "\n" + "~b~Besitzer :~w~" + house.Owner + "\n" + "~b~" + await Main.GetTranslatedTextAsync(pair, "Zu Vermieten") + "\n" + "~b~" + await Main.GetTranslatedTextAsync(pair, "Preis") + " : ~w~" + house.Rental + " $";
                        //label = house.name + "\n" + Messages.GEN_STATE_RENT + "\n" + house.rental + "$";
                        break;
                    case Constants.HouseStateBuyable:
                        label = "~b~" + await Main.GetTranslatedTextAsync(pair, house.Name) + "\n" + "~b~[ID] : ~w~" + house.Id + "\n" + "~b~" + await Main.GetTranslatedTextAsync(pair, "Zu Verkaufen") + "\n" + "~b~" + await Main.GetTranslatedTextAsync(pair, "Preis") + " : ~w~" + house.Price + " $";
                        break;
                }
                return label;
            }
            catch { return ""; }
        }


        public static async void BuyHouseS(VnXPlayer player, HouseModel house)
        {
            try
            {
                if (house.Status == Constants.HouseStateBuyable)
                {
                    if (player.Reallife.Bank >= house.Price)
                    {
                        string labelText = await GetHouseLabelText(house);
                        player.Reallife.Bank -= house.Price;
                        Logfile.WriteLogs("house", player.Username + " hat sich Haus ID " + house.Id + " gekauft für " + house.Price + " $ ");
                        house.Status = Constants.HouseStateNone;
                        house.Owner = player.Username;
                        house.Locked = true;
                        //house.houseLabel.Text = GetHouseLabelText(house);
                        // Update the house
                        Database.Database.UpdateHouse(house);
                        player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 125, 0) + "Glückwunsch,du hast das Haus gekauft!Für mehr Infos, öffne das Hilfemenü!");
                    }
                    else
                    {
                        player.SendTranslatedChatMessage(Constants.RgbaError + "Du hast nicht genug Geld!");
                    }
                }
            }
            catch { }
        }


        [Command("buyhouse")]
        public void BuyHouseIPlayer(VnXPlayer player)
        {
            try
            {
                // Get all the houses
                foreach (HouseModel house in HouseList)
                {
                    if (house.Owner == player.Username)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast bereits ein Haus! nutze /sellhouse um es zu verkaufen!");
                        return;
                    }
                    if (player.Position.Distance(house.Position) <= 1.5f && player.Dimension == house.Dimension)
                    {
                        BuyHouseS(player, house);
                        return;
                    }
                }
            }
            catch { }
        }

        /*[Command("sellhouse")]
        public static void SellHouseIPlayer(PlayerModel player)
        {
            // Get all the houses
            foreach (HouseModel house in houseList)
            {
                if (house.owner ==player.Username)
                {
                    if (player.vnxGetElementData("SELL_HOUSE_REQUESTED") == true)
                    {
                        int moneyget = house.price / 2;
                        player.vnxSetElementData("SELL_HOUSE_REQUESTED", false);

                        house.owner = string.Empty;
                        house.status = Constants.HOUSE_STATE_BUYABLE;
                        house.tenants = 2;
                        house.rental = 0;
                        house.locked = true;
                        //house.houseLabel.Text = GetHouseLabelText(house);

                        Database.UpdateHouse(house);
                        player.SendTranslatedChatMessage( RageAPI.GetHexColorcode(0,200,0) + "Du hast dein Haus für " + moneyget + " verkauft!");
                        player.vnxSetStreamSharedElementData( VenoXV.Globals.EntityData.PLAYER_MONEY, player.Reallife.Money + moneyget);
                        return;
                    }
                    else
                    {
                        int moneyget = house.price / 2;
                        player.SendTranslatedChatMessage( RageAPI.GetHexColorcode(0,200,0) + "Möchtest du dein Haus verkaufen für " + moneyget + " $ ?");
                        player.SendTranslatedChatMessage( RageAPI.GetHexColorcode(0,200,0) + "Bestätige dies mit /sellhouse.");
                        player.vnxSetElementData("SELL_HOUSE_REQUESTED", true);
                    }
                }
            }
            
        }*/


        [Command("hlock")]
        public void HouseLockIPlayer(VnXPlayer player)
        {
            try
            {
                // Get all the houses
                foreach (HouseModel house in HouseList)
                {
                    if (player.Position.Distance(house.Position) <= 1.5f && player.Dimension == house.Dimension)
                    {
                        if (house.Owner == player.Username)
                        {
                            string state = "Abgeschlossen!";
                            if (house.Locked)
                            {
                                house.Locked = false;
                                state = "Aufgeschlossen!";
                            }
                            else
                            {
                                house.Locked = true;
                            }
                            player.SendTranslatedChatMessage("Haus " + state);
                        }
                        return;
                    }
                }
            }
            catch { }
        }

        [Command("houseinfos")]
        public void GetHouseInfos(VnXPlayer player)
        {
            try
            {
                string status = "Aufgeschlossen";
                // Get all the houses
                foreach (HouseModel house in HouseList)
                {
                    if (house.Owner == player.Username)
                    {
                        if (house.Locked) { status = "Abgeschlossen"; }
                        player.SendTranslatedChatMessage("__________________________________________");
                        player.SendTranslatedChatMessage("HAUS : " + house.Name);
                        player.SendTranslatedChatMessage("HAUS ID : " + house.Id);
                        player.SendTranslatedChatMessage("HAUS status : " + status);
                        player.SendTranslatedChatMessage("HAUS Miete  : " + house.Rental + " $");
                        player.SendTranslatedChatMessage("__________________________________________");
                    }
                }
            }
            catch { }
        }




        //[AltV.Net.ClientEvent("getPlayerPurchasedClothes")]
        public void GetPlayerPurchasedClothesEvent(VnXPlayer player, int type, int slot)
        {
            try
            {
                int playerId = player.UID;
                int sex = player.Sex;

                List<ClothesModel> clothesList = Globals.Main.GetPlayerClothes(playerId).Where(c => c.Type == type && c.Slot == slot).ToList();

                if (clothesList.Count > 0)
                {
                    List<string> clothesNames = Globals.Main.GetClothesNames(clothesList);

                    // Show player's clothes
                    VenoX.TriggerClientEvent(player, "showPlayerClothes", JsonConvert.SerializeObject(clothesList), JsonConvert.SerializeObject(clothesNames));
                }
                else
                {
                    player.SendTranslatedChatMessage(Constants.RgbaError + "Keine Klamotten im Klamottenschrank");
                }
            }
            catch { }
        }

        //[VnXEvent("wardrobeClothesItemSelected")]
        public void WardrobeClothesItemSelectedEvent(VnXPlayer player, int clothesId)
        {
            try
            {
                int playerId = player.UID;

                // Replace player clothes for the new ones
                foreach (ClothesModel clothes in Globals.Main.ClothesList)
                {
                    if (clothes.Id == clothesId)
                    {
                        clothes.Dressed = true;
                        if (clothes.Type == 0)
                        {
                            //ToDo Sie Clientseitig Laden! : player.SetClothes(clothes.slot, clothes.drawable, clothes.texture);
                        }

                        // Update dressed clothes into database
                        Database.Database.UpdateClothes(clothes);
                    }
                    else if (clothes.Id != clothesId && clothes.Dressed)
                    {
                        clothes.Dressed = false;

                        // Update dressed clothes into database
                        Database.Database.UpdateClothes(clothes);
                    }
                }
            }
            catch { }
        }


        [Command("setrent")]
        public void RentableCommand(VnXPlayer player, int amount = 0)
        {
            if (player.VnxGetElementData<int>(EntityData.PlayerHouseEntered) == 0)
            {
                _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Dein Haus ist jetzt nicht mehr Mietbar!");
            }
            else
            {

                int houseId = player.VnxGetElementData<int>(EntityData.PlayerHouseEntered);
                HouseModel house = GetHouseById(houseId);
                if (house == null || house.Owner != player.Username)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Dir gehört kein Haus!");
                }
                else if (amount > 0)
                {
                    if (amount <= 5000)
                    {
                        house.Rental = amount;
                        house.Status = Constants.HouseStateRentable;
                        house.Tenants = 2;

                        //house.houseLabel.Text = GetHouseLabelText(house);
                        Database.Database.UpdateHouse(house);
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Miete muss kleiner als 5000 sein!");
                    }

                }
                /*else if (house.status == Constants.HOUSE_STATE_RENTABLE)
                {
                    house.status = Constants.HOUSE_STATE_NONE;
                    house.tenants = 2;
                    //house.houseLabel.Text = GetHouseLabelText(house);
                    //Database.KickTenantsOut(house.id);
                    Database.UpdateHouse(house);
                }*/
                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Miete muss größer als 0 sein!");
                }
            }
        }


        [Command("renthouse")]
        public void RentCommand(VnXPlayer player)
        {
            foreach (HouseModel house in HouseList)
            {
                if (player.Position.Distance(house.Position) <= 1.5 && player.Dimension == house.Dimension)
                {
                    if (player.VnxGetElementData<int>(EntityData.PlayerRentHouse) == 0)
                    {
                        if (house.Status != Constants.HouseStateRentable)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Dieses Haus steht nicht zur Vermietung!");
                        }
                        else if (player.Reallife.Money < house.Rental)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        }
                        else
                        {
                            int money = player.Reallife.Money - house.Rental;
                            player.VnxSetElementData(EntityData.PlayerRentHouse, house.Id);
                            player.VnxSetStreamSharedElementData(VnX.PlayerMoney, money);
                            //house.tenants--;

                            /*if (house.tenants == 0)
                            {
                                house.status = Constants.HOUSE_STATE_NONE;
                                //house.houseLabel.Text = GetHouseLabelText(house);
                            }
                            Database.UpdateHouse(house);*/
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Du hast dich Erfolgreich Eingemietet!");
                        }
                        break;
                    }
                    /*else if (player.vnxGetElementData<int>(EntityData.PLAYER_RENT_HOUSE) == house.id)
                    {
                        player.vnxSetElementData(EntityData.PLAYER_RENT_HOUSE, 0);
                        house.tenants++;
                        Database.UpdateHouse(house);

                    }*/

                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast bereits eine Wohnung!");
                }
            }
        }


        [Command("unrenthouse")]

        public static void UnrentFromHaus(VnXPlayer player)
        {
            if (player.VnxGetElementData<int>(EntityData.PlayerRentHouse) <= 0)
            {
                player.VnxSetElementData(EntityData.PlayerRentHouse, 0);
                //player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0,200,0) + "DEBUG RENT");
            }
            if (player.VnxGetElementData<int>(EntityData.PlayerRentHouse) != 0)
            {
                player.VnxSetElementData(EntityData.PlayerRentHouse, 0);
                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 0) + "Du hast dich Erfolgreich ausgemietet!");
                //Database.KickTenantsOut(house.id);
            }
        }

    }
}
