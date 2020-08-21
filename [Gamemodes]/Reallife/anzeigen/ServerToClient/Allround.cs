using AltV.Net;
using VenoXV._Gamemodes_.Reallife.Vehicles;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Reallife.dxLibary
{
    public class VnXDraw_Allround : IScript
    {

        //[AltV.Net.ClientEvent("clicked_button_server")]
        public void Clicked_button_server(VnXPlayer player, string headertext, string button)
        {
            if (headertext == "VenoX Rentals")
            {
                if (button == "button_1")
                {
                    dxLibary.VnX.DestroyWindow(player, "WindowSelection");
                    Verleih.GivePlayerRentedIVehicle(player, 0);
                }
                else if (button == "button_2")
                {
                    dxLibary.VnX.DestroyWindow(player, "WindowSelection");
                    Verleih.GivePlayerRentedIVehicle(player, 1);
                }
                else
                {
                    logfile.WriteLogs("libLogs", "[ERROR] : Button konnte nicht gefunden werden! @Window_Selection_Class Button_Information:" + button);
                }
            }
        }

        //[AltV.Net.ClientEvent("submit_button_input_server")]
        public void Input_submit_button(VnXPlayer player, string headertext, int value)
        {
            if (headertext == "Kokain Dealer")
            {
                Fun.Aktionen.Kokain.KokainSell.SellKokain(player, value);
            }
            else
            {
                logfile.WriteLogs("libLogs", "[ERROR] : Headertext konnte nicht gefunden werden! @Input_submit_button Input_Header_Information:" + headertext);
            }
        }
    }
}
