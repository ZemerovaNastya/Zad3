using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Zad3
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("file1.txt");
            List<People> p = new List<People>();
            int count = 0;
            try
            {
                while (!sr.EndOfStream)
                {
                    string str1 = sr.ReadLine();
                    string[] str2 = str1.Split(' ');
                    p.Add(new People() { F = str2[0], I = str2[1], O = str2[2], group = str2[3], mark = str2[4] });
                    count++;
                }
            }
            catch { Console.WriteLine("Неправильный тип данных в файле"); }
            sr.Close();
            Console.WriteLine("Максимальный балл:");
            double maxValue = p.Max(a => Convert.ToDouble(a.mark));
            foreach (var item in p)
            {
                if (item.mark == maxValue.ToString())
                {
                    Console.WriteLine(item.F + " " + item.I + " " + item.O + " " + item.group + " " + item.mark);
                }
            }
            Console.WriteLine("Минимальный балл:");
            double minValue = p.Min(a => Convert.ToDouble(a.mark));
            foreach (var item in p)
            {
                if (item.mark == minValue.ToString())
                {
                    Console.WriteLine(item.F + " " + item.I + " " + item.O + " " + item.group + " " + item.mark);
                }
            }
            Console.WriteLine("Среднее значение:");
            double averageMark = p.Average(a => Convert.ToDouble(a.mark));
            Console.WriteLine(averageMark);
            StreamWriter sw = new StreamWriter("file2.txt");
            bool flag = false;
            while (flag == false)
            {
                Console.WriteLine("Введите тип сортировки (по возрастанию, по убыванию), для выхода нажмите 0:");
                string stroka = Console.ReadLine();
                if (stroka == "по возрастанию")
                {
                    foreach (var item in p.OrderBy(d => Convert.ToDouble(d.mark)))
                    {
                        Console.WriteLine($"{item.F} {item.I} {item.O} {item.group} {item.mark}");
                        sw.WriteLine($"{item.F} {item.I} {item.I} {item.group} {item.mark}");
                    }
                    
                }
                else if (stroka == "по убыванию")
                {
                    foreach (var item in p.OrderByDescending(d => Convert.ToDouble(d.mark)))
                    {
                        Console.WriteLine($"{item.F} {item.I} {item.O} {item.group} {item.mark}");
                        sw.WriteLine($"{item.F} {item.I} {item.I} {item.group} {item.mark}");
                    }
                }
                else if (stroka == "0")
                {
                    flag = true;
                }
                else { Console.WriteLine("Такого варианта нет!"); }
            }
            sw.Close();
        }
    }
}
