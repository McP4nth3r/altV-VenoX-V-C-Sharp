using System;
using AltV.Net;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Models;

namespace VenoXV
{
    public class TicketSystem : IScript
    {
        //[AltV.Net.ClientEvent("requestNewTicket")]
        public void CreateNewTicket(VnXPlayer player, string betreff, string text)
        {
            try
            {
                if (betreff.Length == 0)
                {
                    VenoX.TriggerClientEvent(player, "showTicketError");
                    return;
                }

                if (text.Length == 0)
                {
                    VenoX.TriggerClientEvent(player, "showTicketError");
                    return;
                }

                AdminTickets ticket = new AdminTickets {PlayerName = player.Username, Betreff = betreff, Frage = text};
                ticket.Id = Database.Database.AddNewAdminTicket(ticket);
                VenoX.TriggerClientEvent(player, "Destroy_Ticket_Window");
                Admin.SendAdminInformation(player.Username + " hat ein neues Ticket erstellt. [" + ticket.Id + "]");
                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 0) + "Ticket Erstellt! Bitte gedulde dich einen Augenblick bis unser Team dir zurück schreibt.");
                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 0) + "Im Controlpanel ( www.cp-venox.com ) findest du dein Ticket & alle weiteren Informationen.");
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
    }
}
