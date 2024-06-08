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

    //4. sual M[n][m] de cemi max olan sutun elementlerini capa cixarma (evvelden yazmisdim birbasa yazdim asagida)

    //5. sual A[n][m] in sehirli kvadrat olmagini yoxla (setirler sutunlar diaqonallar cemi beraber olanda olur)
    static bool IsMagicSquare(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        // Check if it's a square matrix
        if (n != m)
            return false;

        // Calculate the sum of the first row
        int sum = 0;
        for (int j = 0; j < m; j++)
            sum += matrix[0, j];

        // Check rows
        for (int i = 1; i < n; i++)
        {
            int rowSum = 0;
            for (int j = 0; j < m; j++)
                rowSum += matrix[i, j];

            if (rowSum != sum)
                return false;
        }

        // Check columns
        for (int j = 0; j < m; j++)
        {
            int colSum = 0;
            for (int i = 0; i < n; i++)
                colSum += matrix[i, j];

            if (colSum != sum)
                return false;
        }

        // Check main diagonal
        int diagSum1 = 0;
        for (int i = 0; i < n; i++)
            diagSum1 += matrix[i, i];
        if (diagSum1 != sum)
            return false;

        // Check secondary diagonal
        int diagSum2 = 0;
        for (int i = 0; i < n; i++)
            diagSum2 += matrix[i, n - i - 1];
        if (diagSum2 != sum)
            return false;

        return true;
    }

    //6. sual M[n][m] de min ve max elementi nezere almadan massivin ortalamasini tap
    static double AverageWithoutMinMax(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        // Find min and max values
        int min = int.MaxValue;
        int max = int.MinValue;
        foreach (int element in matrix)
        {
            if (element < min)
                min = element;
            if (element > max)
                max = element;
        }

        // Calculate sum and count, excluding min and max values
        double sum = 0;
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int current = matrix[i, j];
                if (current != min && current != max)
                {
                    sum += current;
                    count++;
                }
            }
        }

        // Calculate average
        if (count == 0)
            return 0; // to avoid division by zero
        return sum / count;
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

        /*{
            //4. sual
            int n = 0;
            int[,] M = new int[5, 5];
            int sum = 0;

            // Fill the matrix
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    M[i, j] = new Random().Next(1, 10);
                    Console.Write(M[i, j] + "\t"); // Print matrix elements
                }
                Console.WriteLine();
            }

            // Find the column with the highest sum
            for (int j = 0; j < 5; j++)
            {
                int colSum = 0;
                for (int i = 0; i < 5; i++)
                {
                    colSum += M[i, j];
                }

                if (colSum > sum)
                {
                    sum = colSum;
                    n = j;
                }
            }

            // Print the column with the highest sum and its sum
            Console.WriteLine();
            Console.WriteLine($"Column with the highest sum is column {n + 1}:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(M[i, n]);
            }
            Console.WriteLine("Sum of the column with the highest sum: " + sum);
        }*/

        /*{
            //5. sual
            int n = 5; // Change the dimensions of the matrix as needed
            int[,] matrix = new int[n, n];

            FillMatrixWithRandomNumbers(matrix, 1, 9);

            Console.WriteLine("Generated Matrix:");
            PrintMatrix(matrix);

            if (IsMagicSquare(matrix))
                Console.WriteLine("It's a magic square.");
            else
                Console.WriteLine("It's not a magic square.");
        }*/

        /*{
            //6.sual
            int n = 3; // Change the dimensions of the matrix as needed
            int m = 3;
            int[,] matrix = new int[n, m];

            // Fill matrix with random numbers between 1 and 100
            FillMatrixWithRandomNumbers(matrix, 1, 100);

            Console.WriteLine("Generated Matrix:");
            PrintMatrix(matrix);

            double average = AverageWithoutMinMax(matrix);
            Console.WriteLine($"Average without considering min and max: {average:F2}");//:F2 noqteden sonra 2 reqem olsun deyedi yazmasaz da olar
        }*/
    }
}
