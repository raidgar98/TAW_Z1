using System;

namespace Z1
{
	class CompareException : System.Exception 
	{
		public CompareException(object o1, object o2) : base($"[Failed] {o1.ToString()} != {o2.ToString()}") {}
	}

	// Test class
	class Tests
	{
		// Alias methode for System.Console.WriteLine
		void log(object msg)
		{
			System.Console.WriteLine(msg);
		}

		// Main parse methode
		void require_equal<T>(T o1, T o2)
		{
			if(!o1.Equals(o2)) throw new CompareException(o1, o2);
			else log($"[Passed] {o1.ToString()} == {o2.ToString()}");
		}

		// Alias methode for `require_equal` for number comprasions
		void require_equal_numbers(double o1, double o2)
		{
			require_equal<double>(o1,o2);
		}

		// Constructor here tests are runned
		public Tests()
		{
			log("* Starting Tests...");

			CircleTests();
			RectangleTests();
			SquareTests();
			TriangleTests();
		}

		// Circle tests manager
		void CircleTests()
		{
			log("** Circle...");
			try
			{
				CircleTestCase1();
			}
			catch(CompareException) { log("** Circle Test Case Failed."); }
		}

		// Triangle tests manager
		void TriangleTests()
		{
			log("** Triangle...");
			try
			{
				TriangleTestCase1();
			}
			catch(CompareException) { log("** Triangle Test Case Failed."); }
		}

		// Square tests manager
		void SquareTests()
		{
			log("** Square...");
			try
			{
				SquareTestCase1();
			}
			catch(CompareException) { log("** Square Test Case Failed."); }
		}

		// Rectangle tests manager
		void RectangleTests()
		{
			log("** Rectangle...");
			try
			{
				RectangleTestCase1();
			}
			catch(CompareException) { log("** Rectangle Test Case Failed."); }
		}

// Test Cases:

		void CircleTestCase1()
		{
			log("*** Circle Test Case 1");
			Circle c1 = new Circle();

			c1.r = 1;
			require_equal_numbers(1, c1.r);
			require_equal_numbers(Math.PI * 2, c1.compute_perimeter());
			require_equal_numbers(Math.PI, c1.compute_field());

			c1.r = 2;
			require_equal_numbers(2 , c1.r);
			require_equal_numbers(c1.compute_field(), c1.compute_perimeter());
		}

		void RectangleTestCase1()
		{
			log("*** Rectangle Test Case 1");
			Rectangle r1 = new Rectangle();

			r1.a = 1;
			r1.b = 1;
			require_equal_numbers(1, r1.a);
			require_equal_numbers(1, r1.b);
			require_equal_numbers(1, r1.compute_field());
			require_equal_numbers(4, r1.compute_perimeter());

			r1.a = 2;
			r1.b = 3;
			require_equal_numbers(2, r1.a);
			require_equal_numbers(3, r1.b);
			require_equal_numbers(6, r1.compute_field());
			require_equal_numbers(10, r1.compute_perimeter());
		}

		void SquareTestCase1()
		{
			log("*** Square Test Case 1");
			Square s1 = new Square();

			s1.a = 1;
			require_equal_numbers(1, s1.a);
			require_equal_numbers(1, s1.compute_field());
			require_equal_numbers(4, s1.compute_perimeter());

			s1.a = 4;
			require_equal_numbers(4, s1.a);
			require_equal_numbers(s1.compute_perimeter(), s1.compute_field());
		}

		void TriangleTestCase1()
		{
			log("*** Triangle Test Case 1");
			Triangle t1 = new Triangle();
			
			t1.a = 1;
			t1.h = 1;
			require_equal_numbers(1, t1.a);
			require_equal_numbers(1, t1.h);
			require_equal_numbers(0.5, t1.compute_field());
			require_equal_numbers(3, t1.compute_perimeter());

			t1.a = 4;
			t1.h = 2;
			require_equal_numbers(4, t1.a);
			require_equal_numbers(2, t1.h);
			require_equal_numbers(4, t1.compute_field());
			require_equal_numbers(12, t1.compute_perimeter());
		}
	}
}