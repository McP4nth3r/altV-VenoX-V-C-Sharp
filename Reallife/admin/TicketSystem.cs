using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV.Reallife.database;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.model;

namespace VenoXV.Reallife.admin
{
    public class TicketSystem : IScript
    {
        //[AltV.Net.ClientEvent("requestNewTicket")]
        public void CreateNewTicket(IPlayer player, string betreff, string text)
        {
            try {
                if (betreff.Length == 0)
                {
                    player.Emit("showTicketError");
                    return;
                }
                else if (text.Length == 0)
                {
                    player.Emit("showTicketError");
                    return;
                }

                AdminTickets ticket = new AdminTickets();
                ticket.playerName =player.Name;
                ticket.Betreff = betreff;
                ticket.Frage = text;
                ticket.id = Database.AddNewAdminTicket(ticket);
                player.Emit("Destroy_Ticket_Window");
                Admin.sendAdminInformation(player.Name + " hat ein neues Ticket erstellt. [" + ticket.id + "]");
                player.SendChatMessage("!{0,200,0}Ticket Erstellt! Bitte gedulde dich einen Augenblick bis unser Team dir zurück schreibt.");
                player.SendChatMessage("!{0,200,0}Im Controlpanel ( www.cp-venox.com ) findest du dein Ticket & alle weiteren Informationen.");
            }
            catch { }
        }
    }
}
