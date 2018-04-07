using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subb_Lab12
{
    // My collection – dictionary (hash-table).
    class MyDictionary<K, T>
    {
        // Array of the DicPoint elements (hash-table).
        DicPoint<K, T>[] table;

        // The hash-table capacity.
        int capacity;
        public int Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Capacity can not be negative!");
                    capacity = 0;
                }
                else
                    capacity = value;
            }
        }

        // The hash-table count.
        int count;
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Count can not be negative!");
                    count = 0;
                }
                else
                    count = value;
            }
        }

        // All the keys in a dictionary.
        K[] keys;
        public K[] Keys
        {
            get
            {
                return keys;
            }
            set
            {
                keys = new K[value.Length];
                for (int i = 0; i < value.Length; i++)
                    keys[i] = value[i];
            }
        }

        // All the values in a dictionary (object because it is actually AbstrState).
        T[] values;
        public T[] Values
        {
            get
            {
                return values;
            }
            set
            {
                values = new T[value.Length];
                for (int i = 0; i < value.Length; i++)
                    values[i] = value[i];
            }
        }


        // Constructor without parameters.
        public MyDictionary()
        {
            // Initital capacity is 100.
            table = new DicPoint<K, T>[100];
            Capacity = 100;
            Count = 0;
            Keys = null;
            Values = null;
        }
        // Constructor with a capacity parameter.
        public MyDictionary(int capacity)
        {
            table = new DicPoint<K, T>[capacity];
            this.Capacity = capacity;
            Count = 0;
            Keys = null;
            Values = null;
        }
        // Constructor with a MyDictionary object parameter.
        public MyDictionary(MyDictionary<K, T> dic)
        {
            table = new DicPoint<K, T>[dic.table.Length];
            for (int i = 0; i < dic.table.Length; i++)
            {
                this.table[i] = dic.table[i];
            }

            for (int i = 0; i < dic.Keys.Length; i++)
            {
                this.Keys[i] = dic.Keys[i];
            }

            for (int i = 0; i < dic.Values.Length; i++)
            {
                this.Values[i] = dic.Values[i];
            }

            Capacity = dic.capacity;
            Count = dic.count;
        }

        // Checks whether there is such key (parameter) or not.
        public bool ContainsKey(object key)
        {
            bool contains = false;
            for (int i = 0; i < this.Keys.Length; i++)
            {
                if (this.Keys[i].Equals((K)key))
                {
                    contains = true;
                    break;
                }
            }

            return contains;
        }

        // Checks whether there is such value (parameter) or not.
        public bool ContainsValue(object value)
        {
            bool contains = false;
            for (int i = 0; i < this.Values.Length; i++)
            {
                if (this.Values[i].Equals((T)value))
                {
                    contains = true;
                    break;
                }
            }

            return contains;
        }

        // Adds an element to the dictionary.
        public bool Add(object key, object value)
        {
            // Creating an object with wanted key and value.
            DicPoint<K, T> dicPointBuffer = new DicPoint<K, T>((K)key, (T)value);

            // Getting index.
            int index = GetIndex(key);

            // If there are no objects with this index.
            if (table[index] == null)
            {
                table[index] = (DicPoint<K, T>)value;
            }
            else
            {
                // The first object in the list of this index.
                DicPoint<K, T> current = table[index];

                // If there is the same object.
                if (current == dicPointBuffer)
                    return false;

                // Finding the end of the list or the same object.
                while (current.next != null)
                {
                    if (current == dicPointBuffer)
                        return false;
                    current = current.next;
                }

                // Adding the element to the table.
                current.next = dicPointBuffer;
            }

            // Adding the key and the value to the arrays and increasing the count.
            AddKey((K)key);
            AddValue((T)value);
            Count++;

            return true;
        }

        // Getting the index of the adding element.
        public int GetIndex(object key)
        {
            // Necessary constant (random 0 < A < 1).
            double A = 0.12837912;

            // Creating the index.
            int index = (int)Math.Truncate(Count * (((int)key * A) % 1));

            return index;
        }

        // Additional function to add an element to the array of keys.
        public void AddKey(K key)
        {
            K[] buf = new K[Keys.Length + 1];

            for (int i = 0; i < Keys.Length; i++)
            {
                buf[i] = Keys[i];
            }
            buf[buf.Length] = key;

            Keys = buf;
        }

        // Additional function to add an element to the array of values.
        public void AddValue(T value)
        {
            T[] buf = new T[Values.Length + 1];

            for (int i = 0; i < Keys.Length; i++)
            {
                buf[i] = Values[i];
            }
            buf[buf.Length] = value;

            Values = buf;
        }

        // Clear the dictionary.
        public void Clear()
        {
            table = new DicPoint<K, T>[100];
            Capacity = 100;
            Count = 0;
            Keys = null;
            Values = null;
        }

        // Clone the dictionary.
        public MyDictionary<K,T> Clone()
        {
            MyDictionary<K, T> buf = this;
            return buf;
        }

        // Removing an object with the wanted value (parameter).
        public bool Remove(object value)
        {
            // Index of the element.
            int index = -1;

            // Getting the index.
            for(int i = 0; i < Values.Length; i++)
            {
                if(Values[i].Equals((T)value))
                {
                    index = i;
                    break;
                }
            }

            // If the elemet exists.
            if (index > -1)
            {
                DicPoint<K, T> current = table[index];

                // IF it's the first in the list.
                if (current.value.Equals((T)value))
                    table[index] = null;
                else
                {
                    // Looking till the end of the list.
                    while (current.next != null)
                    {
                        // If found.
                        if (current.next.value.Equals((T)value))
                        {
                            current.next = current.next.next;
                            return true;
                        }

                        current = current.next;
                    }
                }

                return true;
            }
            else
                return false;
        }
    }
}
