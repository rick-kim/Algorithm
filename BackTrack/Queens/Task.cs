using System;
using System.Collections.Generic;
using System.Text;

namespace Queens
{
    delegate void TrackingSuccess(int[] result);

    delegate void TrackingFail(int level, int[] result);
    class Task
    {
        public event TrackingSuccess Success;
        public event TrackingFail Fail;

        private readonly int _size;

        public Task(int size)
        {
            _size = size;
        }

        public void Start()
        {
            for (int i = 1; i <= _size; i++)
            {
                var column = new int[_size + 1];
                column[1] = i;
                Tracking(1, column);
            }
        }

        private bool Tracking(int level, int[] column)
        {
            if (!IsCanBePlaced(level, column))
            {
                // fail
                Fail?.Invoke(level, column);
                return false;
            }

            if (level == _size)
            {
                // success
                Success?.Invoke(column);
                return true;
            }

            // tracking child cases
            for (int i = 1; i <= _size; i++)
            {
                column[level + 1] = i;
                if (Tracking(level + 1, column))
                {
                    return true;
                }
            }

            return false;
        }

        // check if it is possible or not to place
        private bool IsCanBePlaced(int level, int[] column)
        {
            if (level == 1)
            {
                return true;
            }

            for (int i = 1; i < level; i++)
            {
                if (column[i] == column[level])
                {
                    return false;
                }

                if (level - i == Math.Abs(column[level] - column[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
