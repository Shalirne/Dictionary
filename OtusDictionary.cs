using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class OtusDictionary
    {
        private static int _count = 32;
        private string[] _storage = new string[_count];
        private bool _examinationTrue;
        public void Add(int key, string value)
        {
            foreach (var item in _storage)
            {
                if (item == null)
                {
                    _examinationTrue = false;
                }
            }
            if (_examinationTrue == true)
            {
                throw new OccupancyException("Массив заполнен");
            }
            _examinationTrue = true;
            int hash = key % 32;
            if (_storage[hash] == null)
            {
                _storage[hash] = value;
            }
            else
            {
                if (_storage[hash] != value)
                {
                    _count = _count * 2;
                    Resize(key, value);
                }
                else
                {
                    _storage[hash] = value;
                }
            }
        }
        public string Get(int key)
        {
            Console.WriteLine($"Под индексом {key} находится {_storage[key]}");
            return _storage[key];
        }
        public void Resize(int key, string value)
        {
            string[] storage1 = new string[_count];
            for (int i = 0; i < _storage.Length; i++)
            {
                if (_storage[i] != null)
                {
                    int hash1 = i % storage1.Count();
                    storage1[hash1] = _storage[i];
                }
            }
            _storage = storage1;
            Add(key, value);
        }
    }
}
