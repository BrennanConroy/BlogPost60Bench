using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Order;
using Perfolizer.Horology;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
#if NETCOREAPP
using Microsoft.AspNetCore.Http.Extensions;
#endif

[DisassemblyDiagnoser(maxDepth: 0)]
[MemoryDiagnoser(displayGenColumns: false)]
public class Program
{
    public static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, DefaultConfig.Instance
        .WithSummaryStyle(new SummaryStyle(CultureInfo.InvariantCulture, printUnitsInHeader: false, SizeUnit.B, TimeUnit.Nanosecond))
        .WithOrderer(new DotNetVersionOrderer()));
}

internal sealed class DotNetVersionOrderer : DefaultOrderer
{
    private static readonly Dictionary<string, int> s_rankings = new Dictionary<string, int>() { { ".NET Framework 4.8", 0 }, { ".NET Core 3.1", 1 }, { ".NET 5.0", 2 }, { ".NET 6.0", 3 } };
    public override IEnumerable<BenchmarkCase> GetSummaryOrder(ImmutableArray<BenchmarkCase> benchmarksCases, Summary summary) =>
        benchmarksCases.Sort((b1, b2) => s_rankings[b1.GetRuntime().Name].CompareTo(s_rankings[b2.GetRuntime().Name]));
}