using ExpressoApi.Data;
using ExpressoApi.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExpressoApi.Controllers
{
    public class MenusController : ApiController
    {
		private ExpressoDbContext m_oExpressoDbContext = new ExpressoDbContext();

		[HttpGet]
		public IHttpActionResult GetMenus()
		{
			var oMenus = m_oExpressoDbContext.Menus.Include("SubMenus");
			//using (MySqlConnection connection = new MySqlConnection("Server = localhost; port = 3306; Database = ExpressoDb; uid = admin; pwd = 1234;"))
			//{
			//	using (ExpressoDbContext contextDB = new ExpressoDbContext())
			//	{
			//		contextDB.Database.CreateIfNotExists();
			//		oMenus = contextDB.Menus.Include("SubMenus").ToList();
			//	}
			//}

			return Ok(oMenus);
		}

		[HttpGet]
		public IHttpActionResult GetMenu(int id)
		{
			var oMenu = m_oExpressoDbContext.Menus.Include("SubMenus").FirstOrDefault(m => m.Id == id);

			if (oMenu == null)
			{
				return NotFound();
			}

			return Ok(oMenu);
		}
	}
}
