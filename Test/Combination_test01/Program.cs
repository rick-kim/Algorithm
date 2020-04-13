using System;
using System.Collections.Generic;

namespace Combination_test01
{
    class Program
    {

        static List<List<int>> _combinationList;
        static bool[] _usedCheckArray;
        static void GetCombinationSample()
        {
            int[] dataArray = { 1,2,3,4};
            _usedCheckArray = new bool[dataArray.Length];
            _combinationList = new List<List<int>>();

            Combine(dataArray, 0, new List<int>());
            foreach (var item in _combinationList)
            {
                foreach (var x in item)
                {
                    Console.Write(x + ",");
                }
                Console.WriteLine("");
            }
        }
        static void Combine(int[] dataArray, int position, List<int> combinationItem)
        {

            if (position >= dataArray.Length)
            {
                _combinationList.Add(new List<int>(combinationItem));
                return;
            }
            for (int i = 0; i < dataArray.Length; i++)
            {
                if (!_usedCheckArray[i])
                {
                    _usedCheckArray[i] = true;

                    combinationItem.Add(dataArray[i]);
                    Combine(dataArray, position + 1, combinationItem);
                    combinationItem.RemoveAt(combinationItem.Count - 1);

                    _usedCheckArray[i] = false;
                }
            }
        }
        static void Main(string[] args)
        {
            GetCombinationSample();
        }
    }
}
