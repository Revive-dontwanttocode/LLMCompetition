using AnalysisLibrary.Constants;
using Microsoft.SemanticKernel;

namespace AnalysisServer.Services;

public class KernelFactory : IKernelFactory
{
    public IKernel Produce() =>
        new KernelBuilder().Configure(p =>
        {
            p.AddAzureChatCompletionService(
                LlmInfoConstants.AOAI_DEPLOYMENTNAME,
                LlmInfoConstants.AOAI_ENDPOINT,
                LlmInfoConstants.AOAI_KEY);
        }).Build();
}