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

        public static int[] DuplicateUniques(IEnumerable<int> a,IEnumerable<int> b){
            //You'll need SelectMany, and some of these http://msdn.microsoft.com/en-us/library/bb546153.aspx
            //You probably also need ToArray to satisfy the signature
            throw new System.NotImplementedException();
        }
            
    }
    
}
