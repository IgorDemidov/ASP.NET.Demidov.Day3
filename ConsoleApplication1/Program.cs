using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polynom.Task1.Library;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglePolinomial p = new SinglePolinomial();

            Console.WriteLine(p.Degree);

           
            Console.ReadLine();
            
        }
    }
}
