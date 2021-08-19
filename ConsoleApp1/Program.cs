using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
 Вычислить произведение матриц А и B. Входные данные: произвольные
квадратные матрицы А и В одинаковой размерности. Решить задачу
двумя способами: 1) количество потоков является входным параметром, при
этом размерность матриц может быть не кратна количеству потоков; 2) количество
потоков заранее неизвестно и не является параметром задачи.  
*/
namespace ConsoleApp1
{
    class Program
    {
        // const int n = 2; // 
       // static int[,] *A = new int[];

        static void Main(string[] args)
        {
            Console.Write("Введите размерность матирицы: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int m = n;

            Console.WriteLine("");
            int[,] A = new int[n, m];
            Random rn = new Random();
            Console.WriteLine("Матрица А: ");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    A[i, j] = rn.Next(11) - 5;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(String.Format("{0,3}", A[i, j]));
                Console.WriteLine();
            }

            int x = n;
            int y = n;
            int[,] B = new int[x, y];
            Console.WriteLine("");
            Console.WriteLine("Матрица В: ");
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    B[i, j] = rn.Next(11) - 5;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                    Console.Write(String.Format("{0,3}", B[i, j]));
                Console.WriteLine();
            }

            Console.WriteLine("");

            // создаем новый поток
            Thread myThread = new Thread(new ThreadStart(Count));
            myThread.Start(); // запускаем поток

            int a = n;
            int b = n;
            int[,] C = new int[a, b];
            Console.WriteLine("");
            Console.WriteLine("Матрица C: ");
            // for (int i = 0; i < a; i++)
            //   for (int j = 0; j < b; j++)
            //       C[i, j] = rn.Next(11) - 5;

            if (n == 2) {
                C[0, 0] = A[0,0] * B[0, 0] + A[0, 1] * B[1, 0];
                C[0, 1] = A[0, 0] * B[0, 1] + A[0, 1] * B[1, 1];
                C[1, 0] = A[1, 0] * B[0, 0] + A[1, 1] * B[1, 0];
                C[1, 1] = A[1, 0] * B[0,1] + A[1, 1] * B[1, 1];
            }

            if (n == 3)
            {
                C[0, 0] = A[0, 0] * B[0, 0] + A[0, 1] * B[1, 0] + A[0, 2] * B[2, 0];
                C[0, 1] = A[0, 1] * B[0, 1] + A[0, 1] * B[1, 1] + A[0, 2] * B[2, 1];
                C[0, 2] = A[0, 2] * B[0, 2] + A[0, 1] * B[1, 2] + A[0, 2] * B[2, 2];
                C[1, 0] = A[1, 0] * B[0, 0] + A[1, 1] * B[1, 0] + A[1, 2] * B[2, 0];
                C[1, 1] = A[1, 1] * B[0, 1] + A[1, 1] * B[1, 1] + A[1, 2] * B[2, 1];
                C[1, 2] = A[1, 2] * B[0, 2] + A[1, 1] * B[1, 2] + A[1, 2] * B[2, 2];
                C[2, 0] = A[2, 0] * B[0, 0] + A[2, 1] * B[1, 0] + A[2, 2] * B[2, 0];
                C[2, 1] = A[2, 1] * B[0, 1] + A[2, 1] * B[1, 1] + A[2, 2] * B[2, 1];
                C[2, 2] = A[2, 2] * B[0, 2] + A[2, 1] * B[1, 2] + A[2, 2] * B[2, 2];
            }

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                    Console.Write(String.Format("{0,3}", C[i, j]));
                Console.WriteLine();
            }


            Console.ReadLine();

             for (int i = 0; i < n; i++)
            {
                a += b;
                if (a % 2 == 0)
                {
                    Console.WriteLine("Главный поток:");
                    Console.WriteLine(sum + a);
                    // Thread.Sleep(200);
                }
            }
            Console.ReadLine(); 
        }

        public static void Count()
        {

        }
    }
}
