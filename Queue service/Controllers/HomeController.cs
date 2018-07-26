using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Queuservice.DataBase.Model;
using Queuservice.DataBase;
using Queueservice.Xml;

namespace Queue_service.Controllers
{

    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        static List<ITask> data;

        public HomeController()
        {
            data = new List<ITask>();

        }

        [HttpGet]
        public IEnumerable<ITask> Get()
        {
            return data;
        }

        [HttpPost]
        public IActionResult Post([FromBody]string taskXML)
        {
            ITask task = XmlParse.GetHomework(taskXML);
            data.Add(task);
            DBProvider.Insert(task.Name, task.Description, task.IsDone.ToString());
            return Ok(taskXML);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
