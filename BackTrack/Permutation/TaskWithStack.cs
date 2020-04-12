using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Permutation
{
    delegate void PrintPermutationWWithStack(Stack<string> result);

    class TaskWithStack
    {
        public event PrintPermutationWWithStack Printing;

        private readonly string[] _array;
        private readonly int _arrayLength;

        public TaskWithStack(string[] array)
        {
            _array = array;
            _arrayLength = array.Length;
        }

        public void Start()
        {
            Permutate(new Stack<string>());
        }

        private void Permutate(Stack<string> tempStack)
        {
            
            if (tempStack.Count == _arrayLength)
            {
                // call print event.
                Printing?.Invoke(tempStack);
                return;
            }

            foreach (var item in _array)
            {
                if (tempStack.Contains(item))
                {
                    continue;
                }
                tempStack.Push(item);
                Permutate(tempStack);
                tempStack.Pop();
            }
        }
    }
}
