using System;
using System.Collections.Generic;
using System.Text;

namespace Combination
{

    class TaskDuplication<T>
    {
        internal delegate void PrintResult(Stack<T> resultStack);

        public event PrintResult OnPrint;

        private readonly List<T> _taskList;
        private readonly Stack<T> _tempStack;
        public TaskDuplication(List<T> taskList)
        {
            _taskList = taskList;
            _tempStack = new Stack<T>();
        }

        public void Start(int combinationCount)
        {
            Combine(combinationCount);
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
                _tempStack.Push(item);
                Combine(combinationCount);
                _tempStack.Pop();
            }
        }
    }
}
