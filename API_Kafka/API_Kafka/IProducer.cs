using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Kafka
{
    interface IProducer
    {
        void Produce(string message);
    }
}
