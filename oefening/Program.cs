using System;

namespace First
{
	class Program
	{
		public const string ISPOS = "IsPositief";
		public const string OPPRH = "OppervlakRechthoek";
		public const string INCR = "Increment";
		public const string DECR = "Decrement";


		static void Main(string[] args)
		{
			var menu = new Utils.Menu();
			// voeg oefeningen to door een callback naar een functie
			menu.AddOption('1', "Voer Oef1 uit", DoOef1);

			menu.Start();
		}

		static void DoOef1()
		{
			// object setup
			Utils.Object Obj = null;
			if(Utils.Object.DoesClassExist("First.Oefenreeks1")) {
				Obj = new Utils.Object("First.Oefenreeks1");
			} else
			{
				Console.WriteLine("De class Oefenreeks1 bestaat niet meer. Controleer je code op fouten.");
				return;
			}

			Console.WriteLine("Oefening \tverwacht antwoord \tJouw antwoord");

			// oefening 1
			Console.Write("1: \t\tTrue");
			Console.WriteLine("\t\t\t" + Oefenreeks1.IsPositief(4).ToString());
			Console.Write("1: \t\tFalse");
			Console.WriteLine("\t\t\t" + Oefenreeks1.IsPositief(-1).ToString());

			// oefening 2
			if(Obj.HasMethod(ISPOS, typeof(float))) {
				Console.Write("2: \t\tTrue");
				Console.WriteLine("\t\t\t" + Obj.Method(ISPOS, typeof(float)).Invoke(4.56f).ToString());

				Console.Write("2: \t\tFalse");
				Console.WriteLine("\t\t\t" + Obj.Method(ISPOS, typeof(float)).Invoke(-4.56f).ToString());
			} else
			{
				Console.WriteLine("2: IsPositief(float) niet gevonden");
			}

			// oefening 3
			Console.Write("3: \t\tTrue");
			Console.WriteLine("\t\t\t" + Oefenreeks1.IsLongString("0123456789").ToString());
			Console.Write("3: \t\tFalse");
			Console.WriteLine("\t\t\t" + Oefenreeks1.IsLongString("0123").ToString());

			// oefening 4
			if(Obj.HasMethod(OPPRH, new Type[] { typeof(int), typeof(int) }))
			{
				Console.Write("4: \t\t20");
				Console.WriteLine("\t\t\t" + Obj.Method(OPPRH, new Type[] { typeof(int), typeof(int) }).Invoke(new object[] { 4, 5 }));

				Console.Write("4: \t\t6");
				Console.WriteLine("\t\t\t" + Obj.Method(OPPRH, new Type[] { typeof(int), typeof(int) }).Invoke(new object[] { 3, 2 }));
			}
			else
			{
				Console.WriteLine("4: OppervlakRechthoek (int, int) niet gevonden");
			}

			// oefening 5
			if (Obj.HasMethod(OPPRH, new Type[] { typeof(float), typeof(float) }))
			{
				Console.Write("5: \t\t4,5");
				Console.WriteLine("\t\t\t" + Obj.Method(OPPRH, new Type[] { typeof(float), typeof(float) }).Invoke(new object[] { 1.5f, 3f }));

				Console.Write("5: \t\t6");
				Console.WriteLine("\t\t\t" + Obj.Method(OPPRH, new Type[] { typeof(float), typeof(float) }).Invoke(new object[] { 5f, 1.2f }));
			}
			else
			{
				Console.WriteLine("5: OppervlakRechthoek (float, float) niet gevonden");
			}

			// oefening 6
			Console.Write("6: \t\t100");
			Console.WriteLine("\t\t\t" + Oefenreeks1.Max(10, 100));

			Console.Write("6: \t\t-4");
			Console.WriteLine("\t\t\t" + Oefenreeks1.Max(-4, -5));

			// Oefening 7
			Console.Write("7: \t\t20");
			Console.WriteLine("\t\t\t" + Oefenreeks1.GrootsteOppervlak(4, 5, 3, 4));

			Console.Write("7: \t\t30");
			Console.WriteLine("\t\t\t" + Oefenreeks1.GrootsteOppervlak(1, 1, 6, 5));

			// oefening 8
			{
				int[] arr = { 1, 2, 3, 4 };
				int[] arr2 = { 2, 3, 4, 5 };
				Oefenreeks1.Increment(arr);

				bool correct = true;
				for (int i = 0; i < arr.Length; i++)
				{
					if(arr[i] != arr2[i])
					{
						correct = false;
					}
				}

				if(correct)
				{
					Console.WriteLine("8: De functie werkt correct");
				} else
				{
					Console.WriteLine("8: De functie werkt niet correct");
				}
			}


			// oefening 9
			if (Obj.HasMethod(INCR, new Type[] { typeof(int[]), typeof(int) }))
			{
				int[] arr = { 1, 2, 3, 4 };
				int[] arr2 = { 3, 4, 5, 6 };
				Obj.Method(INCR, new Type[] { typeof(int[]), typeof(int) }).Invoke(new object[] { arr, 2 });

				bool correct = true;
				for (int i = 0; i < arr.Length; i++)
				{
					if (arr[i] != arr2[i])
					{
						correct = false;
					}
				}

				if (correct)
				{
					Console.WriteLine("9: De functie werkt correct");
				}
				else
				{
					Console.WriteLine("9: De functie werkt niet correct");
				}

			}
			else
			{
				Console.WriteLine("9: Increment(int[], int) niet gevonden");
			}

			// oefening 10
			if (Obj.HasMethod(DECR, new Type[] { typeof(int[]), typeof(int) }))
			{
				int[] arr = { 1, 2, 3, 4 };
				int[] arr2 = { 3, 4, 5, 6 };
				Obj.Method(DECR, new Type[] { typeof(int[]), typeof(int) }).Invoke(new object[] { arr2, 2 });

				bool correct = true;
				for (int i = 0; i < arr.Length; i++)
				{
					if (arr[i] != arr2[i])
					{
						correct = false;
					}
				}

				if (correct)
				{
					Console.WriteLine("10: De functie werkt correct");
				}
				else
				{
					Console.WriteLine("10: De functie werkt niet correct");
				}

			}
			else
			{
				Console.WriteLine("10: Increment(int[], int) niet gevonden");
			}
		}

	}
}
