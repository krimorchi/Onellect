using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Onellect.Services
{
    static class ApiService
    {
        /// <summary>
        /// Отправка данных по указанному URL API
        /// </summary>
        /// <param name="urlApi">URL API</param>
        /// <param name="data">Данные для передачи</param>
        /// <returns>Возвращает Task асинхронной операции</returns>
        public static async Task SendToApiAsync(string urlApi, List<int> data)
        {
            try
            {
                using var client = new HttpClient();
                var jsonData = JsonSerializer.Serialize(data);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(urlApi, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Успешно отправил данные");
                }
                else
                {
                    Console.WriteLine($"Ошибка при отправке данных с кодом статуса: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при отправке данных: {ex.Message}");
            }
        }
    }
}
