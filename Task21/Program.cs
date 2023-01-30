using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task21
{
    internal class Program
    {
        private const int m = 5;
        private const int n = 4;

        private static int[,] field = new int[m, n] { { 1, 2, 3 ,5}, { 3, 2, 30 ,5}, { 0, 5, 1 ,3}, { 3, 6, 3 ,15}, { 4, 10, 2 ,11} };
        
        static void Main(string[] args)
        {
            ThreadStart threadstart = new ThreadStart(Gardener1);
            Thread thread = new Thread(threadstart);
            thread.Start();

            Gardener2();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{field[i, j]}");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        static void Gardener1()
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (field[i,j] >= 0)
                    {
                        int delay = field[i, j];
                        field[i, j] = -1;
                        Thread.Sleep(delay);
                    }
                }
            }
        }
        static void Gardener2()
        {
            for (int j = n-1; j >= 0; j--)
            {
                for (int i = m-1; i >= 0; i--)
                {
                    if (field[i, j] >= 0)
                    {
                        int delay = field[i, j];
                        field[i, j] = -2;
                        Thread.Sleep(delay);
                    }
                }
            }
        }
    }

}
