using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ввод символа
            Console.Write("Введите n (длина ряда): ");
            Int32 n = Int32.Parse(Console.ReadLine());
            if (n <= 0)
            {
                Console.WriteLine("Неверный ввод");
                return;
            }

            //Ввод последовательности
            Console.Write("Введите последовательность (через пробел):\n\n> ");
            String[] temp = Console.ReadLine().Split(' ');
            Int32[] a = new Int32[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                a[i] = Int32.Parse(temp[i]);
            }

            //Обрабатываем массив
            bool isChet = a[0] % 2 == 0; //предыдущий чет нечет
            bool isSign = true; //знак чисел для вывода (-true +false)
            for(int i = 1; i < a.Length; i++)
            {
                if (!isChet && (a[i]%2==0)) //условие для переключения на положительные числа
                {
                    isSign = false;
                    break;
                } else
                {
                    isChet = a[i] % 2 == 0;
                }
            }

            //Выводим результат
            Console.WriteLine("\n\nРезультатъ:");
            for (int i = a.Length-1; i >=0; i--)
            {
                if (((a[i]>0) ^ isSign) && a[i]!=0) //выводим числа нужного знака (ноль не имеет знака)
                    Console.Write("{0} ", a[i]);
            }
        }
    }
}
