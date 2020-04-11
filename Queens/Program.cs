using System;
using System.Collections.Generic;

namespace Queens
{
    static class Program
    {
        private static int _successCount = 0;
        static void Main(string[] args)
        {
            var task = new Task(6);
            task.Success += Task_Success;
            task.Fail += Task_Fail;
            task.Start();

            Console.WriteLine($"Total success case is {_successCount}");
        }

        private static void Task_Fail(int level, int[] result)
        {
            Console.WriteLine("Tracking fail.");
            for (int k = 1; k < result.Length; k++)
            {
                Console.WriteLine($"level [{k}] => {result[k]}");
            }
            Console.WriteLine(Environment.NewLine);
        }

        private static void Task_Success(int[] result)
        {
            Console.WriteLine("Tracking success.");
            for (int k = 1; k < result.Length; k++)
            {
                Console.WriteLine($"level [{k}] => {result[k]}");
            }
            Console.WriteLine(Environment.NewLine);
            _successCount++;
        }
    }
}
