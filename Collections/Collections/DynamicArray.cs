using System;
using System.Collections.Generic;
using System.Text;


namespace Collections
{
    internal class DynamicArray<T>
    {
        private const int V = 0;
        private T[] _array;
        private int _length;
        public int Lenght { get { return _length; } }
        public int Capacity { get { return _array.Length; } }

        public DynamicArray()
        {
            _array = new T[8];
            _length = 0;
        }

        public DynamicArray(int length)
        {
            _array = new T[length];
            _length = 0;
        }
        public DynamicArray(T[] array)
        {
            _array = (T[])array.Clone();
            _length = array.Length;

        }
        //Index
        public T this[int i]
        {
            get
            {
                if (i >= _length)
                {
                    throw new ArgumentOutOfRangeException($"Position is outside array  - Lenght: {_length} Position: {i}");
                }
                else
                {
                    return _array[i];
                }

            }
            set
            {
                _array[i] = value;
            }
        }
        public override string ToString()
        {

            return string.Join(" ", _array);
        }
        public void Add(T item)
        {
            if (Capacity <= _length)
            {
                var temparray = new T[Capacity * 2];
                _array.CopyTo(temparray, 0);
                _array = temparray;
            }
            _array[_length] = item;
            _length++;
        }
        public void AddRange(T[] range)
        {
            var temparray = new T[_length + range.Length];
            Array.Copy(_array, 0, temparray, 0, _length);
            Array.Copy(range, 0, temparray, _length, range.Length);
            _array = temparray;
            _length = _length + range.Length;
        }
        public bool Remove(T item)
        {
            for (int i = 0; i < _length; i++)
            {
                if (_array[i].Equals(item))
                {
                    int position = i + 1;
                    if (position < _length)
                    {
                        var temparray = new T[Capacity];
                        Array.Copy(_array, 0, temparray, 0, position);
                        Array.Copy(_array, temparray, Lenght - 1);
                        _array = temparray;
                    }
                    _length--;
                    return true;
                }
            }
            return false;
        }

        public void Insert(T item, int position)
        {
            for (int i = 0; i < _length; i++)
            {
                if (position >= _length)
                {
                    throw new ArgumentOutOfRangeException($"Position is outside array  - Lenght: {_length} Position: {position}");

                }

                if (position == i)
                {
                    var temparray = new T[Capacity + 1];
                    Array.Copy(_array, 0, temparray, 0, position);
                    temparray[i] = item;
                    Array.Copy(_array, position, temparray, position + 1, _length - position);
                    _array = temparray;
                    _length++;
                }


            }
        }
        public void UseIndex(T item, int position)
        {

        }

        public void Sort(Func<T, T, bool> comparator)
        {
            for (int i = 0; i < _length; i++)
            {
                for (int j = i + 1; j < _length; j++)
                {
                    if (comparator(_array[i], _array[j]))
                    {
                        var ctemp = _array[i];
                        _array[i] = _array[j];
                        _array[j] = ctemp;
                    }
                }
            }
        }
        public Dictionary<int, T> Split(Func<T, T, bool> condition)
        {
            if (_length % 2 == 1)
            {
                throw new TeamException("Impossible to devide into equal team");
            }
            var teams = new Dictionary<int, T>();
            for (int i = 0; i < _length - 1; i++)
            {
                if (teams.ContainsKey(i)) continue;
                for (int j = i + 1; j < _length; j++)
                {
                    if (teams.ContainsKey(j)) continue;
                    if (condition(_array[i], _array[j]))
                    {
                        teams.Add(i, _array[i]);
                        teams.Add(j, _array[j]);
                        break;
                    }
                }
            }
            return teams;
        }
    }
}
