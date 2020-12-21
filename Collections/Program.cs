using System;

using StandardC = System.Collections;
using Generic = System.Collections.Generic;
using Concurrent = System.Collections.Concurrent;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            StandardC.ArrayList standardArrayList = new StandardC.ArrayList();
            StandardC.Hashtable standardHashtable = new StandardC.Hashtable();
            StandardC.Queue standardQueue = new StandardC.Queue();
            StandardC.Stack standardStack = new StandardC.Stack();

            Generic.Dictionary<int, string> genericDictionary = new Generic.Dictionary<int, string>();
            Generic.List<int> genericList = new Generic.List<int>();
            Generic.Queue<int> genericQueue = new Generic.Queue<int>();
            Generic.SortedList<int, string> genericSortedList = new Generic.SortedList<int, string>();
            Generic.Stack<int> genericStack = new Generic.Stack<int>();

            Concurrent.BlockingCollection<int> concurrentBlockingCollection = new Concurrent.BlockingCollection<int>();
            Concurrent.ConcurrentDictionary<int, string> concurrentDictionary = new Concurrent.ConcurrentDictionary<int, string>();
            Concurrent.ConcurrentQueue<int> concurrentQueue = new Concurrent.ConcurrentQueue<int>();
            Concurrent.ConcurrentStack<int> concurrentStack = new Concurrent.ConcurrentStack<int>();

            Console.WriteLine("Hello World!");
        }
    }
}
