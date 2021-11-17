using BenchmarkDotNet.Attributes;
using Microsoft.Net.Http.Headers;

namespace BlogPost60Bench
{
    public class ContentDispositionBenchmark
    {
        [Benchmark]
        public void ParseContentDispositionHeader()
        {
            var contentDisposition = new ContentDispositionHeaderValue("inline");
            contentDisposition.FileName = "FileÃName.bat";
        }
    }
}
