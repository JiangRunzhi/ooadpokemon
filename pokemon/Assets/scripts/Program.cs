using System;
using System.IO;
using System.Threading;

namespace ConsoleApp3
{
    class Program
    {
        void Main(string[] args)
        {
            int[] pokemon = {1, 2, 4, 4, 5, 6};
            using (StreamWriter sw = new StreamWriter("names.txt"))
            {
                foreach (int s in pokemon)
                {
                    sw.WriteLine(s);

                }
            }

            int[] duru = new int[6];
            int count = 0;
            string line = "";
            using (StreamReader sr = new StreamReader("names.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    duru[count] = int.Parse(line);
                    count++;
                }
            }
            
        }
    }
}