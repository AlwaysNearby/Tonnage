using Newtonsoft.Json;

namespace Tonnage
{
    internal class Program
    {
        const string Url = "https://api.telegram.org/bot7606445507:AAGl5PQW8BqRIgmjCibmhDefAz85KAj-L0I/";

        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            int offset = -100;

            while (true)
            {
                var uri = GetUpdateMethod(offset);

                var message = await httpClient.GetAsync(uri);

                if (message != null && message.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var response = await message.Content.ReadAsStringAsync();

                    var telegramUpdate = JsonConvert.DeserializeObject<TelegramUpdate>(response);
                    if (!telegramUpdate.Ok || telegramUpdate.Result.Length == 0)
                    {
                        continue;
                    }

                    offset = telegramUpdate.Result[telegramUpdate.Result.Length - 1].UpdateId + 1;

                    //TODO написать на основе текста который отправляетп пользователь нашу идею ТОННАЖАААА!!!!
                    //Найти в telegram api метод, который позволяет отправлять сообщения в час
                    //научится парсить текст пользователя
                    //на основе этого текста рсчитать подходы и общий тоннаж.

                }
            }
        }

        private static Uri GetUpdateMethod(int offset)
        {
            var method = "getUpdates";
            if (offset != -1)
            {
                method = method + $"?offset={offset}";
            }

            return new Uri(Url + method);
        }
    }
}
