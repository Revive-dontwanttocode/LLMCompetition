using Microsoft.SemanticKernel;

namespace AnalysisServer.Services;

public interface IKernelFactory
{
    IKernel Produce(); // 获得kernel
}