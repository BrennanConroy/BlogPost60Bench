using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.WebUtilities;

namespace BlogPost60Bench
{
    public class QueryEnumerableBenchmark
    {
#if NET6_0_OR_GREATER
        public enum QueryEnum
        {
            Simple = 1,
            Encoded,
        }

        [ParamsAllValues]
        public QueryEnum QueryParam { get; set; }

        private string SimpleQueryString = "?key1=value1&key2=value2";
        private string QueryStringWithEncoding = "?key1=valu%20&key2=value%20";

        [Benchmark(Baseline = true)]
        public void QueryHelper()
        {
            var queryString = QueryParam == QueryEnum.Simple ? SimpleQueryString : QueryStringWithEncoding;
            foreach (var queryParam in QueryHelpers.ParseQuery(queryString))
            {
                _ = queryParam.Key;
                _ = queryParam.Value;
            }
        }

        [Benchmark]
        public void QueryEnumerable()
        {
            var queryString = QueryParam == QueryEnum.Simple ? SimpleQueryString : QueryStringWithEncoding;
            foreach (var queryParam in new QueryStringEnumerable(queryString))
            {
                _ = queryParam.DecodeName();
                _ = queryParam.DecodeValue();
            }
        }
#endif
    }
}
