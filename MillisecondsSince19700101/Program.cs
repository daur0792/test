using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MillisecondsSince19700101
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество миллисекунд прошедших с 01.01.1970 для вычисления даты: ");

            string str = Console.ReadLine();
            long milliseconds = 0;

            if (long.TryParse(str, out milliseconds))
            {
                DateSince19700101 dateSince19700101 = new DateSince19700101(milliseconds);
                Console.WriteLine("Ответ: " + dateSince19700101);
            }
            else
            {
                Console.WriteLine("Не удалось расспарсить строку");
            }
            
        }
    }
}
