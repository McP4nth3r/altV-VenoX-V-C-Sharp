using AltV.Net;
using System.Collections.Generic;
using System.Linq;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Preload_.Character_Creator
{
    public class Main : IScript
    {
        public static List<CharacterModel> CharacterSkins;
        [ClientEvent("CharCreator:Create")]
        public static void OnCharCreatorCreateCall(VnXPlayer player, string facefeatures, string headblends, string headoverlays)
        {
            try
            {
                int UID = Database.GetPlayerUID(player.Username);
                //int UID = player.UID;

                Debug.OutputDebugString("----------------");
                Debug.OutputDebugString(facefeatures);
                Debug.OutputDebugString(headblends);
                Debug.OutputDebugString(headoverlays);
                Debug.OutputDebugString("" + player.UID);
                Debug.OutputDebugString("----------------");
                CharacterModel playerClassSkin = new CharacterModel
                {
                    UID = player.UID,
                    FaceFeatures = facefeatures,
                    HeadBlendData = headblends,
                    HeadOverlays = headoverlays
                };
                foreach (CharacterModel skin in CharacterSkins.ToList())
                {
                    if (skin.UID == player.UID) { return; }
                }
                CharacterSkins.Add(playerClassSkin);
                Database.CreateCharacterSkin(player.UID, facefeatures, headblends, headoverlays);
                VenoX.TriggerClientEvent(player, "CharCreator:Close");
                Database.LoadCharacterInformationById(player, UID);
                player.Reallife.SpawnLocation = "Wuerfelpark";
                player.SpawnPlayer(player.Position);
                Preload.ShowPreloadList(player);
                if (player.AdminRank <= 0) { player.Kick("NOT WHITELISTED"); return; }
            }
            catch { }
        }

        public static bool PlayerHaveSkin(VnXPlayer player)
        {
            try
            {
                foreach (CharacterModel skin in CharacterSkins.ToList())
                {
                    if (skin.UID == player.UID) { return true; }
                }
                return false;
            }
            catch { return false; }
        }

        public static void LoadCharacterSkin(VnXPlayer player)
        {
            try
            {
                player.SetPlayerSkin(player.Sex == 0 ? (uint)AltV.Net.Enums.PedModel.FreemodeMale01 : (uint)AltV.Net.Enums.PedModel.FreemodeFemale01);
                VenoX.TriggerClientEvent(player, "Player:DefaultComponentVariation");
                foreach (CharacterModel skins in CharacterSkins)
                {
                    if (skins.UID == player.UID)
                    {
                        VenoX.TriggerClientEvent(player, "Charselector:setCorrectSkin", skins.FaceFeatures, skins.HeadBlendData, skins.HeadOverlays);
                    }
                }
            }
            catch { }
        }
    }
}