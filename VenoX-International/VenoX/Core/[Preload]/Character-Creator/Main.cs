using System;
using System.Collections.Generic;
using System.Linq;
using AltV.Net;
using AltV.Net.Enums;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Database;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Preload_.Character_Creator
{
    public class Main : IScript
    {
        public static List<CharacterModel> CharacterSkins;
        [VenoXRemoteEvent("CharCreator:Create")]
        public static void OnCharCreatorCreateCall(VnXPlayer player, string facefeatures, string headblends, string headoverlays)
        {
            try
            {
                int uid = Database.GetPlayerUid(player.CharacterUsername);
                //int UID = player.UID;

                ConsoleHandling.OutputDebugString("----------------");
                ConsoleHandling.OutputDebugString(facefeatures);
                ConsoleHandling.OutputDebugString(headblends);
                ConsoleHandling.OutputDebugString(headoverlays);
                ConsoleHandling.OutputDebugString("" + player.CharacterId);
                ConsoleHandling.OutputDebugString("----------------");
                CharacterModel playerClassSkin = new CharacterModel
                {
                    Uid = player.CharacterId,
                    FaceFeatures = facefeatures,
                    HeadBlendData = headblends,
                    HeadOverlays = headoverlays
                };
                foreach (CharacterModel skin in CharacterSkins.ToList())
                    if (skin.Uid == player.CharacterId) return;

                CharacterSkins.Add(playerClassSkin);
                Database.CreateCharacterSkin(player.CharacterId, facefeatures, headblends, headoverlays);
                _RootCore_.VenoX.TriggerClientEvent(player, "CharCreator:Close");
                Database.LoadCharacterInformationById(player, uid);
                player.Visible = true;
                player.Reallife.SpawnLocation = "Wuerfelpark";
                player.SpawnPlayer(player.Position);
                Preload.ShowPreloadList(player, true);
                //if (player.AdminRank <= 0) { player.Kick("NOT WHITELISTED"); return; }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        public static bool PlayerHaveSkin(VnXPlayer player)
        {
            try
            {
                foreach (CharacterModel skin in CharacterSkins.ToList())
                    if (skin.Uid == player.CharacterId) return true;

                return false;
            }
            catch { return false; }
        }

        public static void LoadCharacterSkin(VnXPlayer player)
        {
            try
            {
                player.SetPlayerSkin(player.Sex == 0 ? (uint)PedModel.FreemodeMale01 : (uint)PedModel.FreemodeFemale01);
                _RootCore_.VenoX.TriggerClientEvent(player, "Player:DefaultComponentVariation");
                foreach (CharacterModel skins in CharacterSkins)
                    if (skins.Uid == player.CharacterId)
                        _RootCore_.VenoX.TriggerClientEvent(player, "Charselector:setCorrectSkin", skins.FaceFeatures, skins.HeadBlendData, skins.HeadOverlays);
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
    }
}