using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Permutation
{
    delegate void PrintPermutationWithSwap(string[] result);

    class TaskWithSwap
    {
        public event PrintPermutationWithSwap Printing;

        private readonly string[] _array;
        private readonly int _arrayLength;

        public TaskWithSwap(string[] array)
        {
            _array = array;
            _arrayLength = array.Length;
        }

        public void Start()
        {
            Permutate(0);
        }

        private void Permutate(int position)
        {
            if (position == _arrayLength)
            {
                Printing?.Invoke(_array);
                return;
            }

            for (int i = position; i < _arrayLength; i++)
            {
                Swap(i, position);
                Permutate(position +1);
                Swap(i, position);
            }
        }

        private void Swap(int loopI, int position)
        {
            string temp = _array[loopI];
            _array[loopI] = _array[position];
            _array[position] = temp;
        }

    }
}
