using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace lab5_2
{
    internal class Program
    {
        private static Int32[] X;
        private static Int32[] Y;
        static void Main(string[] args)
        {
            
            X = InputFromFile("C:\\Users\\Ghost\\source\\repos\\lab5_2\\lab5_2\\X.txt");
            Int32[] modsX = GetMods(X);
            Print(modsX);
            Y = CopyWithChet(X);
            X = RemoveMaxBetweenMin(X);
            Y = RemoveMaxBetweenMin(Y);
            Print(X);
            
        }
        private static Int32[] InputFromFile(String path) 
        {
            //Ввод значений из файла по строчно в массив
            string[] lines = File.ReadAllLines(path);
            Int32[] arr = new Int32[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                arr[i] = Convert.ToInt32(lines[i]);
            }
            return arr;
        }
        private static void OutputIntoFile(Int32[] arr, String path)
        {
            //Вsвод значений из массива по строчно в файл
            string[] lines = File.ReadAllLines(path);
            arr = new Int32[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                arr[i] = Convert.ToInt32(lines[i]);
            }
        }
        private static Int32[] CopyWithChet(Int32[] arr1)
        {
            //Копируем arr1 в arr2 с дублированием четных чисел
            Int32 newLength = arr1.Length;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] % 2 == 0)
                    newLength++;
            }
            Int32[] arr2 = new Int32[newLength];
            for (int i = 0, j = 0; i < arr1.Length; i++, j++)
            {
                arr2[j] = arr1[i];
                if (arr1[i] % 2 == 0)
                    arr2[++j] = arr1[i];
            }
            return arr2;
        }
        private static Int32[] RemoveMaxBetweenMin(Int32[] arr1)
        {
            //Удаляем элементы между Первым максимальным элементом и последним минимальным
            Int32 iMax = GetIndexMax(arr1);
            Int32 iMin = GetIndexMin(arr1);
            if (iMax < iMin) //Вырезаем из массива если это нужно делать
            {
                Int32[] arr2 = new Int32[arr1.Length - iMin + iMax + 1];
                for(int i = 0; i <= iMax; i++)
                    arr2[i] = arr1[i];
                for (int i = iMin, j = iMax + 1; i < arr1.Length; i++, j++)
                    arr2[j] = arr1[i];
                arr1 = arr2;
            }
            return arr1;
        }
        private static Int32 GetIndexMax(Int32[] arr1)
        {
            //Ищем индекс максимального элемента
            Int32 max = arr1[0]; Int32 iMax = 0;
            for (int j = arr1.Length - 1; j >= 0; j--)
            {
                if (arr1[j] >= max)
                {
                    max = arr1[j]; iMax = j;
                }
            }
            return iMax;
        }
        private static Int32 GetIndexMin(Int32[] arr1)
        {
            //Ищем индекс минимального элемента
            Int32 min = arr1[0]; Int32 iMin = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] <= min)
                {
                    min = arr1[i]; iMin = i;
                }
            }
            return iMin;
        }
        private static Int32[] GetMods(Int32[] arr1)
        {
            //Ищем моды в массиве
            Int32[] Cols = new Int32[arr1.Length]; //Сохраняем количество одинаковых элементов в массиве
            bool isNew; //флаг для обработки (чтобы не дублировать количество элементов)
            for(int i = 0; i < arr1.Length; i++) //считаем элементы
            {
                isNew = true;
                for (int j = 0; j < arr1.Length; j++)
                {
                    if (arr1[i] == arr1[j] && Cols[j]!=0)
                    {
                        isNew = false;
                        Cols[j]++;
                        break;
                    }
                }
                if (isNew)
                {
                    Cols[i]++;
                }
            }
            Int32 max = Cols[0];
            Int32 index = 0;
            Cols[0] = arr1[0];
            for(int i = 0; i < Cols.Length; i++) //Ищем максимальное количество и его дубли и записываем в начало Cols
            {
                if (Cols[i] > max)
                {
                    max = Cols[i];
                    index = 0;
                    Cols[index] = arr1[i];
                } else if (Cols[i] == max)
                {
                    index++;
                    Cols[index] = arr1[i];
                }
            }
            Int32[] mods = new Int32[index+1];
            for (int i = 0; i<=index; i++) //копируем в отдельный массив
                mods[i] = Cols[i];
            return mods;
        }
        private static Int32 GetNumInclude(Int32[] arr1, Int32 elem)
        {
            //число включений элемента в массиве
            Int32 n = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                if(arr1[i] == 0)
                {
                    n++;
                }
            }
            return n;
        }
        private static void Print(Int32[] arr)
        {
            //Вывод результата
            Console.Write("Результат: ");
            for (int i = 0; i < arr.Length; i++)
                Console.Write("{0} ", arr[i]);
            Console.Write("\n");
        }
    }
}
