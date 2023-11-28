using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Json;
using BenchmarkDotNet.Jobs;
using Bogus;
using SimplifiedSearch;

namespace Benchmark
{
    [Config(typeof(Config))]
    [MemoryDiagnoser]
    // [RPlotExporter]
    public class Benchmarks
    {
        private class Config : ManualConfig
        {
            public Config()
            {
                AddExporter(JsonExporter.FullCompressed);

                // var baseJob = Job.MediumRun.WithMaxIterationCount(25);
                var baseJob = Job.ShortRun.WithMaxIterationCount(25);
                AddJob(baseJob);

                // AddJob(baseJob.WithNuGet("SimplifiedSearch", "1.0.0").WithId("1.0.0"));
                // AddJob(baseJob.WithNuGet("SimplifiedSearch", "1.2.0").WithId("1.2.0"));
                // AddJob(baseJob.WithNuGet("SimplifiedSearch", "1.3.0-beta1").WithId("1.3.0"));
                
                // AddJob(baseJob.WithCustomBuildConfiguration("main").WithId("main").AsBaseline());
                // AddJob(baseJob.WithCustomBuildConfiguration("pr").WithId("pr"));
            }
        }

        private class Person
        {
            public string? Name { get; set; }
            public int Age { get; set; }
        }

        private class Blurb
        {
            public string? Text { get; set; }
        }

        private List<Person> _people = null!;
        private List<Blurb> _blurbs = null!;

        private List<Person> GenerateRandomPeople(int count)
        {
            var faker = new Faker<Person>()
                .UseSeed(8964)
                .RuleFor(p => p.Name, f => f.Name.FullName())
                .RuleFor(p => p.Age, f => f.Random.Int(18, 65));

            return faker.Generate(count);
        }

        private List<Blurb> GenerateRandomBlurbs(int count)
        {
            var faker = new Faker<Blurb>()
                .UseSeed(8964)
                .RuleFor(p => p.Text, f => f.Lorem.Sentence());

            return faker.Generate(count);
        }

        [GlobalSetup]
        public void Setup()
        {
            _people = GenerateRandomPeople(10_000);
            _blurbs = GenerateRandomBlurbs(10_000);
        }

        [Benchmark]
        public async Task<int> People()
        {
            var result = await _people.SimplifiedSearchAsync("John Doe");
            return result.Count;
        }

        [Benchmark]
        public async Task<int> Blurbs()
        {
            var result = await _blurbs.SimplifiedSearchAsync("Some text to search for");
            return result.Count;
        }
    }
}
