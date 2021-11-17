## Micro-benchmarks for ASP.NET Core 6.0

This repo contains micro-benchmarks using [BenchmarkDotNet](https://github.com/dotnet/benchmarkdotnet) for the ASP.NET Core 6.0 perf blog post.

To run the benchmarks run
```console
dotnet run -c Release -f net48 --runtimes net48 netcoreapp3.1 net5.0 net6.0
```
and select a number for which benchmark you want to run.

In some cases a benchmark might apply to a subset of target frameworks and a command like
```console
dotnet run -c Release -f net6.0 -filter "**" --runtimes net6.0
```
or
```console
dotnet run -c Release -f net5.0 -filter "**" --runtimes net5.0 net6.0
```
should be used instead.