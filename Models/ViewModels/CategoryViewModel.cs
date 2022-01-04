/*
File Name: CategoryViewModel.cs
Description:View model for passing the category and status message to the view.
Author: Kavitha
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.ViewModels
{
    public class CategoryViewModel
    {
        public Category Category { get; set; }
        public string StatusMessage { get; set; }

    }
}
