using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaExample.Infrastructure
{
    public interface IKafkaSettings
    {
        public string BootstrapServers { get; set; }
    }

    public class SimpleKafkaSettings : IKafkaSettings
    {
        public SimpleKafkaSettings(string kafkaServers)
        {
            BootstrapServers = kafkaServers;
        }

        public string BootstrapServers { get; set; }
    }
}
