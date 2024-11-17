using EventSchedulerImplementaion.Models.Connection;
using EventSchedulerImplementaion.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventSchedulerImplementaion.Controllers
{
    public class EventController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            using (var session = FluentNhibernateHelper.GetSession())
            {

                var EventList = session.Query<Event>().ToList();
                ViewData["Event"] = EventList;

                return View(EventList);
            }


        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event @event)
        {
            if (ModelState.IsValid)
            {
                using (var session = FluentNhibernateHelper.GetSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        @event.CreatedDate = DateTime.Now;
                        @event.UpdatedDate = DateTime.Now;
                        session.Save(@event);
                        transaction.Commit();
                    }
                    return RedirectToAction(nameof(Index));
                }
                
            }
            return View(@event);
        }
    }
}

