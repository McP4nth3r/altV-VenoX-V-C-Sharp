using AltV.Net;
using AltV.Net.Elements.Entities;

namespace VenoXV.Globals.Voice
{
    public class Main : IScript
    {
        // We Create a Voicechat-Channel & set it to 3D by setting ,, spatial " to true.
        public static IVoiceChannel channel = Alt.CreateVoiceChannel(true, 40f);

        // When a Player connects... it should put the Player into the VoiceChannel.
        [ScriptEvent(ScriptEventType.PlayerConnect)]
        public void PlayerConnect(IPlayer player, string reason)
        {
            channel.AddPlayer(player);
            //channel?.MutePlayer(player);
        }

        // When a Player disconnects... it should remove the Player from the VoiceChannel.
        [ScriptEvent(ScriptEventType.PlayerDisconnect)]
        public void OnPlayerDisconnect(IPlayer client, string reason)
        {
            Core.RageAPI.SendChatMessageToAll("Client" + reason);
            channel.RemovePlayer(client);
        }

        // We declare our Client-Event...
        [ClientEvent("Voice:ChangeState")]
        public static void ChangeVoiceState(IPlayer player, bool state)
        {
            if (state)
            { //channel?.MutePlayer(player); player.SendChatMessage("Voice " + Core.RageAPI.GetHexColorcode(200, 0, 0) + " Muted"); 
            }
            else
            { //channel?.UnmutePlayer(player); player.SendChatMessage("Voice " + Core.RageAPI.GetHexColorcode(0, 200, 0) + " Unmuted"); 
            }
        }
    }
}
