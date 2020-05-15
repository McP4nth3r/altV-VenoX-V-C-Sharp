using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using VenoXV._Gamemodes_.Reallife.database;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.factions
{
    public class Fraktionswaffenlager : IScript
    {
        [Command("fweapons")]
        public void FWeapons_CMD(Client player)
        {
            try
            {
                if (player.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == 0)
                {
                    dxLibary.VnX.DrawNotification(player, "error", "Du bist in keiner Fraktion!");
                }
                else
                {
                    player.SendTranslatedChatMessage("Fraktions ID : " + player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                    Fraktions_Waffenlager fweapon = Database.GetFactionWaffenlager(player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                    player.SendTranslatedChatMessage("weapon_knuckle : " + fweapon.weapon_knuckle);
                    player.SendTranslatedChatMessage("weapon_nightstick : " + fweapon.weapon_nightstick);
                    player.SendTranslatedChatMessage("weapon_stungun : " + fweapon.weapon_tazer);
                    player.SendTranslatedChatMessage("weapon_pistol50 : " + fweapon.weapon_pistol50);
                    player.SendTranslatedChatMessage("weapon_revolver : " + fweapon.weapon_revolver);
                    player.SendTranslatedChatMessage("weapon_pistol : " + fweapon.weapon_pistol);
                    player.SendTranslatedChatMessage("weapon_pumpshotgun : " + fweapon.weapon_pumpshotgun);
                    player.SendTranslatedChatMessage("weapon_combatpdw : " + fweapon.weapon_combatpdw);
                    player.SendTranslatedChatMessage("weapon_assaultrifle : " + fweapon.weapon_assaultrifle);
                    player.SendTranslatedChatMessage("weapon_advancedrifle : " + fweapon.weapon_advancedrifle);
                    player.SendTranslatedChatMessage("weapon_gusenberg : " + fweapon.weapon_gusenberg);
                    player.SendTranslatedChatMessage("weapon_sniperrifle : " + fweapon.weapon_sniperrifle);
                    player.SendTranslatedChatMessage("weapon_rpg : " + fweapon.weapon_rpg);
                    player.SendTranslatedChatMessage("weapon_molotov : " + fweapon.weapon_molotov);
                    player.SendTranslatedChatMessage("weapon_smokegrenade : " + fweapon.weapon_smokegrenade);
                    player.SendTranslatedChatMessage("weapon_bzgas : " + fweapon.weapon_bzgas);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EXCEPTION FWeapons_CMD] " + ex.Message);
                Console.WriteLine("[EXCEPTION FWeapons_CMD] " + ex.StackTrace);
            }
        }



        public static IColShape SWT_COL = Alt.CreateColShapeSphere(new Position(1853.666f, 3688.104f, 34f), 1);
        public static IColShape WT_COL = Alt.CreateColShapeSphere(new Position(2853.49f, 1502.488f, 24.72436f), 1);

        public static void OnPlayerEnterIColShape(IColShape shape, Client player)
        {
            try
            {
                if (shape == SWT_COL && Allround.isStateFaction(player))
                {
                    Fraktions_Waffenlager fweapon = Database.GetFactionWaffenlager(Constants.FACTION_POLICE);
                    player.Emit("ShowStaatswaffentruck_C", "Staatswaffentruck",

                        "Schlagstock [" + Constants.NIGHTSTICK_LAGER + "$]",
                        "Tazer [" + Constants.STUNGUN_LAGER + "$]",
                        "Pistol [" + Constants.PISTOL_LAGER + "$]",
                        "Magazin [" + Constants.PISTOL_AMMO_LAGER + "$]",
                        "Pistol50 [" + Constants.PISTOL50_LAGER + "$]",
                        "Magazin [" + Constants.PISTOL50_AMMO_LAGER + "$]",
                        "Shotgun [" + Constants.SHOTGUN_LAGER + "$]",
                        "Magazin [" + Constants.SHOTGUN_AMMO_LAGER + "$]",
                        "PDW [" + Constants.COMBATPDW_LAGER + "$]",
                        "Magazin [" + Constants.COMBATPDW_AMMO_LAGER + "$]",
                        "Karabiner [" + Constants.KARABINER_LAGER + "$]",
                        "Magazin [" + Constants.KARABINER_AMMO_LAGER + "$]",
                        "Advancedrifle[" + Constants.ADVANCEDRIFLE_LAGER + "$]",
                        "Magazin[" + Constants.ADVANCEDRIFLE_AMMO_LAGER + "$]",
                        "Sniper [" + Constants.SNIPER_LAGER + "$]",
                        "Magazin [" + Constants.SNIPER_AMMO_LAGER + "$]",
                        "Tränengas [" + Constants.TRAENENGAS_LAGER + "$]",



                        "Schlagstock = " + fweapon.weapon_nightstick + "/" + Constants.NIGHTSTICK_MAX_LAGER,

                        "Tazer = " + fweapon.weapon_tazer + "/" + Constants.STUNGUN_MAX_LAGER,

                        "Pistol = " + fweapon.weapon_pistol + "/" + Constants.PISTOL_MAX_LAGER + " || Magazin = " + fweapon.weapon_pistol_ammo + "/" + Constants.PISTOL_AMMO_MAX_LAGER,

                        "Shotgun = " + fweapon.weapon_pumpshotgun + "/" + Constants.SHOTGUN_MAX_LAGER + " || Magazin = " + fweapon.weapon_pumpshotgun_ammo + "/" + Constants.SHOTGUN_AMMO_MAX_LAGER,

                        "PDW = " + fweapon.weapon_combatpdw + "/" + Constants.COMBATPDW_MAX_LAGER + " || Magazin = " + fweapon.weapon_combatpdw_ammo + "/" + Constants.COMBATPDW_AMMO_MAX_LAGER,

                        "Karabiner = " + fweapon.weapon_carbinerifle + "/" + Constants.KARABINER_MAX_LAGER + " || Magazin = " + fweapon.weapon_carbinerifle_ammo + "/" + Constants.KARABINER_AMMO_MAX_LAGER,

                        "Advancedrifle = " + fweapon.weapon_advancedrifle + "/" + Constants.ADVANCEDRIFLE_MAX_LAGER + " || Magazin = " + fweapon.weapon_advancedrifle_ammo + "/" + Constants.ADVANCEDRIFLE_AMMO_MAX_LAGER,

                        "Sniper = " + fweapon.weapon_sniperrifle + "/" + Constants.SNIPER_MAX_LAGER + " || Magazin = " + fweapon.weapon_sniperrifle_ammo + "/" + Constants.SNIPER_AMMO_MAX_LAGER,

                        "Tränengas = " + fweapon.weapon_smokegrenade + "/" + Constants.TRAENENGAS_MAX_LAGER,

                        "Kaufliste löschen"


                        );
                }
                else if (shape == WT_COL && Allround.isBadFaction(player))
                {
                    Fraktions_Waffenlager fweapon = Database.GetFactionWaffenlager(player.vnxGetElementData<int>(EntityData.PLAYER_FACTION));
                    player.Emit("ShowWaffentruck_C", "Waffentruck",

                        "Baseball [" + Constants.NIGHTSTICK_LAGER + "$]",

                        "Pistol [" + Constants.PISTOL_LAGER + "$]",
                        "Magazin [" + Constants.PISTOL_AMMO_LAGER + "$]",

                        "Pistol50 [" + Constants.PISTOL50_LAGER + "$]",
                        "Magazin [" + Constants.PISTOL50_AMMO_LAGER + "$]",

                        "Revolver [" + Constants.REVOLVER_LAGER + "$]",
                        "Magazin [" + Constants.REVOLVER_AMMO_LAGER + "$]",

                        "MP5 [" + Constants.MP5_LAGER + "$]",
                        "Magazin [" + Constants.MP5_AMMO_LAGER + "$]",

                        "Ak47 [" + Constants.AK47_LAGER + "$]",
                        "Magazin [" + Constants.AK47_AMMO_LAGER + "$]",

                        "Rifle [" + Constants.RIFLE_LAGER + "$]",
                        "Magazin[" + Constants.RIFLE_AMMO_LAGER + "$]",

                        "Sniper [" + Constants.SNIPER_LAGER + "$]",
                        "Magazin [" + Constants.SNIPER_AMMO_LAGER + "$]",

                        "RPG [" + Constants.RPG_LAGER + "$]",
                        "Schuss [" + Constants.RPG_AMMO_LAGER + "$]",

                        "Molotov [" + Constants.MOLOTOV_LAGER + "$]",



                        "Baseball = " + fweapon.weapon_baseball + "/" + Constants.BASEBALL_MAX_LAGER,

                        "Pistol = " + fweapon.weapon_pistol + "/" + Constants.PISTOL_MAX_LAGER + " || Magazin = " + fweapon.weapon_pistol_ammo + "/" + Constants.PISTOL_AMMO_MAX_LAGER,

                        "Pistol50 = " + fweapon.weapon_pistol50 + "/" + Constants.PISTOL50_MAX_LAGER + " || Magazin = " + fweapon.weapon_pistol50_ammo + "/" + Constants.PISTOL50_AMMO_MAX_LAGER,

                        "Revolver = " + fweapon.weapon_revolver + "/" + Constants.REVOLVER_MAX_LAGER + " || Magazin = " + fweapon.weapon_revolver_ammo + "/" + Constants.REVOLVER_AMMO_MAX_LAGER,

                        "MP5 = " + fweapon.weapon_mp5 + "/" + Constants.MP5_MAX_LAGER + " || Magazin = " + fweapon.weapon_mp5_ammo + "/" + Constants.MP5_AMMO_MAX_LAGER,

                        "Ak - 47 = " + fweapon.weapon_assaultrifle + "/" + Constants.AK47_MAX_LAGER + " || Magazin = " + fweapon.weapon_assaultrifle_ammo + "/" + Constants.AK47_AMMO_MAX_LAGER,

                        "Rifle = " + fweapon.weapon_rifle + "/" + Constants.RIFLE_MAX_LAGER + " || Magazin = " + fweapon.weapon_rifle_ammo + "/" + Constants.RIFLE_AMMO_MAX_LAGER,

                        "Sniper = " + fweapon.weapon_sniperrifle + "/" + Constants.SNIPER_MAX_LAGER + " || Magazin = " + fweapon.weapon_sniperrifle_ammo + "/" + Constants.SNIPER_AMMO_MAX_LAGER,

                        "RPG = " + fweapon.weapon_rpg + "/" + Constants.RPG_MAX_LAGER + " || Magazin = " + fweapon.weapon_rpg_ammo + "/" + Constants.RPG_MAX_LAGER,

                        "Molotov = " + fweapon.weapon_molotov + "/" + Constants.MOLOTOV_MAX_LAGER,

                        "Kaufliste löschen"


                        );
                }
            }
            catch
            {
            }
        }
    }
}
