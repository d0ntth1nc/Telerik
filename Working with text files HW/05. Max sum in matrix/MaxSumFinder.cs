using System;
using System.IO;

/*
Write a program that reads a text file containing a square matrix of numbers and finds in
the matrix an area of size 2 x 2 with a maximal sum of its elements. 
The first line in the input file contains the size of matrix N. Each of the next N lines contain N numbers separated by space. 
The output should be a single number in a separate text file.
 */
class MaxSumFinder
{
    static int FindMaxSum(int[,] matrix)
    {
        int currentSum = 0;
        int maxSum = int.MinValue;
        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                currentSum = matrix[row, col] + matrix[row + 1, col] + matrix[row, col + 1] + matrix[row + 1, col + 1];
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }
        }
        return maxSum;
    }

    static void Main(string[] args)
    {
        int[,] matrix = GetMatrix();
        int maxSum = FindMaxSum(matrix);
        using (StreamWriter sw = File.CreateText(@"result.txt"))
        {
            sw.Write(maxSum);
        }
    }

    private static int[,] GetMatrix()
    {
        using (StreamReader textFileReader = new StreamReader(@"ntd.txt"))
        {
            int[,] matrix;
            int matrixSize = Convert.ToInt32(textFileReader.ReadLine());
            matrix = new int[matrixSize, matrixSize];
            string matrixNumbers = textFileReader.ReadLine();
            int currentLine = 0;
            while (matrixNumbers != null)
            {
                string[] numbers = matrixNumbers.Split(' ');
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[currentLine, col] = Convert.ToInt32(numbers[col]);
                }
                currentLine++;
                matrixNumbers = textFileReader.ReadLine();
            }
            return matrix;
        }
    }
}
