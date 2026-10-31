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
            int index = 0; //индекс последнего свободного элемента в стеке
            for (int i = 0; i < a.Length; i++)
            {
                bool isNew = true; //флаг новый ли элемент
                for (int j = 0; j < index; j++)
                {
                    if (a[i] == a[j])
                    {
                        isNew = false;
                    }
                }
                if (isNew)
                {
                    a[index] = a[i];
                    index++;
                }
            }

            //Выводим результат
            Console.WriteLine("\n\nРезультатъ:");
            for (int i = 0; i < index; i++)
            {
                Console.Write("{0} ", a[i]);
            }
        }
    }
}
