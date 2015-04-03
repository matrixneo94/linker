using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_project.Models
{
    public class Links
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }       
        public string Link { get; set; }
        public double Raiting { get; set; }
        public string AddDate { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }

    }
}