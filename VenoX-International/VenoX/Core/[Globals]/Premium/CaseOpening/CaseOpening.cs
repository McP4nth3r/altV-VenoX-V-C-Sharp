using System.Collections.Generic;
using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using Newtonsoft.Json;
using VenoX.Core._Globals_.Premium.CaseOpening.Models;
using VenoX.Core._RootCore_.Models;

namespace VenoX.Core._Globals_.Premium.CaseOpening
{
    public class Main : IScript
    {
        public const string TypeNormal = "VenoX Normal";
        public const string TypeRare = "VenoX Rare";
        public const string TypeMythical = "VenoX Mythical";
        public const string TypeLegendary = "VenoX Legendary";
        public const string TypeUltimateLegendary = "VenoX ULTIMATE Legendary";
        public static void LoadCaseChances(VnXPlayer player)
        {
            List<CaseChances> caseChances = new List<CaseChances>
            {
                new CaseChances
                {
                    Name = "VenoX Normal",
                    Chance = "79.92",
                    Class = "VenoX_Normal",
                },
                new CaseChances
                {
                    Name = "VenoX Rare",
                    Chance = "15.98",
                    Class = "VenoX_Rare",
                },
                new CaseChances
                {
                    Name = "VenoX Mythical",
                    Chance = "3.2",
                    Class = "VenoX_Mythical",
                },
                new CaseChances
                {
                    Name = "VenoX Legendary",
                    Chance = "0.64",
                    Class = "VenoX_Legendary",
                },
                new CaseChances
                {
                    Name = "VenoX ULTIMATE Legendary",
                    Chance = "0.26",
                    Class = "VenoX_ULTIMATE_Legendary",
                }
            };
            _RootCore_.VenoX.TriggerClientEvent(player, "CaseOpening:LoadChances", JsonConvert.SerializeObject(caseChances));
        }
        public static void LoadCase(VnXPlayer player, string @case)
        {
            List<CaseItemModel> caseItems = new List<CaseItemModel>
            {
                new CaseItemModel
                {
                    Type = TypeNormal,
                    Items = new List<Items>
                    {
                        new Items
                        {
                            Name = "Coins",
                            Info = "6 VnX Coins",
                            Url  = "files/images/venox_coin.png"
                        },
                        new Items
                        {
                            Name = "Coins",
                            Info = "8 VnX Coins",
                            Url  = "files/images/venox_coin.png"
                        },
                        new Items
                        {
                            Name = "Coins",
                            Info = "10 VnX Coins",
                            Url  = "files/images/venox_coin.png"
                        },
                        new Items
                        {
                            Name = "Kokain",
                            Info = "750G Pures Kokain",
                            Url  = "images/kokain.png"
                        }
                    }
                },
                new CaseItemModel
                {
                    Type = TypeRare,
                    Items = new List<Items>
                    {
                        new Items
                        {
                            Name = "Vehicle-Skin-MetallicLavaRed",
                            Info = "Metallic Lava Red - Fahrzeug-Skin",
                            Url  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Vehicle-Skin-PureGold",
                            Info = "Pure Gold - Fahrzeug-Skin",
                            Url  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Vehicle-Skin-MetallicLavaRed",
                            Info = "Metallic Lava Red - Fahrzeug-Skin",
                            Url  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Vehicle-Skin-WornTaxiYellow",
                            Info = "WornTaxiYellow - Fahrzeug-Skin",
                            Url  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Vehicle-Skin-Chrome",
                            Info = "Chrome - Fahrzeug-Skin",
                            Url  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Skin-Gold-Minigun",
                            Info = "Goldene Minigun",
                            Url  = "images/M4A1.png"
                        },

                        new Items
                        {
                            Name = "Skin-Platin-Minigun",
                            Info = "Platin Minigun",
                            Url  = "images/M4A1.png"
                        },

                        new Items
                        {
                            Name = "Skin-Orange-Minigun",
                            Info = "Orange Minigun",
                            Url  = "images/M4A1.png"
                        },

                        new Items
                        {
                            Name = "Skin-Gold-RPG",
                            Info = "Goldene RPG",
                            Url  = "images/M4A1.png"
                        },

                        new Items
                        {
                            Name = "Skin-Platin-RPG",
                            Info = "Platin RPG",
                            Url  = "images/M4A1.png"
                        },

                        new Items
                        {
                            Name = "Skin-Orange-RPG",
                            Info = "Orange RPG",
                            Url  = "images/M4A1.png"
                        }
                    }
                },
                new CaseItemModel
                {
                    Type = TypeMythical,
                    Items = new List<Items>
                    {
                        new Items
                        {
                            Name = "VIP",
                            Info = "SILVER",
                            Url  = "https://www.venox-reallife.com/case/VipSilver.png"
                        },
                        new Items
                        {
                            Name = "VIP",
                            Info = "SILVER",
                            Url  = "https://www.venox-reallife.com/case/VipSilver.png"
                        },
                    }
                },
                new CaseItemModel
                {
                    Type = TypeLegendary,
                    Items = new List<Items>{
                        new Items
                        {
                            Name = "Skin-Gold-CarbineRifle",
                            Info = "Goldene Karabiner",
                            Url  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Skin-Platin-CarbineRifle",
                            Info = "Platin Karabiner",
                            Url  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Skin-Orange-CarbineRifle",
                            Info = "Orange Karabiner",
                            Url  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Skin-Gold-Ak47",
                            Info = "Goldene Ak47",
                            Url  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Skin-Platin-Ak47",
                            Info = "Platin Ak47",
                            Url  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Skin-Orange-Ak47",
                            Info = "Orange Ak47",
                            Url  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Skin-Gold-Sniper",
                            Info = "Goldene Sniper",
                            Url  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Skin-Platin-Sniper",
                            Info = "Platin Sniper",
                            Url  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Skin-Orange-Sniper",
                            Info = "Orange Sniper",
                            Url  = "images/M4A1.png"
                        }
                    }
                },
                new CaseItemModel
                {
                    Type = TypeUltimateLegendary,
                    Items = new List<Items>
                    {
                        new Items
                        {
                            Name = "Skin-Gold-Revolver",
                            Info = "Goldene Revolver",
                            Url  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Skin-Platin-Revolver",
                            Info = "Platin Revolver",
                            Url  = "images/M4A1.png"
                        },
                        new Items
                        {
                            Name = "Skin-Orange-Revolver",
                            Info = "Orange Revolver",
                            Url  = "images/M4A1.png"
                        },
                    }
                }
            };
            _RootCore_.VenoX.TriggerClientEvent(player, "CaseOpening:LoadCase", JsonConvert.SerializeObject(caseItems));
        }


        [Command("opencase")]
        public static void OpenCase(VnXPlayer player)
        {
            _RootCore_.VenoX.TriggerClientEvent(player, "CaseOpening:Show");
            LoadCaseChances(player);
            LoadCase(player, "");
        }
    }
}
