using Confluent.Kafka;
using KafkaExample.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaExample.Infrastructure
{
    public class KafkaProducer
    {
        private readonly IProducer<Null, string> _producer;

        public KafkaProducer(IKafkaSettings settings)
        {
            var producerConfig = new ProducerConfig
            {
                BootstrapServers = settings.BootstrapServers,
            };

            _producer = new ProducerBuilder<Null, string>(producerConfig).Build();
        }

        public void Produce(string topic, string data, Action<DeliveryReport<Null, string>>? callback = null) 
        {
            _producer.Produce(topic, new Message<Null, string> { Value = data }, callback);
        }

        public Task<DeliveryResult<Null, string>> ProduceAsync(string topic, string data)
        {
            return _producer.ProduceAsync(topic, new Message<Null, string> { Value = data });
        }
    }
}
