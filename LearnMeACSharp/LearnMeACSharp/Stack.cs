using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnMeACSharp
{
    public class Stack<T>
    {
       List<T> list = new List<T>();

       public void Push(T x){
            list.Add(x);
       }
       public T Pop(){
           T x = list[list.Count() - 1];
           list.Remove(x);
           return x;
       }
       public int Count
       {
           get { return list.Count(); }
       }
                    
    }
}
