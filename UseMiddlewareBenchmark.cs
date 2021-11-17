using BenchmarkDotNet.Attributes;
using System;
using System.Threading.Tasks;

namespace BlogPost60Bench
{
    public class UseMiddlewareBenchmark
    {
		static private Func<Func<int, Task>, Func<int, Task>> UseOld(Func<int, Func<Task>, Task> middleware)
		{
			return next =>
			{
				return context =>
				{
					Func<Task> simpleNext = () => next(context);
					return middleware(context, simpleNext);
				};
			};
		}
		static private Func<Func<int, Task>, Func<int, Task>> UseNew(Func<int, Func<int, Task>, Task> middleware)
		{
			return next => context => middleware(context, next);
		}

		Func<int, Task> Middleware = UseOld((c, n) => n())(i => Task.CompletedTask);
		Func<int, Task> NewMiddleware = UseNew((c, n) => n(c))(i => Task.CompletedTask);

		[Benchmark(Baseline = true)]
		public Task Use()
		{
			return Middleware(10);
		}

		[Benchmark]
		public Task UseNew()
		{
			return NewMiddleware(10);
		}
	}
}
