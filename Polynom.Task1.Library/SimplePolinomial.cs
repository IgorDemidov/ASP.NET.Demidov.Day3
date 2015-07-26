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

      //  private readonly int NumberOfFractionalDigits = 4; 

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

        public static SimplePolinomial Add(SimplePolinomial first, SimplePolinomial second)
        {
            double[] resultCoefs;
            double[] summandCoefs;
            
            if (first.coefficients.Length>=second.coefficients.Length)
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

        public static SimplePolinomial MultiplyByNumber(SimplePolinomial polinomial, double number)
        {
            double[] resultCoefs = polinomial.Coefficients;
            for (int i = 0; i < resultCoefs.Length; i++)
            {
                resultCoefs[i] *= number;
            }
            return (new SimplePolinomial(resultCoefs));
        }

        #endregion

        #region Public methods

        public SimplePolinomial DivideByNumber(double number)
        {
            if (number == 0)
                throw new DivideByZeroException();

            return MultiplyByNumber(this, 1/number);
        }

        public SimplePolinomial Add(SimplePolinomial added)
        {
            return Add(this, added);
        }

        public SimplePolinomial MultiplyByNumber(double number)
        {
            return MultiplyByNumber(this, number);
        }

        public SimplePolinomial Substract(SimplePolinomial substracted)
        {
            return Add(this, MultiplyByNumber(substracted, -1));
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

        public override bool Equals(object obj)
        {
            SimplePolinomial objAsSP = obj as SimplePolinomial;
            if (objAsSP == null)
                return false;    
            return this.Equals(objAsSP);
        }

        public bool Equals(SimplePolinomial other)
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

        public static bool operator ==(SimplePolinomial left, SimplePolinomial right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SimplePolinomial left, SimplePolinomial right)
        {
            return !(left == right);
        }

        public static SimplePolinomial operator +(SimplePolinomial left, SimplePolinomial right)
        {
            return left.Add(right);
        }

        public static SimplePolinomial operator -(SimplePolinomial left, SimplePolinomial right)
        {
            return left.Substract(right);
        }
        
        #endregion











        
    }
}
