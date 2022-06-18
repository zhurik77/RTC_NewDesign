using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using tets_bogdan.Models;

namespace tets_bogdan.Controllers
{
    public class mindController : Controller
    {
        public string Index()
        {
            return "Abobus";
        }
        public string Welcome(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        }
        public IActionResult Magic()
        {
            return View();
        }
        public IActionResult DataAggregation(string firstname, string lastname,string middlename, string mesto, string phone, string email, string docs)
        {
            using (RTKDatabaseContext db = new RTKDatabaseContext())
            {
                ViewData["Message"] = "Hello " + firstname + "," + lastname;
                Models.Participant participant = new Participant();
                participant.Birthday = DateTime.Now;
                participant.Mesto = mesto;
                participant.Email = email;
                participant.Documents = docs;
                participant.PhoneNumber = phone;
                participant.name = firstname + " " + lastname + " " + middlename;

                db.Participants.Add(participant);
                db.SaveChanges();
            }

            return View();
        }

    }
}
