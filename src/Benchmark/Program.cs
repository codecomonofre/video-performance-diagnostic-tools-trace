using Benchmark.Services;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using OrderManagement.Api.Services;

namespace Benchmark
{
    internal class Program
    {
        private static void Main()
        {
            BenchmarkRunner.Run(typeof(BenchmarkOrderService));
        }
    }
}

namespace Benchmark.Services
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenchmarkOrderService
    {
        private readonly IOrderService _service;

        public BenchmarkOrderService()
        {
            _service = new OrderService();
        }

        [Benchmark]
        public void TestGetOrdersSlowAsync()
        {
            _service.GetOrdersSlow();
        }

        [Benchmark]
        public void TestGetOrdersFastAsync()
        {
            _service.GetOrdersFast();
        }
    }
}