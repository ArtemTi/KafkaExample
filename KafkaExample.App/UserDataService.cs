using Confluent.Kafka;
using KafkaExample.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KafkaExample.App
{
    public class UserDataService
    {
        private readonly KafkaProducer _kafkaProducer;

        public UserDataService(KafkaProducer kafkaProducer)
        {
            _kafkaProducer = kafkaProducer;
        }

        public async Task ProcessDataAsync(UserData userData)
        {
            await Task.Delay(1000); // some processing

            var deliveryResult = await _kafkaProducer.ProduceAsync("userData", JsonSerializer.Serialize(userData));
            Console.WriteLine(deliveryResult.ToString()); // log result
        }

        public void ProcessData(UserData userData)
        {
            Thread.Sleep(1000);

            _kafkaProducer.Produce("userData", JsonSerializer.Serialize(userData), Callback);
        }

        private void Callback(DeliveryResult<Null, string> deliveryResult)
        {
            Console.WriteLine(deliveryResult.ToString());
        }
    }
}
