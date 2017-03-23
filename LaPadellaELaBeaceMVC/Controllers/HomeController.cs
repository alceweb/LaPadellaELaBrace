using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using LaPadellaELaBeaceMVC.Models;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LaPadellaELaBeaceMVC.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ViewBag.Promo = db.Promos.OrderBy(p => p.Promo_Id).ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Contact(FormInfoViewModel contatti)
        {
            if (ModelState.IsValid)
            {
                MailMessage message = new MailMessage(
                    "webservice@lapadellaelabrace.it",
                    "cesare@cr-consult.eu,lapadellaelabrace@gmail.com",
                    "Richiesta informazioni dal sito lapadellaelabrace.it",
                    "Il giorno " + DateTime.Now + "<br/> è stata inserita una richiesta di informazioni dal sito www.lapadellaelabrace.it<hr/><ul><li> Nome: <strong>" +
                    contatti.Nome +
                     "</strong></li><li> Cognome: <strong>" +
                    contatti.Cognome +
                     "</strong></li><li> Telefono: <strong>" +
                    contatti.Telefono +
                     "</strong></li><li> Mail: <strong>" +
                    contatti.Email +
                     "</strong></li><li> Messaggio: <strong>" +
                    contatti.Messaggio +
                    "</strong></li>"
                    );
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                }
                return RedirectToAction("FormOk", "Home");
            }
            return View(contatti);
        }

        public ActionResult FormOk()
        {
            return View();
        }


        public ActionResult Dove()
        {
            return View();
        }

        public ActionResult Galleria()
        {
            var immagini = Directory.GetFiles(Server.MapPath("/Content/Immagini/Galleria/"));
            ViewBag.Immagini = immagini.ToList();
            return View();
        }

    }
}