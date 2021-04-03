using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DYNAMIC_ARRAY
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class DynamicArray<T> : IEnumerable<T>, IEnumerable
    {
        private T[] mass;
        private int _capacity = 8;
        private int _length = 0;
        protected T[] Mass { get => mass; }
        public int Length { get => _length; }

        public int Capacity
        {
            get
            {
                return _capacity;
            }
            private set
            {
                if (value > 0)
                {
                    _capacity = value;

                    Array.Resize(ref mass, Capacity);
                }
            }
        }


        public DynamicArray()
        {
            mass = new T[8];
        }

        public DynamicArray(int length)
        {
            if(length < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            Capacity = length;
            mass = new T[Capacity];
        }

        public DynamicArray(IEnumerable<T> collection) : this(collection.Count())
        {
            if(collection != null)
            {
                mass = collection.ToArray();

                _length = mass.Count();
            }
        }

        public T this[int index]
        {
            get
            {
                if ((index < 0) || (index >= _length))
                {
                    throw new ArgumentOutOfRangeException();
                }

                return mass[index];

            }
            set
            {
                if ((index < 0) || (index >= _length))
                {
                    throw new ArgumentOutOfRangeException();
                }

                mass[index] = value;

            }
        }

        public void TryChangeCapacity(int newLength)
        {
            if(newLength <= _capacity)
            {
                return;
            }

            while (_capacity < newLength)
            {
                _capacity *= 2;
            }

            Array.Resize(ref mass, _capacity);
        }

        public void Add(T objct)
        {
            TryChangeCapacity(_length + 1);

            mass[_length] = objct;
            _length++;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            int newLength = _length + collection.Count();

            TryChangeCapacity(newLength);

            collection.ToArray().CopyTo(mass, _length);
            _length = newLength;
        }

        public bool Remove(T item)
        {
            try
            {
                int index = Array.FindIndex(mass, 0, Length, element => element.Equals(item));
                if (index != -1)
                {
                    Array.Copy(mass, index + 1, mass, index, Length - index - 1);
                    _length--;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Insert(int position, T item)
        {
            if ((position < 0) || (position > _length))
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                try
                {
                    TryChangeCapacity(_length + 1);

                    Array.Copy(mass, position, mass, position + 1, _length - position);
                    mass[position] = item;
                    _length++;

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _length; i++)
            {
                yield return mass[i];

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
