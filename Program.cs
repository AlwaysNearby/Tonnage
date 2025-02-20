using Newtonsoft.Json;
using System.Text;

namespace Tonnage
{
    public class BodyMessage
    {
        public string chat_id { get; set; }
        public string text { get; set; }
    }
    internal class Program
    {
        const string Url = "https://api.telegram.org/bot7606445507:AAGl5PQW8BqRIgmjCibmhDefAz85KAj-L0I/";

        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            int offset = -1;

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
                    var chatId = telegramUpdate.Result[telegramUpdate.Result.Length - 1].Message.Chat.Id;
                    string text = telegramUpdate.Result[telegramUpdate.Result.Length - 1].Message.Text;
                    
                    if (!CorrectRequest(text))
                    {
                        var answer = "Я не смог понять, что вы мне прислали. Пожалуйста, напишите числами шаг веса, шаг количества повторений и ваш максимальный вес на 1 повторение через пробел.%0AПример: 2 2,5 %0AСпасибо!";
                        await httpClient.GetAsync(Url + $"sendMessage?chat_id={chatId}&text={answer}");
                        continue;
                    }
                    else
                    {
                        AnswerToClient(chatId, Url, httpClient, CountedTonnage(text));
                    }
                }
            }
        }

        private static async Task AnswerToClient(long chatId, string Url, HttpClient client, List<double> nums)
        {
            StringBuilder answer = new StringBuilder();
            for (int i = 0; i < nums.Count; i += 3)
            {
                answer.AppendLine($"вес штанги - {nums[i]} , количество повторений - {nums[i + 1]}, тоннаж на данный подход - {nums[i + 2]}");
            }

            var bodyMessage = new BodyMessage
            {
                chat_id = chatId.ToString(),
                text = answer.ToString()
            };
            string json = JsonConvert.SerializeObject(bodyMessage);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync(Url + "sendMessage", content);
        }

        private static List<double> CountedTonnage(string text)
        {
            List<double> result = new List<double>();
            string[] str = text.Split(' ');
            double[] nums = new double[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                nums[i] = double.Parse(str[i]);
            }

            double endWeight = nums[2];
            double startWeight = 20;
            double CountRepetitions = (endWeight - startWeight) / nums[0] * nums[1];
            while (startWeight < endWeight)
            {
                result.Add(startWeight);
                result.Add(CountRepetitions);
                result.Add(startWeight * CountRepetitions);

                startWeight += nums[0];
                CountRepetitions -= nums[1];
            }
            result.Add(endWeight);
            result.Add(1);
            result.Add(endWeight);
               
            return result;
        }

        private static bool CorrectRequest(string text)
        {
            string[] result = text.Split(' ');
            foreach (string s in result)
            {
                if (!double.TryParse(s, out double d))
                {
                    return false;
                }
            }
            return true;
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
