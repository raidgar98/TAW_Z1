using System;

namespace Z1
{
	public class Rectangle : Figure
	{
		public double a { get; set; }
		public double b { get; set; }

		public virtual void get_data()
		{
			System.Console.WriteLine("Rectangle:");
			System.Console.Write("A: ");
			String A = System.Console.ReadLine();
			System.Console.Write("B: ");
			String B = System.Console.ReadLine();
			a = Double.Parse(A);
			b = Double.Parse(B);
		}

		public virtual string show_data()
		{
			return this.ToString();
		}

		public virtual double compute_perimeter()
		{
			return (2.0 * a) + (2.0 * b);
		}

		public virtual double compute_field()
		{
			return a*b;
		}

		public override string ToString()
		{
			return $"A: {this.a}\nB: {this.b}\n";
		}

		public virtual int get_ID() { return 1; }
	}
}