﻿using System.IO;
using BenchmarkDotNet.Attributes;
using Bond.IO.Safe;
using Bond.Protocols;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Bond.PerformanceTest
{
    [Config(typeof(BenchmarksConfig))]
    public class SerializationBenchmarks
    {
        private static readonly Person ProtobufPerson = BenchmarksData.ProtobufPerson();
        private static readonly ProtobufNet.Person ProtobufNetPerson = BenchmarksData.ProtobufNetPerson();

        private readonly Serializer<CompactBinaryWriter<OutputBuffer>> compactBondSerializer = new Serializer<CompactBinaryWriter<OutputBuffer>>(typeof(Bond.Person));
        private readonly Serializer<FastBinaryWriter<OutputBuffer>> fastBondSerializer = new Serializer<FastBinaryWriter<OutputBuffer>>(typeof(Bond.Person));
        private static readonly Bond.Person BondPerson = BenchmarksData.BondPerson();

        private static readonly JSON.Person JSONPerson = BenchmarksData.JSONPerson();
        private static readonly XML.Person XMLPerson = BenchmarksData.XMLPerson();

        [Benchmark]
        public int GoogleProtobuf()
        {
            var data = ProtobufPerson.ToByteArray();
            return data.Length;
        }

        [Benchmark]
        public int ProtobufNet()
        {
            var memoryStream = new MemoryStream();
            ProtoBuf.Serializer.Serialize(memoryStream, ProtobufNetPerson);
            var data = memoryStream.ToArray();
            return data.Length;
        }

        [Benchmark]
        public int CompactBond()
        {
            var output = new OutputBuffer(256);
            var writer = new CompactBinaryWriter<OutputBuffer>(output);
            compactBondSerializer.Serialize(BondPerson, writer);
            return output.Data.Count;
        }

        [Benchmark]
        public int FastBond()
        {
            var output = new OutputBuffer(256);
            var writer = new FastBinaryWriter<OutputBuffer>(output);
            fastBondSerializer.Serialize(BondPerson, writer);
            return output.Data.Count;
        }

        [Benchmark]
        public int JSON()
        {
            return JsonConvert.SerializeObject(JSONPerson).Length;
        }

        [Benchmark]
        public int XML()
        {
            var serializer = new XmlSerializer(typeof(XML.Person));
            var memoryStream = new MemoryStream();
            serializer.Serialize(memoryStream, XMLPerson);
            var data = memoryStream.ToArray();
            return data.Length;
        }
    }
}