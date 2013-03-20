using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnMeACSharp
{
    public static class FunctionMagic
    {
        public static int AddOneToAllAndSum(IEnumerable<int> input){
            int sum = input.Select(x => 1+x).Sum();
            return sum;
        }
        //public static Dictionary<T, R> CouplePairs<T, R>(T aSet, R bSet)
        //{
        //    //You want to use System
        //    throw new System.NotImplementedException();
        //}
    }
}
