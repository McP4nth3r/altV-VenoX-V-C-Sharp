using System.Data;
using MySql.Data.MySqlClient;

namespace VenoXV._Gamemodes_.Reallife.database
{
    class Storage
    {
        /* DB INFOS */
        private static string _dbHost = "51.68.181.55";
        private static string _dbUser = "venox_ingame";
        private static string _dbPass = "G#l7wz27";
        private static string _dbName = "venox_ingame";

        /* Storage */
        private MySqlConnection _handle;

        public Storage()
        {
            // Create connect string
            string connectString = "SERVER=" + _dbHost + "; DATABASE=" + _dbName + "; UID=" + _dbUser + "; PASSWORD=" + _dbPass + "; SSLMODE=none;";

            // Open connection
            _handle = new MySqlConnection(connectString);
            _handle.Open();
            if(!IsOpen())
            {
                // ToDo: Shutdown gamemode
            }
        }

        public void Close()
        {
            _handle.Close();
        }

        public bool IsOpen()
        {
            return (_handle.State == ConnectionState.Open);
        }


    }
}
