using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanNgocKimCuong_HW06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Phan Ngọc Kim Cương - 2175475");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("EXCERCISE 6.2");
            Console.WriteLine();
            var r = new Rectangle(3,4.5);
            Console.WriteLine("Rectangle H:{0} W:{1} Area:{2}",r.Height,r.Weight,r.Area);
            var s = new Square(5);
            Console.WriteLine("Square H:{0} W:{1} Area:{2}",s.Height,s.Weight,s.Area);
            var c = new Circle(2.5);
            Console.WriteLine("Circle H:{0} W:{1} Area:{2}", c.Height, c.Weight, c.Area);
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("DESTRUCTOR");
            Console.WriteLine();
            Third t = new Third();
            Console.WriteLine("Da em hong biet sao ma destructor cua em hong lên a :(((((. Mac du em viet y chang huong dan :(( huhuhu");
            Console.WriteLine("------------------------------------------------------------");
            // generic 2.1
            Console.WriteLine("GENERIC");
            Console.WriteLine();
            var entry = new KeyValue<int, string>(0123456787, "ABC");

            int phone = entry.Key;
            string name = entry.Value;

            Console.WriteLine($"Phone = {phone} / name = {name}");

            Console.WriteLine("------------------------------------------------------------");
            // generic 2.2
            var entryA = new PhoneNameEntry(0123456789, "Kim Cuong");

            phone = entryA.Key;
            name = entryA.Value;

            Console.WriteLine($"Phone = {phone} / name = {name}");

            Console.WriteLine("------------------------------------------------------------");
            // generic 2.3
            var entryB = new StringAndValueEntry<String>("2175475", "Kim Cuong");

            string empNumber = entryB.Key;
            string empName = entryB.Key;

            Console.WriteLine($"Emp Number = {empNumber}");
            Console.WriteLine($"Emp Name = {empName}");

            Console.WriteLine("------------------------------------------------------------");
            // generic 2.4
            try
            {
                (new GenericInterfaceImpl<string>()).DoSomething();
            }
            catch (MyException<string> e)
            {
                Console.WriteLine("Catch ex");
            }

            Console.WriteLine("------------------------------------------------------------");
            // generic 2.5
            var entry1 = new KeyValue<int, String>(2175475, "Kim Cuong");
            var entry2 = new KeyValue<int, String>(2171234, "ABC");

            phone = MyUtils.GetKey(entry1);
            Console.WriteLine($"Phone = {phone}");

            var list = new List<KeyValue<int, string>>();
            list.Add(entry1);
            list.Add(entry2);

            var firstEntry = MyUtils.GetFirstElement(list, null);
            if (firstEntry != null) Console.WriteLine($"Value = {firstEntry.Value}");

            Console.WriteLine("------------------------------------------------------------");
            // generic 2.6
            MyException<int> exc = MyUtils.DoSomeThing<MyException<int>>();
            exc = MyUtils.DoDefault<MyException<int>>();
            Shape[] shapes = MyUtils.CreateArray<Circle>(10);

            // generic 2.6
            GenericArrayExample.Run();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            
        }
        class KeyValue<K, V>
        {
            public K Key { get; set; }

            public V Value { get; set; }

            public KeyValue() { }

            public KeyValue(K key, V value)
            {
                Key = key;
                Value = value;
            }
        }
        class PhoneNameEntry : KeyValue<int, string>
        {
            public PhoneNameEntry(int key, string value) : base(key, value) { }
        }

        class StringAndValueEntry<V> : KeyValue<string, V>
        {
            public StringAndValueEntry() { }

            public StringAndValueEntry(string key, V value)
                : base(key, value) { }
        }

        class KeyValueInfo<K, V, I> : KeyValue<K, V>
        {

            public I info { get; set; }

            public KeyValueInfo(K key, V value)
                : base(key, value) { }

            public KeyValueInfo(K key, V value, I info)
                : base(key, value) => this.info = info;
        }


        interface GenericInterface<G>
        {
            G DoSomething();
        }

        class GenericInterfaceImpl<G> : GenericInterface<G>
        {
            public G something { get; set; }

            public G DoSomething() => throw new MyException<G>();
        }

        class MyException<E> : ApplicationException
        { }

        class MyUtils
        {
            public static K GetKey<K, V>(KeyValue<K, V> entry) => entry.Key;

            public static V GetValue<K, V>(KeyValue<K, V> entry) => entry.Value;

            public static E GetFirstElement<E>(List<E> list, E defaultValue) => (list == null || list.Count == 0) ? defaultValue : list[0];

            // Generic Init Example
            public static T DoSomeThing<T>()
                where T : new() => new T();

            public static K ToDoSomeThing<K>()
                where K : KeyValue<K, string>, new() => new K();

            public static T DoDefault<T>() => default(T);

            public static T[] CreateArray<T>(int size) => new T[size];
        }

        class GenericArrayExample
        {
            public static T[] FilledArray<T>(T value, int count)
            {
                T[] ret = new T[count];
                for (int i = 0; i < count; i++) ret[i] = value;
                return ret;
            }

            public static void Run()
            {
                string value = "Hello Teacher !!!";
                string[] filledArray = FilledArray<string>(value, 5);

                foreach (string s in filledArray) Console.WriteLine(s);
            }
        }
    }
}
