﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_project.Models
{
    public class Link
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }       
        public string URL { get; set; }
        public double Raiting { get; set; }
        public string AddDate { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public UserBase Author { get; set; }

    }
}