using System;
using System.Collections.Generic;

namespace ShTK.Utils
{
    /// <summary>
    /// Basically just me cramming a list and a stack together and seeing what happens
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Lazylist <T> : IDisposable
    {
        Type type => typeof(T);

        List<T> List = new List<T>();
        Stack<T> ListQueue = new Stack<T>();

        /// <summary>
        /// Sifting can be defined as when an object has just exited the queue and has entered the list
        /// </summary>
        /// <param name="t"></param>
        public delegate void OnSiftItem(Object o);
            
        //gay
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
            if (t.GetType() == type)
            {
                ListQueue.Push(t);
            }
            else
            {
                throw new Exception($"Cannot parse type {t.GetType()} to {type} to add it to the queue.");
            }
        }

        /// <summary>
        /// Goes through all the entires in the <see cref="ListQueue"/> and 
        /// adds them to the <see cref="List"/>
        /// </summary>
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
