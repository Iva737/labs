using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            while (true)
            {
                Console.Write("Введите координату X: ");
                decimal x = decimal.Parse(Console.ReadLine());
                Console.Write("Введите координату Y: ");
                decimal y = decimal.Parse(Console.ReadLine());

                bool a = ((((x-2)*(x-2) + (y-2)*(y-2)) <= 4)  && //круг сбоку
                          (((decimal)1.5*x*x - y)      >  6)) || //параболла
                         (((x*x + y*y)                 <= 4)  && //круг в середине
                          (((x-2)*(x-2) + (y-2)*(y-2)) >= 4));   //круг сбоку

                if (a)
                {
                    Console.WriteLine("Принадлежит множеству точек");
                }
                else
                {
                    Console.WriteLine("Не принадлежит множеству точек");
                }
            }
            */
            while (true)
            {
                Console.Write("Введите координату X: ");
                double x = double.Parse(Console.ReadLine());
                Console.Write("Введите координату Y: ");
                double y = double.Parse(Console.ReadLine());

                if(x < 0 || y < 0)
                {
                    Console.WriteLine("Неверный ввод. Значения не могут быть отрицательными");
                    return;
                }

                int chet = (int)(x / 3) + (int)(y / 2); //шахматный порядок (чет серая, нечет белая)

                x = x % 3;
                y = y % 2;

                bool a = (x == 0); // дополняем хар-ку
                if (chet%2 == 0)
                {
                    a = a || !(1 < x && x < 2 && y < 1); // вырезаем пятку
                } else
                {
                    a = a || (1 <= x && x <= 2 && y <= 1); // добавляем пятку
                }

                if (a)
                {
                    Console.WriteLine("Принадлежит множеству точек");
                }
                else
                {
                    Console.WriteLine("Не принадлежит множеству точек");
                }
            }
        }
    }
}
