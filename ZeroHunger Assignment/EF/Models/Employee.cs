using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger_Assignment.EF.Models
{
    public class Employee
    {
        [Required, Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string Email { get; set; }
        [Required, StringLength(25)]
        public string Password { get; set; }
        [Required, StringLength(11)]
        public string Contact { get; set; }
        [Required, StringLength(10)]
        public string Role { get; set; }
        [Required, StringLength(100)]
        public string Address { get; set; }

        public virtual ICollection<AssignedRequest> AssignedRequests { get; set; }
        public Employee()
        {
            AssignedRequests = new List<AssignedRequest>();
        }

    }
}