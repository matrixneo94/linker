using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_project.Models
{

    public class User
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string Position { get; set; }
        public ICollection<Links> Links { get; set; }
    }

}