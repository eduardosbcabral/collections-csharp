using System;
using System.Collections;

namespace Collections.Standard
{
    public class MyArrayList : ICollection, IEnumerable, IList, ICloneable
    {
        private object[] _array;

        private readonly int _DEFAULT_CAPACITY = 4;

        private int _size;

        public object this[int index]
        {
            get => _array[index];
            set => _array[index] = value;
        }

        public bool IsFixedSize => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public int Count => _size;

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public int Capacity { get; private set; }

        public MyArrayList()
        {
            _array = new object[_DEFAULT_CAPACITY];
            Capacity = _DEFAULT_CAPACITY;
        }

        public MyArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(
                    $"Out of range capacity ({capacity}). " +
                    $"Should be greater than zero.");
            }

            _array = new object[capacity];
            Capacity = capacity;
        }

        public int Add(object value)
        {
            if (_size >= Capacity)
            {
                Array.Resize(ref _array, _size + 1);
                Capacity++;
            }

            _array[_size] = value;
            var filledIndex = _size;
            _size++;
            return filledIndex;
        }

        public void Clear()
        {
            for (var i = 0; i < _size; i++)
            {
                _array[i] = null;
            }

            _size = 0;
        }

        public object Clone()
        {
            var clonedArray = new object[_size];

            for (var i = 0; i < _size; i++)
            {
                clonedArray[i] = _array[i];
            }

            return clonedArray;
        }

        public bool Contains(object value)
        {
            if (value == null)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Argument should not be null.");
            }

            var found = false;

            for (var i = 0; i < _size; i++)
            {
                if (_array[i].Equals(value))
                {
                    found = true;
                }
            }

            return found;
        }

        public void CopyTo(Array array, int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(
                    $"Out of range index ({index}). " +
                    $"Should be greater than zero.");
            }

            if (array == null)
            {
                throw new ArgumentOutOfRangeException(nameof(array), $"Argument should not be null.");
            }

            var arraySize = _size + index;

            var tempArray = new object[arraySize];

            var j = 0;

            for (var i = 0; i < array.Length; i++)
            {
                tempArray[j++] = array.GetValue(i);
            }

            for (var i = 0; i < _size; i++)
            {
                tempArray[index++] = _array[i];
            }

            _size = arraySize;
            Capacity = _size;

            _array = tempArray;
        }

        public IEnumerator GetEnumerator()
        {
            for (var i = 0; i < _size; i++)
            {
                yield return _array[i];
            }
        }

        public int IndexOf(object value)
        {
            if (value == null)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Argument should not be null.");
            }

            var index = -1;

            for (var i = 0; i < _size && index == -1; i++)
            {
                if (_array[i].Equals(value))
                {
                    index = i;
                }
            }

            return index;
        }

        public void Insert(int index, object value)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(
                    $"Out of range index ({index}). " +
                    $"Should be greater than zero.");
            }

            if (value == null)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Argument should not be null.");
            }

            var tempArray = new object[_size + 1];

            for (var i = 0; i <= _size; i++)
            {
                if (i < index)
                {
                    tempArray[i] = _array[i];
                }
                else if (i == index)
                {
                    tempArray[i] = value;
                }
                else
                {
                    tempArray[i] = _array[i-1];
                }
            }

            _size++;
            Capacity = _size;
            _array = tempArray;
        }

        public void Remove(object value)
        {
            if (value == null)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Argument should not be null.");
            }

            var found = false;

            int j = 0;

            for (var i = 0; i < _size; i++)
            {
                if (!_array[i].Equals(value))
                {
                    _array[j++] = _array[i];
                }
                else
                {
                    found = true;
                }
            }

            if (found)
            {
                while (j < _size)
                {
                    _array[j++] = null;
                }

                _size--;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(
                    $"Out of range index ({index}). " +
                    $"Should be greater than zero.");
            }

            var tempArray = new object[_size - 1];

            for (var i = 0; i < _size-1; i++)
            {
                if (i < index)
                {
                    tempArray[i] = _array[i];
                }
                else
                {
                    tempArray[i] = _array[i + 1];
                }
            }

            _size--;
            Capacity = _size;
            _array = tempArray;
        }
    }
}
