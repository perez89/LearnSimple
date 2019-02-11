using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Collections
{
    public class Program
    {
        #region tips
        //System.Collections.SortedList is older, it is from.NET 1.1, back before generics where 
        //supported.System.Collections.Generic.SortedList<TKey, TValue> was introduced with.NET 2.0 and normally should be used instead.
        //Think of them as equivlant to System.Collections.ArrayList vs System.Collections.Generic.List<TValue>.
        #endregion
        static void Main(string[] args)
        {
            Hashset("ola");
            Hashset(1);
            EndProgram();
        }

        private static void EndProgram()
        {
            Console.WriteLine("Fim Programa");
            Console.ReadLine();
        }


        /// <summary>
        /// It is recommended to program to the interface rather than to the class. So, use IDictionary<TKey, TValue> type variable to initialize a dictionary object.
        /// Nao permite inserção concurrente, só leitura
        /// </summary>
        private void Dictionary()
        {
            //Dictionary<int, string> dict = new Dictionary<int, string>();
            IDictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(new KeyValuePair<int, string>(1, "One"));
            dict.Add(new KeyValuePair<int, string>(2, "Two"));

            //The following is also valid
            dict.Add(3, "Three");
          

          
        }

        /// <summary>
        /// ConcurrentDictionary is useful when you need to access a dictionary across multiple threads
        /// permite inserção concurrente
        /// </summary>

        private void ConcurrentDictionary()
        {
            ConcurrentDictionary<int, string> dict = new ConcurrentDictionary<int, string>();

            dict.TryAdd(1, "ola");
        }

        /// <summary>
        /// Hashtable. This optimizes lookups. It computes a hash of each key you add. It then uses this hash code to look up the element very quickly.
        /// Don't use this. It is an older .NET Framework type. It is slower than the generic Dictionary type. But if an old program uses Hashtable, it is helpful to know how to use this type.
        /// First example. We create a Hashtable with a constructor. When it is created, the Hashtable has no values. We directly assign values with the indexer, which uses the square brackets.
        /// </summary>
        private void HashTable()
        {
            Hashtable hashtable = new Hashtable();

            hashtable.Add(4, "quatro");
            hashtable[1] = "One";
            hashtable[2] = "Two";
            hashtable[13] = "Thirteen";

            foreach (DictionaryEntry entry in hashtable)
            {
                Console.WriteLine("{0}, {1}", entry.Key, entry.Value);
            }
        }

        /// <summary>
        /// HashSet. This is an optimized set collection. It helps eliminates duplicate strings or elements in an array. It is a set 
        /// that hashes its contents.
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        private static void Hashset<T>(T obj)
        {
            HashSet<T> hashSet = new HashSet<T>();
            hashSet.Add(obj);
            
            var x = hashSet.GetEnumerator();
            x.MoveNext();
            Console.WriteLine(x.Current);
         
            foreach (var y in hashSet) {
                Console.WriteLine(y);
            }           
        }

        /// <summary>
        /// ArrayList can store items of different data types
        /// An ArrayList resizes automatically as it grows.
        /// The limitation of these collections is that while retrieving items, you need to cast into the appropriate data type, 
        /// otherwise the program will throw a runtime exception. It also affects on performance, because of boxing and unboxing.
        /// To overcome this problem, C# includes generic collection classes in the System.Collections.Generic namespace.
        /// </summary>
        private void ArrayList()
        {
            ArrayList arList = new ArrayList();

            arList.Add(1);
            arList.Add("Two");
            arList.Add(true);
            arList.Add(100.45);
            arList.Add(DateTime.Now);
        }

        /// <summary>
        /// A generic collection gets all the benefit of generics. It doesn't need to do boxing and unboxing while storing or 
        /// retrieving items and so performance is improved.
        /// The List<T> collection is the same as an ArrayList except that List<T> is a generic collection whereas ArrayList 
        /// is a non-generic collection.
        /// List<T> stores elements of the specified type and it grows automatically.
        /// List<T> can store multiple null and duplicate elements.
        /// List<T> can be assigned to IList<T> or List<T> type of variable.It provides more helper method When assigned to List<T> variable
        /// List<T> can be access using indexer, for loop or foreach statement.
        /// LINQ can be use to query List<T> collection.
        /// List<T> is ideal for storing and retrieving large number of elements.
        /// </summary>
        private void ListGeneric()
        {
            //List<int> intList = new List<int>();
            //recommended

            IList<int> intList = new List<int>();
            intList.Add(10);
            intList.Add(20);
            intList.Add(30);
            intList.Add(40);

            IList<string> strList = new List<string>();
            strList.Add("one");
            strList.Add("two");
            strList.Add("three");
            strList.Add("four");
            strList.Add("four");
            strList.Add(null);
            strList.Add(null);


            IList<int> int_List = new List<int>() { 10, 20, 30, 40 };


            IList<int> intList1 = new List<int>();
            intList1.Add(10);
            intList1.Add(20);
            intList1.Add(30);
            intList1.Add(40);

            List<int> intList2 = new List<int>();

            intList2.AddRange(intList1);
        }

        /// <summary>
        /// Internally, SortedList maintains a two object[] array, one for keys and another for values. So when you add key-value pair, 
        /// it does binary search using key to find an appropriate index to store a key and value in respective arrays. It also re-arranges 
        /// the elements when you remove the elements from it.
        /// System.Collections.SortedList is older, it is from .NET 1.1, 
        /// back before generics where supported. System.Collections.Generic.SortedList<TKey, TValue>
        /// </summary>
        private void SortedListGeneric() {
            
            SortedList<int, string> sortedList1 = new SortedList<int, string>();
            sortedList1.Add(3, "Three");
            sortedList1.Add(4, "Four");
            sortedList1.Add(1, "One");
            sortedList1.Add(5, "Five");
            sortedList1.Add(2, "Two");

            SortedList<string, int> sortedList2 = new SortedList<string, int>();
            sortedList2.Add("one", 1);
            sortedList2.Add("two", 2);
            sortedList2.Add("three", 3);
            sortedList2.Add("four", 4);
            // Compile time error: cannot convert from <null> to <int>
            // sortedList2.Add("Five", null);

            SortedList<double, int?> sortedList3 = new SortedList<double, int?>();
            sortedList3.Add(1.5, 100);
            sortedList3.Add(3.5, 200);
            sortedList3.Add(2.4, 300);
            sortedList3.Add(2.3, null);
            sortedList3.Add(1.1, null);

            #region  Example: Initialize SortedList<TKey, TValue>
            SortedList<int, string> sortedList4 = new SortedList<int, string>()
            {
                {3, "Three"},
                {4, "Four"},
                {1, "One"},
                {5, "Five"},
                {2, "Two"}
            };

            //Accessing Generic SortedList
            Console.WriteLine(sortedList2["one"]);
            Console.WriteLine(sortedList2["two"]);
            Console.WriteLine(sortedList2["three"]);

            #endregion

            #region Example: Access Key and Value using indexer
            SortedList<string, int> sortedList5 = new SortedList<string, int>();
            sortedList5.Add("one", 1);
            sortedList5.Add("two", 2);
            sortedList5.Add("three", 3);
            sortedList5.Add("four", 4);

            for (int i = 0; i < sortedList5.Count; i++)
            {
                Console.WriteLine("key: {0}, value: {1}", sortedList5.Keys[i], sortedList5.Values[i]);
            }

       

            #endregion

            #region foreach statement to access generic SortedList:
            SortedList<string, int> sortedList6 = new SortedList<string, int>();
            sortedList6.Add("one", 1);
            sortedList6.Add("two", 2);
            sortedList6.Add("three", 3);
            sortedList6.Add("four", 4);

            foreach (KeyValuePair<string, int> kvp in sortedList6)
                Console.WriteLine("key: {0}, value: {1}", kvp.Key, kvp.Value);
            #endregion

            #region Example: TryGetValue
            SortedList<string, int> sortedList7 = new SortedList<string, int>();
            sortedList7.Add("one", 1);
            sortedList7.Add("two", 2);
            sortedList7.Add("three", 3);
            sortedList7.Add("four", 4);

            int val;

            if (sortedList7.TryGetValue("ten", out val))
                Console.WriteLine("value: {0}", val);
            else
                Console.WriteLine("Key is not valid.");

            if (sortedList7.TryGetValue("one", out val))
                Console.WriteLine("value: {0}", val);
            #endregion
        }


        private void SortedDictionaryGeneric() {
            SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();

            sortedDictionary.Add(3, "Three");
            sortedDictionary.Add(4, "Four");
            sortedDictionary.Add(1, "One");
            sortedDictionary.Add(5, "Five");
            sortedDictionary.Add(2, "Two");

            foreach (var dic in sortedDictionary) {

          
                    Console.WriteLine("key: {0}, value: {1}", dic.Key, dic.Value);
                
            }


            for (int i = 0; i < sortedDictionary.Count; i++)
            {
               // Console.WriteLine("key: {0}, value: {1}", sortedDictionary.[i], sortedDictionary.Values[i]);
            }

        }
    }


}
