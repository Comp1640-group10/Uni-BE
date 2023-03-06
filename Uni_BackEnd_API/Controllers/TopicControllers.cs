using Microsoft.AspNetCore.Mvc;
using Uni_BackEnd_API.Models;

namespace Uni_BackEnd_API.Controllers
{
    public class TopicControllers : Controller
    {
        public static List<Topic> topics = new List<Topic>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(topics);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int topicId)
        {
            var topic = topics.SingleOrDefault(c => c.id == topicId);
            if (topic == null)
            {
                return NotFound();
            }

            return Ok(topic);
        }
        [HttpPost]
        public IActionResult Create(Topic newTopic)
        {
            var topic = new Topic();
            {
                topic.topicName = newTopic.topicName;
            }
            topics.Add(topic);
            return Ok(new
            {
                Success = true,
                Data = topic
            });
        }
        [HttpPut("{id}")]
        public IActionResult Update(int topicId, Topic updateTopic)
        {
            var topic = topics.SingleOrDefault(c => c.id == topicId);
            if (topic == null)
            {
                return NotFound();
            }
            //update

            topic.topicName = updateTopic.topicName;

            return Ok(topic);
        }
    }
}
