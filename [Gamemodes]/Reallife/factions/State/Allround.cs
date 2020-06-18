using AltV.Net;
using AltV.Net.Elements.Entities;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.factions.State
{
    public class Allround
    {
        public static ColShapeModel LSPDDuty = RageAPI.CreateColShapeSphere(new Vector3(459.297f, -990.9312f, 30.6896f), 1.5f);
        public static ColShapeModel FBIDuty = RageAPI.CreateColShapeSphere(new Vector3(121.7512f, -753.7672f, 45.75201f), 1.5f);
        public static ColShapeModel ARMYDuty = RageAPI.CreateColShapeSphere(new Vector3(467.07693f, -3220.4834f, 7.0549316f), 1.5f);
        public static ColShapeModel ARMY2Duty = RageAPI.CreateColShapeSphere(new Vector3(-2172.7913f, 3255.9692f, 32.801514f), 1.5f);

        public static void OnStateColShapeHit(IColShape colShape, Client player)
        {
            if (!Factions.Allround.isStateFaction(player)) { return; }
            if (colShape == LSPDDuty.Entity) { Alt.Server.TriggerClientEvent(player, "showDutyWindow", "Wilkommen in der Umkleide des " + Constants.FACTION_POLICE_NAME + ".<br>Hier kannst du im Dienst gehen oder für Schwieriege<br>Einsätze in den S.W.A.T Modus.", player.Username); return; }
            if (colShape == FBIDuty.Entity) { Alt.Server.TriggerClientEvent(player, "showDutyWindow", "Wilkommen in der Umkleide des " + Constants.FACTION_FBI_NAME + ".<br>Hier kannst du im Dienst gehen oder für Schwieriege<br>Einsätze in den S.W.A.T Modus.", player.Username); return; }
            if (colShape == ARMYDuty.Entity || colShape == ARMY2Duty.Entity) { Alt.Server.TriggerClientEvent(player, "showDutyWindow", "Wilkommen in der Umkleide des " + Constants.FACTION_USARMY_NAME + ".<br>Hier kannst du im Dienst gehen oder für Schwieriege<br>Einsätze in den S.W.A.T Modus.", player.Username); return; }
        }
    }
}
