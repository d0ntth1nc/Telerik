using System;

namespace _2.Find_square_with_maximal_sum
{
    //Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.
    class SquareFinder
    {
        static void PrintMatrix(int[,] matrix, int wantedValueRow, int wantedValueCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    bool currentRowIsWithinTheSquare = row == wantedValueRow || row == wantedValueRow + 1 || row == wantedValueRow + 2;
                    bool currentColIsWithinTheSquare = col == wantedValueCol || col == wantedValueCol + 1 || col == wantedValueCol + 2;
                    if (currentRowIsWithinTheSquare && currentColIsWithinTheSquare)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ResetColor();
                    }
                    Console.Write("{0} ", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        static int[,] ReadMatrix()
        {
            Console.Write("Enter rows: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Enter cols: ");
            int cols = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the values:");
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write("{0},{1}: ", row, col);
                    matrix[row, col] = int.Parse(Console.ReadLine());
                }
            }
            return matrix;
        }

        static void Main(string[] args)
        {
            var matrix = ReadMatrix();

            int maximalSum = 0;
            int wantedValueRow = 0;
            int wantedValueCol = 0;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currentSum = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        currentSum += matrix[row, col + i];
                        currentSum += matrix[row + 1, col + i];
                        currentSum += matrix[row + 2, col + i];
                    }
                    if (currentSum > maximalSum)
                    {
                        wantedValueCol = col;
                        wantedValueRow = row;
                        maximalSum = currentSum;
                    }
                }
            }

            PrintMatrix(matrix, wantedValueRow, wantedValueCol);
            Console.WriteLine("Maximal sum = {0}", maximalSum);
        }
    }
}
