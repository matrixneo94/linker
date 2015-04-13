using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontenedWeb.Models
{

    [Table("UserProfile")]
    public class UserBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Position { get; set; }
     
        public ICollection<Link> Links { get; set; }
        public override string ToString()
        {
            return UserName;
        }

    }
}
