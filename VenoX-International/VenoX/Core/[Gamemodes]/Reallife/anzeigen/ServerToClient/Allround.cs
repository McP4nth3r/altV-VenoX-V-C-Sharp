﻿using AltV.Net;
using VenoX.Core._Gamemodes_.Reallife.fun.Aktionen.Kokain;
using VenoX.Core._Gamemodes_.Reallife.vehicles;
using VenoX.Core._RootCore_.Models;
using VenoX.Core._RootCore_.vnx_stored_files;

namespace VenoX.Core._Gamemodes_.Reallife.anzeigen.ServerToClient
{
    public class VnXDrawAllround : IScript
    {

        //[AltV.Net.ClientEvent("clicked_button_server")]
        public void Clicked_button_server(VnXPlayer player, string headertext, string button)
        {
            if (headertext == "VenoX Rentals")
            {
                switch (button)
                {
                    case "button_1":
                        VnX.DestroyWindow(player, "WindowSelection");
                        Verleih.GivePlayerRentedIVehicle(player, 0);
                        break;
                    case "button_2":
                        VnX.DestroyWindow(player, "WindowSelection");
                        Verleih.GivePlayerRentedIVehicle(player, 1);
                        break;
                    default:
                        Logfile.WriteLogs("libLogs", "[ERROR] : Button konnte nicht gefunden werden! @Window_Selection_Class Button_Information:" + button);
                        break;
                }
            }
        }

        //[AltV.Net.ClientEvent("submit_button_input_server")]
        public void Input_submit_button(VnXPlayer player, string headertext, int value)
        {
            if (headertext == "Kokain Dealer")
            {
                KokainSell.SellKokain(player, value);
            }
            else
            {
                Logfile.WriteLogs("libLogs", "[ERROR] : Headertext konnte nicht gefunden werden! @Input_submit_button Input_Header_Information:" + headertext);
            }
        }
    }
}
