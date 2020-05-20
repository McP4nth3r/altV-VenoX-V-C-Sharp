using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace VenoXV._Gamemodes_.Reallife.database
{
    class Storage
    {
        /* DB INFOS */
        private static string DB_HOST = "51.68.181.55";
        private static string DB_USER = "venox_ingame";
        private static string DB_PASS = "G#l7wz27";
        private static string DB_NAME = "venox_ingame";

        /* Storage */
        private MySqlConnection _handle;

        public Storage()
        {
            // Create connect string
            string connectString = "SERVER=" + DB_HOST + "; DATABASE=" + DB_NAME + "; UID=" + DB_USER + "; PASSWORD=" + DB_PASS + "; SSLMODE=none;";

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
