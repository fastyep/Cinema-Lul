using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CinemaLul.Models;

namespace CinemaLul.Controllers
{
    public class ClientController : ApiController
    {
        [HttpGet]
        public ShowView[] View()
        {
            using (var data = new lulCinemaEntities())
            {
                return data.Shows.Where(x => x.time > DateTime.Now).AsEnumerable()
                    .Select(x => new ShowView { Id = x.Id, name = x.name, time = x.time }).ToArray();
            }
        }
        [HttpGet]
        public dynamic Buy(int id, short count)
        {
            using (var data = new lulCinemaEntities())
            {
                Show show = data.Shows.Find(id);
                if (show == null)
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "Show_not_found");
                data.ShowTickets.Add(new ShowTicket
                {
                    show = show.Id,
                    count = count,
                    at = DateTime.Now
                });
                data.SaveChanges();
                return new { ok = true };
            }
        }
    }
}
