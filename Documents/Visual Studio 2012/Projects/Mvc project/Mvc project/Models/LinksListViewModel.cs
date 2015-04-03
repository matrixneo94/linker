﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_project.Models
{
    public class LinksListViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public double Raiting { get; set; }
        public string ShortDescription { get; set; }
        public string Author { get; set; }
    }
}