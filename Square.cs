using System;

namespace Z1
{
	public class Square : Figure
	{
		public double a { get; set; }

		public virtual void get_data()
		{
			System.Console.WriteLine("Square:");
			System.Console.Write("A: ");
			String A = System.Console.ReadLine();
			a = Double.Parse(A);
		}

		public virtual string show_data()
		{
			return this.ToString();
		}

		public virtual double compute_perimeter()
		{
			return (4.0 * a);
		}

		public virtual double compute_field()
		{
			return a*a;
		}

		public override string ToString()
		{
			return $"A: {this.a}\n";
		}

		public virtual int get_ID() { return 2; }
	}
}