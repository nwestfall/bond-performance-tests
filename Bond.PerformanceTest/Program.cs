﻿using System;
using BenchmarkDotNet.Running;

namespace Bond.PerformanceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var switcher = BenchmarkSwitcher.FromTypes(new []
            {
                typeof(SerializationBenchmarks),
                typeof(DeserializationBenchmarks),
            });
            switcher.RunAll();

            var benchmarks = new SerializationBenchmarks();
            Console.WriteLine("Google Protobuf size: {0} bytes", benchmarks.GoogleProtobuf());
            Console.WriteLine("Protobuf.NET size:    {0} bytes", benchmarks.ProtobufNet());
            Console.WriteLine("Compact Bond:         {0} bytes", benchmarks.CompactBond());
            Console.WriteLine("Fast Bond:            {0} bytes", benchmarks.FastBond());
            Console.WriteLine("JSON:                 {0} bytes", benchmarks.JSON());
            Console.WriteLine("XML:                  {0} bytes", benchmarks.XML());
        }
    }
}
