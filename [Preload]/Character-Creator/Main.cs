using System;
using System.Collections.Generic;
using System.Linq;
using AltV.Net;
using AltV.Net.Enums;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Models;

namespace VenoXV._Preload_.Character_Creator
{
    public class Main : IScript
    {
        public static List<CharacterModel> CharacterSkins;
        [VenoXRemoteEvent("CharCreator:Create")]
        public static void OnCharCreatorCreateCall(VnXPlayer player, string facefeatures, string headblends, string headoverlays)
        {
            try
            {
                int uid = Database.Database.GetPlayerUid(player.Username);
                //int UID = player.UID;

                Debug.OutputDebugString("----------------");
                Debug.OutputDebugString(facefeatures);
                Debug.OutputDebugString(headblends);
                Debug.OutputDebugString(headoverlays);
                Debug.OutputDebugString("" + player.UID);
                Debug.OutputDebugString("----------------");
                CharacterModel playerClassSkin = new CharacterModel
                {
                    Uid = player.UID,
                    FaceFeatures = facefeatures,
                    HeadBlendData = headblends,
                    HeadOverlays = headoverlays
                };
                foreach (CharacterModel skin in CharacterSkins.ToList())
                    if (skin.Uid == player.UID) return;

                CharacterSkins.Add(playerClassSkin);
                Database.Database.CreateCharacterSkin(player.UID, facefeatures, headblends, headoverlays);
                VenoX.TriggerClientEvent(player, "CharCreator:Close");
                Database.Database.LoadCharacterInformationById(player, uid);
                player.Visible = true;
                player.Reallife.SpawnLocation = "Wuerfelpark";
                player.SpawnPlayer(player.Position);
                Preload.ShowPreloadList(player);
                //if (player.AdminRank <= 0) { player.Kick("NOT WHITELISTED"); return; }
            }
            catch { }
        }

        public static bool PlayerHaveSkin(VnXPlayer player)
        {
            try
            {
                foreach (CharacterModel skin in CharacterSkins.ToList())
                    if (skin.Uid == player.UID) return true;

                return false;
            }
            catch { return false; }
        }

        public static void LoadCharacterSkin(VnXPlayer player)
        {
            try
            {
                player.SetPlayerSkin(player.Sex == 0 ? (uint)PedModel.FreemodeMale01 : (uint)PedModel.FreemodeFemale01);
                VenoX.TriggerClientEvent(player, "Player:DefaultComponentVariation");
                foreach (CharacterModel skins in CharacterSkins)
                    if (skins.Uid == player.UID)
                        VenoX.TriggerClientEvent(player, "Charselector:setCorrectSkin", skins.FaceFeatures, skins.HeadBlendData, skins.HeadOverlays);
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}