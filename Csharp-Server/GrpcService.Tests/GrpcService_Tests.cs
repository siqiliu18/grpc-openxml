using GrpcService.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Grpc.Core.Testing;
using Grpc.Core;

namespace GrpcService.Tests;
public class GrpcServiceTest
{
    [Fact]
    public async void Test1()
    {
        var mlogger = new Mock<ILogger<ServiceClass>>();
        var testSvc = new ServiceClass(mlogger.Object);
        ServerFuncRequest req = new ServerFuncRequest { };
        req.Name = "Siqi";
        // https://stackoverflow.com/questions/67121378/trying-to-implement-grpc-unit-test-for-c-sharp
        var res = await testSvc.ServerFunc(req, TestServerCallContext.Create(
                                            method: ""
                                            , host: "localhost"
                                            , deadline: DateTime.Now.AddMinutes(30)
                                            , requestHeaders: new Metadata()
                                            , cancellationToken: CancellationToken.None
                                            , peer: "10.0.0.25:5001"
                                            , authContext: null
                                            , contextPropagationToken: null
                                            , writeHeadersFunc: (metadata) => Task.CompletedTask
                                            , writeOptionsGetter: () => new WriteOptions()
                                            , writeOptionsSetter: (writeOptions) => { }
));
        Assert.Equal("Hello Siqi", res.Message);
    }
}