using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;
using System.Collections.Generic;
using VenoXV._Globals_.Premium.CaseOpening;
using VenoXV._RootCore_.Models;

namespace VenoXV._Globals_.Premium
{
    public class Main : IScript
    {
        public const string TYPE_NORMAL = "VenoX Normal";
        public const string TYPE_RARE = "VenoX Rare";
        public const string TYPE_MYTHICAL = "VenoX Mythical";
        public const string TYPE_LEGENDARY = "VenoX Legendary";
        public const string TYPE_ULTIMATE_LEGENDARY = "VenoX ULTIMATE Legendary";
        public static void LoadCaseChances(VnXPlayer player)
        {
            List<CaseChances> CaseChances = new List<CaseChances>
            {
                new CaseChances()
                {
                    Name = "VenoX Normal",
                    Chance = "79.92",
                    Class = "VenoX_Normal",
                },
                new CaseChances()
                {
                    Name = "VenoX Rare",
                    Chance = "15.98",
                    Class = "VenoX_Rare",
                },
                new CaseChances()
                {
                    Name = "VenoX Mythical",
                    Chance = "3.2",
                    Class = "VenoX_Mythical",
                },
                new CaseChances()
                {
                    Name = "VenoX Legendary",
                    Chance = "0.64",
                    Class = "VenoX_Legendary",
                },
                new CaseChances()
                {
                    Name = "VenoX ULTIMATE Legendary",
                    Chance = "0.26",
                    Class = "VenoX_ULTIMATE_Legendary",
                }
            };
            Alt.Server.TriggerClientEvent(player, "CaseOpening:LoadChances", JsonConvert.SerializeObject(CaseChances));
        }
        public static void LoadCase(VnXPlayer player, string Case)
        {
            List<CaseItemModel> CaseItems = new List<CaseItemModel>
            {
                new CaseItemModel()
                {
                    Type = TYPE_NORMAL,
                    Items = new List<Items>
                    {
                        new Items
                        {
                            Name = "Coins",
                            Info = "6 VnX Coins",
                            URL  = "files/images/venox_coin.png"
                        },
                        new Items
                        {
                            Name = "Coins",
                            Info = "8 VnX Coins",
                            URL  = "files/images/venox_coin.png"
                        },
                        new Items
                        {
                            Name = "Coins",
                            Info = "10 VnX Coins",
                            URL  = "files/images/venox_coin.png"
                        },
                        new Items
                        {
                            Name = "Kokain",
                            Info = "750G Pures Kokain",
                            URL  = "images/kokain.png"
                        }
                    }
                },
                new CaseItemModel()
                {
                    Type = TYPE_RARE,
                    Items = new List<Items>
                    {
                        new Items
                        {
                            Name = "Vehicle-Skin-MetallicLavaRed",
                            Info = "Metallic Lava Red - Fahrzeug-Skin",
                            URL  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Vehicle-Skin-PureGold",
                            Info = "Pure Gold - Fahrzeug-Skin",
                            URL  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Vehicle-Skin-MetallicLavaRed",
                            Info = "Metallic Lava Red - Fahrzeug-Skin",
                            URL  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Vehicle-Skin-WornTaxiYellow",
                            Info = "WornTaxiYellow - Fahrzeug-Skin",
                            URL  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Vehicle-Skin-Chrome",
                            Info = "Chrome - Fahrzeug-Skin",
                            URL  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Skin-Gold-Minigun",
                            Info = "Goldene Minigun",
                            URL  = "images/M4A1.png"
                        },

                        new Items
                        {
                            Name = "Skin-Platin-Minigun",
                            Info = "Platin Minigun",
                            URL  = "images/M4A1.png"
                        },

                        new Items
                        {
                            Name = "Skin-Orange-Minigun",
                            Info = "Orange Minigun",
                            URL  = "images/M4A1.png"
                        },

                        new Items
                        {
                            Name = "Skin-Gold-RPG",
                            Info = "Goldene RPG",
                            URL  = "images/M4A1.png"
                        },

                        new Items
                        {
                            Name = "Skin-Platin-RPG",
                            Info = "Platin RPG",
                            URL  = "images/M4A1.png"
                        },

                        new Items
                        {
                            Name = "Skin-Orange-RPG",
                            Info = "Orange RPG",
                            URL  = "images/M4A1.png"
                        }
                    }
                },
                new CaseItemModel()
                {
                    Type = TYPE_MYTHICAL,
                    Items = new List<Items>
                    {
                        new Items
                        {
                            Name = "VIP",
                            Info = "SILVER",
                            URL  = "https://www.venox-reallife.com/case/VipSilver.png"
                        },
                        new Items
                        {
                            Name = "VIP",
                            Info = "SILVER",
                            URL  = "https://www.venox-reallife.com/case/VipSilver.png"
                        },
                    }
                },
                new CaseItemModel()
                {
                    Type = TYPE_LEGENDARY,
                    Items = new List<Items>{
                        new Items
                        {
                            Name = "Skin-Gold-CarbineRifle",
                            Info = "Goldene Karabiner",
                            URL  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Skin-Platin-CarbineRifle",
                            Info = "Platin Karabiner",
                            URL  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Skin-Orange-CarbineRifle",
                            Info = "Orange Karabiner",
                            URL  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Skin-Gold-Ak47",
                            Info = "Goldene Ak47",
                            URL  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Skin-Platin-Ak47",
                            Info = "Platin Ak47",
                            URL  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Skin-Orange-Ak47",
                            Info = "Orange Ak47",
                            URL  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Skin-Gold-Sniper",
                            Info = "Goldene Sniper",
                            URL  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Skin-Platin-Sniper",
                            Info = "Platin Sniper",
                            URL  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Skin-Orange-Sniper",
                            Info = "Orange Sniper",
                            URL  = "images/M4A1.png"
                        }
                    }
                },
                new CaseItemModel()
                {
                    Type = TYPE_ULTIMATE_LEGENDARY,
                    Items = new List<Items>()
                    {
                        new Items
                        {
                            Name = "Skin-Gold-Revolver",
                            Info = "Goldene Revolver",
                            URL  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Skin-Platin-Revolver",
                            Info = "Platin Revolver",
                            URL  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Skin-Orange-Revolver",
                            Info = "Orange Revolver",
                            URL  = "images/M4A1.png"
                        },
                    }
                }
            };
            Alt.Server.TriggerClientEvent(player, "CaseOpening:LoadCase", JsonConvert.SerializeObject(CaseItems));
        }


        [Command("opencase")]
        public static void OpenCase(VnXPlayer player)
        {
            Alt.Server.TriggerClientEvent(player, "CaseOpening:Show");
            LoadCaseChances(player);
            LoadCase(player, "");
        }
    }
}
