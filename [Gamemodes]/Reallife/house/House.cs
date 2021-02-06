using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.house
{
    public class House : IScript
    {
        public static List<HouseModel> houseList;

        public static async void LoadDatabaseHouses()
        {
            houseList = Database.LoadAllHouses();
            foreach (HouseModel houseModel in houseList)
            {
                string houseLabelText = await GetHouseLabelText(houseModel);
                RageAPI.CreateTextLabel(houseLabelText, houseModel.position, 20.0f, 0.75f, 4, new int[] { 255, 255, 255, 255 }, houseModel.Dimension, null, true, true, houseModel.id);
                //ToDo: Requesting Offices NAPI.World.RequestIpl (houseModel.ipl);
            }
        }

        public static HouseModel GetHouseById(int id)
        {
            HouseModel house = null;
            foreach (HouseModel houseModel in houseList)
            {
                if (houseModel.id == id)
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
            foreach (HouseModel houseModel in houseList)
            {
                if (player.Position.Distance(houseModel.position) < distance)
                {
                    house = houseModel;
                    distance = player.Position.Distance(houseModel.position);
                }
            }
            return house;
        }

        public static Position GetHouseExitPoint(string ipl)
        {
            try
            {
                Position exit = new Position(0, 0, 0);
                foreach (HouseIplModel houseIpl in Constants.HOUSE_IPL_LIST)
                {
                    if (houseIpl.ipl == ipl)
                    {
                        exit = houseIpl.position;
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
                return (player.Username == house.owner || player.vnxGetElementData<int>(EntityData.PLAYER_RENT_HOUSE) == house.id);
            }
            catch { return false; }
        }

        public static async Task<string> GetHouseLabelText(HouseModel house = null, _Language_.Main.Languages pair = _Language_.Main.Languages.German, int houseId = 0)
        {
            try
            {
                string label = string.Empty;

                if (pair is _Language_.Main.Languages.German)
                {

                    switch (house.status)
                    {
                        case Constants.HOUSE_STATE_NONE:
                            label = "~b~" + house.name + "\n" + "~b~[ID] : ~w~" + house.id + "\n" + "~b~Besitzer : ~w~" + house.owner;
                            break;
                        case Constants.HOUSE_STATE_RENTABLE:
                            label = "~b~" + house.name + "\n" + "~b~[ID] : ~w~" + house.id + "\n" + "~b~Besitzer :~w~" + house.owner + "\n" + "~b~Zu Vermieten" + "\n" + "~b~Preis : ~w~" + house.rental + " $";
                            //label = house.name + "\n" + Messages.GEN_STATE_RENT + "\n" + house.rental + "$";
                            break;
                        case Constants.HOUSE_STATE_BUYABLE:
                            label = "~b~" + house.name + "\n" + "~b~[ID] : ~w~" + house.id + "\n" + "~b~Zu Verkaufen" + "\n" + "~b~Preis : ~w~" + house.price + " $";
                            break;
                    }
                    return label;
                }
                else
                {
                    if (house is null)
                        house = houseList.FirstOrDefault(x => x.id == houseId);

                    // if house couldn't be found.
                    if (house is null) return "";
                    switch (house.status)
                    {
                        case Constants.HOUSE_STATE_NONE:
                            label = "~b~" + await _Language_.Main.GetTranslatedTextAsync(pair, house.name) + "\n" + "~b~[ID] : ~w~" + house.id + "\n" + "~b~" + await _Language_.Main.GetTranslatedTextAsync(pair, "Besitzer") + " : ~w~" + house.owner;
                            break;
                        case Constants.HOUSE_STATE_RENTABLE:
                            label = "~b~" + await _Language_.Main.GetTranslatedTextAsync(pair, house.name) + "\n" + "~b~[ID] : ~w~" + house.id + "\n" + "~b~Besitzer :~w~" + house.owner + "\n" + "~b~" + await _Language_.Main.GetTranslatedTextAsync(pair, "Zu Vermieten") + "\n" + "~b~" + await _Language_.Main.GetTranslatedTextAsync(pair, "Preis") + " : ~w~" + house.rental + " $";
                            //label = house.name + "\n" + Messages.GEN_STATE_RENT + "\n" + house.rental + "$";
                            break;
                        case Constants.HOUSE_STATE_BUYABLE:
                            label = "~b~" + await _Language_.Main.GetTranslatedTextAsync(pair, house.name) + "\n" + "~b~[ID] : ~w~" + house.id + "\n" + "~b~" + await _Language_.Main.GetTranslatedTextAsync(pair, "Zu Verkaufen") + "\n" + "~b~" + await _Language_.Main.GetTranslatedTextAsync(pair, "Preis") + " : ~w~" + house.price + " $";
                            break;
                    }
                    return label;
                }
            }
            catch { return ""; }
        }


        public static async void BuyHouseS(VnXPlayer player, HouseModel house)
        {
            try
            {
                if (house.status == Constants.HOUSE_STATE_BUYABLE)
                {
                    if (player.Reallife.Bank >= house.price)
                    {
                        string labelText = await GetHouseLabelText(house);
                        player.Reallife.Bank -= house.price;
                        logfile.WriteLogs("house", player.Username + " hat sich Haus ID " + house.id + " gekauft für " + house.price + " $ ");
                        house.status = Constants.HOUSE_STATE_NONE;
                        house.owner = player.Username;
                        house.locked = true;
                        //house.houseLabel.Text = GetHouseLabelText(house);
                        // Update the house
                        Database.UpdateHouse(house);
                        player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 125, 0) + "Glückwunsch,du hast das Haus gekauft!Für mehr Infos, öffne das Hilfemenü!");
                    }
                    else
                    {
                        player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "Du hast nicht genug Geld!");
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
                foreach (HouseModel house in houseList)
                {
                    if (house.owner == player.Username)
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast bereits ein Haus! nutze /sellhouse um es zu verkaufen!");
                        return;
                    }
                    if (player.Position.Distance(house.position) <= 1.5f && player.Dimension == house.Dimension)
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
                foreach (HouseModel house in houseList)
                {
                    if (player.Position.Distance(house.position) <= 1.5f && player.Dimension == house.Dimension)
                    {
                        if (house.owner == player.Username)
                        {
                            string State = "Abgeschlossen!";
                            if (house.locked)
                            {
                                house.locked = false;
                                State = "Aufgeschlossen!";
                            }
                            else
                            {
                                house.locked = true;
                            }
                            player.SendTranslatedChatMessage("Haus " + State);
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
                foreach (HouseModel house in houseList)
                {
                    if (house.owner == player.Username)
                    {
                        if (house.locked == true) { status = "Abgeschlossen"; }
                        player.SendTranslatedChatMessage("__________________________________________");
                        player.SendTranslatedChatMessage("HAUS : " + house.name);
                        player.SendTranslatedChatMessage("HAUS ID : " + house.id);
                        player.SendTranslatedChatMessage("HAUS status : " + status);
                        player.SendTranslatedChatMessage("HAUS Miete  : " + house.rental + " $");
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

                List<ClothesModel> clothesList = Main.GetPlayerClothes(playerId).Where(c => c.type == type && c.slot == slot).ToList();

                if (clothesList.Count > 0)
                {
                    List<string> clothesNames = Main.GetClothesNames(clothesList);

                    // Show player's clothes
                    VenoX.TriggerClientEvent(player, "showPlayerClothes", JsonConvert.SerializeObject(clothesList), JsonConvert.SerializeObject(clothesNames));
                }
                else
                {
                    player.SendTranslatedChatMessage(Constants.Rgba_ERROR + "Keine Klamotten im Klamottenschrank");
                }
            }
            catch { }
        }

        //[ClientEvent("wardrobeClothesItemSelected")]
        public void WardrobeClothesItemSelectedEvent(VnXPlayer player, int clothesId)
        {
            try
            {
                int playerId = player.UID;

                // Replace player clothes for the new ones
                foreach (ClothesModel clothes in Main.clothesList)
                {
                    if (clothes.id == clothesId)
                    {
                        clothes.dressed = true;
                        if (clothes.type == 0)
                        {
                            //ToDo Sie Clientseitig Laden! : player.SetClothes(clothes.slot, clothes.drawable, clothes.texture);
                        }
                        else
                        {
                            //player.SetAccessories(clothes.slot, clothes.drawable, clothes.texture);
                        }

                        // Update dressed clothes into database
                        Database.UpdateClothes(clothes);
                    }
                    else if (clothes.id != clothesId && clothes.dressed)
                    {
                        clothes.dressed = false;

                        // Update dressed clothes into database
                        Database.UpdateClothes(clothes);
                    }
                }
            }
            catch { }
        }


        [Command("setrent")]
        public void RentableCommand(VnXPlayer player, int amount = 0)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_HOUSE_ENTERED) == 0)
            {
                _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Dein Haus ist jetzt nicht mehr Mietbar!");
            }
            else
            {

                int houseId = player.vnxGetElementData<int>(EntityData.PLAYER_HOUSE_ENTERED);
                HouseModel house = GetHouseById(houseId);
                if (house == null || house.owner != player.Username)
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Dir gehört kein Haus!");
                }
                else if (amount > 0)
                {
                    if (amount <= 5000)
                    {
                        house.rental = amount;
                        house.status = Constants.HOUSE_STATE_RENTABLE;
                        house.tenants = 2;

                        //house.houseLabel.Text = GetHouseLabelText(house);
                        Database.UpdateHouse(house);
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
            foreach (HouseModel house in houseList)
            {
                if (player.Position.Distance(house.position) <= 1.5 && player.Dimension == house.Dimension)
                {
                    if (player.vnxGetElementData<int>(EntityData.PLAYER_RENT_HOUSE) == 0)
                    {
                        if (house.status != Constants.HOUSE_STATE_RENTABLE)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Dieses Haus steht nicht zur Vermietung!");
                        }
                        else if (player.Reallife.Money < house.rental)
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast nicht genug Geld!");
                        }
                        else
                        {
                            int money = player.Reallife.Money - house.rental;
                            player.vnxSetElementData(EntityData.PLAYER_RENT_HOUSE, house.id);
                            player.vnxSetStreamSharedElementData(Core.VnX.PLAYER_MONEY, money);
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
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du hast bereits eine Wohnung!");
                    }
                }
            }
        }


        [Command("unrenthouse")]

        public static void UnrentFromHaus(VnXPlayer player)
        {
            if (player.vnxGetElementData<int>(EntityData.PLAYER_RENT_HOUSE) <= 0)
            {
                player.vnxSetElementData(EntityData.PLAYER_RENT_HOUSE, 0);
                //player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0,200,0) + "DEBUG RENT");
            }
            if (player.vnxGetElementData<int>(EntityData.PLAYER_RENT_HOUSE) != 0)
            {
                player.vnxSetElementData(EntityData.PLAYER_RENT_HOUSE, 0);
                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 0) + "Du hast dich Erfolgreich ausgemietet!");
                //Database.KickTenantsOut(house.id);
            }
        }

    }
}
