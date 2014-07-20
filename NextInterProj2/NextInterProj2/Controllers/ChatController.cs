﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NextInterProj2.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using NextInterProj2.Filters;

namespace NextInterProj2.Controllers
{
    public class ChatController : Controller
    {
        //
        // GET: /Chat/
        UsersContext db = new UsersContext();

        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var messages = db.Chats.Include(m => m.Reciever);
            messages = messages.Include(n => n.Sender);
            return View(messages.ToList());
        }

        [Authorize]
        public ActionResult PeopleSearch()
        {
            //var people = db.UserProfiles;
            //return View(people.ToList());
            return View();
        }

        [Authorize]
        public ActionResult PeopleSearchSurname(string surname)
        {
            //var people = db.UserProfiles.Where(x =>
            //    x.LastName.StartsWith(surname, StringComparison.OrdinalIgnoreCase) == true);
            //var people = db.UserProfiles;
            var people = from p in db.UserProfiles
                         where p.LastName == surname
                         select p;
            return PartialView(people.ToList());
        }

        [Authorize]
        [InitializeSimpleMembership]
        [HttpGet]
        public ActionResult Say(int? recieverId)
        {
            if (recieverId == null)
                return HttpNotFound();
            int senderId = (int)WebMatrix.WebData.WebSecurity.CurrentUserId;
            Conversation(recieverId, senderId);
            ViewData["RecieverId"] = recieverId;
            return View();
        }

        private void Conversation(int? recieverId, int senderId)
        {
            ViewBag.Messages = db.Chats.Include(m => m.Reciever).Include(n => n.Sender).
                Where(s => (s.SenderUserId == senderId && s.RecieverUserId == recieverId)
                    ||
                    (s.SenderUserId == recieverId && s.RecieverUserId == senderId)
                ).OrderBy(o => o.Time).ToList();
        }

        [Authorize]
        [InitializeSimpleMembership]
        [HttpPost]
        public ActionResult Say(Chat chat)
        {
            chat.Time = DateTime.Now;
            chat.SenderUserId = (int)WebMatrix.WebData.WebSecurity.CurrentUserId;
            db.Chats.Add(chat);
            db.SaveChanges();
            Conversation(chat.RecieverUserId, chat.SenderUserId);
            return View();
        }
    }
}
