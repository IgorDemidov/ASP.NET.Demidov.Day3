using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynom.Task1.Library
{
    public sealed class SinglePolinomial : ICloneable, IEquatable<SinglePolinomial>
    {
        #region Properties

        public double[] Coefficients { get; set; }

        public int Degree { get { return Coefficients.Length - 1; } }

        #endregion
        
        #region Constructors

        public SinglePolinomial(double[] coefficientsArray)
        {
            if (coefficientsArray!=null)
            {
                Coefficients = coefficientsArray;
            }
            
        }

        public SinglePolinomial() : this(new double[1] { 0 }){}

        #endregion

        #region Static methods

        public static SinglePolinomial Add(SinglePolinomial first, SinglePolinomial second)
        {
            if (first.Degree < second.Degree)
            {
               return Add(second,first);
            }

            for (int i = 0; i < second.Degree; i++)
            {
                first.Coefficients[i] += second.Coefficients[i];
            }
            return first;     
        }


        #endregion

        #region Public methods

        public SinglePolinomial MultiplyByNumber(double number)
        {
            for (int i = 0; i < Coefficients.Length-1; i++)
            {
                Coefficients[i] *= number;                
            }
            return this;
        }

        public SinglePolinomial DivideByNumber(double number)
        {
            MultiplyByNumber(1 / number);
            return this;
        }

        public SinglePolinomial Add(SinglePolinomial added)
        {
            this.Coefficients = added.Coefficients;
            return this;
        }

        public SinglePolinomial Substract(SinglePolinomial substracted)
        {
            this.Add(substracted.MultiplyByNumber(-1));
            return this;
        }

        #endregion

        #region Virtual members overriding & interfaces implemention

        public object Clone()
        {
            return new SinglePolinomial(Coefficients);
        }

        bool IEquatable<SinglePolinomial>.Equals(SinglePolinomial other)
        {
            if (this.Coefficients.Length != other.Coefficients.Length)
            {
                return false;
            }
                        
            for (int i = 0; i < Coefficients.Length; i++)
            {
                if (this.Coefficients[i] != other.Coefficients[i])
                    return false;   
            }
            return true;            
        }



        public override int GetHashCode()
        {
            int hashCode = Degree.GetHashCode();

            foreach (double c in Coefficients)
            {
                hashCode = hashCode ^ c.GetHashCode();
            }
            return hashCode;
        }

        #endregion

        #region Operator Overloading

        #endregion

        #region Private methods

        
        #endregion







        
    }
}
