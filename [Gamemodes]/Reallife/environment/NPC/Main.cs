using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.environment.NPC
{
    public class NPC : IScript
    {

        //Settings 
        public static int NPC_UPDATE_TIME = 1; // Zeit in Minuten wie oft die NPC - Positionen geupdatet werden.
        public static int NPC_MAXIMUM_CREATE = 10; // Wie viele Maximum an NPC´s Spawnen sollen.
        public static string NPC_WINDOW_HEADER_TEXT = "Straßen Ped";


        // Entity´s & Shapes
        public static List<ColShapeModel> NPC_Cols = new List<ColShapeModel>();
        public static List<NPCModel> NPCPeds = new List<NPCModel>();
        public static List<LabelModel> NPCLabels = new List<LabelModel>();

        public static DateTime NPC_NextUpdate_Pos = DateTime.Now.AddMinutes(NPC_UPDATE_TIME + 1);
        public static string NPC_COLSHAPE = "NPC_COLSHAPE";
        public static string NPC_POSITION = "NPC_POSITION";
        public static string NPC_ROTATION = "NPC_ROTATION";
        public static string NPC_RANDOM_ID = "NPC_RANDOM_ID";
        public static string NPC_COLSHAPE_ID = "NPC_COLSHAPE_ID";
        public static string NPC_ENTITY_SKINHASHKEY = "NPC_ENTITY_SKINHASHKEY";
        public static string NPC_ENTITY_LABEL = "NPC_ENTITY_LABEL";
        public static string NPC_ENTITY_KARMA = "NPC_ENTITY_KARMA";
        public static string NPC_ENTITY_KARMA_COP = "NPC_ENTITY_KARMA_COP";
        public static string NPC_ENTITY_KARMA_BAD = "NPC_ENTITY_KARMA_BAD";
        public static string NPC_ENTITY_KARMA_HOMELESS = "NPC_ENTITY_KARMA_HOMELESS";
        public static string NPC_ENTITY_WINDOW_TEXT = "NPC_ENTITY_WINDOW_TEXT";
        public static string NPC_ENTITY_BUTTON1_TEXT = "NPC_ENTITY_BUTTON1_TEXT";
        public static string NPC_ENTITY_BUTTON2_TEXT = "NPC_ENTITY_BUTTON2_TEXT";



        public static Dictionary<Vector3, int> NPC_Spawns = new Dictionary<Vector3, int>
        {
            { new Vector3(170.0734f, -567.5259f, 43.87288f), 43 },
            { new Vector3(-211.44342f, -1033.0864f, 30.13931f), 252 },
            { new Vector3(-203.34644f, -1324.3364f, 31.044863f), 92 },
            { new Vector3(-427.24857f, 1212.383f, 325.75818f), 347 },
            { new Vector3(-96.803986f, 889.85046f, 236.21361f), 288 },
            { new Vector3(221.0148f, 112.096436f, 93.47367f), 248 },
            { new Vector3(141.12791f, -379.3752f, 43.25703f), 68 },
            { new Vector3(-58.545845f, -544.2875f, 31.912367f), 156 },
            { new Vector3(233.98146f, -753.2866f, 30.825989f), 347 },
            { new Vector3(145.84898f, -1058.7992f, 30.186157f), 83 },
            { new Vector3(378.4777f, -997.5386f, 29.450058f), 174 },
            { new Vector3(372.11267f, -790.26263f, 29.285032f), 89 },
            { new Vector3(394.5189f, -711.792f, 29.28488f), 266 },
            { new Vector3(463.41498f, -770.1115f, 27.359283f), 88 },
            { new Vector3(451.26758f, -847.21576f, 27.945845f), 263 },
            { new Vector3(455.2899f, -842.4862f, 27.620499f), 50 },
            { new Vector3(457.03528f, -970.72546f, 30.708979f), 359 },
            { new Vector3(472.6274f, -1058.7017f, 29.211615f), 96 },
            { new Vector3(796.41205f, -1108.7367f, 22.70346f), 177 },
            { new Vector3(826.4756f, -1290.127f, 28.240664f), 88 },
            { new Vector3(880.6781f, -1574.2621f, 30.8921f), 354 },
            { new Vector3(778.3616f, -1622.9883f, 31.017056f), 329 },
            { new Vector3(849.7109f, -1995.4191f, 29.980043f), 32 },
            { new Vector3(773.21136f, -2510.017f, 19.935286f), 268 },
            { new Vector3(604.4097f, -3068.1165f, 6.0692945f), 26 },
            { new Vector3(605.844f, -3087.6526f, 6.0692625f), 4 },
            { new Vector3(623.26654f, -3112.1184f, 1.6941985f), 177 },
            { new Vector3(568.4834f, -3125.868f, 18.768625f), 357 },
            { new Vector3(570.4876f, -3123.813f, 18.768625f), 84 },
            { new Vector3(566.33185f, -3123.3228f, 18.768625f), 263 },
            { new Vector3(575.1966f, -3126.2947f, 18.768623f), 89 },
            { new Vector3(511.90744f, -3118.1846f, 25.572443f), 273 },
            { new Vector3(592.0594f, -3142.3062f, 6.0692616f), 84 },
            { new Vector3(285.80402f, -2491.6497f, 6.4402857f), 198 },
            { new Vector3(89.086235f, -2564.1953f, 6.004588f), 1 },
            { new Vector3(367.82254f, -2122.8562f, 16.233187f), 192 },
            { new Vector3(-812.855f, -1077.6761f, 11.132584f), 144 },
            { new Vector3(2477.898f, -384.13855f, 94.403534f), 273 },
            { new Vector3(2532.9377f, -375.2196f, 93.05888f), 66 },
            { new Vector3(2560.5645f, 390.0132f, 108.62095f), 267 },
            { new Vector3(2561.8816f, 392.30356f, 108.620674f), 239 },
            { new Vector3(1473.4338f, 1113.0477f, 114.33423f), 92 }
        };


        public static void CountAllNPCSpawns()
        {
            Core.Debug.OutputDebugString("Der Server besitzt momentan " + NPC_Cols.Count + " an NPC_Spawns Lel ");
        }

        public static int GetRandomSpawns()
        {
            Random events = new Random();
            int number = events.Next(0, NPC_Spawns.Count);
            return number;
        }

        public static int GetRandomNPC()
        {
            Random events = new Random();
            int number = events.Next(0, NPC_MAXIMUM_CREATE);
            return number;
        }



        public static void CreateNewNPC()
        {
            try
            {
                foreach (var NPCCoords in NPC_Spawns)
                {
                    if (NPC_Cols.Count < NPC_MAXIMUM_CREATE)
                    {
                        int RandomEntry = GetRandomSpawns();
                        Vector3 position = NPC_Spawns.ElementAt(RandomEntry).Key;
                        int rotation = NPC_Spawns.ElementAt(RandomEntry).Value;
                        foreach (ColShapeModel col in NPC_Cols)
                        {
                            if (col.CurrentPosition == position) // Doppelte Erstellung verhindern.
                            {
                                CreateNewNPC();
                                return;
                            }
                        }
                        int GetRandomNPCs = GetRandomNPC();
                        ColShapeModel Col = RageAPI.CreateColShapeSphere(position, 2.25f);
                        Col.vnxSetElementData(NPC_COLSHAPE, true);
                        Col.vnxSetElementData(NPC_COLSHAPE_ID, RandomEntry);
                        Col.vnxSetElementData(NPC_POSITION, position);
                        Col.vnxSetElementData(NPC_ROTATION, rotation);
                        Col.vnxSetElementData(NPC_RANDOM_ID, GetRandomNPCs);
                        NPC_Cols.Add(Col);
                        CreateRandomNPC(Col, rotation);
                        Debug.OutputDebugString("[NPC-System] : Spawned at " + position + " with Rotation : " + rotation + " | " + GetRandomNPCs);
                    }
                }
            }
            catch { }
        }

        [Command("createnewnpc")]
        public static void CreateNewNPCs(VnXPlayer player)
        {
            NPC_NextUpdate_Pos = DateTime.Now;
        }

        [Command("countcolshapes")]
        public static void countcolshapes(VnXPlayer player)
        {
            player.SendChatMessage("" + NPC_Cols.Count);
        }


        public static void DeleteAllNPCs()
        {
            try
            {
                foreach (ColShapeModel col in NPC_Cols)
                {
                    RageAPI.RemoveColShape(col);
                }
                foreach (NPCModel npc in NPCPeds)
                {
                    RageAPI.RemoveNPC(npc);
                }
                foreach (LabelModel npc in NPCLabels)
                {
                    RageAPI.RemoveTextLabel(npc);
                }
                NPC_Cols.Clear();
                NPC_Cols = new List<ColShapeModel>();
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
        public static void CreateRandomNPC(ColShapeModel col, int rotation)
        {
            try
            {
                int Data = col.vnxGetElementData<int>(NPC_RANDOM_ID);
                Vector3 coord = col.vnxGetElementData<Vector3>(NPC_POSITION);
                int Rotation = col.vnxGetElementData<int>(NPC_ROTATION);
                string SkinHashKey = "";
                string SkinKarmaEntity = "";
                string SkinWindowText = "";
                string SkinButton1Text = "";
                string SkinButton2Text = "";
                string SkinTextLabel = "";

                if (Data == 0)
                {
                    SkinHashKey = "s_f_y_cop_01";
                    SkinKarmaEntity = NPC_ENTITY_KARMA_COP;
                    SkinTextLabel = "Eyyy duu!!\nKannst du ein Gang-Mitglied ausseinandernehmen ?!";
                    SkinWindowText = "Hey... da gibts so ein Gang-Mitglied im Norden von Los Santos... Lass ihn verschwinden!";
                    SkinButton1Text = "Job Annehmen<br>[1000$ Belohnung]";
                    SkinButton2Text = "Job Ablehnen";
                }
                else if (Data == 1)
                {
                    SkinHashKey = "a_m_m_tramp_01";
                    SkinKarmaEntity = NPC_ENTITY_KARMA_HOMELESS;
                    SkinTextLabel = "Psst...\nHast du bisschen Kokain für mich?";
                    SkinWindowText = "Hey... Ich kauf dir dein ganzes Kokain ab für 45$ pro G.";
                    SkinButton1Text = "Verkaufen";
                    SkinButton2Text = "Nee Dankee...";
                }
                else if (Data == 2)
                {
                    SkinHashKey = "a_m_o_tramp_01";
                    SkinKarmaEntity = NPC_ENTITY_KARMA_HOMELESS;
                    SkinTextLabel = "Hey...\nHast du einen Snack für mich?";
                    SkinWindowText = "Hast du einen Tankstellen Snack für mich?<br>ich geb dir sogar 1000$!!";
                    SkinButton1Text = "Verkaufen [1000$]";
                    SkinButton2Text = "Nein zieh ab!";
                }
                else if (Data == 3)
                {
                    SkinHashKey = "g_m_y_mexgoon_03";
                    SkinKarmaEntity = NPC_ENTITY_KARMA_BAD;
                    SkinTextLabel = "Psst... Eyy!!\nHab n geiles Angebot für dich...";
                    SkinWindowText = "Hab hier ne geile Pistol für dich...<br>50 Schuss! Frisch Poliert! Interesse?";
                    SkinButton1Text = "Kaufen[200$]";
                    SkinButton2Text = "Zieh ab digga..";
                }
                else if (Data == 4)
                {
                    SkinHashKey = "csb_cop";
                    SkinKarmaEntity = NPC_ENTITY_KARMA_COP;
                    SkinTextLabel = "Psst... Eyy!!\nHol das Paket vom LS Airport ab!";
                    SkinWindowText = "Hey kleiner... Da gibt es ein Koka Paket am LS - Airport...<br>Hol das Paket vom Airport ab und bring ihn zum Dealer ohne Erwischt zu werden!";
                    SkinButton1Text = "Job Annehmen";
                    SkinButton2Text = "Nein danke...";
                }
                else if (Data == 5)
                {
                    SkinHashKey = "s_m_y_cop_01";
                    SkinKarmaEntity = NPC_ENTITY_KARMA_COP;
                    SkinTextLabel = "Pew Pew...!\nWillst du ein geiles Angebot ?";
                    SkinWindowText = "Willst du ne Combat - PDW? Geiles Angebot!! 300 Schuss!!!";
                    SkinButton1Text = "Kaufen[1000$]";
                    SkinButton2Text = "Nööö!";
                }
                else if (Data == 6)
                {
                    SkinHashKey = "u_m_y_mani";
                    SkinKarmaEntity = NPC_ENTITY_KARMA_BAD;
                    SkinTextLabel = "*Sniff Sniff*\nHast du etwas Kokain ?";
                    SkinWindowText = "Hey... Ich kauf dir dein ganzes Kokain ab für 45$ pro G.";
                    SkinButton1Text = "Verkaufen]";
                    SkinButton2Text = "Nee Dankee...";
                }
                else if (Data == 7)
                {
                    SkinHashKey = "a_m_y_mexthug_01";
                    SkinKarmaEntity = NPC_ENTITY_KARMA_BAD;
                    SkinTextLabel = "*Ka Boooom*\nWillst du etwas C4 Kaufen?";
                    SkinWindowText = "Perfekt geeignet für einen Bankraub!<br>Interesse an etwas C4?";
                    SkinButton1Text = "Kaufen[10.000$]";
                    SkinButton2Text = "Ablehnen";
                }
                else if (Data == 8)
                {
                    SkinHashKey = "ig_ramp_gang";
                    SkinKarmaEntity = NPC_ENTITY_KARMA_BAD;
                    SkinTextLabel = "*Ka Boooom*\nWillst du etwas C4 Kaufen?";
                    SkinWindowText = "Perfekt geeignet für einen Bankraub!<br>Interesse an etwas C4?";
                    SkinButton1Text = "Kaufen[10.000$]";
                    SkinButton2Text = "Ablehnen";
                }
                else if (Data == 9)
                {
                    SkinHashKey = "s_m_y_autopsy_01";
                    SkinKarmaEntity = NPC_ENTITY_KARMA_BAD;
                    SkinTextLabel = "*Ka Boooom*\nWillst du etwas C4 Kaufen?";
                    SkinWindowText = "Perfekt geeignet für einen Bankraub!<br>Interesse an etwas C4?";
                    SkinButton1Text = "Kaufen[10.000$]";
                    SkinButton2Text = "Ablehnen";
                }
                else if (Data == 10)
                {
                    SkinHashKey = "g_m_y_ballasout_01";
                    SkinKarmaEntity = NPC_ENTITY_KARMA_BAD;
                    SkinTextLabel = "*Rumm Rummmmmmm*\nAlter ist das geil!!!";
                    SkinWindowText = "Willst du ein Random Fahrzeug Kaufen?<br>Es könnte ein Ferrari sein oder auch ein Asea..";
                    SkinButton1Text = "Kaufen[10.000$]";
                    SkinButton2Text = "Ablehnen";

                }
                col.vnxSetElementData(NPC_ENTITY_SKINHASHKEY, SkinHashKey);
                col.vnxSetElementData(NPC_ENTITY_KARMA, SkinKarmaEntity);
                col.vnxSetElementData(NPC_ENTITY_LABEL, SkinTextLabel);
                col.vnxSetElementData(NPC_ENTITY_WINDOW_TEXT, SkinWindowText);
                col.vnxSetElementData(NPC_ENTITY_BUTTON1_TEXT, SkinButton1Text);
                col.vnxSetElementData(NPC_ENTITY_BUTTON2_TEXT, SkinButton2Text);
                NPCPeds.Add(RageAPI.CreateNPC(SkinHashKey, new Vector3(col.CurrentPosition.X, col.CurrentPosition.Y, col.CurrentPosition.Z + 0.5f), new Vector3(0, 0, rotation), 0, null));
                NPCLabels.Add(RageAPI.CreateTextLabel(SkinTextLabel, new Vector3(col.CurrentPosition.X, col.CurrentPosition.Y, col.CurrentPosition.Z + 1.25f), 10f, 0.6f, 0, new int[] { 255, 255, 255, 255 }, 0));
            }
            catch { }
        }
        public static void OnUpdate()
        {
            if (NPC_NextUpdate_Pos < DateTime.Now)
            {
                NPC_NextUpdate_Pos = DateTime.Now.AddHours(NPC_UPDATE_TIME);
                DeleteAllNPCs();
                CreateNewNPC();
                Debug.OutputDebugString("Es wurden neue Random - NPC's nun erstellt!");
            }
        }



        //Part 2 
        /*
        public static void OnPlayerEnterColShape(IColShape shape, Client player)
        {
            try
            {
                if (shape.vnxGetElementData<bool>(NPC_COLSHAPE) == true)
                {
                    string EntityKarma = shape.GetData(NPC_ENTITY_KARMA);
                    string WindowText = shape.GetData(NPC_ENTITY_WINDOW_TEXT);
                    string Button1Text = shape.GetData(NPC_ENTITY_BUTTON1_TEXT);
                    string Button2Text = shape.GetData(NPC_ENTITY_BUTTON2_TEXT);
                    dxLibary.VnX.DrawWindowSelection(player, NPC_WINDOW_HEADER_TEXT, WindowText, Button1Text, Button2Text);
                    player.SetData(NPC_COLSHAPE_ID, shape.GetData(NPC_COLSHAPE_ID));
                }
            }
            catch { }
        }
        */

        public static void OnClickedButton(VnXPlayer player, string button)
        {
            if (button == "button_1")
            {
                int Data = player.vnxGetElementData<int>(NPC_COLSHAPE_ID);
                NPC_StartAction(player, Data);
            }
        }


        public static void NPC_StartAction(VnXPlayer player, int Data)
        {
            if (Data == 0)
            {
                Vector3 Pos = new Vector3();
                Core.RageAPI.CreateNPC("a_m_y_mexthug_01", Pos, new Vector3(0, 0, 0), 0, player);
                dxLibary.VnX.DrawWaypoint(player, Pos.X, Pos.Y);
                dxLibary.VnX.DrawZielBlip(player, "NPC_MISSION", Pos, 303, 1, 0);
            }
            else if (Data == 1)
            {
                //ToDo : Verkaufen Koks * 45
            }
            else if (Data == 2)
            {
                //ToDo : Tankstellen Snack verkauf

            }
            else if (Data == 3)
            {
                //ToDo : Pistolen Verkauf
            }
            else if (Data == 4)
            {
                // ToDo: Airport Paket Mission.
            }
            else if (Data == 5)
            {
                // ToDo : Combat PDW Angebot.
            }
            else if (Data == 6)
            {
                //ToDo : Verkaufen Koks * 45
            }
            else if (Data == 7)
            {
                // ToDo : C4 Kaufen.
            }
            else if (Data == 8)
            {
                // ToDo : C4 Kaufen.
            }
            else if (Data == 9)
            {
                // ToDo : C4 Kaufen.
            }
            else if (Data == 10)
            {
                // ToDo : Random Vehicle.
            }
        }

        [ClientEvent("NPC:OnFinishedMission")]
        public static void NPC_OnFinishedMission(VnXPlayer player, string Event)
        {
            if (Event == "TargetNPC:Killed")
            {
                Core.Debug.OutputDebugString("Hiii Du hast einen Target Enemy gekillt :D");
            }
        }

    }
}
