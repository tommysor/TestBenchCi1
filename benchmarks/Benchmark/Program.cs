using BenchmarkDotNet.Running;
// using this apps namespace
using Benchmark;

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
