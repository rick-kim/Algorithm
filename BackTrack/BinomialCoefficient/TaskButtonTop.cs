using System;
using System.Collections.Generic;
using System.Text;

namespace BinomialCoefficient
{
    class TaskButtonTop
    {
        public delegate void CallResult(int forI, int forK);
        public event CallResult OnCall;

        private int[,] _cache;

        public int Start(int allCount, int chosenCount)
        {
            _cache = new int[allCount+1, chosenCount+1];
            return Calculate(allCount, chosenCount);
        }

        private int Calculate(int allCount, int chosenCount)
        {
            for (int i = 0; i <= allCount; i++)
            {
                for (int k = 0; k <= chosenCount && k<=i; k++)
                {
                    if (k == 0)
                    {
                        _cache[i,k] = 1;
                    }
                    else
                    {
                        _cache[i, k] = _cache[i - 1, k] + _cache[i - 1, k - 1];
                    }
                    OnCall?.Invoke(i, k);
                }
            }

            return _cache[allCount, chosenCount];
        }
    }
}
