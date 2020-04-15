using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BinomialCoefficient
{
    class TaskNonDuplication
    {
        public delegate void CallResult(int allCount, int chosenCount);

        public delegate void CacheResult(int allCount, int chosenCount);

        public event CallResult OnCall;
        public event CacheResult OnCache;

        private int[,] _cache;
        public int Start(int allCount, int chosenCount)
        {
            _cache = new int[allCount+1, chosenCount+1];
            for (int i = 0; i <= allCount; i++)
            {
                for (int k = 0; k <= chosenCount; k++)
                {
                    _cache[i,k] = -1;
                }
            }

            return Calculate(allCount, chosenCount);
        }

        private int Calculate(int allCount, int chosenCount)
        {
            
            if (chosenCount == 0 || allCount == chosenCount)
            {
                return 1;
            }

            var savedValue = _cache[allCount, chosenCount];
            if (savedValue > -1)
            {
                OnCache?.Invoke(allCount, chosenCount);
                return savedValue;
            }

            OnCall?.Invoke(allCount, chosenCount);
            return _cache[allCount, chosenCount] = Calculate(allCount - 1, chosenCount) + Calculate(allCount - 1, chosenCount - 1);
        }
    }
}
