using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynom.Task1.Library
{
    public sealed class SimplePolinomial : ICloneable, IEquatable<SimplePolinomial>
    {
        #region Private fields

        private readonly double[] coefficients;

        #endregion

        #region Properties

        public double[] Coefficients
        {
            get
            { return (double[])coefficients.Clone(); }
        }
        
        public int Degree
        { get { return coefficients.Length - 1; } }

        #endregion
        
        #region Constructors

        public SimplePolinomial(double[] coefficientsArray)
        {
            if (coefficientsArray == null)
                throw new ArgumentNullException("CoefficientsArray reference not set to an instance of an double[]");
            coefficients = (double[])coefficientsArray.Clone();
        }

        public SimplePolinomial() : this(new double[1] { 0 }){}

        #endregion

        #region Static methods

        public static SimplePolinomial MultiplyByNumber(SimplePolinomial polinomial, double number)
        {
            double[] resultCoefs = polinomial.Coefficients;
            for (int i = 0; i < resultCoefs.Length; i++)
            {
                resultCoefs[i] *= number;
            }
            return (new SimplePolinomial(resultCoefs));
        }

        public static SimplePolinomial DivideByNumber(SimplePolinomial polinomial, double number)
        {
            if (number==0)
            {
                throw new DivideByZeroException("number");
            }

            double[] resultCoefs = polinomial.Coefficients;
            for (int i = 0; i < resultCoefs.Length; i++)
            {
                resultCoefs[i] /= number;
            }
            return (new SimplePolinomial(resultCoefs));
        }

        public static SimplePolinomial Add(SimplePolinomial first, SimplePolinomial second)
        {
            double[] resultCoefs;
            double[] summandCoefs;

            if (first.coefficients.Length >= second.coefficients.Length)
            {
                resultCoefs = first.Coefficients;
                summandCoefs = second.Coefficients;
            }
            else
            {
                resultCoefs = second.Coefficients;
                summandCoefs = first.Coefficients;
            }

            for (int i = 0; i < resultCoefs.Length; i++)
            {
                resultCoefs[i] += summandCoefs[i];
            }

            return (new SimplePolinomial(resultCoefs));
        }

        public static SimplePolinomial Substract(SimplePolinomial minuend, SimplePolinomial subtrahend)
        {
            return Add(minuend, MultiplyByNumber(subtrahend,-1));
        }

        #endregion

        #region Virtual members overriding & interfaces implemention
        
        public override string ToString()
        {
            string stringRepresentation="";
            for (int i = 0; i < Coefficients.Length; i++)
            {
                stringRepresentation += coefficients[i] + "\t";
            }
            return stringRepresentation;
        }

        public object Clone()
        {
            return new SimplePolinomial((double[])coefficients.Clone());
        }

        public bool Equals(SimplePolinomial other)
        {
            if (other == null)
                return false; 

            if (this.coefficients.Length!=other.coefficients.Length)
                return false;

            for (int i = 0; i < this.coefficients.Length; i++)
            {
                if (this.coefficients[i] != other.coefficients[i])
                    return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            SimplePolinomial objAsSimplePolinomial = obj as SimplePolinomial;
            return this.Equals(objAsSimplePolinomial);
        }
        
        public override int GetHashCode()
        {
            int hash = coefficients.Length;
            for (int i = 0; i < coefficients.Length; i++)
            {
                hash = ((hash << 5)+hash) + coefficients[i].GetHashCode();
            }
            return hash;
        }

        #endregion

        #region Operator Overloading

        public static bool operator ==(SimplePolinomial lhs, SimplePolinomial rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(SimplePolinomial lhs, SimplePolinomial rhs)
        {
            return !lhs.Equals(rhs);
        }

        public static SimplePolinomial operator +(SimplePolinomial lhs, SimplePolinomial rhs)
        {
            return Add(lhs, rhs);
        }

        public static SimplePolinomial operator -(SimplePolinomial lhs, SimplePolinomial rhs)
        {
            return Substract(lhs, rhs);
        }

        public static SimplePolinomial operator /(SimplePolinomial lhs, double rhs)
        {
            return DivideByNumber(lhs, rhs);
        }

        #endregion











        
    }
}
