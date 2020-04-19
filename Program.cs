using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace Z1
{
	class Program
	{
		// Translator between user choice and class
		public static Figure get_figure(int x = -1, string json = "")
		{
			// Printing avaiable options
			if(x == -1)
			{
				Console.Write("1) Rectangle\n2) Square\n3) Circle\n4) Triangle\nI choose: ");
				x = Int32.Parse(Console.ReadLine());
			}
			if(x == new Rectangle().get_ID()) return json == "" ? new Rectangle() : JsonConvert.DeserializeObject<Rectangle>(json) ;
			else if(x == new Square().get_ID() ) return json == "" ? new Square() : JsonConvert.DeserializeObject<Square>(json) ;
			else if(x == new Circle().get_ID() ) return json == "" ? new Circle() : JsonConvert.DeserializeObject<Circle>(json) ;
			else if(x == new Triangle().get_ID() ) return json == "" ? new Triangle() : JsonConvert.DeserializeObject<Triangle>(json) ;
			else return null;
		}

		// struct responsible for propoer serialize
		struct file_struct
		{
			public int id;
			public string data;
			public file_struct( int _id, string json )
			{
				id = _id;
				data = json;
			}
		}

		// Takes care about gathering data
		static LinkedList<Figure> load_data( string path = "" )
		{
			LinkedList<Figure> tab = new LinkedList<Figure>();

			if(path == "")
			{
				// Gathering data from user
				for(int i = 0; i < 2; i++)
				{
					Figure ret = get_figure();

					//Invalid input compensator
					if(ret == null)
					{
						Console.WriteLine("Error, try again");
						continue;
					}

					ret.get_data();
					tab.AddLast(ret);
				}
			}
			else // Gathering from file
			{
				LinkedList<file_struct> tmp = JsonConvert.DeserializeObject<
					LinkedList<file_struct>
				>(
					System.IO.File.ReadAllText(path)
				);

				foreach(file_struct var in tmp)
					tab.AddLast(get_figure(var.id, var.data));
			}

			return tab;
		}
		
		// Takes care about outputing data
		static void output_data( LinkedList<Figure> tab, string path, bool serial = false)
		{
			if(path == "")
			{
				// Printing Values
				Console.WriteLine("###############################");
				foreach(Figure x in tab)
				{
					Console.WriteLine(x.show_data());
					Console.WriteLine($"Perimiter: {x.compute_perimeter()}");
					Console.WriteLine($"Field: {x.compute_field()}");
					Console.WriteLine("###############################");
				}
			}
			else // Printing to File
			{
				// lambda help functions
				Func<string, byte[]> to_bytes = str => { return System.Text.Encoding.ASCII.GetBytes(str); };
				Func<string, string> n = str => { return str + "\n"; };

				// safe file opening
				using(FileStream fs = new FileStream(path, FileMode.CreateNew))
				{
					// If serial is true output file will be ready to 
					if(serial)
					{
						LinkedList<file_struct> tmp = new LinkedList<file_struct>();

						foreach(Figure var in tab)
							tmp.AddLast( new file_struct(var.get_ID(), JsonConvert.SerializeObject(var) ) );

						fs.Write(to_bytes(JsonConvert.SerializeObject(tmp)));
					}
					else
					{
						fs.Write(to_bytes("###############################"));
						foreach(Figure x in tab)
						{
							fs.Write(to_bytes(n(x.show_data())));
							fs.Write(to_bytes(n($"Perimiter: {x.compute_perimeter()}")));
							fs.Write(to_bytes(n($"Field: {x.compute_field()}")));
							fs.Write(to_bytes(n("###############################")));
						}
					}
				}
			}
		
		}

		static void Main (string[] args)
		{
			// control variabbles

			string load_file_path = "";
			bool is_load_file_path = false;
			string save_file_path = "";
			bool is_save_file_path = false;
			bool serializable_output = false;

			// argument parser
			foreach(string arg in args)
			{
				if(arg == "--run-tests")
				{
					new Tests();
					return;
				}

				if(is_load_file_path && load_file_path == "" ) load_file_path = arg;
				if(arg == "--from-file" ) { is_load_file_path = true; }

				if( is_save_file_path && save_file_path == "" ) save_file_path = arg;
				if(arg == "--to-file") { is_save_file_path = true; }

				if(arg == "--serial-output") serializable_output = true;
			}

			output_data(load_data(load_file_path), save_file_path, serializable_output);
		}
	}
}