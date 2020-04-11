using System;

namespace Permutation
{
    static class Program
    {
        private static int _counter = 1;
        static void Main(string[] args)
        {
            string[] target = {"A", "B", "C", "D" };
            var task = new Task(target);
            task.Printing += Task_Print;
            task.Start();
        }

        private static void Task_Print(string[] result)
        {
            var resultText = string.Empty;
            foreach (var item in result)
            {
                resultText = string.Concat(resultText, item);
            }
            Console.WriteLine($"{_counter}. {resultText}");
            _counter++;
        }
    }
}
