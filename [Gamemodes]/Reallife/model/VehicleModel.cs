using AltV.Net.Data;
using MySql.Data.MySqlClient;
using System.Numerics;
using VenoXV._Gamemodes_.Reallife.Globals;

namespace VenoXV._Gamemodes_.Reallife.model
{
    public class VehicleModel
    {
        public int id { get; set; }
        public string model { get; set; }
        public string owner { get; set; }
        public string plate { get; set; }
        public Position position { get; set; }
        public Rotation rotation { get; set; }
        public int RgbaType { get; set; }
        public string firstRgba { get; set; }
        public string secondRgba { get; set; }
        public int pearlescent { get; set; }
        public int dimension { get; set; }
        public int faction { get; set; }
        public int engine { get; set; }
        public int locked { get; set; }
        public int price { get; set; }
        public int parking { get; set; }
        public int parked { get; set; }
        public float gas { get; set; }
        public float kms { get; set; }

        public VehicleModel()
        {

        }



        /// <summary>
        /// Converts a roll pitch yaw vector to a rotation vector.
        /// </summary>
        /// <param name="d">A vector where X=Roll, Y=Pitch, Z=Yaw</param>
        /// <returns>A rotation vector with rx, ry and rz used to rotate the TCP of UR10</returns>

        public VehicleModel(MySqlDataReader reader)
        {
            float posX = reader.GetFloat("posX");
            float posY = reader.GetFloat("posY");
            float posZ = reader.GetFloat("posZ");
            float rotation = reader.GetFloat("rotation");

            this.id = reader.GetInt32("id");
            this.model = reader.GetString("model");
            this.RgbaType = reader.GetInt32("colorType");
            this.firstRgba = reader.GetString("firstColor");
            this.secondRgba = reader.GetString("secondColor");
            this.pearlescent = reader.GetInt32("pearlescent");
            this.owner = reader.GetString("owner");
            this.plate = reader.GetString("plate");
            this.faction = reader.GetInt32("faction");
            if (this.faction > 0)
            {
                this.dimension = reader.GetInt32("dimension");
            }
            else
            {
                this.dimension = Constants.VEHICLE_OFFLINE_DIM;
            }
            this.engine = reader.GetInt32("engine");
            this.locked = reader.GetInt32("locked");
            this.price = reader.GetInt32("price");
            this.parking = reader.GetInt32("parking");
            this.parked = reader.GetInt32("parkedTime");
            this.gas = reader.GetFloat("gas");
            this.kms = reader.GetFloat("kms");
            this.position = new Position(posX, posY, posZ);
            this.rotation = new Vector3(0, 0, (float)(System.Math.PI / 180) * rotation);
        }

    }
}
