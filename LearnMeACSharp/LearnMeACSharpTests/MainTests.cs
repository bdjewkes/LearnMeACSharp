using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LearnMeACSharp;
namespace LearnMeACSharpTests
{
    [TestClass]
    public class MainTests
    {
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
            Assert.AreEqual(new int[]{2,2,3,3}, FunctionMagic.DuplicateUniques(a,b));   
        }

    }
}
