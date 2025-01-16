using Onellect.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RandomSortApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Генерируем список случайных чисел
            var numbers = NumberGenerator.GenerateRandomNumbers(-100, 100, 20, 100);

            // Показываем список
            Console.WriteLine("Первичный список чисел:");
            Console.WriteLine(string.Join(", ", numbers));

            // Сортируем список числе по случайно выбранному алгоритму
            var numbersSorted = Sorter.SortRandomly(numbers);

            // Выводим отсортированный список
            Console.WriteLine("Отсортированный список чисел:");
            Console.WriteLine(string.Join(", ", numbersSorted));

            // Получаем ссылку для API и отправляем данные (если нашли)
            string? urlApi = ConfigurationService.GetUrlApi();
            if (!string.IsNullOrEmpty(urlApi))
            {
                await ApiService.SendToApiAsync(urlApi, numbersSorted);
            }
            else
            {
                Console.WriteLine("Не нашел URL для отправки данных по API");
            }
        }
    }
}
