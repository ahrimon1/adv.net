using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger_Assignment.EF.Models
{
    public class CollectRequest
    {
        [Required, Key]
        public int Id { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required, StringLength(10)]
        public string Status { get; set; }
        [Required, ForeignKey("Resturant")]
        public int ResturantId { get; set; }
        public virtual Resturant Resturant { get; set; }
        public virtual ICollection<AssignedRequest> AssignedRequests { get; set; }
        public virtual ICollection<FoodItem> FoodItems { get; set; }

    }
}