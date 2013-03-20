using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnMeACSharp
{
    public class ListStack<T>
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
    
    
    
    
    public class Stack<T>
    {
        int position = 0;
        T[] array = new T[10];
        public void Push(T x)
        {
            if (array.Length>=position){int pos2=position*2; 
                Array.Resize(ref array, position*2);
            }
            array[position] = x;
            position++;
        }
        public T Pop()
        {
            position--;
            T popped = array[position];
            return popped;

        }
        public int Count { get {return position+1;} }
            

    }




}
