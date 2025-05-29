using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Business.Concrete
{
    public class QuestionGenerateManager : IQuestionGenerateService
    {
        private IQuestionGenerateDal _generateDal;
        private readonly string _apiKey = "AIzaSyAD3QXF_NMvP8uWHO8INLmsdcFQ7nEujYI"; // API anahtarınızı buraya güvenli bir şekilde ekleyin
        private readonly HttpClient _httpClient;
        private const string _baseUrl = "https://generativelanguage.googleapis.com/v1beta"; // Düzeltilmiş baseUrl
        private const string _modelName = "gemini-2.0-flash"; // İhtiyaca göre modeli değiştirebilirsiniz

        public QuestionGenerateManager(IQuestionGenerateDal generateDal)
        {
            _generateDal = generateDal;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IDataResult<List<Question>>> QuestionCreate(QuestionSolvingMissionDto questionMission)
        {
            // Burada questionMission içeriğini prompt olarak kullanabilirsin,
            // ya da sabit örnek prompt
            string prompt = $@"
                {questionMission.NumberOfQuestion} tane {questionMission.SchoolLessonName} sorusu üret.
                Format:
                [
                  {{
                    ""questionText"": ""Soru?"",
                    ""options"": [""A"", ""B"", ""C"", ""D""],
                    ""correctAnswer"": ""A""
                  }}
                ]"
            ;

            var requestUri = $"{_baseUrl}/models/{_modelName}:generateContent?key={_apiKey}";

            var requestData = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                }
            };

            string jsonRequest = JsonSerializer.Serialize(requestData);

            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(requestUri, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Gemini API'ye bağlanılamadı veya istek başarısız oldu.");
            }

            var responseBody = await response.Content.ReadAsStringAsync();

            // JSON parse için System.Text.Json kullanacağız,
            // Önce gelen response JSON'dan text kısmını çekelim

            using var doc = JsonDocument.Parse(responseBody);

            var root = doc.RootElement;

            // response JSON yapısına göre
            // candidates[0].content.parts[0].text yolunu izle
            var textWithCodeBlock = root
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString();

            // code block içindeki ```json ... ``` kısmını temizle
            string cleanJson = CleanCodeBlock(textWithCodeBlock);

            // Son olarak cleanJson'u deserialize et
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var questions = JsonSerializer.Deserialize<List<Question>>(cleanJson, options);

            return new SuccessDataResult<List<Question>>(questions);
        }

        private static string CleanCodeBlock(string input)
        {
            var regex = new Regex(@"```json\s*(.*?)\s*```", RegexOptions.Singleline);
            var match = regex.Match(input);

            if (match.Success)
            {
                return match.Groups[1].Value.Trim();
            }

            return input.Trim();
        }
    }
}