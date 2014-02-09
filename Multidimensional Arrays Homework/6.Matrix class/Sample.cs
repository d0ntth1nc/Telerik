using System;

namespace _6.Matrix_class
{
    class Sample
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(5, 5);
            Matrix secondMatrix = new Matrix(5, 5);
            Random randomValue = new Random();

            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Columns; col++)
                {
                    matrix[row, col] = randomValue.Next(0, 20);
                    secondMatrix[row, col] = randomValue.Next(0, 20);
                }
            }
            Console.WriteLine("First matrix:");
            Console.WriteLine(matrix.ToString());

            Console.WriteLine("Second matrix:");
            Console.WriteLine(secondMatrix.ToString());

            var multiplied = matrix * secondMatrix;
            Console.WriteLine("First matrix * second matrix:");
            Console.WriteLine(multiplied.ToString());

            var total = matrix + secondMatrix;
            Console.WriteLine("First matrix + second matrix:");
            Console.WriteLine(total.ToString());

            var distinction = matrix - secondMatrix;
            Console.WriteLine("First matrix - second matrix:");
            Console.WriteLine(distinction.ToString());
        }
    }
}
