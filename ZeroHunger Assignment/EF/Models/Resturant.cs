using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger_Assignment.EF.Models
{
    public class Resturant
    {
        [Required, Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(100)]
        public string Address { get; set; }
        [Required, StringLength(50)]
        public string Email { get; set; }
        [Required, StringLength(25)]
        public string Password { get; set; }
        [Required, StringLength(11)]
        public string Contact { get; set; }

        public virtual ICollection<CollectRequest> CollectRequests { get; set; }
        public Resturant()
        {
            CollectRequests = new List<CollectRequest>();
        }
    }
}