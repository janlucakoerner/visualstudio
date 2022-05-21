using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashsystem.Math
{
    public class Fraction
    {
        private readonly Int64 numerator;
        private readonly Int64 denominator;

        #region constructors
        public Fraction(Int64 numerator, Int64 denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }
        public Fraction(string fraction)
        {
            if (!string.IsNullOrEmpty(fraction))
            {
                if (fraction.Contains("/"))
                {
                    var frac = fraction.Split("/");
                    numerator = Int64.Parse(frac[0]);
                    denominator = Int64.Parse(frac[1]);
                }
                else if (fraction.StartsWith("\frac{") &&
                         fraction.EndsWith("}") &&
                         fraction.Contains("}{"))
                {
                    string frac = fraction;
                    frac = frac.Replace("\frac{", "");
                    var num = frac.Substring(0, frac.IndexOf("}"));
                    numerator = Int64.Parse(num);

                    frac = frac.Replace(num + "}{", "");
                    var den = frac.Substring(0, frac.IndexOf("}"));
                    denominator = Int64.Parse(den);
                }
                else
                    throw new Exception("Unparseable 'fraction' string");
            }
            else
                throw new Exception("Empty 'fraction' string");
            if (denominator == 0)
                throw new Exception("Denominator equals zero");
            
        }
        #endregion

        #region output
        public override string ToString()
        {
            return numerator.ToString() + "/" + denominator.ToString();
        }
        public string ToStringLaTeX()
        {
            return "\frac{" + numerator.ToString() + "}{" + denominator.ToString() + "}";
        }
        #endregion

        #region arithmetic operations
        public Fraction add(Fraction fraction)
        {
            Int64 num, den;
            num = this.numerator * fraction.denominator +
                  fraction.numerator * this.denominator;
            den = this.denominator * fraction.denominator;
            return new Fraction(num, den);
        }
        public static Fraction operator +(Fraction fraction1, Fraction fraction2)
        {
            return fraction1.add(fraction2);
        }
        public Fraction sub(Fraction fraction)
        {
            Int64 num, den;
            num = this.numerator * fraction.denominator -
                  fraction.numerator * this.denominator;
            den = this.denominator * fraction.denominator;
            return new Fraction(num, den);
        }
        public static Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            return fraction1.sub(fraction2);
        }
        public Fraction mul(Fraction fraction)
        {
            Int64 num, den;
            num = this.numerator * fraction.numerator;
            den = this.numerator * fraction.denominator;
            return new Fraction(num, den);
        }
        public static Fraction operator *(Fraction fraction1, Fraction fraction2)
        {
            return fraction1.mul(fraction2);
        }
        #endregion
    }
}
