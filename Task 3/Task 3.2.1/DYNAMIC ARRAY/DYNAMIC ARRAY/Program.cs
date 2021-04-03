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
            set
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
            if(length > 0)
            { 
                Capacity = length;
                mass = new T[Capacity];
            }
            else
            {
                Console.WriteLine("The capacity must be greater than 0");
                Console.ReadLine();
                Process.GetCurrentProcess().Kill();
            }
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
                if((index < -_length) || (index >= _length))
                {
                    throw new ArgumentOutOfRangeException();
                }
                else if(index < 0)
                {
                    return mass[_length + index];
                }
                else
                {
                    return mass[index];
                }
            }
            set 
            {
                if ((index < -_length) || (index >= _length))
                {
                    throw new ArgumentOutOfRangeException();
                }
                else if (index < 0)
                {
                    mass[_length + index] = value;
                }
                else
                {
                    mass[index] = value;
                }
            }
        }

        public void Add(T objct)
        {
            if (_capacity == _length)
            {
                _capacity *= 2;
                Array.Resize(ref mass, _capacity);
            }

            mass[_length] = objct;
            _length++;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            if(collection != null)
            {
                bool needMoreSize = false;

                while(_capacity < collection.Count() + _length)
                {
                    _capacity *= 2;
                    needMoreSize = true;
                }

                if (needMoreSize)
                {
                    Array.Resize(ref mass, _capacity);
                }

                collection.ToArray().CopyTo(mass, _length);
                _length += collection.Count();
            }
            else
            {
                Console.WriteLine("Вы пытаетесь добавить пустые элементы!");
            }
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
                    if(_capacity == _length)
                    {
                        _capacity *= 2;
                        Array.Resize(ref mass, _capacity);
                    }

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
