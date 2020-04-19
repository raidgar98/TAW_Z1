using System;

namespace Z1
{
	public interface Figure
	{
		void get_data();
		string show_data();
		double compute_perimeter();
		double compute_field();
		int get_ID();
	}
}