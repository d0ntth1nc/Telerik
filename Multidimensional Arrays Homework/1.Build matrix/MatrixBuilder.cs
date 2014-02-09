using System;

namespace _1.Build_matrix
{
    //Write a program that fills and prints a matrix of size (n, n) as shown below: (run the program to see)
    class MatrixBuilder
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BuildFirstMatrix(n);
            BuildSecondMatrix(n);
            BuildThirdMatrix(n);
            BuildFourthMatrix(n);
        }

        static void BuildFirstMatrix(int n)
        {
            int[,] matrix = new int[n, n];
            int counter = 1;
            for (int col = 0; col < n; col++)
            {
                for (int row = 0; row < n; row++)
                {
                    matrix[row, col] = counter;
                    counter++;
                }
            }
            PrintMatrix(matrix);
        }

        static void BuildSecondMatrix(int n)
        {
            int[,] matrix = new int[n, n];
            int counter = 1;
            for (int col = 0; col < n; col++)
            {
                if (col % 2 == 0)
                {
                    for (int row = 0; row < n; row++)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                }
                else
                {
                    for (int row = n - 1; row >= 0; row--)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                }
            }
            PrintMatrix(matrix);
        }

        static void BuildThirdMatrix(int n)
        {
            int[,] matrix = new int[n, n];
            int beginningRow = n - 1;
            int beginningCol = 0;
            int counter = 0;
            int currentValue = 1;
            while (currentValue <= n * n)
            {
                int currentRow = beginningRow + counter;
                int currentCol = beginningCol + counter;
                matrix[currentRow, currentCol] = currentValue;
                counter++;
                currentValue++;

                if(beginningRow > 0)
                {
                    if (currentRow == n - 1) //Hit down array border
                    {
                        beginningRow--;
                        counter = 0;
                    }
                }
                else
                {
                    if (currentCol == n - 1) //Hit left array border
                    {
                        beginningCol++;
                        counter = 0;
                    }
                }
            }
            PrintMatrix(matrix);
        }

        static void BuildFourthMatrix(int n)
        {
            /* CLR zeroes all arrays so we can check if the next value is != instead of creating new bool array usedPlaces,
             * but lets do it with bool array(the homework subject is multidimensional arrays :) ).
             */
            int[,] matrix = new int[n, n];
            bool[,] usedPlaces = new bool[n, n];
            int currentValue = 1;
            int currentRow = 0;
            int currentCol = 0;
            string direction = "down"; //Default start direction
            while (currentValue <= n * n)
            {
                matrix[currentRow, currentCol] = currentValue;
                usedPlaces[currentRow, currentCol] = true;
                currentValue++;
                if(direction == "down")
                {
                    //check if the current element hits border or the next element will hit used place
                    if (currentRow == n - 1 || usedPlaces[currentRow + 1, currentCol] == true)
                    {
                        direction = "right";
                        currentCol++;
                    }
                    else
                    {
                        currentRow++;
                    }
                }
                else if(direction == "right")
                {
                    if (currentCol == n - 1 || usedPlaces[currentRow, currentCol + 1] == true)
                    {
                        direction = "up";
                        currentRow--;
                    }
                    else
                    {
                        currentCol++;
                    }

                }
                else if (direction == "up")
                {
                    if (currentRow == 0 || usedPlaces[currentRow - 1, currentCol] == true)
                    {
                        direction = "left";
                        currentCol--;
                    }
                    else
                    {
                        currentRow--;
                    }
                }
                else if (direction == "left")
                {
                    if (currentRow == n - 1 || usedPlaces[currentRow, currentCol - 1] == true)
                    {
                        direction = "down";
                        currentRow++;
                    }
                    else
                    {
                        currentCol--;
                    }
                }
            }
            PrintMatrix(matrix);
        }

        static void PrintMatrix(int[,] matrix)
        {
            Console.WriteLine();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0} ", matrix[row, col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
