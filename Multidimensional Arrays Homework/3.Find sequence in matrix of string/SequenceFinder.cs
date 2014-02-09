using System;

namespace _3.Find_sequence_in_matrix_of_string
{
    //We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several neighbor elements located on the same line,
    //column or diagonal. Write a program that finds the longest sequence of equal strings in the matrix.
    class SequenceFinder
    {
        static void Main(string[] args)
        {
            Directions direction = Directions.Vertical;
            string[,] matrix = 
            {
                {"ha", "fifi", "ho", "hi"},
                {"fo", "ha", "hi", "xx"},
                {"xxx", "ho", "ha", "xx"},
                
            };

            int maxSequenceLength = 1;
            int firstSequenceElementCol = 0;
            int firstSequenceElementRow = 0;
            CheckRows(matrix, ref maxSequenceLength, ref firstSequenceElementRow, ref firstSequenceElementCol, ref direction);
            CheckCols(matrix, ref maxSequenceLength, ref firstSequenceElementRow, ref firstSequenceElementCol, ref direction);
            CheckDiagonals(matrix, ref maxSequenceLength, ref firstSequenceElementRow, ref firstSequenceElementCol, ref direction);

            PrintResult(matrix, maxSequenceLength, firstSequenceElementRow, firstSequenceElementCol, direction);
        }

        static void PrintResult(string[,] matrix, int maxSequenceLength, int firstSequenceElementRow, int firstSequenceElementCol, Directions direction)
        {
            string uppercaseValue = matrix[firstSequenceElementRow, firstSequenceElementCol].ToUpper();
            if (direction == Directions.DiagonalTopToBottom)
            {
                for (int i = 0; i < maxSequenceLength; i++)
                {
                    matrix[firstSequenceElementRow + i, firstSequenceElementCol + i] = uppercaseValue;
                }
            }
            else if (direction == Directions.DiagonalBottomToTop)
            {
                for (int i = 0; i < maxSequenceLength; i++)
                {
                    matrix[firstSequenceElementRow - i, firstSequenceElementCol + i] = uppercaseValue;
                }
            }
            else if (direction == Directions.Horizontal)
            {
                for (int i = 0; i < maxSequenceLength; i++)
                {
                    matrix[firstSequenceElementRow, firstSequenceElementCol + i] = uppercaseValue;
                }
            }
            else if (direction == Directions.Vertical)
            {
                for (int i = 0; i < maxSequenceLength; i++)
                {
                    matrix[firstSequenceElementRow + i, firstSequenceElementCol] = uppercaseValue;
                }
            }


            //Print
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0} ", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        static void CheckRows(string[,] inputMatrix, ref int maxSequenceLength, ref int firstSequenceElementRow, ref int firstSequenceElementCol, ref Directions direction)
        {
            int currentSequenceLength = 1;
            int currentFirstSequenceElementRow = 0;
            int currentFirstSequenceElementCol = 0;

            for (int row = 1; row < inputMatrix.GetLength(0); row++)
            {
                for (int col = 1; col < inputMatrix.GetLength(1); col++)
                {
                    bool foundLongestSequence =
                    CheckForSequence(inputMatrix, maxSequenceLength, ref currentSequenceLength, ref currentFirstSequenceElementRow, ref currentFirstSequenceElementCol, row, col, Directions.Horizontal);

                    if (foundLongestSequence)
                    {
                        maxSequenceLength = currentSequenceLength;
                        firstSequenceElementRow = currentFirstSequenceElementRow;
                        firstSequenceElementCol = currentFirstSequenceElementCol;
                        direction = Directions.Horizontal;
                    }
                }
            }
        }

        static void CheckCols(string[,] inputMatrix, ref int maxSequenceLength, ref int firstSequenceElementRow, ref int firstSequenceElementCol, ref Directions direction)
        {
            int currentSequenceLength = 1;
            int currentFirstSequenceElementRow = 0;
            int currentFirstSequenceElementCol = 0;

            for (int col = 1; col < inputMatrix.GetLength(1); col++)
            {
                for (int row = 1; row < inputMatrix.GetLength(0); row++)
                {
                    bool foundLongestSequence =
                    CheckForSequence(inputMatrix, maxSequenceLength, ref currentSequenceLength, ref currentFirstSequenceElementRow, ref currentFirstSequenceElementCol, row, col, Directions.Vertical);

                    if (foundLongestSequence)
                    {
                        maxSequenceLength = currentSequenceLength;
                        firstSequenceElementRow = currentFirstSequenceElementRow;
                        firstSequenceElementCol = currentFirstSequenceElementCol;
                        direction = Directions.Vertical;
                    }
                }
            }
        }

        static void CheckDiagonals(string[,] inputMatrix, ref int maxSequenceLength, ref int firstSequenceElementRow, ref int firstSequenceElementCol, ref Directions direction)
        {
            int currentSequenceLength = 1;
            int currentFirstSequenceElementRow = 0;
            int currentFirstSequenceElementCol = 0;

            #region Left to right diagonals
            for (int row = inputMatrix.GetLength(0) - 1 - maxSequenceLength; row >= 0; row--) //We add "- maxSequenceLength" because it is pointless to check diagonals shorter than our sequence
            {
                for (int currentRow = row + 1, currentCol = 1; currentRow < inputMatrix.GetLength(0) && currentCol < inputMatrix.GetLength(1); currentRow++, currentCol++)
                {
                    bool foundLongestSequence =
                    CheckForSequence(inputMatrix, maxSequenceLength, ref currentSequenceLength, ref currentFirstSequenceElementRow, ref currentFirstSequenceElementCol, currentRow, currentCol, Directions.DiagonalTopToBottom);

                    if (foundLongestSequence)
                    {
                        maxSequenceLength = currentSequenceLength;
                        firstSequenceElementRow = currentFirstSequenceElementRow;
                        firstSequenceElementCol = currentFirstSequenceElementCol;
                        direction = Directions.DiagonalTopToBottom;
                    }
                }
            }

            //check upper diagonals
            for (int col = 1; col < inputMatrix.GetLength(1) - 1 - maxSequenceLength; col++)
            {
                for (int currentRow = 1, currentCol = col + 1; currentRow < inputMatrix.GetLength(0) && currentCol < inputMatrix.GetLength(1); currentRow++, currentCol++)
                {
                    bool foundLongestSequence = 
                    CheckForSequence(inputMatrix, maxSequenceLength, ref currentSequenceLength, ref currentFirstSequenceElementRow, ref currentFirstSequenceElementCol, currentRow, currentCol, Directions.DiagonalTopToBottom);
                    
                    if (foundLongestSequence)
                    {
                        maxSequenceLength = currentSequenceLength;
                        firstSequenceElementRow = currentFirstSequenceElementRow;
                        firstSequenceElementCol = currentFirstSequenceElementCol;
                        direction = Directions.DiagonalTopToBottom;
                    }
                }
            }
            #endregion

            #region Right to left diagonals
            for (int row = maxSequenceLength; row < inputMatrix.GetLength(0); row++)
            {
                for (int currentRow = row - 1, currentCol = 1; currentRow >= 0 && currentCol < inputMatrix.GetLength(1); currentRow--, currentCol++)
                {
                    bool foundLongestSequence =
                    CheckForSequence(inputMatrix, maxSequenceLength, ref currentSequenceLength, ref currentFirstSequenceElementRow, ref currentFirstSequenceElementCol, currentRow, currentCol, Directions.DiagonalBottomToTop);

                    if (foundLongestSequence)
                    {
                        maxSequenceLength = currentSequenceLength;
                        firstSequenceElementRow = currentFirstSequenceElementRow;
                        firstSequenceElementCol = currentFirstSequenceElementCol;
                        direction = Directions.DiagonalBottomToTop;
                    }
                }
            }

            //check down diagonals
            for (int col = 1; col < inputMatrix.GetLength(1) - 1 - maxSequenceLength; col++)
            {
                for (int currentRow = inputMatrix.GetLength(0) - 2, currentCol = col + 1; currentRow > 0 && currentCol < inputMatrix.GetLength(1); currentRow--, currentCol++)
                {
                    bool foundLongestSequence =
                    CheckForSequence(inputMatrix, maxSequenceLength, ref currentSequenceLength, ref currentFirstSequenceElementRow, ref currentFirstSequenceElementCol, currentRow, currentCol, Directions.DiagonalBottomToTop);

                    if (foundLongestSequence)
                    {
                        maxSequenceLength = currentSequenceLength;
                        firstSequenceElementRow = currentFirstSequenceElementRow;
                        firstSequenceElementCol = currentFirstSequenceElementCol;
                        direction = Directions.DiagonalBottomToTop;
                    }
                }
            }
            #endregion
        }

        private static bool CheckForSequence(string[,] inputMatrix, int maxSequenceLength, ref int currentSequenceLength, ref int currentFirstSequenceElementRow, ref int currentFirstSequenceElementCol, int currentRow, int currentCol, Directions direction)
        {
            string previousValue = string.Empty;
            int previousValueRow = 0;
            int previousValueCol = 0;
            switch(direction)
            {
                case Directions.DiagonalTopToBottom:
                    previousValueRow = currentRow - 1;
                    previousValueCol = currentCol - 1;
                    previousValue = inputMatrix[previousValueRow, previousValueCol]; break;
                case Directions.DiagonalBottomToTop:
                    previousValueRow = currentRow + 1;
                    previousValueCol = currentCol - 1;
                    previousValue = inputMatrix[currentRow + 1, currentCol - 1]; break;
                case Directions.Horizontal:
                    previousValueRow = currentRow;
                    previousValueCol = currentCol - 1;
                    previousValue = inputMatrix[currentRow, currentCol - 1]; break;
                case Directions.Vertical:
                    previousValueRow = currentRow - 1;
                    previousValueCol = currentCol;
                    previousValue = inputMatrix[currentRow - 1, currentCol]; break;
            }
            if (inputMatrix[currentRow, currentCol] == previousValue)
            {
                if (currentSequenceLength == 1) //If we just have found sequence, lets save the first element position
                {
                    currentFirstSequenceElementRow = previousValueRow;
                    currentFirstSequenceElementCol = previousValueCol;
                }
                currentSequenceLength++;
                if (currentSequenceLength > maxSequenceLength) //If we just have found longest sequence
                {
                    return true;
                }
            }
            else
            {
                currentSequenceLength = 1;
            }
            return false;
        }

        enum Directions
        {
            Horizontal, Vertical, DiagonalTopToBottom, DiagonalBottomToTop
        }
    }
}
