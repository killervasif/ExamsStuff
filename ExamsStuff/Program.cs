using System;
class Program
{
    //asagidaki 2 funksiyani bir nece sualda isledirem
    static void FillMatrixWithRandomNumbers(int[,] matrix, int minValue, int maxValue)
    {
        Random rand = new Random();
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = rand.Next(minValue, maxValue + 1);
            }
        }
    }
    static void PrintMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }


    //sual 1: x[n][m] de ilk 2 menfi ededin mesafesini tap
    static int? FindDifferenceBetweenFirstTwoNegatives(int[,] matrix)
    {
        int n = matrix.GetLength(0); // number of rows
        int m = matrix.GetLength(1); // number of columns

        int firstValue = int.MaxValue;
        int secondValue = int.MaxValue;

        bool firstFound = false;
        bool secondFound = false;

        // Traverse the matrix to find the first two negative numbers
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matrix[i, j] < 0)
                {
                    if (!firstFound)
                    {
                        firstValue = matrix[i, j];
                        firstFound = true;
                    }
                    else if (!secondFound)
                    {
                        secondValue = matrix[i, j];
                        secondFound = true;
                        return Math.Abs(secondValue - firstValue);
                    }
                }
            }
        }

        // If we reached here, it means there are less than two negative numbers
        return null;
    }

    //sual 2: x[n][m] de menfi ededler olan siradaki minimum elementi tap
    static List<int> FindMinElementsInNegativeRows(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        List<int> minElements = new List<int>();

        for (int i = 0; i < n; i++)
        {
            bool allNegative = true;
            for (int j = 0; j < m; j++)
            {
                if (matrix[i, j] >= 0)
                {
                    allNegative = false;
                    break;
                }
            }

            if (allNegative)
            {
                int minElement = int.MaxValue;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < minElement)
                    {
                        minElement = matrix[i, j];
                    }
                }
                minElements.Add(minElement);
            }
        }

        return minElements;
    }

    //sual 3 x[n][m] de ilk ve son eded arasindaki mesafeni tap
    static int FindDifferenceBetweenFirstAndLastNumbers(int[,] matrix)
    {
        int n = matrix.GetLength(0); // number of rows
        int m = matrix.GetLength(1); // number of columns

        int firstValue = matrix[0, 0];
        int lastValue = matrix[n - 1, m - 1];

        return Math.Abs(lastValue - firstValue);
    }


    static void Main()
    {

        /*{
            //1. sual
            Console.Write("Enter the number of rows (n): ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of columns (m): ");
            int m = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, m];

            FillMatrixWithRandomNumbers(matrix, -10, 10);

            Console.WriteLine("Matrix filled with random numbers between -10 and 10:");
            PrintMatrix(matrix);

            // Find the difference between the first two negative numbers
            int? difference = FindDifferenceBetweenFirstTwoNegatives(matrix);
            if (difference != null)
            {
                Console.WriteLine($"Difference between the first two negative numbers: {difference}");
            }
            else
            {
                Console.WriteLine("Less than two negative numbers found in the matrix.");
            }
        }*/

        /*{
            //2. sual
            Console.Write("Enter the number of rows (n): ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of columns (m): ");
            int m = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, m];

            FillMatrixWithRandomNumbers(matrix, -10, 10);//musbet 10u isteyirsizse asagi yazin yoxsa menfi setir cox az cixir

            Console.WriteLine("Matrix filled with random numbers between -10 and 10:");
            PrintMatrix(matrix);

            // Find the minimum element in rows that have only negative numbers
            List<int> minElements = FindMinElementsInNegativeRows(matrix);
            if (minElements.Count > 0)
            {
                Console.WriteLine("Minimum elements in rows that have only negative numbers:");
                foreach (var minElement in minElements)
                {
                    Console.WriteLine(minElement);
                }
            }
            else
            {
                Console.WriteLine("No rows with only negative numbers found.");
            }

        }*/

        /*{
            //3. sual
            Console.Write("Enter the number of rows (n): ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of columns (m): ");
            int m = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, m];

            FillMatrixWithRandomNumbers(matrix, -10, 10);

            Console.WriteLine("Matrix filled with random numbers between -10 and 10:");
            PrintMatrix(matrix);

            // Find the difference between the first and last numbers
            int difference = FindDifferenceBetweenFirstAndLastNumbers(matrix);
            Console.WriteLine($"Difference between the first and last numbers: {difference}");
        }*/



    }
}
