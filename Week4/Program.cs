using System;
using System.IO;
using System.Linq;

namespace Week4
{
    class Program
    {
        static void Main(string[] args)
        {
            Q1();
            Q2();
            Console.WriteLine("Q3");
            Q3();
            Console.WriteLine("Q4");
            Q4();
            Console.WriteLine("Q5");
            Q5();

        }
        static public void Q1()
        {
            int[] numbers = { 1, 5, 3, 6, 11, 2, 15, 21, 13, 12, 10 };

            var outputNumbers = from number in numbers
                                where number > 5
                                orderby number descending
                                select number;

            foreach (int number in outputNumbers)
            {
                Console.WriteLine(number.ToString());
            }



        }
        static public void Q2()
        {
            var files = new DirectoryInfo("E:\\semester2\\OOD").GetFiles();

            var query = from item in files
                        where item.Length > 10000
                        orderby item.Length, item.Name
                        select new MyFileInfo
                        {
                            Name = item.Name,
                            Length = item.Length,
                            CreationTime = item.CreationTime

                        };

            Console.WriteLine("Filename\tSize\t\tCreation Date");

            foreach (var item in query)
            {
                Console.WriteLine(
                    "{0} \t {1} Bytes,\t{2}", item.Name, item.Length, item.CreationTime);
            }
        }

        static public void Q3()
        {
            var files  = new DirectoryInfo("E:\\semester2\\OOD").GetFiles();

            var query = from item in files
                         where item.Length > 10000
                        orderby item.Length, item.Name
                         select new
                         {
                             Name = item.Name,
                             Lenght = item.Length,
                             CreationTime = item.CreationTime
                         };


            Console.WriteLine("Filename\tSize\t\tCreation Date");
                 
            foreach (var item in query)
            {
                Console.WriteLine(
                    "{0} \t{1} bytes, \t{2}",
                    item.Name, item.Lenght, item.CreationTime);
            }
            //Console.ReadLine();
                

        }
        static public void Q4()
        {
            int[] numbers = { 1, 5, 3, 6, 10, 12, 8 };

            var query = numbers
                .Select(n => DoubleIt(n));

            Console.WriteLine("Before the foreach loop");

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
         Console.ReadLine();

           

        }
      
        static public void Q5()
        {
            int[] numbers = { 1, 5, 3, 6, 10, 12, 8 };
            var query1 = numbers
                .OrderByDescending(n => n);
            var query2 = query1
                .Where(n => n < 8);

            var query3 = query2
                .Select(n => DoubleIt(n));

            foreach (var item in query3)
            {
                Console.WriteLine(item);
            }

            

        }
        private static int DoubleIt(int value)
        {
            Console.WriteLine("About to double the number" + value.ToString());
            return value * 2;

        }

    }
}
