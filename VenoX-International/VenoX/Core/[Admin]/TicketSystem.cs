using System;
using AltV.Net;
using VenoX.Core._Gamemodes_.Reallife.model;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Database;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Admin_
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
                    _RootCore_.VenoX.TriggerClientEvent(player, "showTicketError");
                    return;
                }

                if (text.Length == 0)
                {
                    _RootCore_.VenoX.TriggerClientEvent(player, "showTicketError");
                    return;
                }

                AdminTickets ticket = new AdminTickets {PlayerName = player.CharacterUsername, Betreff = betreff, Frage = text};
                ticket.Id = Database.AddNewAdminTicket(ticket);
                _RootCore_.VenoX.TriggerClientEvent(player, "Destroy_Ticket_Window");
                Admin.SendAdminInformation(player.CharacterUsername + " hat ein neues Ticket erstellt. [" + ticket.Id + "]");
                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 0) + "Ticket Erstellt! Bitte gedulde dich einen Augenblick bis unser Team dir zurück schreibt.");
                player.SendTranslatedChatMessage(RageApi.GetHexColorcode(0, 200, 0) + "Im Controlpanel ( www.cp-venox.com ) findest du dein Ticket & alle weiteren Informationen.");
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
    }
}
