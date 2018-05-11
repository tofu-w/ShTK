using System;
using System.Collections.Generic;

namespace ShTK.Utils
{
    /// <summary>
    /// Sifting can be defined as when an object has just exited the queue and has entered the list
    /// </summary>
    /// <param name="t"></param>
    public delegate void OnSiftItem(Object o);

    /// <summary>
    /// Basically just me cramming a list and a stack together and seeing what happens
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Lazylist <T> : IDisposable
    {
        Type type => typeof(T);
        
        public List<T> List = new List<T>();
        private Stack<T> ListQueue = new Stack<T>();

        public OnSiftItem OnSiftItem;
            
        public Lazylist()
        {
        }

        /// <summary>
        /// Pushes <paramref name="t"/> to the <see cref="ListQueue"/> 
        /// stack and attempts to add it to <see cref="List"/>
        /// </summary>
        /// <param name="t"></param>
        public void Push (T t)
        {
            ListQueue.Push(t);
        }

        /// <summary>
        /// Goes through all the entires in the <see cref="ListQueue"/> and 
        /// adds them to the <see cref="List"/>
        /// </summary>
        /// <param name="reciprocate">Should all the new entries be added in the correct order or 
        /// preserved in a first in last out stack order? True by default</param>
        public void SiftQueue(bool reciprocate = true)
        {
            List<T> list = new List<T>();

            //Clearing the stack and adding to list
            while (ListQueue.Count > 0)
            {
                list.Add(ListQueue.Pop());
            }

            //reciprocates only if true useful for preserving order, occurs by default
            if (reciprocate)
                list.Reverse();

            //Adds list in the order it was given
            foreach (var c in list)
            {
                List.Add(c);
                OnSiftItem?.Invoke(c);
            }
        }

        public string GetTypeAsString()
        {
            return type.GetType().ToString();
        }

        public void Dispose()
        {
            List.Clear();
            ListQueue.Clear();
            GC.SuppressFinalize(this);
        }
    }
}
