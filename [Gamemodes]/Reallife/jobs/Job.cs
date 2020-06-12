using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System.Collections.Generic;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.jobs
{
    public class Job : IScript
    {
        //Cols 
        public static ColShapeModel CITY_TRANSPORT_Col = RageAPI.CreateColShapeSphere(new Position(864.2459f, -2312.139f, 30), 2);
        public static ColShapeModel AIRPORT_JOB_Col = RageAPI.CreateColShapeSphere(new Position(-1047.312f, -2744.564f, 21.3594f), 2);
        public static ColShapeModel BUS_JOB_Col = RageAPI.CreateColShapeSphere(new Position(438.2896f, -626.1547f, 28.70835f), 2);
        public static ColShapeModel LSPDDuty = RageAPI.CreateColShapeSphere(new Position(459.297f, -990.9312f, 30.6896f), 1.5f);
        public static ColShapeModel FBIDuty = RageAPI.CreateColShapeSphere(new Position(121.7512f, -753.7672f, 45.75201f), 1.5f);

        [Command("setclothes")]
        public static void GiveIPlayerTestClothes(Client player, int clothesslot, int clothesdrawable, int clothestexture)
        {
            player.SetClothes(clothesslot, clothesdrawable, clothestexture);
            player.SendTranslatedChatMessage("ClothesSlot " + clothesslot + " | ClothesDrawable " + clothesdrawable + " | ClothesTexture " + clothestexture);
        }
        [Command("setprop")]
        public static void GiveIPlayerTestProp(Client player, int clothesslot, int clothesdrawable, int clothestexture)
        {
            player.SetProp(clothesslot, clothesdrawable, clothestexture);
            player.SendTranslatedChatMessage("ClothesSlot " + clothesslot + " | ClothesDrawable " + clothesdrawable + " | ClothesTexture " + clothestexture);
        }

        [Command("setcopclothes")]
        public static void GiveTargetCopClothes(Client player, string target_name)
        {
            Client target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            target.SetClothes(6, 24, 0);
            target.SetClothes(4, 33, 0);
            target.SetClothes(9, 7, 1);
            target.SetClothes(11, 50, 0);
            target.SetProp(0, 144, 0);
            target.SetClothes(3, 4, 0);
            target.SetClothes(8, 15, 0);
        }

        [Command("setbadclothes")]
        public static void GiveTargetBadClothes(Client player, string target_name)
        {
            Client target = RageAPI.GetPlayerFromName(target_name);
            if (target == null) { return; }
            target.SetClothes(4, 19, 0);
            target.SetClothes(1, 95, 0);
            target.SetClothes(3, 0, 0);
            target.SetClothes(8, 15, 0);
            target.SetClothes(7, 0, 0);
            target.SetClothes(6, 25, 0);
            target.SetClothes(11, 18, 0);
        }

        [Command("givepweapon")]
        public static void GivePlayerWeapons(Client player, string weaponname)
        {
            player.GivePlayerWeapon((AltV.Net.Enums.WeaponModel)Alt.Hash(weaponname), 500);
        }

        public static void OnPlayerEnterColShapeModel(IColShape shape, Client player)
        {
            try
            {
                if (shape == CITY_TRANSPORT_Col.Entity)
                {
                    string job = player.vnxGetElementData<string>(EntityData.PLAYER_JOB);
                    if (job == Constants.JOB_CITY_TRANSPORT)
                    {
                        dxLibary.VnX.DrawJobWindow(player, "Venox City Transport", "Wähle dein Fahrzeug aus", "Van<br>[Ab LvL 0]", "Transporter<br>[Ab LvL 50]", "LkW<br>[Ab LvL 100]", "Verfügbar ab LvL 0<br>", "Verfügbar ab LvL 50<br>", "Verfügbar ab LvL 150<br>", "Dein Job-level beträgt : " + player.vnxGetElementData<int>(EntityData.PLAYER_LIEFERJOB_LEVEL));
                    }
                    else if (job == "Arbeitslos")
                    {
                        dxLibary.VnX.DrawWindow(player, "Venox City Transport", "Hallo " + player.Username + ",<br>willkommen bei Venox City Transport!<br>Du liebst es zu Fahren ?<br>Du liebst es mit anderen Menschen in Kontakt zu kommen ?<br>Dann bist du hier genau Richtig!<br>Möchtest du deine Karriere als Transporter Starten ?", "Job Annehmen", "Job Ablehnen");
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Du hast bereits einen Job! Nutze /quitjob um deinen Job zu beenden!");
                    }
                }
                else if (shape == LSPDDuty.Entity)
                {
                    if (player.Reallife.Faction == Constants.FACTION_POLICE)
                    {

                        Alt.Server.TriggerClientEvent(player,"showDutyWindow", "Wilkommen in der Umkleide des " + Constants.FACTION_POLICE_NAME + ".<br>Hier kannst du im Dienst gehen oder für Schwieriege<br>Einsätze in den S.W.A.T Modus.", player.Username);
                    }
                }
                else if (shape == FBIDuty.Entity)
                {
                    if (player.Reallife.Faction == Constants.FACTION_FBI)
                    {
                        Alt.Server.TriggerClientEvent(player,"showDutyWindow", "Wilkommen in der Umkleide des " + Constants.FACTION_FBI_NAME + ".<br>Hier kannst du im Dienst gehen oder für Schwieriege<br>Einsätze in den S.W.A.T Modus.", player.Username);
                    }
                }
                else if (shape == AIRPORT_JOB_Col.Entity)
                {
                    if (player.vnxGetElementData<string>(EntityData.PLAYER_JOB) == Constants.JOB_AIRPORT)
                    {
                        dxLibary.VnX.DrawJobWindow(player, "Los Santos Airport", "Wähle dein Flugzeug aus", "Dodo<br>[Ab LvL 0]", "Shamal<br>[Ab LvL 50]", "JET<br>[Ab LvL 150]", "Verfügbar ab LvL 0<br>", "Verfügbar ab LvL 50<br>", "Verfügbar ab LvL 150<br>", "Dein Job-level beträgt : " + player.vnxGetElementData<int>(EntityData.PLAYER_AIRPORTJOB_LEVEL));
                    }
                    else if (player.vnxGetElementData<string>(EntityData.PLAYER_JOB) == Constants.JOB_NONE)
                    {
                        dxLibary.VnX.DrawWindow(player, "LS Airport", "Hallo " + player.Username + ",<br>willkommen bei Venox City Airport!<br>Du liebst es zu Fliegen?<br>Du liebst es mit anderen Menschen in Kontakt zu kommen ?<br>Dann bist du hier genau Richtig!<br>Möchtest du deine Karriere als Pilot Starten ?", "Job Annehmen", "Job Ablehnen");
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Du hast bereits einen Job! Nutze /quitjob um deinen Job zu beenden!");
                    }
                }
                else if (shape == BUS_JOB_Col.Entity)
                {
                    if (player.vnxGetElementData<string>(EntityData.PLAYER_JOB) == Constants.JOB_BUS)
                    {
                        dxLibary.VnX.DrawJobWindow(player, "VenoX Busdepot", "Wähle dein Bus aus", "Bus<br>[Ab LvL 0]", "Airbus<br>[Ab LvL 50]", "Coach<br>[Ab LvL 150]", "Verfügbar ab LvL 0<br>", "Verfügbar ab LvL 50<br>", "Verfügbar ab LvL 150<br>", "Dein Job-level beträgt : " + player.vnxGetElementData<int>(EntityData.PLAYER_BUSJOB_LEVEL));
                    }
                    else if (player.vnxGetElementData<string>(EntityData.PLAYER_JOB) == Constants.JOB_NONE)
                    {
                        dxLibary.VnX.DrawWindow(player, "VenoX Busdepot", "Hallo " + player.Username + ",<br>willkommen beim VenoX City Busdepot!<br>Du liebst es mit einem 500.000$ Benz zu fahren?<br>Du liebst es jedentag heiße Frauen in deinem Fahrzeug zu haben?<br>Dann werde heute noch Busfahrer!", "Job Annehmen", "Job Ablehnen");
                    }
                    else
                    {
                        _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Du hast bereits einen Job! Nutze /quitjob um deinen Job zu beenden!");
                    }
                }
            }
            catch { }
        }



        [Command("quitjob")]
        public static void QuitJob_Server(Client player)
        {
            try
            {
                if (player.vnxGetElementData<string>(EntityData.PLAYER_JOB) != Constants.JOB_NONE)
                {
                    player.vnxSetElementData(EntityData.PLAYER_JOB, Constants.JOB_NONE);
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Info, "Du bist nun Arbeitslos.");
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("accept_job_server")]
        public void Accept_job(Client player, string windowname)
        {
            if (windowname == "Venox City Transport")
            {
                player.vnxSetElementData(EntityData.PLAYER_JOB, Constants.JOB_CITY_TRANSPORT);
                dxLibary.VnX.DestroyWindow(player, "DestroyVnXSAWindowLib");
                dxLibary.VnX.DrawJobWindow(player, "Venox City Transport", "Wähle dein Fahrzeug aus", "Van<br>[Ab LvL 0]", "Transporter<br>[Ab LvL 50]", "LkW<br>[Ab LvL 100]", "Verfügbar ab LvL 0<br>", "Verfügbar ab LvL 50<br>", "Verfügbar ab LvL 100<br>", "Dein Job-level beträgt : " + player.vnxGetElementData<int>(EntityData.PLAYER_LIEFERJOB_LEVEL));
            }
            else if (windowname == "LS Airport")
            {
                player.vnxSetElementData(EntityData.PLAYER_JOB, Constants.JOB_AIRPORT);
                dxLibary.VnX.DrawJobWindow(player, "Los Santos Airport", "Wähle dein Flugzeug aus", "Dodo<br>[Ab LvL 0]", "Shamal<br>[Ab LvL 50]", "JET<br>[Ab LvL 150]", "Verfügbar ab LvL 0<br>", "Verfügbar ab LvL 50<br>", "Verfügbar ab LvL 150<br>", "Dein Job-level beträgt : " + player.vnxGetElementData<int>(EntityData.PLAYER_AIRPORTJOB_LEVEL));
            }
            else if (windowname == "VenoX Busdepot")
            {
                player.vnxSetElementData(EntityData.PLAYER_JOB, Constants.JOB_BUS);
                dxLibary.VnX.DrawJobWindow(player, "VenoX Busdepot", "Wähle dein Bus aus", "Bus<br>[Ab LvL 0]", "Airbus<br>[Ab LvL 50]", "Coach<br>[Ab LvL 150]", "Verfügbar ab LvL 0<br>", "Verfügbar ab LvL 50<br>", "Verfügbar ab LvL 150<br>", "Dein Job-level beträgt : " + player.vnxGetElementData<int>(EntityData.PLAYER_BUSJOB_LEVEL));
            }
        }
        //[AltV.Net.ClientEvent("job_window_1_button")]
        public void trigger_job_window_1_buttons(Client player, string button)
        {
            try
            {
                if (player.vnxGetElementData<string>(EntityData.PLAYER_JOB) == Constants.JOB_CITY_TRANSPORT)
                {
                    if (button == "button1")
                    {
                        dxLibary.VnX.DestroyWindow(player, "Job1");
                        Lieferrant.Lieferrant.lieferjob_first_start(player);
                    }
                    else if (button == "button2")
                    {
                        if (player.vnxGetElementData<int>(EntityData.PLAYER_LIEFERJOB_LEVEL) >= 50)
                        {
                            dxLibary.VnX.DestroyWindow(player, "Job1");
                            Lieferrant.Lieferrant.lieferjob_Second_start(player);
                        }
                        else
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du brauchst mindestens Job Level 50!");
                        }
                    }
                    else if (button == "button3")
                    {
                        if (player.vnxGetElementData<int>(EntityData.PLAYER_LIEFERJOB_LEVEL) >= 100)
                        {
                            dxLibary.VnX.DestroyWindow(player, "Job1");
                            Lieferrant.Lieferrant.lieferjob_THIRD_start(player);
                        }
                        else
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du brauchst mindestens Job Level 100!");
                        }
                    }
                }
                else if (player.vnxGetElementData<string>(EntityData.PLAYER_JOB) == Constants.JOB_AIRPORT)
                {
                    if (button == "button1")
                    {
                        if (player.vnxGetElementData<int>(EntityData.PLAYER_FLUGSCHEIN_A_FÜHRERSCHEIN) == 1)
                        {
                            dxLibary.VnX.DestroyWindow(player, "Job1");
                            Airport.Airport.Airport_job_start(player, 1);
                            player.vnxSetElementData("JOB_STAGE_LVL_AIRPORT", 1);
                        }
                        else
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du brauchst einen Flugschein A!");
                        }
                    }
                    if (button == "button2")
                    {
                        if (player.vnxGetElementData<int>(EntityData.PLAYER_AIRPORTJOB_LEVEL) >= 50)
                        {

                            if (player.vnxGetElementData<int>(EntityData.PLAYER_FLUGSCHEIN_B_FÜHRERSCHEIN) == 1)
                            {
                                dxLibary.VnX.DestroyWindow(player, "Job1");
                                Airport.Airport.Airport_job_start(player, 2);
                                player.vnxSetElementData("JOB_STAGE_LVL_AIRPORT", 2);
                            }
                            else
                            {
                                _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du brauchst einen Flugschein B!");
                            }
                        }
                        else
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du brauchst mindestens Job Level 50!");
                        }
                    }
                    if (button == "button3")
                    {
                        if (player.vnxGetElementData<int>(EntityData.PLAYER_AIRPORTJOB_LEVEL) >= 150)
                        {
                            if (player.vnxGetElementData<int>(EntityData.PLAYER_FLUGSCHEIN_B_FÜHRERSCHEIN) == 1)
                            {
                                dxLibary.VnX.DestroyWindow(player, "Job1");
                                Airport.Airport.Airport_job_start(player, 3);
                                player.vnxSetElementData("JOB_STAGE_LVL_AIRPORT", 3);
                            }
                            else
                            {
                                _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du brauchst einen Flugschein B!");
                            }
                        }
                        else
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du brauchst mindestens Job Level 150!");
                        }
                    }
                }
                else if (player.vnxGetElementData<string>(EntityData.PLAYER_JOB) == Constants.JOB_BUS)
                {
                    if (button == "button1")
                    {
                        if (player.vnxGetElementData<int>(EntityData.PLAYER_LKW_FÜHRERSCHEIN) == 1)
                        {
                            dxLibary.VnX.DestroyWindow(player, "Job1");
                            Reallife.jobs.Bus.Busjob.StartBusJob(player, 1);
                        }
                        else
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du brauchst einen LKW - Führerschein!");
                        }
                    }
                    if (button == "button2")
                    {
                        if (player.vnxGetElementData<int>(EntityData.PLAYER_LKW_FÜHRERSCHEIN) == 1)
                        {
                            dxLibary.VnX.DestroyWindow(player, "Job1");
                            Reallife.jobs.Bus.Busjob.StartBusJob(player, 2);
                        }
                        else
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du brauchst einen LKW - Führerschein!");
                        }
                    }
                    if (button == "button3")
                    {
                        if (player.vnxGetElementData<int>(EntityData.PLAYER_LKW_FÜHRERSCHEIN) == 1)
                        {
                            dxLibary.VnX.DestroyWindow(player, "Job1");
                            Reallife.jobs.Bus.Busjob.StartBusJob(player, 3);
                        }
                        else
                        {
                            _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Du brauchst einen LKW - Führerschein!");
                        }
                    }
                }

                else
                {
                    _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "du bist bei keinem Job");
                }
            }
            catch { }
        }


        static List<JobPickModel> jobList = new List<JobPickModel>()
        {

            /*
            new JobPickModel(Constants.JOB_CITY_TRANSPORT, new Position(-1037.697f, -1397.189f, 5.553192f), "dedasd"),
            new JobPickModel(Constants.JOB_AIRPORT, new Position(-1047.312f, -2744.564f, 21.3594f), "ded"),*/
        };



        public static void OnResourceStart()
        {
            try
            {


                foreach (JobPickModel job in jobList)
                {
                    RageAPI.CreateTextLabel("Job", job.position, 10.0f, 0.5f, 4, new int[] { 0, 150, 200, 255 }, 0);
                    RageAPI.CreateTextLabel("Bist du interessiert hier zu Arbeiten?", new Position(job.position.X, job.position.Y, job.position.Z - 0.1f), 10.0f, 0.5f, 4, new int[] { 0, 150, 200, 255 }, 0);
                }
                Reallife.jobs.Bus.Busjob.OnResourceStart(); // Bus - Sign Loading.
            }
            catch { }

        }


        /*
        [Command(Messages.COM_DUTY)]
        public void DutyCommand(PlayerModel player)
        {
            // We get the sex, job and faction from the player
            int playerSex = player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SEX);
            int playerFaction = player.Reallife.Faction;

            if (player.vnxGetElementData<int>(EntityData.PLAYER_KILLED) != 0  
            {
                _Notifications_.Main.DrawNotification(player, _Notifications_.Main.Types.Error, "Diese Aktion ist derzeit nicht Möglich!");
            }
            else if (player.vnxGetElementData<int>(EntityData.PLAYER_ON_DUTY) == 1)
            {
                    // Load selected character
                    PlayerModel character = Database.LoadCharacterInformationById(player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID));
                    SkinModel skinModel = Database.GetCharacterSkin(player.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_SQL_ID));

                    //ToDo : Fix & find another Way! player.Username = character.realName;
                    player.vnxSetElementData(EntityData.PLAYER_SKIN_MODEL, skinModel);
                                                player.SetPlayerSkin(character.sex == 0) ? Alt.Hash("FreemodeMale01") : Alt.Hash("FreemodeFemale01");
                    Customization.ApplyPlayerCustomization(player, skinModel, character.sex);
                    Customization.ApplyPlayerClothes(player);
                    Customization.ApplyPlayerTattoos(player);
                    // We set the player on duty
                    player.vnxSetElementData(EntityData.PLAYER_ON_DUTY, 0);
                    Weapons.GivePlayerWeaponItems(player);
            }
            else
            {
                // Dress the player with the uniform
                foreach (UniformModel uniform in Constants.UNIFORM_LIST)
                {
                    if (uniform.type == 0) && uniform.factionJob == playerFaction && playerSex == uniform.characterSex)
                    {
                        //ToDo Sie Clientseitig Laden! : player.SetClothes(uniform.uniformSlot, uniform.uniformDrawable, uniform.uniformTexture);
                    }
                    else if (uniform.type == 1 && playerSex == uniform.characterSex)
                    {
                        //ToDo Sie Clientseitig Laden! : player.SetClothes(uniform.uniformSlot, uniform.uniformDrawable, uniform.uniformTexture);
                    }
                }

                // We set the player on duty
                player.vnxSetElementData(EntityData.PLAYER_ON_DUTY, 1);


                Weapons.GivePlayerWeaponItems(player);
                // Notification sent to the player
                player.SendTranslatedChatMessage(Messages.INF_PLAYER_ON_DUTY);
            }
        }*/
    }
}
