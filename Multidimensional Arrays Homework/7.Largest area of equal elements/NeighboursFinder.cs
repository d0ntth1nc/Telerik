using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _7.Largest_area_of_equal_elements
{
    /*Write a program that finds the largest area of equal neighbor elements in a rectangular matrix and prints its size
     * I made this algorithm by myself and i don't have more time to optimize it (if it's possible)...
     */
    class NeighboursFinder
    {
        static void Main(string[] args)
        {
            int[,] matrix = 
            {
                {1, 3, 2, 2, 2, 4},
                {3, 3, 3, 2, 4, 4},
                {4, 3, 1, 2, 3, 3},
                {4, 3, 1, 3, 3, 1},
                {4, 3, 3, 3, 1, 1},
            };

            var timer = new Stopwatch();
            timer.Start();
            var foundElements = Search(matrix);
            timer.Stop();
            PrintMatrix(matrix, foundElements);
            Console.WriteLine("Algorithm execution time");
            Console.WriteLine(timer.Elapsed);
        }

        static List<Element> Search(int[,] inputMatrix)
        {
            bool[,] elementsWithNeighbours = new bool[inputMatrix.GetLength(0), inputMatrix.GetLength(1)];
            List<Element> mostNeighboursFound = new List<Element>();
            List<Element> foundNeighbourElements = new List<Element>();
            var startElement = new Element();
            
            for (int row = 0; row < inputMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < inputMatrix.GetLength(1); col++)
                {
                    startElement.Row = row;
                    startElement.Col = col;
                    startElement.Value = inputMatrix[row, col];
                    SearchForNeighbours(startElement, inputMatrix, ref elementsWithNeighbours, ref foundNeighbourElements);
                    if (foundNeighbourElements.Count > mostNeighboursFound.Count)
                    {
                        mostNeighboursFound = new List<Element>(foundNeighbourElements);
                        foundNeighbourElements.Clear();
                    }
                    else
                    {
                        foundNeighbourElements.Clear();
                    }
                }
            }
            return mostNeighboursFound;
        }

        static void SearchForNeighbours(Element parentElement, int[,] matrix, ref bool[,] elementsWithNeighbours, ref List<Element> foundElements)
        {
            int depth = 3;
            int startRow;
            int startCol;
            if (parentElement.Row == 0) //If it's the first element, we cant search outside the array :)
            {
                startRow = 0;
                depth = 2;
            }
            else
            {
                startRow = parentElement.Row - 1;
            }
            if (parentElement.Col == 0)
            {
                startCol = 0;
                depth = 2;
            }
            else
            {
                startCol = parentElement.Col - 1;
            }

            for (int row = startRow; row < startRow + depth; row++)
            {
                for (int col = startCol; col < startCol + depth; col++)
                {
                    if (row != parentElement.Row || col != parentElement.Col)
                    {
                        int currentMatrixElementValue = 0;
                        try
                        {
                            currentMatrixElementValue = matrix[row, col];
                        }
                        catch //We cant search for neighbours outside the array, so this loop is over
                        {
                            continue;
                        }
                        if (currentMatrixElementValue == parentElement.Value && elementsWithNeighbours[row, col] == false)
                        {
                            elementsWithNeighbours[row, col] = true; //Mart the element as a part of neighbour elements, so we can skip it in later searches
                            var foundElement = new Element();
                            foundElement.Row = row;
                            foundElement.Col = col;
                            foundElement.Value = currentMatrixElementValue;
                            foundElements.Add(foundElement);
                            SearchForNeighbours(foundElement, matrix, ref elementsWithNeighbours, ref foundElements); //Lets find its neighbours
                        }
                    }
                }
            }
        }

        static void PrintMatrix(int[,] matrix, List<Element> foundElements)
        {
            var element = new Element();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    element.Row = row;
                    element.Col = col;
                    element.Value = matrix[row, col];
                    if(foundElements.Contains(element))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ResetColor();
                    }
                    Console.Write("{0} ", element.Value);
                }
                Console.WriteLine();
            }
        }

        struct Element
        {
            public int Value;
            public int Row;
            public int Col;
        }
    }
}
