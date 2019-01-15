using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using QuotingDojo.Models;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("quotes")]
        public IActionResult Submit(Quote quote)
        {
            if(ModelState.IsValid)
            {
                string query = $"INSERT INTO quotes (User, Text) VALUES ('{quote.User}', '{quote.Text}')";
                DbConnector.Execute(query);
                return RedirectToAction("Quotes");

            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("quotes")]
        public IActionResult Quotes()
        {
            List<Dictionary<string, object>> AllQuotes = DbConnector.Query("SELECT * FROM quotes");
            ViewBag.Quotes = AllQuotes;
            return View();
        }
    }
}
