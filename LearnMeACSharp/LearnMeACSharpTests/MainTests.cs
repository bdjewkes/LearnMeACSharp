using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LearnMeACSharp;
namespace LearnMeACSharpTests
{
    [TestClass]
    public class MainTests
    {
        [TestMethod]
        public void TestMethod1()
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
        }
    }
}
