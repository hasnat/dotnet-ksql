using System;
using System.Text;
using System.Collections.Generic;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;

public class Program
{
  public static void Main()
  {
    var conf = new Dictionary<string, object>
    {
      { "group.id", "consumer-dot-net-test" },
      { "bootstrap.servers", "kafka:9092" },
      { "auto.commit.interval.ms", 5000 },
      { "auto.offset.reset", "earliest" }
    };

    using (var consumer = new Consumer<Null, string>(conf, null, new StringDeserializer(Encoding.UTF8)))
    {
      consumer.OnMessage += (_, msg)
        => Console.WriteLine($"Read '{msg.Value}' from: {msg.TopicPartitionOffset}");

      consumer.OnError += (_, error)
        => Console.WriteLine($"Error: {error}");

      consumer.OnConsumeError += (_, msg)
        => Console.WriteLine($"Consume error ({msg.TopicPartitionOffset}): {msg.Error}");

      consumer.Subscribe("test");

      while (true)
      {
        consumer.Poll(TimeSpan.FromMilliseconds(100));
      }
    }
  }
}