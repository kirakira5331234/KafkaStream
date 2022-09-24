using System;
using System.Collections.Generic;
using System.Text;

namespace API_kafka
{
    public interface IConsumer
    {
        void Listen(Action<string> message);
    }
}
