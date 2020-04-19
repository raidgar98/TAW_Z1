using System;

namespace Z1
{
	public class Triangle : Figure
	{
		public double a { get; set; }
		public double h { get; set; }

		public virtual void get_data()
		{
			System.Console.WriteLine("Triangle:");
			System.Console.Write("A: ");
			String A = System.Console.ReadLine();
			System.Console.Write("H: ");
			String H = System.Console.ReadLine();
			a = Double.Parse(A);
			h = Double.Parse(H);
		}

		public virtual void show_data()
		{
			System.Console.WriteLine(this.ToString());
		}

		public virtual double compute_perimeter()
		{
			return (3.0 * a);
		}

		public virtual double compute_field()
		{
			return (a*h)/2.0;
		}

		public override string ToString()
		{
			return $"A: {this.a}\nH: {this.h}\n";
		}
	}
}