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

    //7. sual M[n][m] de min ve max element arasindaki elementlerin hasilini tap (duz islemir amma cetin kimse run eleye bunlari yaza yaza burda ne gedir orda ne bas verir izah edin getsin
    static int[] FlattenArray(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[] flattenedArray = new int[rows * cols];
        int index = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                flattenedArray[index++] = matrix[i, j];
            }
        }

        return flattenedArray;
    }

    static void FindMinAndMaxIndices(int[] array, out int minIndex, out int maxIndex)
    {
        minIndex = 0;
        maxIndex = 0;
        int min = array[0];
        int max = array[0];

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
                minIndex = i;
            }
            else if (array[i] > max)
            {
                max = array[i];
                maxIndex = i;
            }
        }
    }

    static int MultiplyInRange(int[] array, int minIndex, int maxIndex)
    {
        int product = 1;
        int start = Math.Min(minIndex, maxIndex);
        int end = Math.Max(minIndex, maxIndex);

        for (int i = start + 1; i < end; i++)
        {
            product *= array[i];
        }

        return product;
    }

    //8. sual X[n][m] de yeher noqtesini tapma (setrde min sutunda max olanda olur
    static void FindSaddlePoints(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            // Find the minimum value in the row
            int minVal = int.MaxValue;
            int minIndex = -1;
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] < minVal)
                {
                    minVal = matrix[i, j];
                    minIndex = j;
                }
            }

            // Check if the minimum value is also the maximum in its column
            bool isSaddlePoint = true;
            for (int k = 0; k < rows; k++)
            {
                if (matrix[k, minIndex] > minVal)
                {
                    isSaddlePoint = false;
                    break;
                }
            }

            if (isSaddlePoint)
            {
                Console.WriteLine("Saddle point found at: (" + i + ", " + minIndex + ")");
            }
            else
            {
                Console.WriteLine("No saddle points found");
            }
        }
    }

    //9. sual X[n][m] de artmayan ardicil 3 reqemi tapin
    static void FindNonIncreasingConsecutiveNumbers(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols - 2; j++)
            {
                // Check if three consecutive numbers in the same row are not increasing
                if (matrix[i, j] >= matrix[i, j + 1] && matrix[i, j + 1] >= matrix[i, j + 2])
                {
                    Console.WriteLine("Non-increasing consecutive numbers found in row " + i + ": (" + matrix[i, j] + ", " + matrix[i, j + 1] + ", " + matrix[i, j + 2] + ")");
                }
            }
        }

        for (int j = 0; j < cols; j++)
        {
            for (int i = 0; i < rows - 2; i++)
            {
                // Check if three consecutive numbers in the same column are not increasing
                if (matrix[i, j] >= matrix[i + 1, j] && matrix[i + 1, j] >= matrix[i + 2, j])
                {
                    Console.WriteLine("Non-increasing consecutive numbers found in column " + j + ": (" + matrix[i, j] + ", " + matrix[i + 1, j] + ", " + matrix[i + 2, j] + ")");
                }
            }
        }
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

        /*{
            //7. sual
            int n = 5; // Number of rows
            int m = 5; // Number of columns
            int[,] matrix = new int[n, m];

            FillMatrixWithRandomNumbers(matrix, 1, 10); // Fill matrix with random numbers between 1 and 10
            Console.WriteLine("Randomly generated matrix:");
            PrintMatrix(matrix); // Print the generated matrix

            int[] flattenedArray = FlattenArray(matrix);
            int minIndex, maxIndex;
            FindMinAndMaxIndices(flattenedArray, out minIndex, out maxIndex);

            int product = MultiplyInRange(flattenedArray, minIndex, maxIndex);

            Console.WriteLine("The product of numbers between the first instance of the min and max numbers is: " + product);
        }*/

        /*{
            //sual 8
            int n = 3; // Number of rows
            int m = 3; // Number of columns
            int[,] matrix = new int[n, m];

            FillMatrixWithRandomNumbers(matrix, 1, 10); // Fill matrix with random numbers between 1 and 10
            Console.WriteLine("Randomly generated matrix:");
            PrintMatrix(matrix); // Print the generated matrix

            FindSaddlePoints(matrix); // Find saddle points in the matrix
        }*/

        /*{
            //sual 9
            int n = 5; // Number of rows
            int m = 5; // Number of columns
            int[,] matrix = new int[n, m];

            FillMatrixWithRandomNumbers(matrix, 1, 10); // Fill matrix with random numbers between 1 and 10
            Console.WriteLine("Randomly generated matrix:");
            PrintMatrix(matrix); // Print the generated matrix

            FindNonIncreasingConsecutiveNumbers(matrix); // Find non-increasing consecutive numbers in the matrix
        }*/
    }
}
