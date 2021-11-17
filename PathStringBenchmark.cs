using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Http;

namespace BlogPost60Bench
{
    public class PathStringBenchmark
    {
        private PathString _first = new PathString("/first/");
        private PathString _second = new PathString("/second/");
        private PathString _long = new PathString("/longerpathstringtoshowsubstring/");

        [Benchmark]
        public PathString AddShortString()
        {
            return _first.Add(_second);
        }

        [Benchmark]
        public PathString AddLongString()
        {
            return _first.Add(_long);
        }
    }
}
