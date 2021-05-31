using MathBot.Models;
using MathBot.Models.ORM.Context;
using MathBot.Models.ORM.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MathBothCommon.Model;
using System.Text;

namespace MathBot.Controllers
{
    public class HomeController : Controller
    {
        private readonly MathBotContext _mathBotContext;

        public HomeController(MathBotContext mathBotContext)
        {
            _mathBotContext = mathBotContext;
        }

        //[Authorize]



        public IActionResult Index()
        {
            //var name = User.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();

            return View();


        }

        [HttpPost]
        public IActionResult Index(Operation model)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            {
                channel.QueueDeclare(
                    queue: "MathQueue",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var message = JsonConvert.SerializeObject(model);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                    routingKey: "MathQueue",
                    basicProperties: null,
                    body: body);
            }

            return View();
        }



        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
