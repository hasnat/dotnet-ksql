using System;
using System.Collections.Generic;
using System.Text;
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
        while (i < 1000)
        {
          var dr = producer.ProduceAsync("test", null, "test message text" + i.ToString()).Result;
          Console.WriteLine($"Delivered '{dr.Value}' to: {dr.TopicPartitionOffset}");
          i++;
        }
      }
    }
  }
}
