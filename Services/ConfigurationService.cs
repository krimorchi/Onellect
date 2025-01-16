using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Onellect.Services
{
    static class ConfigurationService
    {
        private const string PathFileConfig = "config.json";

        /// <summary>
        /// Находит url для отправки API 
        /// </summary>
        /// <returns>URL для API или null, если файл не найден</returns>
        public static string? GetUrlApi()
        {
            if (!File.Exists(PathFileConfig))
            {
                Console.WriteLine($"Не нашел конфигурационный файл: {PathFileConfig}");
                return null;
            }

            try
            {
                var jsonContent = File.ReadAllText(PathFileConfig);

                var config = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonContent);

                if (config != null && config.TryGetValue("url_api", out var urlApi))
                {
                    return urlApi;
                }

                Console.WriteLine("Параметр 'url_api' отсутствует в файле конфигурации");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Ошибка парсинга JSON: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении конфигурационного файла: {ex.Message}");
            }

            return null;
        }
    }
}
