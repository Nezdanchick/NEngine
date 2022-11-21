using System;
using System.Collections.Generic;
using System.Text;

namespace NRender
{
    public class Vector2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Matrix ToMatrix()
        {
            return ToMatrix(X, Y);
        }
        public static Matrix ToMatrix(double x, double y)
        {
            return new Matrix(new double[,] {
                { x, y },
                { x, y }
            });
        }
    }
}
