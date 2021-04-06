using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace двумерный_массив
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int m = rand.Next(2, 7);
            int n = rand.Next(2, 7);
            int[,] mass = new int[m, n];
            FillArray(mass);
            ShowArray(mass);
            Console.WriteLine("Your minimum element= " + FindMin(mass));
            Console.WriteLine("Your maximum element= " + FindMax(mass));
            Console.WriteLine("The amount of elements bigger than their neighbours = " + CountNeighbours(mass));
        }

        private static int CountNeighbours(int[,] arr)
        {
            int count = 0;
            int row = arr.GetLength(0);
            int column = arr.GetLength(1);
            if (arr[0, 0] > arr[0, 1])
                count++;
            if (arr[row - 1, column - 1] > arr[row - 1, column - 2])
                count++;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (i == 0 && j == 0)
                        continue;
                    if (i == row - 1 && j == column - 1)
                        break;

                    if (j == column - 1)
                    {
                        if (arr[i, j] > arr[i + 1, 0] && arr[i, j] > arr[i, j - 1])
                        {
                            count++;
                        }
                    }
                    else if (j == 0)
                    {
                        if (arr[i, j] > arr[i - 1, column - 1] && arr[i, j] > arr[i, j + 1])
                        {
                            count++;
                        }
                    }
                    else if (arr[i, j] > arr[i, j + 1] && arr[i, j] > arr[i, j - 1])
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        private static void FillArray(Array arr)
        {

            Random ran = new Random();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    arr.SetValue(ran.Next(1, 99), i, j);
            }

        }
        private static void ShowArray(int[,] arr)
        {

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }

        }
        private static int FindMin(int[,] arr)
        {
            int min_elem = arr[0, 0];
            int index_min_i = 0;
            int index_min_j = 0;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] < min_elem)
                    {
                        min_elem = arr[i, j];
                        index_min_i = i;
                        index_min_j = j;
                    }
                }
            }
            Console.WriteLine("\n\nIndex of your minimum element= [" + index_min_i + "," + index_min_j + "]");
            return min_elem;
        }

        private static int FindMax(int[,] arr)
        {
            int max_elem = arr[0, 0];
            int index_max_i = 0;
            int index_max_j = 0;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] > max_elem)
                    {
                        max_elem = arr[i, j];
                        index_max_i = i;
                        index_max_j = j;
                    }
                }
            }
            Console.WriteLine("\n\nIndex of your minimum element= [" + index_max_i + "," + index_max_j + "]");
            return max_elem;
        }
    }
}
