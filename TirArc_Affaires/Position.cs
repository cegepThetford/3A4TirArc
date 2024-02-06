using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TirArc_Affaires
{
    public class Position
    {
        private double _x, _y, _z;
        #region Proprietes
        public double X { get { return _x; } set { _x = value; } }
        public double Y { get { return _y; } set { _y = value; } }
        public double Z { get { return _z; } set { _z = value; } }
        #endregion
        public Position(double x = 0.0, double y = 0.0, double z = 0.0)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public double calculerDistance(Position autrePosition)
        {
            double cx = _x - autrePosition.X;
            double cy = _y - autrePosition.Y;
            double cz = _z - autrePosition.Z;
            return Math.Sqrt(cx * cx + cy * cy + cz * cz);
        }
    }
}
