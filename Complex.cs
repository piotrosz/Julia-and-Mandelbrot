using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace JuliaAndMandelbrot 
{
	public enum ConversionStyle {
		Length,
		Real,
		Imaginary
	}

	/// <summary>
	/// A double-precision complex number representation.
	/// Ben Houston (ben@exocortex.org)
	/// March 7, 2002
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Complex {

		//-----------------------------------------------------------------------------------

		public double Re;
		public double Im;

		//-----------------------------------------------------------------------------------

		public Complex( double real, double imaginary ) {
			this.Re		= (double) real;
			this.Im	= (double) imaginary;
		}

		public Complex( Complex c ) {
			this.Re		= c.Re;
			this.Im	= c.Im;
		}
		
		//-----------------------------------------------------------------------------------

		// create complex number from real and imaginary coords
		static public Complex	FromRealImaginary( double real, double imaginary ) {
			Complex c;
			c.Re		= (double) real;
			c.Im = (double) imaginary;
			return c;
		}

		// create complex number from polar coordinates
			static public Complex	FromModulusArgument( double modulus, double argument ) {
			Complex c;
			c.Re		= (double)( modulus * System.Math.Cos( argument ) );
			c.Im	= (double)( modulus * System.Math.Sin( argument ) );
			return c;
		}
		
		//-----------------------------------------------------------------------------------

		// radius of complex vector in polar coordinates
		public double	GetModulus() {
			double	x	= this.Re;
			double	y	= this.Im;
			return	Math.Sqrt( x*x + y*y );
		}

		// angle of complex vector in polar coordinates 
		public double	GetArgument() {
			return	Math.Atan2( this.Im, this.Re );
		}

		//-----------------------------------------------------------------------------------

		// get the conjugate of the complex number
		public Complex GetConjugate() {
			return FromRealImaginary( this.Re, -this.Im );
		}

		//-----------------------------------------------------------------------------------

		// scale modulus such that it is 1
		public void Normalize() {
			double	modulus = this.GetModulus();
			if( modulus == 0 ) {
				return;
			}
			this.Re		= (double)( this.Re / modulus );
			this.Im	= (double)( this.Im / modulus );
		}

		//-----------------------------------------------------------------------------------
		//-----------------------------------------------------------------------------------

		// int->complex, just sets real component
		public static explicit operator Complex ( int i ) {
			Complex c;
			c.Re		= (double) i;
			c.Im	= (double) 0;
			return c;
		}
		// float->complex, just sets real component
		public static explicit operator Complex ( float f ) {
			Complex c;
			c.Re		= (double) f;
			c.Im	= (double) 0;
			return c;
		}
		// double->complex, just sets real component
		public static explicit operator Complex ( double d ) {
			Complex c;
			c.Re		= (double) d;
			c.Im	= (double) 0;
			return c;
		}

		// complex->int, just gets real component
		public static explicit operator int ( Complex c ) {
			return (int) c.Re;
		}
		// complex->float, just gets real component
		public static explicit operator float ( Complex c ) {
			return (float) c.Re;
		}
		// complex->double, just gets real component
		public static explicit operator double ( Complex c ) {
			return (double) c.Re;
		}
		
		//-----------------------------------------------------------------------------------
		//-----------------------------------------------------------------------------------

		public override int	GetHashCode() {
			return	( this.Re.GetHashCode() ^ this.Im.GetHashCode() );
		}

		public override bool Equals( object o ) {
			if( o is Complex ) {
				Complex c = (Complex) o;
				return   ( this == c );
			}
			return	false;
		}

		public static bool	operator==( Complex a, Complex b ) {
			if( ( a.Re == b.Re ) && ( a.Im == b.Im ) ) {
				return true;
			}

			double numerator = ( a - b ).GetModulus();
			return ( ( numerator / ( a.GetModulus() + b.GetModulus() ) ) < 0.0000000001 );
		}
		public static bool	operator!=( Complex a, Complex b ) {
			return   ! ( a == b );
		}

		//-----------------------------------------------------------------------------------
		//-----------------------------------------------------------------------------------

		public static Complex operator+( Complex a ) {
			return a;
		}
		public static Complex operator-( Complex a ) {
			a.Re		= -a.Re;
			a.Im	= -a.Im;
			return a;
		}

		public static Complex operator+( Complex a, double d ) {
			a.Re		= (double)( a.Re + d );
			return a;
		}
		public static Complex operator+( double d, Complex a ) {
			a.Re		= (double)( a.Re + d );
			return a;
		}
		
		public static Complex operator*( Complex a, double d ) {
			a.Re		= (double)( a.Re * d );
			a.Im	= (double)( a.Im * d );
			return a;
		}
		public static Complex operator*( double d, Complex a ) {
			a.Re		= (double)( a.Re * d );
			a.Im	= (double)( a.Im * d );
			return a;
		}

		public static Complex operator/( Complex a, double d ) {
			if( d == 0 ) {
				return	Complex.Zero;
			}
			a.Re		= (double)( a.Re / d );
			a.Im	= (double)( a.Im / d );
			return a;
		}

		
		public static Complex operator+( Complex a, Complex b ) {
			a.Re		= a.Re + b.Re;
			a.Im	= a.Im + b.Im;
			return a;
		}
		public static Complex operator-( Complex a, Complex b ) {
			a.Re		= a.Re - b.Re;
			a.Im	= a.Im - b.Im;
			return a;
		}

		public static Complex operator*( Complex a, Complex b ) {
			// (x + yi)(u + vi) = (xu – yv) + (xv + yu)i. 
			double	x = a.Re, y = a.Im;
			double	u = b.Re, v = b.Im;
			a.Re		= (double)( x*u - y*v );
			a.Im	= (double)( x*v + y*u );
			return a;
		}
		public static Complex operator/( Complex a, Complex b ) {
			double	x = a.Re,	y = a.Im;
			double	u = b.Re,	v = b.Im;
			double	denom = u*u + v*v;
			if( denom == 0 ) {
				return	Complex.Zero;
			}

			a.Re		= (double)( ( x*u + y*v ) / denom );
			a.Im	= (double)( ( y*u - x*u ) / denom );
			return a;
		}

		//-----------------------------------------------------------------------------------

		public override string ToString() {
			return	String.Format( "( {0}, {1}i )", this.Re, this.Im );
		}

		//-----------------------------------------------------------------------------------

		static public Complex Parse( string s ) {
			Debug.Assert( false );
			return (Complex) 1;
		}
		
		//-----------------------------------------------------------------------------------
		//-----------------------------------------------------------------------------------

		static public bool IsEqual( Complex a, Complex b, double tolerance ) {
			return
				( Math.Abs( a.Re - b.Re ) < tolerance ) &&
				( Math.Abs( a.Im - b.Im ) < tolerance );

		}
		static public bool IsEqual( Complex a, Complex b ) {
			return
				( Math.Abs( a.Re - b.Re ) < 0.000001 ) &&
				( Math.Abs( a.Im - b.Im ) < 0.000001 );

		}

		static public bool IsInfinity( Complex c ) {
			return double.IsInfinity( c.Re ) || double.IsInfinity( c.Im );
		}
		static public bool IsNAN( Complex c ) {
			return double.IsNaN( c.Re ) || double.IsNaN( c.Im );
		}
		
		//=========================================================================

		static readonly public Complex	Zero		= Complex.FromRealImaginary( 0, 0 );
		static readonly public Complex	I			= Complex.FromRealImaginary( 0, 1 );
		static readonly public Complex	MaxValue	= Complex.FromRealImaginary( double.MaxValue, double.MaxValue );

		//----------------------------------------------------------------------------------

		static public Type	GetInnerType() {
			return	typeof( double );
		}

		//----------------------------------------------------------------------------------
	}
}
