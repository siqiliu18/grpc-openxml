using Grpc.Core;

namespace GrpcService.Services;

public class ServiceClass : GrpcService.GrpcServiceBase
{
    private readonly ILogger<ServiceClass> _logger;
    public ServiceClass(ILogger<ServiceClass> logger)
    {
        _logger = logger;
    }

    public override Task<ServerFuncReply> ServerFunc(ServerFuncRequest request, ServerCallContext context)
    {
        return Task.FromResult(new ServerFuncReply
        {
            Message = "Hello " + request.Name
        });
    }
}
