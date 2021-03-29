using System;
using System.Collections;
using System.Collections.Generic;

namespace WEAKEST_LINK
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Укажите число игроков: ");

            int players = int.Parse(Console.ReadLine());

            CirclePeople<int> circlePeople = new CirclePeople<int>();

            for (int i = 1; i <= players; i++)
            {
                circlePeople.Add(i);
            }

            circlePeople.DeleteSecondPlayer();
            circlePeople.ShowDisply();

            Console.ReadLine();

        }
    }

    public class CirclePeople<T> : ICollection<T>
    {
        private List<T> _list;

        private int _roundCount = 1;

        public CirclePeople()
        {
            _list = new List<T>();
        }

        public int Count => _list.Count;

        public bool IsReadOnly => false;


        public void DeleteSecondPlayer()
        {
            bool delete = false;
            for (int i = 0; _list.Count > 1; i++)
            {
                if(i == _list.Count)
                {
                    i = -1;
                    continue;
                }
                if(i > _list.Count)
                {
                    i = -1;
                    continue;
                }
                if (!delete)
                {
                    delete = !delete;
                    continue;
                }
                _list.RemoveAt(i);
                delete = !delete;
                i--;
                Console.WriteLine($"Раунд {_roundCount} завершён. Осталось людей: {_list.Count}.");
            }
        }

        public void ShowDisply()
        {
            foreach (var item in _list)
            {
                Console.WriteLine(item);
            }
        }

        public void Add(T item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
