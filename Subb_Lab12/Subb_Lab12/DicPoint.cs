using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subb_Lab12
{
    // Class of the Hash-table elements.
    class DicPoint<K, T>
    {
        // Element's value.
        public T value;
        // Key
        public K key;
        // Next element with the same hash-code.
        public DicPoint<K, T> next;

        // Constructor with a T parameter.
        public DicPoint(K key, T ob)
        {
            value = ob;
            this.key = key;
            next = null;
        }

        public static bool operator ==(DicPoint<K, T> ob1, DicPoint<K, T> ob2)
        {
            bool equal = false;
            if (ob1.value.Equals(ob2.value) && ob1.key.Equals(ob2.key))
                equal = true;

            return equal;
        }

        public static bool operator !=(DicPoint<K, T> ob1, DicPoint<K, T> ob2)
        {
            bool unequal = false;
            if (ob1.value.Equals(ob2.value) || ob1.key.Equals(ob2.key))
                unequal = true;

            return unequal;
        }
    }
}
