﻿using FinalProject.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace FinalProject.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;

        public UsersController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IEmailSender emailsender)
        {
            _context = context;
            _userManager = userManager;
            _emailSender = emailsender;
        }


        public async Task<string> CheckIn(int id)
        {
            var book = await _context.Books.FindAsync(id);
            var user = await _userManager.GetUserAsync(User);
            //var email = user.Email;
            var userId = user.Id;
            
            book.DueDate = (DateTime.Now).AddDays(14);
            if (book.Status.Equals("0"))
            {
                book.CheckOutDate = (DateTime.Now);
                var bookInDb = _context.Books.Single(b => b.Id == id);
                bookInDb.CheckOutDate = book.CheckOutDate;
                bookInDb.UserId = userId;
                bookInDb.Status = "1";
                _context.SaveChanges();
                await _emailSender.SendEmailAsync(user.Email, "Book Checked out", " Successfully");
                return "Book Checked out successfully. Your due date is " + book.DueDate.ToString(); ;
            }
            else
            {
                return "Book already checked out";
            }
            

        }
    }
}
