using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Http;
#if NETCOREAPP
using Microsoft.AspNetCore.Http.Extensions;
#endif

namespace BlogPost60Bench
{
    public class UriHelperBenchmark
    {
#if NETCOREAPP
        [Benchmark]
        public void BuildAbsolute()
        {
            _ = UriHelper.BuildAbsolute("https", new HostString("localhost"));
        }
#endif
    }
}
