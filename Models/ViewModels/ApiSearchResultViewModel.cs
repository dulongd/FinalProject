﻿/*
File Name: ApiSearchResultViewModel.cs
Description: DTO for book details retrieved from the API
Author: Danielle DuLong
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.ViewModels
{
    public class ApiSearchResultViewModel
    {
        public string title { get; set; }
        public string subtitle { get; set; }
        public string image { get; set; }
        public string isbn13 { get; set; }
        public string url { get; set; }

        public string desc { get; set; }

        public string authors { get; set; }

        public string year { get; set; }
        public int CategoryId { get; set; }
    }
}
