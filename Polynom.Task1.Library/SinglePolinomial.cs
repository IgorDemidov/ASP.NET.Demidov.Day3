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

        public double[] Coefficients { get; private set; }

        public int Degree 
        { get { return Coefficients.Length - 1; } }

        public double this[int degree]
        {get { return Coefficients[degree]; }}

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
            if (first.Coefficients.Length < second.Coefficients.Length)
            {
               return Add(second,first);
            }

            for (int i = 0; i < second.Coefficients.Length; i++)
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
            this.Coefficients = Add(this, added).Coefficients;
            return this;
        }

        public SinglePolinomial Substract(SinglePolinomial substracted)
        {
            this.Add(substracted.MultiplyByNumber(-1));
            return this;
        }

        #endregion

        #region Virtual members overriding & interfaces implemention

        public override string ToString()
        {
            string stringRepresentation="";
            for (int i = 0; i < Coefficients.Length; i++)
            {
                stringRepresentation += Coefficients[i] + "   ";
            }
            return stringRepresentation;
        }

        public object Clone()
        {
            return new SinglePolinomial((double[])Coefficients.Clone());
        }

        public override bool Equals(object obj)
        {
            SinglePolinomial objAsSP = obj as SinglePolinomial;
            return this.Equals(objAsSP);
        }

        public bool Equals(SinglePolinomial other)
        {
            if (other == null)
            {
                return false; 
            }

            return this.ToString() == this.ToString();  
        }
        
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        #endregion

        #region Operator Overloading

        public static bool operator ==(SinglePolinomial left, SinglePolinomial right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SinglePolinomial left, SinglePolinomial right)
        {
            return !(left == right);
        }

        public static SinglePolinomial operator +(SinglePolinomial left, SinglePolinomial right)
        {
            return left.Add(right);
        }

        public static SinglePolinomial operator -(SinglePolinomial left, SinglePolinomial right)
        {
            return left.Substract(right);
        }
        
        #endregion

        #region Private methods

        
        #endregion









        
    }
}
