using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using Confluent.Kafka;
using System.Text;
using API_Kafka;

namespace API_Kafka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //string topic = "test_Kafka";
            //var message = "testing Kafka";
            //Uri uri = new Uri(@"http://localhost:9092");
            //var options = new KafkaOptions(uri);
            //BrokerRouter brokerRouter = new BrokerRouter(options);
            //Consumer kafkaConsumer = new Consumer(new ConsumerOptions(topic, brokerRouter));

            //foreach (var messages in kafkaConsumer.Consume())
            //{
            //  message = message + Encoding.UTF8.GetString(messages.Value);
            //  break;
            //}
            var producer = new BookingProducer();
            producer.Produce();
            var newCall = new API_kafka.BookingConsumer();
            newCall.Listen();
            Console.WriteLine("Done circle");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
