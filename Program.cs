using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUOI1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Nhập vào một dãy n số
            double[] A = new double[100];
            Console.Write("Nhap vao n:");
            int n = Convert.ToInt32(Console.ReadLine());
            double Tong = 0;
            for (int i = 0; i < n; i++)
            {
                Console.Write("A[" + i + "]=");
                A[i] = Convert.ToDouble(Console.ReadLine());
                Tong = Tong + A[i];
            }

            // In hình tam giác vuông
            Console.WriteLine("Day so vua nhap vao");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(A[j] + " ");

                }
                Console.WriteLine();
            }

            // In hình cây thông
            Console.WriteLine("Day so vua nhap vao");
            for (int i = 0; i < n; i++)
            {
                // In khoảng trắng để căn giữa
                for (int j = 0; j < n - i - 1; j++)
                {
                    Console.Write(" ");
                }

                // In các phần tử của mảng
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(A[j] + " ");
                }

                Console.WriteLine();
            }
            Console.WriteLine("Tong day so vua nhap = " + Tong);
            Console.ReadLine();

        }
    }
}
