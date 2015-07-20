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

            double[] coefs = new double[] { 2.5, 4, 1, 8, 7 };
            double[] coefs2 = new double[] { 1, 1, 1, 1, 1, 1 };
            double[] coefs3 = new double[] { 2.5, 4, 1, 8, 7 };

            SinglePolinomial polinom = new SinglePolinomial(coefs);
            SinglePolinomial polinom2 = new SinglePolinomial(coefs2);

            SinglePolinomial polinom3 = (SinglePolinomial)polinom2.Clone();

            polinom2.MultiplyByNumber(2);

            Console.WriteLine(polinom2);
            Console.WriteLine(polinom3);


           

            Console.ReadLine();
            
        }
    }
}
