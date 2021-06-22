using ExpressoApi.Data;
using ExpressoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExpressoApi.Controllers
{
    public class ReservationsController : ApiController
    {
		ExpressoDbContext m_oExpressoDbContext = new ExpressoDbContext();

		[HttpPost]
		public IHttpActionResult Post(Reservation reservation)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			m_oExpressoDbContext.Reservations.Add(reservation);
			m_oExpressoDbContext.SaveChanges();

			return StatusCode(HttpStatusCode.Created);
		}
    }
}
