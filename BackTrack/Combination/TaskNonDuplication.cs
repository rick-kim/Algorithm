using System;
using System.Collections.Generic;
using System.Text;

namespace Combination
{
    class TaskNonDuplication<T>
    {
        internal delegate void PrintResult(Stack<T> resultStack);

        public event PrintResult OnPrint;

        private readonly List<T> _taskList;
        private readonly Stack<T> _tempStack;
        public TaskNonDuplication(List<T> taskList)
        {
            _taskList = taskList;
            _tempStack = new Stack<T>();
        }

        public void Start(int combinationCount, int? position = null)
        {
            if (position == null)
            {
                Combine(combinationCount);
            }
            else
            {
                Combine((int)position, combinationCount);
            }

        }

        private void Combine(int combinationCount)
        {
            if (_tempStack.Count == combinationCount)
            {
                OnPrint?.Invoke(_tempStack);
                return;
            }

            foreach (var item in _taskList)
            {
                if (_tempStack.Contains(item))
                {
                    return;
                }
                _tempStack.Push(item);
                Combine(combinationCount);
                _tempStack.Pop();
            }
        }

        private void Combine(int position, int combinationCount)
        {
            if (_tempStack.Count == combinationCount)
            {
                OnPrint?.Invoke(_tempStack);
                return;
            }

            for (int i = position; i < _taskList.Count; i++)
            {
                _tempStack.Push(_taskList[i]);
                Combine(i + 1, combinationCount);
                _tempStack.Pop();
            }
        }
    }
}
