using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onellect.Services
{
    static class Sorter
    {
        private static readonly List<Func<List<int>, List<int>>> AlgorithmsSorting =
        [
            BubbleSort,
            InsertionSort,
            QuickSort
        ];

        /// <summary>
        /// Сортируем случайно выбранным алгоритмом
        /// </summary>
        /// <param name="numbers">Числа для сортировки</param>
        /// <returns>Отсортированный список</returns>
        public static List<int> SortRandomly(List<int> numbers)
        {
            var random = new Random();
            var algorithmChosen = AlgorithmsSorting[random.Next(AlgorithmsSorting.Count)];
            return algorithmChosen(numbers);
        }

        /// <summary>
        /// Сортировка пузырьком
        /// </summary>
        /// <param name="numbers">Числа для сортировки</param>
        /// <returns>Отсортированный список чсел</returns>
        private static List<int> BubbleSort(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                for (int j = 0; j < numbers.Count - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        (numbers[j], numbers[j + 1]) = (numbers[j + 1], numbers[j]);
                    }
                }
            }
            return numbers;
        }

        /// <summary>
        /// Сортировка вставками
        /// </summary>
        /// <param name="numbers">Числа для сортировки</param>
        /// <returns>Отсортированный список чсел</returns>
        private static List<int> InsertionSort(List<int> numbers)
        {
            for (int i = 1; i < numbers.Count; i++)
            {
                int numCurrent = numbers[i];
                int j = i - 1;

                while (j >= 0 && numbers[j] > numCurrent)
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }

                numbers[j + 1] = numCurrent;
            }

            return numbers;
        }

        /// <summary>
        /// Быстрая сортировка
        /// </summary>
        /// <param name="numbers">Числа для сортировки</param>
        /// <returns>Отсортированный список чсел</returns>
        private static List<int> QuickSort(List<int> numbers)
        {
            if (numbers.Count <= 1) return numbers;

            var numCentral = numbers[numbers.Count / 2];
            var numsLessCentral = numbers.Where(x => x < numCentral).ToList();
            var numsEqualCentral = numbers.Where(x => x == numCentral).ToList();
            var numsGreaterCentral = numbers.Where(x => x > numCentral).ToList();

            return QuickSort(numsLessCentral).Concat(numsEqualCentral).Concat(QuickSort(numsGreaterCentral)).ToList();
        }
    }
}
