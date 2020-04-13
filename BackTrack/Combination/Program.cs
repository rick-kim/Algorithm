using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Combination
{
    static class Program
    {
        private static int _counter = 1, _counterForDuplication = 1;
        static void Main(string[] args)
        {
            var nonDuplication = new TaskNonDuplication<string>(new List<string>() { "A", "B", "C", "D" });
            var duplication = new TaskDuplication<int>(new List<int>(){1,2,3,4});

            var taskDuplication = Task.Factory.StartNew(() =>
            {
                duplication.OnPrint += TaskDuplication_OnPrint;
                duplication.Start(3);
            });

            var taskNonDuplication = Task.Factory.StartNew(() =>
            {
                nonDuplication.OnPrint += TaskNonDuplication_OnPrint;
                nonDuplication.Start(2, 0);
            });

            Task.WaitAll(taskDuplication, taskNonDuplication);
        }

        private static void TaskNonDuplication_OnPrint(Stack<string> resultStack)
        {
            var resultText = string.Empty;
            foreach (var item in resultStack)
            {
                resultText = string.Concat(resultText, item);
            }
            Console.WriteLine($"taskNonDuplication Print: {_counter} => {resultText}");

            _counter++;
        }

        private static void TaskDuplication_OnPrint(Stack<int> resultStack)
        {
            var resultText = string.Empty;
            foreach (var item in resultStack)
            {
                resultText = string.Concat(resultText, item);
            }
            Console.WriteLine($"taskDuplication Print: {_counterForDuplication} => {resultText}");

            _counterForDuplication++;
        }
    }
}
