using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;

namespace Producer.NetCore
{
  class Program
  {
    static void Main(string[] args)
    {
      var config = new Dictionary<string, object>
        {
            { "bootstrap.servers", "kafka:9092" }
        };

      using (var producer = new Producer<Null, string>(config, null, new StringSerializer(Encoding.UTF8)))
      {
        int i = 0;
        using (var rd = new System.IO.StreamReader("Sample.CSV"))
        {
          while (!rd.EndOfStream) {
            if (i == 0) {rd.ReadLine(); i=1; continue;}
            var dr = producer.ProduceAsync(
              "KSQL_INPUT",
              null,
              // KSQL can currently only read tsv
              string.Join(
                ",",
                rd.ReadLine()
                  .Split(';')
                  .Select(s => s.Replace(',', '·'))
                  .ToArray()
              )
             ).Result;
            Console.WriteLine($"Delivered '{dr.Value}' to: {dr.TopicPartitionOffset}");
          }
        }
      }
    }
  }
}
