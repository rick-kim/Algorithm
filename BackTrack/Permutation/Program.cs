using System;
using System.Linq;
using System.Threading.Tasks;

namespace Permutation
{
    static class Program
    {
        private static int _swapCounter = 1, _stackCounter = 1;
        static void Main(string[] args)
        {
            string[] target1 = { "A", "B", "C", "D", "E", "F" };
            string[] target2 = { "A", "B", "C", "D", "E" };


            var taskWithSwap = new TaskWithSwap(target1);
            var taskWithStack = new TaskWithStack(target2);


            // Execute task with swap.
            var swapTask = Task.Factory.StartNew(() =>
            {
                taskWithSwap.Printing += SwapTask_Printing;
                taskWithSwap.Start();
            });
            

            // Execute task with stack.
            var stackTask = Task.Factory.StartNew(() =>
            {
                taskWithStack.Printing += StackTask_Printing;
                taskWithStack.Start();
            });

            Task.WaitAll(swapTask, stackTask);
        }

        private static void StackTask_Printing(System.Collections.Generic.Stack<string> result)
        {
            var resultText = string.Empty;
            foreach (var item in result.Reverse())
            {
                resultText = string.Concat(resultText, item);
            }
            Console.WriteLine($"Stack Print: {_stackCounter} => {resultText}");
            _stackCounter++;
        }

        private static void SwapTask_Printing(string[] result)
        {
            var resultText = string.Empty;
            foreach (var item in result)
            {
                resultText = string.Concat(resultText, item);
            }
            Console.WriteLine($"Swap Print: {_swapCounter} => {resultText}");
            _swapCounter++;
        }
    }
}
