using AltV.Net;
using System.Collections.Generic;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Preload_.Character_Creator
{
    public class Main : IScript
    {
        public static List<CharacterModel> CharacterSkins;
        [ClientEvent("CharCreator:Create")]
        public static void OnCharCreatorCreateCall(Client player, string facefeatures, string headblends, string headoverlays)
        {
            int UID = Database.GetPlayerUID(player.Username);
            player.UID = UID;

            Core.Debug.OutputDebugString("----------------");
            Core.Debug.OutputDebugString(facefeatures);
            Core.Debug.OutputDebugString(headblends);
            Core.Debug.OutputDebugString(headoverlays);
            Core.Debug.OutputDebugString("" + player.UID);
            Core.Debug.OutputDebugString("----------------");
            CharacterModel playerClassSkin = new CharacterModel
            {
                UID = player.UID,
                FaceFeatures = facefeatures,
                HeadBlendData = headblends,
                HeadOverlays = headoverlays
            };
            foreach (CharacterModel skin in CharacterSkins)
            {
                if (skin.UID == player.UID) { return; }
            }
            player.DespawnPlayer();
            CharacterSkins.Add(playerClassSkin);
            Database.CreateCharacterSkin(player.UID, facefeatures, headblends, headoverlays);
            Alt.Server.TriggerClientEvent(player,"preload_gm_list");
            Alt.Server.TriggerClientEvent(player,"CharCreator:Close");
            Database.LoadCharacterInformationById(player, UID);
        }

        public static bool PlayerHaveSkin(Client player)
        {
            foreach (CharacterModel skin in CharacterSkins)
            {
                if (skin.UID == player.UID) { return true; }
            }
            return false;
        }

        public static void LoadCharacterSkin(Client player)
        {
            player.SetPlayerSkin(player.Sex == 0 ? (uint)AltV.Net.Enums.PedModel.FreemodeMale01 : (uint)AltV.Net.Enums.PedModel.FreemodeFemale01);
            foreach (CharacterModel skins in CharacterSkins)
            {
                if (skins.UID == player.UID)
                {
                    Alt.Server.TriggerClientEvent(player,"Charselector:setCorrectSkin", skins.FaceFeatures, skins.HeadBlendData, skins.HeadOverlays);
                }
            }
        }
    }
}