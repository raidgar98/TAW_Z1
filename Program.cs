using System;
using System.Collections.Generic;

namespace Z1
{

	class Program
	{

		public static Figure get_figure()
		{
			Console.Write("1) Rectangle\n2) Square\n3) Circle\n4) Triangle\nI choose: ");
			Int32 x = Int32.Parse(Console.ReadLine());
			if(x == 1) return new Rectangle();
			else if(x == 2 ) return new Square();
			else if(x == 3 ) return new Circle();
			else if(x == 4 ) return new Triangle();
			else return null;
		}

		static void Main (string[] args)
		{
			LinkedList<Figure> tab = new LinkedList<Figure>();
			for(int i = 0; i < 2; i++)
			{
				Figure ret = get_figure();
				ret.get_data();
				tab.AddLast(ret);
			}

			Console.WriteLine("###############################");
			foreach(Figure x in tab)
			{
				x.show_data();
				Console.WriteLine($"Perimiter: {x.compute_perimeter()}");
				Console.WriteLine($"Field: {x.compute_field()}");
				Console.WriteLine("###############################");
			}
		}
	}
}