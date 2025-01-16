using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onellect.Services
{
    static class NumberGenerator
    {
        /// <summary>
        /// Генерируем список случайных чисел в указанном диапозоне, количество также от указанного минимума и максимума
        /// </summary>
        /// <param name="minValue">Минимальное значение чисел</param>
        /// <param name="maxValue">Максимальное значение чисел</param>
        /// <param name="minCount">Минимальное количество чисел</param>
        /// <param name="maxCount">Максимальное количество чисел</param>
        /// <returns>Список случайных чисел</returns>
        public static List<int> GenerateRandomNumbers(int minValue, int maxValue, int minCount, int maxCount)
        {
            var random = new Random();
            int count = random.Next(minCount, maxCount + 1);
            return Enumerable.Range(0, count).Select(_ => random.Next(minValue, maxValue + 1)).ToList();
        }
    }
}
