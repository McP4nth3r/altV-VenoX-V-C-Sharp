using AltV.Net;
using AltV.Net.Data;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Globals;

namespace VenoXV.Zombie.KI
{
    public class Spawner : IScript
    {
        public static int RANDOM_COUNTER = 0;
        public static int X_ADD = 0;
        public static int Y_ADD = 0;
        public static Position ZOMBIESPAWN;


        public static void TriggerForEveryoneInLobby(PlayerModel player, Position coord)
        {
            foreach (PlayerModel players in Alt.GetAllPlayers())
            {
                if (players.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_GAMEMODE) == EntityData.GAMEMODE_ZOMBIE)
                {
                    players.Emit("Zombie:SpawnKI", "u_m_y_zombie_01", coord, player);
                }
            }
        }



        public static void SpawnZombiesArroundPlayers()
        {
            foreach (PlayerModel player in Alt.GetAllPlayers())
            {
                if (player.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_GAMEMODE) == EntityData.GAMEMODE_ZOMBIE)
                {
                    if (RANDOM_COUNTER == 0)
                    {
                        X_ADD = 2;
                        Y_ADD = 2;
                        ZOMBIESPAWN = new Position(player.position.X + X_ADD, player.position.Y + Y_ADD, player.position.Z);
                    }
                    else if (RANDOM_COUNTER == 1)
                    {
                        X_ADD = 4;
                        Y_ADD = -4;
                        ZOMBIESPAWN = new Position(player.position.X + X_ADD, player.position.Y - Y_ADD, player.position.Z);

                    }
                    else if (RANDOM_COUNTER == 2)
                    {
                        X_ADD = 10;
                        Y_ADD = -2;
                        ZOMBIESPAWN = new Position(player.position.X + X_ADD, player.position.Y - Y_ADD, player.position.Z);
                    }
                    else if (RANDOM_COUNTER == 4)
                    {
                        X_ADD = 17;
                        Y_ADD = 7;
                        ZOMBIESPAWN = new Position(player.position.X + X_ADD, player.position.Y + Y_ADD, player.position.Z);

                    }
                    else
                    {
                        RANDOM_COUNTER = 0;
                        X_ADD = -10;
                        Y_ADD = -10;
                        ZOMBIESPAWN = new Position(player.position.X - X_ADD, player.position.Y - Y_ADD, player.position.Z);

                    }

                    TriggerForEveryoneInLobby(player, ZOMBIESPAWN);

                    //player.SendChatMessage( "Zombie Spawned" + player.position.X + X_ADD + " || " +  player.position.Y + Y_ADD + " || " + player.position.Z);

                    RANDOM_COUNTER += 1;
                }
            }
        }
    }
}
