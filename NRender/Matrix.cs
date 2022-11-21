using System;
using System.Collections;

namespace NRender
{
    public class Matrix : IEnumerable
    {
        double[,] Array { get; set; }

        public Matrix(double[,] array)
        {
            Array = array;
        }

        public IEnumerator GetEnumerator()
        {
            return Array.GetEnumerator();
        }

        public static double[,] operator *(Matrix left, Matrix right)
        {
            var result = new double[left.Array.GetLength(0), right.Array.GetLength(1)];
            for (int y = 0; y < left.Array.GetLength(0); y++)
            {
                for (int x = 0; x < right.Array.GetLength(1); x++)
                {
                    for (int i = 0; i < left.Array.GetLength(1); i++)
                    {
                        result[y, x] += left.Array[y, i] * right.Array[i, x];
                    }
                }
            }
            return result;
        }
        public void ConsoleDisplay()
        {
            for (int y = 0; y < Array.GetLength(0); y++)
            {
                for (int x = 0; x < Array.GetLength(1); x++)
                {
                    Console.Write(Array[y, x] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
