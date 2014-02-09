using System;
using System.Text;

namespace _6.Matrix_class
{
    /*Write a class Matrix, to holds a matrix of integers. 
     * Overload the operators for adding, subtracting and multiplying of matrices,
     * indexer for accessing the matrix content and ToString()
     */
    public class Matrix
    {
        private int[,] matrix;

        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public Matrix(int rows, int columns)
        {
            this.matrix = new int[rows, columns];
            this.Rows = rows;
            this.Columns = columns;
        }

        public int this[int row, int col]
        {
            get { return this.matrix[row, col]; }
            set { this.matrix[row, col] = value; }
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
            {
                throw new ArithmeticException("Rows and columns of both matrixes must be equal!");
            }

            Matrix result = new Matrix(m1.Rows, m1.Columns);
            for (int row = 0; row < m1.Rows; row++)
            {
                for (int col = 0; col < m1.Columns; col++)
                {
                    result[row, col] = m1[row, col] + m2[row, col];
                }
            }

            return result;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
            {
                throw new ArithmeticException("Rows and columns of both matrixes must be equal!");
            }

            Matrix result = new Matrix(m1.Rows, m1.Columns);
            for (int row = 0; row < m1.Rows; row++)
            {
                for (int col = 0; col < m1.Columns; col++)
                {
                    result[row, col] = m1[row, col] - m2[row, col];
                }
            }

            return result;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            Matrix result = new Matrix(m1.Rows, m2.Columns);

            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m2.Columns; j++)
                {
                    result[i,j] = 0;
                    for (int k = 0; k < m2.Columns; k++)
                    {
                        result[i,j] = result[i,j] + m1[i,k] * m2[k,j];
                    }
                }
            }

            return result;
        }

        public override String ToString()
        {
            StringBuilder matrixAsString = new StringBuilder();
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Columns; col++)
                {
                    matrixAsString.Append(this.matrix[row, col]);
                    if (col < this.Columns - 1)
                    {
                        matrixAsString.Append(",");
                    }
                }
                matrixAsString.Append(System.Environment.NewLine);
            }

            return matrixAsString.ToString();
        }
    }
}
