using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BinomialCoefficient
{
    class Program
    {
        private static int _duplicationCallCounter = 1, _nonDuplicationCallCounter = 1, _bottomTopCallCounter = 1;
        static async Task Main()
        {
            var nonDuplication = new TaskNonDuplication();
            var duplication = new TaskDuplication();
            var bottomTop = new TaskButtonTop();
            
            
            Console.WriteLine(Environment.NewLine);

            var taskBottomTop = new Task<int>(() =>
            {
                bottomTop.OnCall += BottomTop_OnCall;
                return bottomTop.Start(40, 5);
            });

            var taskDuplication = new Task<int>(() =>
            {
                duplication.OnCall += Duplication_OnCall;
                return duplication.Start(40, 5);
            });

            var taskNonDuplication = new Task<int>(() =>
            {
                nonDuplication.OnCall += NonDuplication_OnCall;
                nonDuplication.OnCache += NonDuplication_OnCache;

                return nonDuplication.Start(40, 5);
            });



            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            taskDuplication.Start();
            var taskDuplicationResult = await taskDuplication;
            stopwatch.Stop();
            Console.WriteLine($"Task of duplication running time is {stopwatch.Elapsed.Milliseconds}");

            stopwatch.Reset();

            taskNonDuplication.Start();
            var taskNonDuplicationResult = await taskNonDuplication;
            stopwatch.Stop();
            Console.WriteLine($"Task of non-duplication running time is {stopwatch.Elapsed.Milliseconds}");

            stopwatch.Reset();

            taskBottomTop.Start();
            var taskBottomTopResult = await taskBottomTop;
            stopwatch.Stop();
            Console.WriteLine($"Task of taskBottomTop running time is {stopwatch.Elapsed.Milliseconds}");


            Console.WriteLine($"All cases from task duplicated is {taskDuplicationResult}");
            Console.WriteLine($"All cases from task non-duplicated is {taskNonDuplicationResult}");
            Console.WriteLine($"All cases from task bottom-top is {taskBottomTopResult}");

        }

        private static void BottomTop_OnCall(int forI, int forK)
        {
            Console.WriteLine($"Task bottom-top call: {_bottomTopCallCounter} => forI: {forI} / forK: {forK}");
            _bottomTopCallCounter++;
        }

        private static void NonDuplication_OnCache(int allCount, int chosenCount)
        {
            Console.WriteLine($"Task non-duplication call: {_nonDuplicationCallCounter} from cache value => allCount: {allCount} / chosenCount: {chosenCount}");
            _nonDuplicationCallCounter++;
        }

        private static void NonDuplication_OnCall(int allCount, int chosenCount)
        {
            Console.WriteLine($"Task non-duplication call: {_nonDuplicationCallCounter} => allCount: {allCount} / chosenCount: {chosenCount}");
            _nonDuplicationCallCounter++;
        }

        private static void Duplication_OnCall(int allCount, int chosenCount)
        {
            Console.WriteLine($"Task duplication call: {_duplicationCallCounter} => allCount: {allCount} / chosenCount: {chosenCount}");
            _duplicationCallCounter++;
        }
    }
}
