﻿using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using VenoXV._RootCore_.Database;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.admin
{
    public class TicketSystem : IScript
    {
        //[AltV.Net.ClientEvent("requestNewTicket")]
        public void CreateNewTicket(Client player, string betreff, string text)
        {
            try
            {
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
                ticket.playerName = player.Username;
                ticket.Betreff = betreff;
                ticket.Frage = text;
                ticket.id = Database.AddNewAdminTicket(ticket);
                player.Emit("Destroy_Ticket_Window");
                Admin.sendAdminInformation(player.Username + " hat ein neues Ticket erstellt. [" + ticket.id + "]");
                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 0) + "Ticket Erstellt! Bitte gedulde dich einen Augenblick bis unser Team dir zurück schreibt.");
                player.SendTranslatedChatMessage(RageAPI.GetHexColorcode(0, 200, 0) + "Im Controlpanel ( www.cp-venox.com ) findest du dein Ticket & alle weiteren Informationen.");
            }
            catch { }
        }
    }
}
