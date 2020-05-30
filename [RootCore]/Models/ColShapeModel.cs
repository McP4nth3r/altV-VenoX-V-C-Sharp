using AltV.Net.Elements.Entities;
using System.Numerics;

namespace VenoXV._RootCore_.Models
{
    public class ColShapeModel
    {
        public IColShape Entity { get; set; }
        public Vector3 Position { get; set; }
        public float Radius { get; set; }
        public int Dimension { get; set; }
        public void vnxSetElementData(string element, object value)
        {
            Core.RageAPI.vnxSetElementData(Entity, element, value);
        }
        public T vnxGetElementData<T>(string key)
        {
            return Core.RageAPI.vnxGetElementData<T>(Entity, key);
        }
    }
}
