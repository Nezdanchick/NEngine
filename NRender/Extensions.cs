using System;

namespace NRender
{
    public static class Extensions
    {
        public static double[] ToOneDimension(this double[,] matrix, int dimension = 0, int index = 0)
        {
            if (dimension > 1) throw new Exception("Two dimension array only ( first dimension is 0 )");
            double[] result = new double[matrix.GetLength(dimension)];
            bool d = dimension == 0;
            for (int i = 0; i < matrix.GetLength(dimension); i++)
            {
                result[i] = d ? matrix[i, index] : matrix[index, i];
            }
            return result;
        }
    }
}
