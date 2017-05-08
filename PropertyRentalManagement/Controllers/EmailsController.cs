using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using PropertyRentalManagement.Models;

namespace PropertyRentalManagement.Controllers
{
    public class EmailsController : Controller
    {
        public ActionResult Email()
        {
            ViewBag.Message = "Our contacts:";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Send(EmailViewModel email)
        {
            var client = new SmtpClient();
            var message = new MailMessage();

            message.From = new MailAddress(email.From);
            message.To.Add(new MailAddress("vitalij.shkuratov@gmail.com"));

            message.Subject = email.Subject;
            message.Body = email.Message;
            message.IsBodyHtml = true;


            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("vilalij.shkuratov@gmail.com","password", "smtp.gmail.com");
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;

            client.Send(message);
            return RedirectToAction("Index", "Home");
        }
    }
}