using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger_Assignment.EF.Models
{
    public class AssignedRequest
    {
        [Required, Key]
        public int Id { get; set; }
        [Required, ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [Required, ForeignKey("CollectRequest")]
        public int CollectRequestId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual CollectRequest CollectRequest { get; set; }
    }
}