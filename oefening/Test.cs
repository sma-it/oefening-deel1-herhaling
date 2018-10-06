using NUnit.Framework;
using NUnitLite;
using System;

namespace Tests
{
	[TestFixture]
	public class TestClass
	{
		// deze functie is nodig om de testen achteraf via de webinterface uit te voeren
		public static int Run(string resultPath)
		{
			string[] args = { "--work=" + resultPath };
			return new AutoRun().Execute(args);
		}

		[Test]
		public void TestOefening1()
		{
			Assert.That(First.Oefenreeks1.IsPositief(0), Is.True, "Nul is ook een positief getal");
			Assert.That(First.Oefenreeks1.IsPositief(-1), Is.False, "Negatieve getallen zijn niet positief");
			Assert.That(First.Oefenreeks1.IsPositief(10), Is.True, "Getallen groter dan nul zijn positief");
		}

		[Test]
		public void TestOefening2()
		{
			Utils.Object Obj = new Utils.Object("First.Oefenreeks1");
			Assert.That(Obj.HasMethod(First.Program.ISPOS, typeof(float)), First.Program.ISPOS + " heeft geen float argument");
			Assert.That(Obj.Method(First.Program.ISPOS, typeof(float)).Invoke(5.67f), Is.True, "Getallen groter dan nul zijn positief");
			Assert.That(Obj.Method(First.Program.ISPOS, typeof(float)).Invoke(-12f), Is.False, "Negatieve getallen zijn kleiner dan null");
		}

		[Test]
		public void TestOefening3()
		{
			Assert.That(First.Oefenreeks1.IsLongString("very long string"), Is.True, "strings langer dan 10 tekens zijn lang");
			Assert.That(First.Oefenreeks1.IsLongString("Short"), Is.False, "Je functie werkt niet met korte strings");
		}

		[Test]
		public void TestOefening4()
		{
			Utils.Object Obj = new Utils.Object("First.Oefenreeks1");
			Assert.That(Obj.HasMethod(First.Program.OPPRH, new Type[] { typeof(int), typeof(int) }), Is.True, "De functie OppervlakRechtoek(int, int) bestaat niet");
			Assert.That(Obj.Method(First.Program.OPPRH, new Type[] { typeof(int), typeof(int) }).Invoke(new object[] { 4, 5 }), Is.EqualTo(20), "Foute Berekening");
			Assert.That(Obj.Method(First.Program.OPPRH, new Type[] { typeof(int), typeof(int) }).Invoke(new object[] { 14, 10 }), Is.EqualTo(140), "Foute Berekening");
		}

		[Test]
		public void TestOefening5()
		{
			Utils.Object Obj = new Utils.Object("First.Oefenreeks1");
			Assert.That(Obj.HasMethod(First.Program.OPPRH, new Type[] { typeof(float), typeof(float) }), Is.True, "De functie OppervlakRechtoek(int, int) bestaat niet");
			Assert.That(Obj.Method(First.Program.OPPRH, new Type[] { typeof(float), typeof(float) }).Invoke(new object[] { 4.1f, 5f }), Is.EqualTo(20.5f).Within(.0005), "Foute Berekening");
			Assert.That(Obj.Method(First.Program.OPPRH, new Type[] { typeof(float), typeof(float) }).Invoke(new object[] { 1.1f, 3.4f }), Is.EqualTo(3.74f).Within(.0005), "Foute Berekening");
		}

		[Test]
		public void TestOefening6()
		{
			Assert.That(First.Oefenreeks1.Max(0, 10), Is.EqualTo(10), "Het tweede getal was hier het grootst");
			Assert.That(First.Oefenreeks1.Max(-234, 158967), Is.EqualTo(158967), "Het tweede getal was hier het grootst");
			Assert.That(First.Oefenreeks1.Max(-234, -456), Is.EqualTo(-234), "Het eerste getal was hier het grootst");
		}

		[Test]
		public void TestOefening7()
		{
			Assert.That(First.Oefenreeks1.GrootsteOppervlak(1, 2, 3, 4), Is.EqualTo(12), "De tweede rechthoek is het grootst");
			Assert.That(First.Oefenreeks1.GrootsteOppervlak(5, 8, 3, 4), Is.EqualTo(40), "De eerste rechthoek is het grootst");
		}

		bool ArraysAreEqual(int[] a, int[] b)
		{
			if (a.Length != b.Length) return false;
			for(int i = 0; i < a.Length; i++) {
				if (a[i] != b[i]) return false;
			}
			return true;
		}

		[Test]
		public void TestOefening8()
		{
			int[] arr = { 5,6,7,8 };
			int[] arr2 = { 6,7,8,9 };
			First.Oefenreeks1.Increment(arr);
			Assert.That(ArraysAreEqual(arr, arr2), Is.True, "De verhoging is niet correct");
		}

		[Test]
		public void TestOefening9()
		{
			Utils.Object Obj = new Utils.Object("First.Oefenreeks1");
			Assert.That(Obj.HasMethod(First.Program.INCR, new Type[] { typeof(int[]), typeof(int) }), "Increment(int[], int) bestaat niet");

			int[] arr = { 5, 6, 7, 8 };
			int[] arr2 = { 8, 9, 10, 11 };
			Obj.Method(First.Program.INCR, new Type[] { typeof(int[]), typeof(int) }).Invoke(new object[] { arr, 3 });
			Assert.That(ArraysAreEqual(arr, arr2), Is.True, "De verhoging is niet correct");
		}

		[Test]
		public void TestOefening10()
		{
			Utils.Object Obj = new Utils.Object("First.Oefenreeks1");
			Assert.That(Obj.HasMethod(First.Program.DECR, new Type[] { typeof(int[]), typeof(int) }), "Decrement(int[], int) bestaat niet");

			int[] arr = { 5, 6, 7, 8 };
			int[] arr2 = { 0, 1, 2, 3 };
			Obj.Method(First.Program.DECR, new Type[] { typeof(int[]), typeof(int) }).Invoke(new object[] { arr, 5 });
			Assert.That(ArraysAreEqual(arr, arr2), Is.True, "De verlaging is niet correct");
		}
	}
}
