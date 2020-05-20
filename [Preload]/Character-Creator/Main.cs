using AltV.Net;
using System.Collections.Generic;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
namespace VenoXV._Preload_.Character_Creator
{
    public class Main : IScript
    {
        public static List<CharacterModel> CharacterSkins;
        [ClientEvent("CharCreator:Create")]
        public static void OnCharCreatorCreateCall(Client player, string facefeatures, string headblends, string headoverlays)
        {
            Core.Debug.OutputDebugString("----------------");
            Core.Debug.OutputDebugString(facefeatures);
            Core.Debug.OutputDebugString(headblends);
            Core.Debug.OutputDebugString(headoverlays);
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
            CharacterSkins.Add(playerClassSkin);
            Database.CreateCharacterSkin(player.UID, facefeatures, headblends, headoverlays);
        }
    }
}