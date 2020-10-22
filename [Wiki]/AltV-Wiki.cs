using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VenoXV.Wiki
{
    /* We create our IScript class */
    public class AltV_Wiki : IScript
    {

        // We declare and create our event handler
        [ScriptEvent(ScriptEventType.PlayerLeaveVehicle)]
        public static void OnPlayerLeaveVehicle(IVehicle vehicle, IPlayer player, byte seat)
        {
            // Simple output.
            player?.SendChatMessage("Damn " + player.Name + "... you've left your awesome " + (VehicleModel)vehicle?.Model);
        }

        public class Program
        {
            private static int SETTINGS_OUTPUT = 0; // just to change the output method.
            private static List<int> IntegerList = new List<int>(); // Creating a Integer List.
            static void main(string[] args)
            {
                Console.WriteLine("Gib bitte eine Zahl ein...");
                IntegerList[0] = int.Parse(Console.ReadLine());
                Console.WriteLine("Gib bitte nochmal eine Zahl ein...");
                IntegerList[1] = int.Parse(Console.ReadLine());
                Console.WriteLine("Und jetzt bitte nochmal eine Zahl eingeben...");
                IntegerList[2] = int.Parse(Console.ReadLine());

                // Checking the Settings-Output Number.
                switch (SETTINGS_OUTPUT)
                {
                    case 0:
                        Console.WriteLine("Die größte Zahl die eingegeben wurde ist : " + IntegerList.Max());
                        return;
                    case 1:
                        int _HighestInt = 0;
                        foreach (int numb in IntegerList)
                            if (numb < _HighestInt) _HighestInt = numb;
                        Console.WriteLine("Die größte Zahl die eingegeben wurde ist : " + _HighestInt);
                        return;
                    case 2:
                        Console.WriteLine("Die größte Zahl die eingegeben wurde ist : das sie behindert sind, und SETTINGS_OUTPUT 0 das beste ist sie lulatsch.");
                        return;
                }

            }
        }
    }
}
