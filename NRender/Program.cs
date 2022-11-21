using System;
using System.Collections.Generic;

namespace NRender
{
    class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Camera camera = new Camera
            {
                Width = 50,
                Height = 30,
                FOV = 120,
                FocalLength = 15
            };

            List<Vector3D> vectors = new List<Vector3D>()
            {
                new Vector3D(-1, 1, 1),//       #           #
                new Vector3D(1, 1, 1),//            #           #

                new Vector3D(-1, -1, 1),
                new Vector3D(1, -1, 1),

                new Vector3D(-1, 1, -1),
                new Vector3D(1, 1, -1),

                new Vector3D(-1, -1, -1),//     #           #
                new Vector3D(1, -1, -1),//          #           #
            };

            for (int i = 0; i < 180; i += 1)
            {
                foreach (var e in vectors)
                {
                    e.ConsoleDraw(camera);
                    e.Rotate(15, Vector3D.Direction.Y);
                    Console.WriteLine();
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
