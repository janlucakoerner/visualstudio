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
        private Fraction(Int64 numerator, Int64 denominator = 1)
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
                {
                    Int64 num;
                    if (Int64.TryParse(fraction, out num))
                    {
                        numerator = num;
                        denominator = 1;
                    }
                    else
                        throw new Exception("Unparseable 'fraction' string");
                }
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
            if (denominator != 1)
                return numerator.ToString() + "/" + denominator.ToString();
            else
                return numerator.ToString();
        }
        public string ToStringLaTeX()
        {
            if (denominator != 1)
                return "\frac{" + numerator.ToString() + "}{" + denominator.ToString() + "}";
            else
                return numerator.ToString();
        }
        #endregion

        #region arithmetic operations
        public static Fraction operator +(Fraction fraction1, Fraction fraction2)
        {
            Int64 num, den;
            num = fraction1.numerator * fraction2.denominator +
                  fraction2.numerator * fraction1.denominator;
            den = fraction1.denominator * fraction2.denominator;
            return new Fraction(num, den).Shorten();
        }
        public static Fraction operator -(Fraction fraction)
        {
            return new Fraction(-fraction.numerator, fraction.denominator).Shorten();
        }
        public static Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            return ( fraction1 + (-fraction2) ).Shorten();
        }
        public static Fraction operator *(Fraction fraction1, Fraction fraction2)
        {
            Int64 num, den;
            num = fraction1.numerator * fraction2.numerator;
            den = fraction2.numerator * fraction2.denominator;
            return new Fraction(num, den).Shorten();
        }
        public static Fraction operator /(Fraction fraction1, Fraction fraction2)
        {
            return ( fraction1 * fraction2.Flip() ).Shorten();
        }
        public Fraction Flip()
        {
            if (numerator != 0)
                return new Fraction(denominator, numerator).Shorten();
            else
                throw new Exception("Denominator equals zero");
        }
        public Fraction Shorten()
        {
            var num = numerator;
            var den = denominator;
            Int64 ggt;
            if (num == 0) ggt = System.Math.Abs(den);
            //else if (den == 0) ggt = System.Math.Abs(num);
            else
            {
                do
                {
                    var tmp = num % den;
                    num = den;
                    den = tmp;
                }
                while (den != 0);
                ggt = System.Math.Abs(num);
            }
            return new Fraction(numerator / ggt, denominator / ggt);
        }
        #endregion
    }
}
