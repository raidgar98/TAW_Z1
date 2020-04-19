using System;

// prostokąt, kwadrat, koło, trójkąt

namespace Z1
{
	public interface Figure
	{
		void get_data();
		void show_data();
		double compute_perimeter();
		double compute_field();
	}
}