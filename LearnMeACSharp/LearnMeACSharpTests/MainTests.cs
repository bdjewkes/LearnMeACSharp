#define LIVE

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LearnMeACSharp;
using System.Linq;
namespace LearnMeACSharpTests
{
    [TestClass]
    public class MainTests
    {
        [TestMethod]
        public void AddTest()
        {
            var controlList = new System.Collections.Generic.List<int>();
            System.Collections.Generic.IList<int> testList =
#if LIVE
            new MyList<int>();
#else
            new System.Collections.Generic.List<int>();
#endif
            var r = new System.Random();
            for (int i = 0; i < 1000; i++)
            {
                var next = r.Next();
                controlList.Add(next);
                testList.Add(next);
                Assert.AreEqual(controlList.Count, testList.Count);
            }

        }

        [TestMethod]
        public void AddIndexAndValueCheckTest()
        {
            System.Collections.Generic.IList<int> testList =
#if LIVE
            new MyList<int>();
#else
            new System.Collections.Generic.List<int>();
#endif
            var controlList = new System.Collections.Generic.List<int>();
            var r = new System.Random();
            for (int i = 0; i < 1000; i++)
            {
                var next = r.Next();
                controlList.Add(next);
                testList.Add(next);
                Assert.AreEqual(controlList.Count, testList.Count);
            }
            for (int i = 0; i < 1000; i++)
            {
                Assert.IsTrue(testList.IndexOf(controlList[i]) == i);
            }

        }
        [TestMethod]
        public void AddAndRemoveAtTest()
        {
            var controlList = new System.Collections.Generic.List<int>();
            System.Collections.Generic.IList<int> testList =
#if LIVE
            new MyList<int>();
#else
            new System.Collections.Generic.List<int>();
#endif
            var r = new System.Random();
            for (int i = 0; i < 1000; i++)
            {
                var next = r.Next();
                controlList.Add(next);
                testList.Add(next);
                Assert.AreEqual(controlList.Count, testList.Count);
            }
            for (int i = 0; i < controlList.Count; i++)
            {
                if (r.Next() < int.MaxValue / 2)
                {
                    testList.RemoveAt(i);
                    controlList.RemoveAt(i);
                }
            }
            Assert.AreEqual(testList.Count, controlList.Count);
            for (int i = 0; i < controlList.Count; i++)
            {
                Assert.IsTrue(testList.IndexOf(controlList[i]) == i);
            }

        }
        [TestMethod]
        public void ListTest()
        {
            ListRNDTest();
            DateTime start = DateTime.Now;
            for (int i = 0; i < 100; i++)
            {
                ListRNDTest();
            }
            Assert.IsTrue((DateTime.Now - start).Duration() < TimeSpan.FromMilliseconds(3000));
        }
        public void ListRNDTest()
        {
            System.Collections.Generic.IList<int> testList =
#if LIVE
            new MyList<int>();
#else
            new System.Collections.Generic.List<int>();
#endif
            var controlList = new System.Collections.Generic.List<int>();
            var r = new System.Random();
            for (int i = 0; i < 1000; i++)
            {
                var next = r.Next();
                controlList.Add(next);
                testList.Add(next);
                Assert.AreEqual(controlList.Count, testList.Count);
            }
            for (int i = 0; i < 1000; i++)
            {
                Assert.IsTrue(testList.IndexOf(controlList[i]) == i);
            }
            for (int i = 0; i < controlList.Count; i++)
            {
                if (r.Next() < int.MaxValue / 2)
                {
                    testList.RemoveAt(i);
                    controlList.RemoveAt(i);
                }
                else
                {
                    var newItem = r.Next();
                    testList.Insert(i, newItem);
                    controlList.Insert(i, newItem);
                }
            }
            Assert.AreEqual(controlList.Count, testList.Count);


            foreach (var itm in controlList){
                Assert.IsTrue(testList.Contains(itm));    
            }
            for (int i = 0; i < controlList.Count / 2; i++ )
            {
                var e = controlList[i];
                controlList.Remove(e);
                testList.Remove(e);
            }
            Assert.AreEqual(controlList.Count, testList.Count);

            int[] controllarray = new int[controlList.Count+1];
            int[] testArray = new int[testList.Count+1];
            controllarray[0] = r.Next();
            testArray[0] = controllarray[0];
            controlList.CopyTo(controllarray, 1);
            testList.CopyTo(testArray, 1);

            var q = from a in testArray
                    join b in controllarray on a equals b
                    select a;


            Assert.IsTrue(testArray.Length == controllarray.Length && q.Count() == controllarray.Length);
            controlList.Clear();
            testList.Clear();
            Assert.AreEqual(controlList.Count,testList.Count);
        }

        [TestMethod]
        public void StackTest()
        {
            Stack<int> s = new Stack<int>();
            Assert.AreEqual(s.Count, 0);
            var x = new Random().Next();
            s.Push(x);
            s.Push(2);
            s.Push(3);
            Assert.AreEqual(s.Count, 3);
            Assert.AreEqual(s.Pop(), 3);
            s.Pop();
            Assert.AreEqual(s.Pop(), x);
            Assert.AreEqual(s.Count, 0);

            Stack<string> strStck = new Stack<string>();
            var testString = "hi there";
            strStck.Push(testString);
            Assert.AreEqual(testString, strStck.Pop());

            Stack<Object> bigStack = new Stack<Object>();
            for (int i = 0; i < 10000; i++)
            {
                bigStack.Push(new Object());
            }
            Assert.AreEqual(10000, bigStack.Count);
        }
        [TestMethod]
        public void FunctionTest()
        {
            int[] t = {1,2,3,4};
            Assert.AreEqual(FunctionMagic.AddOneToAllAndSum(t), 14);   
        }
        public void DuplicateUniqueTest()
        {
            int[] a = { 1, 2, 3 };
            int[] b = { 2, 3, 4 };
            Assert.AreEqual(new int[]{1,1,4,4}, FunctionMagic.DuplicateUniques(a,b));

            int[] c = { 1, 2, 3, 4, 5, 7, 8, 10 };
            int[] d = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Assert.AreEqual(new int[] {6, 6, 9, 9 }, FunctionMagic.DuplicateUniques(a, b));   
 
        }
        public void MultiplyByTest()
        {
            Assert.AreEqual(1,FunctionMagic.MultiplyBy(1)(1));
            Assert.AreEqual(4, FunctionMagic.MultiplyBy(2)(2));
            Assert.AreEqual(15, FunctionMagic.MultiplyBy(5)(3));

        }
    }
}
