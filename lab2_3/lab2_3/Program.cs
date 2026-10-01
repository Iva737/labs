using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, world!");
            //Console.ReadKey();
            //Console.ReadLine();
            //int input = Int32.Parse(Console.ReadLine());
            //Console.WriteLine("Введеное число: {0}", input);
            //string[] mounth = {"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"};
            /*
            string str = Console.ReadLine();
            string[] array = str.Split(' ');
            for(int i=0; i<2; i++)
            {
                Console.WriteLine(array[i]);
            }


            */

            string quest = "53. Даны натуральные числа n, a1, a2, ... an. Найти те члены ai, последовательности a1, a2, ... an , которые больше a[i-2]\n";
            string input;
            while (true)
            {
                Console.Write("Введите n: ");
                input = Console.ReadLine().ToLower();
                if (input == "exit")
                {
                    break;
                }
                else if (input == "?")
                {
                    Console.Write(quest);
                }

                UInt32 n = UInt32.Parse(input);
                UInt64 a = 0; //мини буфер
                bool isError = false; //есть ли ошибка
                bool isExit = false; //выход
                string output = "Ответ: "; // зачаток выходного текста

                if (n <= 0)
                {
                    Console.WriteLine("Неверный ввод. Число n должно быть натуральным\n");
                    continue;
                }

                for (uint i = 0; i++ < n;) //от 1, до n
                {
                    Console.Write("Введите a{0}: ", i);

                    input = Console.ReadLine().ToLower();
                    if (input == "exit")
                    {
                        isExit = true;
                        break;
                    } else if (input == "?")
                    {
                        Console.Write(quest);
                    }
                    UInt64 inp = UInt32.Parse(input);
                    if (inp <= 0)
                    {
                        Console.WriteLine("Неверный ввод. Число a{0} должно быть натуральным\n", i);
                        isError = true;
                        break;
                    }

                    if (i >= 3 && ((a >> 32) < inp)) //проверяем существование элемента и сравниваем a(n-2) и a(n)
                    {
                        output += $"{inp} ";
                    }

                    a = (a << 32) | inp; //записываем введенное число в буфер
                }

                if (isExit)
                {
                    break;
                }

                if (!isError) //только без ошибок
                {
                    Console.WriteLine(output);
                    Console.WriteLine();
                }
            }
        }
    }
}