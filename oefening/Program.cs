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
			menu.AddOption('1', "Voer Oefenreeks 1 uit", DoOef1);
			menu.AddOption('2', "Voer Oefenreeks 2 uit", DoOef2);

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

		static void DoOef2()
		{
			// object setup
			Utils.Object Obj = null;
			if (Utils.Object.DoesClassExist("First.Oefenreeks2"))
			{
				Obj = new Utils.Object("First.Oefenreeks2");
			}
			else
			{
				Console.WriteLine("De class Oefenreeks2 bestaat niet meer. Controleer je code op fouten.");
				return;
			}

			// oefening 1
			Console.Write("1: \t\t108");
			Console.WriteLine("\t\t\t" + Oefenreeks2.Maximize(12));
			Console.Write("1: \t\t102");
			Console.WriteLine("\t\t\t" + Oefenreeks2.Maximize(3));

			// oefening 2
			if (Obj.HasMethod("Maximize", new Type[] { typeof(int), typeof(int) }))
			{
				Console.Write("2: \t\t60");
				Console.WriteLine("\t\t\t" + Obj.Method("Maximize", new Type[] { typeof(int), typeof(int) }).Invoke(new object[] { 12, 50 }).ToString());

				Console.Write("2: \t\t204");
				Console.WriteLine("\t\t\t" + Obj.Method("Maximize", new Type[] { typeof(int), typeof(int) }).Invoke(new object[] { 12, 200 }).ToString());
			}
			else
			{
				Console.WriteLine("2: Maximize(int , int) niet gevonden");
			}

			// oefening 3
			Console.Write("3: \t\t13");
			Console.WriteLine("\t\t\t" + Oefenreeks2.FibonacciOfAtLeast(10).ToString());
			Console.Write("3: \t\t6765");
			Console.WriteLine("\t\t\t" + Oefenreeks2.FibonacciOfAtLeast(6000).ToString());

			// oefening 4
			Console.Write("4: \t\tabcd");
			Console.WriteLine("\t\t\t" + Oefenreeks2.Start("abcdefghijklml"));
			Console.Write("4: \t\t!$@*");
			Console.WriteLine("\t\t\t" + Oefenreeks2.Start("!$@*^#$*@$%^&"));

			// oefening 5
			Console.Write("5: \t\t!$@");
			Console.WriteLine("\t\t\t" + Oefenreeks2.Start("!$@*^#$*@$%^&", 3));
			Console.Write("5: \t\t!$@*^");
			Console.WriteLine("\t\t\t" + Oefenreeks2.Start("!$@*^#$*@$%^&", 5));

			// oefening 6
			string[] result = Oefenreeks2.Split("wie (code) schrijft die blijft");
			string[] test = new string[] { "wie", "(code)", "schrijft", "die", "blijft" };
			for (int i = 0; i < test.Length; i++) {
				Console.Write("6:\t\t" + test[i]);
				if(result.Length > i)
				{
					Console.WriteLine("\t\t\t" + result[i]);
				} else
				{
					Console.WriteLine("");
				}
			}

			// oefening 7
			Console.WriteLine("7  : You;are;the;semicolon;to;my;statements");
			Console.WriteLine("you: " + Oefenreeks2.ReplaceSpaces("You are the semicolon to my statements"));

			// oefening 8
			Console.Write("8: \t\tTrue");
			Console.WriteLine("\t\t\t" + Oefenreeks2.StartsWith("this is correct", "this").ToString());
			Console.Write("8: \t\tFalse");
			Console.WriteLine("\t\t\t" + Oefenreeks2.StartsWith("this is not correct", "not").ToString());

			// oefening 9
			Console.WriteLine("9:       'zero and null are not the same.'");
			Console.WriteLine("Becomes: 'afsp boe ovmm bsf opu uif tbnf.'");
			Console.WriteLine("You    : '" + Oefenreeks2.Encrypt("zero and null are not the same.") + "'");

			// oefening 10
			Console.WriteLine("10:      'afsp boe ovmm bsf opu uif tbnf.'");
			Console.WriteLine("Becomes: 'zero and null are not the same.'");
			Console.WriteLine("You    : '" + Oefenreeks2.Decrypt("afsp boe ovmm bsf opu uif tbnf.") + "'");
		}


	}
}
