using System;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            try
            {
                using (StreamReader sr = new StreamReader("D:/Project_of_c#/ConsoleApp2/ConsoleApp2/test.txt"))
                {
                    string line;
                     
                    while ((line = sr.ReadLine()) != null)
                    {   
                        Console.WriteLine(count.ToString()+' '+line);
                        // Console.WriteLine(count+' '+line);
                        count++;
                        // Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}