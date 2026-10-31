using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Дан целочисленный массив размера N. Прекобразовать массив, увеличив его
предпоследнюю серию наименьшей длины на один элемент. Если такову найти нельзя
, то оставить массив без изменения.
*/
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
            int[] b; //результирующий массив
            int lenMin = a.Length; //Минимально найденная длина
            int len = 1; //Текущая длина
            int index = -1; //Индекс первого элемента предпоследней серии
            int col = 0; //Количество найденный серий минимальной длины
            int elem = a[a.Length-1]; //последний элемент

            for(int i = a.Length-2; i >= 0; i--)
            {
                if (a[i] == elem)
                {
                    len++;
                } else
                {
                    if(len < lenMin)
                    {
                        lenMin = len;
                        col = 1;
                        index = -1;
                    } else if (len == lenMin)
                    {
                        col++;
                        if (col == 2)
                            index = i + 1;
                    }
                    elem = a[i];
                    len = 1;
                }
            }
            if (len < lenMin)
            {
                index = -1;
            }
            else if (len == lenMin && col == 1)
            {
                index = 0;
            }

            Console.WriteLine("leMin={0} index={1} col={2}", lenMin, index, col);
            if (index!=-1)
            {
                b = new int[a.Length + 1]; //результирующий массив
                b[index] = a[index]; // добавляем элемент
                for (int i = 0; i < index; i++) //добавляем остальное
                {
                    b[i] = a[i];
                }
                for (int i = index; i < a.Length; i++)
                {
                    b[i+1] = a[i];
                }
            } else
            {
                b = a;
            }




            Console.WriteLine("\n\nРезультатъ:");
            for (int i = 0; i < b.Length; i++)
            {
                Console.Write("{0} ", b[i]);
            }
        }
    }
}
