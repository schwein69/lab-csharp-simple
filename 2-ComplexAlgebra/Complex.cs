using System;

namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {
     

        public double Real { get; }
        public double Imaginary { get; }
        public double Modulus => Math.Sqrt(Real * Real + Imaginary * Imaginary);
        
        public double Phase => Math.Atan2(Imaginary, Real);

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public Complex Plus(Complex other) => new Complex(this.Real + other.Real, this.Imaginary + other.Imaginary);
        public Complex Minus(Complex other) => new Complex(this.Real - other.Real, this.Imaginary - other.Imaginary);
        public Complex Complement() => new Complex(Real, -Imaginary );
        public bool Equals(Complex other)
        {
            return Real.Equals(other.Real) && Imaginary.Equals(other.Imaginary);
        }
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Complex) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Real, Imaginary);
        }

        public override string ToString()
        {
            if (Imaginary == 0.0) return Real.ToString();
            var imAbs = Math.Abs(Imaginary);
            var imValue = imAbs == 1.0 ? "" : imAbs.ToString();
            string sign;
            if (Real == 0d)
            {
                sign = Imaginary > 0 ? "" : "-";
                return sign + "i" + imValue;
            }

            sign = Imaginary > 0 ? "+" : "-";
            return $"{Real} {sign} i{imValue}";
        }
    }
}