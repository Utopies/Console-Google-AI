using System;
using Mscc.GenerativeAI;

class GeminiAICon
{

    public static async Task Main()
    {
        AiConfig aiConfig = await ConfigurAI.LoadAiConfigAsync("AIConf.json", default);

        var googleAI = new GoogleAI(apiKey: aiConfig.ApiKey);
        var modelOne = googleAI.GenerativeModel(model: Model.Gemini25Flash);
        var modelTwo = googleAI.GenerativeModel(model: Model.Gemini25Flash);

        var response = await modelOne.GenerateContent("Расскажи короткий интересый факт о C# на русском языке.");
        var responseTwo = await modelTwo.GenerateContent("Кефир 1-1-2-3-4-5-6");

        Console.WriteLine(response.Text);
        Console.WriteLine(responseTwo.Text);
    }
}