using System;

namespace Z1
{
	public class Circle : Figure
	{
		public double r { get; set; }

		public virtual void get_data()
		{
			System.Console.WriteLine("Circle:");
			System.Console.Write("r: ");
			String R = System.Console.ReadLine();
			r = Double.Parse(R);
		}

		public virtual void show_data()
		{
			System.Console.WriteLine(this.ToString());
		}

		public virtual double compute_perimeter()
		{
			return (2.0 * r * Math.PI);
		}

		public virtual double compute_field()
		{
			return Math.PI * r * r;
		}

		public override string ToString()
		{
			return $"R: {this.r}\n";
		}
	}
}