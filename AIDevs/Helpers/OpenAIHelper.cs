using OpenAI.Audio;
using OpenAI.Chat;
using OpenAI.Images;

namespace AIDevs.Helpers
{
    public static class OpenAIHelper
    {
        public static string Ask(string message, string model = "gpt-4o")
        {
            ChatClient chatClient = new(model: model, apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
            ChatCompletion completion = chatClient.CompleteChat(message);
            return completion.Content[0].Text;
        }

        public static string Draw(string prompt)
        {
            ImageClient client = new("dall-e-3", Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
            var generatedImage = client.GenerateImage(prompt);
            return generatedImage.Value.ImageUri.ToString();
        }

        public static string TranscribeAudio(string audioFilePath)
        {
            AudioClient client = new("whisper-1", Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

            AudioTranscriptionOptions options = new()
            {
                ResponseFormat = AudioTranscriptionFormat.Verbose,
                TimestampGranularities = AudioTimestampGranularities.Word | AudioTimestampGranularities.Segment,
            };

            AudioTranscription transcription = client.TranscribeAudio(audioFilePath, options);

            return transcription.Text;
        }
    }
}