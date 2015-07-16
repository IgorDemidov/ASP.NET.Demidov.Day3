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
        public int[] Сoefficients { get; private set; }

        public int Degree { get; private set; }

        #endregion
        
        #region Constructors

        public SinglePolinomial(int[] coefficientsArray)
        {
            Сoefficients = coefficientsArray;
            Degree = coefficientsArray.Length - 1;
        }

        public SinglePolinomial()
            : this(new int[1] { 0 })
        {
        }

        #endregion

        #region Virtual members overriding

        public object Clone()
        {
            return new SinglePolinomial(Сoefficients);
        }
        

        

        public bool Equals(SinglePolinomial other)
        {
            return this.Equals(other);       
        }

        public override int GetHashCode()
        {
            int hashCode = Degree.GetHashCode();

            foreach (int c in Сoefficients)
            {
                hashCode = hashCode ^ c;
                
            }
            return hashCode;
        }

        #endregion







    }
}
