using System;
using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using API_kafka;

namespace API_kafka
{
    public class BookingConsumer
    {
        public async void Listen()
        {
            int confirm = 0;
            // The Kafka endpoint address
            string kafkaEndpoint = "localhost:9092";

            // The Kafka topic we'll be using
            string kafkaTopic = "test_booking";

            // Create the consumer configuration
            var consumerConfig = new Dictionary<string, object>
            {
                { "group.id", "myconsumer" },
                { "bootstrap.servers", kafkaEndpoint },
            };

            // Create the consumer
            using (var consumer = new Consumer<Null, string>(consumerConfig, null, new StringDeserializer(Encoding.UTF8)))
            {
                // Subscribe to the OnMessage event
                consumer.OnMessage += (obj, msg) =>
                {
                    Console.WriteLine($"Received: {msg.Value}");
                    confirm = 1;
                };

                // Subscribe to the Kafka topic
                consumer.Subscribe(new List<string>() { kafkaTopic });

                // Handle Cancel Keypress 
                var cancelled = false;
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true; // prevent the process from terminating.
                    cancelled = true;
                };
                if (confirm == 1)
                {
                    cancelled = true;
                    confirm = 0;
                }
                Console.WriteLine("Ctrl-C to exit.");

                // Poll for messages
                while (!cancelled)
                {
                    consumer.Poll(TimeSpan.FromMinutes(1));
                    return;
                }
            }
        }
    }
}
