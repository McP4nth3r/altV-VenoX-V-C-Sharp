using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.Vehicles;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.register_login
{
    public class Main : IScript
    {
        public static void InitializePlayerData(IPlayer player)
        {
            try
            {
                // Spawn pos 2
                player.SpawnPlayer(player.Position);
                Position rotation = new Position(0.0f, 0.0f, 0.0f);
                player.Position = new Position(152.26f, -1004.47f, -99.00f);
                player.Dimension = player.Id;

                player.Health = 100;
                player.Armor = 0;

                // Clear weapons 
                player.RemoveAllWeapons();

                // Initialize shared entity data
                player.SetVnXName("Random-Player");
                player.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_MONEY, 0);
                player.vnxSetElementData(EntityData.PLAYER_PLAYING, false);
                // Initialize entity data
                player.vnxSetElementData(EntityData.PLAYER_SPAWN_POS, new Position(-2286.745f, 356.3762f, 175.317f));
                player.vnxSetElementData(EntityData.PLAYER_SPAWN_ROT, rotation);
                player.vnxSetElementData(EntityData.PLAYER_ADMIN_RANK, 0);
                player.vnxSetElementData(EntityData.PLAYER_PHONE, 0);
                player.vnxSetElementData(EntityData.PLAYER_KILLED, 0);
                player.vnxSetElementData(EntityData.PLAYER_FACTION, 0);
                player.vnxSetElementData(EntityData.PLAYER_ZIVIZEIT, DateTime.Now);
                player.vnxSetElementData(EntityData.PLAYER_JOB, "-");
                player.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_VIP_LEVEL, "-");
                player.vnxSetElementData(EntityData.PLAYER_LIEFERJOB_LEVEL, 0);
                player.vnxSetElementData(EntityData.PLAYER_BUSJOB_LEVEL, 0);
                player.vnxSetElementData(EntityData.PLAYER_AIRPORTJOB_LEVEL, 0);
                player.vnxSetElementData(EntityData.PLAYER_ON_DUTY, 0);
                player.vnxSetElementData(EntityData.PLAYER_RENT_HOUSE, 0);
                player.vnxSetElementData(EntityData.PLAYER_HOUSE_ENTERED, 0);
                player.vnxSetElementData(EntityData.PLAYER_BUSINESS_ENTERED, 0);

                player.vnxSetElementData(EntityData.PLAYER_PERSONALAUSWEIS, 0);
                player.vnxSetElementData(EntityData.PLAYER_FÜHRERSCHEIN, 0);
                player.vnxSetElementData(EntityData.PLAYER_MOTORRAD_FÜHRERSCHEIN, 0);
                player.vnxSetElementData(EntityData.PLAYER_LKW_FÜHRERSCHEIN, 0);
                player.vnxSetElementData(EntityData.PLAYER_HELIKOPTER_FÜHRERSCHEIN, 0);
                player.vnxSetElementData(EntityData.PLAYER_FLUGSCHEIN_A_FÜHRERSCHEIN, 0);
                player.vnxSetElementData(EntityData.PLAYER_FLUGSCHEIN_B_FÜHRERSCHEIN, 0);
                player.vnxSetElementData(EntityData.PLAYER_MOTORBOOT_FÜHRERSCHEIN, 0);
                player.vnxSetElementData(EntityData.PLAYER_ANGEL_FÜHRERSCHEIN, 0);
                player.vnxSetElementData(EntityData.PLAYER_WAFFEN_FÜHRERSCHEIN, 0);
                player.vnxSetElementData(EntityData.PLAYER_ADVENTSKALENEDER, 0);

                player.vnxSetElementData(VenoXV.Globals.EntityData.PLAYER_STATUS, 0);
                player.vnxSetElementData(EntityData.PLAYER_SPAWNPOINT, "noobspawn");
                player.vnxSetElementData(EntityData.PLAYER_QUESTS, 0);
                player.vnxSetElementData(EntityData.PLAYER_FACTION, 0);
                player.vnxSetStreamSharedElementData(EntityData.PLAYER_WANTEDS, 0);
                player.vnxSetElementData(EntityData.PLAYER_KNASTZEIT, 0);
                player.vnxSetElementData(EntityData.PLAYER_KAUTION, 0);
                player.vnxSetStreamSharedElementData("settings_atm", "ja");
                player.vnxSetStreamSharedElementData("settings_haus", "ja");
                player.vnxSetStreamSharedElementData("settings_tacho", "ja");
                player.vnxSetStreamSharedElementData("settings_quest", "ja");
                player.vnxSetStreamSharedElementData("settings_reporter", "ja");
                player.vnxSetStreamSharedElementData("settings_globalchat", "ja");
                player.vnxSetStreamSharedElementData(VenoXV.Globals.EntityData.PLAYER_STATUS, "VenoX");
                player.vnxSetStreamSharedElementData("SocialState_NAMETAG", "VenoX");
                player.vnxSetStreamSharedElementData("HideHUD", 1);
                player.vnxSetStreamSharedElementData(EntityData.PLAYER_HUNGER, 60);
                player.vnxSetElementData(Verleih.HAVE_PLAYER_RENTED_VEHICLE, 0);

            }
            catch { }
        }

        public static void LoadCharacterData(IPlayer player, PlayerModel character)
        {
            try
            {
                player.vnxSetElementData(EntityData.PLAYER_SPAWN_POS, character.position);
                player.vnxSetElementData(EntityData.PLAYER_SPAWN_ROT, character.rotation);
                player.vnxSetElementData(EntityData.PLAYER_PHONE, character.phone);
                player.vnxSetElementData(EntityData.PLAYER_KILLED, character.killed);
                player.vnxSetElementData(EntityData.PLAYER_JOB, character.job);
                player.vnxSetElementData(EntityData.PLAYER_LIEFERJOB_LEVEL, character.LIEFERJOB_LEVEL);
                player.vnxSetElementData(EntityData.PLAYER_AIRPORTJOB_LEVEL, character.AIRPORTJOB_LEVEL);
                player.vnxSetElementData(EntityData.PLAYER_BUSJOB_LEVEL, character.BUSJOB_LEVEL);

                player.vnxSetElementData(EntityData.PLAYER_ON_DUTY, 0);
                player.vnxSetElementData(EntityData.PLAYER_RENT_HOUSE, character.houseRent);
                player.vnxSetElementData(EntityData.PLAYER_HOUSE_ENTERED, character.houseEntered);
                player.vnxSetElementData(EntityData.PLAYER_BUSINESS_ENTERED, character.businessEntered);
                player.vnxSetElementData(EntityData.PLAYER_SPAWNPOINT, character.spawn);
                player.vnxSetElementData(EntityData.PLAYER_ZIVIZEIT, character.zivizeit);
                player.vnxSetElementData(EntityData.PLAYER_QUESTS, character.quests);
                player.vnxSetStreamSharedElementData(EntityData.PLAYER_WANTEDS, character.wanteds);
                player.vnxSetElementData(EntityData.PLAYER_KNASTZEIT, character.knastzeit);
                player.vnxSetElementData(EntityData.PLAYER_KAUTION, character.kaution);
                player.vnxSetElementData(EntityData.PLAYER_ADVENTSKALENEDER, character.adventskalender);


                player.vnxSetElementData(EntityData.PLAYER_PERSONALAUSWEIS, character.Personalausweis);
                player.vnxSetElementData(EntityData.PLAYER_FÜHRERSCHEIN, character.Autofuehrerschein);
                player.vnxSetElementData(EntityData.PLAYER_MOTORRAD_FÜHRERSCHEIN, character.Motorradfuehrerschein);
                player.vnxSetElementData(EntityData.PLAYER_LKW_FÜHRERSCHEIN, character.LKWfuehrerschein);
                player.vnxSetElementData(EntityData.PLAYER_HELIKOPTER_FÜHRERSCHEIN, character.Helikopterfuehrerschein);
                player.vnxSetElementData(EntityData.PLAYER_FLUGSCHEIN_A_FÜHRERSCHEIN, character.FlugscheinKlasseA);
                player.vnxSetElementData(EntityData.PLAYER_FLUGSCHEIN_B_FÜHRERSCHEIN, character.FlugscheinKlasseB);
                player.vnxSetElementData(EntityData.PLAYER_MOTORBOOT_FÜHRERSCHEIN, character.Motorbootschein);
                player.vnxSetElementData(EntityData.PLAYER_ANGEL_FÜHRERSCHEIN, character.Angelschein);
                player.vnxSetElementData(EntityData.PLAYER_WAFFEN_FÜHRERSCHEIN, character.Waffenschein);
                player.vnxSetElementData(EntityData.PLAYER_HANDCUFFED, false);

                player.vnxSetStreamSharedElementData("settings_atm", character.atm);
                player.vnxSetStreamSharedElementData("settings_haus", character.haus);
                player.vnxSetStreamSharedElementData("settings_tacho", character.tacho);
                player.vnxSetStreamSharedElementData("settings_quest", character.quest_anzeigen);
                player.vnxSetStreamSharedElementData("settings_reporter", character.reporter);
                player.vnxSetStreamSharedElementData("settings_globalchat", character.globalchat);
                player.vnxSetStreamSharedElementData("SocialState_NAMETAG", character.SocialState);
                player.vnxSetStreamSharedElementData(EntityData.PLAYER_ADMIN_ON_DUTY, 0);

                player.vnxSetStreamSharedElementData(EntityData.PLAYER_FACTION, character.faction);
                player.vnxSetStreamSharedElementData(EntityData.PLAYER_ADMIN_RANK, character.adminRank);
                player.vnxSetStreamSharedElementData("HideHUD", 1);
                player.vnxSetElementData(Verleih.HAVE_PLAYER_RENTED_VEHICLE, 0);

                player.vnxSetElementData(Tactics.Globals.EntityData.PLAYER_TACTIC_KILLS, character.tactic_kills);
                player.vnxSetElementData(Tactics.Globals.EntityData.PLAYER_TACTIC_TODE, character.tactic_tode);
                player.vnxSetElementData(EntityData.PLAYER_REALLIFE_HUD, character.REALLIFE_HUD);


                player.vnxSetElementData(Zombie.Globals.EntityData.PLAYER_ZOMBIE_KILLS, character.zombie_kills);
                player.vnxSetElementData(Zombie.Globals.EntityData.PLAYER_ZOMBIE_PLAYERS_KILLED, character.zombie_player_kills);
                player.vnxSetElementData(Zombie.Globals.EntityData.PLAYER_ZOMBIE_TODE, character.zombie_tode);
            }
            catch { }
        }


        public static string GetCurrentChangelogs()
        {
            return "" +
           "10.12.2019 <br>---------------------------------<br>"
           + " - Version 1.1.1 ist nun Online.<br>"
           + " - EVENT MODE wurde entfernt.<br>"
           + " - 225.000$ wurde entfernt.<br>"
           + " - More Infos Cooming Soon...<br>"
           ;
        }

        [ClientEvent("Register:First")]
        public static void OnFirstStepRegister(IPlayer player, string username, string email, string password, string password_retype, int GenderSelected)
        {
            //int Sex = int.Parse(GenderSelected);
            Core.Debug.OutputDebugString("Register : " + username + " | " + email + " | " + password + " | " + password_retype + " | " + GenderSelected);
            Core.Debug.OutputDebugString("Register called");
            player.Emit("DestroyLoginWindow");
            player.Emit("CharCreator:Start");
        }
    }
}
