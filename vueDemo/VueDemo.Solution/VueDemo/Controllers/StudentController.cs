using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VueDemo.Controllers
{
   
    public class StudentController : Controller
    {
        private static ContactRepository contactRepository = new ContactRepository();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Get()
        {
            return Json(contactRepository.Get(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(Contact contact)
        {
            contactRepository.Put(contact);
            return Json(contactRepository.Get());
        }

        [HttpPost]
        public JsonResult Update(Contact contact)
        {
            contactRepository.Post(contact);
            return Json(contactRepository.Get());
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            var contact = contactRepository.Get(id);
            contactRepository.Delete(id);
            return Json(contactRepository.Get());
        }
    }
    public class ContactRepository
    {
        private static List<Contact> contacts;

        static ContactRepository()
        {
            contacts = new List<Contact>()
        {
            new Contact(){ Id=Guid.NewGuid().ToString(), Name="张三", PhoneNo="123", EmailAddress="zhangsan@gmail.com" },
            new Contact(){ Id=Guid.NewGuid().ToString(), Name="李四", PhoneNo="456", EmailAddress="lisi@gmail.com" },
        };
        }

        public IEnumerable<Contact> Get()
        {
            return contacts;
        }

        public Contact Get(string id)
        {
            return contacts.FirstOrDefault(t => t.Id == id);
        }

        public void Put(Contact contact)
        {
            contact.Id = Guid.NewGuid().ToString();
            contacts.Add(contact);
        }

        public void Post(Contact contact)
        {
            Delete(contact.Id);
            contacts.Add(contact);
        }

        public void Delete(string id)
        {
            Contact contact = contacts.FirstOrDefault(t => t.Id == id);
            contacts.Remove(contact);
        }
    }
    public class Contact
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string EmailAddress { get; set; }
    }
}