using System;
using System.Collections.Generic;
using System.Text;

namespace NRender
{
    public class Line
    {
        public Vector3D FirstPoint { get; set; }
        public Vector3D SecondPoint { get; set; }
        public double Angle;

        public Line(Vector3D first, Vector3D second)
        {
            FirstPoint = first;
            SecondPoint = second;
        }

        public void FindAngle()
        {
            var tang = Math.Atan((SecondPoint.Y - FirstPoint.Y) /
                                 (SecondPoint.X - FirstPoint.X));
            var angle = tang * 180 / Math.PI;
            if (tang < 0)
                angle += 90;
            else
                angle = -(90 - angle);
            Angle = angle;
        }

        public void Draw(Camera camera)
        {
            FirstPoint.Projection2D(camera);
            SecondPoint.Projection2D(camera);
        }
    }
}
