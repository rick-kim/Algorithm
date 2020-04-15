using System;
using System.Collections.Generic;
using System.Text;

namespace BinomialCoefficient
{
    
    class TaskDuplication
    {
        public delegate void CallResult(int allCount, int chosenCount);
        public event CallResult OnCall;

        public int Start(int allCount, int chosenCount)
        {
            return Calculate(allCount, chosenCount);
        }

        private int Calculate(int allCount, int chosenCount)
        {
            OnCall?.Invoke(allCount, chosenCount);

            if (allCount == chosenCount || chosenCount == 0)
            {
                return 1;
            }

            return Calculate(allCount - 1, chosenCount) + Calculate(allCount - 1, chosenCount - 1);
        }
    }
}
