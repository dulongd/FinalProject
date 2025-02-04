﻿/*
File Name: ApiSearchResult.cs
Description: Convert API Search Result page to object in order to parse results and get list of books returned
Author: Danielle DuLong
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models.ViewModels;

namespace FinalProject.Models.Api
{
    public class ApiSearchResult
    {
        public string keyword { get; set; }
        public string error { get; set; }
        public string total { get; set; }
        public string page { get; set; }

        public IEnumerable<ApiSearchResultViewModel> books { get; set; }
    }
}
