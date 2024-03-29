﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Xml.Serialization;
using Uni_BackEnd_API.Data;
using Uni_BackEnd_API.Models;

namespace Uni_BackEnd_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "admin,manager")]
    public class TopicController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public TopicController(ApplicationDbContext dbContext)
        {

            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_dbContext.Topics);
        }
        [HttpGet("{topicId}")]
        public IActionResult GetById(int topicId)
        {
            var topic = _dbContext.Topics.SingleOrDefault(c => c.id == topicId);
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
                topic.closureDate = newTopic.closureDate.Date;
                topic.finalClosureDate = newTopic.finalClosureDate.Date;
            }
            _dbContext.Topics.Add(topic);
            _dbContext.SaveChanges();
            return Ok(new
            {
                Success = true,
                Data = topic
            });
        }
        [HttpPut("{topicId}")]
        public IActionResult Update(int topicId, Topic updateTopic)
        {
            var topic = _dbContext.Topics.SingleOrDefault(c => c.id == topicId);
            if (topic == null)
            {
                return NotFound();
            }
            //update

            topic.topicName = updateTopic.topicName;
            topic.closureDate = updateTopic.closureDate.Date;
            topic.finalClosureDate = updateTopic.finalClosureDate.Date;
            _dbContext.SaveChanges();
            return Ok(topic);
        }

        [HttpDelete("{topicId}")]
        public IActionResult Delete(int topicId)
        {
            var topic = _dbContext.Topics.SingleOrDefault(c => c.id == topicId);
            if (topic == null)
            {
                return NotFound();
            }
            //update

            _dbContext.Remove(topic);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
