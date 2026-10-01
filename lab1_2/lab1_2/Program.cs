using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Лабораторная 1_2
            
            while (true) //бескн. для удоства тестирования
            {
                double a_now, a_last = 0; //первый и ывторой элемент a
                uint output = 0;
                bool sign;

                Console.Write("Введите n: ");
                UInt32 n = UInt32.Parse(Console.ReadLine());

                if(n <= 0) //проверяем на существование в множестве нат.чисел 1,2,3,4,5,6 ...
                {
                    Console.WriteLine("Неверный ввод. Число n должно быть натуральным");
                    continue;
                }

                for (uint i=0; i++ < n;) //от 1 до n
                {
                    Console.Write("Введите a{0}: ", i);
                    a_now = double.Parse(Console.ReadLine()); //принимаем действительное число и пишем в double
                    sign = (a_now >= -a_now); //опеределяем знак первого элемента t+ f- (ноль не имеет знака, уберется позже)

                    if (a_now!=0 && i!=1 && !(sign^(a_last>=-a_last)) && (!(a_last>a_now)^sign)) //проверяем что элемент не первый и подходит ли по условию
                    {
                        output++;
                    }
                    a_last = a_now;
                }
                Console.WriteLine("Число соседств: {0}\n", output);
            }
        }
    }
}