using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

string inputPrompt = args.Length > 0 ? args[0] : "Just say 'Hello, World!'";
// Prerequirement: Ollama Server should be running on http://localhost:11434
// ollama pull gemma2:2b
// ollama pull exaone3.5:2.4b
string modelId = args.Length > 1 ? args[1] : "gemma2:2b";

#pragma warning disable SKEXP0070
IKernelBuilder builder = Kernel.CreateBuilder();
builder.AddOllamaChatCompletion(
    modelId: modelId,
    endpoint: new Uri("http://localhost:11434")
);

var kernel = builder.Build();
var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

ChatMessageContent chatMessage = await chatCompletionService
                                .GetChatMessageContentAsync(inputPrompt);
Console.WriteLine(chatMessage.ToString());
