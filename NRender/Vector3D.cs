using System;
using System.Drawing;

namespace NRender
{
    public class Vector3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector2D Projected { get; set; }
        public Point ProjectedPoint => new Point(Convert.ToInt32(Projected.X*10),
                    Convert.ToInt32(Projected.Y*10));

        public Vector3D(double x, double y, double z)
        {
            Projected = new Vector2D(0, 0);
            X = x;
            Y = y;
            Z = z;
        }

        public void Projection2D(Camera camera)
        {
            Projection2D(camera.Width, camera.Height, camera.FOV, camera.FocalLength);
        }
        private void Projection2D(double width, double height, double fov, double focalLength)
        {
            double factor = fov / (focalLength + Z);
            Projected.X = X * factor + width / 2;
            Projected.Y = -Y * factor + height / 2;
        }

        public void Rotate(double angle, Direction direction = Direction.X)
        {
            double radius = angle * Math.PI / 180;
            double cos = Math.Cos(radius);
            double sin = Math.Sin(radius);
            Matrix matrixA;
            Matrix matrixB = new Matrix(new double[,] {
                    { cos, -sin },
                    { sin, cos } });
            double x = X, y = Y, z = Z;
            switch (direction)
            {
                case Direction.X:
                    matrixA = Vector2D.ToMatrix(y, z);
                    setResult(out y, out z);
                    break;
                case Direction.Y:
                    matrixA = Vector2D.ToMatrix(x, z);
                    setResult(out x, out z);
                    break;
                case Direction.Z:
                    matrixA = Vector2D.ToMatrix(x, y);
                    setResult(out x, out y);
                    break;
            }
            X = x; Y = y; Z = z;

            void setResult(out double a, out double b)
            {
                var result = (matrixA * matrixB);
                a = result[0, 0];
                b = result[0, 1];
            }
        }

        public void ConsoleDraw(Camera camera)
        {
            Projection2D(camera);
            Console.SetCursorPosition(  (int)(Projected.X),
                                        (int)(Projected.Y));
            Console.Write(".");
        }

        public enum Direction
        {
            X,
            Y,
            Z
        }
    }
}
